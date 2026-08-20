using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
//using Intensive.Services.Common;
using Intensive.Services.Auditing;
using Intensive.Data.SSDatabase;
using Intensive.Services.Patching;
using Intensive.Services.Patching.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using Intensive.Services.Patching.TicketGenerator;
using Intensive.Services.CTKAPIWrapper;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Patching.Controllers
{
    [Route("ticketgenerator")]
    public class TicketGeneratorController : Controller
    {

        protected ILogger<TicketGeneratorController> log;
        protected PatchingSystemConfig config;
        protected GeneratorConfig generatorConfig;
        PatchingTicketGenerator TicketGenerator;
        AuditTrail audit;
        CTKAPI core;

        public TicketGeneratorController(ILogger<TicketGeneratorController> logger,
                                        IOptions<PatchingSystemConfig> patchConfig,
                                        IOptions<GeneratorConfig> ptgConfig,
                                        PatchingTicketGenerator ptg,
                                        AuditTrail auditTrail,
                                        CTKAPI coreCTKAPI
                                       )
        {
            log = logger;
            config = patchConfig.Value;
            generatorConfig = ptgConfig.Value;
            audit = auditTrail;
            TicketGenerator = ptg;
            core = coreCTKAPI;
        }

        public IActionResult Get()
        {
            try
            {
                //return Ok(TicketGenerator.GetConfig());
                return Ok(generatorConfig);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14100, $"Unable to load Ticket Generator configuration");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]GeneratorConfig newConfig)
        {
            try
            {
                TicketGenerator.SaveConfig(newConfig);
                return Ok();
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("newConfig", JsonConvert.SerializeObject(newConfig));
                APIError err = new APIError(ex, 14101, $"Unexpected error saving Ticket Generator configuration");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Route("progress/{runid}")]
        [HttpGet]
        public IActionResult Get(string runid)
        {
            try
            {
                double pct = TicketGenerator.GetTicketGeneratorProgress(runid);
                return Ok(pct);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("runid", runid);
                APIError err = new APIError(ex, 14102, $"Unable to load Ticket Generator progress data");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Route("preview/{account}")]
        [HttpGet]
        public IActionResult Get(int account)
        {
            try
            {
                //core.BaseURL = "https://staging.core.rackspace.com";
                //core.Login("segment-support", "w_goEz%VhZ3G6l");
                //core.Token = "7e6471e97a7c1fd6f28f8bfef650b6c0";

                //core = new CTKAPI("https://staging.core.rackspace.com", "segment-support", "w_goEz%VhZ3G6l");


                List <string> results = TicketGenerator.Generate(account, true);
                return Ok(results);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 14103, $"Unexpected error when generating preview ticket(s)");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
    }
}
