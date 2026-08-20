using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("accounts")]
    public class ContainerController : ADControllerBase
    {
        //DirectoryEntry root;
        AdObjectFactory adFactory;
        AdContainer adContainer;
        AdGroup adRAXClustersGroup;
        AdGroup adAllUsersGroup;
        AdGroup adAdminsGroup; 
        AdGroup adRAXGroup;
        AdGroup adClustersGroup;

        public ContainerController(ILogger<ContainerController> logger,
                                ActiveDirectoryService adsvc,
                                IOptions<AdSystemConfig> adconfig,
                                AdContainer adobj,
                                AdObjectFactory fac,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            this.adContainer = adobj;
            this.adFactory = fac;
        }

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost()]
        public IActionResult Post([FromBody] int account)
        {
            //Create new Account OU
            string acctDN = string.Empty;

            if (account <= 0)
            {
                return BadRequest($"'{account}' is not a valid number");
            }

            try
            {
                ad.Connect("OU=RAX,DC=Globalrs,DC=rack,DC=space", null); //All account OU are created in the RAX OU
                log.LogDebug($"[API]Connected to RAX OU");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            List<string> automationResults = new List<string>();

            //create Account OU
            try //try loading the account OU to see if it already exists
            {
                automationResults.Add(SetupAccountOU(ad.DirectoryRoot, account));
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unexpected error setting up account OU");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }




            try
            {
                adRAXClustersGroup = adFactory.CreateGroup();
                adRAXClustersGroup.LoadDN(ad.DirectoryRoot.Parent, $"CN=RAX-Clusters,OU=Infrastructure-Support,OU=Rackspace-Infrastructure,DC=Globalrs,DC=rack,DC=space");


                ad.Dispose();               //kill the current connection

                acctDN = GetAccountOU(account);
                log.LogDebug($"[API]Connecting to account OU: {acctDN}");
                ad.Connect(acctDN, null);   //connect to the account OU to make it the root 

                log.LogDebug($"[API]Initializing account OU...");
                automationResults.AddRange(InitializeAccountOU(ad, account));   //move to service layer??
                log.LogDebug($"[API]Initialization complete");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unexpected Error initializing the Account OU: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            ad.Dispose();
            return Ok(automationResults);
        }

 
        [AllowAnonymous]
        [HttpGet("{account}")]
        public IActionResult Get([FromRoute] int account, [FromQuery] string path, [FromQuery] string attributes)
        {
            string oupath = string.Empty;
            try
            {
                log.LogDebug($"AccountDN: {GetAccountOU(account)}");
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect(GetAccountOU(account), null);
                }
                else
                {
                    //oupath = $"{base.ToDN(path)},{ GetAccountOU(account)}";
                    ad.Connect(path, null);
                }
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                if (string.IsNullOrEmpty(attributes))
                {
                    adContainer.LoadDN(ad.DirectoryRoot, ad.DirectoryRoot.Properties["distinguishedName"].Value.ToString());
                }
                else
                {
                    List<string> AttrList = attributes.Split(new char[] { ',' }).ToList<string>();
                    adContainer.LoadDN(ad.DirectoryRoot, ad.DirectoryRoot.Properties["distinguishedName"].Value.ToString(), AttrList);
                }
               
                return Ok(adContainer);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound("OU path was not found");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unable to load OU/Container information");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

     

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost("{account}")]
        public async Task<IActionResult> Post([FromRoute] int account, [FromQuery] string path, [FromBody] string name)
        {
            //validate path, if not empty, is for this account
            if (!string.IsNullOrEmpty(path))
            {
                if (!PathMatchesAccount(account, path))
                {
                    return BadRequest($"'{path}' is not a valid DN for account {account}");
                }
            }

            //connect to AD
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect(GetAccountOU(account), null);
                }
                else
                {
                    ad.Connect(path, null);
                }
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                adContainer.Create(ad.DirectoryRoot, name);
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11999, $"Unexpected error creating new OU/Container");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Create OU";
                audit.Detail = name;
                audit.Account = account;
                audit.SystemId = config.SystemId;
                audit.DeviceNumber = null;
                audit.TimeStamp = DateTime.UtcNow;
                await audit.SaveAsync();

                resourceURL = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/accounts/{account}";
                return Created(resourceURL, null);
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 100, $"The  OU was successfully created.  However, an unexpected error occurred writing the Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        private List<string> InitializeAccountOU(ActiveDirectoryService ad, int acct)
        {
            List<string> automationResults = new List<string>(); //not thread-safe
 
            IdentityReference authUsers = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
            IdentityReference everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            ad.DirectoryRoot.ObjectSecurity.RemoveAccess(everyone, AccessControlType.Allow);
            ad.DirectoryRoot.ObjectSecurity.RemoveAccess(authUsers, AccessControlType.Allow);

            automationResults.Add($"Create Customer OU: succeeded");
            adAllUsersGroup = adFactory.CreateGroup();
            adAdminsGroup = adFactory.CreateGroup();
            adRAXGroup = adFactory.CreateGroup();
            adClustersGroup = adFactory.CreateGroup();

            //create groups
            log.LogDebug($"[API] Creating default Account Groups");

            automationResults.Add(SetupCustomerObjectsOU(ad.DirectoryRoot, acct));

            //create groups and load their default properties
            try
            { 
                adAllUsersGroup.Create(ad.DirectoryRoot, $"{acct}-AllUsers", AdGroupType.DomainLocalGroup);
                automationResults.Add($"Create group '{acct}-AllUsers': succeeded");
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Create group '{acct}-AllUsers': failed");
                automationResults.Add($"Create group '{acct}-AllUsers': failed[{ex.Message}]");
                return automationResults;
            }

            try
            {
                adAdminsGroup.Create(ad.DirectoryRoot, $"{acct}-Admins", AdGroupType.DomainLocalGroup);
                automationResults.Add($"Create group '{acct}-Admins': succeeded");
            }
            catch (Exception ex)
            {
                automationResults.Add($"Create group '{acct}-Admins': failed[{ex.Message}]");
            }

            try
            {
                adRAXGroup.Create(ad.DirectoryRoot, $"{acct}-RAX", AdGroupType.DomainLocalGroup);
                automationResults.Add($"Create group '{acct}-RAX': succeeded");
            }
            catch (Exception ex)
            {
                automationResults.Add($"Create group '{acct}-RAX': failed[{ex.Message}]");
            }

            try
            {
                adClustersGroup.Create(ad.DirectoryRoot, $"{acct}-Clusters", AdGroupType.DomainLocalGroup);
                automationResults.Add($"Create group '{acct}-Clusters': succeeded");
            }
            catch (Exception ex)
            {
                automationResults.Add($"Create group '{acct}-Clusters': failed[{ex.Message}]");
            }


            log.LogDebug($"[API] Created default Account Groups");

            //ad.DirectoryRoot.CommitChanges();

            //Populate Groups
            log.LogDebug($"[API] Populating Groups....");
            try
            {
                adRAXClustersGroup.AddMember(adClustersGroup.DN);
                automationResults.Add($"Add {acct}-Clusters added to RAX-Clusters group: succeeded");
            }
            catch (Exception ex)
            {
                automationResults.Add($"Add {acct}-Clusters added to RAX-Clusters group: failed[{ex.Message}]");
            }

            //populate AllUsersgroup
            try
            {
                adAllUsersGroup.AddMember(adClustersGroup.DN);
                adAllUsersGroup.AddMember(adAdminsGroup.DN);
                adAllUsersGroup.AddMember(adRAXGroup.DN);
                automationResults.Add($"Initialize {acct}-AllUsers group members: succeeded");
            }
            catch(Exception ex)
            {
                automationResults.Add($"Unexpected Error initializing the {acct}-AllUsers group membership list: {ex.Message}");
            }
 
            log.LogDebug($"[API] Populated default Account Groups");


            log.LogDebug($"[API] Setting OU and object security");

            //set default permissions
            //ref: https://stackoverflow.com/questions/3420187/how-do-i-add-permissions-to-an-ou-using-c

            log.LogDebug($"[API] Setting security identifiers...");

            // Well-Known SIDs
            //log.LogDebug($"[API]    AuthenticatedUsers...");
            //IdentityReference authUsers = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);

            //log.LogDebug($"[API]    Everyone...");
            //IdentityReference everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);

            //log.LogDebug($"[API]    {acct}-AllUsers...");
            adAllUsersGroup.Load(ad.DirectoryRoot, $"{acct}-AllUsers", new List<string> { "objectSid" });
            byte[] sid = (byte[])adAllUsersGroup.Attributes["objectSid"];
            IdentityReference grpAllUsers = new SecurityIdentifier(sid,0);

            
            //log.LogDebug($"[API]    {acct}-Admins...");
            adAdminsGroup.Load(ad.DirectoryRoot, $"{acct}-Admins", new List<string> { "objectSid" });
            sid = (byte[])adAdminsGroup.Attributes["objectSid"];
            IdentityReference grpAdmins = new SecurityIdentifier(sid, 0);
            
            //log.LogDebug($"[API]    {acct}-RAX...");
            adRAXGroup.Load(ad.DirectoryRoot, $"{acct}-RAX", new List<string> { "objectSid" });
            sid = (byte[])adRAXGroup.Attributes["objectSid"];
            IdentityReference grpRax = new SecurityIdentifier(sid, 0);
            
            //log.LogDebug($"[API]    {acct}-Clusters...");
            adClustersGroup.Load(ad.DirectoryRoot, $"{acct}-Clusters", new List<string> { "objectSid" });
            sid = (byte[])adClustersGroup.Attributes["objectSid"];
            IdentityReference grpClusters = new SecurityIdentifier(sid, 0);
            //log.LogDebug($"NTAccount: {grpClusters.Value}");

            try
            {
                log.LogDebug($"Granting READ on Account OU to {acct}-AllUsers...");
                ad.DirectoryRoot.ObjectSecurity.SetAccessRule(new ActiveDirectoryAccessRule(grpAllUsers, ActiveDirectoryRights.GenericRead, AccessControlType.Allow, ActiveDirectorySecurityInheritance.All));
                automationResults.Add($"Grant READ access on the Account OU to {acct}-AllUsers: succeeded");
                
                ActiveDirectorySecurity sec = ad.DirectoryRoot.ObjectSecurity;

                //Guids for properties can be looked up via ADSIEdit or LDP in the SchemaNaming context
                Guid computerObjects = Guid.Parse("bf967a86-0de6-11d0-a285-00aa003049e2");
                Guid spnProperty = Guid.Parse("f3a64788-5306-11d1-a9c5-0000f80367c1");
                Guid userObjects = Guid.Parse("BF967ABA-0DE6-11D0-A285-00AA003049E2");

                //No errors thrown, but the property permissions below were not granted.
                log.LogDebug($"Granting CREATE Computer Property on Account OU to {acct}-Clusters...");
                ActiveDirectoryAccessRule createComputerObjectPermission = new ActiveDirectoryAccessRule(grpClusters,
                                                                                                            ActiveDirectoryRights.CreateChild,
                                                                                                            AccessControlType.Allow,
                                                                                                            computerObjects,
                                                                                                            ActiveDirectorySecurityInheritance.All
                                                                                                          );

                sec.AddAccessRule(createComputerObjectPermission);

                automationResults.Add($"Grant CREATE COMPUTER access on the Account OU to {acct}-Clusters: succeeded");

                log.LogDebug($"Granting READ/WRITE spn Property on Account OU to {acct}-Clusters...");
                PropertyAccessRule GrantSPN_RW = new PropertyAccessRule(grpClusters,
                                                                        AccessControlType.Allow,
                                                                        PropertyAccess.Read,
                                                                        spnProperty, 
                                                                        ActiveDirectorySecurityInheritance.Descendents,
                                                                        userObjects);
                //ad.DirectoryRoot.ObjectSecurity.SetAccessRule();
                sec.AddAccessRule(GrantSPN_RW);
                GrantSPN_RW = new PropertyAccessRule(grpClusters,
                                                                        AccessControlType.Allow,
                                                                        PropertyAccess.Write,
                                                                        spnProperty,
                                                                        ActiveDirectorySecurityInheritance.Descendents,
                                                                        userObjects);
                //ad.DirectoryRoot.ObjectSecurity.SetAccessRule();
                sec.AddAccessRule(GrantSPN_RW);
                automationResults.Add($"Grant READ/WRITE SevicePrincipalName access on the Account OU to {acct}-Clusters: succeeded");


                //ad.DirectoryRoot.ObjectSecurity.RemoveAccess(everyone, AccessControlType.Allow);
                //ad.DirectoryRoot.ObjectSecurity.RemoveAccess(authUsers, AccessControlType.Allow);

                //(new ActiveDirectoryAccessRule(grpRax, ActiveDirectoryRights.ReadProperty | ActiveDirectoryRights.WriteProperty, AccessControlType.Allow, ActiveDirectorySecurityInheritance.All, spnProperty));

                ad.DirectoryRoot.ObjectSecurity = sec;

                
                ad.DirectoryRoot.CommitChanges();

                //sec = ad.DirectoryRoot.ObjectSecurity;
                //PrintSD(sec);
                //foreach (ActiveDirectoryAccessRule ace in sec.GetAccessRules(true, false, typeof(SecurityIdentifier)) )
                //{
                //    PrintAce(ace);
                //}

            }
            catch (AggregateException aggEx)
            {
                foreach (Exception ex in aggEx.InnerExceptions)
                {
                    automationResults.Add($"Unexpected error granting access to the account OU: {ex.Message}");
                }
            }

            audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            audit.Action = $"Account OU Initialized";
            audit.Detail = string.Empty;
            audit.Account = acct;
            audit.SystemId = config.SystemId;
            audit.DeviceNumber = null;
            audit.TimeStamp = DateTime.UtcNow;
            audit.Save();

            return automationResults;
        }

        private string SetupAccountOU(DirectoryEntry root, int account)
        {
            try //try loading the account OU to see if it already exists
            {
                log.LogDebug($"[API]checking if account OU already exists...");
                string acctDN = GetAccountOU(account);
                adContainer.LoadDN(root, acctDN);
                return "Create Account OU: Exists";
            }
            catch (ADNotFoundException nf)
            {
                return CreateAccountOU(root, account);
            }
            catch (Exception ex)
            {
                //APIError err = new APIError(ex, 11999, $"Unexpected error searching for existing account OU");
                //log.LogError(err.ErrorCode, err.FormattedException());
                //return new ServerError(err);
                throw;
            }

        }

        private string CreateAccountOU(DirectoryEntry root, int account)
        {
            try
            {
                //create the account OU in the Rax container
                log.LogDebug($"[API]Creating account OU....");
                adContainer.Create(ad.DirectoryRoot, account.ToString());
                log.LogDebug($"[API]OU created"); 
            }
            catch (Exception ex)
            {
                return $"Create Account OU: failed:[{ex.Message}]";
            }
            //write Audit trail entry
            audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
            audit.Action = $"Create Account OU";
            audit.Detail = "";
            audit.Account = account;
            audit.SystemId = config.SystemId;
            audit.DeviceNumber = null;
            audit.TimeStamp = DateTime.UtcNow;
            audit.Save();

            return "Create Account OU: succeeded";
        }

        private string SetupCustomerObjectsOU(DirectoryEntry root, int account)
        {
            try
            {
                adContainer.LoadDN(root, $"OU=Customer Objects,OU={account},OU=RAX,DC=Globalrs,DC=rack,DC=space");
                return $"Create 'Customer Objects' OU: Exists";
            }
            catch (Exception ex)
            {
                return CreateCustomerObjectsOU(root, account);
            }  
        }

        private string CreateCustomerObjectsOU(DirectoryEntry root, int account)
        {
            try
            {
                adContainer.Create(root, "Customer Objects");
                return $"Create 'Customer Objects' OU: succeeded";
            }
            catch(Exception ex)
            {
                return $"Create 'Customer Objects' OU: failed[{ex.Message}]";
            }
        }


        private void PrintAce(ActiveDirectoryAccessRule rule)
        {
            log.LogDebug("=====ACE=====");
            log.LogDebug($" Identity: {rule.IdentityReference.ToString()}");
            log.LogDebug($" AccessControlType: {rule.AccessControlType.ToString()}");
            log.LogDebug($" ActiveDirectoryRights: {rule.ActiveDirectoryRights.ToString()}");
            log.LogDebug($" InheritanceType: {rule.InheritanceType.ToString()}");
            if (rule.ObjectType == Guid.Empty)
                log.LogDebug($" ObjectType:");
            else
                log.LogDebug($" ObjectType: {rule.ObjectType.ToString() }");

            if (rule.InheritedObjectType == Guid.Empty)
                log.LogDebug($" InheritedObjectType:");
            else
                log.LogDebug($" InheritedObjectType: {rule.InheritedObjectType.ToString()}");
            log.LogDebug($" ObjectFlags: {rule.ObjectFlags.ToString()}");
           
        }

        public void PrintSD(ActiveDirectorySecurity sd)
        {
            log.LogDebug("=====Security Descriptor=====");
            log.LogDebug($" Owner: {sd.GetOwner(typeof(NTAccount)).Value}");
            log.LogDebug($" Group: {sd.GetGroup(typeof(NTAccount)).Value}");
        }
    }
}
