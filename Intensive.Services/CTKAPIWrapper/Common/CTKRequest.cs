using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

using Newtonsoft.Json;


namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// The CTKRequest class provides the properties and methods needed to create and submit a
    /// CTKAPI request to CORE and get teh response back.
    /// </summary>
    internal class CTKRequest
    {
        /// <summary>
        /// The URL of the web endpoint
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// The HTTP Verb, such as GET, POST, DELETE, etc
        /// </summary>
        public string Verb { get; set; }

        /// <summary>
        /// Read-only.  set to "application/json"
        /// </summary>
        public string Content { get { return "application/json"; } }

        /// <summary>
        /// a CORE auth token created by the <see cref="CTKAPI"/> <b>Login</b> method
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The data to be passed to the web endpoint
        /// </summary>
        public object PostData { get; set; }

        /// <summary>
        /// The HTTP Status code returned by the server
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// The text message associcated with the returned StatusCode
        /// </summary>
        public string StatusDescription { get; internal set; }

        private HttpWebRequest HttpRequest;
        private HttpWebResponse HttpResponse;
        private CookieContainer CookieContainer = new CookieContainer();

        /// <summary>
        /// Intializes a new request with default values:
        /// </summary>
        public CTKRequest()
        {
            Verb = "GET";
            PostData = null;
            Token = string.Empty;
            URL = string.Empty;
        }

        /// <summary>
        /// Sends the request to the server
        /// </summary>
        public void Execute()
        {
            if (URL == null)
                throw new ArgumentException("URL cannot be null.");

            HttpRequest = CreateRequest();
            if (HttpRequest == null)
            {
                throw new NullReferenceException("HttpRequest is null");
            }
            if (PostData != null)
            {
                AddPostDataToRequest();
            }

            try
            {
                HttpResponse = (HttpWebResponse)HttpRequest.GetResponse();
            }
            catch (WebException error)
            {
                HttpResponse = (HttpWebResponse)error.Response;
                throw new Exception("WebException caught", error);
            }

            if (HttpResponse == null)
            {
                throw new NullReferenceException("HttpResponse is null");
            }

            StatusCode = HttpResponse.StatusCode;
            StatusDescription = HttpResponse.StatusDescription;
        }

        private HttpWebRequest CreateRequest()
        {
            var basicRequest = (HttpWebRequest)WebRequest.Create(URL);
            basicRequest.ContentType = Content;
            basicRequest.Method = Verb;
            basicRequest.CookieContainer = CookieContainer;
            basicRequest.Timeout = 300000;  //5 minute timeout

            if (!URL.Contains("Auth"))
            {
                basicRequest.Headers.Add("X-Auth", Token);
            }

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


        /// <summary>
        /// Deserializes the returned JSON string into an object
        /// </summary>
        /// <typeparam name="TT">the Object type to return</typeparam>
        /// <returns>a <em>TT</em> object</returns>
        public TT ReadObjectResponse<TT>()
        {
            if (HttpResponse != null)
            {
                return (TT)JsonConvert.DeserializeObject<TT>(ReadJsonResponse());
                //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TT));
                //return (TT)ser.ReadObject(HttpResponse.GetResponseStream());

            }
            return default(TT);
        }

        /// <summary>
        /// returns the raw JSON string that was returned by the request
        /// </summary>
        /// <returns>a string containing the JSON data</returns>
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
