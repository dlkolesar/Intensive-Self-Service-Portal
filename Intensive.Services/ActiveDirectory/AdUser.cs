using System;
using System.Linq;
using System.Collections.Generic;
using System.DirectoryServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Intensive.Services.ActiveDirectory
{
    public class AdUser : AdObject
    {
        private static List<string> DefaultUserAttributes = new List<string>()
                                 { "sAMAccountName","givenName","sn", "userAccountControl" , "msDS-User-Account-Control-Computed"};

        private static List<string> ReadOnlyUserAttributes = new List<string>()
                                 { "memberOf","employeeID","objectSid", "userAccountControl","msDS-User-Account-Control-Computed"};

        private string ldapFilter = string.Empty;

        const int ADS_UF_ACCOUNT_DISABLE  = 0x0002;  
        const int ADS_UF_LOCKOUT =          0x0010;
        const int ADS_UF_NORMAL_ACCOUNT = 0x0200;
        const int ADS_UF_PASSWORD_EXPIRED = 0x800000;   //read-only flag set by AD; cannot be set via code;  set properties["pwdLastSet"] = 1 to "expire" the pwd
        const int ADS_UF_DONT_EXPIRE_PASSWORD = 0x10000;
        const int ADS_UF_PASSWD_NOTREQD = 0x0020;

        public string UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public bool Enabled { get; set; }
        public bool LockedOut { get; set; }


        public AdUser(ILogger<AdUser> logger, IOptions<AdSystemConfig> adconfig) :base(logger, adconfig)
        {
            DefaultAttributes.AddRange(DefaultUserAttributes);//merge default object attributes with default user attributes
        }
        public AdUser() {
            DefaultAttributes.AddRange(DefaultUserAttributes);//merge default object attributes with default user attributes
        }


        public void Load(DirectoryEntry root, string userid)
        {
            //ldapFilter = $"(samaccountname={userid})";
            //DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());
            //GetUser(ds);
            //ds.Dispose();

            Load(root, userid, DefaultAttributes);
        }

        public void Load(DirectoryEntry root, string userid, List<string> attributes)
        {
            ldapFilter = $"(samaccountname={userid})";

            //log.LogDebug($"attributes b4   : {JsonConvert.SerializeObject(attributes)}");
            attributes = attributes.Union(DefaultAttributes).ToList<string>();    //merge default attributes with user-provided attributes
            //log.LogDebug($"attributes after: {JsonConvert.SerializeObject(attributes)}");

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            GetUser(ds);
            ds.Dispose();
        }

        public new void LoadDN(DirectoryEntry root, string dn )
        {
            string ldapFilter = $"(distinguishedname={dn})";
            log.LogDebug($"Loading User by DN(No attributes): {dn}");
            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());
            GetUser(ds);
            ds.Dispose();
        }

        public new void LoadDN(DirectoryEntry root, string dn, List<string> attributes)     //"new" overrides the LoadDN() method inherited from AdObject
        {
            string ldapFilter = $"(distinguishedname={dn})";

            //log.LogDebug($"attributes b4   : {JsonConvert.SerializeObject(attributes)}");
            attributes = attributes.Union(DefaultAttributes).ToList<string>();    //merge default attributes with user-provided attributes
            //log.LogDebug($"attributes after: {JsonConvert.SerializeObject(attributes)}");

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            GetUser(ds);
            ds.Dispose();
        }


        public new List<AdUser> Find(DirectoryEntry root, string ldapFilter)
        {
            DirectorySearcher ds = new DirectorySearcher();

            try
            {
                List<AdUser> lst = new List<AdUser>();
                AdUser user = new AdUser();

                ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());
                ds.SearchScope = SearchScope.Subtree;
                ds.ReferralChasing = ReferralChasingOption.All;

                SearchResultCollection results = ds.FindAll();
                foreach (SearchResult sr in results)
                {
                    user = new AdUser();
                    user.ObjectEntry = sr.GetDirectoryEntry();
                    user.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());
                    user.LoadObjectProperties(ds.PropertiesToLoad);

                    user.FirstName = user.GetProperty("givenName").ToString();
                    user.LastName = user.GetProperty("sn").ToString();
                    user.UserId = user.GetProperty("sAMAccountName").ToString();

                    //log.LogDebug($"Converting userAccountControl....");
                    int flags = Convert.ToInt32(user.GetProperty("userAccountControl"));
                    //log.LogDebug($"userAccountControl: {flags}");
                    user.Enabled = (flags & ADS_UF_ACCOUNT_DISABLE) != ADS_UF_ACCOUNT_DISABLE;

                    //log.LogDebug($"Converting msDS-User-Account-Control-Computed....");
                    flags = Convert.ToInt32(user.GetProperty("msDS-User-Account-Control-Computed"));
                    //log.LogDebug($"msDS-User-Account-Control-Computed: {flags}");
                    user.LockedOut = (flags & ADS_UF_LOCKOUT) == ADS_UF_LOCKOUT;

                    lst.Add(user);
                }
                return lst;
            }
            catch(Exception ex)
            {
                log.LogDebug($"Unexpected Exception: {ex.Message} \r\n {ex.StackTrace}");
                throw;
            }
            finally
            {
                ds.Dispose();
            }
        }

        public void Create(DirectoryEntry root, AdNewUser user)
        {
            if (DirectoryEntry.Exists(root.Path))
            {
                log.LogDebug($"Creating user {user.FullName} in {root.Path}");
                this.ObjectEntry = root.Children.Add($"CN={user.FullName}", "user");
                this.ObjectEntry.CommitChanges();
                root.CommitChanges();

                this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());

                //log.LogDebug($"setting samaccountname....");
                this.ObjectEntry.Properties["sAMAccountName"].Value = user.UserId;
                
                AdGeneratedPassword pwdGen = new AdGeneratedPassword();
                //log.LogDebug($"generating initial password");
                pwdGen.GeneratePassword(15);
                //log.LogDebug($"setting initial Password");
                SetPassword(pwdGen.Password);
                
                this.ObjectEntry.CommitChanges();

                log.LogDebug($"Account created.  Setting Additional properties...");
                
                //log.LogDebug($"Calculating account flags...");
                int flags = Convert.ToInt32(this.ObjectEntry.Properties["userAccountControl"].Value);
                //log.LogDebug($"flags(initial): {flags}");

                flags &= ADS_UF_NORMAL_ACCOUNT; //clears all bits/flags except the Normal_Account bit
                //log.LogDebug($"flags(normal): {flags}");

                //log.LogDebug($"commiting flag=NORMAL_ACCOUNT...");
                this.ObjectEntry.Properties["userAccountControl"].Value = flags;
                this.ObjectEntry.Properties["description"].Value = string.IsNullOrEmpty(user.Description) ? "" : user.Description;
                //this.ObjectEntry.CommitChanges();
                //this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());

                if (user.ServiceAccount)
                {
                    flags |= ADS_UF_DONT_EXPIRE_PASSWORD;
                    //log.LogDebug($"flags(dontExpire): {flags}");
                    //log.LogDebug($"commiting flag=NORMAL_ACCOUNT...");
                    this.ObjectEntry.Properties["userAccountControl"].Value = flags;
                    //this.ObjectEntry.CommitChanges();
                    //this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());
                }
                else
                {
                    this.ObjectEntry.Properties["pwdLastSet"].Value = 0;   //force user to change password at next logon
                    //log.LogDebug($"commiting pwdLastSet...");
                    //this.ObjectEntry.CommitChanges();
                    //this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());
                }
 
                //log.LogDebug($"Setting account flags to {flags}");
                this.ObjectEntry.Properties["userAccountControl"].Value = flags;

                //log.LogDebug($"flags(final): {flags}");


                //log.LogDebug($"Committing 1...");

                this.ObjectEntry.CommitChanges();
                //this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());

                //log.LogDebug($"Loading User...");
                this.Load(root, user.UserId);   //so we can re-use class methods and the caller has a copy of this object after the create call is finished

                this.LastName = string.IsNullOrEmpty(user.LastName) ? " " : user.LastName;
                this.FirstName = string.IsNullOrEmpty(user.FirstName) ? " " : user.FirstName;
                this.DisplayName = user.FullName;
                this.Enabled = user.Enabled;

                log.LogDebug($"this.Save().....");
                this.Save();
            }
            else
            {
                throw new ADNotFoundException($"parent root does not exist or has not been loaded");
            }
        }

        public void CreateIntensiveUser(DirectoryEntry root, AdNewUser user)
        {
            // connect to root
            //get

        }

        private void GetUser(DirectorySearcher ds)
        {
            //log.LogDebug($"Loading Properties: {JsonConvert.SerializeObject(ds.PropertiesToLoad)}");
            if (ds == null) { throw new ArgumentNullException("ds", "Directory Searcher object is null"); }
            ds.SearchScope = SearchScope.Subtree;
            ds.ReferralChasing = ReferralChasingOption.All;

            log.LogDebug("Searching for User...");
            SearchResult sr = ds.FindOne();
            if (sr == null)
            {
                throw new ADNotFoundException($"No Active Directory objects found that match '{ds.Filter}'");
            }

            log.LogDebug("Getting directory object...");
            this.ObjectEntry = sr.GetDirectoryEntry();
            if (this.ObjectEntry == null)
            {
                throw new ADNotFoundException($"No Active Directory entries found that match '{ds.Filter}'");
            }
            string[] attrs = new string[sr.Properties.PropertyNames.Count];

            sr.Properties.PropertyNames.CopyTo(attrs, 0);
            //log.LogDebug($"RefreshCache: {JsonConvert.SerializeObject(attrs)}");
            this.ObjectEntry.RefreshCache(attrs);

            log.LogDebug("Loading AdObject Properties...");
            //log.LogDebug($"Object Properties: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)}");
            this.LoadObjectProperties(ds.PropertiesToLoad);

            //log.LogDebug($"AdUser Attributes: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)}");
            log.LogDebug("Loading AdUser Properties...");
            this.UserId = GetProperty("sAMAccountname").ToString();
            if (sr.Properties.Contains("givenName"))
            {
                this.FirstName = GetProperty("givenName").ToString();
            }
            else
            {
                this.FirstName = this.UserId;
            }


            if (sr.Properties.Contains("sn"))
            {
                this.LastName = GetProperty("sn").ToString();
            }
            else
            {
                this.LastName = this.UserId;
            }

            //log.LogDebug($"Converting userAccountControl....");
            int flags = Convert.ToInt32(GetProperty("userAccountControl"));
            //log.LogDebug($"userAccountControl: {flags}");
            this.Enabled = (flags & ADS_UF_ACCOUNT_DISABLE) != ADS_UF_ACCOUNT_DISABLE;

            //log.LogDebug($"Converting msDS-User-Account-Control-Computed....");
            flags = Convert.ToInt32(GetProperty("msDS-User-Account-Control-Computed"));
            //log.LogDebug($"msDS-User-Account-Control-Computed: {flags}");
            this.LockedOut = (flags & ADS_UF_LOCKOUT) == ADS_UF_LOCKOUT;
        }


        public void Save()
        {
            //this.ObjectEntry.RefreshCache();
            this.ObjectEntry.Properties["givenName"].Value = this.FirstName;
            this.ObjectEntry.Properties["sn"].Value = this.LastName;
            this.ObjectEntry.Properties["displayName"].Value = this.DisplayName;
            //this.ObjectEntry.Properties["userPrincipalName"].Value = this.PrincipalName;

            int currentFlags = Convert.ToInt32(this.ObjectEntry.Properties["userAccountControl"].Value);
            log.LogDebug($"currentFlags: {currentFlags}");
            bool currEnabled = !( (currentFlags & ADS_UF_ACCOUNT_DISABLE) == ADS_UF_ACCOUNT_DISABLE );

            if (this.Enabled != currEnabled)    //is enabled value being modified?
            {
                currentFlags = currentFlags ^ ADS_UF_ACCOUNT_DISABLE; //XOR to toggle the enabled bit
            }
            
            this.ObjectEntry.Properties["userAccountControl"].Value = currentFlags;

            log.LogDebug($"Calculating Lockout Flag");
           
            bool currLockedOut = (currentFlags & ADS_UF_LOCKOUT) == ADS_UF_LOCKOUT;
            
            if (this.LockedOut != currLockedOut)    //is lockedout value being modified?
            {
                if (this.LockedOut)     //cannot set LockedOut property to TRUE
                {
                    throw new ArgumentException($"User Property 'LockedOut' cannot be set to TRUE");
                }
                else
                {
                    //currentFlags = currentFlags ^ ADS_UF_LOCKOUT; //XOR to toggle the lockout bit
                    this.ObjectEntry.Properties["lockoutTime"].Value = 0;
                }
            }

            

            //copy temp values from the Attributes property
            //to the DirectoryEntry for the user

            log.LogDebug($"updating attributes...");
            foreach (string a in this.Attributes.Keys)
            {
                log.LogDebug($"   =>[{a}]={this.Attributes[a].ToString()}");
                try
                {
                    //directoryServices keeps injecting "ADSPath" into the attribute list
                    if (a.ToLower() == "adspath") continue;


                    //skip read-only attributes in the Intensive domain only
                    if ( (this.DomainName.ToLower() == "intensive") && (ReadOnlyUserAttributes.Contains(a)) ) { continue;  } 

                    if (this.ObjectEntry.Properties[a].Value != this.Attributes[a])
                    {
                        this.ObjectEntry.Properties[a].Value = this.Attributes[a];
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"User attribute '{a}' cannot be modified: {ex.Message}", ex);
                }
            }
            log.LogDebug($"Commiting Directory Entry Changes");
            this.ObjectEntry.CommitChanges();
            //this.ObjectEntry.Dispose();
        }

       

        #region helper methods

        public void SetPassword(string newPassword)
        {
            this.ObjectEntry.Invoke("SetPassword", new object[] { newPassword });
            this.ObjectEntry.CommitChanges();
        }
        
        #endregion
    }
}
