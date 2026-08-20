using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Intensive.Services.ActiveDirectory
{
    public class ActiveDirectoryService : IDisposable
    {
        //public string ConnectedServer { get; internal set; }
        public DirectoryContext DomainContext { get; internal set; }
        public DirectoryEntry DirectoryRoot { get; internal set; }
        public AdSystemConfig Config { get; internal set; }

        

        ILogger log;
        string domainName;

        public ActiveDirectoryService(ILogger<ActiveDirectoryService> logger,
                                      IOptions<AdSystemConfig> adconfig
                                     )
        {
            this.DomainContext = null;
            this.DirectoryRoot = null;
            this.log = logger;
            this.Config = adconfig.Value;
            
            domainName = this.Config.DomainFQDN;
        }

        public void Connect()
        {
            this.DomainContext = new DirectoryContext(DirectoryContextType.Domain, domainName);

            log.LogDebug($"Connecting to LDAP://{ FQDN2DN(domainName)}...");
            this.DirectoryRoot = new DirectoryEntry($"LDAP://{ FQDN2DN(domainName)}");
            
            if (!DirectoryEntry.Exists(this.DirectoryRoot.Path))
            {
                throw new ADNotFoundException($"'{this.DirectoryRoot.Path}' does not exist");
            }
        }


        //public void Connect(string domainName)
        //{
        //    try
        //    { 
        //    this.DomainContext = new DirectoryContext(DirectoryContextType.Domain, domainName);
        //    this.DirectoryRoot = new DirectoryEntry($"LDAP://{ FQDN2DN(domainName)}");
        //    Domain dom = Domain.GetDomain(this.DomainContext);
        //    this.ConnectedServer = dom.Name;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ADConnectionException("Error connecting to AD", ex);
        //    }
        //}

        //public ActiveDirectoryService(string domainName, string siteName)
        //public void Connect(string domainName, string siteName)
        public void Connect(string siteName)
        {
            log.LogDebug($"Connecting to AD site {siteName}...");
            this.DomainContext = ConnectToSiteDomainController(siteName, null);
            if (!DirectoryEntry.Exists(this.DirectoryRoot.Path))
            {
                throw new ADNotFoundException($"'{this.DirectoryRoot.Path}' does not exist");
            }
        }

        //public void Connect(string domainName, string ouPath, string siteName = null)
        public void Connect(string ouPath, string siteName = null)
        {

            if (string.IsNullOrEmpty(siteName))
            {
                this.DomainContext = new DirectoryContext(DirectoryContextType.Domain, domainName);
                //this.DirectoryRoot = new DirectoryEntry($"LDAP://{ouPath},{ FQDN2DN(domainName) }");
                log.LogDebug($"Connecting to LDAP://{ouPath}...");
                this.DirectoryRoot = new DirectoryEntry($"LDAP://{ouPath}");
            }
            else
            {
                
                this.DomainContext = ConnectToSiteDomainController( siteName, ouPath);
            }

            if (!DirectoryEntry.Exists(this.DirectoryRoot.Path))
            {
                throw new ADNotFoundException($"'{this.DirectoryRoot.Path}' does not exist");
            }
        }


        private DirectoryContext ConnectToSiteDomainController(string site, string ouPath)
        {
            DirectoryContext dc = null;
            DirectoryContext ctx = new DirectoryContext(DirectoryContextType.Domain, domainName);
            DomainControllerCollection dcList = DomainController.FindAll(ctx, site);
            foreach (DomainController d in dcList)
            {
                try
                {
                    if (string.IsNullOrEmpty(ouPath))
                    {
                        dc = new DirectoryContext(DirectoryContextType.DirectoryServer, d.Name);
                        log.LogDebug($"Connecting to LDAP://{FQDN2DN(domainName)} ...");
                        this.DirectoryRoot = new DirectoryEntry($"LDAP://{ FQDN2DN(domainName) }");
                    }
                    else
                    {
                        dc = new DirectoryContext(DirectoryContextType.DirectoryServer, d.Name);
                        log.LogDebug($"Connecting to LDAP://{ouPath}...");
                        this.DirectoryRoot = new DirectoryEntry($"LDAP://{ouPath}");
                    }
                    return dc;
                }
                catch(Exception ex)
                {
                    continue;
                }
            }
            throw new PrincipalServerDownException($"Unable to connect to a domain controller in site {site}");

        }


        

        private string FQDN2DN(string fqdn)
        {
            return "DC=" + fqdn.Replace(".", ",DC=");
        }




        public void Dispose()
        {
            this.DirectoryRoot?.Close();    // close if not null
            this.DirectoryRoot?.Dispose();  // dispose if not null
        }
    }
}
