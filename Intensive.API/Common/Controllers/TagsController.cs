using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Intensive.API.Global;
using Intensive.Services.Common;
using Intensive.Services.Auditing;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Common.Controllers
{
    [ApiController]
    [Route("tags")]
    public class TagsController : ControllerBase
    {
        private ILogger<TagsController> log;
        private Tag tags;
        private AuditTrail audit;
        public TagsController(ILogger<TagsController> logger, 
                                AuditTrail aud,
                                Tag tagSvc)
        {
            log = logger;
            tags = tagSvc;
            audit = aud;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()  //get all "public" tags
        {

            APICollection results = new APICollection();
            string resourceURL;
            try
            {
                List<Tag> lst = await tags.Find(null); //public tags have a null account number
                foreach (Tag t in lst)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}/tags/{t.ID.ToString()}";
                    results.Resources.Add(resourceURL);
                }
                return Ok(results);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 200, $"Unexpected error finding public tags: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"{id} is not a valid tag id.  ID numbers must be greater than zero");
            }

            try
            {
                await tags.Load(id);
                return Ok(tags);
            }
            catch(TagNotFoundException nf)
            {
                return NotFound($"A tag with {id} was not found");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 200, $"Unexpected error loading tag {id}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

     }
}
