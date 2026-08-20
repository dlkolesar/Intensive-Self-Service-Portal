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

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    [ApiController]
    [Route("containers")]
    public class ContainerController : ADControllerBase
    {
        //DirectoryEntry root;
        AdContainer adContainer;

        public ContainerController(ILogger<DomainController> logger,
                                ActiveDirectoryService adsvc,
                                IOptions<AdSystemConfig> adconfig,
                                AdContainer adobj,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            this.adContainer = adobj;
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult Get([FromQuery] string filter, [FromQuery]string path)
        {
            string oupath = string.Empty;
            //string ouFilter = "(|(objectclass=container)(objectclass=organizationalUnit)";
            if (string.IsNullOrEmpty(filter))
            {
                return BadRequest($"A valid LDAP filter is required");
            }
            //else
            //{
            //    if ( (!filter.ToLower().Contains("objectclass=container"))
            //      && (!filter.ToLower().Contains("objectclass=organizationalunit")) )
            //    {
            //        filter = $"(&({ouFilter})(" + filter + "))";
            //    }
            //}

            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect();
                }
                else
                {
                    ad.Connect(base.ToDN(path), null); 
                }
                
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {

                List<AdContainer> containers = adContainer.Find(ad.DirectoryRoot, filter);
                foreach (AdContainer c in containers)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}{Request.Path}/{c.DN}";
                    results.Resources.Add(resourceURL);
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unable to load OU/Container information");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        [AllowAnonymous]
        [HttpGet("{dn}")]
        public IActionResult GetContainer([FromRoute] string dn)
        {
            try
            {
                ad.Connect();
            }
            catch (Exception ex)
            {
                ex.Data.Add("dn", dn);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                log.LogDebug($"Loading {dn}");
                adContainer.LoadDN(ad.DirectoryRoot, dn); 

                return Ok(adContainer);

            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("dn", dn);
                APIError err = new APIError(ex, 11999, $"Unable to load OU/Container information");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        
    }
}
