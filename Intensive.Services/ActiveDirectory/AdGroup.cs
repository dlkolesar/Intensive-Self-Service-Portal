using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Intensive.Services.ActiveDirectory
{
    [Flags]
    public enum AdGroupType
    {
        SystemGroup =                 1,     //0x00000001
        GlobalGroup =                 2,     //0x00000002
        DomainLocalGroup =            4,     //0x00000004
        UniversalGroup =              8,     //0x00000008
        AuthManBasicGroup=           16,     //0x00000010
        AuthManQueryGroup =          32,     //0x00000020
        SecurityEnabled =   -2147483648      //0x80000000
    };
    public class AdGroup : AdObject
    {
        private static List<string> DefaultGroupAttributes = new List<string>() { "grouptype" };
        private static List<string> ReadOnlyGroupAttributes = new List<string>()
                                 { "objectSid","ADsPath", "distinguishedName", "objectClass", "msDS-PrincipalName"};


        private string ldapFilter = string.Empty;
        //private DirectoryEntry GrpEntry;
        private bool recursiveSearch = false;

        public AdGroupType GroupType { get; set; }

        public bool IsSecurityGroup
        {
            get { return this.GroupType.HasFlag(AdGroupType.SecurityEnabled); }
        }
        
        public AdGroup(ILogger<AdGroup> logger, 
                        IOptions<AdSystemConfig> adconfig
                       ) : base(logger, adconfig)
        {
            //merge default object attributes with default group attributes
            DefaultAttributes.AddRange(DefaultGroupAttributes);
        }

        public AdGroup() : base() {
            //merge default object attributes with default group attributes
            DefaultAttributes.AddRange(DefaultGroupAttributes);
        }


        public void Load(DirectoryEntry root, string name)
        {
            this.Load(root, name, DefaultAttributes);
        }

        public void Load(DirectoryEntry root, string name, List<string> attributes)
        {
            ldapFilter = $"(&(objectclass=group)(name={name}))";

            attributes = attributes.Union(DefaultAttributes).Distinct().ToList<string>();    //merge default attributes with user-provided attributes

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            GetGroup(ds);
            ds.Dispose();
        }


        public new void LoadDN(DirectoryEntry root, string dn)
        {
            this.LoadDN(root, dn, new List<string>());
        }

        public new void LoadDN(DirectoryEntry root, string dn, List<string> attributes)
        {
            log.LogDebug($"Loading Group by DN {dn}");
            ldapFilter = $"(&(objectclass=group)(distinguishedname={dn}))";

            attributes = attributes.Union(DefaultAttributes).Distinct().ToList<string>();    //merge default attributes with user-provided attributes

            DirectorySearcher ds = new DirectorySearcher(root, ldapFilter, attributes.ToArray());
            //ds.PageSize = 5000;
            GetGroup(ds);
            ds.Dispose();
        }
        
        public new List<AdGroup> Find(DirectoryEntry root, string ldapFilter)
        {
            DirectorySearcher ds = new DirectorySearcher();

            try
            {
                List<AdGroup> lst = new List<AdGroup>();
                AdGroup grp = new AdGroup();

                ds = new DirectorySearcher(root, ldapFilter, DefaultAttributes.ToArray());
                ds.SearchScope = SearchScope.Subtree;
                ds.ReferralChasing = ReferralChasingOption.All;

                SearchResultCollection results = ds.FindAll();
                foreach (SearchResult sr in results)
                {
                    grp = new AdGroup();
                    grp.ObjectEntry = sr.GetDirectoryEntry();
                    if (grp.ObjectEntry == null)
                    {
                        throw new Exception($"Failed to get DirectoryEntry Object '{ds.Filter}'");
                    }

                    grp.LoadObjectProperties(ds.PropertiesToLoad); //loads the base properties and any user-specified properties

                    //additional properties to load
                    string grptype = grp.GetProperty("grouptype").ToString();
                    this.GroupType = (AdGroupType)Enum.Parse(typeof(AdGroupType), grptype);

                    lst.Add(grp);
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

        public void Create(DirectoryEntry root, string name, AdGroupType grpType)
        {
            if (DirectoryEntry.Exists(root.Path))
            {
                try
                {
                    this.ObjectEntry = root.Children.Add($"CN={name}", "Group");
                    this.ObjectEntry.Properties["sAMAccountName"].Value = name;
                    this.ObjectEntry.Properties["grouptype"].Value = (int)(grpType | AdGroupType.SecurityEnabled); //all groups are security groups
                    this.ObjectEntry.CommitChanges();

                    this.ObjectEntry.RefreshCache(DefaultAttributes.ToArray());
                    this.LoadObjectProperties();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected Error creating group {name}: {ex.Message}", ex);
                }
            }
            else
            {
                throw new ADNotFoundException($"parent root path {root.Path} does not exist");
            }

        }

        public void Save()
        {
            this.ObjectEntry.RefreshCache(this.Attributes.Keys.ToArray());
            //this.ObjectEntry.Properties["name"].Value = this.Name;
            this.ObjectEntry.Properties["groupType"].Value = (int)this.GroupType;
            this.ObjectEntry.Properties["displayName"].Value = this.DisplayName;

            //copy temp values from the Attributes property
            //to the DirectoryEntry for the user

            log.LogDebug($"updating attributes...");
            foreach (string a in this.Attributes.Keys)
            {
                log.LogDebug($"   =>[{a}]={this.Attributes[a].ToString()}");
                try
                {
                    if (ReadOnlyGroupAttributes.Contains(a)) //skip read-only attributes
                    {
                        log.LogDebug($"skipping Read-Only attribute {a}");
                        continue; 
                    }
                    System.Type type = this.ObjectEntry.Properties[a].Value.GetType();
                   
                    log.LogDebug($"   =>[{a}] type is a {type.Name}");
                    
                    if (this.ObjectEntry.Properties[a].Value != this.Attributes[a])
                    {
                        if (type.Name.ToLower() == "string")
                        {
                            this.ObjectEntry.Properties[a].Value = this.Attributes[a].ToString();
                        }
                        else
                        {
                            this.ObjectEntry.Properties[a].Value = this.Attributes[a];
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException($"Group attribute '{a}' cannot be modified: {ex.Message}", ex);
                }
            }
            log.LogDebug($"Commiting Directory Entry Changes");
            this.ObjectEntry.CommitChanges();
            //this.ObjectEntry.Dispose();
        }


        //public void Delete(DirectoryEntry root)
        //{
        //    root.Children.Remove(this.ObjectEntry);

        //    this.ObjectEntry.CommitChanges();
        //    this.ObjectEntry.Dispose();
        //}


        public void AddMember(string dn)
        {
            log.LogDebug($"[AdGroup] adding dn={dn} to group {this.DN}");

            if (this.ObjectEntry == null)
            {
                throw new ArgumentNullException("ObjectEntry", "Group has not been loaded; call Group.Load(name) before adding members");
            }

            if (DirectoryEntry.Exists(this.ObjectEntry.Path))
            {
                this.ObjectEntry.Properties["member"].Add(dn);
                this.ObjectEntry.CommitChanges();
            }
            else
            {
                throw new ADNotFoundException("Group does not exist");
            }

        }

        public void RemoveMember(string dn)
        {
            log.LogDebug($"[AdGroup] removing dn={dn}");

            if (this.ObjectEntry == null)
            {
                throw new ArgumentNullException("ObjectEntry", "Group has not been loaded; call Group.Load(name) before adding members");
            }

            if (DirectoryEntry.Exists(this.ObjectEntry.Path))
            {
                this.ObjectEntry.Properties["member"].Remove(dn);
                this.ObjectEntry.CommitChanges();
            }
            else
            {
                throw new ADNotFoundException("Group does not exist");
            }

        }
        
        private void DumpEntry(DirectoryEntry d)
        {
            log.LogDebug("******************************************");
            log.LogDebug($"Name: {d.Name}");
            log.LogDebug($"Path: {d.Path}");
            log.LogDebug($"Schema: {d.SchemaClassName}");
            log.LogDebug("Properties:");
            foreach (string k in d.Properties.PropertyNames)
            {
                log.LogDebug($"  [{k}] = {d.Properties[k].Value.ToString()}");
            }
            log.LogDebug("******************************************");
        }

        //not allowing recursive group lookups right now
        //problems arise when a group contains member objects
        //from another trusted/child domain --
        // the service layer is not able to resolve the 
        // referal/reference, since it is "connected" to 
        // a specific AD domain
        //use Attribute-Scoped Query to get group members
        // see: https://docs.microsoft.com/en-us/windows/desktop/adsi/performing-an-attribute-scoped-query
        //
        public List<string> GetMembers()
        {
            //recursiveSearch = recursive;
            if (this.ObjectEntry == null)
            {
                throw new ArgumentNullException("ObjectEntry", "Group has not been loaded; call Group.Load(name) before adding members");
            }

            if (DirectoryEntry.Exists(this.ObjectEntry.Path))
            {
                return GetGroupMembers();
            }
            else
            {
                throw new ADNotFoundException("Group does not exist");
            }

           
        }

        private List<string> GetGroupMembers()
        {
            log.LogDebug($"[GetGroupMembers] Begin");

            int start = 1500;
            List<string> groupMembers = new List<string>();
            log.LogDebug($"[GetGroupMembers] Refresh Cache (member)");
            this.ObjectEntry.RefreshCache(new string[] { "member" });

            //log.LogDebug($"ObjectProperty[member]: {JsonConvert.SerializeObject(this.ObjectEntry.Properties["member"].Value)}");

            //while (true)
            //{
                object result = this.GetProperty("member");
                if (result is string)
                {
                    log.LogDebug($"result is a single result/string");
                    groupMembers.Add(result.ToString());
                //break;
                    return groupMembers;
                }

                List<string> members = new List<string>();
                if (result is List<string>)
                {
                    members = result as List<string>;
                    log.LogDebug($"result is a an array({members.Count})");
                }

                log.LogDebug($"[GetGroupMembers] members: {JsonConvert.SerializeObject(members)}");
                if (members.Count > 0) 
                {
                    log.LogDebug($"[GetGroupMembers] Before Merging into groupMembers - size={groupMembers.Count}");
                    groupMembers.AddRange(members);
                    log.LogDebug($"[GetGroupMembers] After  Merging into groupMembers - size={groupMembers.Count}");
                };

                //if (members.Count == 1500)
                //{
                //    start += 1500;
                //    this.ObjectEntry.RefreshCache(new string[] { $"member;range={start}-*" });
                //}
                //else
                //{
                //    break;
                //}
            //}
            
            log.LogDebug($"[GetGroupMembers] End");
            return groupMembers;
        }


        //private List<AdObject> GetGroupMembers(AdObject grp)
        //{
        //    log.LogDebug($"[GetGroupMembers] Begin");
        //    List<AdObject> members = new List<AdObject>();
        //    AdObject mem = new AdObject();

        //    //use the Global Catalog for searching
        //    // why???
        //    log.LogDebug($"[GetGroupMembers] Connecting to GC://{grp.DN}");
        //    DirectoryEntry grpObject = new DirectoryEntry($"GC://{grp.DN}");
        //    //List<string> memberAttributes = new List<string>();

        //    DirectorySearcher ds = new DirectorySearcher(grpObject, "(objectclass=*)", DefaultAttributes.ToArray());
        //    ds.SearchScope = SearchScope.Base;//must be BASE when using AttributeScopeQuery
        //    ds.AttributeScopeQuery = "member";
        //    //ds.ReferralChasing = ReferralChasingOption.All;
        //    ds.PageSize = Int32.MaxValue;

        //    log.LogDebug($"[GetGroupMembers] Searching ....");
        //    using (SearchResultCollection src = ds.FindAll())
        //    {
        //        log.LogDebug($"[GetGroupMembers] Search Results: {src.Count} matches found");
        //        foreach (SearchResult sr in src)
        //        {
        //            log.LogDebug($"sr={sr.Path}");
        //            mem = new AdObject();
        //            mem.ObjectEntry = sr.GetDirectoryEntry();
        //            mem.LoadObjectProperties(ds.PropertiesToLoad);
        //            members.Add(mem);
        //        }
        //    }

        //    log.LogDebug($"[GetGroupMembers] End");
        //    return members;
        //}


        private void GetGroup(DirectorySearcher ds)
        {
            log.LogDebug($"Finding AdGroup object....");
            if (ds == null) { throw new ArgumentNullException("ds", "Directory Searcher object is null"); }
            ds.SearchScope = SearchScope.Subtree;
            ds.ReferralChasing = ReferralChasingOption.All;
            //int size = ds.PropertiesToLoad.Count;
            
            SearchResult sr = ds.FindOne();
            
            if (sr == null)
            {
                throw new ADNotFoundException($"No Active Directory objects found that match '{ds.Filter}'");
            }

            this.ObjectEntry = sr.GetDirectoryEntry();
            if (ObjectEntry == null)
            {
                throw new ADNotFoundException($"Unable to retrieve matching directory entry '{sr.Path}'");
            }

            this.LoadObjectProperties(ds.PropertiesToLoad); //Load default AdObject properties and attributes array

            string grp = GetProperty("grouptype").ToString();
            this.GroupType = (AdGroupType)Enum.Parse(typeof(AdGroupType), grp);
        }
    }
}
