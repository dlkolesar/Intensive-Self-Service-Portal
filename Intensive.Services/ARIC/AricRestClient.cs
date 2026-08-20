using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Intensive.Services.Aric
{
    public class AricRestClient
    {
        public string URL { get; set; }
        public string Verb { get; set; }
        public string Content { get { return "application/json"; } }
        public string Token { get; set; }
        public object PostData { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string UserAgent { get; set; }

        private HttpWebRequest HttpRequest;
        private HttpWebResponse HttpResponse;
        private CookieContainer CookieContainer = new CookieContainer();

        public AricRestClient()
        {
            Verb = "GET";
            PostData = null;
            Token = string.Empty;
            URL = string.Empty;
            UserAgent = "Segment Support Self Service";
        }

        public void Submit()
        {
            if (URL == null)
                throw new ArgumentException("URL cannot be null.");

            HttpRequest = CreateRequest();

            if (PostData != null)
            {
                AddPostDataToRequest();
            }
            try
            {
                HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
                if (HttpResponse == null)
                {
                    StatusCode = HttpStatusCode.InternalServerError;
                    StatusDescription = "HTTP Response was null";
                }
            }
            catch (WebException wex)
            {
                HttpResponse = (HttpWebResponse)wex.Response;
                if (HttpResponse == null) { throw; }
            }

            StatusCode = HttpResponse.StatusCode;
            StatusDescription = HttpResponse.StatusDescription;
        }

        private HttpWebRequest CreateRequest()
        {

            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var basicRequest = (HttpWebRequest)WebRequest.Create(URL);
            basicRequest.ContentType = Content;
            basicRequest.Method = Verb;
            basicRequest.CookieContainer = CookieContainer;
            basicRequest.Timeout = 300000;  //5 minute timeout

            basicRequest.Headers.Add("X-Auth-Token", Token);

            return basicRequest;
        }

        private void AddPostDataToRequest()
        {
            this.Verb = "POST";

            using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
            {
                if (PostData is string)
                    streamWriter.Write(PostData);
                else
                    streamWriter.Write(JsonConvert.SerializeObject(PostData));
            }
        }


        public TT ReadObjectResponse<TT>()
        {
            if (HttpResponse != null)
            {
                return (TT)JsonConvert.DeserializeObject<TT>(ReadJsonResponse());
            }

            return default(TT);
        }
        public string ReadJsonResponse()
        {
            StreamReader streamReader = new StreamReader(HttpResponse.GetResponseStream());
            string json = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader.Dispose();
            return json;
        }
    }
}
