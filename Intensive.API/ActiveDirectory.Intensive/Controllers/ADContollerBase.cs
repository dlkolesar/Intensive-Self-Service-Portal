using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Intensive.Services.ActiveDirectory;

using Intensive.Services.Auditing;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
using System.Security.Claims;
using System;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Text;
using System.Collections.Generic;

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    public class ADControllerBase : ControllerBase
    {
        protected ILogger log;
        protected ActiveDirectoryService ad;
        protected AuditTrail audit;    
        protected AdSystemConfig config;
        protected const string SYSTEM_NAME = "API.ActiveDirectory";
        protected string CurrentUserSSO;

        //AD LDAP filter examples
        // http://social.technet.microsoft.com/wiki/contents/articles/5392.active-directory-ldap-syntax-filters.aspx

        protected APICollection results = new APICollection();
        protected string resourceURL = string.Empty;
        public ADControllerBase(ILogger logger,
                                ActiveDirectoryService adsvc,
                                IOptions<AdSystemConfig> adconfig,
                                AuditTrail audsvc
                                )
        {
            log = logger;
            ad = adsvc;
            config = adconfig.Value;
            audit = audsvc;
        }

        protected bool IsAuthenticated()
        {
            Claim claim = User.Claims.FirstOrDefault(c => c.Type == "sso");
            CurrentUserSSO = (claim == null) ? null : claim.Value;

            return !string.IsNullOrEmpty(CurrentUserSSO);
        }

        protected string DomainFQDNtoDN(string fqdn)  //convert fqdn to dn, dc=xxx,dc=yyyyyy,dc=zzzzz
        {
            if (string.IsNullOrEmpty(fqdn)) { return string.Empty; }

            string[] path = fqdn.Split(new char[] { '.' });
            string dn = $"DC={string.Join(",DC=", path)}";
            return dn;
        }

        protected string GetDomainFQDN(string dn)   //return the FQDN of the domain where this DN resides
        {
            if (string.IsNullOrEmpty(dn)) { return string.Empty; }

            string[] path = dn.Split(new char[] { ',' });
            string[] parts;
            StringBuilder sb = new StringBuilder();

            foreach (string segment in path)
            {
                parts = segment.Split(new char[] { '=' });
                if (parts[0].ToLower() == "dc")
                {
                    sb.Append(parts[1].ToLower());
                    sb.Append(".");
                }
            }
            sb.Remove(sb.Length - 1, 1); //remove the last .
            return sb.ToString().ToLower();
        }

        protected string GetForestName(string fqdn)    
        {
            log.LogDebug($"[API]GetForestName: {fqdn}");
            string[] path = fqdn.Split(new char[] { '.' });
            int l = path.Length;
            return $"{path[l - 2]}.{path[l - 1]}".ToLower();
        }

        protected string ToDN(string path)
        {
            // convert path to DN
            //   path/to/some/ou ==> OU=ou,OU=some,OU=to,OU=path
            List<string> parts = path.Split(new char[] { '/' }).ToList<string>();
            parts.Reverse();

            string dn = string.Join("OU=", parts.ToArray());
            return dn;
        }
    }
}
