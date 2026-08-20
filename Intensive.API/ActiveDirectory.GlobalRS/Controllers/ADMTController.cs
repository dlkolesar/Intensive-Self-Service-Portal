using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.DirectoryServices;
using Microsoft.AspNetCore.Mvc;
using Intensive.Services.ActiveDirectory;

using Microsoft.Extensions.Logging;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
//using Microsoft.Management.Infrastructure;
//using Microsoft.Management.Infrastructure.Options;
using Intensive.Data.SSDatabase;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("/accounts/{accountNumber}/admt")]
    public class ADMTController : ADControllerBase
    {

        AdObject adObject;
        AdMigration admt;
        AdMigrationHistory admtHistory;

        SSDatabaseContext db;

        public ADMTController(ILogger<ADMTController> logger,
                                ActiveDirectoryService adsvc,
                                IOptions<AdSystemConfig> adconfig,
                                AdMigration admig,
                                AdObject adobject,
                                AdMigrationHistory admighist,
                                SSDatabaseContext dbContext,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            this.admt = admig;
            this.adObject = adobject;
            this.admtHistory = admighist;
            this.db = dbContext;
            log.LogDebug($"*** ADMT Controller ctor ***");
        }

 
        //[AllowAnonymous]
        //[HttpGet("{account}")]
        //public async Task<IActionResult> Get([FromRoute] int account)
        //{
        //    if (config.DomainName.ToLower() != "globalrs")
        //    {
        //        return BadRequest("domain name must be GlobalRS");
        //    }

        //    try
        //    {
        //        List<AdMigrationHistory> history = await admtHistory.FindAsync(account);
        //        foreach (AdMigrationHistory entry in history)
        //        {
        //            resourceURL = $"https://{Request.Host}{Request.PathBase}/admt/{account}/{entry.TaskId}";
        //            results.Resources.Add(resourceURL);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        ex.Data.Add("account", account);
        //        APIError err = new APIError(ex, 11999, "Unexpected error loading migration objects");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err.Message);
        //    }

        //    return Ok(results);
        //}


        //need additional/different auth scheme for ADMT_Access membership
        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromRoute] int accountNumber, [FromBody] AdMigrationRequest request)
        {
           
            if (request == null)
            {
                return BadRequest("a valid adMigrationRequest object must be present in the HTTP request body");
            }

            try
            {
                log.LogDebug("Connecting to AD....");
                ad.Connect();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("request", JsonConvert.SerializeObject(request));
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            List<AdObject> migrationObjects = new List<AdObject>();
            try
            {
                log.LogDebug($"Load {request.Objects.Count} objects to be migrated....");
                //migrationObjects = LoadMigrationObjects(request.Objects);
                migrationObjects = LoadMigrationObjects(request.Objects);
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("request", JsonConvert.SerializeObject(request));
                APIError err = new APIError(ex, 11999, "Unexpected error loading migration objects");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err.Message);
            }

            try
            {
                log.LogDebug("Load targetOU for migration....");
                this.adObject.LoadDN(ad.DirectoryRoot, request.TargetOU);
            }
            catch(ADNotFoundException nf)
            {
                return NotFound("Target OU does not exist in the GlobalRS domain");
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("request", JsonConvert.SerializeObject(request));
                APIError err = new APIError(ex, 11999, $"Unexpected error loading target OU");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err.Message);
            }

            try
            {
                log.LogDebug($"Migrating {migrationObjects.Count } objects....");
                log.LogDebug($"   Target = {adObject.DN}");
                string submittedBy = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                await this.admt.MigrateObjects(ad.DirectoryRoot, request.Account, migrationObjects, adObject, submittedBy);
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("request", JsonConvert.SerializeObject(request));
                APIError err = new APIError(ex, 11999, "Unexpected error making migration request");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err.Message);
            }


            //write Audit trail entry
            try
            {
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Migration to GlobalRS Submitted";
                audit.Detail = $"Migrate {migrationObjects.Count } objects into {adObject.DN}";
                audit.Account = request.Account;
                audit.SystemId = config.SystemId;
                audit.DeviceNumber = null;
                audit.TimeStamp = DateTime.UtcNow;
                await audit.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("request", JsonConvert.SerializeObject(request));
                APIError err = new APIError(ex, 100, $"The migration request was successfully submitted.  However, an unexpected error writing the Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


       

        private List<AdObject> LoadMigrationObjects(List<string> dnList)
        {
            List<AdObject> lst = new List<AdObject>();

            List<Task<AdObject>> tasks = new List<Task<AdObject>>();

            foreach (string dn in dnList)
            {
                tasks.Add( Task<AdObject>.Factory.StartNew(() => this.LoadObject(dn)) );
            }


            log.LogDebug(">>>> Waiting for Parallel Tasks/Threads to Finish <<<<");

            //try/catch aggregate exceptions?
            Task.WaitAll(tasks.ToArray());


            foreach(Task<AdObject> t in tasks)
            {
                lst.Add(t.Result);
            }

            return lst;
        }


        //Can't use the service layer object because
        // we are getting data from a different Intensive, not GlobalRS
        private AdObject LoadObject(string dn)
        {
            APIClient intensiveAPI = new APIClient();
            AdObject o;
            int threadNum = Thread.CurrentThread.ManagedThreadId;
            //log.LogDebug($"#{threadNum} Starting...");
            //string urlBase = $"https://{Request.Host}{Request.PathBase.ToString().ToLower().Replace("globalrs", "intensive")}";

            string urlBase = $"https://{Request.Host}{Request.PathBase.ToString().ToLower()}";
            urlBase = urlBase.Replace("globalrs","Intensive");
            intensiveAPI.URL = $"{urlBase}/objects/{dn}";
            intensiveAPI.Execute();

            if (intensiveAPI.StatusCode == System.Net.HttpStatusCode.OK)
            {
                o = intensiveAPI.ReadObjectResponse<AdObject>();
                log.LogDebug($"#{threadNum} Object Loaded: {JsonConvert.SerializeObject(o)}");
                return o;
            }
            else
            {
                log.LogDebug($"#{threadNum} **** Error Loading object {dn}");
                log.LogDebug($"#{threadNum} **** {intensiveAPI.StatusCode}: {intensiveAPI.StatusDescription}");
                return null;
            }
        }

    }
}
