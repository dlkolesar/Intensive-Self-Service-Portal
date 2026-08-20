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

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("accounts/{accountNumber}/users")]
    public class UserController : ADControllerBase
    {
        AdUser user;
        AdGroup group;
        

        public UserController(ILogger<UserController> logger,
                                ActiveDirectoryService adsvc,
                                AdUser aduser,
                                AdGeneratedPassword pwdgen,
                                AdGroup grp,
                                IOptions<AdSystemConfig> adconfig,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            user = aduser;
            group = grp;
        }
        // ?filter={ldapFilter} is required
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromRoute] int accountNumber, [FromQuery] string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                filter = "(&(objectCategory=person)(objectClass=user))";
            }
            else
            {
                filter = $"(&(objectCategory=person)(objectClass=user)({filter}))";
            }

            try
            {
                log.LogDebug($"AccountDN: {GetAccountOU(accountNumber)}");
                string oupath = GetAccountOU(accountNumber);
                ad.Connect(oupath, null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                List<AdUser> users = user.Find(ad.DirectoryRoot, filter);
                foreach (AdUser u in users)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}{Request.Path}/{u.UserId}";
                    results.Resources.Add(resourceURL);
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                ex.Data.Add("filter", filter);
                APIError err = new APIError(ex, 11999, $"Unexpected error searching for users that match '{filter}'");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [AllowAnonymous]
        [HttpGet("{name}")]
        public IActionResult GetUser([FromRoute] int accountNumber,
                                     [FromRoute] string name,
                                     [FromQuery] string attributes)
        {
            //connect to AD
            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
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
                    if (name.ToLower().StartsWith("cn="))
                    {
                        user.LoadDN(ad.DirectoryRoot, name);
                    }
                    else
                    {
                        user.Load(ad.DirectoryRoot, name);
                    }
                }
                else
                {
                    List<string> AttrList = attributes.Split(new char[] { ',' }).ToList<string>();
                    //group.Load(ad.DirectoryRoot, name, AttrList);
                    if (name.ToLower().StartsWith("cn="))
                    {
                        user.LoadDN(ad.DirectoryRoot, name, AttrList);
                    }
                    else
                    {
                        user.Load(ad.DirectoryRoot, name, AttrList);
                    }
                }
                return Ok(user);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("name", name);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11999, $"Unable to load user data for {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] int accountNumber, [FromQuery]string path, [FromBody]AdNewUser newUser)
        {
            log.LogDebug($"newUser: {JsonConvert.SerializeObject(newUser)}");

            //validate path, if not empty, is for this account
            if (!string.IsNullOrEmpty(path))
            {
                if (!PathMatchesAccount(accountNumber, path))
                {
                    return BadRequest($"'{path}' is not a valid DN for account {accountNumber}");
                }
            }

            //validate newUser data
           
            if (newUser == null)
            {
                return BadRequest("There was an error parsing the input data");
            }

            if (!newUser.IsValid())
            {
                return BadRequest($"The input data is not valid: {JsonConvert.SerializeObject(newUser.Errors)}");
            }


            if (!newUser.UserId.StartsWith($"{accountNumber.ToString()}-"))
            {
                newUser.UserId = $"{ accountNumber.ToString()}-{newUser.UserId}";
            }


            if (string.IsNullOrEmpty(newUser.FullName.Trim()))
            {
                //newUser.FullName = $"{newUser.FirstName} {newUser.LastName}";
                newUser.FullName = newUser.UserId;
            }

            //connect to AD
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect(base.GetAccountOU(accountNumber), null);
                }
                else
                {
                    ad.Connect(path, null);
                }
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            StringBuilder sbErrors = new StringBuilder();
            log.LogDebug($"[API] Creating User Object....");
            try
            {
                user.Create(ad.DirectoryRoot, newUser); //will populate "user" with new attributes
            }
            catch (Exception ex)
            {
                ex.Data.Add("path", path);
                APIError err = new APIError(ex, 11999, $"Unexpected error creating new  user:{newUser.UserId}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //write Audit trail entry
            try
            {
                log.LogDebug($"[API] Writing Audit trail....");
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Create User Account {user.DomainName}\\{user.UserId}";
                audit.Account = accountNumber;
                audit.DeviceNumber = null;
                audit.TimeStamp = DateTime.UtcNow;
                await audit.SaveAsync();
            }
            catch (Exception ex)
            {
                sbErrors.AppendLine($"The User Object was created, however, an unexpected error occured writing audit trail entry: {ex.Message}");
            }

            // Add to AllUsers group
            //connect to AD
            
            string ouAcct = base.GetAccountOU(accountNumber).ToLower();

            if (!string.IsNullOrEmpty(path))    //if path was specified
            {
                try
                {
                    ad.Dispose(); //destroy the old connection
                    ad.Connect(base.GetAccountOU(accountNumber), null); //connect to the account OU to find the group
                }
                catch (ADNotFoundException nf)
                {
                    return NotFound($"OU for account {accountNumber} does not exist in this domain");
                }
                catch (Exception ex)
                {
                    APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                    log.LogError(err.ErrorCode, err.FormattedException());
                    return new ServerError(err);
                }
            }
            
            log.LogDebug($"[API] Adding User to {accountNumber}-AllUsers....");
            try
            {
                group.Load(ad.DirectoryRoot, $"{accountNumber}-AllUsers");
                group.AddMember(user.DN);
            }
            catch (Exception ex)
            {
                sbErrors.AppendLine($"The User Object was created, however, an unexpected error occurred adding the user account to the {accountNumber}-AllUsers group: {ex.Message}");
            }

            Uri url = new Uri($"https://{Request.Host}{Request.PathBase}{Request.Path}/{newUser.UserId}");

            if (sbErrors.Length > 0)
            {
                log.LogError(sbErrors.ToString());
                return Created(url, sbErrors.ToString());
            }

            return Created(url, null);

        }


        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [Route("{userid}")]
        [HttpPut]
        public IActionResult Put([FromRoute] int accountNumber, 
                                 [FromRoute] string userid,
                                 [FromBody] AdUser newUser)

        {
            Dictionary<string, object> OldAttributes = new Dictionary<string, object>();

            //connect to AD
            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            //load current user data
            try
            {
                string[] attrKeys = new string[newUser.Attributes.Count];
                newUser.Attributes.Keys.CopyTo(attrKeys, 0);

                user.Load(ad.DirectoryRoot, userid, attrKeys.ToList<string>());

                log.LogDebug("[API]auditing Attribute values....");
                log.LogDebug($"[API]old user: {JsonConvert.SerializeObject(user)}");
                log.LogDebug($"[API]new user: {JsonConvert.SerializeObject(newUser)}");
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("newUser", JsonConvert.SerializeObject(newUser));
                APIError err = new APIError(ex, 11003, $"Unable to load user data for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            audit.SystemId = ad.Config.SystemId;

            try
            {
                if (user.FirstName != newUser.FirstName)
                {
                    audit.Detail += $"[FirstName] changed from '{user.FirstName.ToString()}' to '{newUser.FirstName.ToString()}'\r\n";
                    user.FirstName = newUser.FirstName;
                }

                if (user.LastName != newUser.LastName)
                {
                    audit.Detail += $"[LastName] changed from '{user.LastName.ToString()}' to '{newUser.LastName.ToString()}'\r\n";
                    user.LastName = newUser.LastName;
                }

                if (user.Enabled != newUser.Enabled)
                {
                    audit.Detail += $"[Enabled] changed from '{user.Enabled.ToString()}' to '{newUser.Enabled.ToString()}'\r\n";
                    user.Enabled = newUser.Enabled;
                }


                if (user.LockedOut != newUser.LockedOut)
                {
                    audit.Detail += $"[LockedOut] changed from '{user.LockedOut.ToString()}' to '{newUser.LockedOut.ToString()}'\r\n";
                    user.LockedOut = newUser.LockedOut;
                }

                if (user.DisplayName != newUser.DisplayName)
                {
                    audit.Detail += $"[DisplayName] changed from '{user.DisplayName.ToString()}' to '{newUser.DisplayName.ToString()}'\r\n";
                    user.DisplayName = newUser.DisplayName;
                }

                OldAttributes = user.Attributes;      // save previous values for audit logging
                                                      //user.Attributes = newUser.Attributes; // replace current attribute values with the new ones


                foreach (string attr in newUser.Attributes.Keys)
                {
                    log.LogDebug($"  {attr}");
                    if (OldAttributes.ContainsKey(attr))
                    {
                        log.LogDebug($"[API]     Comparing Values....");
                        log.LogDebug($"[API]     old: {user.Attributes[attr]}");
                        log.LogDebug($"[API]     new: {newUser.Attributes[attr]}");
                        if (newUser.Attributes[attr] != user.Attributes[attr])
                        {
                            //log.LogDebug("not equal. setting new value");
                            audit.Detail += $"[{attr}] changed from '{user.Attributes[attr]}' to '{newUser.Attributes[attr]}'\r\n";
                            user.Attributes[attr] = newUser.Attributes[attr];

                        }
                    }
                    else //attr was added
                    {
                        user.Attributes[attr] = newUser.Attributes[attr];
                        log.LogDebug("[API]   --> Adding new Attribute / value ");
                        user.Attributes.Add(attr, newUser.Attributes[attr]);
                        audit.Detail += $"[{attr}] changed from NULL to '{newUser.Attributes[attr]}'\r\n";
                    }
                }


                log.LogDebug($"[API]Attr.Keys: {user.Attributes.Keys.Count}");
                log.LogDebug("[API]checking if anything was actually changed....");
                //was anything actually changed?
                if (!string.IsNullOrEmpty(audit.Detail))
                {
                    log.LogDebug("[API]saving AD User object....");
                    user.Save();    // save the changes
                }
                else
                {
                    //log.LogDebug("Nothing changed");
                    return NoContent();    //nothing was changed; send back 200 OK
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("newUser", JsonConvert.SerializeObject(newUser));
                APIError err = new APIError(ex, 11004, $"Unexpected error updating user data for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //write Audit trail entry
            try
            {
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Update User Account {user.DomainName}\\{user.UserId}";

                audit.TimeStamp = DateTime.UtcNow;
                audit.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("newUser", JsonConvert.SerializeObject(newUser));
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [Route("{userid}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] int accountNumber,
                                    [FromRoute] string userid)

        {
            //connect to AD
            try
            {
                ad.Connect(base.GetAccountOU(accountNumber), null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound($"OU for account {accountNumber} does not exist in this domain");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            //load current user data
            try
            {
                user.Load(ad.DirectoryRoot, userid);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                APIError err = new APIError(ex, 11003, $"Unable to load user data for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                log.LogDebug("[API]Deleting AD User object....");
                user.Delete();    // Delete this user
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                APIError err = new APIError(ex, 11004, $"Unexpected error deleting user account {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //write Audit trail entry
            try
            {
                audit.SystemId = ad.Config.SystemId;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Delete User Account";
                audit.Detail = $"{user.DomainName}\\{user.UserId}";
                audit.TimeStamp = DateTime.UtcNow;
                audit.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                APIError err = new APIError(ex, 100, $"the User account was deleted, however, an unexpected error occurred writing the Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


    }
}
