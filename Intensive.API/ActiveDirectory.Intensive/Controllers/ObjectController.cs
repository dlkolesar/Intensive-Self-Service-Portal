using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    [ApiController]
    [Route("objects")]
    public class ObjectController : ADControllerBase
    {
        AdObject adObject;

        public ObjectController(ILogger<ObjectController> logger,
                                ActiveDirectoryService adsvc,
                                IOptions<AdSystemConfig> adconfig,
                                AdObject adobj,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            this.adObject = adobj;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery] string filter, [FromQuery] string path,  [FromQuery]string attributes)
        {
            if (string.IsNullOrEmpty(filter)) 
            {
                return (BadRequest("a 'filter' is required in the querystring"));
            }

            try
            {
                // ad.Connect();
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect();
                }
                else
                {
                    ad.Connect(path, null);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("filter", filter);
                ex.Data.Add("path", path);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            DirectoryEntry root;
            try
            {
                //if (string.IsNullOrEmpty(path))
                //{
                    root = ad.DirectoryRoot;
                //}
                //else
                //{
                //    try
                //    {
                //        root = new DirectoryEntry($"LDAP://{path}");
                //    }
                //    catch (Exception ex)
                //    {
                //        return BadRequest($"AD path '{path}' was not found or could not be accessed");
                //    }
                //}

                string res = string.Empty;

                List<AdObject> lst = adObject.Find(root, filter);
                foreach (AdObject o in lst)
                {
                    if (o.IsContainer) { res = "/containers/"; }
                    if (o.IsUser) { res = "/users/"; }
                    if (o.IsGroup) { res = "/groups/"; }
                    if (o.IsComputer) { res = "/computers/"; }
                    log.LogDebug($"obj  Domain: {o.DomainName}");
                    log.LogDebug($"curr Domain: {config.DomainName.ToLower()}");
                    if (o.DomainName != config.DomainFQDN.ToLower())
                    {
                        //change the domain name in the URL
                        string pb = Request.PathBase.ToString();
                        pb = pb.Replace($"domains/{config.DomainName.ToLower()}", $"domains/{o.DomainName}");
                        resourceURL = $"https://{Request.Host}{pb}{res}{o.DN}";
                    }
                    else
                    {
                        resourceURL = $"https://{Request.Host}{Request.PathBase}{res}{o.DN}";
                    }

                    //resourceURL = $"https://{Request.Host}{Request.PathBase}{res}{o.DN}";
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
                ex.Data.Add("filter", filter);
                ex.Data.Add("path", path);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11999, $"Unable to load OU/Container information");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        [AllowAnonymous]
        [HttpGet("{dn}")]
        public IActionResult GetObject([FromRoute]string dn, [FromQuery]string attributes)
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
                //dn was specified in the querystring
                //get the object and return it
                if (string.IsNullOrEmpty(attributes))
                {
                    adObject.LoadDN(ad.DirectoryRoot, dn);
                }
                else
                {
                    adObject.LoadDN(ad.DirectoryRoot, dn, attributes.Split(new char[] { ',' }).ToList<string>());
                }
                return Ok(adObject);

            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("dn", dn);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11999, $"Unable to load object information");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
