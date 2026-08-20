using Intensive.Data.SSDatabase;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Intensive.API.Global
{
    public class RackspaceIdentityAuthenticationHandler: AuthenticationHandler<RackspaceIdentityAuthenticationOptions>
    {
        const string AUTH_HEADER = "X-Auth-Token";
        const string ENCORE_TOKEN_API = "https://identity-internal.api.rackspacecloud.com/v2.0/tokens";
        //const string ENCORE_TOKEN_API = "https://staging.identity-internal.api.rackspacecloud.com/v2.0/tokens";

        ILogger log;
        //HttpContext httpContext;

        public RackspaceIdentityAuthenticationHandler(IOptionsMonitor<RackspaceIdentityAuthenticationOptions> options, 
                                            ILoggerFactory logger, 
                                            UrlEncoder encoder, 
                                            ISystemClock clock)
        : base(options, logger, encoder, clock) 
        {
            this.log = logger.CreateLogger<RackspaceIdentityAuthenticationHandler>();    
        }


        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            AuthenticateResult result;

            if (!Request.Headers.ContainsKey(AUTH_HEADER))
            {
                result = AuthenticateResult.Fail("'X-Auth-Token' header is required with a valid Identity token");
                return Task.FromResult(result);
            }

            // validate token and load claims
            string token = Request.Headers[AUTH_HEADER];
            //IdentityAuthHandler IdentityAuth;

            List<Claim> claims = ValidateEncoreToken(token);

            if (claims.Count == 0)
            {
                //Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                result = AuthenticateResult.Fail("Error validating token in 'X-Auth-Token' header");
                return Task.FromResult(result);
            }

            //has the token expired?
            DateTime expires = DateTime.Parse(claims.Single(c => c.Type == "expires").Value);
            if (DateTime.Now > expires)
            {
                //Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                result = AuthenticateResult.Fail("The token in 'X-Auth-Token' header has expired");
                return Task.FromResult(result);
            }

            ClaimsIdentity claimID = new ClaimsIdentity(claims, "RackspaceIdentity");

            Request.HttpContext.User.AddIdentity(claimID);
            ClaimsIdentity ci = Request.HttpContext.User.Identities
                                            .SingleOrDefault<ClaimsIdentity>(id => id.HasClaim(c => c.Type == "sso"));
            
            //var identities = new List<ClaimsIdentity> { new ClaimsIdentity("RackspaceIdentity") };

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(ci), this.Scheme.Name);

            return Task.FromResult(AuthenticateResult.Success(ticket));

            //return Task.FromResult(
            // AuthenticateResult.Success(
            //    new AuthenticationTicket(
            //        new ClaimsPrincipal(claimID),
            //        new AuthenticationProperties(),
            //        this.Scheme.Name)));
        }

        private List<Claim> ValidateEncoreToken(string token)
        {
            //string userid = string.Empty;
            WebClient client = new WebClient();
            client.Headers.Add(AUTH_HEADER, token);
            List<Claim> claims = new List<Claim>();

            try
            {
                string json = client.DownloadString($"{ENCORE_TOKEN_API}/{token}");
                //log.LogDebug($"[IdentityAuthRequirement]Identity Response: {json}");
                JObject jo = JObject.Parse(json);

                claims = new List<Claim>()
                        {
                            new Claim("sso", jo["access"]["user"]["name"].ToString() ),
                            new Claim("token", jo["access"]["token"]["id"].ToString() ),
                            new Claim("expires", jo["access"]["token"]["expires"].ToString())
                        };

                JArray ja = (JArray)jo["access"]["user"]["roles"];
                foreach (JObject jRole in ja)
                {
                    claims.Add(new Claim(ClaimTypes.Role, jRole["name"].ToString()));
                }

            }
            catch (WebException ex)
            {
                //userid = string.Empty;
                log.LogDebug($"[IdentityAuthRequirement]ValidateEncoreToken Error: {ex}");
            }
            return claims;
        }
    }
}
