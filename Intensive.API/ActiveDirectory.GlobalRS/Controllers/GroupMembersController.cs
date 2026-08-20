using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices;
using Microsoft.AspNetCore.Mvc;
using Intensive.Services.ActiveDirectory;
using Microsoft.Extensions.Logging;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("/accounts/{accountNumber}/groups/{name}/members")]
    public class GroupMembersController : ADControllerBase
    {

        AdGroup grp;
        AdUser user;
        AdObject adObjectResolver;
        AdObject adObject;

        AdSystemConfig adcfg;

        public GroupMembersController(ILogger<GroupMembersController> logger,
                                ActiveDirectoryService adsvc,
                                AdGroup adgroup,
                                AdUser AdUser,
                                AdObject adobject,
                                IOptions<AdSystemConfig> adconfig,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            grp = adgroup;
            adObjectResolver = adobject;
            adObject = adobject;
            user = AdUser;
            adcfg = adconfig.Value;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromRoute] int accountNumber, [FromRoute] string name)
        {
            log.LogDebug($"***name: {name}");
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Group name is required in the URL");
            }

            //connect to AD
            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                grp.Load(ad.DirectoryRoot, name);
                List<string> members = grp.GetMembers();
                string objType = string.Empty;

                foreach (string mem in members)
                {
                    adObjectResolver.LoadDN(ad.DirectoryRoot, mem);
                    if (adObjectResolver.IsComputer) { objType = "computers"; }
                    if (adObjectResolver.IsGroup) { objType = "groups"; }
                    if (adObjectResolver.IsUser) { objType = "users"; }
                    if (adObjectResolver.IsForeignSecurityPrincipal)
                    {
                        //resolve FSP to a new ADObject
                        AdObject fspMember = adObjectResolver.ResolveFSP();
                        resourceURL = $"https://{Request.Host}{Request.PathBase}/domains/intensive/{objType}/{fspMember.Name}";
                    }
                    else
                    {
                        resourceURL = $"https://{Request.Host}{Request.PathBase}/accounts/{accountNumber}/{objType}/{adObjectResolver.Name}";
                    }

                    results.Resources.Add(resourceURL);
                } //foreach

                return Ok(results);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unable to load group data for {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

  
        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] int accountNumber, [FromRoute] string name, [FromBody] string memberDN)
        {
            //return StatusCode(501);
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Group name is required in the URL");
            }

            if (string.IsNullOrEmpty(memberDN))
            {
                return BadRequest("A member DN is required in the body of the HTTP request. At this time only 1 DN may be added at a time");
            }

            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (Exception ex)
            {
                ex.Data.Add("name", name);
                ex.Data.Add("memberDN", memberDN);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            //get the group and group members
            try
            {
                log.LogDebug($"Loading Group {name}....");
                if (name.ToLower().StartsWith("cn="))
                {
                    grp.LoadDN(ad.DirectoryRoot, name);
                }
                else
                {
                    grp.Load(ad.DirectoryRoot, name);
                }


                log.LogDebug($"[API]Adding member(s)");
                string mem = string.Empty;


                log.LogDebug($"Adding {memberDN} to group");
                grp.AddMember(memberDN);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unexpected error Adding {memberDN} to group {name}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //write Audit trail entry
            try
            {
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Add Member(s) to group {grp.DomainName.ToUpper()}\\{grp.Name}";
                audit.Detail = memberDN;
                audit.SystemId = adcfg.SystemId;
                audit.TimeStamp = DateTime.UtcNow;
                await audit.SaveAsync();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry:{ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            return NoContent();
        }


        ////public IActionResult PutMemberObject([FromRoute] string name, [FromBody] AdObject member)
        ////{
        ////    if (string.IsNullOrEmpty(name))
        ////    {
        ////        return BadRequest("Group name is required in the URL");
        ////    }

        ////    if (member == null)
        ////    {
        ////        return BadRequest("An AdObject, AdUser, AdGroup, or AdComputer object is required in the the body");
        ////    }


        ////    try
        ////    {
        ////        ad.Connect();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
        ////        log.LogError(err.ErrorCode, err.FormattedException());
        ////        return new ServerError(err);
        ////    }


        ////    try
        ////    {
        ////        log.LogDebug($"[API]Loading Group {name}....");
        ////        if (name.ToLower().StartsWith("cn="))
        ////        {
        ////            grp.LoadDN(ad.DirectoryRoot, name);
        ////        }
        ////        else
        ////        {
        ////            grp.Load(ad.DirectoryRoot, name);
        ////        }


        ////        log.LogDebug($"[API]Authenticating {name}....");
        ////        //validate authorization
        ////        //user can only add themselves to a group
        ////        string sso = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sso").Value;

        ////        try
        ////        {
        ////            edir.Connect();
        ////            ediruser.Load(edir, sso, new List<string> { "employeeid" });
        ////        }
        ////        catch (eDirException e)
        ////        {
        ////            log.LogDebug($"[API]Exception looking up RSAD user");
        ////            log.LogDebug(e.Message);
        ////            return Forbid("Unexpected Error authenticating your SSO/Identity Token");
        ////        }



        ////            //or user is a member of ldap group  xxxxxxxxxxxxxxxxx(for ADC, myRack, etc.....)
        ////            if (user.Attributes["employeeid"].ToString() == ediruser.Attributes["employeeid"].ToString())
        ////            {
        ////                log.LogDebug($"Adding {member.DN} to group");
        ////                grp.AddMember(member.DN);
        ////            }
        ////            else
        ////            {
        ////                return Forbid();
        ////            }


        ////        return NoContent();
        ////    }
        ////    catch (ADNotFoundException nf)
        ////    {
        ////        return NotFound();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        APIError err = new APIError(ex, 11999, $"Unable to load group data for {name}");
        ////        log.LogError(err.ErrorCode, err.FormattedException());
        ////        return new ServerError(err);
        ////    }
        ////}


        ////[Authorize(Policy = "Default")]
        ////[HttpPut]
        ////public IActionResult PutMemberList([FromRoute] string name, [FromBody] List<string> memberDNList)
        ////{
        ////    if (string.IsNullOrEmpty(name))
        ////    {
        ////        return BadRequest("Group name is required in the URL");
        ////    }

        ////    if (memberDNList == null)
        ////    {
        ////        return BadRequest("A member DN  or an array of member DN's is required in the body of the HTTP request");
        ////    }


        ////    try
        ////    {
        ////        ad.Connect();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
        ////        log.LogError(err.ErrorCode, err.FormattedException());
        ////        return new ServerError(err);
        ////    }


        ////    try
        ////    {
        ////        if (name.ToLower().StartsWith("cn="))
        ////        {
        ////            grp.LoadDN(ad.DirectoryRoot, name);
        ////        }
        ////        else
        ////        {
        ////            grp.Load(ad.DirectoryRoot, name);
        ////        }


        ////        grp.AddMember(memberDNList);

        ////        return NoContent();
        ////    }
        ////    catch (ADNotFoundException nf)
        ////    {
        ////        return NotFound();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        APIError err = new APIError(ex, 11999, $"Unable to load group data for {name}");
        ////        log.LogError(err.ErrorCode, err.FormattedException());
        ////        return new ServerError(err);
        ////    }
        ////}

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete("{memberDN}")]
        public IActionResult Delete([FromRoute] int accountNumber, [FromRoute] string name, [FromRoute] string memberDN)
        {
            //return StatusCode(501);

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Group name is required in the URL");
            }

            if ( (!memberDN.ToLower().StartsWith("cn=") ) || (!memberDN.ToLower().Contains(",dc=")) )
            {
                return BadRequest($"'{memberDN}' is not a valid DistinguishedName(DN)");
            }


            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                if (name.ToLower().StartsWith("cn="))
                {
                    grp.LoadDN(ad.DirectoryRoot, name);
                }
                else
                {
                    grp.Load(ad.DirectoryRoot, name);
                }

                log.LogDebug($"Removing {memberDN} from group");
                grp.RemoveMember(memberDN);

            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unexpected error removing {memberDN} from group {name}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Removed Member from group {grp.DomainName.ToUpper()}\\{grp.Name}";
                audit.Detail = memberDN;
                audit.SystemId = adcfg.SystemId;
                audit.TimeStamp = DateTime.UtcNow;
                audit.Save();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry:{ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
                
            return NoContent();
        }
    }
}
