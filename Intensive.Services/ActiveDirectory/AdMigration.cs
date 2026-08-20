using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Intensive.Data.SSDatabase;
using Intensive.Data.ADMT;
//using Microsoft.Management.Infrastructure.Options;
//using System.Security;
//using Microsoft.Management.Infrastructure;
using Newtonsoft.Json;
using System;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.CTKAPIWrapper.CTKObjects;
using Intensive.Services.CTKAPIWrapper.Exceptions;
using System.Text.RegularExpressions;

namespace Intensive.Services.ActiveDirectory
{
    public enum CimProcessState
    {
        Unknown = 0,
        Other,
        Ready,
        Running,
        Blocked,
        Suspended_Blocked,
        Suspended_Ready,
        Terminated,
        Stopped,
        Growing
    }
    public class AdMigration
    {
        private ILogger<AdMigration> log;
        private AdSystemConfig config;
        private ADMTConfig admtConfig;
        //private ADMTContext admtDB;
        private SSDatabaseContext db;
        private AdObject adObject;

        private AdMigrationHistory status;
        CTKAPI core;

        //private SSDatabaseDBContextFactory ssDbFactory;

        //private string cmdLine = @"C:\Windows\ADMT\admt.exe";
        //private string cmdLine = @"C:\Windows\ADMT\admt.exe user /n 3014275-testc /sd:lon.intensive.int /sdc:674153-londc41.lon.intensive.int /td:globalrs.rack.space /tdc:674157-gbldc40.globalrs.rack.space";
        //private string workDir = @"C:\Windows\ADMT\";
        //string admtConnectionString = "server=184.106.51.37;Initial Catalog=ADMT; Integrated Security=True; Connect Timeout=30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //string admtConnectionString = "server=162.13.225,38;Initial Catalog=ADMT; Integrated Security=True; Connect Timeout=30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //string admtConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADMT; Integrated Security=True; Connect Timeout=30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public AdMigration(ILogger<AdMigration> logger,
                            IOptions<AdSystemConfig> adconfig,
                            IOptions<ADMTConfig> admtconfig,
                            //ADMTDBContextFactory admt,
                            SSDatabaseContext dbcontext,
                            AdObject adobject,
                            AdMigrationHistory admtHistory,
                            CTKAPI ctk
            )
        {
            log = logger;
            config = adconfig.Value;
            admtConfig = admtconfig.Value;
            //admtDB = admt.Create(admtConfig.Database); //create DB Context
            db = dbcontext;
            adObject = adobject;
            status = admtHistory;
            core = ctk;
        }

        //public async Task<int> MigrateUsers(AdMigrationRequest request)
        //{
        //    StringBuilder sbCmdLine = new StringBuilder(this.cmdLine);  //start with base admt cmdline
        //    sbCmdLine.Append(" user /n");

        //    foreach (AdUser o in request.Objects)
        //    {
        //        sbCmdLine.Append(" \"");
        //        sbCmdLine.Append(o.UserId);
        //        sbCmdLine.Append(" \"");
        //    }
        //    int x = await StartADMT(config.ADMTServer, sbCmdLine.ToString(), request);
        //    return x;
        //}
        //public async Task<int> MigrateGroups(AdMigrationRequest request)
        //{
        //    StringBuilder sbCmdLine = new StringBuilder(this.cmdLine);  //start with base admt cmdline
        //    sbCmdLine.Append(" group /n");

        //    foreach (AdGroup o in request.Objects)
        //    {
        //        sbCmdLine.Append(" \"");
        //        sbCmdLine.Append(o.Name);
        //        sbCmdLine.Append(" \"");
        //    }
        //    int x = await StartADMT(config.ADMTServer, sbCmdLine.ToString(), request);
        //    return x;
        //}

        //public async Task<int> MigrateComputers(AdMigrationRequest request)
        //{
        //    StringBuilder sbCmdLine = new StringBuilder(this.cmdLine);  //start with base admt cmdline
        //    sbCmdLine.Append(" computer /n");

        //    foreach (AdUser o in request.Objects)
        //    {
        //        sbCmdLine.Append(" \"");
        //        sbCmdLine.Append(o.Name);
        //        sbCmdLine.Append(" \"");
        //    }
        //    int x = await StartADMT(config.ADMTServer, sbCmdLine.ToString(), request);
        //    return x;
        //}


        //public async Task MigrateObjectsAync(DirectoryEntry root, AdMigrationRequest request)
        public async Task MigrateObjects(DirectoryEntry root, int account, List<AdObject> sourceObjects, AdObject targetOU, string submittedBy)
        {
            //List<AdObject> sourceObjects = LoadObjects(root, request.Objects);
            
            IEnumerable<IGrouping<string, AdObject>> grpObjects;


            List<AdObject> UserObjects = new List<AdObject>();
            List<AdObject> GroupObjects = new List<AdObject>();
            List<AdObject> ComputerObjects = new List<AdObject>();

            log.LogDebug($"==>TotalObjects: {sourceObjects.Count}");

            UserObjects = sourceObjects.Where(o => o.IsUser).ToList<AdObject>();
            log.LogDebug($"==>UserObjects: {UserObjects.Count}");

            GroupObjects = sourceObjects.Where(o => o.IsGroup).ToList<AdObject>();
            log.LogDebug($"==>GroupObjects: {GroupObjects.Count}");

            ComputerObjects = sourceObjects.Where(o => o.IsComputer).ToList<AdObject>();
            log.LogDebug($"==>ComputerObjects: {ComputerObjects.Count}");

            log.LogDebug($"==>TargetOU: {targetOU.DN}");

            //if any groups are selected for migration, migrate them first
            //run the migration synchronously to make sure all groups are migrated
            //before migrating any user objects.

            if (GroupObjects.Count > 0)
            {
                log.LogDebug($"==>Grouping Groups by Domain Name(s)");
                grpObjects = GroupObjects.GroupBy(o => o.DomainName);
                List<Task> grpTasks = new List<Task>();
                Task grpTask;

                foreach (IGrouping<string, AdObject> src in grpObjects) //i.e., foreach domain grouping
                {
                    //StartADMT(account, src.Key.ToUpper(), "group",  src.ToList<AdObject>(), targetOU, submittedBy);
                    await WriteADMTStatusAsync(account, src.Key.ToLower(), string.Empty, "group", targetOU, src.ToList<AdObject>(), submittedBy);
                }
            }


            //if any user objects are selected, migrate them AFTER all groups have been migrated
            if (UserObjects.Count > 0)
            {
                log.LogDebug($"==>Grouping Users by Domain Name(s)");
                grpObjects = UserObjects.GroupBy(o => o.DomainName);
                
                foreach (IGrouping<string, AdObject> src in grpObjects)//i.e., foreach domain grouping
                {
                    //StartADMT(account, src.Key.ToUpper(), "user", src.ToList<AdObject>(), targetOU, submittedBy);
                    await WriteADMTStatusAsync(account, src.Key.ToLower(), string.Empty, "user", targetOU, src.ToList<AdObject>(), submittedBy);
                }
                
            }

            

            if (ComputerObjects.Count > 0)
            {
                log.LogDebug($"==>Grouping Computers by Domain Name(s)");
                grpObjects = ComputerObjects.GroupBy(o => o.DomainName);

                foreach (IGrouping<string, AdObject> src in grpObjects)//i.e., foreach domain grouping
                {
                    if (src.Key.ToLower() == "intensive") //or intensive.int??
                    {
                        await MigrateIntensiveComputers(account,targetOU, src.ToList<AdObject>(), submittedBy);
                    }
                    await WriteADMTStatusAsync(account, src.Key.ToLower(), string.Empty, "computer", targetOU, src.ToList<AdObject>(), submittedBy);
                }

            }
        }

        //public void Save(int acct, int taskid)
        //{
        //    TbAdmigrations migration = new TbAdmigrations();
        //    migration.Account = acct;
        //    migration.TaskId = taskid;
        //    db.TbAdmigrations.Add(migration);
        //    int x = admtDB.SaveChanges();
        //}

        //public async Task SaveAsync(int acct, int taskid)
        //{
        //    TbAdmigrations migration = new TbAdmigrations();
        //    migration.Account = acct;
        //    migration.TaskId = taskid;
        //    await db.TbAdmigrations.AddAsync(migration);
        //    int x = await db.SaveChangesAsync();
        //}


        //private async Task<int> StartADMT(string admtServer, string admtCommand, AdMigrationRequest admtRequest)
        //private void StartADMT(string admtServer, string admtCommand, AdMigrationRequest admtRequest)
        //{
        //    SecureString pwd = new SecureString();
        //    foreach (char ch in "wtq9wBitM3DJ#") { pwd.AppendChar(ch); }

        //    CimCredential creds = new CimCredential(PasswordAuthenticationMechanism.Default,"globalrs","pes-globalrs" ,pwd);

        //    //CimSessionOptions opts = new CimSessionOptions();
        //    //opts.AddDestinationCredentials(creds);

        //    WSManSessionOptions opts = new WSManSessionOptions();
        //    opts.AddDestinationCredentials(creds);
        //    opts.UseSsl = true;
        //    CimSession remoteSession = CimSession.Create(admtServer, opts);

        //    CimClass cimClass = remoteSession.GetClass("root\\cimv2", "Win32_Process");
        //   log.LogDebug($"Retrieved Win32_Process CLASS");

        //    CimInstance Win32_ProcessStartup = new CimInstance("Win32_ProcessStartup", "root\\cimv2");
        //   log.LogDebug($"retrivied Win32_ProcessStartup INSTANCE");

        //    CimMethodDeclaration method = cimClass.CimClassMethods["Create"];

        //    bool isStatic = method.Qualifiers["static"] != null;

        //    CimMethodParametersCollection args = new CimMethodParametersCollection();
        //    //CimMethodParameter param;

        //    //foreach (CimMethodParameterDeclaration p in method.Parameters)
        //    //{
        //    //    param = CimMethodParameter.Create(p.Name, null, p.CimType,);
        //    //    args.Add(param);
        //    //    //Console.WriteLine($"name:{p.Name} [{p.CimType}]");
        //    //}

        //    //args["CommandLine"].Value = $"{admtCommand} {admtRequest.Options}"; //append
        //    //args["CurrentDirectory"].Value = workDir;
        //    //args["ProcessStartupInformation"].Value = Win32_ProcessStartup;

        //    //args.Add(CimMethodParameter.Create("CommandLine",
        //    //                                    $"{admtCommand} {admtRequest.Options}",
        //    //                                    CimFlags.In));


        //    //args.Add(CimMethodParameter.Create("CommandLine",
        //    //                                    "c:\\Windows\\notepad.exe",
        //    //                                    CimFlags.In));

        //    args.Add(CimMethodParameter.Create("CommandLine",
        //                                        "c:\\Windows\\system32\\cmd.exe /k whoami",
        //                                        CimFlags.In));

        //    args.Add(CimMethodParameter.Create("CurrentDirectory",
        //                                        workDir,
        //                                        CimFlags.In));
        //    args.Add(CimMethodParameter.Create("ProcessStartupInformation",
        //                                        null,
        //                                        CimType.Instance,
        //                                        CimFlags.In | CimFlags.NullValue
        //                                       ));
        //    //args.Add(CimMethodParameter.Create("ProcessId",
        //    //                                   null,
        //    //                                   CimType.UInt32,
        //    //                                   CimFlags.Out));

        //    //args.Add(param);


        //    //CimInstance cimProcess = new CimInstance(cimClass);


        //    //invoke the ADMT process remotely via WMI
        //    //CimMethodResult result = remoteSession.InvokeMethod(cimProcess, "Create", args);
        //   log.LogDebug($"Invoking {args["CommandLine"]}");
        //    CimMethodResult result = remoteSession.InvokeMethod("root\\cimv2", "Win32_Process", "Create", args);
        //   log.LogDebug($"==> Results: rc={result.ReturnValue}");

        //    int rc = Convert.ToInt32(result.ReturnValue.Value);


        //    // return codes documented at
        //    // https://docs.microsoft.com/en-us/windows/desktop/cimwin32prov/create-method-in-class-win32-process#return-value

        //    if (rc == 0)
        //    {
        //        int ProcessId = Convert.ToInt32(result.OutParameters["ProcessId"]);
        //       log.LogDebug($"==> Results: pid={ProcessId}");
        //    }

        //    result.Dispose();
        //    Win32_ProcessStartup.Dispose();
        //    cimClass.Dispose();

        //    remoteSession.Dispose();
        //}


        //private async void StartADMT(int account, string sourceDomain, string migrationType, List<AdObject> sourceObjects, AdObject targetOU, string submittedBy)
        //{
        //    log.LogDebug($"==>Starting ADMT....");
        //    //string p = "wtq9wBitM3DJ#";
        //    //string cmdLine = @"C:\Windows\ADMT\admt.exe user /n 3014275-testc /sd:lon.intensive.int /sdc:674153-londc41.lon.intensive.int /td:globalrs.rack.space /tdc:674157-gbldc40.globalrs.rack.space";
        //    // exec ADMT Wrapper utility

        //    //string workDir = @"C:\ADMTWrapper\";
        //    //string cmdLine = @"C:\ADMTWrapper\ADMTWrapper.exe";


        //    //cmdline input can only be 8191 bytes long
        //    //may need logic to split long cmds into multiple cmds

        //    string workDir = admtConfig.Path;
        //    //string cmdLine = $"[{sourceDomain}]{workDir}\\{admtConfig.ExeName} {account} {BuildADMTArguments(sourceDomain,sourceObjects, targetOU)}";

        //    log.LogDebug($"==>Build Command line - initial");

        //    List<string> cmds = BuildCommandLine(account, sourceDomain, migrationType, sourceObjects, targetOU);

        //    foreach (string cmd in cmds)
        //    {
        //        log.LogDebug($"==> cmdLine({cmd.Length}): {cmd}");

        //    }

        //    //return Task.CompletedTask;

        //    try
        //    {
        //        //CimSessionOptions opts = new CimSessionOptions();
        //        WSManSessionOptions opts = new WSManSessionOptions();


        //        log.LogDebug($"admtConfig: {JsonConvert.SerializeObject(admtConfig)}");
        //        SecureString pwd = new SecureString();

        //        foreach (char ch in admtConfig.AdminPassword)
        //        {
        //            pwd.AppendChar(ch);
        //        }

        //        CimCredential creds = new CimCredential(PasswordAuthenticationMechanism.Negotiate, "globalrs", admtConfig.AdminUser, pwd);

        //        opts.AddDestinationCredentials(creds);

        //        log.LogDebug($"Creating remote CIM Session on ADMT Server {admtConfig.ADMTServers[sourceDomain]} ...");

        //        CimSession remoteSession = CimSession.Create(admtConfig.ADMTServers[sourceDomain], opts);

        //        foreach (string cmd in cmds)
        //        {
        //            try
        //            {
        //                log.LogDebug($"Building remote process..");

        //                CimMethodParametersCollection args = new CimMethodParametersCollection();

        //                args.Add(CimMethodParameter.Create("CommandLine",
        //                                                    cmd,
        //                                                    CimFlags.In));

        //                args.Add(CimMethodParameter.Create("CurrentDirectory",
        //                                                    workDir,
        //                                                    CimFlags.In));

        //                args.Add(CimMethodParameter.Create("ProcessStartupInformation",
        //                                                    null,
        //                                                    CimType.Instance,
        //                                                    CimFlags.In | CimFlags.NullValue
        //                                                   ));

        //                //invoke the ADMT process remotely via WMI
        //                log.LogDebug($"invoking {sourceDomain} remote process {cmd}");

        //                //CimMethodResult result = remoteSession.InvokeMethod("root\\cimv2", "Win32_Process", "Create", args);

        //                // return codes documented at
        //                // https://docs.microsoft.com/en-us/windows/desktop/cimwin32prov/create-method-in-class-win32-process#return-value

        //                //if (Convert.ToInt32(result.ReturnValue.Value) == 0)
        //                //{
        //                    //split into 3 parts
        //                    // ADMTWrapper command exe
        //                    // Guid for the command
        //                    // the remaining arguments to be passed to ADMT.EXE
        //                    string[] tmp = cmd.Split(new char[] { ' ' }, 3);
        //                    log.LogDebug($"cmd Split: {JsonConvert.SerializeObject(tmp)}");
        //                    await WriteADMTStatusAsync(tmp[1], account, sourceDomain, migrationType, targetOU, submittedBy);
        //                //}
        //                //else
        //                //{
        //                //    log.LogDebug($"InvokeMethod Failed: {JsonConvert.SerializeObject(result)}");
        //                //}

        //                //result?.Dispose();
        //            }
        //            catch(CimException cimex)
        //            {
        //                log.LogDebug($"CIMException: {JsonConvert.SerializeObject(cimex)}");
        //                continue;
        //            }
        //            catch(Exception ex)
        //            {
        //                log.LogDebug($"Generic Exception: {JsonConvert.SerializeObject(ex)}");
        //                continue;
        //            }
        //        }//foreach

        //        remoteSession?.Close();
        //        remoteSession?.Dispose();
        //    }
        //    catch (CimException cimEx)
        //    {
        //        log.LogDebug($"CIMException: {JsonConvert.SerializeObject(cimEx)}");
        //    }
        //}


        //**************************
        //** 
        //** Recursive function
        //**
        //** if cmdline arguments > 8191 bytes
        //** split the list of sourceobjects in half
        //** and build the cmdline for each half
        //**
        //** repeat until all cmdline args < 8191
        //**
        //***************************

        private async Task MigrateIntensiveComputers(int account, AdObject targetOU, List<AdObject> objects, string submittedBy)
        {
            Dictionary<string, List<AdObject>> ComputersByDC = new Dictionary<string, List<AdObject>>();
            string dc = string.Empty;

            log.LogDebug("Getting Datacenters from CORE...");
            foreach (AdObject c in objects)
            {
                dc = GetComputerDatacenter(account,c.Name); //returned in all CAPS

                if (!ComputersByDC.ContainsKey(dc))
                {
                    ComputersByDC.Add(dc, new List<AdObject>());
                }

                ComputersByDC[dc].Add(c);
            }

            foreach (KeyValuePair<string, List<AdObject>> kvp in ComputersByDC)
            {
                log.LogDebug($"Writing DB entry for intensive.int | {kvp.Key}");
                await WriteADMTStatusAsync(account, "intensive", kvp.Key, "computer", targetOU, kvp.Value, submittedBy);
            }
        }

        private string GetComputerDatacenter(int account, string name)
        {
            string dc = string.Empty;
            int devNumber = 0;
            List<string> attrs = new List<string> { "datacenter.symbol", "account.number" };
            try
            {
                log.LogDebug($"GetComputerDatacenter: {account}: {name}");
                Regex re = new Regex("^\\d*");
                if (re.IsMatch(name))
                {
                    devNumber = Convert.ToInt32(re.Match(name).Value);
                    log.LogDebug($"GetComputerDatacenter: devNumber={devNumber}");
                    CTKComputer coreComputer = new CTKComputer(core, devNumber, attrs);
                    log.LogDebug($"GetComputerDatacenter: coreComputer={JsonConvert.SerializeObject(coreComputer)}");

                    //just in case the leading number(s) match a computer on a different account
                    if (Convert.ToInt32(coreComputer.Properties["account.number"]) == account)
                    {
                        dc = coreComputer.Properties["datacenter.symbol"].ToString();
                    }
                    else
                    {
                        throw new CTKNotFoundException($"device number {devNumber} does not belong to account {account}");
                    }
                }
                else
                {
                    throw new CTKNotFoundException("computer name does not start with device number");
                }
            }
            catch(CTKNotFoundException nf)
            {
                //lookup by device number failed;  try looking up by name
                log.LogDebug($"GetComputerDatacenter: looking up by name...");
                CTKWhere wh = new CTKWhere();
                wh.ClassName = "Computer.Computer";
                wh.Values = new CTKWhereCondition("name", "=", name); //does core do partial match?
                CTKComputer coreComputer = new CTKComputer(core, devNumber, attrs);
                log.LogDebug($"GetComputerDatacenter: coreComputer={JsonConvert.SerializeObject(coreComputer)}");
            }
            catch(Exception ex)
            {
                log.LogError(ex, ex.Message);
                dc = "UNKNOWN";
            }
            return dc.ToUpper();
        }

        private async Task WriteADMTStatusAsync(int account, string domain, string datacenter, string migrationType,  
                                                    AdObject targetOU, List<AdObject> objects, string submittedBy)
        {
            status.ID = Guid.NewGuid();
            status.Account = account;
            status.MigrationType = migrationType;
            status.SourceDomain = (domain=="intensive")?"intensive.int":$"{domain}.intensive.int";
            status.Datacenter = datacenter;
            status.SSO = submittedBy;
            status.Status = "Pending";
            status.Submitted = DateTime.UtcNow;
            status.TargetOU = targetOU.DN;
            status.Objects = objects.Select(o => o.Name).ToList<string>(); //extract the object names from the adObjects
            status.TaskId = -1;
            log.LogDebug($"==>Saving Status: {JsonConvert.SerializeObject(status)}");
            await status.SaveAsync();
        }

       

        private string DN2LdapPath(string dn)
        {

            List<string> path = new List<string>();
            string[] parts = dn.Split(new char[] { ',' });
            string name;
            foreach (string p in parts)
            {
                if ((p.ToLower().StartsWith("ou=")) || (p.ToLower().StartsWith("cn="))  )
                {
                    name = p.Replace("OU=", "");
                    path.Add(name);
                }
            }
            path.Reverse();
            return string.Join("/", path );
        }

    }
}
