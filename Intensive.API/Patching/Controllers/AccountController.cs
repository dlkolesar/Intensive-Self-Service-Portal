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
using Intensive.Services.Common;
using Intensive.Data.SSDatabase;
using Intensive.Services.Patching;
using Intensive.Services.Patching.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading;



// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Patching.Controllers
{
    [Route("accounts")]
    public class AccountController : Controller
    {
        protected ILogger<AccountController> log;
        protected PatchingSystemConfig config;
        PatchingAccount PatchingAcct;
        PatchingClient PatchClient;
        AuditTrail audit;
        SSDatabaseContext db;


        public AccountController(ILogger<AccountController> logger,
                                 IOptions<PatchingSystemConfig> patchConfig,
                                 PatchingAccount pa,
                                 PatchingClient pc,
                                 AuditTrail auditTrail,
                                 SSDatabaseContext dbContext
                               )
        {
            log = logger;
            PatchingAcct = pa;
            PatchClient = pc;
            config = patchConfig.Value;
            audit = auditTrail;
            db = dbContext;
        }

        [HttpGet]
        //[ResponseCache(CacheProfileName = "Default")]
        public IActionResult Get()
        {

            try
            {
                 List<PatchingAccount> accounts = PatchingAcct.AllOptedInAccounts();

                //List<PatchingAccount> accounts = new List<PatchingAccount>();

                //    List<TbPatchingAccounts> tbPatchAcct = db.TbPatchingAccounts
                //                                            .AsNoTracking()
                //                                            .Where(a => !a.OptedOut)
                //                                            .ToList<TbPatchingAccounts>();

                //    PatchingAccount pa = new PatchingAccount();
                //    foreach (TbPatchingAccounts tbpa in tbPatchAcct)
                //    {
                //    pa = new PatchingAccount();
                //        pa.Number = tbpa.Number;
                //        pa.OptedOut = tbpa.OptedOut;
                //        pa.OptInOutDate = tbpa.OptInOutDate;
                //        pa.OptInOutTicket = tbpa.OptInOutTicket;
                //        pa.OptedOutOfTicketing = tbpa.OptedOutOfTicketing;
                //        pa.LastRefresh = tbpa.LastRefresh;

                //        accounts.Add(pa);
                //    }


                    string resourceURL = string.Empty;

                APICollection results = new APICollection();

                //build the url result set
                foreach (PatchingAccount pacct in accounts)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/accounts/{pacct.Number}";
                    results.Resources.Add(resourceURL);
                }

                return Ok(results);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14001, $"Unexpected error loading Opted In Accounts");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        //get patching summary data for the account
        [Route("{acctNumber}")]
        [HttpGet]
        //[ResponseCache(CacheProfileName = "Default")]
        public IActionResult Get(int acctNumber)
        {

            //eventLog.LogInformation("current User:" + User.Identity.Name);
            if (acctNumber <= 0) { return BadRequest(); }

            try
            {
                PatchingAcct.Load(acctNumber);
                return Ok(PatchingAcct);
            }
            catch (PatchingNotFoundException nf)
            {
                PatchingAcct.OptedOut = true;
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14002, $"Unable to load account {acctNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        //get patching summary data for the account
        [Route("{acctNumber}/clients")]
        [HttpGet]
        //[ResponseCache(CacheProfileName = "Default")]
        public IActionResult GetClients(int acctNumber)
        {
            try
            {
                PatchingAcct.Load(acctNumber);
                List<Server> clients = PatchingAcct.GetPatchingClients();
                string resourceURL = string.Empty;
                APICollection results = new APICollection();

                //build the url result set
                foreach (Server p in clients)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/Clients/{p.DeviceNumber}";
                    results.Resources.Add(resourceURL);
                }

                return Ok(results);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14003, $"Unexpected error loading clients for account {acctNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        // POST api/values
        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [Route("{acctNumber}")]
        [HttpPost]
        public async Task<IActionResult> Post(int acctNumber, [FromQuery] string action, [FromQuery] string ticket)
        {
            //return StatusCode(405);
            if (acctNumber <= 0) { return BadRequest(); }

            try
            {
                PatchingAcct.Load(acctNumber);  //load the account data, if it exists
            }
            catch (PatchingNotFoundException nf)
            {
                PatchingAcct.Number = acctNumber;       
                PatchingAcct.OptedOut = true;
                PatchingAcct.Create();          //if patching account does not exisT, create it ????? //validate against core??
                //return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14002, $"Unable to load account {acctNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            //should have a valid patching account row in db now
            log.LogDebug("Patching Account has been loaded....");
            try
                {
                    log.LogDebug($"switch(action): {action}");
                    log.LogDebug($"ticket: {ticket}");
                    switch (action.ToLower())
                    {
                        //case "create"????
                        case "optin" : { return await OptInAccount(ticket); }
                        case "optout": { return await OptOutAccount(ticket); }
                        case "refresh": {
                            if (PatchingAcct.OptedOut)
                            {
                                return BadRequest($"Account is opted out.");
                            }
                            else
                            {
                                return await RefreshAccount();
                            }
                        }
                }

                    return NoContent();
                }
                catch (PatchingNotFoundException nf)
                {
                    return NotFound();
                }
                catch (Exception ex)
                {
                    APIError err = new APIError(ex, 14005, $"Unable to {action} account {acctNumber}");
                    log.LogError(err.ErrorCode, err.FormattedException());
                    return new ServerError(err);
                }
        }

        [Authorize(Policy ="TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [Route("{acctNumber}")]
        [HttpPut]
        public IActionResult Put(int acctNumber, [FromBody] PatchingAccount pa)
        {

            try
            {
                PatchingAcct.Load(acctNumber);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14002, $"Unable to load account {acctNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                if (PatchingAcct.OptedOutOfTicketing == pa.OptedOutOfTicketing)
                {
                    return StatusCode(304, "No data changed");
                }

                audit.Detail = $"Changed OptedOutOfTicketing from {PatchingAcct.OptedOutOfTicketing} to {pa.OptedOutOfTicketing}";

                PatchingAcct.OptedOutOfTicketing = pa.OptedOutOfTicketing;
                PatchingAcct.Save();

                audit.SystemId = config.SystemId;
                audit.TimeStamp = DateTime.UtcNow;
                //audit.UserId = User.Claims.FirstOrDefault(c=> c.Type == "sso").Value;;
                audit.UserId = "Sum Dum Gai";
                audit.Action = "Updated Patching Account Config";
                //audit.Detail = $"Changed OptedOutOfTicketing from {PatchingAcct.OptedOutOfTicketing} to {pa.OptedOutOfTicketing}";
                audit.DeviceNumber = null;
                audit.Account = acctNumber;

                audit.Save();

                return NoContent();
            }
            catch(PatchingNotFoundException nfex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("patchingAccount", JsonConvert.SerializeObject(pa));
                APIError err = new APIError(ex, 14006, $"Unexpected error when updating account {acctNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
       
        }


        private async Task<IActionResult> OptInAccount(string ticket)
        {
            log.LogDebug($"OptInAccount({ticket})");
            if (!PatchingAcct.OptedOut)  //is the account already opted in?
            {
                return StatusCode(304, "Account is already opted in");
            }

            if (String.IsNullOrEmpty(ticket))
            {
                return BadRequest("a CORE ticket number is required to Opt In the account");
            }

            Regex re = new Regex(@"[0-9]{6}\-[0-9]{5}");
            if (!re.IsMatch(ticket))
            {
                return BadRequest("Not a valid CORE ticket number");
            }

            log.LogDebug($"Getting Claims from request....");
            string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
            string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;

            log.LogDebug($"Opting in the accout.....");

            PatchingAcct.OptIn(ticket, token, sso);

            //foreach (int devNumber in newDevices)
            //{
            //    log.LogDebug($"pulling settings for device {devNumber}");
            //    PullSettingsForDevice(devNumber);
            //}


            audit.SystemId = config.SystemId;
            log.LogDebug("writing Audit Trail data for OPT IN");
            audit.TimeStamp = DateTime.UtcNow;
            audit.UserId = sso;
            audit.Action = "Account Opted IN";
            audit.DeviceNumber = null;
            audit.Account = PatchingAcct.Number;
            audit.Detail = $"Ticket {ticket}";

            audit.Save();

            return NoContent();
        }


        private async Task<IActionResult> OptOutAccount(string ticket)
        {
            if (PatchingAcct.OptedOut)
            {
                return StatusCode(304, "Account is already opted out");
            }

            if (String.IsNullOrEmpty(ticket))
            {
                return BadRequest("a CORE ticket number is required to Opt Out the account");
            }

            Regex re = new Regex(@"[0-9]{6}\-[0-9]{5}");
            if (!re.IsMatch(ticket))
            {
                return BadRequest("Not a valid CORE ticket number");
            }

            PatchingAcct.OptOut(ticket);

            audit.SystemId = config.SystemId;

            audit.TimeStamp = DateTime.UtcNow;
            audit.UserId = User.Claims.FirstOrDefault(c=> c.Type == "sso").Value;;
            //audit.UserId = "Sum Dum Gai";
            audit.Action = "Account Opted OUT";
            audit.DeviceNumber = null;
            audit.Account = PatchingAcct.Number;
            audit.Detail = $"Ticket {ticket}";

            await audit.SaveAsync();

            return NoContent();
        }


        private async Task<IActionResult> RefreshAccount()
        {
            string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
            string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;

            log.LogDebug($"Refreshing account {PatchingAcct.Number}.....");

            List<int> newClientIds =  await PatchingAcct.RefreshAccount(sso, token);

            string resourceURL = string.Empty;

            APICollection results = new APICollection();

            //build the url result set
            foreach (int devNumber in newClientIds)
            {
                resourceURL = $"https://{Request.Host}{Request.PathBase}/clients/{devNumber}";
                results.Resources.Add(resourceURL);
            }

            if (newClientIds.Count > 0)
            {
                audit.SystemId = config.SystemId;
                audit.TimeStamp = DateTime.UtcNow;
                audit.UserId = sso;
                audit.Action = "Account Refresh";
                audit.DeviceNumber = null;
                audit.Account = PatchingAcct.Number;
                audit.Detail = $"{newClientIds.Count} new client(s) imported";

                await audit.SaveAsync();
            }
            return Ok(results);
        }

        private void PullSettingsForDevice(int devNumber)
        {
            APIClient clientApi = new APIClient();
            clientApi.Verb = "POST";
            clientApi.URL = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Clients/{devNumber}?action=pullsettings";
            clientApi.Execute();

            if (clientApi.StatusCode != System.Net.HttpStatusCode.Created)
            {
                APIError err = new APIError();
                err.ErrorCode = 14002;
                err.Message = $"Error submitting Settings Pull job to ARIC: {clientApi.StatusCode} - {clientApi.StatusDescription}";
                log.LogError(err.ErrorCode, err.FormattedException());
            }
            clientApi.HttpResponse.Close();
        }

    }
}
