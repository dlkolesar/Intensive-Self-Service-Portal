using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intensive.API.Global;
using Intensive.Services.Common;
using Intensive.Services.Auditing;
using Intensive.Data.SSDatabase;
using Intensive.Services.Patching;
using Intensive.Services.Patching.Exceptions;
using Intensive.Data.WSUS;
using System.Text;

namespace Intensive.API.Patching.Controllers
{
    [Route("clients/{deviceNumber}/config")]
    public class ClientConfigController : Controller
    {

        protected ILogger<ClientConfigController> eventLog;
        //protected PatchingClientBasic BasicClient;
        //protected PatchingClientAdvanced AdvancedClient;
        protected PatchingClient Client;
        object BasicClient = null;

        public ClientConfigController(ILogger<ClientConfigController> logger)
        {
            //BasicClient = basic;
            //AdvancedClient = adv;
            eventLog = logger;
        }

        [HttpGet]
        //[ResponseCache(CacheProfileName = "Default")]
        public IActionResult Get(int deviceNumber)
        {
            if (deviceNumber <= 0) { return BadRequest(); }

            //get basic config data 
            try
            {
               // BasicClient.Load(deviceNumber);
                return Ok(BasicClient);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (PatchingWSUSConnectionException wsusConnEx)
            {
                return Ok(BasicClient);
            }
            catch (PatchingWSUSNotFoundException wsusnf)
            {
                return Ok(BasicClient);
            }
            catch (Exception ex)
            {
                APIError err = new APIError();
                eventLog.LogError(err.ErrorCode, ex, err.Message + ": " + ex.Message);
                return new ServerError(err);
            }
        }


        [HttpPut]
        public IActionResult Put([FromRoute] int deviceNumber, [FromBody] object o)
        {
            //Client = new PatchingClient();
            //Client.Load(deviceNumber);

            //if (Client.PatchingLevel == 2)
            //{
            //    AdvancedClient.Load(deviceNumber);
            //    AdvancedClient.Save();
            //    return Ok("Advanced Client");
            //}
            //else
            //{
            //    BasicClient.Load(deviceNumber);
            //    BasicClient.Save();
            //    return Ok("Basic Client");
            //}


            //string errors = this.ValidPatchingClientConfig(pcb);
            //if (errors == "")
            //{
            //PatchClient.Load(deviceNumber);
            //PatchClient.ScheduledDay = pcb.ScheduledDay;
            //PatchClient.ScheduledTime = pcb.ScheduledTime;
            //PatchClient.ScheduledWeek = pcb.ScheduledWeek;
            //PatchClient.Save();
            //return NoContent();
            //}
            //else
            //{
                return BadRequest();
            //}
        }
       

        //private string ValidPatchingClientConfig(PatchingClientBasic pcb)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    if ((pcb.ScheduledWeek < 1) || (pcb.ScheduledWeek > 3))
        //    {
        //        sb.AppendLine($"Scheduled Week is not valid");
        //    }

        //    if ((pcb.ScheduledDay < 0) || (pcb.ScheduledDay > 7))
        //    {
        //        sb.AppendLine($"Scheduled Day is not valid");
        //    }

        //    if ((pcb.ScheduledTime < 0) || (pcb.ScheduledTime > 23))
        //    {
        //        sb.AppendLine($"Scheduled Time is not valid");
        //    }

        //    return sb.ToString();
        //}

    }
}
