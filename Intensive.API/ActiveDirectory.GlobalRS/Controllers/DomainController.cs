using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

//using Intensive.API.Common;
using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("")]
    public class DomainController : ADControllerBase
    {
        AdDomain domain;

        public DomainController(ILogger<DomainController> logger,
                                ActiveDirectoryService adsvc,
                                IOptions<AdSystemConfig> adconfig,
                                AdDomain domsvc,
                                AuditTrail audsvc) : base(logger, adsvc,adconfig, audsvc)
        {
            this.domain = domsvc;
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult Get()
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
                domain.Load(ad.DomainContext);
                return Ok(domain);
            }
            catch(ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unable to load Domain information");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
    }
 
}
