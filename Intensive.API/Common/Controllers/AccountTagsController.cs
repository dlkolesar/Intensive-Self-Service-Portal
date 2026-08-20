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

namespace Intensive.API.Common.Controllers
{
    [ApiController]
    [Route("accounts/{acctNumber}/tags")]
    public class AccountTagsController : ControllerBase
    {
        private ILogger<AccountTagsController> log;
        private Account acct;
        private AuditTrail audit;
        private Tag tags;


        public AccountTagsController(ILogger<AccountTagsController> logger,
                                Account acctsvc,
                                AuditTrail audSvc,
                                Tag tagSvc
                                )
        {
            log = logger;
            acct = acctsvc;
            tags = tagSvc;
            audit = audSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute]int acctNumber)  //get all "custom" tags for account
        {
           
           
            if (acctNumber <= 0) { return BadRequest(); }

            APICollection results = new APICollection();
            string resourceURL;
            try
            {
                List<Tag> lst = await tags.Find(acctNumber);
                foreach (Tag t in lst)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/tags/{t.ID.ToString()}";
                    results.Resources.Add(resourceURL);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 200, $"Unexpected error finding custom account tags: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        public async Task<IActionResult> Post([FromRoute]int acctNumber, [FromBody] string tag)
        {
            if  (acctNumber <= 0)
            {
                return BadRequest("Account Number provided is not valid");
            }

            if ( string.IsNullOrEmpty(tag))
            {
                return BadRequest("Tag is empty");
            }

            if (tag.Length > 15)
            {
                return BadRequest($"'{tag}' is too long.  Tags must be 15 characters or less");
            }


            try
            {
                tags.Account = acctNumber;
                tags.TagName = tag;
                await tags.Save();
            }
            catch (Exception ex)
            {
                ex.Data.Add("new tag", tag);
                APIError err = new APIError(ex, 210, $"Unexpected error saving custom tag '{tag}': {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                audit.SystemId = 0;
                audit.TimeStamp = DateTime.UtcNow;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = "Created New Custom Tag";
                audit.DeviceNumber = null;
                audit.Account = acctNumber;
                audit.Detail = tag;

                audit.Save();   //write the Audit Trail record

                return NoContent();
            }
            catch (Exception ex)    //re-throw any other exceptions ba
            {
                ex.Data.Add("new tag", tag);
                APIError err = new APIError(ex, 210, $"The tag {tag} was created, but there was an unexpected error writing the Audit trail entry: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        //[Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        //[HttpDelete("{tagid}")]
        //public async Task<IActionResult> Delete([FromRoute]int acctNumber, [FromRoute] int tagid)
        //{
        //    if (acctNumber <= 0)
        //    {
        //        return BadRequest("Account Number provided is not valid");
        //    }

        //    if (tagid <= 0)
        //    {
        //        return BadRequest("Tagid is not valid");
        //    }



        //    //try to find the tag by name first
        //    try
        //    {
        //        await tags.Load(tagid);
        //    }
        //    catch (TagNotFoundException nf)
        //    {
        //        return NotFound($"{nf.Message}");
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("account", acctNumber);
        //        ex.Data.Add("tag id", tagid);
        //        APIError err = new APIError(ex, 200, $"Unexpected error searching for tag '{tags.TagName}' in account {acctNumber}: {ex.Message}");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }


        //    //try to delete it
        //    try
        //    {
        //        await tags.Delete();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("account", acctNumber);
        //        ex.Data.Add("tag id", tagid);
        //        APIError err = new APIError(ex, 200, $"Unexpected error deleting tag '{tags.TagName}' in account {acctNumber}: {ex.Message}");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }

        //    try
        //    {
        //        // build Audit entry
        //        audit.SystemId = 0;
        //        audit.TimeStamp = DateTime.UtcNow;
        //        audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
        //        audit.Action = "Deleted Custom Server Tag";
        //        audit.DeviceNumber = null;
        //        audit.Account = acctNumber;
        //        audit.Detail = tags.TagName;

        //        log.LogDebug($"[API] Saving Audit Entry....");
        //        audit.Save();   //write the Audit Trail record

        //        return NoContent();
        //    }
        //    catch (Exception ex)    //re-throw any other exceptions ba
        //    {
        //        ex.Data.Add("account", acctNumber);
        //        ex.Data.Add("tag id", tagid);
        //        APIError err = new APIError(ex, 210, $"The tag was deleted, but there was an unexpected error writing the Audit trail entry: {ex.Message}");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }
        //}


        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete("{tag}")]
        public async Task<IActionResult> DeleteTag([FromRoute]int acctNumber, [FromRoute] string tag)
        {
            if (acctNumber <= 0)
            {
                return BadRequest("Account Number provided is not valid");
            }

            if (string.IsNullOrEmpty(tag))
            {
                return BadRequest("Tag is empty");
            }

            if (tag.Length > 15)
            {
                return BadRequest($"'{tag}' is too long.  Tags must be 15 characters or less");
            }

            int tagid;

            
            //try to find the tag by name first
            try
            {
                if (Int32.TryParse(tag, out tagid))
                {
                    await tags.Load(tagid);
                }
                else
                {
                    await tags.Load(acctNumber, tag);
                }
            }
            catch (TagNotFoundException nf)
            {
                return NotFound($"{nf.Message}");
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", acctNumber);
                ex.Data.Add("tag", tag);
                APIError err = new APIError(ex, 200, $"Unexpected error searching for tag '{tag}' in account {acctNumber}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            //try to delete it
            try
            {
                await tags.Delete();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", acctNumber);
                ex.Data.Add("tag", tag);
                APIError err = new APIError(ex, 200, $"Unexpected error deleting tag '{tag}' in account {acctNumber}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                // build Audit entry
                audit.SystemId = 0;
                audit.TimeStamp = DateTime.UtcNow;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = "Deleted Custom Server Tag";
                audit.DeviceNumber = null;
                audit.Account = acctNumber;
                audit.Detail = tag;

                log.LogDebug($"[API] Saving Audit Entry....");
                audit.Save();   //write the Audit Trail record

                return NoContent();
            }
            catch (Exception ex)    //re-throw any other exceptions ba
            {
                ex.Data.Add("account", acctNumber);
                ex.Data.Add("tag", tag);
                APIError err = new APIError(ex, 210, $"The tag was deleted, but there was an unexpected error writing the Audit trail entry: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
    }
}
