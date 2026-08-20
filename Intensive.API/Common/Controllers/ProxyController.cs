using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Intensive.API.Global;
using System.Net;
using System.Collections;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Common.Controllers
{
    [ApiController]
    [Route("proxy")]
    public class ProxyController : ControllerBase
    {
        ILogger<ProxyController> log;

        public ProxyController(ILogger<ProxyController> logger)
        {
            log = logger;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

        }
        // this controller is a simple reverse proxy, that will allow
        // the selfservice UI to make calls to other APIs, such as Identity, CORE, Rackspace AD, etc....
        //
        
        [HttpGet]
        public async Task Get([FromQuery] string url)
        {
            APIClient api = new APIClient();
            api.URL = url;
        
            IEnumerable<KeyValuePair<string, StringValues>> headers = this.Request.Headers
                                                                        .Where(h => !string.IsNullOrEmpty(h.Value)
                                                                                 && !WebHeaderCollection.IsRestricted(h.Key));

            foreach (KeyValuePair<string, StringValues> header in headers)
            {
                api.Headers.Add(header.Key, header.Value.ToString());
            }

            api.Verb = this.Request.Method;

            await this.ForwardRequest(api);
        }


        [HttpPost]
        public async Task Post([FromQuery] string url, [FromBody] object body)
        {
            APIClient api = new APIClient();
            api.URL = url;
            IEnumerable<KeyValuePair<string, StringValues>> headers = this.Request.Headers
                                                                        .Where(h => !string.IsNullOrEmpty(h.Value)
                                                                                 && !WebHeaderCollection.IsRestricted(h.Key));

            foreach (KeyValuePair<string, StringValues> header in headers)
            {
                api.Headers.Add(header.Key, header.Value.ToString());
            }

            api.Verb = this.Request.Method;
            api.PostData = body;

            await this.ForwardRequest(api);
        }


        private async Task ForwardRequest(APIClient api)
        {
            log.LogDebug($"Forwarding request to {api.URL}");
            await api.ExecuteAsync();
            log.LogDebug($"Respsonse from {api.URL}: {api.StatusCode}:{api.StatusDescription}");

            //Copy the status code from the response to this response
            //so it can be returned back to the browser
            this.Response.StatusCode = (int)api.StatusCode;
            await api.HttpResponse.GetResponseStream().CopyToAsync(this.Response.Body);
        }
    }
}
