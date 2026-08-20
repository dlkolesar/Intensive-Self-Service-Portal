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

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Patching.Controllers
{
    [Route("ticketgenerator/history")]
    public class TicketGeneratorHistoryController : Controller
    {

        protected ILogger<TicketGeneratorHistoryController> log;
        protected PatchingSystemConfig config;
        PatchingTicketGenerator TicketGenerator;
        PatchingTicketHistory PatchingHistory;
        AuditTrail audit;

        public TicketGeneratorHistoryController(ILogger<TicketGeneratorHistoryController> logger,
                                        IOptions<PatchingSystemConfig> patchConfig,
                                        PatchingTicketGenerator ptg,
                                        PatchingTicketHistory pth,
                                        AuditTrail auditTrail
                                       )
        {
            log = logger;
            config = patchConfig.Value;
            audit = auditTrail;
            TicketGenerator = ptg;
            PatchingHistory = pth;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] int? account,
                                 [FromQuery] string runid
                                )
        {
            List<PatchingTicketHistory> list = new List<PatchingTicketHistory>();
            try
            {
                if ((account != null) && (account < 0))
                {
                    return BadRequest($"Account number {account} is not valid");
                }

                //if (!string.IsNullOrEmpty(ticket))
                //{
                //    Regex re = new Regex("^[0-9]{6}.[0-9]{5}$", RegexOptions.IgnoreCase);

                //    if (!re.IsMatch(ticket))
                //    {
                //        return BadRequest($"'{ticket}' is not a valid ticket number");
                //    }
                //}

                if (!string.IsNullOrEmpty(runid))
                {
                    Regex re = new Regex("^[0-9]{6}$", RegexOptions.IgnoreCase);

                    if (!re.IsMatch(runid))
                    {
                        return BadRequest($"'{runid}' is not a valid RunId");
                    }
                }

                //if (!string.IsNullOrEmpty(ticketType))
                //{
                //    if ( (ticketType != "manual") || (ticketType != "automatic") || (ticketType != "advanced"))
                //    {
                //        return BadRequest($"'{ticketType}' is not a valid value for ticketType; ticketType must be 'manual', 'automatic' or 'advanced'");
                //    }
                        
                //}

                //list = TicketGenerator.Find(account, ticket, runid, ticketType);
                list = PatchingHistory.Find(account, runid);
                APICollection result = new APICollection();
                foreach( PatchingTicketHistory hist in list)
                {
                    result.Resources.Add($"https://{Request.Host}{Request.PathBase}/ticketgenerator/history/{hist.CoreTicket}");

                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", (account==null)?"":account.ToString());
                ex.Data.Add("runid", (string.IsNullOrEmpty(runid)) ? "" : runid.ToString());
                APIError err = new APIError(ex, 14104, $"Unable to load Ticket Generator history");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }

        //public IActionResult Post([FromBody]PatchingTicketHistory newHistory)
        //{
        //    try
        //    {
        //        TicketGenerator.SaveTicketHistory(newHistory);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        APIError err = new APIError(2101);
        //        eventLog.LogError(err.ErrorCode, ex, err.Message);

        //        return new ServerError(err);
        //    }
        //}


        [Route("{ticket}")]
        [HttpGet]
        public IActionResult Get(string ticket)
        {
            try
            {
                //TicketGenerator.SetUpdateFlag(ticket);
                PatchingHistory.Load(ticket);
                return Ok(PatchingHistory);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("ticket", ticket);
                APIError err = new APIError(ex, 14104, $"Unable to load Ticket Generator history");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Route("{ticket}")]
        [HttpPut]
        public IActionResult Put( string ticket, [FromBody] bool updated)
        {
            try
            {
                PatchingHistory.Load(ticket);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("ticket", ticket);
                APIError err = new APIError(ex, 14104, $"Unable to load Ticket Generator history");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                PatchingHistory.SetUpdateFlag(true);
                return Ok();
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("ticket", ticket);
                ex.Data.Add("updated", updated);
                APIError err = new APIError(ex, 14105, $"Unexpected error when setting mass update flag");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

    }
}
