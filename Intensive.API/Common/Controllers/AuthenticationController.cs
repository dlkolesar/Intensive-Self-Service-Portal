using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Microsoft.Net.Http.Headers;

using Intensive.API.Global;
using Intensive.Services.Common;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

using System.IO.Compression;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.Common.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        protected ILogger<AuthenticationController> log;
        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            log = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                string saml64 = Request.Form["SAMLResponse"];
                string relay = Request.Form["RelayState"];

                log.LogDebug($"SAMLResponse: {saml64}");
                log.LogDebug($"RelayState: {relay}");


                //send the encoded saml response over to Identity service to get
                //a token.  This token will be used in subsequent API calls

                string json = await GetIdentity(saml64);

                //parse the response and extract the token
                JObject jo = JObject.Parse(json);
                string token = jo["access"]["token"]["id"].ToString();



                // Add sso Claims here
                //  does App Pool timeout/recycle drop the claim?



                string redir = String.IsNullOrEmpty(relay) ? "/" : relay;



                //redirect the browser session to the auth page, which
                //will store the auth data in the browser's local storage
                //cache and then redirect to [redir]

                //parse relay for base url to generate new redirect
                Uri url = new Uri(relay);
                string newURL = $"https://{url.Host}/auth?relaystate={redir}&token={token}";

                log.LogDebug($"Redirecting to {newURL}");
                return new RedirectResult(newURL);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet("{token}")]
        public async Task<string> Get(string token)
        {
            string url = $"https://identity-internal.api.rackspacecloud.com/v2.0/tokens/{token}";
            HttpClient http = new HttpClient();

            http.DefaultRequestHeaders.Add("X-Auth-Token", token);
            HttpResponseMessage resp = await http.GetAsync(url);
            string json = await resp.Content.ReadAsStringAsync();
            return json;
        }

        [Authorize(Policy = "TokenRequired", AuthenticationSchemes = "RackspaceIdentityHandler")]   
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles(string token)
        {

            List<string> roles = new List<string>();
            
            foreach (Claim claim in User.Claims.Where( c => c.Type == ClaimTypes.Role))
            {
                roles.Add(claim.Value);
            }
            return Ok(roles);
        }

       

        //docs: https://pages.github.rackspace.com/ServiceAPIContracts/global-auth-keystone-extensions/api-reference/token-operations.html

        private async Task<string> GetIdentity(string saml64)
        {
            log.LogDebug("Getting Identity Token......");
            string url = "https://identity-internal.api.rackspacecloud.com/v2.0/RAX-AUTH/federation/saml/auth/";
            HttpClient http = new HttpClient();

            FormUrlEncodedContent body = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                                                                        new KeyValuePair<string, string>("SAMLResponse", saml64) }
                                                                  );
            body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            HttpResponseMessage resp = await http.PostAsync(url, body);


            string json = resp.Content.ReadAsStringAsync().Result;
            log.LogDebug($"Identity Response: {json}");
            return json;
        }
    }
}
