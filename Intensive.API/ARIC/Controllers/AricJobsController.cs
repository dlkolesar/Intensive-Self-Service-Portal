using System;
using Intensive.Services.Aric;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intensive.API.Global;
using Intensive.Data.SSDatabase;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Intensive.Services.Patching;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Intensive.Services.Patching.Exceptions;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ARIC.Controllers
{
    [ApiController]
    public class AricJobsController : ControllerBase
    {
        APICollection results = new APICollection();
        protected ILogger<AricJobsController> log;
        AricJob aricJob;
        AricDataHandlerPatching adhp;
        SSDatabaseContext db;
        IConfiguration apiConfig;
        PatchingClient client;

        public AricJobsController(ILogger<AricJobsController> logger,
                                            SSDatabaseContext dbContext,
                                            AricJob aricjob,
                                            AricDataHandlerPatching aricDataHandler,
                                            PatchingClient pc,
                                            IConfiguration config
                                          )
        {
            log = logger;
            aricJob = aricjob;
            db = dbContext;
            adhp = aricDataHandler;
            apiConfig = config;
            client = pc;
        }

        [HttpGet]
        [Route("jobs")]
        public IActionResult Get([FromQuery] int systemid, [FromQuery] int accountNumber, [FromQuery] int deviceNumber)
        {
            List<AricJob> jobs = new List<AricJob>();

            if (systemid <= 0) 
            {
                return BadRequest();
            }

            if ( (accountNumber <= 0) && (deviceNumber <= 0) )
            {
                return BadRequest();
            }

            results = new APICollection();
            string resourceURL;
            try
            {

                jobs = aricJob.Find(systemid, accountNumber, deviceNumber);

                foreach (AricJob j in jobs)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/jobs/{j.EventId}";
                    results.Resources.Add(resourceURL);
                }

                return Ok(results);
            }
            catch (AricNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("systemid", systemid);
                ex.Data.Add("accountNumber", accountNumber);
                ex.Data.Add("deviceNumber", deviceNumber);
                APIError err = new APIError(ex, 302, $"Unexpected error has occured while querying ARIC for matching jobs");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        [Route("jobs")]
        public IActionResult Post([FromBody] AricJobPayload parameters, [FromQuery] int systemid)
        {
            List<AricProcess> processes = new List<AricProcess>();

            if ((systemid == 0) || (parameters == null))
            {
                return BadRequest();
            }
            Claim claimSSO = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sso");
            string SSO = (claimSSO == null) ? null : claimSSO.Value;

            Claim claimToken = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "token");
            string token = (claimToken == null) ? null : claimToken.Value;

            if ( (string.IsNullOrEmpty(SSO)) || (string.IsNullOrEmpty(token)) )
            {
                return Unauthorized();
            }


            try
            {
                aricJob.Create(SSO, token, systemid, parameters);

                //return Ok(aricJob);
                string resourceURL = $"https://{Request.Host}{Request.PathBase}/jobs/{aricJob.EventId}";
                return Created(resourceURL, aricJob);
            }
            catch (AricNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("systemid", systemid);
                ex.Data.Add("parameters", JsonConvert.SerializeObject(parameters));
                APIError err = new APIError(ex, 304, $"Unexpected error submitting job to ARIC");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        
        [HttpGet]
        [Route("jobs/{jobid}")]
        public IActionResult Get([FromRoute] Guid jobid)
        {
            try
            {
                aricJob.Load(jobid);
                return Ok(aricJob);
            }
            catch (AricNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("jobid", jobid);
                APIError err = new APIError(ex, 303, $"Unable to load ARIC job {jobid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [HttpPut]
        [Route("jobs/{jobid}")]
        public async Task<IActionResult> Put([FromRoute] Guid jobid, [FromBody] AricJob jobData)
        {
            if (jobData == null)
            {
                return BadRequest();
            }

            try
            {
                aricJob.Load(jobid);
            }
            catch (AricNotFoundException nf)
            {
                //return NotFound();  

                //load properties in preparation for inserting a row into the DB
                aricJob.EventId = jobid;
                aricJob.AccountNumber = jobData.AccountNumber;
                aricJob.DeviceNumber = jobData.DeviceNumber;
                aricJob.ProcessName = jobData.ProcessName;
                aricJob.SystemId = jobData.SystemId;
                aricJob.UserId = jobData.UserId;

                // the "aricJob.Save()" call in the try block below will insert a new row if jobid does not exist

            }
            catch (Exception ex)
            {
                ex.Data.Add("jobid", jobid);
                APIError err = new APIError(ex, 303, $"Unable to load ARIC job {jobid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                aricJob.State = jobData.State;
                aricJob.ReturnedData = jobData.ReturnedData;
                aricJob.Message = jobData.Message;

                log.LogDebug($"state: {jobData.State}");
                log.LogDebug($"data: {jobData.ReturnedData}");
                log.LogDebug($"msg: {jobData.Message}");

                aricJob.Save();

                if (aricJob.ProcessName.ToLower() == "wap:portal:patchsettingsaudit")
                {
                    if (aricJob.State.ToLower() == "success")
                    {
                        //get patching client via API
                        //PatchingClient client = GetPatchingClient(aricJob.DeviceNumber);
                        try
                        {
                            client.Load(aricJob.DeviceNumber);
                        }
                        catch (PatchingNotFoundException pnf) { return NotFound(); }
                        catch (PatchingWSUSConnectionException wc) {  }
                        catch (PatchingWSUSNotFoundException wnf) { }
                        
                        log.LogDebug($"[API] Processing Returned Data....");
                        string changes = await adhp.ProcessDataAsync(aricJob, client);

                        if (changes.Length > 0)
                        {
                            TbServers server = db.TbServers.AsNoTracking().Single(c => c.DeviceNumber == aricJob.DeviceNumber) as TbServers;
                            //write audit trail entry
                            //log.logDebug($"Audit: Begin");
                            //log.logDebug($"Audit: account={server.Account}");
                            //log.logDebug($"Audit: details={sbDetails}");
                            TbAuditTrail audit = new TbAuditTrail();
                            audit.Account = aricJob.AccountNumber;
                            audit.Action = "Pull Config Settings";
                            audit.Detail = changes;
                            audit.DeviceNumber = aricJob.DeviceNumber;
                            audit.SystemId = aricJob.SystemId;
                            audit.TimeStamp = DateTime.UtcNow;
                            audit.UserId = aricJob.UserId;

                            db.TbAuditTrail.Add(audit);
                        }
                    }
                }


                if (aricJob.State.ToLower() == "success")
                {
                    log.LogDebug($"[API] Deleting ARIC Job from DB...");
                    aricJob.Delete();
                }



                return NoContent();
            }
            //catch (AricProcessException ex)
            //{
            //    ex.Data.Add("newJobData", JsonConvert.SerializeObject(jobData));
            //    APIError err = new APIError(ex, 306, $"ARIC process failed: {ex.Message}");
            //    log.LogError(err.ErrorCode, err.FormattedException());
            //    return new ServerError(err);
            //}
            catch (PatchingNotFoundException pnf) { return NotFound(); }
            catch (PatchingWSUSConnectionException wc) { return NoContent(); }
            catch (PatchingWSUSNotFoundException wnf) { return NoContent(); }

            catch (Exception ex)
            {
                ex.Data.Add("newJobData", JsonConvert.SerializeObject(jobData));
                APIError err = new APIError(ex, 305, $"Unexpected Error updating job {jobid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
    }
}
