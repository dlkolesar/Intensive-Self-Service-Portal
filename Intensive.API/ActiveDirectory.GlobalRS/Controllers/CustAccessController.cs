using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
//using Intensive.API.Common;
using Intensive.API.Global;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    public class AdCustomerAccess
    {
        public int Account { get; set; }
        public DateTime Expires { get; set; }

        public AdCustomerAccess(int acct, DateTime expires)
        {
            this.Account = acct;
            this.Expires = expires;
        }
    }

    [Route("accounts/{account}/customeraccess")]
    //[Route("custaccess")]
    public class CustAccessController : ADControllerBase
    {
        const string ACCESS_ATTRIBUTE = "rsactiveaccess";
        List<string> attributes = new List<string>() { ACCESS_ATTRIBUTE, "objectsid" };
        Dictionary<int, DateTime> customerAccess = new Dictionary<int, DateTime>();
        //int AccessDuration = 0;
        AdUser user;
        AdGroup group;


        public CustAccessController(ILogger<CustAccessController> logger,
                                    ActiveDirectoryService adsvc,
                                    AuditTrail audsvc,
                                    IOptions<AdSystemConfig> adconfig,
                                    AdUser aduser,
                                    AdGroup adgrp) : base(logger, adsvc, adconfig, audsvc)
        {
            int AccessDuration = ad.Config.AccountAccessLifeHours;
            this.user = aduser;
            this.group = adgrp;
            audit = audsvc;
        }

        //[Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        //[HttpGet]
        //public IActionResult Get([FromRoute] int account)
        //{
        //    if (!userid.ToLower().EndsWith(".cust"))
        //    {
        //        return BadRequest("only *.cust user accounts from the INTENSIVE domain can be granted access");
        //    }

        //    if (config.DomainName.ToUpper() != "INTENSIVE")
        //    {
        //        return BadRequest("only *.cust user accounts from the INTENSIVE domain can be granted access");
        //    }

        //    try
        //    {
        //        ad.Connect();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("userid", userid);
        //        APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }

        //    try
        //    {
        //        user.Load(ad.DirectoryRoot, userid, attributes);
        //        if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (user.Attributes[ACCESS_ATTRIBUTE] != null))
        //        {
        //            customerAccess = JsonConvert.DeserializeObject<Dictionary<int, DateTime>>(user.Attributes[ACCESS_ATTRIBUTE].ToString());
        //        }
                
        //        return Ok(customerAccess); 
                
        //    }
        //    catch (ADNotFoundException nf)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("userid", userid);
        //        APIError err = new APIError(ex, 11999, $"Unexpected error when querying {userid}'s access to customer environments");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }

        //}


        //[Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        public IActionResult Post([FromRoute] int account, [FromQuery]string site, [FromBody] SidArgument member )
        {
            //if (!member.SID.ToUpper().StartsWith("<SID"))
            //{
            //    return BadRequest("This endpoint can only accept the SID of the INTENSIVE user that is to be granted access");
            //}
            if (member == null)
            {
                return BadRequest("You must provide the SID of the INTENSIVE user that is to be granted access");
            }



            List<string> errors = new List<string>();
            log.LogDebug($"[API]connecting to AD....");
            try
            {
                if (string.IsNullOrEmpty(site))
                {
                    ad.Connect(GetAccountOU(account), null);
                }
                else
                {
                    ad.Connect(GetAccountOU(account),site);
                }
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {account} does not exist in this domain");
            }
            catch (Exception ex)
            {
                ex.Data.Add("sid", member.ToString());
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            
            log.LogDebug($"[API]Granting/Renewing Access to accounts....");
            List<Task> domainTasks = new List<Task>();

            //foreach (int acct in accounts)
            //{
            try
            {
                log.LogDebug($"[API]   {account}");

                group.Load(ad.DirectoryRoot, $"{account}-Rax");
                group.AddMember(member.ToString());
                return NoContent();

            }
            catch (Exception ex)
            {
                ex.Data.Add("sid", member.ToString());
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error granting access to {member.ToString()}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        //[Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete("{sid}")]
        public IActionResult Delete([FromRoute] int account, [FromRoute] string sid, [FromQuery]string site)
        {
            //if (!sid.ToUpper().StartsWith("<SID="))
            //{
            //    return BadRequest("This endpoint can only accept the SID of the INTENSIVE user that is to be granted access");
            //}




            List<string> errors = new List<string>();
            log.LogDebug($"[API]connecting to AD....");
            try
            {
                if (string.IsNullOrEmpty(site))
                {
                    ad.Connect(GetAccountOU(account),null);
                }
                else
                {
                    ad.Connect(GetAccountOU(account),site);
                }
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {account} does not exist in this domain");
            }
            catch (Exception ex)
            {
                ex.Data.Add("sid", sid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            log.LogDebug($"[API]Granting/Renewing Access to accounts....");
            List<Task> domainTasks = new List<Task>();

            //foreach (int acct in accounts)
            //{
            try
            {
                log.LogDebug($"[API]   {account}");
                group.Load(ad.DirectoryRoot, $"{account}-Rax");
                group.RemoveMember($"<SID={sid}>");
                return Ok();

            }
            catch (Exception ex)
            {
                ex.Data.Add("sid", sid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error granting access to {sid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }
    }

    public class SidArgument
    {
        public string SID { get; set; }
        public override string ToString()
        {
            return $"<SID={this.SID}>";
        }
    }
}
