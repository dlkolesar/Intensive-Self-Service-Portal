using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Intensive.Data.SSDatabase;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Intensive.API.Global
{

    public class IdentityAuthRequirement : IAuthorizationRequirement { }

    public class UserAdminRequirement : IAuthorizationRequirement { }
    public class GroupAdminRequirement : IAuthorizationRequirement { }
    public class ComputerAdminRequirement : IAuthorizationRequirement { }
    public class ContainerAdminRequirement : IAuthorizationRequirement { }


    //Identity info:
    //https://identity-internal.api.rackspacecloud.com/v2.0/tokens
    //https://developer.rackspace.com/docs/cloud-identity/v2/api-reference/token-operations/


    public class IdentityAuthHandler : IAuthorizationHandler
    {
        const string AUTH_HEADER = "X-Auth-Token";
        const string ENCORE_TOKEN_API = "https://identity-internal.api.rackspacecloud.com/v2.0/tokens";
        //const string ENCORE_TOKEN_API = "https://staging.identity-internal.api.rackspacecloud.com/v2.0/tokens";

        ILogger log;
        SSDatabaseContext db;
        HttpContext httpContext;

        public IdentityAuthHandler(ILoggerFactory loggerFactory, SSDatabaseContext ssdb, IHttpContextAccessor hca)
        {
            log = loggerFactory.CreateLogger<IdentityAuthHandler>();
            db = ssdb;
            httpContext = hca.HttpContext;
        }
        
        public Task HandleAsync(AuthorizationHandlerContext context)
        {

            //
            // RackspaceIdentityAuthenticationHandler takes care of validating the X-Auth-Token token
            // and creates and identity with claims on httpContext.User
            //

            HttpRequest request = httpContext.Request;
            ClaimsIdentity ci = httpContext.User.Identities.SingleOrDefault(id => id.AuthenticationType == "RackspaceIdentity");
            if (ci == null) //Authentication failed
            {
                context.Fail(); //no sense doing any other checks
                return Task.CompletedTask;
            }

            List<Claim> claims = ci.Claims.ToList<Claim>();


            //load role-based access roles
            Claim ssoClaim = claims.SingleOrDefault(c => c.Type == "sso");

            if (ssoClaim != null)
            {
                List<Claim> roleClaims = GetUserRoles(ssoClaim.Value);
                if (roleClaims.Count > 0)
                {
                    //claims.AddRange(roleClaims);
                    ci.AddClaims(roleClaims);
                }
            }

             List<IAuthorizationRequirement> pendingRequirements = context.PendingRequirements.ToList();

            foreach (IAuthorizationRequirement req in pendingRequirements)
            {
                log.LogDebug($"  {req.GetType().ToString()}");

                if (req is IdentityAuthRequirement) { context.Succeed(req); }

                if ( (req is UserAdminRequirement) && (httpContext.User.HasClaim(ClaimTypes.Role,"AD_UserAdmin")) )
                {
                    context.Succeed(req);
                }

                if ((req is GroupAdminRequirement) && (httpContext.User.HasClaim(ClaimTypes.Role, "AD_GroupAdmin")))
                {
                    context.Succeed(req);
                }

                if ((req is ContainerAdminRequirement) && (httpContext.User.HasClaim(ClaimTypes.Role, "AD_ContainerAdmin")))
                {
                    context.Succeed(req);
                }

                if ((req is ComputerAdminRequirement) && (httpContext.User.HasClaim(ClaimTypes.Role, "AD_ComputerAdmin")))
                {
                    context.Succeed(req);
                }


            }

            return Task.CompletedTask;
        }

        

        private List<Claim> GetUserRoles(string sso)
        {
            List<Claim> claims = new List<Claim>();

            try
            {
                List<TbUserRole> roles = db.TbUserRole.AsNoTracking().Where(u => u.Member == sso).ToList<TbUserRole>();
                foreach (TbUserRole r in roles)
                {
                    //log.LogDebug($"==> {r.Role}");
                    claims.Add(new Claim(ClaimTypes.Role, r.Role));
                }
            }
            catch (Exception ex)
            {
               log.LogDebug($"[GetUserRoles] Error: {ex}");
            }
            return claims;
        }
    }
}
