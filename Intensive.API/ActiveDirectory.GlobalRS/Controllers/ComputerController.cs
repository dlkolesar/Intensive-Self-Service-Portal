using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Intensive.API.Global;
using Intensive.Services.ActiveDirectory;
using Intensive.Services.Auditing;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.CTKAPIWrapper.CTKObjects;
using Intensive.Services.CTKAPIWrapper.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Intensive.API.ActiveDirectory.GlobalRS.Controllers
{
    [ApiController]
    [Route("accounts/{account}/computers")]
    public class ComputerController : ADControllerBase
    {
        const string COMPUTERS_CONTAINER = "CN=Computers,DC=Globalrs,DC=rack,DC=space";

        //DirectoryEntry root;
        AdComputer adComputer;
        AdObjectFactory adObjectFactory;
        AdGroup adGroup;
        AdGroup adAllUsersGroup;
        AdGroup adClustersGroup;
        CTKAPI core;
        DirectoryEntry ComputerContainer;
        DirectoryEntry AccountOU;
        DirectoryEntry TargetOU;

      

        public ComputerController(ILogger<ComputerController> logger,
                                ActiveDirectoryService adsvc,
                                IOptions<AdSystemConfig> adconfig,
                                AdComputer comp,
                                AdObjectFactory f,
                                AdGroup grp,
                                CTKAPI ctk,
                                AuditTrail audsvc) : base(logger, adsvc, adconfig, audsvc)
        {
            this.adComputer = comp;
            this.adObjectFactory = f;
            this.adGroup = grp;
            this.core = ctk;
        }

        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromRoute] int account, [FromQuery]string path, [FromBody]int deviceNumber)
        {
            CTKComputer ctkComputer;
            CTKAccount ctkAccount;
            string acctOU = GetAccountOU(account);

            ///////////////////////////////////////////////////////
            //validation checks
            ///////////////////////////////////////////////////////
            if (account <= 0)
            {
                return BadRequest($"'{account}' is not a valid number");
            }
            if (deviceNumber <= 0)
            {
                return BadRequest($"'{deviceNumber}' is not a device number");
            }


            try
            {
                ctkAccount = new CTKAccount(core, account);
            }
            catch (Exception ex)
            {
                return BadRequest($"'{account}' is not a valid CORE account number");
            }

            try
            {
                List<string> attr = new List<string>() { "is_cluster" };
                ctkComputer = new CTKComputer(core, deviceNumber, attr);
            }
            catch (Exception ex)
            {
                return BadRequest($"'{deviceNumber}' is not a valid CORE device number");
            }

            /////////////////////////////////////////////////////////////////////////
            //Connect to AD forest root  to search for existing computer objects
            /////////////////////////////////////////////////////////////////////////
            try
            {
                ad.Connect(COMPUTERS_CONTAINER, null);
                ComputerContainer = ad.DirectoryRoot;  //Save the ComputerContainer for a search later
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            /////////////////////////////////////////////////////////////////////////
            //try to load the account OU
            /////////////////////////////////////////////////////////////////////////
            try
            {
                ad.Connect(acctOU, null);
                AccountOU = ad.DirectoryRoot;   //save the AccountOU root for later operations
            }
            catch (ADNotFoundException nf)
            {
                return NotFound("Account OU not found");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            /////////////////////////////////////////////////////////////////////////
            //try to load the Target OU to create the object in
            /////////////////////////////////////////////////////////////////////////
            string oupath = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    oupath = acctOU;
                    TargetOU = AccountOU; //already connected to Account OU
                }
                else
                {
                    oupath = path;
                    ad.Dispose();   
                    ad.Connect(path, null);
                    TargetOU = ad.DirectoryRoot;
                }
            }
            catch (ADNotFoundException nf)
            {
                return NotFound("Target OU not found");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }


            try
            {
                adAllUsersGroup = adObjectFactory.CreateGroup();
                adAllUsersGroup.Load(AccountOU, $"{account}-AllUsers");

                adClustersGroup = adObjectFactory.CreateGroup();
                adClustersGroup.Load(AccountOU, $"{account}-Clusters");
            }
            catch (Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unexpected error loading AllUsers and/or Clusters groups: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            /////////////////////////////////////////////////////////////////////////
            // Create the computer object(s) in the Target OU
            /////////////////////////////////////////////////////////////////////////

            string hostName = string.Empty;
            try
            {
                if (Convert.ToInt32(ctkComputer.Properties["is_cluster"]) == 1)
                {
                    List<AdComputer> computers = CreateClusterObjects(ctkComputer.Number); //creates all cluster and physical devices associated with this device number
                    audit.Detail = string.Join(", ", computers.Select(c => c.Name).ToArray());
                    hostName = computers.First().Name;  //used in the returned URL
                }
                else
                {
                    
                    adComputer = CreateComputerObject(ctkComputer.Number);
                    hostName = adComputer.Name; //also used in the returned URL
                    audit.Detail = hostName;
                } 
            }
            catch(Exception ex)
            {
                APIError err = new APIError(ex, 11000, $"Unexpected error creating computer object(s): {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            try
            {
                audit.UserId = User.Claims.FirstOrDefault(c => c.Type == "sso").Value;
                audit.Action = "Create Computer Object";
                audit.Account = account;
                audit.SystemId = config.SystemId;
                audit.DeviceNumber = ctkComputer.Number;
                audit.TimeStamp = DateTime.UtcNow;
                await audit.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"The computer object was successfully created/moved into the Account OU.  However, an unexpected error occurred writing the Audit Trail entry");
            }

            Uri url = new Uri($"{Request.Scheme}://{Request.Host}{Request.PathBase}{Request.Path}/{hostName}");

            return Created(url, null);
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult Get([FromRoute] int account, [FromQuery]string path, [FromQuery]string filter)
        {
            
            ///////////////////////////////////////////////////////
            //validation checks
            ///////////////////////////////////////////////////////
            if (account <= 0)
            {
                return BadRequest($"'{account}' is not a valid number");
            }

            if (string.IsNullOrEmpty(filter))
            {
                filter = "name=*";
            }

            //validate path, if not empty, is for this account
            if (!string.IsNullOrEmpty(path))
            {
                if (!PathMatchesAccount(account, path))
                {
                    return BadRequest($"'{path}' is not a valid DN for account {account}");
                }
            }


            /////////////////////////////////////////////////////////////////////////
            //try to load the Account OU/path to search
            /////////////////////////////////////////////////////////////////////////
            
            string oupath = string.Empty;
            try
            {
                oupath = (string.IsNullOrEmpty(path)) ? GetAccountOU(account) : path;
                
                ad.Connect(oupath, null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound("Account OU/path not found");
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                ex.Data.Add("path", path);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            /////////////////////////////////////////////////////////////////////////
            // search the account/OU recursively for computers matching the filter
            /////////////////////////////////////////////////////////////////////////
            try
            {
                List<AdComputer> computers = adComputer.Find(ad.DirectoryRoot, filter);
                foreach (AdComputer c in computers)
                {
                    resourceURL = $"{Request.Scheme}://{Request.Host}{Request.PathBase}{Request.Path}/{c.Name}";
                    results.Resources.Add(resourceURL);
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                ex.Data.Add("filter", filter);
                ex.Data.Add("path", path);
                APIError err = new APIError(ex, 11999, $"Unexpected error searching for computer that match '{filter}'");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            return Ok(results);
        }

        [AllowAnonymous]
        [HttpGet("{name}")]
        public IActionResult GetComputer([FromRoute] int account, [FromRoute]string name, [FromQuery] string attributes)
        {
            string acctDN = $"{GetAccountOU(account)}";

            ///////////////////////////////////////////////////////
            //validation checks
            ///////////////////////////////////////////////////////
            if (account <= 0)
            {
                return BadRequest($"'{account}' is not a valid number");
            }

            /////////////////////////////////////////////////////////////////////////
            //try to load the Account OU/path to search
            /////////////////////////////////////////////////////////////////////////
            try
            {
                ad.Connect(acctDN, null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound("Account OU/path not found");
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            int devnum = -1;
            log.LogDebug($"parsing {name} for device number...");
            if (Int32.TryParse(name, out devnum))
            {
                log.LogDebug($"devicenumber found: {devnum}");
                name = GetComputerName(devnum);
            }

            try
            {
                log.LogDebug($"Loading computer {name}...");
                if (string.IsNullOrEmpty(attributes))
                {
                    if (name.ToLower().StartsWith("cn="))
                    {
                        adComputer.LoadDN(ad.DirectoryRoot, name);
                    }
                    else
                    {
                        adComputer.Load(ad.DirectoryRoot, name);
                    }
                }
                else
                {
                    List<string> AttrList = attributes.Split(new char[] { ',' }).ToList<string>();
                    if (name.ToLower().StartsWith("cn="))
                    {
                        adComputer.LoadDN(ad.DirectoryRoot, name, AttrList);
                    }
                    else
                    {
                        adComputer.Load(ad.DirectoryRoot, name, AttrList);
                    }
                }
                return Ok(adComputer);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound(nf.Message);
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                ex.Data.Add("name", name);
                ex.Data.Add("attributes", attributes);
                APIError err = new APIError(ex, 11999, $"Unable to load computer data for {name}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        //[AllowAnonymous]
        //[HttpGet("{deviceNumber}")]
        //public IActionResult GetComputerByDeviceNumber([FromRoute] int account, [FromRoute]int deviceNumber, [FromQuery] string attributes)
        //{
        //    CTKComputer ctkComputer;

        //    /////////////////////////////////////////////////////////////////////////
        //    // Get the Computer Name from CORE
        //    // Call GetComputer with the name from CORE
        //    /////////////////////////////////////////////////////////////////////////
        //    try
        //    {
        //       //List<string> attr = new List<string>() { "is_cluster" };
        //        ctkComputer = new CTKComputer(core, deviceNumber);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"'{account}' is not a valid CORE device number");
        //    }

        //    return this.GetComputer(account, ctkComputer.Name, attributes);
        //}


        [Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        [HttpDelete("{name}")]
        public IActionResult DeleteComputer([FromRoute] int account, [FromRoute]string name)
        {
            string acctDN = $"{GetAccountOU(account)}";

            ///////////////////////////////////////////////////////
            //validation checks
            ///////////////////////////////////////////////////////
            if (account <= 0)
            {
                return BadRequest($"'{account}' is not a valid number");
            }

            /////////////////////////////////////////////////////////////////////////
            //try to load the Account OU/path to search
            /////////////////////////////////////////////////////////////////////////
            try
            {
                ad.Connect(acctDN, null);
            }
            catch (ADNotFoundException nf)
            {
                return NotFound("Account OU/path not found");
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }

            int devnum = -1;
            log.LogDebug($"parsing {name} for device number...");
            if (Int32.TryParse(name, out devnum))
            {
                log.LogDebug($"devicenumber found: {devnum}");
                name = GetComputerName(devnum);
            }

            try
            {

                if (name.ToLower().StartsWith("cn="))
                {
                    adComputer.LoadDN(ad.DirectoryRoot, name);
                }
                else
                {
                    adComputer.Load(ad.DirectoryRoot, name);
                }

                adComputer.Delete();
                return NoContent();
 
            }
            catch (ADNotFoundException nf)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                ex.Data.Add("account", account);
                ex.Data.Add("name", name);
                APIError err = new APIError(ex, 11999, $"Unexpected error deleting computer {name}: {ex.Message}");
                log.LogError(err.ErrorCode, err.FormattedException());
                return new ServerError(err);
            }
        }

        //[Authorize(Policy = "Default", AuthenticationSchemes = "RackspaceIdentityHandler")]
        //[HttpDelete("{deviceNumber}")]
        //public IActionResult DeleteComputerByDeviceNumber([FromRoute] int account, [FromRoute]int deviceNumber)
        //{
        //    CTKComputer ctkComputer;

        //    /////////////////////////////////////////////////////////////////////////
        //    // Get the Computer Name from CORE
        //    // Call DeleteComputer with the name from CORE
        //    /////////////////////////////////////////////////////////////////////////
        //    try
        //    {
        //        List<string> attr = new List<string>() { "is_cluster" };
        //        ctkComputer = new CTKComputer(core, deviceNumber);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"'{account}' is not a valid CORE device number");
        //    }

        //    return this.DeleteComputer(account, ctkComputer.Name);
        //}


        //[AllowAnonymous]
        //[Route("{name}/groups")]
        //[HttpGet]
        //public IActionResult GetComputerGroups([FromRoute] int account, [FromRoute] string name)
        //{
        //    string acctDN = $"{GetAccountOU(account)}";
        //    try
        //    {
        //        ad.Connect(acctDN, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("account", account);
        //        ex.Data.Add("name", name);
        //        APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainFQDN} Active Directory domain");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }


        //    int devnum = -1;
        //    log.LogDebug($"parsing {name} for device number...");
        //    if (Int32.TryParse(name, out devnum))
        //    {
        //        log.LogDebug($"devicenumber found: {devnum}");
        //        name = GetComputerName(devnum);
        //    }

        //    try
        //    {

        //        List<string> AttrList = new List<string> { "memberof" };

        //        adComputer.Load(ad.DirectoryRoot, name, AttrList);
        //        List<string> grps = new List<string>();
        //        object memberof = adComputer.Attributes["memberof"];
        //        if (memberof is string)
        //        {
        //            log.LogDebug($"memberof is a string");
        //            grps.Add(memberof as string);
        //        }
        //        else
        //        {
        //            grps = adComputer.Attributes["memberof"] as List<string>;
        //        }

        //        results = new APICollection();
        //        string[] parts;
        //        string grpName;
        //        string domain;

        //        foreach (string g in grps)
        //        {
        //            log.LogDebug($"parsing group {g}");
        //            parts = g.Split(new char[] { ',' });
        //            grpName = parts[0].Substring(3); //strip off the "cn="  at the beginning

        //            log.LogDebug($"extracting domain name...");
        //            domain = parts.First(s => s.ToUpper().StartsWith("DC=")).Substring(3);
        //            resourceURL = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/groups/{grpName}";
        //            results.Resources.Add(resourceURL);
        //        }

        //        return Ok(results);
        //    }
        //    catch (ADNotFoundException nf)
        //    {
        //        return NotFound();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Data.Add("account", account);
        //        ex.Data.Add("name", name);
        //        APIError err = new APIError(ex, 11999, $"Unexpected error getting the groups that computer {name} is a member of");
        //        log.LogError(err.ErrorCode, err.FormattedException());
        //        return new ServerError(err);
        //    }
        //}



        //helper methods

        //private void CreateComputerObject(CTKComputer ctkComputer, int account, bool enabled=true)

        private AdComputer CreateComputerObject(int deviceNumber, bool enabled = true, bool isCluster=false)
        {
            
            AdComputer adcomputer = adObjectFactory.CreateComputer();

            string hostName = GetComputerName(deviceNumber);
            bool computerAlreadyExists = false;
   

            try
            {
                adcomputer.Load(AccountOU, hostName); //see if the computer object already exists in the account OU structure
                computerAlreadyExists = true;
            }
            catch (ADNotFoundException nf)
            {
                //swallow this exception and execute next code to create new computer object(s)
            }
            catch (Exception ex)
            {
                throw;
            }



            // if the computer account already exists in the account OU
            //  skip ahead to group memberships
            // otherwise
            //  search the Computers container for the computer account
            //  if found, move it into the Account OU
            if (!computerAlreadyExists) 
            {
                try
                {
                    log.LogDebug($"Searching for Computer object in Computers container...");
                    adcomputer.Load(ComputerContainer, hostName);
                    log.LogDebug($"Computer object already exists for {hostName}.  Moving to account OU");
                    adcomputer.MoveTo(TargetOU);
                }
                catch (ADNotFoundException nf)  //not found in the Computers container either.  Create a new computer object in the Account OU
                {
                    log.LogDebug($"Creating Computer object {hostName} in {TargetOU.Path}");
                    adcomputer.Create(TargetOU, hostName, enabled);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            //add the new computer object to AllUsers or Clusters group
            try
            {
                if (isCluster)
                {
                    adClustersGroup.AddMember(adcomputer.DN);
                }
                else
                {
                    adAllUsersGroup.AddMember(adcomputer.DN);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error adding the computer object to AllUSers/Cluster group: {ex.Message}");
            }

            return adcomputer;
        }

        private List<AdComputer> CreateClusterObjects(int deviceNumber)
        {
            log.LogDebug($"Creating cluster and node objects for cluster {deviceNumber}");
            /////////////////////////////////////////////////////////////////////////
            // Get cluster data from CORE
            /////////////////////////////////////////////////////////////////////////

            //CTKCluster cluster = new CTKCluster(core, deviceNumber);
            CTKCluster cluster = GetCluster(core, deviceNumber);
            List<AdComputer> clusterMembers = new List<AdComputer>();

            /////////////////////////////////////////////////////////////////////////
            // Create computer objects for each CORE device in the cluster set
            /////////////////////////////////////////////////////////////////////////

            foreach (int dev in cluster.ClusterDevices)
            {
                adComputer = CreateComputerObject(dev, false, true); 
                clusterMembers.Add(adComputer);
            }

            //create physical nodes objects
            foreach (int dev in cluster.PhysicalNodes)
            {
                adComputer = CreateComputerObject(dev, true, true); 
                clusterMembers.Add(adComputer);
            }
            return clusterMembers;
        }

        private CTKCluster GetCluster(CTKAPI instance, int deviceNumber)
        {
            log.LogDebug($"[GetCluster]");
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"class\":\"DevContainer.DeviceContents\",");
            sb.Append("\"load_method\":\"loadList\",");
            sb.Append($" \"load_arg\":{{\"server\":{deviceNumber}}},");
            sb.Append("\"attributes\":[\"container.id\", \"container.name\",\"container.connected_servers.number\", \"container.contents.server.number\"]");
            sb.Append("}");
            string json = sb.ToString();

            log.LogDebug($"\trequest: {JsonConvert.SerializeObject(json)}");

            CTKResponse resp = instance.Submit(json);
            log.LogDebug($"\tctkResponse: {JsonConvert.SerializeObject(resp)}");

            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            log.LogDebug($"\tctkResults: {JsonConvert.SerializeObject(rd)}");

            if (rd.Count == 0)
            {
                throw new CTKNotFoundException($"Device {deviceNumber} is not a cluster or was not found in CORE");
            }
            CTKCluster ctkCluster = new CTKCluster();
            ctkCluster.Id = Convert.ToInt32(rd[0]["container.id"]);
            ctkCluster.Name = rd[0]["container.name"].ToString();
            //int[] arr = (int[])rd[0]["container.connected_servers.number"];
            JArray ja = JArray.Parse(rd[0]["container.connected_servers.number"].ToString());
            int[] arr = ja.Select(jv => (int)jv).ToArray();
            ctkCluster.PhysicalNodes.AddRange(arr);

            //arr = (int[])rd[0]["container.contents.server.number"];
            ja = JArray.Parse(rd[0]["container.contents.server.number"].ToString());
            arr = ja.Select(jv => (int)jv).ToArray();
            ctkCluster.ClusterDevices.AddRange(arr);

            log.LogDebug($"[GetCluster] END");
            return ctkCluster;
        }


        private string GetComputerName(int deviceNumber)
        {
            CTKComputer ctkComputer = new CTKComputer(core, deviceNumber, new List<string>() { "is_cluster" });
            return GetComputerName(ctkComputer.Name);
        }

        private string GetComputerName(string fqdn)
        {
            string name = string.Empty;
            int i = fqdn.IndexOf('.');
            if (i == -1)
            {
                name = fqdn;
            }
            else
            {
                name = fqdn.Substring(0, i);
            }
            return name;
        }

    
    }
}
