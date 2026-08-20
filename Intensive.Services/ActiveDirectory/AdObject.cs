using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Intensive.Services.ActiveDirectory
{


    public class AdObject
    {
        public string DN { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public List<string> ClassList { get; set; }
        public string PrincipalName { get; set; }// <domain>\<samaccountname> OR <domain>\<name>
        public string DomainName {
            get
            {
                return this.ParseDomain(this.DN);
            }

        }

        public bool IsContainer 
        {
            get
            {
                return this.ClassList.Contains("container") || this.ClassList.Contains("organizationalUnit");
            }
        }

        public bool IsUser
        {
            get
            {
                return (!IsComputer) &&
                            (this.ClassList.Contains("person") || 
                             this.ClassList.Contains("user") || 
                             this.ClassList.Contains("organizationalPerson")
                            );
            }
        }

        public bool IsGroup
        {
            get
            {
                return this.ClassList.Contains("group") ;
            }
        }

        public bool IsComputer
        {
            get
            {
                return this.ClassList.Contains("computer");
            }
        }

        public bool IsForeignSecurityPrincipal
        {
            get
            {
                return this.ClassList.Contains("foreignSecurityPrincipal");
            }
        }

        public bool IsHidden { get; set; }

        public Dictionary<string, object> Attributes { get; set; }

        protected DirectoryEntry Root;

        protected ILogger<AdObject> log;
        protected AdSystemConfig config;
        protected List<string> DefaultAttributes = new List<string>()
                { "name", "displayName", "distinguishedName", "objectClass", "msDS-PrincipalName", "wWWHomePage"};

        internal DirectoryEntry ObjectEntry = null;

        public AdObject(ILogger<AdObject> logger, IOptions<AdSystemConfig> adconfig) 
        {
            log = logger;
            config = adconfig.Value;
            this.Attributes = new Dictionary<string, object>();
            this.ClassList = new List<string>();
        }

        public AdObject() 
        {
            this.Attributes = new Dictionary<string, object>();
            this.ClassList = new List<string>();
        }


        public virtual List<AdObject> Find(DirectoryEntry root, string ldapFilter)
        {
            DirectorySearcher ds = new DirectorySearcher();
            try
            {
                List<AdObject> lst = new List<AdObject>();
                AdObject obj = new AdObject();

                log.LogDebug($"Building LDAP Searcher....");
                ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());
                ds.SearchScope = SearchScope.Subtree;
                ds.ReferralChasing = ReferralChasingOption.All;

                log.LogDebug($"searching LDAP: {ldapFilter}....");
                SearchResultCollection results = ds.FindAll();
                foreach (SearchResult sr in results)
                {
                    //this.ObjectEntry = sr.GetDirectoryEntry();

                    obj = new AdObject();
                    obj.ObjectEntry = sr.GetDirectoryEntry();
                    obj.LoadObjectProperties(ds.PropertiesToLoad);
                    lst.Add(obj);
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

        
        public void LoadDN(DirectoryEntry root, string dn)
        {
            this.LoadDN(root, dn, DefaultAttributes);
        }

        public void LoadDN(DirectoryEntry root, string dn, List<string> attributes)
        {
            string ldapFilter = $"(distinguishedname={dn})";

            foreach (string a in DefaultAttributes)
            {
                if (!attributes.Contains(a)) { attributes.Add(a); }
            }

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            GetObject(ds);
            ds.Dispose();
        }


        public AdObject ResolveFSP()
        {
            
            AdObject target = new AdObject();
            string[] dn = this.DN.Split(new char[] { ',' });
            string cn = dn[0];
            string sidstring = cn.Substring(3);
            log.LogDebug($"sid: {sidstring}");

            //string[] part = this.PrincipalName.Split(new char[] { '\\' });
            //string domain = part[0].ToLower();
            //string objName = part[1].ToLower();

            log.LogDebug($"Binding to INTENSIVE");
            DirectoryEntry root = new DirectoryEntry($"LDAP://DC=intensive,dc=int");

            log.LogDebug($"Searcher set to (objectSid={sidstring})");
            DirectorySearcher ds = new DirectorySearcher(root, $"(objectSid={sidstring})", DefaultAttributes.ToArray());

            if (ds == null) { throw new ArgumentNullException("ds", "Directory Searcher object is null"); }
            ds.SearchScope = SearchScope.Subtree;
            ds.ReferralChasing = ReferralChasingOption.All;

            log.LogDebug($"Searching.....");
            SearchResult sr = ds.FindOne();

            if (sr == null)
            {
                throw new ADNotFoundException($"No Active Directory objects found that match '{ds.Filter}'");
            }


            ObjectEntry = sr.GetDirectoryEntry();

            if (ObjectEntry == null)
            {
                throw new ADNotFoundException($"No Active Directory entries found that match '{ds.Filter}'");
            }

            //load default properties
            target.DN = GetProperty("distinguishedname").ToString();

            target.Name = GetProperty("name").ToString();

            target.DisplayName = (sr.Properties.Contains("displayname")) ?
                                        GetProperty("displayname").ToString() :
                                        target.Name;


            object o = GetProperty("objectclass");
            if (o is string)
            {
                target.ClassList.Add(o as string);
            }
            else
            {
                target.ClassList = o as List<string>;
            }

            //this.LoadUserAttributes(sr.Properties);

            return target;

        }



        public void MoveTo(AdContainer targetOU)
        {
            this.MoveTo(targetOU.ObjectEntry);
        }

        public void MoveTo(DirectoryEntry target)
        {
            if (DirectoryEntry.Exists(target.Path))
            {
                this.ObjectEntry.MoveTo(target);
                this.ObjectEntry.CommitChanges();
                this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());//refresh properties, such as DN, Parent, etc....
                StringCollection sc = new StringCollection();
                sc.AddRange(DefaultAttributes.ToArray());
                this.LoadObjectProperties(sc); //reload this object from properties
            }
            else
            {
                throw new ADNotFoundException("Target OU does not exist");
            }
        }

        public void Delete()
        {
            if (this.ObjectEntry == null)
            {
                throw new ADNotFoundException("Object has not been loaded");
            }
            else
            {
                using (DirectoryEntry parent = this.ObjectEntry.Parent)
                {
                    parent.Children.Remove(this.ObjectEntry);
                    parent.CommitChanges();
                }
            }
        }

        //additional ACL methods? Remove, modify, Purge, 
        public void SetACL(ActiveDirectoryAccessRule acl)
        {
            this.ObjectEntry.ObjectSecurity.SetAccessRule(acl);
            this.ObjectEntry.CommitChanges();
        }
        
        private void GetObject(DirectorySearcher ds)
        {
            if (ds == null) { throw new ArgumentNullException("ds", "Directory Searcher object is null"); }
            ds.SearchScope = SearchScope.Subtree;
            ds.ReferralChasing = ReferralChasingOption.All;

            SearchResult sr = ds.FindOne();

            if (sr == null)
            {
                throw new ADNotFoundException($"No Active Directory objects found that match '{ds.Filter}'");
            }


            ObjectEntry = sr.GetDirectoryEntry();

            if (ObjectEntry == null)
            {
                throw new ADNotFoundException($"No Active Directory entries found that match '{ds.Filter}'");
            }
            
            this.LoadObjectProperties(ds.PropertiesToLoad);
        }


        //Copies properties from the ObjectEntry object into the properties of this object
        internal void LoadObjectProperties()
        {
            //load default properties
            //log.LogDebug($"[LoadObjectProperties] Object Properties 1: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires").ToString()}");

            this.DN = GetProperty("distinguishedName").ToString();

            this.Name = GetProperty("name").ToString();

            this.DisplayName = (this.ObjectEntry.Properties.Contains("displayName")) ?
                                        GetProperty("displayName").ToString() :
                                        this.Name;
            //log.LogDebug($"[LoadObjectProperties] Object Properties 2: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires")}");

            string tempHidden = (GetProperty("wWWHomePage") == null) ? string.Empty : GetProperty("wWWHomePage").ToString();

            this.IsHidden = this.DisplayName.EndsWith("$") || tempHidden.Length > 0;

            //log.LogDebug($"[LoadObjectProperties] Object Properties 3: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires").ToString()}");

            object o = GetProperty("objectClass");
            if (o is string)
            {
                this.ClassList.Add(o as string);
            }
            else
            {
                this.ClassList = o as List<string>;
            }

            this.PrincipalName = GetProperty("msDS-PrincipalName").ToString();

            //log.LogDebug($"[LoadObjectProperties] Object Properties 4: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires").ToString()}");
            //load User-specified attributes/properties
            this.Attributes.Clear();
            foreach (string p in this.ObjectEntry.Properties.PropertyNames)
            {
                //log.LogDebug($"Adding property [{a}] to Attributes List");
                //do not add Default Attributes to the Attributes dictionary
                //so that only user-requested attributes are present
                if (DefaultAttributes.Contains(p))
                {
                    continue;
                }
                else
                {
                    this.Attributes.Add(p, GetProperty(p));
                }
            }//foreach
        }


        internal void LoadObjectProperties(StringCollection propList)
        {
            //load default properties
            //log.LogDebug($"[LoadObjectProperties] Object Properties 1: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires").ToString()}");

            this.DN = GetProperty("distinguishedName").ToString();

            this.Name = GetProperty("name").ToString();

            this.DisplayName = (this.ObjectEntry.Properties.Contains("displayName")) ?
                                        GetProperty("displayName").ToString() :
                                        this.Name;
            //log.LogDebug($"[LoadObjectProperties] Object Properties 2: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires")}");

            string tempHidden = (GetProperty("wWWHomePage") == null) ? string.Empty : GetProperty("wWWHomePage").ToString();

            this.IsHidden = this.DisplayName.EndsWith("$") || tempHidden.Length > 0;

            //log.LogDebug($"[LoadObjectProperties] Object Properties 3: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires").ToString()}");

            object o = GetProperty("objectClass");
            if (o is string)
            {
                this.ClassList.Add(o as string);
            }
            else
            {
                this.ClassList = o as List<string>;
            }

            this.PrincipalName = GetProperty("msDS-PrincipalName").ToString();

            //log.LogDebug($"[LoadObjectProperties] Object Properties 4: {JsonConvert.SerializeObject(this.ObjectEntry.Properties.PropertyNames)} accountExpires={GetProperty("accountExpires").ToString()}");
            //log.LogDebug($"[LoadObjectProperties] propList: {JsonConvert.SerializeObject(propList)}");
            //load User-specified attributes/properties
            this.Attributes.Clear();
            foreach (string p in propList)
            {
                //DirectoryEntry will inject the ADSPath attribute in the properties list, even if
                //it is not requested, since it cannot be updated, "hide" it from the caller so
                //the never see it.
                if (p.ToLower() == "adspath") continue;

                //log.LogDebug($"Adding property [{a}] to Attributes List");
                //do not add Default Attributes to the Attributes dictionary
                //so that only user-requested attributes are present
                if (DefaultAttributes.Contains(p))
                {
                    continue;
                }
                else
                {
                    this.Attributes.Add(p, GetProperty(p));
                }
            }//foreach
        }


        private string ParseDomain(string dn)
        {
            if (string.IsNullOrEmpty(dn)) { return string.Empty;  }

            string[] path = dn.Split(new char[] { ',' });
            string[] parts;

            foreach (string segment in path)
            {
                parts = segment.Split(new char[] { '=' });
                if (parts[0].ToLower() == "dc")
                {
                    return parts[1].ToLower();
                }
            }

            return string.Empty;
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
                }
            }
            return sb.ToString().ToLower();
        }

        protected string GetForestName(string fqdn)    // forestname == last two nodes of domain FQDN
        {
            string[] path = fqdn.Split(new char[] { '.' });
            int l = path.Length;
            return $"{path[l - 2]}.{path[l - 1]}".ToLower();
        }

        //protected object GetAttribute(ResultPropertyValueCollection items)
        //{
        //    if (items == null)
        //    {
        //        return null;
        //    }

            
        //    if (items.Count > 1)
        //    {
        //        return GetMultiValueProperty(items);
        //    }
        //    else if (items.Count == 1)
        //    {
        //        return items[0];
        //    }
        //    else 
        //    {
        //        return string.Empty;
        //    }
        //}


        //protected List<string> GetMultiValueProperty(ResultPropertyValueCollection items)
        //{
        //    List<string> lst = new List<string>();

        //    foreach (object obj in items)
        //    {
        //        lst.Add(obj.ToString());
        //    }
            
        //    return lst;
        //}

        protected object GetProperty(string key)
        {
            //log.LogDebug($"[GetProperty] {key}={JsonConvert.SerializeObject(this.ObjectEntry.Properties[key].Value)}");
            PropertyValueCollection items = this.ObjectEntry.Properties[key];
            if (items == null)
            {
                return null;
            }

            if (items.Count > 1)
            {
                return GetMultiValueProperty(items);
            }
            else if (items.Count == 1)
            {
                //return items[0];
                System.Type type = this.ObjectEntry.Properties[key].Value.GetType();

                if (type.Name.ToLower() == "__comobject")
                {
                    //long l = IADSLongIntegerToInt64(this.ObjectEntry.Properties[key].Value);
                    //log.LogDebug($"returning long/int64 of {l}");
                    //return l;
                    log.LogDebug($"calling IADSLongIntegerToInt64 -- key:{key} value: {this.ObjectEntry.Properties[key].Value} ");
                    return IADSLongIntegerToInt64(this.ObjectEntry.Properties[key].Value);
                }
                else
                {
                    return this.ObjectEntry.Properties[key].Value;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        //decodes IADsLargeInteger objects into Int64 format (long)
        //using Reflection instead of Interop
        public long IADSLongIntegerToInt64(object largeInteger)
        {
            System.Type type = largeInteger.GetType();

            int highPart = (int)type.InvokeMember(  "HighPart",
                                                    BindingFlags.GetProperty,
                                                    null,
                                                    largeInteger,
                                                    null
                                                 );

            int lowPart = (int)type.InvokeMember(   "LowPart",
                                                    BindingFlags.GetProperty,
                                                    null,
                                                    largeInteger,
                                                    null
                                                );

            return (long)highPart << 32 | (uint)lowPart;
        }



        protected List<string> GetMultiValueProperty(PropertyValueCollection items)
        {
            List<string> lst = new List<string>();

            foreach (object obj in items)
            {
                lst.Add(obj.ToString());
            }

            return lst;
        }

        //protected void LoadUserAttributes(ResultPropertyCollection items)
        //{
        //    this.Attributes.Clear();

        //    foreach (string a in items.PropertyNames)
        //    {
        //        //log.LogDebug($"Adding property [{a}] to Attributes List");
        //        //do not add Default Attributes to the Attributes dictionary
        //        //so that only user-requested attributes are present
        //        if (DefaultAttributes.Contains(a))
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            //Load user-requested attributes into the Attributes dictionary
        //            if (items[a].Count == 1)    //single-value property?
        //            {
        //                this.Attributes.Add(a, items[a][0]);
        //            }
        //            else if (items[a].Count > 1)    //multi-valued property??
        //            {
        //                List<string> lstValues = new List<string>();
        //                foreach (object o in items[a])
        //                {
        //                    lstValues.Add(o.ToString());
        //                }
        //                this.Attributes.Add(a, lstValues);
        //            }
        //        }
        //    }
        //}
    }

    
}
