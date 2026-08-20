using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Intensive.Services.ActiveDirectory
{
    public class AdDomain: AdObject
    {
        public string FQDN { get; set; }    //fqdn will be set by the API 
        //public string Name { get; set; }    //name will be set by the API
        public List<string> Sites { get; set; }

        //ILogger<AdDomain> log;
        //AdSystemConfig config;

        public AdDomain(ILogger<AdDomain> logger,
                        IOptions<AdSystemConfig> adconfig) :base(logger, adconfig)
        {
            log = logger;
            config = adconfig.Value;
        }


        public void Load(DirectoryContext ctx)
        {
            try
            {
                Domain Dom = Domain.GetDomain(ctx);
                this.Name = config.DomainName;
                this.DisplayName = Dom.Name;
                this.FQDN = config.DomainFQDN;
                this.DN = "DC=" + this.FQDN.Replace(".", ",DC=");
                this.Sites = new List<string>();
                foreach (ActiveDirectorySite s in Dom.Forest.Sites)
                {
                    this.Sites.Add(s.Name);
                }
                Dom.Dispose();
            }
            catch(ActiveDirectoryObjectNotFoundException nf)
            {
                throw new ADNotFoundException("Error Getting Domain", nf);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
