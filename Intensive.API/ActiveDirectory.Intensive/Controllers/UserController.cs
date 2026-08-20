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

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ADControllerBase
    {
        AdUser user;
        public UserController(ILogger<UserController> logger,
                                ActiveDirectoryService adsvc,
                                AdUser aduser,
                                IOptions<AdSystemConfig> adconfig,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            user = aduser;
        }

        //get users in the domain
        // ?filter={ldapFilter} is required
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get([FromQuery] string filter, [FromQuery]string path)
        {
            log.LogDebug($"***path: {path}");
            log.LogDebug($"***filter: {filter}");
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
                if (string.IsNullOrEmpty(path))
                {
                    ad.Connect();
                }
                else
                {
                    ad.Connect(path,null);
                }
                
            }
            catch (Exception ex)
            {
                ex.Data.Add("filter", filter);
                ex.Data.Add("path", path);
                APIError err = new APIError(ex,11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                List<AdUser> users = user.Find(ad.DirectoryRoot, filter);
                foreach (AdUser u in users)
                {
                    resourceURL = $"https://{Request.Host}{Request.PathBase}{Request.Path.Value.TrimEnd(new char[]{'/'})}/{u.UserId}";
                    results.Resources.Add(resourceURL);
                }
                
                return Ok(results);
            }
            catch (Exception ex)
            {
                ex.Data.Add("filter", filter);
                ex.Data.Add("path", path);
                APIError err = new APIError(ex, 11999, $"Unexpected error searching for users that match '{filter}'");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        [AllowAnonymous]
        [Route("{userid}")]
        [HttpGet]
        public IActionResult GetUser([FromRoute] string userid,
                                     [FromQuery] string attributes)
        {

            //log.LogDebug($"userid: {userid}");
            try
            {
                ad.Connect();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
            

            try
            {
                if (string.IsNullOrEmpty(attributes))
                {
                    if (userid.ToLower().StartsWith("cn="))
                    {
                        user.LoadDN(ad.DirectoryRoot, userid);
                    }
                    else
                    {
                        user.Load(ad.DirectoryRoot, userid);
                    }
                }
                else
                {
                    List<string> AttrList = attributes.Split(new char[] { ',' }).ToList<string>();
                    if (userid.ToLower().StartsWith("cn="))
                    {
                        user.LoadDN(ad.DirectoryRoot, userid, AttrList);
                    }
                    else
                    {
                        user.Load(ad.DirectoryRoot, userid, AttrList);
                    }
                }
                log.LogDebug($"[API] GET user: {JsonConvert.SerializeObject(user)}");
                return Ok(user);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11999, $"Unable to load user data for {userid}");
                log.LogDebug($"**** ERROR: {err.ToString()}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


        [Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [Route("{userid}")]
        [HttpPut]
        public IActionResult Put([FromRoute] string userid,
                                 [FromQuery] string site,
                                 [FromBody] AdUser newUser)

        {
            Dictionary<string, object> OldAttributes = new Dictionary<string, object>();

            log.LogDebug($"Updating User....");

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
                ex.Data.Add("newUser", JsonConvert.SerializeObject(newUser));
                
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
                if (User == null)
                {
                    return NotFound();
                }

                log.LogDebug("[API]auditing Attribute values....");
                log.LogDebug($"[API]old user: {JsonConvert.SerializeObject(user)}");
                log.LogDebug($"[API]new user: {JsonConvert.SerializeObject(newUser)}");
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
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
                //if ( (!string.IsNullOrEmpty(audit.Detail)) && (user.Attributes.Keys.Count > 0))
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
                ex.Data.Add("site", site);
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
                ex.Data.Add("site", site);
                ex.Data.Add("newUser", JsonConvert.SerializeObject(newUser));
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        //[Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        //[HttpPost]
        //public async Task<IActionResult> Post([FromRoute] int accountNumber, [FromQuery]string path, [FromBody]AdNewUser newUser)
        //{
        //    log.LogDebug($"newUser: {JsonConvert.SerializeObject(newUser)}");

        //    if (string.IsNullOrEmpty(newUser.FullName.Trim()))
        //    {
        //        //newUser.FullName = $"{newUser.FirstName} {newUser.LastName}";
        //        newUser.FullName = newUser.UserId;
        //    }

        //    try
        //    {
        //        //connect to AD
        //        try
        //        {
        //            if (string.IsNullOrEmpty(path))
        //            {
        //                ad.Connect();
        //            }
        //            else
        //            {
        //                ad.Connect(path, null);
        //            }
        //        }
        //        catch (ADNotFoundException nf)
        //        {
        //            return NotFound($"OU path '{path}' does not exist in this domain");
        //        }
        //        catch (Exception ex)
        //        {
        //            APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
        //            log.LogError(err.ErrorCode, err.FormattedException());
        //            return new ServerError(err);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("account", accountNumber);
        //        ex.Data.Add("path", path);
        //        ex.Data.Add("newUser", newUser);
        //        APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }

        //    StringBuilder sbErrors = new StringBuilder();
        //    log.LogDebug($"[API] Creating User Object....");
        //    try
        //    {
        //        user.Create(ad.DirectoryRoot, newUser); //will populate "user" with new attributes
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("path", path);
        //        APIError err = new APIError(ex, 11999, $"Unexpected error creating new  user:{newUser.UserId}");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }

        //    //write Audit trail entry
        //    try
        //    {
        //        log.LogDebug($"[API] Writing Audit trail....");
        //        audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
        //        audit.Action = $"Create User Account {user.DomainName}\\{user.UserId}";
        //        audit.Account = accountNumber;
        //        audit.DeviceNumber = null;
        //        audit.TimeStamp = DateTime.UtcNow;
        //        await audit.SaveAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        sbErrors.AppendLine($"The User Object was created, however, an unexpected error occured writing audit trail entry: {ex.Message}");
        //    }



        //    // generate new random passoword and set it.
        //    log.LogDebug($"[API] Setting Password....");
        //    try
        //    {
        //        AdGeneratedPassword pg = new AdGeneratedPassword();
        //        pg.GeneratePassword(ad.Config.PasswordLength, ad.Config.PasswordLifeHours);
        //        user.SetPassword(pg.Password);
        //    }
        //    catch (Exception ex)
        //    {
        //        sbErrors.AppendLine($"The User Object was created, however, an unexpected error occured setting a default password: {ex.Message}");
        //    }

        //    Uri url = new Uri($"https://{Request.Host}{Request.PathBase}{Request.Path}/{newUser.UserId}");

        //    if (sbErrors.Length > 0)
        //    {
        //        log.LogError(sbErrors.ToString());
        //        return Created(url, sbErrors.ToString());
        //    }

        //    return Created(url, null);

        //}


        [AllowAnonymous]
        [Route("{userid}/groups")]
        [HttpGet]
        public IActionResult GetUserGroups([FromRoute] string userid,
                                     [FromQuery] string attributes)
        {
            try
            {
                ad.Connect();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);

                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {

                List<string> AttrList = new List<string> { "memberof" };

                user.Load(ad.DirectoryRoot, userid, AttrList);

                List<string> grps = user.Attributes["memberof"] as List<string>;
                results = new APICollection();
                string[] parts;
                string grpName;
                string domain;

                foreach (string g in grps)
                {
                    parts = g.Split(new char[] { ',' });
                    grpName = parts[0].Substring(3); //strip off the "cn="  at the beginning

                    domain = parts.First(s => s.ToUpper().StartsWith("DC=")).Substring(3);

                    if (domain.ToLower() == config.DomainFQDN.ToLower())
                    {
                        resourceURL = $"https://{Request.Host}{Request.PathBase}/groups/{grpName}";
                    }
                    else
                    {
                        string pathbase = Request.PathBase.Value.ToLower();
                        pathbase.Replace(config.DomainName, domain);
                        resourceURL = $"https://{Request.Host}{pathbase}/groups/{grpName}";
                    }
                    
                    //resourceURL = $"https://{Request.Host}{Request.PathBase}/groups/{grpName}";
                    results.Resources.Add(resourceURL);
                }
                
                return Ok(results);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                APIError err = new APIError(ex, 11999, $"Unable to load user data for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }


    }
}
