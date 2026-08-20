using System;
using Intensive.Services.Aric;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intensive.API.Global;
using Intensive.Data;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ARIC.Controllers
{
    [ApiController]
    [Route("processes")]

    public class AricProcessesController : ControllerBase
    {

        protected ILogger<AricProcessesController> log;
        AricProcess aricProcess;

        public AricProcessesController(ILogger<AricProcessesController> logger,
                                AricProcess ap
                                )
        {
            log = logger;
            aricProcess = ap;
        }
        // gets the aric processes defined for a given system
        // generally used to populate a dropdown/selection list
        [HttpGet]
        public IActionResult Get([FromQuery] int systemid, [FromQuery] string name)
        {
            List<AricProcess> processes = new List<AricProcess>();

            try
            {
                if (systemid == 0)
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        processes = aricProcess.Find();
                    }
                    else
                    {
                        processes = aricProcess.Find(name);
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        processes = aricProcess.Find(systemid);
                    }
                    else
                    {
                        processes = aricProcess.Find(systemid,name);
                    }
                }

                APICollection results = new APICollection();
                string resourceURL = string.Empty;

                foreach (AricProcess p in processes)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/processes/{p.ProcessName}";
                    results.Resources.Add(resourceURL);
                }
               return Ok(results);
            }
            catch (Exception ex)
            {
                ex.Data.Add("systemid", systemid);
                ex.Data.Add("name", name);
                APIError err = new APIError(ex, 300, $"Unexpected error has occured while querying ARIC for matching processes");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [Route("{name}")]
        [HttpGet]
        public IActionResult Get([FromRoute] string name)
        {
            try
            {
                aricProcess.Load(name);
                return Ok(aricProcess);
            }
            catch (AricNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("name", name);
                APIError err = new APIError(ex, 301, $"Unable to load ARIC process {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }
    }
}
