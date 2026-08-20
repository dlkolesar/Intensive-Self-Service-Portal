using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices;
using Microsoft.AspNetCore.Mvc;
using Intensive.Services.ActiveDirectory;

//using Intensive.API.Common;
using Intensive.Data;
using Microsoft.Extensions.Logging;
using Intensive.Services.Auditing;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{

    [ApiController]
    [Route("accounts/{account}/sqlserviceaccounts")]
    public class SQLSvcAccountController: ADControllerBase
    {
        AdObjectFactory adFactory;
        AdGroup group;
        AdUser adSqlSvcAccount;
        AdUser adAgentSvcAccount;
        AdUser adBackupSvcAccount;
        AdUser adReportingSvcAccount;
        AdUser adAnalysisSvcAccount;
        AdUser adIntegrationSvcAccount;

        AdGeneratedPassword passwordGenerator;
        DirectoryEntry AccountRoot;
        DirectoryEntry TargetOU;

        public SQLSvcAccountController(ILogger<UserController> logger,
                                ActiveDirectoryService adsvc,
                                AdObjectFactory fac,
                                AdGeneratedPassword pwdgen,
                                IOptions<AdSystemConfig> adconfig,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {

            passwordGenerator = pwdgen;
            adFactory = fac;
        }

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromRoute] int account, [FromQuery]string path, [FromQuery] int sequenceNumber, [FromBody]AdNewSQLServiceAccounts svcAcctParams)
        {
            //validate newUser data

            if (svcAcctParams == null)
            {
                return BadRequest("There was an error parsing the input data");
            }

            if (!svcAcctParams.IsValid())
            {
                return BadRequest($"The input data is not valid: {JsonConvert.SerializeObject(svcAcctParams.Errors)}");
            }


            //sequence number, if present, must be 1 or greater
            // if omitted, it will default to zero
            if (sequenceNumber < 0) 
            {
                return BadRequest("sequenceNumber, if present, must be greater than 0");
            }

            //get the account OU, ignoring the path if present
            // This directoryEntry will be used as the root for seaches/Loads
            string acctDN = $"{GetAccountOU(account)}";
            try
            {
                ad.Connect(acctDN, null);
                AccountRoot = ad.DirectoryRoot;
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            //This call will load the sub-OU of the Account OU, where the new objects will be created.
            //if no sub-ou path is given, the existing(Account OU) object will be used.

            log.LogDebug($"***path: {path}");
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    TargetOU = AccountRoot;
                }
                else
                {
                    ad.Dispose();
                    ad.Connect(path, null);
                    TargetOU = ad.DirectoryRoot;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                ex.Data.Add("path", path);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            // look for existing SQLSVC# user accounts where # is a number > 0
            int seqNumber = (sequenceNumber == 0) ? GetNextSequenceNumber(AccountRoot, account) : sequenceNumber;
            log.LogDebug($"seqNumber={seqNumber}");

            List<string> cbResults = new List<string>();
            List<string> cbAuditDetails = new List<string>();


            // Create the Service Accounts
            adSqlSvcAccount = null;
            adAgentSvcAccount = null;
            adBackupSvcAccount = null;
            adReportingSvcAccount = null;
            adAnalysisSvcAccount = null;
            adIntegrationSvcAccount = null;

            try
            {
                adSqlSvcAccount = CreateServiceAccount(TargetOU, $"{account}-SQLSVC{seqNumber}", svcAcctParams.InstanceName);
                cbAuditDetails.Add($"{account}-SQLSVC{seqNumber}");
                cbResults.Add($"Create service account {account}-SQLSVC{seqNumber}: success");

                adAgentSvcAccount = CreateServiceAccount(TargetOU,  $"{account}-AGTSVC{seqNumber}", svcAcctParams.InstanceName);
                cbAuditDetails.Add($"{account}-AGTSVC{seqNumber}");
                cbResults.Add($"Create service account {account}-AGTSVC{seqNumber}: success");

                if (svcAcctParams.CreateBackupAccount)
                {
                    adBackupSvcAccount = CreateServiceAccount(TargetOU, $"{account}-Backup{seqNumber}", svcAcctParams.InstanceName);
                    cbAuditDetails.Add($"{account}-Backup{seqNumber}");
                    cbResults.Add($"Create service account {account}-backup{seqNumber}: success");
                }

                if (svcAcctParams.ReportingServices)
                {
                    adReportingSvcAccount = CreateServiceAccount(TargetOU,  $"{account}-RPTSVC{seqNumber}", svcAcctParams.InstanceName);
                    cbAuditDetails.Add($"{account}-RPTSVC{seqNumber}");
                    cbResults.Add($"Create service account {account}-RPTSVC{seqNumber}: success");
                }

                if (svcAcctParams.AnalysisServices)
                {
                    adAnalysisSvcAccount = CreateServiceAccount(TargetOU,  $"{account}-ANLSVC{seqNumber}", svcAcctParams.InstanceName);
                    cbAuditDetails.Add($"{account}-ANLSVC{seqNumber}");
                    cbResults.Add($"Create service account {account}-ANLSVC{seqNumber}: success");
                }

                if (svcAcctParams.IntegrationServices)
                {
                    adIntegrationSvcAccount = CreateServiceAccount(TargetOU,  $"{account}-INTSVC{seqNumber}", svcAcctParams.InstanceName);
                    cbAuditDetails.Add($"{account}-INTSVC{seqNumber}");
                    cbResults.Add($"Create service account {account}-INTSVC{seqNumber}: success");
                }
            }

            catch (Exception ex)
            {
                ex.Data.Add("path", path);
                APIError err = new APIError(ex, 11999, $"Unexpected error creating one or more service account:{ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            if (cbAuditDetails.Count == 0) //no service accounts created
            {
                Exception ex = new Exception($"No Service Accounts were created: {cbResults.ToString()}");

                APIError err = new APIError(ex, 11999, ex.Message);
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //
            // Create and populate groups
            //
            #region Create and Populate Groups

            // Create the SvcGroup# group, if it does not already exist
            group = adFactory.CreateGroup();
            try
            {
                group.Load(AccountRoot, $"{account}-SvcGroup{seqNumber}");
            }
            catch(ADNotFoundException nf)
            { 
                group.Create(TargetOU, $"{account}-SvcGroup{seqNumber}", AdGroupType.DomainLocalGroup);
 
                cbResults.Add($"Create group {account}-SvcGroup{seqNumber}: success");
            }
            catch (Exception ex)
            {
                cbResults.Add($"One or more Service Accounts were created, however, an unexpected error occured creating the the {account}-SvcGroup{seqNumber} group: {ex.Message}");
            }


            //Add the created service accounts to the SvcGroup# that was just created/loaded
            //if the service account does not exist, it will be skipped.
            try
            { 
                if (adSqlSvcAccount != null)
                {
                    group.AddMember(adSqlSvcAccount.DN);
                }

                if (adAgentSvcAccount != null)
                {
                    group.AddMember(adAgentSvcAccount.DN);
                }

                if (adBackupSvcAccount != null)
                {
                    group.AddMember(adBackupSvcAccount.DN);
                }

                if (adReportingSvcAccount != null)
                {
                    group.AddMember(adReportingSvcAccount.DN);
                }

                if (adAnalysisSvcAccount != null)
                {
                    group.AddMember(adAnalysisSvcAccount.DN);
                }

                if (adIntegrationSvcAccount != null)
                {
                    group.AddMember(adIntegrationSvcAccount.DN);
                }


                cbResults.Add($"Add service accounts to group {account}-SvcGroup{seqNumber}: success");
            }

            catch(Exception ex)
            {
                cbResults.Add($"One or more Service Accounts were created, however, an unexpected error occured adding them to the {account}-SvcGroup{seqNumber} group: {ex.Message}");
            }

            AdGroup AllUsersGroup = adFactory.CreateGroup();

            try
            {
                string grpDN = group.DN;
                AllUsersGroup.Load(AccountRoot, $"{account}-AllUsers", new List<string> { "objectSid" });
            }
            catch (Exception ex)
            {
                cbResults.Add($"One or more Service Accounts were created, however, an unexpected error occured loading the {account}-AllUsers group: {ex.Message}");
            }

            AdGroup ClustersGroup = adFactory.CreateGroup();
            try
            {
                string grpDN = group.DN;
                ClustersGroup.Load(AccountRoot, $"{account}-Clusters");
                ClustersGroup.AddMember(grpDN);
                cbResults.Add($"Add {account}-SvcGroup{seqNumber} to group {account}-Clusters: success");
            }
            catch (Exception ex)
            {
                cbResults.Add($"One or more Service Accounts were created, however, an unexpected error occured while adding the {account}-SvcGroup{seqNumber} to group {account}-Clusters group: {ex.Message}");
            }


            #endregion

            //
            // Grant permissions
            //
            #region Grant Permissions
            ActiveDirectoryAccessRule acl;
            byte[] sid;
            try
            {
                group.Load(AccountRoot, $"{account}-SvcGroup{seqNumber}", new List<string> { "objectSid" });//reload the svcGroup# to get the SID
                sid = (byte[])group.Attributes["objectSid"];
                IdentityReference irSvcGroup = new SecurityIdentifier(sid, 0);

                log.LogDebug($"Granting READ on {account}-AllUsers to {account}-SvcGroup{seqNumber}...");
                acl = new ActiveDirectoryAccessRule(irSvcGroup, ActiveDirectoryRights.GenericRead, AccessControlType.Allow, ActiveDirectorySecurityInheritance.All);
                AllUsersGroup.SetACL(acl);
                cbResults.Add($"Grant READ on {account}-AllUsers to {account}-SvcGroup{seqNumber}: success");
            }
            catch (Exception ex)
            {
                cbResults.Add($"One or more Service Accounts were created, however, an unexpected error occured while Granting READ on {account}-AllUsers to {account}-SvcGroup{seqNumber}: {ex.Message}");
            }



            try
            {
                adSqlSvcAccount.Load(AccountRoot, $"{account}-SQLSVC{seqNumber}", new List<string> { "objectSid" });//re-load user account to get the SID
                sid = (byte[])adSqlSvcAccount.Attributes["objectSid"];
                IdentityReference irSqlSvc = new SecurityIdentifier(sid, 0);

                log.LogDebug($"Granting FULLCONTROL on {group.Name} to {adSqlSvcAccount.Name}...");
                acl = new ActiveDirectoryAccessRule(irSqlSvc, ActiveDirectoryRights.GenericAll, AccessControlType.Allow, ActiveDirectorySecurityInheritance.All);
                group.SetACL(acl);
                cbResults.Add($"Grant FULLCONTROL on {group.Name} to {adSqlSvcAccount.Name}: success");
            }
            catch (Exception ex)
            {
                cbResults.Add($"One or more Service Accounts were created, however, an unexpected error occured while Granting FULLCONTROL on {account}-SvcGroup{seqNumber} to {account}-SQLSVC{seqNumber}: {ex.Message}");
            }
            #endregion


            //write Audit trail entry
            try
            {
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Create SQL Service Account(s) ";
                audit.Detail = cbAuditDetails.ToString();
                audit.Account = account;
                audit.DeviceNumber = null;
                audit.TimeStamp = DateTime.UtcNow;
                await audit.SaveAsync();
            }
            catch (Exception ex)
            {
                cbResults.Add($"Unexpected error writing audit trail entry: {ex.Message}");
            }

            return Ok(cbResults);
        }

        private int GetNextSequenceNumber(DirectoryEntry root, int account)
        {
            int seq = 0;
            List<AdUser> userAccounts = adFactory.CreateUser().Find(root, $"name={account}-sqlsvc*");
            //log.LogDebug($"[getSeq#] sqlsvc accounts: {JsonConvert.SerializeObject(userAccounts)}");
            if (userAccounts.Count > 0)
            {
                userAccounts.Sort(
                    (a, b) => { return a.Name.CompareTo(b.Name); }
                );
                AdUser user = userAccounts.Last();
                char ch = user.Name.Last(); //get the last char of the username
                seq = Convert.ToInt32(char.GetNumericValue(ch));
            }
            return ++seq;
        }


        private AdUser CreateServiceAccount(DirectoryEntry root, string userid, string instance)
        {
            AdUser svcAcct = adFactory.CreateUser();

            AdNewUser userParams = new AdNewUser();
            userParams.UserId = userid;
            userParams.FullName = userid;
            userParams.FirstName = "";
            userParams.LastName = "";
            userParams.Description = $"{instance} instance";
            userParams.ServiceAccount = true;
            userParams.Enabled = true;

            try
            {
                svcAcct.Load(root, userid);
                //if svc account already exists, do nothing
            }
            catch(ADNotFoundException nf)   //svc account does not already exist, so create it
            { 
                svcAcct.Create(root, userParams);
            }
            catch(Exception ex)
            {
                throw new Exception($"Unexpected error creating service account {userid}: {ex.Message}");
            }

            return svcAcct;
        }
    }

}
