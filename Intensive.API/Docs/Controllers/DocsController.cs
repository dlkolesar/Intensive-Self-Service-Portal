using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Docs.Controllers
{
    [ApiController]
    [Route("")]
    public class DocsController : ControllerBase
    {
        IConfiguration config;
        ILogger<DocsController> log;
        IWebHostEnvironment env;
        List<ApiDocsMetaData> docs;
        ApiDocsMetaData doc;
        public DocsController(ILogger<DocsController> logger, IConfiguration cfg, IWebHostEnvironment hostenv)
        {
            log = logger;
            config = cfg;
            env = hostenv;
        }
       string docRoot = "OpenAPIDocs";
        string curr = Directory.GetCurrentDirectory();
        [HttpGet]
        public IActionResult Get()
        {
            docs = new List<ApiDocsMetaData>();
            string apidocs = config.GetValue<string>("apidocs");
            string path = $"{env.WebRootPath}\\{apidocs}";
            Directory.SetCurrentDirectory(path);



            foreach (string cat in Directory.EnumerateDirectories(path))
            {
                log.LogDebug(Tail(cat));
                foreach (string api in Directory.EnumerateDirectories(cat))
                {
                    log.LogDebug($"   {Tail(api)}");
                    
                    foreach (string fil in Directory.EnumerateFiles(api, "*.json"))
                    {
                        log.LogDebug($"      {Tail(fil)}");
                        doc = new ApiDocsMetaData();

                        FileInfo fi = new FileInfo(fil);
                        doc.FileName = fi.Name;

                        doc.Category = Tail(cat);
                        doc.Title = Tail(api);

                        IEnumerable<string> icons = Directory.EnumerateFiles(api, "*.*")
                                .Where(f => f.EndsWith(".png") | f.EndsWith(".jpg") | f.EndsWith(".gif") | f.EndsWith(".ico"));

                        doc.IconFileName = Tail(icons.FirstOrDefault<string>());
                        docs.Add(doc);
                    }
                }
            }


            return Ok(docs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        private string Tail(string dir)
        {
            if (string.IsNullOrEmpty(dir)) { return String.Empty; }

            string[] t = dir.Split(new char[] { '\\' });
            int l = t.Length-1;

            return t[l];


        }


    }


}
