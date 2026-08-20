using System;
using System.Collections.Generic;
using System.Linq;
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


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("/accounts/{accountNumber}/admt/results")]
    public class ADMTHistoryController : ADControllerBase
    {

        //AdMigration admt;
        AdMigrationHistory admtHistory;
 

        SSDatabaseContext db;

        public ADMTHistoryController(ILogger<ADMTHistoryController> logger,
                                ActiveDirectoryService adsvc,
                                AdMigrationHistory admighist,
                                SSDatabaseContext dbContext,
                                IOptions<AdSystemConfig> adconfig,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            this.admtHistory = admighist;
            this.db = dbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromRoute] int accountNumber, [FromQuery]string status)
        {
            try
            {
                List<AdMigrationHistory> history = admtHistory.Find(accountNumber, status);

                foreach (AdMigrationHistory entry in history)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/accounts/{accountNumber}/admt/results/{entry.ID}";
                    results.Resources.Add(resourceURL);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                APIError err = new APIError(ex, 11999, "Unexpected error loading migration objects");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err.Message);
            }

            return Ok(results);
        }

        [AllowAnonymous]
        [HttpPut("{guid}")]
        public async Task<IActionResult> Put([FromRoute] int accountNumber, [FromRoute] Guid guid, [FromBody] AdMigrationHistory newStatus)
        {
            try
            {
                admtHistory.Load(guid);
                admtHistory.Status = newStatus.Status;
                admtHistory.TaskId = newStatus.TaskId;

                await this.admtHistory.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", accountNumber);
                ex.Data.Add("guid", guid.ToString());
                APIError err = new APIError(ex, 11999, $"Unexpected error updating migration status");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err.Message);
            }
        }



        [AllowAnonymous]
        [HttpGet("{guid}")]
        public IActionResult GetResult([FromRoute] Guid guid)
        {
            try
            {
                admtHistory.Load(guid);
                return Ok(admtHistory);
            }
            catch (ADNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("guid", guid);
                APIError err = new APIError(ex, 11999, $"Unexpected error loading ADMT Migration History");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [AllowAnonymous]
        [HttpGet("{guid}/log")]
        public IActionResult GetLog([FromRoute] int account, [FromRoute] Guid guid)
        {
            try
            {
                admtHistory.Load(guid);
                string txt = admtHistory.GetMigrationLog();
                FileContents log = new FileContents(txt);

                return Ok(log);
            }
            catch (ADNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error loading ADMT Migration History Log");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
        [AllowAnonymous]
        [HttpGet("{guid}/passwords")]
        public IActionResult GetPasswords([FromRoute] int account, [FromRoute] Guid guid)
        {
            try
            {
                admtHistory.Load(guid);
                string txt = admtHistory.GetUserMigrationPasswords();
                FileContents passwords = new FileContents(txt);

                return Ok(passwords);
            }
            catch (ADNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error loading ADMT Migration History Log");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
    }

    public class FileContents
    {
        public string Contents;
        public FileContents(string txt)
        {
            this.Contents = txt;
        }
    }

}
