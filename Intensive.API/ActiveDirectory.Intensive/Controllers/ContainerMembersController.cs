using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.DirectoryServices;
using Microsoft.AspNetCore.Mvc;
using Intensive.Services.ActiveDirectory;
//using Intensive.Services.eDirectory;

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
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Intensive.API.ActiveDirectory.Intensive.Controllers
{
    [ApiController]
    [Route("containers/{dn}/members")]
    public class ContainerMembersController : ADControllerBase
    {
        AdObject obj;
        AdContainer container;
        AdGroup grp;

        //eDir edir;
        //eDirUser ediruser;

        //private string ldapFilter_AllUsers = "(&(objectCategory=person)(objectClass=user))";
        public ContainerMembersController(ILogger<ContainerMembersController> logger,
                                ActiveDirectoryService adsvc,
                                AdObject adobject,
                                AdGroup adgrp,
                                AdContainer adcontainer,
                                IOptions<AdSystemConfig> adconfig,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            obj = adobject;
            grp = adgrp;
            container = adcontainer;
        }

        [HttpGet]
        public IActionResult Get([FromRoute] string dn)
        {
            return Ok();
        }
    
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public IActionResult Post([FromRoute] string dn, [FromBody] AdObject child)
        {
            try
            {
                ad.Connect();
                log.LogDebug($"connected to {ad.DirectoryRoot.Path}");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
            string sid64 = "AQUAAAAAAAUVAAAA6yV5LA/4YB0H5TsrVWYAAA==";
            byte[] sid = Convert.FromBase64String(sid64);


            grp.LoadDN(ad.DirectoryRoot, "CN=1103359-RAX,OU=1103359,OU=RAX,DC=Globalrs,DC=rack,DC=space", new List<string>() { "member" });
            

            SecurityIdentifier sidObj = new SecurityIdentifier(sid, 0);
            string sidHex = BitConverter.ToString(sid).Replace("-", "");
            log.LogDebug($"sidHex={sidHex}");
            log.LogDebug($"Adding sidHex to group");

            try
            {
                grp.AddMember($"<SID={sidHex}>");//if cross-forest

                //grp.AddMember("CN=Dan Kolesar,OU=CUST,OU=Support,DC=intensive,DC=int"); //if same forest
            }
            catch (Exception ex)
            {
                log.LogError(14999, ex, ex.Message);
                if (ex.InnerException != null)
                {
                    log.LogError(14999, ex, $"***Inner Exception: {ex.Message}");
                }
            }
            

            //log.LogDebug($"Loading container {dn}");



            //container.LoadDN(ad.DirectoryRoot, dn);
            

            //log.LogDebug($"Creating FSP....");
            //container.CreateForeignSecurityPrincipal(sid, "INTENSIVE\\dan5673.cust");

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
