using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
//using Intensive.API.Common;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Intensive.API.Global;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    [ApiController]
    [Route("/users/{userid}/password")]
    public class UserPasswordController : ADControllerBase
    {
        AdGeneratedPassword passwordGenerator;
        AdUser user;

        public UserPasswordController(ILogger<DomainController> logger,
                               ActiveDirectoryService adsvc,
                               AdGeneratedPassword pwdgen,
                               AdUser usr,
                               IOptions<AdSystemConfig> adconfig,
                               AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            passwordGenerator = pwdgen;
            user = usr;
        }
        [Authorize(Policy="UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpGet]
        public IActionResult Get([FromRoute] string userid,
                                  [FromQuery] string site)
        {
           // return new StatusCodeResult(501);
            log.LogDebug("Connecting to AD....");
            try
            {

                if (String.IsNullOrEmpty(site))
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
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //int age = ad.Config.PasswordLifeHours;

            // Load current user data
            log.LogDebug($"Loading User Object {userid}....");
            try
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
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                APIError err = new APIError(ex, 11999, $"Unable to load user data for {userid}");
                log.LogDebug($"**** ERROR: {err.ToString()}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //generate a new password and update user account
            try
            {
                log.LogDebug("Generating new password....");
                passwordGenerator.GeneratePassword(ad.Config.PasswordLength, ad.Config.PasswordLifeHours);

                user.SetPassword(passwordGenerator.Password);

                user.Attributes.Add("accountexpires", passwordGenerator.Expires.ToFileTime().ToString());

                log.LogDebug("Saving User account....");
                user.Save();

                log.LogDebug($"password generated and saved: {JsonConvert.SerializeObject(passwordGenerator)}");
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                APIError err = new APIError(ex, 11005, $"Unexpected error Generating/Setting new password for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                audit.SystemId = ad.Config.SystemId;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"New password generated for {user.DomainName}\\{user.UserId}";
                audit.Detail += $"[accountexpires] set to {passwordGenerator.Expires} UTC";
                audit.TimeStamp = DateTime.UtcNow;
                audit.Save();

                return Ok(passwordGenerator);
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }



        //expire the account/password right now
        [Authorize(Policy = "UserMatch", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] string userid,
                              [FromQuery] string site)
        {
           // return new StatusCodeResult(501);
            log.LogDebug("Connecting to AD....");
            try
            {

                if (String.IsNullOrEmpty(site))
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
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            //int age = ad.Config.PasswordLifeHours;

            // Load current user data
            log.LogDebug($"Loading User Object {userid}....");
            try
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
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                APIError err = new APIError(ex, 11003, $"Unable to load user data for {userid}");
                log.LogError(err.ErrorCode, ex.Message, ex.StackTrace);
                return new ServerError(err);
            }

            try
            {
                log.LogDebug("Expiring account....");
                user.Attributes.Add("accountexpires", DateTime.UtcNow.ToFileTime().ToString());

                log.LogDebug("Saving User account....");
                user.Save();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                APIError err = new APIError(ex, 11005, $"Unexpected error Expiring account/password for {userid}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                audit.SystemId = ad.Config.SystemId;
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = $"Expired User Account  {user.DomainName}\\{user.UserId}";
                audit.Detail = "";
                audit.TimeStamp = DateTime.UtcNow;
                audit.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                ex.Data.Add("userid", userid);
                ex.Data.Add("site", site);
                APIError err = new APIError(ex, 100, $"Unexpected error writing Audit Trail entry");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

        }

    }
}
