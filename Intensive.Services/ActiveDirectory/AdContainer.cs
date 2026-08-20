using System;
using System.Collections.Generic;
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
    public class AdContainer: AdObject
    {
        public List<AdObject> ChildObjects { get; set; }

        public AdContainer(): base()
        {
            this.ChildObjects = new List<AdObject>();
        }
        public AdContainer(ILogger<AdContainer> logger, IOptions<AdSystemConfig> adconfig) : base(logger, adconfig)
        {
            this.ChildObjects = new List<AdObject>();

        }

         public new void LoadDN(DirectoryEntry root, string dn)  //"new" overrides the LoadDN() method inherited from AdObject
        {
            //string ldapFilter = $"(distinguishedname={dn})";
            //DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());
            //GetContainer(ds);
            //ds.Dispose();
            this.LoadDN(root, dn, DefaultAttributes);
        }


        public new void LoadDN(DirectoryEntry root, string dn, List<string> attributes)     //"new" overrides the LoadDN() method inherited from AdObject
        {
            string ldapFilter = $"(distinguishedname={dn})";

            foreach (string a in DefaultAttributes)
            {
                if (!attributes.Contains(a)) { attributes.Add(a); }
            }

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            GetContainer(ds);
            ds.Dispose();
        }

        public new List<AdContainer> Find(DirectoryEntry root, string ldapFilter)
        {
            DirectorySearcher ds = new DirectorySearcher();
            string containerFilter = "(|(objectclass=container)(objectclass=organizationalUnit))";
            try
            {
                List<AdContainer> lst = new List<AdContainer>();
                AdContainer ou = new AdContainer();

                ldapFilter = $"(&({ldapFilter})({containerFilter}))";

                log.LogDebug($"Finding container. filter: {ldapFilter}");
                ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());


                ds.SearchScope = SearchScope.Subtree;  
                ds.ReferralChasing = ReferralChasingOption.All;

                SearchResultCollection results = ds.FindAll();
                foreach (SearchResult sr in results)
                {
                    ou = new AdContainer();

                    ou.ObjectEntry = sr.GetDirectoryEntry();
                    ou.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());
                    ou.LoadObjectProperties(ds.PropertiesToLoad);

                    this.ChildObjects = new List<AdObject>();

                    lst.Add(ou);
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

        public void CreateForeignSecurityPrincipal(byte[] sid, string upn)
        {
            SecurityIdentifier sidObj = new SecurityIdentifier(sid, 0);
            log.LogDebug($"sidString={sidObj.ToString()}");
            DirectoryEntry child = this.ObjectEntry.Children.Add($"CN={sidObj.ToString()}", "foreignSecurityPrincipal");

            log.LogDebug($"Committing Children.Add...");
            this.ObjectEntry.CommitChanges();

            log.LogDebug($"fsp dn :{child.Path}");
            //log.LogDebug($"Committing Child after Add...");
            //child.CommitChanges();

            log.LogDebug($"Setting UPN to {upn}");
            child.Properties["msds-principalname"].Value = upn;

            foreach (string k in child.Properties.PropertyNames)
            {
                log.LogDebug($"  [{k}] = {child.Properties[k].Value.ToString()}");
            }


            log.LogDebug($"Committing Child after Update...");
            child.CommitChanges();

            log.LogDebug($"Disposing Child....");
            child.Dispose();
        }


        public void Create(DirectoryEntry root, string name)
        {
            if (DirectoryEntry.Exists(root.Path))
            {
                this.ObjectEntry = root.Children.Add($"OU={name}", "OrganizationalUnit");
                this.ObjectEntry.CommitChanges();

                this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());
                this.LoadObjectProperties();
            }
            else
            {
                throw new ADNotFoundException($"parent root does not exist or has not been loaded");
            }
            
        }


        public void Delete()
        {
            if (DirectoryEntry.Exists(ObjectEntry.Path))
            {
                DirectoryEntry parent = ObjectEntry.Parent;
                parent.Children.Remove(ObjectEntry);
                
                parent.CommitChanges();
                parent.Dispose();
            }
            else
            {
                throw new ADNotFoundException($"parent root does not exist or has not been loaded");
            }

        }



        private void GetContainer(DirectorySearcher ds)
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

            string[] attrs = new string[sr.Properties.PropertyNames.Count];

            sr.Properties.PropertyNames.CopyTo(attrs, 0);
            this.ObjectEntry.RefreshCache(attrs);

            this.LoadObjectProperties(ds.PropertiesToLoad);

            if (!this.IsContainer)
            {
                throw new ADNotFoundException("This AdObject is not a container");
            }

            this.ChildObjects = this.GetChildren(ObjectEntry);
        }

        private List<AdObject> GetChildren(DirectoryEntry parent)
        {
            List<AdObject> children = new List<AdObject>();
            AdObject obj = new AdObject();
            AdContainer ou = new AdContainer();

            foreach (DirectoryEntry child in parent.Children)
            {
                obj = new AdObject();
                child.RefreshCache(DefaultAttributes.ToArray());
                
                obj.DN = child.Properties["distinguishedName"].Value.ToString();

                obj.Name = child.Properties["name"].Value.ToString();

                obj.DisplayName = (child.Properties.Contains("displayName")) ?
                                            child.Properties["displayName"].Value.ToString() :
                                            obj.Name;

                obj.PrincipalName = (child.Properties["msDS-PrincipalName"].Value == null) ?
                                        string.Empty : child.Properties["msDS-PrincipalName"].Value.ToString();


                string tempHidden = (child.Properties["wWWHomePage"].Value == null) ?
                                        string.Empty : child.Properties["wWWHomePage"].Value.ToString();

                obj.IsHidden = this.DisplayName.EndsWith("$") || tempHidden.Length > 0;

                object a = child.Properties["objectClass"];
                if (a is string)
                {
                    obj.ClassList.Add(a as string);
                }
                else
                {
                    string jsonClassList = JsonConvert.SerializeObject(a);
                    obj.ClassList = JsonConvert.DeserializeObject<List<string>>(jsonClassList);
                }

                
                if (obj.IsContainer)
                {
                    ou = new AdContainer();
                    ou.DN = obj.DN;
                    ou.Name = obj.Name;
                    ou.DisplayName = obj.DisplayName;
                    ou.ClassList = obj.ClassList;
                    ou.PrincipalName = string.Empty;
                    ou.ChildObjects = this.GetChildren(child);
                    ou.IsHidden = false;
                    children.Add(ou);
                }
                else
                {
                    children.Add(obj);
                }
                
            }

            return children;
        }
        //protected object GetAttribute(PropertyValueCollection items)
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


        //protected List<string> GetMultiValueProperty(PropertyValueCollection items)
        //{
        //    List<string> lst = new List<string>();

        //    foreach (object obj in items)
        //    {
        //        lst.Add(obj.ToString());
        //    }

        //    return lst;
        //}

        //protected void LoadUserAttributes(PropertyCollection items)
        //{
        //    foreach (string a in items.PropertyNames)
        //    {
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
