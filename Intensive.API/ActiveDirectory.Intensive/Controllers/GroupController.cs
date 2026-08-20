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

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    [ApiController]
    public class GroupController : ADControllerBase
    {
        AdGroup group;
        AdObject adObj;

        public GroupController(ILogger<UserController> logger,
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
        [Route("groups")]
        [HttpGet]
        public IActionResult Get([FromQuery] string filter, [FromQuery]string path)
        {
            log.LogDebug($"***path: {path}");
            log.LogDebug($"***filter: {filter}");

            //make sure filter contains "objectClass=group"
            // if not add it or AND it with the given filter
            // to restrict results to only group objects

            if (string.IsNullOrEmpty(filter))
            {
                return BadRequest("a valid LDAP filter is required");
            }
            else
            {
                if (!filter.ToLower().Contains("objectclass=group"))
                {
                    filter = "(&(objectclass=group)(" + filter + "))";
                }
            }


            //connect to AD
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect();
                }
                else
                {
                    //ad.Connect(base.ToDN(path), null);
                    ad.Connect(path, null);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("filter", filter);
                ex.Data.Add("path", path);
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

                    resourceURL = $"https://{Request.Host}{pathbase}{Request.Path.Value.TrimEnd(new char[] { '/' })}/{g.Name}";
                    results.Resources.Add(resourceURL);
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                ex.Data.Add("filter", filter);
                ex.Data.Add("path", path);
                APIError err = new APIError(ex, 11999, $"Unexpected error searching for groups that match '{filter}'");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [AllowAnonymous]
        [Route("groups/{name}")]
        [HttpGet]
        public IActionResult GetGroup([FromRoute] string name,
                                      [FromQuery] string attributes)
        {
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
    }
}
