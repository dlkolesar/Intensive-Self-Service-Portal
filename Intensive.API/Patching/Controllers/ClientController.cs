 using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intensive.API.Global;
using Intensive.Services.Auditing;
using Intensive.Services.Patching;
using Intensive.Services.Patching.Exceptions;
using Intensive.Services.Aric;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Intensive.Data.SSDatabase;
using Microsoft.EntityFrameworkCore;
using Intensive.Services.Common;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Intensive.API.Patching.Controllers
{
    [Route("clients")]
    public class ClientController : Controller
    {
        protected ILogger<ClientController> log;
        protected PatchingSystemConfig config;
        protected PatchingClient PatchClient;
        protected Server server;
        protected AuditTrail audit;
        protected AricTimeTable timetable;
        protected AricJob aricJob;
        protected SSDatabaseContext db;
        private string t;

        public ClientController(ILogger<ClientController> logger,
                                IOptions<PatchingSystemConfig> patchConfig,
                                PatchingClient pc,
                                Server svr,
                                AuditTrail auditTrail,
                                AricTimeTable tt,
                                AricJob aj,
                                SSDatabaseContext dbContext
                               )
        {
            PatchClient = pc;
            server = svr;
            log = logger;
            config = patchConfig.Value;
            audit = auditTrail;
            timetable = tt;
            aricJob = aj;
            db = dbContext;
            //Claim claimToken = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "token");
            //t = (claimToken == null) ? null : claimToken.Value;
            //log.LogDebug($"PatchingConfig: {JsonConvert.SerializeObject(config)}");
        }

        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpGet("{deviceNumber}")]
        //[ResponseCache(CacheProfileName = "Default")]
        public IActionResult Get(int deviceNumber)
        {
            if (deviceNumber <= 0) { return BadRequest(); }

            try
            {
                GetPatchingClient(deviceNumber);
                this.ValidatePatchingClientData(PatchClient);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (AricNotFoundException anf)
            {
                //  ignore/swallow this error
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14999, $"[API] Unexpected error loading patching client: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            return Ok(PatchClient);
        }


        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost("{deviceNumber}")]
        public IActionResult Post(int deviceNumber, [FromQuery] string action)
        {
            //return StatusCode(405);
            if (deviceNumber <= 0) { return BadRequest(); }

            if (action == null) { return BadRequest("an action is required in the querystring"); }

            //try
            //{
            //    PatchClient.Load(deviceNumber);
            //    server.Load(deviceNumber);
            //}
            //catch (PatchingNotFoundException nf)
            //{
            //    return NotFound();
            //}
            //catch (PatchingWSUSConnectionException wsus)
            //{
            //    //"swallow" or ignore this exception, since we don't need data from WSUS 
            //}
            //catch (PatchingWSUSNotFoundException wsusnf)
            //{
            //    //"swallow" or ignore this exception, since we don't need data from WSUS 
            //}
            //catch (Exception ex)
            //{
            //    APIError err = new APIError(ex, 14007, $"Unable load patching client {deviceNumber}");
            //    log.LogError(err.ErrorCode, err.FormattedException());
            //    return new ServerError(err);
            //}

            try
            {
                server.Load(deviceNumber);
                GetPatchingClient(deviceNumber);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (AricNotFoundException anf)
            {
                //  ignore/swallow this error
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14999, $"[API] Unexpected error loading patching client: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                switch (action.ToLower())
                {
                    case "optin":           { return this.OptInDevice(); }
                    case "optout":          { return this.OptOutDevice(); }
                    case "pullsettings":    { return this.PullSettings(); }
                    case "patchnow":        { return this.PatchNow(); }
                    //case "defaulttoms":   { return this.DefaultToMicrosoftSettings(); }
                    case "defaulttors":     { return this.DefaultToRackspaceSettings(); }
                    case "resetwsusid":     { return this.ResetWSUSId(); }
                    default:                { return BadRequest($"'{action}' is not a valid action. refer to the API documentation for valid actions"); }
                }

                //return NoContent();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14008, $"Unable to perform '{action}' on patching client {deviceNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


        }


        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPut("{deviceNumber}")]
        public IActionResult Put(int deviceNumber, [FromBody] PatchingClient pc)
        {
            //load the current client data
            log.LogDebug($"[API] new pc: {JsonConvert.SerializeObject(pc)}");

            if (pc == null) { return BadRequest($"There was an error parsing your input data");  }

            if (deviceNumber <= 0) { return BadRequest(); }

            try
            {
                GetPatchingClient(deviceNumber);
                //this.ValidatePatchingClientData(PatchClient);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 14999, $"[API] Unexpected error loading patching client: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            List<string> errors = this.ValidatePatchingClientInput(pc);
            if (errors.Count > 0)
            {
                string s = string.Join("\r\n", errors.ToArray());
                return BadRequest(s);
            }

            //save and audit the change(s)
            try
            {
                // build Audit entry
                audit.SystemId = config.SystemId;
                audit.TimeStamp = DateTime.UtcNow;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = "Updated Patching Client Config";
                audit.DeviceNumber = PatchClient.DeviceNumber;

                server.Load(PatchClient.DeviceNumber);
                audit.Account = server.Account;
                
                //update PatchClient, et. al, with new values and collect audit trail details
                // of which properties were changed
                audit.Detail = this.UpdateClient(pc);   //updates properties in PatchClient

                //When doing mass updates, it's posible that the changes being applied already
                //exist on the PatchClient, if so, return a NoContent status, as if it had updated
                //No need to write an audit entry, since nothing actually changed
                if (audit.Detail == "")
                {
                    return NoContent();
                }
                

                log.LogDebug($"[API] Saving Audit Entry....");
                audit.Save();   //write the Audit Trail record

                //validate the new updated data
                this.ValidatePatchingClientData(PatchClient);
                return Ok(PatchClient); //return the patch client data back to the caller, since the adv schedule id may have been set
            }
            catch (Exception ex)    //re-throw any other exceptions ba
            {
                ex.Data.Add("new patchingClient", JsonConvert.SerializeObject(pc));
                ex.Data.Add("current patchingClient", JsonConvert.SerializeObject(PatchClient));
                APIError err = new APIError(ex, 14009, $"Unexpected error when updating patching client {deviceNumber}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        private void GetPatchingClient(int deviceNumber)
        {
            //get common config data 
            try
            {
                PatchClient.Load(deviceNumber);
                log.LogDebug($"[API] Client Loaded");
            }
            catch (PatchingNotFoundException nf)
            {
                //return NotFound();
                throw;
            }
            catch (PatchingWSUSConnectionException nf)
            {
                
                if (string.IsNullOrEmpty(PatchClient.WUServer))
                {
                    PatchClient.Errors.Add($"WSUS server name is empty");
                }
                else
                {
                    if (PatchClient.WUServer.ToLower().EndsWith("rackspace.com"))
                    {
                        PatchClient.Errors.Add($"Unable to connect to the Intensive WSUS server {PatchClient.WUServer}");
                    }
                    else
                    {
                        PatchClient.Errors.Add($"Unable to connect to the 3rd party WSUS server {PatchClient.WUServer}");
                    }
                }

                //this.ValidatePatchingClientData(PatchClient);
                //return Ok(PatchClient);
            }
            catch (PatchingWSUSNotFoundException nf)
            {
                PatchClient.Errors.Add($"WSUS data not found for device {deviceNumber}");
                //this.ValidatePatchingClientData(PatchClient);
                //return Ok(PatchClient);
            }

            catch (Exception ex)
            {
                //APIError err = new APIError(ex, 14007, $"Unable to load patching client {deviceNumber}");
                //log.LogError(err.ErrorCode, err.FormattedException());
                //return new ServerError(err);
                throw new Exception($"Unable to load patching client {deviceNumber}",ex);
            }

            //if (PatchClient.PatchingLevel == PatchingLevels.Advanced)
            if ((PatchClient.AdvancedPatching != null) && (PatchClient.AdvancedPatching.ID != Guid.Empty))
            {
                try
                {
                    // log.LogDebug($"[API] Getting Identity Token.....");
                    Claim claimToken = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "token");
                    string token = claimToken?.Value;

                    log.LogDebug($"[API] Getting Advanced Patching Timetable.....");

                    timetable.Load(PatchClient.AdvancedPatching.ID, token);

                    PatchClient.AdvancedPatching.Minute = $"{timetable.Schedule.Minute:D2}";
                    PatchClient.AdvancedPatching.Hour = $"{timetable.Schedule.Hour:D2}";
                    PatchClient.AdvancedPatching.DayOfWeek = timetable.Schedule.Day_of_week;
                    PatchClient.AdvancedPatching.DayOfMonth = timetable.Schedule.Day_of_month;
                    PatchClient.AdvancedPatching.MonthOfYear = timetable.Schedule.Month_of_year;
                    PatchClient.AdvancedPatching.ID = timetable.Schedule_id;
                    PatchClient.AdvancedPatching.ID = timetable.Schedule_id;

                    //PatchClient.AdvancedPatching.Arguments = timetable.Args;
                    AricJobPayload aricJob = JsonConvert.DeserializeObject<AricJobPayload>(timetable.Args[2]);
                    PatchClient.AdvancedPatching.ProcessName = aricJob.Name;
                    AricMetadataPatchNow metadata = JsonConvert.DeserializeObject<AricMetadataPatchNow>(aricJob.Metadata.ToString());
                    PatchingClientPatchNowArguments advPatchingArgs = new PatchingClientPatchNowArguments
                    {
                        DownloadPatches = metadata.DownloadPatches,
                        Endtime = metadata.Endtime,
                        ForceReboot = metadata.ForceReboot,
                        InstallPatches = metadata.InstallPatches,
                        Reboot = metadata.Reboot
                    };
                    PatchClient.AdvancedPatching.Arguments = advPatchingArgs;

                    if (PatchClient.PatchingLevel == PatchingLevels.Advanced)
                    {
                        PatchClient.NextPatchDate = timetable.NextRun;
                        PatchClient.LastPatchDate = timetable.LastRun;
                    }
                   
                }
                catch (AricNotFoundException)
                {
                    if (PatchClient.AdvancedPatching.ProcessName != null) {
                        PatchClient.Errors.Add($"Advanced Scheduling data not found in ARIC");
                        throw;
                    }
                    // If there is no ProcessName, pass the exception. SSD-766
                }
                catch (Exception ex)
                {
                    //APIError err = new APIError(ex, 14999, $"[API] Unable to load Advanced Patching data from ARIC");
                    //log.LogError(err.ErrorCode, err.FormattedException());
                    //return new ServerError(err);
                    throw new Exception("Unable to load Advanced Patching data from ARIC", ex);
                }
            }
        }

        private Guid UpdateAricTimetable(PatchingClient pc)
        {
            log.LogDebug($"[API] Saving Patching Client Advanced Patching Config....");
            Claim claimToken = Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "token");
            string token = (claimToken == null) ? null : claimToken.Value;

            log.LogDebug($"new Adv Patching schedule: {JsonConvert.SerializeObject(pc.AdvancedPatching)}");

            timetable.Enabled = (pc.PatchingLevel == PatchingLevels.Advanced);
            timetable.Schedule_id = pc.AdvancedPatching.ID;

            AricMetadataPatchNow aricArgs = new AricMetadataPatchNow();
            // a direct casting of pc.AdvancedPatching.Arguments to PatchingClientPatchNowArguments
            // did not work, so I deserialized the arguments into JSON, then 
            // Deserialize the json into the PatchingClientPatchNowArguments object
            //
            // strange and marvelous, but that's the only way I could come up with to 
            // do the conversion
            PatchingClientPatchNowArguments newArgs = new PatchingClientPatchNowArguments();
            string json = JsonConvert.SerializeObject(pc.AdvancedPatching.Arguments);
            newArgs = JsonConvert.DeserializeObject<PatchingClientPatchNowArguments>(json);
            

            aricArgs.DownloadPatches = newArgs.DownloadPatches;
            aricArgs.Endtime = newArgs.Endtime;
            aricArgs.ForceReboot = newArgs.ForceReboot;
            aricArgs.InstallPatches = newArgs.InstallPatches;
            aricArgs.Reboot = newArgs.Reboot;
            ///aricArgs.SsoUserName = "ssportal";
            aricArgs.SsoUserName =  Request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            aricArgs.TriggeredBy = "portal";
            aricArgs.WinPatchUrl = "";
            aricArgs.DeviceId = pc.DeviceNumber.ToString();

            AricJobPayload job = new AricJobPayload();
            job.Tenant = server.Account;
            job.Targets.Add(new AricTarget(pc.DeviceNumber));
            job.Name = pc.AdvancedPatching.ProcessName;
            job.Source = "WindowsAutomationTeam";
            job.Metadata = aricArgs;

            log.LogDebug($"[API] job: {JsonConvert.SerializeObject(job)}");
            
            timetable.Name = $"Windows Advanced Patching {pc.DeviceNumber}";
            timetable.Args.Clear();
            timetable.Args.Add("$[ApplicationConfig.globalauth.2.0.us.session]");
            timetable.Args.Add(server.Account.ToString());
            timetable.Args.Add(JsonConvert.SerializeObject(job, new JsonSerializerSettings
                                                                {
                                                                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                                }));

            timetable.Schedule.Minute = pc.AdvancedPatching.Minute;
            timetable.Schedule.Hour = pc.AdvancedPatching.Hour;
            timetable.Schedule.Day_of_week = pc.AdvancedPatching.DayOfWeek;
            timetable.Schedule.Day_of_month = pc.AdvancedPatching.DayOfMonth;
            timetable.Schedule.Month_of_year = pc.AdvancedPatching.MonthOfYear;

            log.LogDebug($"[API] Saving Timetable....");
            return timetable.Save(token);  //creates or updates
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(405);
        }


        private void ValidatePatchingClientData(PatchingClient pc)
        {
            log.LogDebug($"[API] Validating Client Data.....");
            //log.LogDebug($"[API]    AuOptions - None/Manual");
            if ((pc.PatchingLevel < PatchingLevels.None) || (pc.PatchingLevel > PatchingLevels.Manual))
            {
                pc.Errors.Add($"Patching Level is not valid");
            }

            if ( (pc.WSUSID == null) ||(pc.WSUSID == Guid.Empty) )
            {
                pc.Errors.Add($"WSUS ID is empty");
            }



            //log.LogDebug($"[API]    AuOptions - Basic");
            //Basic Patching Level must have AUOptions 4 or 5
            if (pc.PatchingLevel == PatchingLevels.Basic)
            {
                if ((pc.AUOptions != 4) && (pc.AUOptions != 5))
                {
                    pc.Errors.Add($"Action/AUOptions is not valid with Basic Patching Level");
                }
            }

            //log.LogDebug($"[API]    AuOptions - Manual");
            //Manual Patching Level must have AUOptions 2 or 3
            if (pc.PatchingLevel == PatchingLevels.Manual)
            {
                if ((pc.AUOptions != 2) && (pc.AUOptions != 3))
                {
                    pc.Errors.Add($"Action/AUOptions is not valid with Manual Patching Level");
                }
            }

           
            //log.LogDebug($"[API]    Basic Schedule");
            if (pc.PatchingLevel != PatchingLevels.Advanced)
            {
                if ((pc.ScheduledWeek == null) || (pc.ScheduledWeek < 0) || (pc.ScheduledWeek > 3))
                {
                    pc.Errors.Add($"Scheduled Week is not valid");
                }

                if ((pc.ScheduledDay == null) || (pc.ScheduledDay < 0) || (pc.ScheduledDay > 7))
                {
                    pc.Errors.Add($"Scheduled Day is not valid");
                }

                if ((pc.ScheduledTime == null) || (pc.ScheduledTime < 0) || (pc.ScheduledTime > 23))
                {
                    pc.Errors.Add($"Scheduled Time is not valid");
                }
            }

            if (pc.PatchingLevel == PatchingLevels.Advanced)
            {
                if (pc.AdvancedPatching.Arguments == null)
                {
                    pc.Errors.Add($"Advanced Patching Arguments not found");
                }

                //AricMetadataPatchNow args = new AricMetadataPatchNow();
                PatchingClientPatchNowArguments args = new PatchingClientPatchNowArguments();
                try
                {
                    args = pc.AdvancedPatching.Arguments as PatchingClientPatchNowArguments;
               
                    if (!args.DownloadPatches)
                    {
                        pc.Errors.Add($"'DownloadPatches' argument must be set to TRUE");
                    }

                    //aricArgs.SsoUserName = "ssportal";
                    //aricArgs.TriggeredBy = "portal";
                    //aricArgs.WinPatchUrl = "";
                }
                catch (InvalidCastException castex)
                {
                    pc.Errors.Add($"Error parsing Advanced Patching Arguments: {castex.Message}");
                }
                catch (Exception ex)
                {
                    ex.Data.Add("Arguments", pc.AdvancedPatching.Arguments);
                    pc.Errors.Add($"Unexpected error parsing or validating Advanced Patching Arguments: {ex.Message}");
                }
            }
                
        }

        private List<string> ValidatePatchingClientInput(PatchingClient pc)
        {
            log.LogDebug($"[API] Validating Client Input Data.....");

            List<string> Errors = new List<string>();

            if (pc.PatchingLevel == PatchingLevels.None) //no need to validate if we are turning off patching
            {
                return Errors;
            }

            if ((pc.PatchingLevel < PatchingLevels.None) || (pc.PatchingLevel > PatchingLevels.Manual))
            {
                Errors.Add($"Patching Level is not valid");
            }

            if ( (pc.WSUSID == null) || (pc.WSUSID == Guid.Empty)  )
            {
                Errors.Add($"WSUS ID is missing, null or empty");
            }

            if  (string.IsNullOrEmpty(pc.WUServer))
            {
                Errors.Add($"WSUS Server is missing, null, or empty");
            }

            //log.LogDebug($"[API]    AuOptions - Basic");
            //Basic Patching Level must have AUOptions 4 or 5
            if (pc.PatchingLevel == PatchingLevels.Basic)
            {
                if ((pc.AUOptions != 4) && (pc.AUOptions != 5))
                {
                    Errors.Add($"Action/AUOptions is not valid with Basic Patching Level");
                }
            }

            //log.LogDebug($"[API]    AuOptions - Manual");
            //Manual Patching Level must have AUOptions 2 or 3
            if (pc.PatchingLevel == PatchingLevels.Manual)
            {
                if ((pc.AUOptions != 2) && (pc.AUOptions != 3))
                {
                    Errors.Add($"Action/AUOptions is not valid with Manual Patching Level");
                }
            }


            if (pc.PatchingLevel != PatchingLevels.Advanced)
            {
                if ((pc.ScheduledWeek == null) || (pc.ScheduledWeek < 0) || (pc.ScheduledWeek > 3))
                {
                    Errors.Add($"Scheduled Week is not valid");
                }

                if ((pc.ScheduledDay == null) || (pc.ScheduledDay < 0) || (pc.ScheduledDay > 7))
                {
                    Errors.Add($"Scheduled Day is not valid");
                }

                if ((pc.ScheduledTime == null) || (pc.ScheduledTime < 0) || (pc.ScheduledTime > 23))
                {
                    Errors.Add($"Scheduled Time is not valid");
                }
            }

            if (pc.PatchingLevel == PatchingLevels.Advanced)
            {
                //if ( (pc.AdvancedPatching.Arguments == null) || (!(pc.AdvancedPatching.Arguments is PatchingClientPatchNowArguments)) )
                if (pc.AdvancedPatching.Arguments == null) 
                {
                    //are adv. patching args already available in ARIC?
                    //if (!(PatchClient.AdvancedPatching.Arguments is PatchingClientPatchNowArguments))
                    //{
                        Errors.Add($"Advanced Patching Arguments are required when PatchingLevel is 2(Advanced)");
                    //}
                }
                else
                {
                    PatchingClientPatchNowArguments args = new PatchingClientPatchNowArguments();
                    try
                    {
                        args = pc.AdvancedPatching.Arguments as PatchingClientPatchNowArguments;

                        if (!args.DownloadPatches)
                        {
                            pc.Errors.Add($"'DownloadPatches' argument must be set to TRUE");
                        }
                    }
                    catch (InvalidCastException castex)
                    {
                        pc.Errors.Add($"Error parsing Advanced Patching Arguments: {castex.Message}");
                    }
                    catch (Exception ex)
                    {
                        ex.Data.Add("Arguments", pc.AdvancedPatching.Arguments);
                        pc.Errors.Add($"Unexpected error parsing or validating Advanced Patching Arguments: {ex.Message}");
                    }
                }
            }
            return Errors;
        }

        private void ValidateWSUSData(PatchingClient pc)
        {
            if (pc.LastPatchDate < DateTime.UtcNow.AddMonths(-1 * config.LastPatchDateTimeout))
            {
                pc.Errors.Add($"Client has not been patched in more than {config.LastPatchDateTimeout} months");
            }

            if (pc.RebootPending == null)
            {
                pc.Errors.Add($"Reboot Pending state could not be determined");
            }

            if (pc.LastContact == null)
            {
                pc.Errors.Add($"WSUS LastContact date could not be determined");
            }
            else
            {
                if (pc.LastContact < DateTime.UtcNow.AddHours(-1 * config.LastContactTimeout))
                {
                    pc.Errors.Add($"Client has not contacted its WSUS server within the last {config.LastContactTimeout} hours");
                }
            }
        }

        private string UpdateClient(PatchingClient pc)
        {
            log.LogDebug($"[API] Updating Patching Client....");
            
            StringBuilder sbDetails = new StringBuilder();
            string[] Day = { "Everyday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            string[] Week = { "Custom", "Early", "Default", "Delayed" };
            bool updateAdvPatching = false;

            //if  old client is advanced patching and new client is NOT advanced patching(i.e. changing FROM advanced patching to something else)
            // OR old client is NOT advanced patching and new client IS advanced patching(i.e., changing TO advanced patching from something else)
            // OR both are set to advanced patching
            //
            //simplifies down to      if either one is set to advanced patching
            //log.LogDebug($"adv test pc         : {(pc.PatchingLevel == PatchingLevels.Advanced)}");
            //log.LogDebug($"adv test PatchClient: {(PatchClient.PatchingLevel == PatchingLevels.Advanced)}");

            // update Adv Patching Timetable if
            //      Patching Level is changing either TO or FROM "Advanced"
            updateAdvPatching = ((PatchClient.PatchingLevel != pc.PatchingLevel) &&    //is patching level being changed?
                                    (
                                        (PatchClient.PatchingLevel == PatchingLevels.Advanced) ||   //changing FROM advanced?
                                        (pc.PatchingLevel == PatchingLevels.Advanced)               //changing TO advanced
                                    )
                                );

            //log.LogDebug($"adv test AND/OR     : {updateAdvPatching}");

            if (PatchClient.PatchingLevel != pc.PatchingLevel)
            {
                sbDetails.AppendLine($"PatchingLevel changed from {PatchClient.PatchingLevel} to {pc.PatchingLevel}");
                PatchClient.PatchingLevel = pc.PatchingLevel;
            }



            if (PatchClient.UseWUServer != pc.UseWUServer)
            {
                sbDetails.AppendLine($"UseWUServer changed from {PatchClient.UseWUServer} to {pc.UseWUServer}");
                PatchClient.UseWUServer = pc.UseWUServer;
            }

            if (PatchClient.WUServer != pc.WUServer)
            {
                sbDetails.AppendLine($"WUServer changed from {PatchClient.WUServer} to {pc.WUServer}");
                PatchClient.WUServer = pc.WUServer;
            }

            if (PatchClient.AUOptions != pc.AUOptions)
            {
                sbDetails.AppendLine($"AUOptions changed from {PatchClient.AUOptions} to {pc.AUOptions}");
                PatchClient.AUOptions = pc.AUOptions;
            }

            if (PatchClient.OptedOut != pc.OptedOut)
            {
                sbDetails.AppendLine($"OptedOut changed from {PatchClient.OptedOut} to {pc.OptedOut}");
                PatchClient.OptedOut = pc.OptedOut;
            }

            if ((pc.PatchingLevel == PatchingLevels.Basic) || (pc.PatchingLevel == PatchingLevels.Manual))
            {
                if (PatchClient.ScheduledDay != pc.ScheduledDay)
                {
                    if ((PatchClient.ScheduledDay == null) || (PatchClient.ScheduledDay < 0) || (PatchClient.ScheduledDay > 7))
                    {
                        sbDetails.AppendLine($"ScheduledDay changed from {PatchClient.ScheduledDay} to {Day[(int)pc.ScheduledDay]}");
                    }
                    else
                    {
                        sbDetails.AppendLine($"ScheduledDay changed from {Day[(int)PatchClient.ScheduledDay]} to {Day[(int)pc.ScheduledDay]}");
                    }
                    PatchClient.ScheduledDay = pc.ScheduledDay;
                }

                if (PatchClient.ScheduledTime != pc.ScheduledTime)
                {
                    sbDetails.AppendLine($"ScheduledTime changed from {PatchClient.ScheduledTime} to {pc.ScheduledTime}");
                    PatchClient.ScheduledTime = pc.ScheduledTime;
                }

                if (PatchClient.ScheduledWeek != pc.ScheduledWeek)
                {
                    if ((PatchClient.ScheduledWeek == null) || (PatchClient.ScheduledWeek < 1) || (PatchClient.ScheduledWeek > 3))
                    {
                        sbDetails.AppendLine($"ScheduledWeek changed from {PatchClient.ScheduledWeek} to {Week[(int)pc.ScheduledWeek]}");
                    }
                    else
                    {
                        sbDetails.AppendLine($"ScheduledWeek changed from {Week[(int)PatchClient.ScheduledWeek]} to {Week[(int)pc.ScheduledWeek]}");
                    }
                    PatchClient.ScheduledWeek = pc.ScheduledWeek;
                }

                if (PatchClient.NoAutoRebootWithLoggedOnUsers != pc.NoAutoRebootWithLoggedOnUsers)
                {
                    sbDetails.AppendLine($"NoAutoRebootWithLoggedOnUsers changed from {PatchClient.NoAutoRebootWithLoggedOnUsers} to {pc.NoAutoRebootWithLoggedOnUsers}");
                    PatchClient.NoAutoRebootWithLoggedOnUsers = pc.NoAutoRebootWithLoggedOnUsers;
                }
            }


            PatchingClientPatchNowArguments oldArgs = new PatchingClientPatchNowArguments();
            PatchingClientPatchNowArguments newArgs = new PatchingClientPatchNowArguments();

            if (pc.PatchingLevel == PatchingLevels.Advanced)
            {
                log.LogDebug($"[API] Auditing Advanced Patching properties....");

                PatchClient.ScheduledWeek = 1;  //Early Week
                PatchClient.ScheduledDay = 1;   //Sunday
                PatchClient.ScheduledTime = 0;  //midnight

                if (PatchClient.AdvancedPatching == null)
                {
                    PatchClient.AdvancedPatching = new PatchingClientAdvancedPatching();
                }

                //log.LogDebug($"[API] Comparing Advanced Patching CronTab ....");
                if (PatchClient.AdvancedPatching.ToCronTab() != pc.AdvancedPatching.ToCronTab())
                {
                    sbDetails.AppendLine($"Advanced Patching Schedule changed from {PatchClient.AdvancedPatching.ToCronTab()} to {pc.AdvancedPatching.ToCronTab()}");
                    PatchClient.AdvancedPatching.DayOfMonth = pc.AdvancedPatching.DayOfMonth;
                    PatchClient.AdvancedPatching.DayOfWeek = pc.AdvancedPatching.DayOfWeek;
                    PatchClient.AdvancedPatching.Hour = pc.AdvancedPatching.Hour;
                    PatchClient.AdvancedPatching.Minute = pc.AdvancedPatching.Minute;
                    PatchClient.AdvancedPatching.MonthOfYear = pc.AdvancedPatching.MonthOfYear;
                    updateAdvPatching = true;
                }

                //log.LogDebug($"[API] Comparing Advanced Patching ProcessName ....");
                if (PatchClient.AdvancedPatching.ProcessName != pc.AdvancedPatching.ProcessName)
                {
                    sbDetails.AppendLine($"Advanced Patching Process changed from {PatchClient.AdvancedPatching.ProcessName} to {pc.AdvancedPatching.ProcessName}");
                    PatchClient.AdvancedPatching.ProcessName = pc.AdvancedPatching.ProcessName;
                    updateAdvPatching = true;
                }

                string json = JsonConvert.SerializeObject(PatchClient.AdvancedPatching.Arguments);
                log.LogDebug($"[API] Client.Adv.Args: {json}");
                oldArgs = JsonConvert.DeserializeObject<PatchingClientPatchNowArguments>(json);
                //log.LogDebug($"[API] oldArgs: {JsonConvert.SerializeObject(oldArgs)}");


                json = JsonConvert.SerializeObject(pc.AdvancedPatching.Arguments);
                log.LogDebug($"[API] pc.Adv.Args: {json}");
                newArgs = JsonConvert.DeserializeObject<PatchingClientPatchNowArguments>(json);
                //log.LogDebug($"[API] newArgs: {JsonConvert.SerializeObject(newArgs)}");
                
                //log.LogDebug($"[API] Comparing Advanced Patching EndTime ....");

                DateTime oldtime = DateTime.MinValue;
                DateTime newtime = DateTime.MinValue;

                //log.LogDebug($"[API]     Checking oldTime has a value....");
                if (oldArgs.Endtime.HasValue) 
                {
                    log.LogDebug($"[API]     setting oldtime to ...");
                    oldtime = oldArgs.Endtime.Value;  
                }
                //log.LogDebug($"[API] oldtime: {oldtime}");

                //log.LogDebug($"[API]     Checking newTime has a value....");
                if (newArgs.Endtime.HasValue) 
                {
                    log.LogDebug($"[API]     setting newtime to ...");
                    newtime = newArgs.Endtime.Value; 
                }
               
                //log.LogDebug($"[API] newtime: {newtime}");

                //if (oldArgs.Endtime != newArgs.Endtime)
                if (oldtime != newtime)
                {
                    sbDetails.AppendLine($"Advanced Patching Endtime changed from {oldArgs.Endtime} to {newArgs.Endtime}");
                    //oldArgs.Endtime = newArgs.Endtime;
                    updateAdvPatching = true;
                }

                //log.LogDebug($"[API] Comparing Advanced Patching DownloadPatches Flag ....");
                if (oldArgs.DownloadPatches != newArgs.DownloadPatches)
                {
                    sbDetails.AppendLine($"Advanced Patching DownloadPatches flag changed from {oldArgs.DownloadPatches} to {newArgs.DownloadPatches}");
                    //oldArgs.DownloadPatches = newArgs.DownloadPatches;
                    updateAdvPatching = true;
                }

                //log.LogDebug($"[API] Comparing Advanced Patching InstallPatches Flag ....");
                if (oldArgs.InstallPatches != newArgs.InstallPatches)
                {
                    sbDetails.AppendLine($"Advanced Patching InstallPatches flag changed from {oldArgs.InstallPatches} to {newArgs.InstallPatches}");
                    //oldArgs.InstallPatches = newArgs.InstallPatches;
                    updateAdvPatching = true;
                }

                //log.LogDebug($"[API] Comparing Advanced Patching Reboot Flag ....");
                if (oldArgs.Reboot != newArgs.Reboot)
                {
                    sbDetails.AppendLine($"Advanced Patching Reboot flag changed from {oldArgs.Reboot} to {newArgs.Reboot}");
                    //oldArgs.Reboot = newArgs.Reboot;
                    updateAdvPatching = true;
                }

                //log.LogDebug($"[API] Comparing Advanced Patching ForceReboot Flag ....");
                if (oldArgs.ForceReboot != newArgs.ForceReboot)
                {
                    sbDetails.AppendLine($"Advanced Patching ForceReboot flag changed from {oldArgs.ForceReboot} to {newArgs.ForceReboot}");
                    //oldArgs.ForceReboot = newArgs.ForceReboot;
                    updateAdvPatching = true;
                }
            }

            if (updateAdvPatching)
            {
                log.LogDebug($"[API] Updating ARIC TimeTable Config....");
                PatchClient.AdvancedPatching.Arguments = newArgs;
                PatchClient.AdvancedPatching.ID = this.UpdateAricTimetable(pc);
            }

            log.LogDebug($"[API] Saving Patch Client....");
            PatchClient.Save(); //save Patching client with new data applied


            if (!PatchClient.OptedOut)
            {
                log.LogDebug($"[API] Pushing settings to client....");
                this.PushSettings();
            }
            return sbDetails.ToString();
        }

        private IActionResult OptInDevice()
        {
            if (!PatchClient.OptedOut)  //is the device already opted in?
            {
                return StatusCode(304, "Device is already opted in");
            }

            PatchClient.OptIn();

            audit.SystemId = config.SystemId;

            audit.TimeStamp = DateTime.UtcNow;
            audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            audit.Action = "Device Opted IN";
            audit.DeviceNumber = null;

            audit.Account = server.Account;

            audit.Save();

            return NoContent();
        }


        private IActionResult OptOutDevice()
        {
            if (PatchClient.OptedOut)  //is the device already opted in?
            {
                return StatusCode(304, "Device is already opted out");
            }

            PatchClient.OptOut();

            audit.SystemId = config.SystemId;

            audit.TimeStamp = DateTime.UtcNow;
            audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;

            audit.Action = "Device Opted OUT";
            audit.DeviceNumber = null;

            server.Load(PatchClient.DeviceNumber);
            audit.Account = server.Account;

            audit.Save();

            return NoContent();
        }


        private IActionResult PullSettings()
        {
            List<AricRegistryKey> keysToPull = new List<AricRegistryKey>() {
                new AricRegistryKey("HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\SusClientId"),
                new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallDay"),
                new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallTime"),
                new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\AUOptions"),
                new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoRebootWithLoggedOnUsers"),
                new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoUpdate"),
                new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\UseWUServer"),
                new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\WUServer")
            };
            string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
            int acct = -1;

            if (PatchClient.OptedOut)  //is the device already opted in?
            {
                return StatusCode(304, "Device is opted out.  Opt-in the server before pulling settings");
            }

            server.Load(PatchClient.DeviceNumber);
            acct = server.Account;

            AricJobPayload data = new AricJobPayload();
            AricMetadataPullSettings meta = new AricMetadataPullSettings();
            meta.DeviceId = PatchClient.DeviceNumber.ToString();
            meta.SsoUserName = sso;
            meta.WinPatchUrl = config.AricCallbackUrl;
            string json = JsonConvert.SerializeObject(keysToPull);
            byte[] bson = Encoding.UTF8.GetBytes(json);
            meta.Base64Json = Convert.ToBase64String(bson);

            data.Name = "WAP:Portal:PatchSettingsAudit";
            data.Source = "WindowsAutomationTeam";
            data.Tenant = acct;
            data.Targets.Add(new AricTarget(PatchClient.DeviceNumber));
            data.Metadata = meta;

            aricJob.Create(sso, token, config.SystemId, data);

            string jobUrl = $"{meta.WinPatchUrl}{aricJob.EventId}";
            return Created(jobUrl, aricJob);
        }

        private void PushSettings()
        {
            string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
            int acct = -1;
            server.Load(PatchClient.DeviceNumber);
            acct = server.Account;

            AricJobPayload data = new AricJobPayload();
            AricMetadataPushSettings meta = new AricMetadataPushSettings();
            meta.DeviceId = PatchClient.DeviceNumber.ToString();
            meta.SsoUserName = sso;
            //meta.WinpatchUrl = "https://test.api.selfservice.intensive.int/aric/v1/jobs/";
            meta.WinPatchUrl = config.AricCallbackUrl;
            

            //set registry keys
            List<AricRegistryKeyValueType> regkeys = BuildRegistryKeysAndValues();

            string json = JsonConvert.SerializeObject(regkeys);
            byte[] bson = Encoding.UTF8.GetBytes(json);
            meta.Base64Json = Convert.ToBase64String(bson);

            data.Name = "WAP:Portal:PatchSettingsConfig";
            data.Source = "WindowsAutomationTeam";
            data.Tenant = acct;
            data.Targets.Add(new AricTarget(PatchClient.DeviceNumber));
            data.Metadata = meta;

            aricJob.Create(sso, token, config.SystemId, data);
        }

        private IActionResult PatchNow()
        {
            string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
            int acct = -1;

            if (PatchClient.OptedOut)  //is the device already opted in?
            {
                return StatusCode(304, "Device is opted out.  Opt-in the server before pulling settings");
            }

            //server.Load(PatchClient.DeviceNumber);
            acct = server.Account;

            AricJobPayload job = new AricJobPayload();
            job.Name = "WAP:Portal:PatchNow";
            job.Source = "WindowsAutomationTeam";
            job.Tenant = acct;
            job.Targets.Add(new AricTarget(PatchClient.DeviceNumber));

            AricMetadataPatchNow meta = new AricMetadataPatchNow();
            meta.SsoUserName = sso;
            meta.WinPatchUrl = config.AricCallbackUrl;
            meta.DownloadPatches = true;
            meta.InstallPatches = true;
            meta.Reboot = false;
            meta.ForceReboot = false;
            meta.TriggeredBy = "portal";
            meta.DeviceId = PatchClient.DeviceNumber.ToString();
            meta.StreamId = $"{job.Name}{PatchClient.DeviceNumber}";
            

            job.Metadata = meta;
            
            aricJob.Create(sso, token, config.SystemId, job);

            audit.SystemId = config.SystemId;

            audit.TimeStamp = DateTime.UtcNow;
            audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            audit.Action = "Patch Now";
            audit.DeviceNumber = PatchClient.DeviceNumber;

            audit.Account = acct;

            audit.Save();


            string jobUrl = $"{meta.WinPatchUrl}{aricJob.EventId}";
            return Created(jobUrl, aricJob);
        }

        //private IActionResult DefaultToMicrosoftSettings()
        //{
        //    string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
        //    string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
        //    int acct = -1;
        //    server.Load(PatchClient.DeviceNumber);
        //    acct = server.Account;

        //    AricJobPayload data = new AricJobPayload();
        //    AricMetadataPushSettings meta = new AricMetadataPushSettings();
        //    meta.DeviceId = PatchClient.DeviceNumber.ToString();
        //    meta.SsoUserName = sso;
        //    //meta.WinpatchUrl = "https://test.api.selfservice.intensive.int/aric/v1/jobs/";
        //    meta.WinPatchUrl = config.AricCallbackUrl;

        //    //set registry keys
        //    List<AricRegistryKey> regkeys = new List<AricRegistryKey>()
        //    {
        //        new AricRegistryKey("HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate")
        //    };

        //    string json = JsonConvert.SerializeObject(regkeys);
        //    byte[] bson = Encoding.UTF8.GetBytes(json);
        //    meta.Base64Json = Convert.ToBase64String(bson);

        //    data.Name = "WAP:Portal:PatchSettingsDelete";
        //    data.Source = "WindowsAutomationTeam";
        //    data.Tenant = acct;
        //    data.Targets.Add(new AricTarget(PatchClient.DeviceNumber));
        //    data.Metadata = meta;

        //    aricJob.Create(sso, token, config.SystemId, data);

        //    string url = $"{Request.Scheme}://{Request.Host}aric/v1/{aricJob.EventId}";
        //    return Created(url, aricJob);

        //}

        private IActionResult DefaultToRackspaceSettings()
        {
            log.LogDebug("Resetting to Rackspace Defaults");
            string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
            //disable Adv Patch schedule, if enabled
            if (PatchClient.PatchingLevel == PatchingLevels.Advanced)
            {
                timetable.Load(PatchClient.AdvancedPatching.ID, token);
                timetable.Enabled = false;
                Guid id = timetable.Save(token);
            }

            PatchClient.AUOptions = 4;  //Automatic download and install
            PatchClient.NoAutoRebootWithLoggedOnUsers = false;
            PatchClient.PatchingLevel = PatchingLevels.Basic;
            if (config.DefaultScheduleDay.ContainsKey(server.DataCenter))
            {
                PatchClient.ScheduledDay = (short)config.DefaultScheduleDay[server.DataCenter];
                PatchClient.WUServer = config.DefaultWUServer[server.DataCenter];
            }
            else
            {
                PatchClient.ScheduledDay = (short)config.DefaultScheduleDay["DFW"];
                PatchClient.WUServer = config.DefaultWUServer["DFW"];
            }
            PatchClient.ScheduledTime = 2;  //2:00am local time
            PatchClient.ScheduledWeek = 2;  //DefaultReleaseWeek
            PatchClient.UseWUServer = true;
           

            PatchClient.Save();

            PushSettings(); //builds aricJob

            audit.SystemId = config.SystemId;
            audit.TimeStamp = DateTime.UtcNow;
            audit.UserId = sso;
            audit.Action = "Reset to RS Defaults";
            audit.DeviceNumber = PatchClient.DeviceNumber;
            audit.Account = server.Account;

            audit.Save();


            string jobUrl = $"{config.AricCallbackUrl}{aricJob.EventId}";
            return Created(jobUrl, aricJob);
        }

        private IActionResult ResetWSUSId()
        {
            string sso = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            string token = User.Claims.FirstOrDefault(c => c.Type == "token").Value;
            int acct = -1;
            server.Load(PatchClient.DeviceNumber);
            acct = server.Account;

            AricJobPayload data = new AricJobPayload();
            AricMetadataPushSettings meta = new AricMetadataPushSettings();
            meta.DeviceId = PatchClient.DeviceNumber.ToString();
            meta.SsoUserName = sso;
            meta.WinPatchUrl = config.AricCallbackUrl;

            //set registry keys
            List<AricRegistryKeyValue> regkeys = new List<AricRegistryKeyValue>()
            {
                new AricRegistryKeyValue("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate", "AccountDomainSid"),
                new AricRegistryKeyValue("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate", "PingID"),
                new AricRegistryKeyValue("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate", "SusClientId"),
                new AricRegistryKeyValue("HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate", "SusClientIdValidation")
            };

            string json = JsonConvert.SerializeObject(regkeys);
            byte[] bson = Encoding.UTF8.GetBytes(json);
            meta.Base64Json = Convert.ToBase64String(bson);

            data.Name = "WAP:Portal:PatchSettingsDelete";
            data.Source = "WindowsAutomationTeam";
            data.Tenant = acct;
            data.Targets.Add(new AricTarget(PatchClient.DeviceNumber));
            data.Metadata = meta;

            aricJob.Create(sso, token, config.SystemId, data);

            audit.SystemId = config.SystemId;
            audit.TimeStamp = DateTime.UtcNow;
            audit.UserId = sso;
            audit.Action = "Reset WSUS ID";
            audit.DeviceNumber = PatchClient.DeviceNumber;
            audit.Account = server.Account;

            audit.Save();

            string url = $"{config.AricCallbackUrl}{aricJob.EventId}";
            return Created(url, aricJob);

        }


        private List<AricRegistryKeyValueType> BuildRegistryKeysAndValues()
        {
            List<AricRegistryKeyValueType> regKeys = new List<AricRegistryKeyValueType>();
            AricRegistryKeyValueType regKey;

            //string hkey = "HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\";
            string hkeyPolicy = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\";
            string hkeyAU = $"{hkeyPolicy}AU\\";

            regKey = new AricRegistryKeyValueType($"{hkeyPolicy}WUServer", "String", PatchClient.WUServer);
            regKeys.Add(regKey);

            regKey = new AricRegistryKeyValueType($"{hkeyPolicy}WUStatusServer", "String", PatchClient.WUServer);
            regKeys.Add(regKey);

            if ((PatchClient.PatchingLevel == PatchingLevels.None) || (PatchClient.PatchingLevel == PatchingLevels.Advanced))
            {
                regKey = new AricRegistryKeyValueType($"{hkeyAU}NoAutoUpdate", "DWord", "1");
            }
            else
            {
                regKey = new AricRegistryKeyValueType($"{hkeyAU}NoAutoUpdate", "DWord", "0");
            }
            regKeys.Add(regKey);


            regKey = new AricRegistryKeyValueType($"{hkeyAU}AUOptions", "DWord", PatchClient.AUOptions.ToString());
            regKeys.Add(regKey);

            regKey = new AricRegistryKeyValueType($"{hkeyAU}NoAutoRebootWithLoggedOnUsers", "DWord", (bool)PatchClient.NoAutoRebootWithLoggedOnUsers ? "1" : "0");
            regKeys.Add(regKey);

            regKey = new AricRegistryKeyValueType($"{hkeyAU}ScheduledInstallDay", "DWord", PatchClient.ScheduledDay.ToString());
            regKeys.Add(regKey);

            regKey = new AricRegistryKeyValueType($"{hkeyAU}ScheduledInstallTime", "DWord", PatchClient.ScheduledTime.ToString());
            regKeys.Add(regKey);

            return regKeys;
        }
    }
}

