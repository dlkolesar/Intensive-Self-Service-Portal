using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices;
using Microsoft.AspNetCore.Mvc;
using Intensive.Services.ActiveDirectory;
//using Intensive.Services.eDirectory;

//using Intensive.API.Common;
using Intensive.Data;
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

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    [ApiController]
    [Route("groups/{name}/members")]
    public class GroupMembersController : ADControllerBase
    {

        AdGroup grp;
        AdUser user;
        AdObject adObjectResolver;

        //eDir edir;
        //eDirUser ediruser;
        AdSystemConfig adcfg;

        //private string ldapFilter_AllUsers = "(&(objectCategory=person)(objectClass=user))";
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
            user = AdUser;
            adcfg = adconfig.Value;
        }


        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult Get([FromRoute] string name)
        //{
        //    //connect to AD
        //    try
        //    {
        //        ad.Connect();
        //    }
        //    catch (Exception ex)
        //    {
        //        APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }


        //    try
        //    {
        //        grp.Load(ad.DirectoryRoot, name);

        //        log.LogDebug($"Getting Group Members...");
        //        List<AdObject> members = grp.GetMembers();
        //        string objType = string.Empty;

        //        foreach (AdObject mem in members)
        //        {
        //            log.LogDebug($"mem: {JsonConvert.SerializeObject(mem)}");
        //            objType = "objects";
        //            if (mem.IsComputer) { objType = "computers"; }
        //            if (mem.IsGroup) { objType = "groups"; }
        //            if (mem.IsUser) { objType = "users"; }

        //            resourceURL = $"https://{Request.Host}{Request.PathBase}/{objType}/{mem.DN}";
        //            results.Resources.Add(resourceURL);
        //        }

        //        return Ok(results);
        //    }
        //    catch (ADNotFoundException nf)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        APIError err = new APIError(ex, 11999, $"Unable to load group data for {name}");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }
        //}


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromRoute] string name)
        {
            //connect to AD
            try
            {
                ad.Connect();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                log.LogDebug($"Getting Group and Members...");
                grp.Load(ad.DirectoryRoot, name, new List<string> { "member" }); 


                List<string> memberDNs = grp.GetMembers();
                log.LogDebug($"members: {memberDNs.Count}");

                foreach (string dn in memberDNs)
                {
                    //log.LogDebug($"member dn: {dn}");
                    //adObjectResolver.LoadDN(ad.DirectoryRoot, dn, new List<string> { "sAMAccountname" });

                    //if (adObjectResolver.IsComputer) 
                    //{ 
                    //    resourceURL = $"https://{Request.Host}{Request.PathBase}/computers/{adObjectResolver.Name}";
                    //}
                    //if (adObjectResolver.IsGroup) 
                    //{
                    //    resourceURL = $"https://{Request.Host}{Request.PathBase}/groups/{adObjectResolver.Name}";
                    //}
                    //if (adObjectResolver.IsUser) 
                    //{
                    //    resourceURL = $"https://{Request.Host}{Request.PathBase}/users/{adObjectResolver.Attributes["sAMAccountname"].ToString()}";
                    //}

                    resourceURL = $"https://{Request.Host}{Request.PathBase}/objects/{dn}";
                    results.Resources.Add(resourceURL);
                }

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
        public IActionResult Post([FromRoute] string name, [FromBody] string memberDN)
        {
            return StatusCode(501);
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
                ad.Connect();
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

                Regex re = new Regex("\\d-RAX", RegexOptions.IgnoreCase);
                if (!re.IsMatch(grp.Name))
                {
                    return BadRequest("At this time members can only be added to <account>-Rax groups");
                }


                try
                {
                    user.LoadDN(ad.DirectoryRoot, memberDN);
                }
                catch(Exception ex)
                {
                    return BadRequest($"memberDN must be a User Object with your employeeid assigned to it");
                }
                
                if (!ValidMemberObject(user).Result){
                    return Forbid("You can only add user accounts that have your employeeid assigned to it");
                }

                log.LogDebug($"[API]Adding member(s)");
                //string mem = string.Empty;
                //StringBuilder auditDetail = new StringBuilder();

                //foreign Security Principals will not be allowed to 
                //be group members as per the AD Engineers

                log.LogDebug($"Adding {memberDN} to group");
                grp.AddMember(memberDN);


                //write Audit trail entry
                //if (auditDetail.Length > 0) //if no members actually added
                //{
                    try
                    {
                        audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                        audit.Action = $"Add Member(s) to group {grp.DomainName.ToUpper()}\\{grp.Name}";
                        audit.Detail = memberDN;
                        audit.SystemId = adcfg.SystemId;
                        audit.TimeStamp = DateTime.UtcNow;
                        audit.Save();
                    }
                    catch (Exception ex)
                    {
                        APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                        log.LogError(err.ErrorCode, err.FormattedException());
                        return new ServerError(err);
                    }
                //}

                return NoContent();
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
        public IActionResult Delete([FromRoute] string name, [FromRoute] string memberDN)
        {
            return StatusCode(501);

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Group name is required in the URL");
            }

            //if (memberDN.Count != 1)
            //{
            //    return BadRequest("An array of member DN's is required in the body of the HTTP request. At this time only 1 DN may be removed at a time");
            //}


            try
            {
                ad.Connect();
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

                Regex re = new Regex("\\d-RAX", RegexOptions.IgnoreCase);
                if (!re.IsMatch(grp.Name))
                {
                    return BadRequest("At this time members can only be removed from <account>-Rax groups");
                }


                //validate authorization
                //user can only add themselves to a group
                string sso = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sso").Value;

                //try
                //{
                //    edir.Connect();
                //    ediruser.Load(edir, sso, new List<string> { "employeeid" });
                //}
                //catch (eDirException e)
                //{
                //    log.LogDebug($"Exception looking up RSAD user");
                //    log.LogDebug(e.Message);
                //}

                string mem = string.Empty;
                StringBuilder sb = new StringBuilder();
                StringBuilder auditDetail = new StringBuilder();

                //foreach (string dn in memberDN)
                //{

                    user.LoadDN(ad.DirectoryRoot, memberDN, new List<string> { "employeeid" });
                    if ((user == null) || (user.DomainName.ToUpper() != "INTENSIVE"))
                    {
                        sb.AppendLine($"{memberDN} is not an INTENSIVE user.  Only INTENSIVE user accounts can be removed from a group at this time");
                        //continue; //skip to next member DN
                    }


                //or user is a member of ldap group  xxxxxxxxxxxxxxxxx(for ADC, myRack, etc.....)
                //if (user.Attributes["employeeid"].ToString() == ediruser.Attributes["employeeid"].ToString())
                //{
                //    log.LogDebug($"Removing {mem} from group");
                //    grp.RemoveMember(mem);
                //    auditDetail.AppendLine(memberDN);
                //}
                //else
                //{
                //    return Forbid("You can only add your own userid to a group");
                //}

                if (!ValidMemberObject(user).Result)
                {
                    return Forbid("You can only add user accounts that have your employeeid assigned to it");
                }
                //}

                //write Audit trail entry
                if (auditDetail.Length > 0)
                {
                    try
                    {
                        audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                        audit.Action = $"Removed Member(s) from group {grp.DomainName.ToUpper()}\\{grp.Name}";
                        audit.Detail = auditDetail.ToString();
                        audit.SystemId = adcfg.SystemId;
                        audit.TimeStamp = DateTime.UtcNow;
                        audit.Save();
                    }
                    catch (Exception ex)
                    {
                        APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                        log.LogError(err.ErrorCode, err.FormattedException());
                        return new ServerError(err);
                    }
                }
                return Ok(sb.ToString());
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

        ////[Authorize(Policy = "Default")]
        ////[HttpDelete]
        ////public IActionResult DeleteMemberList([FromRoute] string name, [FromBody] List<string> memberDNList)
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


        ////        grp.RemoveMember(memberDNList);

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


        private async Task<bool> ValidMemberObject(AdUser user)
        {
            bool ok = false;
            string sso = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            string token = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "token").Value;

            //RSAD API - get employeeid where userid=sso from claims("sso")
            //ok = rsad empid == aduser.attributes["employeeid"]

            APIClient rsad = new APIClient();
            rsad.URL = $"{Constants.RACKSPACE_AD_API}/user/{CurrentUserSSO}";
            rsad.Headers.Add("X-Auth-Token", token);
            await rsad.ExecuteAsync();

            if (rsad.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            RackspaceAdApiResponse response = rsad.ReadObjectResponse<RackspaceAdApiResponse>();
            RackspaceAdUser rsadUser = (RackspaceAdUser)response.Data;

            return (rsadUser.employeeID == user.Attributes["employeeid"].ToString());
        }

        //private AdUser GetIntensiveUser(string dn)
        //{
        //    log.LogDebug($"*** CROSS_DOMAIN API CALL ***");
        //    APIClient req = new APIClient();
        //    log.LogDebug($"PathBase={Request.PathBase}");
        //    req.URL = $"https://{Request.Host}/ad/v1/domains/intensive/users/{dn}?attributes=employeeid,objectsid";

        //    log.LogDebug($"url: {req.URL}");
        //    req.Execute();

        //    if (req.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        return req.ReadObjectResponse<AdUser>();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


    }




    public class RackspaceAdApiResponse
    {
        public string Server { get; set; }
        public string TimeStamp { get; set; }
        public object Data { get; set; }
    }
}
