using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Intensive.Data.SSDatabase;
using Intensive.Services.Auditing;
using Intensive.API.Global;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Auditing.Controllers
{
    [ApiController]
    [Route("")]
    public class AuditTrailController : ControllerBase
    {
        ILogger<AuditTrailController> log;
        AuditTrail audit;
        APICollection results;
        SSDatabaseContext db;
        public AuditTrailController(ILogger<AuditTrailController> logger,
                                    SSDatabaseContext dbContext,
                                    AuditTrail audsvc
                                    ) 
        {
            log = logger;
            audit = audsvc;
            db = dbContext;
        }

        [HttpGet("")]
        public IActionResult Get([FromQuery] int? account, 
                                 [FromQuery] int? device,
                                 [FromQuery] int? systemid,
                                 [FromQuery] string userid,
                                 [FromQuery] string action)
        {
            List<AuditTrail> list = new List<AuditTrail>();
            
            try
            {
                //if ( ( account != null) && (account < 0) )
                //{
                //    return BadRequest($"Account number {account} is not valid");
                //}
                //if ( (device != null) && (device < 0) )
                //{
                //    return BadRequest($"Device number {device} is not valid");
                //}
                //if ( (systemid != null) && (systemid < 0) )
                //{
                //    return BadRequest($"System ID number {systemid} is not valid");
                //}

                log.LogDebug($"Searching Audit Trail Entries....");
                list = audit.LoadFiltered(account, device, systemid, userid, action);
                log.LogDebug($"Found {list.Count} matching entries");
                results = new APICollection();

                foreach (AuditTrail a in list)
                {
                    results.Resources.Add($"https://{Request.Host}{Request.PathBase}/{a.Id}");
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 103, ex.Message );
                log.LogError(err.ErrorCode, ex, err.Message);
                return new ServerError(err);
            }
        }






        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest($"Audit Trail id number {id} is not valid");
                }
                
                audit.Load(id);

                return Ok(audit);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 104, ex.Message);
                log.LogError(err.ErrorCode, ex, err.Message);
                return new ServerError(err);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]string value) 
        {
            return StatusCode(405);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return StatusCode(405);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(405);
        }
    }
}
