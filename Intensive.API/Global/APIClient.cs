using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Intensive.API.Global
{

    public class APIClient
    {

        public NetworkCredential Credentials { get; set; }
        public string URL { get; set; }
        public string Verb { get; set; }
        public string ContentType{ get; set; }
        public string Accept { get; set; }
        public WebHeaderCollection Headers { get; set;
        }
        public object PostData { get; set; }
        public int Retries { get; set; }
        public HttpStatusCode StatusCode { get; internal set; }
        public string StatusDescription { get; internal set; }

        public HttpWebRequest HttpRequest;
        public HttpWebResponse HttpResponse;

        public APIClient()
        {
            this.Verb = "GET";
            this.PostData = null;
            this.Credentials = null;
            this.ContentType = "application/json";
            this.Accept = "application/json";
            this.Retries = 1;
            this.Headers = new WebHeaderCollection();
        }

        public void Execute(string url, object obj, string verb, int retries)
        {
            this.URL = url;
            this.Verb = verb;
            this.PostData = obj;
            this.Retries = retries;

            this.Execute();
        }

        public void Execute(string url, object obj, string verb)
        {
            this.URL = url;
            this.Verb = verb;
            this.PostData = obj;

            this.Execute();
        }

        public void Execute(string url)
        {
            URL = url;
            this.Execute();
        }

        public void Execute()
        {
            if (URL == null)
                throw new ArgumentException("URL cannot be null.");

            for (int i = 0; i <= this.Retries; i++)
            {
                HttpRequest = CreateRequest();

                if (PostData != null)
                {
                    AddPostDataToRequest();
                }

                HttpRequest.Timeout = 1000 * 60 * 3;  //3 minute timeout
                //Execute the request and Get the response

            
                try
                {
                    HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
                    if (((int)HttpResponse.StatusCode >= 200) && 
                        ((int)HttpResponse.StatusCode < 300))
                    {
                        break;
                    }
                }
                catch (WebException error)
                {
                    HttpResponse = (HttpWebResponse)error.Response;
                }
            }

            if (HttpResponse == null)
            {
                StatusCode = HttpStatusCode.ServiceUnavailable;
                StatusDescription = "HTTP Response is NULL";
            }
            else
            {
                StatusCode = HttpResponse.StatusCode;
                StatusDescription = HttpResponse.StatusDescription;
            }
        }

        public async Task ExecuteAsync()
        {
            if (URL == null)
                throw new ArgumentException("URL cannot be null.");

            for (int i = 0; i <= this.Retries; i++)
            {
                HttpRequest = CreateRequest();

                if (PostData != null)
                {
                    await AddPostDataToRequestAsync();
                }

                HttpRequest.Timeout = 1000 * 60 * 3;  //3 minute timeout
                                                      //Execute the request and Get the response


                try
                {
                    HttpResponse = (HttpWebResponse) await HttpRequest.GetResponseAsync();
                    if (((int)HttpResponse.StatusCode >= 200) &&
                        ((int)HttpResponse.StatusCode < 300))
                    {
                        break;
                    }
                }
                catch (WebException error)
                {
                    HttpResponse = (HttpWebResponse)error.Response;
                }
            }

            if (HttpResponse == null)
            {
                StatusCode = HttpStatusCode.ServiceUnavailable;
                StatusDescription = "HTTP Response is NULL";
            }
            else
            {
                StatusCode = HttpResponse.StatusCode;
                StatusDescription = HttpResponse.StatusDescription;
            }
        }

        private HttpWebRequest CreateRequest()
        {
            //see http://alihamdar.com/2010/06/19/expect-100-continue/
            //
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var basicRequest = (HttpWebRequest)WebRequest.Create(this.URL);
            basicRequest.Headers.Add(this.Headers);
            basicRequest.ContentType = this.ContentType;
            basicRequest.Accept = this.Accept;
            basicRequest.Method = this.Verb;
            basicRequest.CookieContainer = new CookieContainer();
            return basicRequest;
        }

        private void AddPostDataToRequest()
        {
            
            using (var streamWriter = new StreamWriter(HttpRequest.GetRequestStream()))
            {
                if (PostData is string)
                    streamWriter.Write(PostData);
                else
                    streamWriter.Write(JsonConvert.SerializeObject(PostData));
            }
        }

        private async Task AddPostDataToRequestAsync()
        {

            using (var streamWriter = new StreamWriter(await HttpRequest.GetRequestStreamAsync()))
            {
                if (PostData is string)
                    await streamWriter.WriteAsync((string)PostData);
                else
                    await streamWriter.WriteAsync(JsonConvert.SerializeObject(PostData));
            }
        }


        public TT ReadObjectResponse<TT>()
        {
            if (HttpResponse != null)
            {
                return JsonConvert.DeserializeObject<TT>(ReadJsonResponse());
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
        

        public WebHeaderCollection GetHeaders()
        {
            return HttpRequest.Headers;
        }
    }
}
