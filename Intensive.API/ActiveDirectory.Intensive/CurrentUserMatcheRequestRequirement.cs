using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Intensive.Services.ActiveDirectory;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Intensive.API.Global;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authentication;

namespace ActiveDirectory.Intensive
{
    public class CurrentUserMatchesRequestRequirement : IAuthorizationRequirement
    {
    }

    public class CurrentUserMatchesRequestHandler : AuthorizationHandler<CurrentUserMatchesRequestRequirement>
    {
        const string AUTH_HEADER = "X-Auth-Token";
        const string ENCORE_TOKEN_API = "https://identity-internal.api.rackspacecloud.com/v2.0/tokens";
        //const string ENCORE_TOKEN_API = "https://staging.identity-internal.api.rackspacecloud.com/v2.0/tokens";


        private ILogger<CurrentUserMatchesRequestHandler> log;
        private ActiveDirectoryService ad;
        private AdUser user;

        HttpContext httpContext;

        public CurrentUserMatchesRequestHandler(ILogger<CurrentUserMatchesRequestHandler> logger,
                                        ActiveDirectoryService adsvc,
                                        AdUser aduser, 
                                        IHttpContextAccessor hca)
        {
            ad = adsvc;
            log = logger;
            user = aduser;
            httpContext = hca.HttpContext;
        }
        
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                        CurrentUserMatchesRequestRequirement requirement)
        {
            HttpRequest req = httpContext.Request;
            string currentUserSSO = string.Empty;
            string targetUser = string.Empty;   //userid from the route; i.e., the user that is being modified

            Claim claimSSO = httpContext.User.Claims.FirstOrDefault(c => c.Type == "sso");
            Claim claimToken = httpContext.User.Claims.FirstOrDefault(c => c.Type == "token");

            try
            {
                
                 targetUser = httpContext.GetRouteValue("userid").ToString();

                currentUserSSO = claimSSO.Value;

                string empid = await GetEmployeeIDFromRSAD(currentUserSSO, claimToken.Value);

                ad.Connect();

                //
                // if the AD user that is being modified has the same employeeID
                // as the SSO(represented by the token) that is trying to modify 
                // it are the same "adUsers" should have one and only one item.
                //
                // if "adUsers" is empty, the SSO is not authorized to make the changes
                //

                string ldapFilter = $"(&(employeeid={empid})(samaccountname={targetUser}))";
                List<AdUser> adUsers = user.Find(ad.DirectoryRoot, ldapFilter);

                if (adUsers.Count == 0)
                {
                    log.LogDebug($"[CurrentUserMatchesRequestRequirement] Failed2");
                    return;
                }
                else
                {
                    log.LogDebug($"[CurrentUserMatchesRequestRequirement] End");
                    context.Succeed(requirement);
                    return;
                }
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11006, "Unexpected error during Active Directory API authentication and/or authorization");
                log.LogError(err.ErrorCode, err.FormattedException());
                log.LogDebug($"[CurrentUserMatchesRequestRequirement] Failed3");
            }
        }

        private async Task<string> GetEmployeeIDFromRSAD(string userid, string token)
        {
            APIClient rsad = new APIClient();
            rsad.URL = $"https://api.identity.rackspace.corp/v1.0/ad/user/{userid}";
            rsad.Headers.Add("X-Auth-Token", token);

            await rsad.ExecuteAsync();

            if (rsad.StatusCode == HttpStatusCode.OK)
            {
                string json = rsad.ReadJsonResponse();
                JObject user = JObject.Parse(json);
                return user["data"]["employeeID"].ToString();
            }
            else
            {
                log.LogDebug($"RSAD error: {rsad.StatusCode} {rsad.StatusDescription}");
                return string.Empty;
            }
        }

    }
}
