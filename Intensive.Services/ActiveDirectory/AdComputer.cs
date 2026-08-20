using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Intensive.Services.ActiveDirectory
{
    public class AdComputer: AdObject
    {
        public bool Enabled { get; set; }

        private static List<string> DefaultComputerAttributes = new List<string>()
                                 { "userAccountControl"};
        private string ldapFilter = string.Empty;

        const int ADS_UF_ACCOUNT_DISABLE = 0x0002;
        const int ADS_UF_COMPUTER_ACCOUNT = 0x1000;
   

        public AdComputer(ILogger<AdComputer> logger, IOptions<AdSystemConfig> adconfig) :base(logger, adconfig)
        {
            DefaultAttributes.AddRange(DefaultComputerAttributes);//merge default object attributes with default computer attributes
        }
        public AdComputer()
        {
            DefaultAttributes.AddRange(DefaultComputerAttributes);//merge default object attributes with default computer attributes
        }


        public void Load(DirectoryEntry root, string name)
        {
            this.Load(root, name, DefaultAttributes);
        }

        public void Load(DirectoryEntry root, string name, List<string> attributes)
        {
            ldapFilter = $"(&(objectclass=computer)(name={name}))"; 

            //log.LogDebug($"attributes b4   : {JsonConvert.SerializeObject(attributes)}");
            attributes = attributes.Union(DefaultAttributes).ToList<string>();    //merge default attributes with user-provided attributes
            //log.LogDebug($"attributes after: {JsonConvert.SerializeObject(attributes)}");

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            GetComputer(ds);
            ds.Dispose();
        }

        public new void LoadDN(DirectoryEntry root, string dn)
        {
            this.LoadDN(root, dn, DefaultAttributes);
        }

        public new void LoadDN(DirectoryEntry root, string dn, List<string> attributes)     //"new" overrides the LoadDN() method inherited from AdObject
        {
            string ldapFilter = $"(distinguishedname={dn})";

            log.LogDebug($"attributes b4   : {JsonConvert.SerializeObject(attributes)}");
            attributes = attributes.Union(DefaultAttributes).ToList<string>();    //merge default attributes with user-provided attributes
            log.LogDebug($"attributes after: {JsonConvert.SerializeObject(attributes)}");

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            GetComputer(ds);
            ds.Dispose();
        }

        public void Create(DirectoryEntry root, string name, bool enabled=true)
        {
            if (DirectoryEntry.Exists(root.Path))
            {
                this.ObjectEntry = root.Children.Add($"CN={name}", "Computer");
                
                int flags = (enabled) ? ADS_UF_COMPUTER_ACCOUNT : ADS_UF_COMPUTER_ACCOUNT| ADS_UF_ACCOUNT_DISABLE;

                this.ObjectEntry.Properties["userAccountControl"].Value = flags;
                this.ObjectEntry.Properties["sAMAccountName"].Value = $"{name}$";
                this.ObjectEntry.CommitChanges();
                this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());

                StringCollection sc = new StringCollection();
                sc.AddRange(DefaultAttributes.ToArray());
                this.LoadObjectProperties(sc);
            }
            else
            {
                throw new ADNotFoundException($"parent root does not exist or has not been loaded");
            }
        }



        public void Delete()
        {
            if (DirectoryEntry.Exists(this.ObjectEntry.Path))
            {
                this.ObjectEntry.DeleteTree();
            }
            else
            {
                throw new ADNotFoundException($"Computer object does not exist");
            }

        }



        public new List<AdComputer> Find(DirectoryEntry root, string ldapFilter)
        {
            DirectorySearcher ds = new DirectorySearcher();
            string computerFilter = "(objectclass=computer)";
            try
            {
                List<AdComputer> lst = new List<AdComputer>();
                AdComputer computer = new AdComputer();
                ldapFilter = $"(&({ldapFilter})({computerFilter}))";
                ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());
                ds.SearchScope = SearchScope.Subtree;
                ds.ReferralChasing = ReferralChasingOption.All;

                SearchResultCollection results = ds.FindAll();
                foreach (SearchResult sr in results)
                {
                    computer = new AdComputer();
                    computer.ObjectEntry = sr.GetDirectoryEntry();
                    
                    computer.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());


                    //log.LogDebug("Loading properties....");
                    computer.LoadObjectProperties(ds.PropertiesToLoad);

                    //log.LogDebug($"uac={computer.GetProperty("userAccountControl")}");

                    int flags = Convert.ToInt32(computer.GetProperty("userAccountControl"));
                    computer.Enabled = (flags & ADS_UF_ACCOUNT_DISABLE) != ADS_UF_ACCOUNT_DISABLE;

                    //log.LogDebug($"computer: {JsonConvert.SerializeObject(computer)}");
                    //log.LogDebug($"sr.properties: {JsonConvert.SerializeObject(sr.Properties.PropertyNames)}");
                    //log.LogDebug($"object.properties: {JsonConvert.SerializeObject(computer.ObjectEntry.Properties.PropertyNames)}");
                    lst.Add(computer);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ds.Dispose();
            }
        }

       
      

        private void GetComputer(DirectorySearcher ds)
        {
            if (ds == null) { throw new ArgumentNullException("ds", "Directory Searcher object is null"); }
            ds.SearchScope = SearchScope.Subtree;
            ds.ReferralChasing = ReferralChasingOption.All;

            //log.LogDebug($"ds.properties: {JsonConvert.SerializeObject(ds.PropertiesToLoad)}");

            SearchResult sr = ds.FindOne();
            if (sr == null)
            {
                throw new ADNotFoundException($"No Active Directory objects found that match '{ds.Filter}'");
            }

            this.ObjectEntry = sr.GetDirectoryEntry();
            if (this.ObjectEntry == null)
            {
                throw new ADNotFoundException($"No Active Directory entries found that match '{ds.Filter}'");
            }
            string[] attrs = new string[sr.Properties.PropertyNames.Count];

            sr.Properties.PropertyNames.CopyTo(attrs, 0);
            this.ObjectEntry.RefreshCache(attrs);

            //log.LogDebug($"    sr.properties: {JsonConvert.SerializeObject(sr.Properties.PropertyNames)}");
            //log.LogDebug($"object.properties: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)}");
            this.LoadObjectProperties(ds.PropertiesToLoad);

            int flags = Convert.ToInt32(GetProperty("userAccountControl"));
            //log.LogDebug($"UserAccountControl: {flags}");
            this.Enabled = (flags & ADS_UF_ACCOUNT_DISABLE) != ADS_UF_ACCOUNT_DISABLE;
        }


        //public void Save()
        //{
        //    UserEntry.RefreshCache(DefaultComputerAttributes.ToArray());

        //    int currentFlags = Convert.ToInt32(UserEntry.Properties["useraccountcontrol"].Value);
        //    bool currEnabled = (currentFlags & ADS_UF_ACCOUNT_DISABLE) != ADS_UF_ACCOUNT_DISABLE;

        //    if (this.Enabled != currEnabled)    //is enabled value being modified?
        //    {
        //        currentFlags = currentFlags ^ ADS_UF_ACCOUNT_DISABLE; //XOR to toggle the enabled bit
        //    }

        //    this.ObjectEntry.Properties["useraccountcontrol"].Value = currentFlags;

        //    //copy temp values from the Attributes property
        //    //to the DirectoryEntry for the user

        //    log.LogDebug($"updating attributes...");
        //    foreach (string a in this.Attributes.Keys)
        //    {
        //        log.LogDebug($"   =>[{a}]");
        //        try
        //        {
        //            if (this.ObjectEntry.Properties[a].Value != this.Attributes[a])
        //            {
        //                this.ObjectEntry.Properties[a].Value = this.Attributes[a];
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new ArgumentException($"User attribute '{a}' cannot be modified: {ex.Message}", ex);
        //        }
        //    }
        //    log.LogDebug($"Commiting Directory Entry Changes");
        //    this.ObjectEntry.CommitChanges();
        //}

    }
}
