using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Intensive.Services.CTKAPIWrapper;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Common.Controllers
{
    [Route("core/proxy")]
    public class CoreProxyController : Controller
    {
        HttpWebRequest req;
        HttpWebResponse resp;
        CoreProxyData reqData;

        ILogger<CoreProxyController> log;

        public CoreProxyController(ILogger<CoreProxyController> logger)
        {
            log = logger;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

        }

        [HttpGet]
        public void Get([FromBody]CoreProxyData data)
        {
            reqData = data;

            if (reqData.Url == null) throw new ArgumentException("URL is required.");

            //if (string.IsNullOrEmpty(reqData.Token)) throw new ArgumentException("TOKEN is required.");

            //if (string.IsNullOrEmpty(data.JSONData)) throw new ArgumentException("JSONData is required.");

            ExecuteRequest();
        }



        //may need to think about multi-threading this with ******Async methods and await
        [HttpPost]
        public void Post([FromBody]CoreProxyData data)
        {
            reqData = data;

            if (reqData.Url == null) throw new ArgumentException("URL is required.");

            //if (string.IsNullOrEmpty(reqData.Token)) throw new ArgumentException("TOKEN is required.");

            //if (string.IsNullOrEmpty(data.JSONData)) throw new ArgumentException("JSONData is required.");
            log.LogDebug($"Executing HTTP request....");
            ExecuteRequest();
        }



        private async void ExecuteRequest()
        {
            req = CreateRequest();

            if (reqData.JSONData != null)
            {
                AddPostDataToRequest();
            }

            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException error)
            {
                resp = (HttpWebResponse)error.Response;
                log.LogDebug($"HTTP ERROR: [{ resp.StatusCode}] {resp.StatusDescription} \r\n { error.Message}");
                //log.LogError(999, error, $"HTTP ERROR: {resp.StatusCode} {resp.StatusDescription} \r\n {error.Message} ");
            }

            //Copy the status code from the CORE response to this response
            //so it can be returned back to the browser
            this.Response.StatusCode = (int)resp.StatusCode;

            //copy the data from the CORE response to this
            //response, which is returned to the browser

            await resp.GetResponseStream().CopyToAsync(this.Response.Body);

            

        }

        private HttpWebRequest CreateRequest()
        {
            var basicRequest = (HttpWebRequest)WebRequest.Create(reqData.Url);
            basicRequest.ContentType = "application/json";
            basicRequest.Method = this.Request.Method;
            basicRequest.Timeout = 300000;  //5 minute timeout

            
            if (!string.IsNullOrEmpty(reqData.Token))
            {
                basicRequest.Headers.Add("X-Auth", reqData.Token);
            }

            return basicRequest;
        }

        private void AddPostDataToRequest()
        {
            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                if (reqData.JSONData is string)
                    streamWriter.Write(reqData.JSONData);
                else
                    streamWriter.Write(JsonConvert.SerializeObject(reqData.JSONData));
            }
        }
    }


    public class CoreProxyData
    {
        public string Url { get; set; }
        public string Token { get; set; }
        public object JSONData { get; set; }
    }
}
