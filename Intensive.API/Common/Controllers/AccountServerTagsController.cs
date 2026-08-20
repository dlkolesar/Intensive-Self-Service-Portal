using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Intensive.API.Global;
using Intensive.Services.Common;

using Intensive.Data.EBIDataMart;
using System.Threading.Tasks;
using System.Collections.Generic;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Common.Controllers
{
    [ApiController]
    [Route("accounts/{acctNumber}/servers/{deviceNumber}/tags")]
    public class AccountServerTagsController : ControllerBase
    {
        private ILogger<AccountServerTagsController> log;
        private Server svr;
        private AuditTrail audit;
        private Tag tags;

        public AccountServerTagsController(ILogger<AccountServerTagsController> logger,
                               Server svrSvc,
                               AuditTrail audSvc,
                               Tag tagSvc
                               )
        {
            log = logger;
            svr = svrSvc;
            tags = tagSvc;
            audit = audSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]int acctNumber, [FromRoute]int deviceNumber)  //get all tags for a server
        {
            
            if (acctNumber <= 0) { return BadRequest($"Account number is invalid"); }
            if (deviceNumber <= 0) { return BadRequest($"Device Number is invalid"); }

            APICollection results = new APICollection();
            string resourceURL;
            try
            {
                svr.DeviceNumber = deviceNumber;
                List<Tag> lst = await svr.GetTagsAsync();
                foreach (Tag t in lst)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/tags/{t.ID.ToString()}";
                    results.Resources.Add(resourceURL);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 200, $"Unexpected error loading server tags: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        public async Task<IActionResult> PostServerTags([FromRoute] int acctNumber, [FromRoute] int deviceNumber, [FromBody] Tag tag)
        {
            try
            {
                svr.Load(deviceNumber);
            }
            catch (InvalidOperationException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 201, $"Unable to load server {deviceNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                await svr.AssignTagsAsync(tag);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 202, $"Unexpected error assigning tag '{tag.TagName}' to server {deviceNumber}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                // build Audit entry
                audit.SystemId = 0;
                audit.TimeStamp = DateTime.UtcNow;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = "Assign Server Tag";
                audit.DeviceNumber = deviceNumber;
                audit.Account = acctNumber;
                audit.Detail = tag.TagName;

                log.LogDebug($"[API] Saving Audit Entry....");
                audit.Save();   //write the Audit Trail record

                return NoContent();
            }
            catch (Exception ex)    //re-throw any other exceptions ba
            {
                ex.Data.Add("new tag", JsonConvert.SerializeObject(tag));
                APIError err = new APIError(ex, 210, $"The tag(s) were assigned, but there was an unexpected error writing the Audit trail entry: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }


        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAll([FromRoute] int acctNumber, [FromRoute] int deviceNumber)
        {
            Tag tag;
            try
            {
                svr.Load(deviceNumber);
            }
            catch (InvalidOperationException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 201, $"Unable to load server {deviceNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                await svr.RemoveAllTagsAsync();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 202, $"Unexpected error deleting all server tags from server {deviceNumber}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                // build Audit entry
                audit.SystemId = 0;
                audit.TimeStamp = DateTime.UtcNow;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = "Delete Server Tags";
                audit.DeviceNumber = deviceNumber;
                audit.Account = acctNumber;
                audit.Detail = "**All**";

                log.LogDebug($"[API] Saving Audit Entry....");
                audit.Save();   //write the Audit Trail record

                return NoContent();
            }
            catch (Exception ex)    //re-throw any other exceptions ba
            {
                APIError err = new APIError(ex, 210, $"The tag was removed, but there was an unexpected error writing the Audit trail entry: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }



        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete("{tag}")]
        public async Task<IActionResult> DeleteServerTag([FromRoute] int acctNumber, [FromRoute] int deviceNumber, [FromRoute] string tag)
        {
            try
            {
                svr.Load(deviceNumber);
            }
            catch (InvalidOperationException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 201, $"Unable to load server {deviceNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            int tagid;
            Tag svrTag;
            try
            {
                log.LogDebug($"Tags on server: {JsonConvert.SerializeObject(svr.Tags)}");
                if (Int32.TryParse(tag, out tagid))
                {
                    log.LogDebug($"Extracting Tag by ID...");
                    svrTag = svr.Tags.SingleOrDefault(t => t.ID == tagid);
                }
                else
                {
                    log.LogDebug($"Extracting Tag by ID...");
                    svrTag = svr.Tags.SingleOrDefault(t => t.TagName.ToLower() == tag.ToLower());
                }
                log.LogDebug($"tag to delete: {JsonConvert.SerializeObject(svrTag)}");
                

                await svr.RemoveTagAsync(svrTag);
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", acctNumber);
                ex.Data.Add("deviceNumber", deviceNumber);
                ex.Data.Add("tagid", tag);
                APIError err = new APIError(ex, 202, $"Unexpected error deleting server tag '{tag}' from server {deviceNumber}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                // build Audit entry
                audit.SystemId = 0;
                audit.TimeStamp = DateTime.UtcNow;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = "Delete Server Tag";
                audit.DeviceNumber = deviceNumber;
                audit.Account = acctNumber;
                audit.Detail = tag;

                log.LogDebug($"[API] Saving Audit Entry....");
                audit.Save();   //write the Audit Trail record

                return NoContent();
            }
            catch (Exception ex)    //re-throw any other exceptions ba
            {
                APIError err = new APIError(ex, 210, $"The tag was removed, but there was an unexpected error writing the Audit trail entry: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }

    }
}
