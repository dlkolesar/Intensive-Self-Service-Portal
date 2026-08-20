using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Intensive.Data;
using Intensive.Services.Common;
using Microsoft.Extensions.Logging;
using Intensive.API.Global;
using Microsoft.AspNetCore.Authorization;
using Intensive.Services.Auditing;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Common.Controllers
{
    [ApiController]
    [Route("accounts/{number}/servers")]
    public class AccountServersController : ControllerBase
    {
        protected ILogger<AccountServersController> log;
        protected Server svr;
        private AuditTrail audit;

        public AccountServersController(ILogger<AccountServersController> logger,
                                Server svrSvc, AuditTrail audSvc
                                )
        {
            log = logger;
            svr = svrSvc;
            audit = audSvc;
        }
        [HttpGet]
        public IActionResult GetServers([FromRoute] int number)
        {
            APICollection results = new APICollection();
            string resourceURL;

            try { 
                List<Server> lst = svr.Find(number);
                foreach(Server s in lst)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/accounts/{number}/servers/{s.DeviceNumber}";
                    results.Resources.Add(resourceURL);
                }
                return Ok(results);
            }
            catch (InvalidOperationException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 200, $"Unexpected error finding servers for account {number}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        // GET api/values/5
        [HttpGet("{serverNumber}")]
        public IActionResult Get([FromRoute] int number,[FromRoute] int serverNumber)
        {
            try
            {
                svr.Load(serverNumber);
                return Ok(svr);
            }
            catch(InvalidOperationException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 201, $"Unable to load server {serverNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }

            }
}
