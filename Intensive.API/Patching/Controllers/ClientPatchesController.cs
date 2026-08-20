using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intensive.API.Global;
using Intensive.Services.Common;
using Intensive.Services.Auditing;
using Intensive.Data.SSDatabase;
using Intensive.Services.Patching;
using Intensive.Services.Patching.Exceptions;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Options;
using Intensive.Data.WSUS;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Patching.Controllers
{
    [Route("clients/{deviceNumber}/patches")]
    public class ClientPatchesController : Controller
    {
        protected ILogger<ClientController> log;
        protected PatchingSystemConfig config;
        protected PatchingClient PatchClient;
        protected PatchStatus patchStatus;
        protected AuditTrail audit;

        public ClientPatchesController(ILogger<ClientController> logger,
                                IOptions<PatchingSystemConfig> patchConfig,
                                PatchingClient pc,
                                PatchStatus ps,
                                AuditTrail auditTrail
                               )
        {
            PatchClient = pc;
            log = logger;
            config = patchConfig.Value;
            audit = auditTrail;
            patchStatus = ps;
        }


        //[HttpGet]
        ////[ResponseCache(CacheProfileName = "Default")]
        //public IActionResult Get([FromRoute] int deviceNumber, [FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery]string includeStates, [FromQuery] string excludeStates)
        //{
        //    if (deviceNumber <= 0) { return BadRequest(); }
        //    int incStates = -1;
        //    int excStates = 0;


        //    if (from == DateTime.MinValue) { from = new DateTime(1753, 1,1); }
        //    if (to == DateTime.MinValue)   { to = DateTime.Now;  }

        //    if (!string.IsNullOrEmpty(includeStates))
        //    {
        //        incStates = TranslateStates(includeStates);
        //    }

        //    if (!string.IsNullOrEmpty(excludeStates))
        //    {
        //        excStates = TranslateStates(excludeStates);
        //    }

        //    if (incStates == 0) { return BadRequest("the value(s) provided in 'includeStates' will always produce zero results"); }

        //    if ((excStates == -1) || (excStates == 124)) //124 means every state has been selected for exclusion, therefore everything will be excluded
        //    { 
        //        return BadRequest("the value(s) provided in 'excludeStates' will always produce zero results"); 
        //    }

        //    if (incStates == excStates){return BadRequest("the combination of values in 'includeStates' and 'excludeStates' will always produce zero results");}


        //    try
        //    {
        //        PatchClient.Load(deviceNumber);

        //        if (PatchClient.WUServer.ToLower().EndsWith("rackspace.com"))
        //        {
        //            log.LogDebug($"Finding Patches....");
        //            List<Guid> Patches = PatchClient.FindPatches(from, to, incStates, excStates);

        //            //build the url result set
        //            string resourceURL = string.Empty;

        //            APICollection results = new APICollection();
        //            foreach (Guid g in Patches)
        //            {
        //                resourceURL = $"https://{Request.Host}{Request.PathBase}/clients/{PatchClient.DeviceNumber}/patches/{g.ToString()}";
        //                results.Resources.Add(resourceURL);
        //            }
        //            return Ok(results);
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (PatchingNotFoundException nf)
        //    {
        //        return NotFound();
        //    }
        //    catch (PatchingWSUSConnectionException nf)
        //    {
        //        return NotFound();
        //    }
        //    catch (PatchingWSUSNotFoundException nf)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        //return Ok(PatchClient);
        //        APIError err = new APIError();
        //        log.LogError(err.ErrorCode, ex, err.Message);
        //        return new ServerError(err);
        //    }
        //}

        //[HttpGet("installed")]
        ////[ResponseCache(CacheProfileName = "Default")]
        //public IActionResult GetInstalledPatches(int deviceNumber, [FromQuery] DateTime from, [FromQuery] DateTime to)
        //{
        //    if (from == DateTime.MinValue) { from = new DateTime(1753, 1, 1); }
        //    if (to == DateTime.MinValue) { to = DateTime.Now; }
        //    return this.Get(deviceNumber, from, to, "Installed", null);
        //}

        //[HttpGet("missing")]
        ////[ResponseCache(CacheProfileName = "Default")]
        //public IActionResult GetMissingPatches(int deviceNumber, [FromQuery] DateTime from, [FromQuery] DateTime to)
        //{
        //    if (from == DateTime.MinValue) { from = new DateTime(1753, 1, 1); }
        //    if (to == DateTime.MinValue) { to = DateTime.Now; }
        //    return this.Get(deviceNumber, from, to, "Downloaded,NotInstalled,Failed", null);
        //}

        //[HttpGet("pendingReboot")]
        ////[ResponseCache(CacheProfileName = "Default")]
        //public IActionResult GetPendingPatches(int deviceNumber, [FromQuery] DateTime from, [FromQuery] DateTime to)
        //{
        //    if (from == DateTime.MinValue) { from = new DateTime(1753, 1, 1); }
        //    if (to == DateTime.MinValue) { to = DateTime.Now; }
        //    return this.Get(deviceNumber, from, to, "PendingReboot", null);
        //}

        [HttpGet("missing")]
        //[ResponseCache(CacheProfileName = "Default")]
        public IActionResult Get(int deviceNumber)
        {
            if (deviceNumber <= 0) { return BadRequest(); }

            //eventLog.LogInformation($"Missing Patches: Loading Client data... ");
            try
            {
                PatchClient.Load(deviceNumber);

                if (PatchClient.WUServer.ToLower().EndsWith("rackspace.com"))
                {
                    //eventLog.LogInformation($"Missing Patches: Get Missing Patches... ");
                    List<PatchStatus> OutstandingPatches = PatchClient.GetMissingPatches();
                    return Ok(OutstandingPatches);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound();
            }
            catch (PatchingWSUSConnectionException nf)
            {
                return NotFound();
            }
            catch (PatchingWSUSNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                //return Ok(PatchClient);
                APIError err = new APIError();
                log.LogError(err.ErrorCode, ex, err.Message);
                return new ServerError(err);
            }


            //string resourceURL = string.Empty;
            //APICollection results = new APICollection();

            //build the url result set
            //foreach (Guid g in OutstandingPatches)
            //{
            //    resourceURL = $"https://{Request.Host}{Request.PathBase}/Clients/{deviceNumber}/patches/{g}";
            //    results.Resources.Add(resourceURL);
            //}


        }


        //get status of patch on this client
        [HttpGet("{patchId}")]
        //[ResponseCache(CacheProfileName = "Default")]
        public IActionResult Get(int deviceNumber, Guid patchId)
        {
            try
            {
                PatchClient.Load(deviceNumber);

                if ( (PatchClient.TargetId < 1) || ( PatchClient.WSUSID == null) || (PatchClient.WSUSID == Guid.Empty) )
                {
                    return BadRequest($"WSUS ID and/or Internal ID is missing.  You may need to do a Settings Pull to update the data");
                }

                log.LogDebug($"Getting Client Patch Status....");
                PatchStatus status = PatchClient.GetClientPatchStatus(patchId);
                return Ok(status);
            }
            catch (PatchingNotFoundException nf)
            {
                return NotFound(nf.Message);
            }
            catch (PatchingWSUSConnectionException nf)
            {
                return NotFound(nf.Message);
            }
            catch (PatchingWSUSNotFoundException nf)
            {
                return NotFound(nf.Message);
            }
            catch (Exception ex)
            {
                //return Ok(PatchClient);
                APIError err = new APIError();
                log.LogError(err.ErrorCode, ex, err.Message);
                return new ServerError(err);
            }
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return StatusCode(405);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return StatusCode(405);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return StatusCode(405);
        }



        [Flags]
        enum InstallationStateFlags
        {
            NotInstalled = 4,
            Downloaded = 8,
            Installed = 16,
            Failed = 32,
            PendingReboot = 64,
            All = -1,
            None = 0

        }



        // see "[spFilterUpdatesByScopeInternal] Stored Procedure in the WSUS DB for details
        // the value of the patching state is an integer 0-6(see the PatchStatus class for the ENUM).
        // When searching for patches the search proc call [spFilterUpdatesByScopeInternal], which uses
        // binary "flags" to indicate what states to search for.  
        //
        // the TranslateStates() function below "maps" the state names passed into the API to the binary flags used by the stored proc.
        //
        //  0000 0000 0111 1100
        //  |_________|||| ||||
        //       |     ||| |||+- ( 1) has something to do with Summary data for all computers(see the stored proc source code).  Always set to 0 (for now anyway)
        //       |     ||| ||+-- ( 2) has something to do with Summary data for all computers(see the stored proc source code).  Always set to 0 (for now anyway)
        //       |     ||| |+--- ( 4) Patch is NOTINSTALLED
        //       |     ||| +---- ( 8) Patch has been DOWNLOADED but not installed yet
        //       |     ||+------ (16) Patch has been INSTALLED successfully
        //       |     |+------- (32) Patch FAILED to install
        //       |     +-------- (64) Patch has been install, but has a PENDINGREBOOT for it to become effective
        //       |
        //       +--------------- Not used
        //

        private int TranslateStates(string states)
        {
            InstallationStateFlags stateValue = 0;
            string[] names = states.Split(new char[] { ',' });

            foreach (string n in names)
            {
                log.LogDebug($"translating {n} to binary flag");
                switch(n.ToLower().Trim())
                {
                    case "all": stateValue |= InstallationStateFlags.All; break;
                    case "none": stateValue |= InstallationStateFlags.None; break;
                    case "notinstalled": stateValue |= InstallationStateFlags.NotInstalled; break;
                    case "downloaded": stateValue |= InstallationStateFlags.Downloaded; break;
                    case "installed": stateValue |= InstallationStateFlags.Installed; break;
                    case "failed": stateValue |= InstallationStateFlags.Failed; break;
                    case "pendingreboot": stateValue |= InstallationStateFlags.PendingReboot; break;
                }  
            }

            return (int)stateValue;
        }
    }
}
