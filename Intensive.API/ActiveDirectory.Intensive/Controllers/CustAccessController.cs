using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
//using Intensive.API.Common;
using Intensive.API.Global;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    public class AdCustomerAccess
    {
        public int Account { get; set; }
        public DateTime Expires { get; set; }

        public AdCustomerAccess(int acct, DateTime expires)
        {
            this.Account = acct;
            this.Expires = expires;
        }
    }

    [ApiController]
    [Route("users/{userid}/customeraccess")]
    public class CustAccessController : ADControllerBase
    {
        const string ACCESS_ATTRIBUTE = "rsactiveaccess";
        List<string> attributes = new List<string>() { ACCESS_ATTRIBUTE, "objectsid" };
        Dictionary<int, DateTime> customerAccess = new Dictionary<int, DateTime>();
        //int AccessDuration = 0;
        AdUser user;
        AdGroup group;


        public CustAccessController(ILogger<CustAccessController> logger,
                                    ActiveDirectoryService adsvc,
                                    AuditTrail audsvc,
                                    IOptions<AdSystemConfig> adconfig,
                                    AdUser aduser,
                                    AdGroup adgrp) : base(logger, adsvc, adconfig, audsvc)
        {
            int AccessDuration = ad.Config.AccountAccessLifeHours;
            this.user = aduser;
            this.group = adgrp;
            audit = audsvc;

        }

        [Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpGet]
        public IActionResult Get([FromRoute] string userid)
        {
            //return new StatusCodeResult(501);
            if (!userid.ToLower().EndsWith(".cust"))
            {
                return BadRequest("only *.cust user accounts from the INTENSIVE domain can be granted access");
            }

            if (config.DomainName.ToUpper() != "INTENSIVE")
            {
                return BadRequest("only *.cust user accounts from the INTENSIVE domain can be granted access");
            }

            try
            {
                ad.Connect();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                user.Load(ad.DirectoryRoot, userid, attributes);
                //if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (user.Attributes[ACCESS_ATTRIBUTE] != null))
                if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (!string.IsNullOrEmpty(user.Attributes[ACCESS_ATTRIBUTE].ToString())) )
                {
                    customerAccess = JsonConvert.DeserializeObject<Dictionary<int, DateTime>>(user.Attributes[ACCESS_ATTRIBUTE].ToString());
                }
                
                return Ok(customerAccess); 
                
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                APIError err = new APIError(ex, 11999, $"Unexpected error when querying {userid}'s access to customer environments");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }


        [Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] string userid, [FromQuery]string site, [FromBody] int account )
        {
            //this endpoint can only be callled on INTENSIVE user accounts the end with ".cust"
            //
            // e.g.,   /ad/v1/domains/intensive/users/joe.racker.cust
            //

            //return new StatusCodeResult(501);

            if (!userid.ToLower().EndsWith(".cust"))
            {
                return BadRequest("only *.cust user accounts from the INTENSIVE domain can be granted access");
            }

            if (config.DomainName.ToUpper() != "INTENSIVE")
            {
                return BadRequest("only *.cust user accounts from the INTENSIVE domain can be granted access");
            }

            List<string> errors = new List<string>();
            log.LogDebug($"[API]connecting to AD....");
            try
            {
                if (string.IsNullOrEmpty(site))
                {
                    ad.Connect();
                }
                else
                {
                    ad.Connect(site);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //List<AdGroup> groups = new List<AdGroup>();
            //string[] path;
            string errmsg = string.Empty;
            try
            {
                //load user and rsactiveaccess attribute
                log.LogDebug($"[API]loading user....");
                user.Load(ad.DirectoryRoot, userid, attributes);
                //if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (user.Attributes[ACCESS_ATTRIBUTE] != null))
                //{
                //    customerAccess = JsonConvert.DeserializeObject<Dictionary<int, DateTime>>(user.Attributes[ACCESS_ATTRIBUTE].ToString());
                //}
                if (user.Attributes.ContainsKey(ACCESS_ATTRIBUTE))
                {
                    //log.LogDebug($"  rsActiveAccess: exists on user object");
                    if (string.IsNullOrEmpty(user.Attributes[ACCESS_ATTRIBUTE].ToString()) )
                    {
                        //log.LogDebug($"  rsActiveAccess: is null or empty");
                        customerAccess = new Dictionary<int, DateTime>();
                        user.Attributes[ACCESS_ATTRIBUTE] = customerAccess;
                    }
                    else
                    {
                        //log.LogDebug($"  rsActiveAccess: is not null");
                        customerAccess = JsonConvert.DeserializeObject<Dictionary<int, DateTime>>(user.Attributes[ACCESS_ATTRIBUTE].ToString());
                    }
                }
                else
                {
                    //log.LogDebug($"  rsActiveAccess: does not exist on user object");
                    customerAccess = new Dictionary<int, DateTime>();
                    user.Attributes.Add(ACCESS_ATTRIBUTE, customerAccess);
                }

                log.LogDebug($"cust Access initial: {JsonConvert.SerializeObject(customerAccess)}");
            }
            catch(ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11003, $"Unable to load user data for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            log.LogDebug($"[API]Granting/Renewing Access to accounts....");

            bool OKToUpdateUser = false; 

            //update groups in the intensive domain and child domains
            try
            {
                List<AdGroup> groups = group.Find(ad.DirectoryRoot, $"(name={account}-Rax)");
                foreach (AdGroup g in groups)
                {
                    try
                    {
                        log.LogDebug($"Adding {userid} to {g.DomainName.ToUpper()}\\{g.Name}[{g.DN}]");
                        group.LoadDN(ad.DirectoryRoot, g.DN);
                        group.AddMember(user.DN);
                        log.LogDebug($"{userid} added to {g.DomainName.ToUpper()}\\{g.Name}");
                        errors.Add($"{userid} added to {g.DomainName.ToUpper()}\\{g.Name}");
                        OKToUpdateUser = true;
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Error Granting {userid} access to {g.DomainName.ToUpper()}\\{g.Name}: {ex.Message}");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error granting access to {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                errors.Add($"Error Granting {userid} access to account {account}: {ex.Message}");
            }


            // update groups in external forests/domains
            try
            { 
                //get hex string for user's SID
                log.LogDebug($"SID={user.Attributes["objectsid"].ToString()}");
                byte[] sid = (byte[])user.Attributes["objectsid"];
                SecurityIdentifier sidObj = new SecurityIdentifier(sid, 0);
                log.LogDebug($"sidObj={sidObj.ToString()}");
                string sidHex = BitConverter.ToString(sid).Replace("-", "");

                //add the SID Hex string as a Foreign Security Principal to the grp in the GlobalRS domain
                foreach (string url in FindGroup("globalrs", account, $"{account}-Rax").Resources)
                {
                    try
                    {
                        AddToGroupInGlobalRS(account, sidHex);
                        errors.Add($"{userid} added to GLOBALRS\\{account}-Rax");
                        OKToUpdateUser = true;
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Error adding {userid} to GLOBALRS\\{account}-Rax: {ex.Message}");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error granting access to {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                errors.Add($"Error add {userid} access to account {account}: {ex.Message}");
            }

            //update user
            if (OKToUpdateUser) //"true" if at least one group membership was successfully updated
            {
                try
                {
                    //load user and rsactiveaccess attribute
                    //log.LogDebug($"[API]loading user....");
                    //user.Load(ad.DirectoryRoot, userid, attributes);
                    //if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (user.Attributes[ACCESS_ATTRIBUTE] != null))
                    //{
                    //    customerAccess = JsonConvert.DeserializeObject<Dictionary<int, DateTime>>(user.Attributes[ACCESS_ATTRIBUTE].ToString());
                    //}

                    //above removed because "customerAccess" has already been loaded and initialized earlier
                    
                    if (customerAccess.ContainsKey(account))
                    {
                        customerAccess[account] = DateTime.UtcNow.AddHours(ad.Config.AccountAccessLifeHours);
                    }
                    else
                    {
                        customerAccess.Add(account, DateTime.UtcNow.AddHours(ad.Config.AccountAccessLifeHours));
                    }


                    log.LogDebug($"[API]Updating User attributes....");
                    user.Attributes[ACCESS_ATTRIBUTE] = JsonConvert.SerializeObject(customerAccess);
                    log.LogDebug($"cust Access updated: {JsonConvert.SerializeObject(customerAccess)}");
                    user.Save();
                }
                catch (Exception ex)
                {
                    ex.Data.Add("userid", userid);
                    ex.Data.Add("site", site);
                    ex.Data.Add("account", account);
                    APIError err = new APIError(ex, 11999, $"Unexpected error when saving user data for {userid}");
                    log.LogError(err.ErrorCode, err.FormattedException());
                    throw;
                }

                //audit changes
                log.LogDebug($"[API]writing Audit trail....");
                try
                {
                    audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                    audit.Action = "Grant Customer Access";
                    audit.Detail = string.Join("\r\n", errors);
                    audit.Account = account;
                    audit.DeviceNumber = null;
                    audit.TimeStamp = DateTime.UtcNow;
                    audit.SystemId = ad.Config.SystemId;

                    await audit.SaveAsync();

                    return Ok(errors);
                }
                catch (Exception ex)
                {
                    ex.Data.Add("userid", userid);
                    ex.Data.Add("site", site);
                    ex.Data.Add("account", account);
                    APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                    log.LogError(err.ErrorCode, err.FormattedException());
                    return new ServerError(err);
                }
            }//if OKToUpdateUser
            else
            {
                return Ok(errors);
            }
        }


        [Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete("{account}")]
        public async Task<IActionResult> Delete([FromRoute] string userid, [FromQuery]string site, [FromRoute] int account)
        {
            //this endpoint can only be callled on INTENSIVE user accounts the end with ".cust"
            //
            // e.g.,   /ad/v1/domains/intensive/users/joe.racker.cust
            //

            //return new StatusCodeResult(501);


            if (!userid.ToLower().EndsWith(".cust"))
            {
                return BadRequest("only *.cust user accounts from the INTENSIVE domain can have access revoked");
            }

            if (config.DomainName.ToUpper() != "INTENSIVE")
            {
                return BadRequest("only *.cust user accounts from the INTENSIVE domain can have access revoked");
            }

            List<string> errors = new List<string>();
            log.LogDebug($"[API]connecting to AD....");
            try
            {
                if (string.IsNullOrEmpty(site))
                {
                    ad.Connect();
                }
                else
                {
                    ad.Connect(site);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //List<AdGroup> groups = new List<AdGroup>();
           // string[] path;
            string errmsg = string.Empty;
            try
            {
                //load user and rsactiveaccess attribute
                log.LogDebug($"[API]loading user....");
                user.Load(ad.DirectoryRoot, userid, attributes);
                //if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (user.Attributes[ACCESS_ATTRIBUTE] != null))
                if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (!string.IsNullOrEmpty(user.Attributes[ACCESS_ATTRIBUTE].ToString())))
                {
                    customerAccess = JsonConvert.DeserializeObject<Dictionary<int, DateTime>>(user.Attributes[ACCESS_ATTRIBUTE].ToString());
                }
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11003, $"Unable to load user data for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            log.LogDebug($"[API]Revoking Access to accounts....");

            bool OKToUpdateUser = false;

            //update groups in the intensive domain and child domains
            try
            {

                List<AdGroup> groups = group.Find(ad.DirectoryRoot, $"(name={account}-Rax)");
                foreach (AdGroup g in groups)
                {
                    try
                    {
                        log.LogDebug($"Removing {userid} from {g.DomainName.ToUpper()}\\{g.Name}");
                        group.LoadDN(ad.DirectoryRoot, g.DN);
                        group.RemoveMember(user.DN);
                        log.LogDebug($"{userid} removed from {g.DomainName.ToUpper()}\\{g.Name}");
                        errors.Add($"{userid} removed from {g.DomainName.ToUpper()}\\{g.Name}");
                        OKToUpdateUser = true;
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Error removing {userid} from {g.DomainName.ToUpper()}\\{g.Name}: {ex.Message}");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error granting access to {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                errors.Add($"Error Granting {userid} access to account {account}: {ex.Message}");
            }

            // update groups in external forests/domains
            try
            {
                //get hex string for user's SID
                log.LogDebug($"SID={user.Attributes["objectsid"].ToString()}");
                byte[] sid = (byte[])user.Attributes["objectsid"];
                SecurityIdentifier sidObj = new SecurityIdentifier(sid, 0);
                log.LogDebug($"sidObj={sidObj.ToString()}");
                string sidHex = BitConverter.ToString(sid).Replace("-", "");

                //add the SID Hex string as a Foreign Security Principal to the grp in the GlobalRS domain
                foreach (string url in FindGroup("globalrs", account, $"{account}-Rax").Resources)
                {
                    try
                    {
                        RemoveFromGroupInGlobalRS(account, sidHex);
                        errors.Add($"{userid} removed from GLOBALRS\\{account}-Rax");
                        OKToUpdateUser = true;
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Error removing {userid} from GLOBALRS\\{account}-Rax: {ex.Message}");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11999, $"Unexpected error granting access to {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                errors.Add($"Error Granting {userid} access to account {account}: {ex.Message}");
            }

            //update user
            if (OKToUpdateUser) //"true" if at least one group membership was successfully updated
            {
                try
                {
                    //load user and rsactiveaccess attribute
                    user.Load(ad.DirectoryRoot, userid, attributes);
                    //if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (user.Attributes[ACCESS_ATTRIBUTE] != null))
                    if ((user.Attributes.ContainsKey(ACCESS_ATTRIBUTE)) && (!string.IsNullOrEmpty(user.Attributes[ACCESS_ATTRIBUTE].ToString())))
                    {
                        customerAccess = JsonConvert.DeserializeObject<Dictionary<int, DateTime>>(user.Attributes[ACCESS_ATTRIBUTE].ToString());
                    }

                    if (customerAccess.ContainsKey(account))
                    {
                        customerAccess.Remove(account);
                    }

                    log.LogDebug($"[API]Updating User attributes....");
                    user.Attributes[ACCESS_ATTRIBUTE] = JsonConvert.SerializeObject(customerAccess);
                    user.Save();
                }
                catch (Exception ex)
                {
                    ex.Data.Add("userid", userid);
                    ex.Data.Add("site", site);
                    ex.Data.Add("account", account);
                    APIError err = new APIError(ex, 11999, $"Unexpected error when saving user data for {userid}");
                    log.LogError(err.ErrorCode, err.FormattedException());
                    throw;
                }




                //audit changes
                log.LogDebug($"[API]writing Audit trail....");
                try
                {
                    audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                    audit.Action = "Revoke Customer Access";
                    audit.Detail = string.Join("\r\n", errors);
                    audit.Account = account;
                    audit.DeviceNumber = null;
                    audit.TimeStamp = DateTime.UtcNow;
                    audit.SystemId = ad.Config.SystemId;

                    await audit.SaveAsync();

                    return Ok(errors);
                }
                catch (Exception ex)
                {
                    ex.Data.Add("userid", userid);
                    ex.Data.Add("site", site);
                    ex.Data.Add("account", account);
                    APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                    log.LogError(err.ErrorCode, err.FormattedException());
                    return new ServerError(err);
                }
            } //if OKToUpdateUser
            else
            {
                return Ok(errors);
            }
        }

        private APICollection FindGroup(string domain, int account, string group)
        {
            log.LogDebug($"[API] Finding Groups in forest: {domain}");
            APIClient api = new APIClient();
            string basePath = Request.PathBase.Value.ToLower().Replace("domains/intensive", $"domains/{domain}/accounts/{account}");

            api.URL = $"{Request.Scheme}://{Request.Host}{basePath}/groups?filter=(name={group})";

            api.Execute();

            if (api.StatusCode == System.Net.HttpStatusCode.OK)
            {
                APICollection results = api.ReadObjectResponse<APICollection>();
                log.LogDebug($"Groups Found: {JsonConvert.SerializeObject(results)}");
                return results;
            }
            else
            {
                if (api.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new APICollection();
                }
                else
                {
                    throw new Exception($"Unexpected Error searching for account access group {group} in {domain}: {api.StatusDescription}");
                }
            }
        }

        private void AddToGroupInGlobalRS(int account, string memberSID)
        {
             log.LogDebug($"[API] AddToGroupInGlobalRS: adding member:{memberSID}");
            APIClient api = new APIClient();

            string basePath = Request.PathBase.Value.ToLower();
            string[] parts = basePath.Split(new char[] { '/' });  //  /ad/{version}/domain/users/{userid}/customeraccess
            string root = $"{parts[1]}/{parts[2]}";  //should be ad/{version}

            api.URL = $"{Request.Scheme}://{Request.Host}/{root}/domains/globalrs/accounts/{account}/customeraccess";

            api.Verb = "POST";
            api.PostData = "{\"sid\": \"" + memberSID + "\"}";
            //api.Headers.Add("X-Auth-Token", Request.Headers["X-Auth-Token"]);
            log.LogDebug($"[API] calling globalrs api: {api.URL}");
            api.Execute();

            if ((int)api.StatusCode >= 300)
            {
                log.LogDebug($"[API] ERROR==>{api.StatusCode}: {api.StatusDescription}");
                throw new Exception($"{ api.StatusCode }: { api.StatusDescription}");
            }
        }



      
        private string RemoveFromGroupInGlobalRS(int account, string memberSID)
        {
            log.LogDebug($"[API] RemoveFromGroupInGlobalRS: adding member:{memberSID}");
            APIClient api = new APIClient();

            string basePath = Request.PathBase.Value.ToLower();
            string[] parts = basePath.Split(new char[] { '/' });  //  /ad/{version}/domain/users/{userid}/customeraccess
            string root = $"{parts[1]}/{parts[2]}";  //should be ad/{version}

            api.URL = $"{Request.Scheme}://{Request.Host}/{root}/domains/globalrs/accounts/{account}/customeraccess/{memberSID}";
            log.LogDebug($"globalrs api: {api.URL}");

            api.Verb = "DELETE";
            //api.PostData = memberSID;
            //api.Headers.Add("X-Auth-Token", Request.Headers["X-Auth-Token"]);

            api.Execute();

            if (api.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return $"{memberSID} removed from GLOBALRS\\{account}-Rax";
            }
            else
            {
                log.LogDebug($"[API] ERROR==>{api.StatusCode}: {api.StatusDescription}");
                return $"Unexpected Error removing members from group GLOBALRS\\{account}-Rax: {api.StatusDescription}";
            }
        }


    }
}
