using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Intensive.Services.CTKAPIWrapper.CTKObjects;
using Intensive.Services.CTKAPIWrapper.Exceptions;


namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    ///Intensive.Services.CTKAPIWrapper Library is a set of .NET "wrapper" classes that make it easier for .NET applications
    /// to communicate with CORE using the CTKAPI web endpoints.  Classes within theIntensive.Services.CTKAPIWrapper namespace
    /// are provide "low-level" functionality to build a request or an action, 
    /// submit it to the CORE CTKAPI endpoint and perform some basic formatting of the returned data.
    /// </summary>
    internal static class NamespaceDoc { }    //dummy class used to generate Namespace documentation


    /// <summary>
    /// The CTKAPI class is the primary class used to communicate with CORE.  It contains methods to connect to and submit
    /// requests to the CORE environment
    /// </summary>
    public class CTKAPI
    {
        private string URL_BASE = "https://ws.core.rackspace.com";
        private string LOGIN_URL = string.Empty;
        private string LOGOUT_URL = string.Empty;
        private string SESSION_URL = string.Empty;
        private string QUERY_URL = string.Empty;

        private string _token;
        private string _credsU;
        private string _credsP; //can't use the 'p'-word as a variable name because Checkmarx will flag it


        /// <summary>
        /// the CORE token generated when the connection to CORE was established
        /// 
        /// </summary>
        /// <remarks>
        /// <para>When the CTKAPI constructor is called, with login parameters, or the login method is called,
        /// a token is generated for the userid/pwd provided and is stored in this property.
        /// </para>
        /// <para>
        /// If your code sets the Token property to a different token, this will effectively "switch"
        /// the user that was connected to CORE to be the user associated with the new token, and this new token
        /// will be used for all subsequent calls to CTKAPI.Net methods
        /// </para>
        /// </remarks>
        public string Token { get { return _token; } set { _token = value; } }

        /// <summary>
        /// The base FQDN of the CORE CTKAPI 
        /// </summary>
        public string BaseURL {
            get { return URL_BASE; }
            set {
                URL_BASE = value;
                InitURLs();
            }
        }

        /// <summary>
        /// returns information about the user associated with the current Token
        /// </summary>
        public CTKUser CurrentUser
        {
            get { return GetUser(_token);  }
        }


        /// <summary>
        /// Creates a new instance, targeting all calls to an alternate CORE environment
        /// </summary>

        public CTKAPI()
        {
           
        }


        /// <summary>
        /// Creates a new instance, targeting all calls to an alternate CORE environment
        /// </summary>
        /// <param name="coreURL">the full URL to the CORE environment, e.g. "https://staging.core.rackspace.com" for the CORE Staging environment </param>
        public CTKAPI(string coreURL)
        {
            URL_BASE = coreURL;
            InitURLs();
        }

        /// <summary>
        /// Creates a new instance, logging into CORE with the provided userid and password
        /// </summary>
        /// <remarks>
        /// By default, this constructor will connect to the Production CORE environment.  To connect to the CORE Dev or 
        /// Staging environment, use the alternate constructor -- CTKAPI(string coreURL, string userid, string password)
        /// </remarks>
        /// <param name="userid">core User ID</param>
        /// <param name="password">core User Password</param>
        public CTKAPI(string userid, string password)
        {
            InitURLs();
            Login(userid, password);
            Logout();
        }

        /// <summary>
        /// Creates a new instance, targeting all calls to an alternate CORE environment and logging into CORE with the provided userid and password
        /// </summary>
        /// <param name="coreURL">the full URL to the CORE environment, e.g. "https://staging.core.rackspace.com" for the CORE Staging environment </param>
        /// <param name="userid">core User ID</param>
        /// <param name="password">core User Password</param>
        public CTKAPI(string coreURL, string userid, string password)
        {
            URL_BASE = coreURL;
            InitURLs();
            Login(userid, password);
        }


        public void Login(string userid, string passcode)
        {
            //InitURLs();

            CTKRequest req = new CTKRequest();
            req.URL = string.Format(LOGIN_URL, userid);
            string pwdObj = "{\"password\":\"" + passcode + "\"}";
            req.PostData = pwdObj;
            req.Verb = "POST";

            req.Execute();
            if (req.StatusCode != HttpStatusCode.OK)
            {
                Exception ex = new Exception(req.StatusDescription);
                throw ex;
            }

            string json = req.ReadJsonResponse();
            var def = new { authtoken = "" };
            var objToken = JsonConvert.DeserializeAnonymousType(json, def);
            _token = objToken.authtoken;

            //save creds for re-auth when token expires
            _credsU = userid;
            _credsP = passcode;
            //return objToken.authtoken;
        }

        /// <summary>
        /// Terminates the current CORE Session and invalidates the associated token
        /// </summary>
        public void Logout()
        {
            this.Logout(this.Token);
        }

        /// <summary>
        /// Terminates the CORE Session and invalidates the provided token
        /// </summary>
        /// <param name="token">a CORE auth token</param>
        public void Logout(string token)
        {
            CTKRequest req = new CTKRequest();
            req.URL = string.Format(LOGOUT_URL, token);
            req.PostData = null;
            req.Verb = "GET";
            req.Execute();
            if (req.StatusCode != HttpStatusCode.OK)
            {
                Exception ex = new Exception(req.StatusDescription);
                throw ex;
            }
        }


        /// <summary>
        /// Validates the given token and returns information about the Production CORE user associated with that token
        /// </summary>
        /// <param name="token">a CORE auth token created by the <b>Login</b> method</param>
        /// <returns>a <see cref="CTKUser"/> object</returns>
        /// <example>
        ///     <code>
        ///         CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///         string newToken = "0c7fb9aca7bdd2e77207762f878b01d2";
        ///         CTKUser u = core.GetUser(newToken);
        ///         Console.Write("Name=>" + u.UserName);
        ///         Console.Write("Contact ID=>" + u.ContactID);
        ///         Console.Write("Employee ID=>" + u.EmployeeID);
        ///
        ///         //Output
        ///         Name=>joe.racker
        ///         Contact ID=>1234
        ///         Employee ID=>654321
        ///     </code>
        /// </example>
        /// 
        private CTKUser GetUser(string token)
        {
            CTKRequest req = new CTKRequest();
            req.URL = string.Format(SESSION_URL, token);
            req.PostData = null;
            req.Verb = "GET";
            req.Execute();
            if (req.StatusCode != HttpStatusCode.OK)
            {
                Exception ex = new Exception(req.StatusDescription);
                throw ex;
            }

            CTKUser user = req.ReadObjectResponse<CTKUser>();

            return user;
        }


        /// <summary>
        /// Submit the request to CORE
        /// </summary>
        /// <param name="qry">a <see cref=" CTKQuery"/> object</param>
        /// <returns>a <see cref="CTKResponse"/> object containing the results and status of the query</returns>
        public CTKResponse Submit(CTKQuery qry)
        {
            if (!this.CurrentUser.valid)
            {
                this.Login(_credsU, _credsP);
            }
            CTKResponse resp = new CTKResponse();
        
            CTKRequest req = new CTKRequest();
            req.URL = QUERY_URL;
            req.PostData = qry.ToString();
            req.Verb = "POST";
            req.Token = _token;
            req.Execute();
            string json = req.ReadJsonResponse();

            resp.StatusCode = (int)req.StatusCode;

            if (req.StatusCode == HttpStatusCode.OK)
            {
                JArray ja = JArray.Parse(json);
                resp.jsonResult = ja[0]["result"].ToString();
                resp.Count = Convert.ToInt32(ja[0]["count"].ToString());
                
                if (resp.Count > 0)
                {
                    JToken j = (ja[0]["result"].Type == JTokenType.Array) ? ja[0]["result"][0] : ja[0]["result"];

                    if (j.Type == JTokenType.Array)
                    {
                        resp.Results = JsonConvert.DeserializeObject<CTKResultTuple>(resp.jsonResult);
                    }
                    else
                    {
                        resp.Results = JsonConvert.DeserializeObject<CTKResultDictionary>(resp.jsonResult);
                    }

                }
            }
            else
            {
                ThrowException(req.StatusCode, req.StatusDescription, json);
            }

            return resp;
        }

        public CTKResponse Submit(string jsonRequest)
        {
            if (!this.CurrentUser.valid)
            {
                this.Login(_credsU, _credsP);
            }
            CTKResponse resp = new CTKResponse();

            CTKRequest req = new CTKRequest();
            req.URL = QUERY_URL;
            req.PostData = jsonRequest;
            req.Verb = "POST";
            req.Token = _token;
            req.Execute();
            string json = req.ReadJsonResponse();

            resp.StatusCode = (int)req.StatusCode;

            if (req.StatusCode == HttpStatusCode.OK)
            {
                JArray ja = JArray.Parse(json);
                resp.jsonResult = ja[0]["result"].ToString();
                resp.Count = Convert.ToInt32(ja[0]["count"].ToString());

                JToken j = (ja[0]["result"].Type == JTokenType.Array) ? ja[0]["result"][0] : ja[0]["result"];

                if (j.Type == JTokenType.Array)
                {
                    resp.Results = JsonConvert.DeserializeObject<CTKResultTuple>(resp.jsonResult);
                }
                else
                {
                    resp.Results = JsonConvert.DeserializeObject<CTKResultDictionary>(resp.jsonResult);
                }
            }
            else
            {
                ThrowException(req.StatusCode, req.StatusDescription, json);
            }
            return resp;
        }


        ///
        /// <summary>
        /// Submit the request to CORE
        /// </summary>
        /// <param name="action">a <see cref=" CTKAction"/> object</param>
        /// <returns>a <see cref="CTKActionResponse"/> object containing the results and status of the query</returns>
        public CTKActionResponse Submit(CTKAction action)
        {
            if (!this.CurrentUser.valid)
            {
                this.Login(_credsU, _credsP);
            }
            CTKActionResponse resp = new CTKActionResponse();

            CTKRequest req = new CTKRequest();
            req.URL = QUERY_URL;
            req.PostData = action.ToString();
            req.Verb = "POST";
            req.Token = _token;
            req.Execute();
            
            string json = req.ReadJsonResponse();


            if (req.StatusCode == HttpStatusCode.OK)
            {
                JArray ja = JArray.Parse(json);
                //resp.Success = ja[0]["success"].ToString().ToLower() == "true";
                resp.Success = req.PostData.ToString().ToLower().Contains("set_attribute") ? true : ja[0]["success"].ToString().ToLower() == "true";
                resp.ErrorMessage = (resp.Success) ? string.Empty : ja[0]["result"].ToString();
                resp.jsonResult = ja[0]["result"].ToString();
                resp.Count = Convert.ToInt32(ja[0]["count"].ToString());
                if (resp.jsonResult.StartsWith("{"))
                {
                    resp.jsonResult = "[" + resp.jsonResult + "]";
                }
                //resp.Results = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(resp.jsonResult);


                //JToken j = ja[0]["result"][0];
                JToken j = (ja[0]["result"].Type == JTokenType.Array) ? ja[0]["result"][0] : ja[0]["result"];

                if (j.Type == JTokenType.Array)
                {
                    resp.Results = JsonConvert.DeserializeObject<CTKResultTuple>(resp.jsonResult);
                }
                else
                {
                    resp.Results = JsonConvert.DeserializeObject<CTKResultDictionary>(resp.jsonResult);
                }


                
 
            }
            else
            {
                ThrowException(req.StatusCode, req.StatusDescription, json);
            }
            

            return resp;

        }

        ///
        /// <summary>
        /// Submit the request to CORE
        /// </summary>
        /// <param name="action">a <see cref=" CTKAction"/> object</param>
        /// <param name="args">a comma separated list of parameters to be passed to the method being invoked</param>
        /// <returns>a <see cref="CTKActionResponse"/> object containing the results and status of the query</returns>
        public CTKActionResponse Submit(CTKAction action, params object[] args)
        {
            foreach (object o in args)
            {
                action.MethodArguments.Add(o);
            }
            return Submit(action);
        }




        private void InitURLs()
        {
            LOGIN_URL = URL_BASE + "/ctkapi/login/{0}";
            LOGOUT_URL = URL_BASE + "/ctkapi/logout/{0}";
            SESSION_URL = URL_BASE + "/ctkapi/session/{0}";
            QUERY_URL = URL_BASE + "/ctkapi/query";
        }

        private void ThrowException(HttpStatusCode httpStatus, string httpDescription, string json)
        {
            //parse returned json into httpstatuscode, httpstatusdescription, and errormessage
            JObject jo = JObject.Parse(json);
            string msg = jo["error_message"].ToString();

            switch(httpStatus)
            {
                case HttpStatusCode.BadRequest:
                        CTKInvalidRequestException ex400 = new CTKInvalidRequestException(msg);
                        ex400.HttpStatus = httpStatus;
                        ex400.HttpStatusDescription = httpDescription;
                        throw ex400;
                    
                case HttpStatusCode.Forbidden:
                        CTKAuthenticationException ex403 = new CTKAuthenticationException(msg);
                        ex403.HttpStatus = httpStatus;
                        ex403.HttpStatusDescription = httpDescription;
                        throw ex403;

                case HttpStatusCode.NotFound:
                        CTKNotFoundException ex404 = new CTKNotFoundException(msg);
                        ex404.HttpStatus = httpStatus;
                        ex404.HttpStatusDescription = httpDescription;
                        throw ex404;

                case HttpStatusCode.InternalServerError:
                        CTKServerException ex500 = new CTKServerException(msg);
                        ex500.HttpStatus = httpStatus;
                        ex500.HttpStatusDescription = httpDescription;
                        throw ex500;

                case HttpStatusCode.ServiceUnavailable:
                        CTKThrottleException ex503 = new CTKThrottleException(msg);
                        ex503.HttpStatus = httpStatus;
                        ex503.HttpStatusDescription = httpDescription;
                        throw ex503;

            }//switch
        }//throwerror

    }
}
