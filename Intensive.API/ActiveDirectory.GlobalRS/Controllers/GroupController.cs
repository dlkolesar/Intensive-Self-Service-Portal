using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices;
using Microsoft.AspNetCore.Mvc;
using Intensive.Services.ActiveDirectory;

//using Intensive.API.Common;
using Intensive.Data;
using Microsoft.Extensions.Logging;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("/accounts/{accountNumber}/groups")]
    public class GroupController : ADControllerBase
    {
        AdGroup group;
        AdObject adObj;

        public GroupController(ILogger<GroupController> logger,
                               ActiveDirectoryService adsvc,
                               AdObject adobj,
                               AdGroup adgroup,
                               IOptions<AdSystemConfig> adconfig,
                               AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            adObj = adobj;
            group = adgroup;
            audit = audsvc;

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromRoute] int accountNumber, [FromQuery] string filter)
        {
            log.LogDebug($"***filter: {filter}");

            //make sure filter contains "objectCategory=group"
            // if not add it or AND it with the given filter
            // to restrict results to only group objects

            if (string.IsNullOrEmpty(filter))
            {
                filter = "(objectCategory=group)";
            }
            else
            {
                if (!filter.ToLower().Contains("objectcategory=group"))
                {
                    filter = "(&(objectCategory=group)(" + filter + "))";
                }
            }


            //connect to AD
            try
            {
                log.LogDebug($"AccountDN: {GetAccountOU(accountNumber)}");
                string oupath = GetAccountOU(accountNumber);
                ad.Connect(oupath, null);
            }
            catch(ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                List<AdGroup> groups = group.Find(ad.DirectoryRoot, filter);
                foreach (AdGroup g in groups)
                {
                    string pathbase = Request.PathBase.Value.ToLower().Replace(ad.Config.DomainName.ToLower(), g.DomainName);

                    resourceURL = $"https://{Request.Host}{Request.PathBase}{Request.Path}/{g.Name}";
                    results.Resources.Add(resourceURL);
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                ex.Data.Add("filter", filter);
                APIError err = new APIError(ex, 11999, $"Unexpected error searching for groups that match '{filter}'");
                //log.LogError(err.ErrorCode, err.FormattedException());
                log.LogError(ex, err.Message);
                return new ServerError(err);
            }
        }

        [AllowAnonymous]
        [HttpGet("{name}")]
        public IActionResult GetGroup([FromRoute] int accountNumber,
                                      [FromRoute] string name,
                                      [FromQuery] string attributes)
        {
            //connect to AD
            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                if (string.IsNullOrEmpty(attributes))
                {
                    if (name.ToLower().StartsWith("cn="))
                    {
                        group.LoadDN(ad.DirectoryRoot, name);
                    }
                    else
                    {
                        group.Load(ad.DirectoryRoot, name);
                    }
                }
                else
                {
                    List<string> AttrList = attributes.Split(new char[] { ',' }).ToList<string>();
                    //group.Load(ad.DirectoryRoot, name, AttrList);
                    if (name.ToLower().StartsWith("cn="))
                    {
                        group.LoadDN(ad.DirectoryRoot, name, AttrList);
                    }
                    else
                    {
                        group.Load(ad.DirectoryRoot, name, AttrList);
                    }
                }
                return Ok(group);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("name", name);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11999, $"Unable to load group data for {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        public IActionResult Post([FromRoute] int accountNumber, [FromBody] NewAdGroup newGroup, [FromQuery]string path)
        {
            if (newGroup == null)
            {
                return BadRequest("Error parsing input data");
            }

            if (!newGroup.ValidData())
            {
                return BadRequest("There was an issue with the input data.  A group NAME and a GROUPSCOPE are require.  GroupScope must be either 'Universal', 'Global', 'Domain Local'");
            }

            //connect to AD
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect(base.GetAccountOU(accountNumber), null);
                }
                else
                {
                    ad.Connect(path, null);
                }
                
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                group.Create(ad.DirectoryRoot, newGroup.Name, newGroup.GetGroupType());
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unexpected error creating group '{newGroup}'");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            resourceURL = $"https://{Request.Host}{Request.PathBase}{Request.Path}/{newGroup.Name}";

            return Created(resourceURL, null);
        }

 
        [HttpPut("{name}")]
        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        public IActionResult Put([FromRoute] int accountNumber, [FromRoute] string name, [FromBody]AdGroup newGroup)
        {
            //disabled due to complexities with changing the groupScope
            return StatusCode(501);

            //connect to AD
            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                if (name.ToLower().StartsWith("cn="))
                {
                    if (newGroup.Attributes.Count > 0)
                    {
                        group.LoadDN(ad.DirectoryRoot, name,newGroup.Attributes.Keys.ToList<string>());
                    }
                    else
                    {
                        group.LoadDN(ad.DirectoryRoot, name);
                    }
                }
                else
                {
                    if (newGroup.Attributes.Count > 0)
                    {
                        group.Load(ad.DirectoryRoot, name, newGroup.Attributes.Keys.ToList<string>());
                    }
                    else
                    {
                        group.Load(ad.DirectoryRoot, name);
                    }
                }
                group.Attributes.Remove("ADsPath");
                log.LogDebug($"[API] Current Group: {JsonConvert.SerializeObject(group)}");
                log.LogDebug($"[API]   New   Group: {JsonConvert.SerializeObject(newGroup)}");
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("name", name);
                APIError err = new APIError(ex, 11999, $"Unable to load group data for {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //update the group....
            //Dictionary<string, object> OldAttributes;
            try
            {
                audit.Detail = string.Empty;
                if (group.Name != newGroup.Name)
                {
                    log.LogDebug($"[Name] changed from '{group.Name}' to '{newGroup.Name}'");
                    audit.Detail += $"[Name] changed from '{group.Name}' to '{newGroup.Name}'\r\n";
                    group.Name = newGroup.Name;
                }

                if (group.GroupType != newGroup.GroupType)
                {
                    log.LogDebug($"[GroupType] changed from '{group.GroupType}' to '{newGroup.GroupType}'");
                    audit.Detail += $"[GroupType] changed from '{group.GroupType}' to '{newGroup.GroupType}'\r\n";
                    group.GroupType = newGroup.GroupType;
                }

                //OldAttributes = group.Attributes;      // save previous values for audit logging

                log.LogDebug("[API] Updating group attributes....");
                foreach (string attr in newGroup.Attributes.Keys)
                {
                    log.LogDebug($"[API]     {attr}");
                    if (group.Attributes.ContainsKey(attr))
                    {
                        log.LogDebug($"[API]     Comparing Values....");
                        log.LogDebug($"[API]     old: {group.Attributes[attr]}");
                        log.LogDebug($"[API]     new: {newGroup.Attributes[attr]}");
                        if (newGroup.Attributes[attr] != group.Attributes[attr])
                        {
                            audit.Detail += $"[{attr}] changed from '{group.Attributes[attr]}' to '{newGroup.Attributes[attr]}'\r\n";
                            group.Attributes[attr] = newGroup.Attributes[attr];
                        }
                    }
                    else //attr was added
                    {
                        group.Attributes[attr] = newGroup.Attributes[attr];
                        log.LogDebug("[API]   --> Adding new Attribute / value ");
                        group.Attributes.Add(attr, newGroup.Attributes[attr]);
                        audit.Detail += $"[{attr}] changed from NULL to '{newGroup.Attributes[attr]}'\r\n";
                    }
                }


                log.LogDebug($"[API]Attr.Keys: {group.Attributes.Keys.Count}");
                log.LogDebug( "[API]checking if anything was actually changed....");
                //was anything actually changed?
                //if ((!string.IsNullOrEmpty(audit.Detail)) && (group.Attributes.Keys.Count > 0))
                if (!string.IsNullOrEmpty(audit.Detail))
                {
                    log.LogDebug("[API]saving AD Group object....");
                    group.Save();    // save the changes
                }
                else
                {
                    //log.LogDebug("Nothing changed");
                    return NoContent();    //nothing was changed; send back 200 OK
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("group", JsonConvert.SerializeObject(group));
                ex.Data.Add("newGroup", JsonConvert.SerializeObject(newGroup));
                APIError err = new APIError(ex, 11004, $"Unexpected error updating group data for {group.Name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            //write Audit trail entry
            try
            {
                audit.SystemId = config.SystemId;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Update Group {group.DomainName}\\{group.Name}";
                audit.Account = accountNumber;
                audit.TimeStamp = DateTime.UtcNow;
                audit.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("group", JsonConvert.SerializeObject(group));
                ex.Data.Add("newGroup", JsonConvert.SerializeObject(newGroup));
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete("{name}")]
        public IActionResult Delete([FromRoute] int accountNumber, [FromRoute] string name)
        {
            //connect to AD
            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                if (name.ToLower().StartsWith("cn="))
                {
                    group.LoadDN(ad.DirectoryRoot, name);
                }
                else
                {
                    group.Load(ad.DirectoryRoot, name);
                }
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("name", name);
                APIError err = new APIError(ex, 11999, $"Unable to load group data for {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //delete the group....
            try
            {
                group.Delete();
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("name", name);
                APIError err = new APIError(ex, 11999, $"Unable to delete group {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //write Audit trail entry
            try
            {
                audit.SystemId = config.SystemId;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Delete Group {group.DomainName}\\{group.Name}";
                audit.Detail = "";
                audit.Account = accountNumber;
                audit.TimeStamp = DateTime.UtcNow;
                audit.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("group", JsonConvert.SerializeObject(group));
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }
    }

    public class NewAdGroup
    {
        public string Name { get; set; }
        public string GroupScope { get; set; }



        public AdGroupType GetGroupType()
        {
            AdGroupType t = AdGroupType.SecurityEnabled;

            switch (this.GroupScope.ToLower().Trim())
            {
                case "universal": t |= AdGroupType.UniversalGroup; break;
                case "global": t |= AdGroupType.GlobalGroup; break;
                case "domain local": t |= AdGroupType.DomainLocalGroup; break;
            }

            return t;
        }

        public bool ValidData()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            if (string.IsNullOrEmpty(this.GroupScope))
            {
                return false;
            }
            if ((this.GroupScope.ToLower().Trim() != "universal") &&
                 (this.GroupScope.ToLower().Trim() != "global") &&
                 (this.GroupScope.ToLower().Trim() != "domain local"))
            {
                return false;
            }
            return true;
        }
    }
}
