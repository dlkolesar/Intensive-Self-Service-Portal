using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data.SSDatabase;
using Intensive.Services.Patching;
using Intensive.Services.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using Intensive.Data.WSUS;
using System.Net;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Intensive.Services.Patching.Exceptions;

namespace Intensive.Services.Aric
{
    public class AricDataHandlerPatching
    {
        SSDatabaseContext db;

        ILogger<AricDataHandlerPatching> log;
        PatchingClient client;
        //Server server;
        TbServers server;
        AricTimeTable timetable;
        string token;
        AricSystemConfig aricConfig;

        public AricDataHandlerPatching(SSDatabaseContext dbContext,
                                        //Server svr,
                                        //PatchingClient pc,
                                        IOptions<AricSystemConfig> aricConfigData,
                                        AricTimeTable at,
                                        WSUSDBContextFactory wsusFactory,
                                        ILogger<AricDataHandlerPatching> logger)
        {
            this.db = dbContext;
            this.log = logger;
            //this.server = svr;
            //this.client = pc;
            this.timetable = at;
            aricConfig = aricConfigData.Value;
            token = Authenticate();
        }
        //public async Task ProcessDataAsync(AricJob job)
        //{
        //    switch (job.ProcessName.ToLower())
        //    {
        //        case "wap:portal:patchsettingsaudit":
        //            {
        //                ////log.logDebug($"Starting UpdatePatchingClientConfig");
        //                await UpdatePatchingClientConfig(job);
        //                ////log.logDebug($"Finished UpdatePatchingClientConfig");
        //                break;
        //            }
        //        case "wap:portal:patchsettingsconfig":
        //        case "wap:portal:patchsettingsdelete":
        //        case "wap:portal:patchnow":
        //            {
        //                TbAricJob currJob = db.TbAricJob.Single(p => p.EventId == job.EventId);
        //                db.TbAricJob.Remove(currJob);

        //                db.SaveChanges();
        //                break;
        //            }
        //    }
            

        //    //return Task.CompletedTask;
        //}
        //private Task UpdatePatchingClientConfig(AricJob job)
        //public async Task<string> ProcessDataAsync(AricJob job)
        //{
        //    //log.logDebug($"UpdatePatchingClientConfig: Start");
        //    //log.logDebug($"Job: {JsonConvert.SerializeObject(job)}");
        //    string sbDetails = string.Empty;
            
        //    sbDetails = UpdateConfig(job);

        //    //any changes made to the DB?
        //    if (sbDetails.Length > 0)
        //    {
        //        TbServers server = db.TbServers.AsNoTracking().Single(c => c.DeviceNumber == job.DeviceNumber) as TbServers;
        //        //write audit trail entry
        //        //log.logDebug($"Audit: Begin");
        //        //log.logDebug($"Audit: account={server.Account}");
        //        //log.logDebug($"Audit: details={sbDetails}");
        //        TbAuditTrail audit = new TbAuditTrail();
        //        audit.Account = server.Account;
        //        audit.Action = "Pull Config Settings";
        //        audit.Detail = sbDetails.ToString();
        //        audit.DeviceNumber = job.DeviceNumber;
        //        audit.SystemId = job.SystemId;
        //        audit.TimeStamp = DateTime.UtcNow;
        //        audit.UserId = job.UserId;

        //        db.TbAuditTrail.Add(audit);
        //    }

        //    TbAricJob currJob = db.TbAricJob.Single(p => p.EventId == job.EventId);
        //    db.TbAricJob.Remove(currJob);

        //    db.SaveChanges();

        //    return;
        //}

        //private string UpdateConfig(AricJob job)
        //{
        //    //log.logDebug($"UpdateConfig: Start");
        //    //log.logDebug($"Job: {JsonConvert.SerializeObject(job)}");
        //    //PatchingRegistryValues reg = new PatchingRegistryValues(job.ReturnedData);

        //    PatchingRegistryValues reg = Parse(job.ReturnedData);


        //    StringBuilder sbDetails = new StringBuilder();

        //    //log.logDebug($"UpdateConfig: Loading TbServers....");
        //    TbServers server = db.TbServers.Single(c => c.DeviceNumber == job.DeviceNumber) as TbServers;


        //    //log.logDebug($"UpdateConfig: Loading TbPatchingClient....");
        //    TbPatchingClients client = db.TbPatchingClients.Single(c => c.DeviceNumber == job.DeviceNumber) as TbPatchingClients;


        //    //log.logDebug($"UpdateConfig: Loading TbPatchingCLientConfigBasic....");
        //    TbPatchingClientConfigBasic config = db.TbPatchingClientConfigBasic
        //                                                .Single(c => c.DeviceNumber == job.DeviceNumber)
        //                                                        as TbPatchingClientConfigBasic;
        //    string key = string.Empty;


        //    // If any value from the registry is different from what is in the database
        //    // document the change in the Audit trail
        //    key = "HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\SusClientId";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");
        //    log.LogDebug($"     Registry Value: {reg.Registry[key].Value}");
        //    log.LogDebug($"     Server Value: {server.Wsusid.ToString()}");
        //    log.LogDebug($"     Client Value: {client.Wsusid.ToString()}");
        //    if (reg.Registry[key].Exists)
        //    {
        //        //if (server.Wsusid != Guid.Parse(reg.Registry[key].Value))
        //        if (server.Wsusid.ToString() != reg.Registry[key].Value)
        //        {
        //            log.LogDebug($"UpdateConfig: WSUS id has changed");
        //            //sbDetails.AppendLine($"WSUS ID changed from {server.Wsusid} to {Guid.Parse(reg.Registry[key].Value)}");
        //            sbDetails.AppendLine($"WSUS ID changed from {server.Wsusid} to {reg.Registry[key].Value}");
        //            server.Wsusid = Guid.Parse(reg.Registry[key].Value);
        //            client.Wsusid = server.Wsusid;
        //            server.LastRefresh = DateTime.UtcNow;
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    { 
        //        sbDetails.AppendLine($"WSUS ID Error: {reg.Registry[key].ErrorMessages.First()}");
        //        server.Wsusid = Guid.Empty;
        //        client.Wsusid = Guid.Empty;
        //        server.LastRefresh = DateTime.UtcNow;
        //        client.LastRefresh = DateTime.UtcNow;
        //    }

        //    key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\WUServer";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");
        //    if (reg.Registry[key].Exists)
        //    {
        //        if (client.Wuserver != reg.Registry[key].Value)
        //        {
        //            sbDetails.AppendLine($"WSUS Server changed from {client.Wuserver} to {reg.Registry[key].Value}");
        //            client.Wuserver = reg.Registry[key].Value;
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    {
        //        client.Wuserver = "";
        //        client.LastRefresh = DateTime.UtcNow;
        //    }

        //    key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\AUOptions";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");
        //    if (reg.Registry[key].Exists)
        //    {
        //        if (client.Auoptions != Convert.ToInt16(reg.Registry[key].Value))
        //        {
        //            sbDetails.AppendLine($"AUOptions changed from {client.Auoptions} to {Convert.ToInt16(reg.Registry[key].Value)}");
        //            client.Auoptions = Convert.ToInt16(reg.Registry[key].Value);
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    {
        //        client.Auoptions = 0;
        //        client.LastRefresh = DateTime.UtcNow;
        //    }

        //    key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoUpdate";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");

        //    if (reg.Registry[key].Exists)
        //    {
        //        if ((client.PatchingLevel != 0) && (Convert.ToInt16(reg.Registry[key].Value) == 1))
        //        {
        //            sbDetails.AppendLine($"Patching Level changed from {client.PatchingLevel} to  0(NONE)");
        //            client.PatchingLevel = 0;
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    {
        //        client.PatchingLevel = 0;
        //        client.LastRefresh = DateTime.UtcNow;
        //    }


        //    key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\UseWUServer";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");
        //    if (reg.Registry[key].Exists)
        //    {
        //        if (client.UseWuserver != Convert.ToInt16(reg.Registry[key].Value))
        //        {
        //            sbDetails.AppendLine($"UseWUServer changed from {client.UseWuserver} to {Convert.ToInt16(reg.Registry[key].Value)}");
        //            client.UseWuserver = Convert.ToInt16(reg.Registry[key].Value);
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    {
        //        client.UseWuserver = 1;
        //        client.LastRefresh = DateTime.UtcNow;
        //    }

        //    key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoRebootWithLoggedOnUsers";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");
        //    if (reg.Registry[key].Exists)
        //    {
        //        short pulledValue = 0;

        //        switch (reg.Registry[key].Value.ToLower())
        //        {
        //            case "1":
        //            case "true": pulledValue = 1; break;

        //            case "0":
        //            case "false": pulledValue = 0; break;

        //        }

        //        //if (config.NoAutoRebootWithLoggedOnUsers != Convert.ToInt16(reg.Registry[key].Value))
        //        if (config.NoAutoRebootWithLoggedOnUsers != pulledValue)
        //        {
        //            sbDetails.AppendLine($"NoAutoRebootWithLoggedOnUsers changed from {config.NoAutoRebootWithLoggedOnUsers} to {Convert.ToInt16(reg.Registry[key].Value)}");
        //            config.NoAutoRebootWithLoggedOnUsers = Convert.ToInt16(reg.Registry[key].Value);
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    {
        //        config.NoAutoRebootWithLoggedOnUsers = 0;
        //        client.LastRefresh = DateTime.UtcNow;
        //    }

        //    key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallDay";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");
        //    if (reg.Registry[key].Exists)
        //    {
        //        if (config.ScheduledDay != Convert.ToInt16(reg.Registry[key].Value))
        //        {
        //            sbDetails.AppendLine($"ScheduledDay changed from {config.ScheduledDay} to {Convert.ToInt16(reg.Registry[key].Value)}");
        //            config.ScheduledDay = Convert.ToInt16(reg.Registry[key].Value);
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    {
        //        config.ScheduledDay = -1;
        //        client.LastRefresh = DateTime.UtcNow;
        //    }

        //    key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallTime";
        //    log.LogDebug($"UpdateConfig: comparing RegKey {key}");
        //    if (reg.Registry[key].Exists)
        //    {
        //        if (config.ScheduledTime != Convert.ToInt16(reg.Registry[key].Value))
        //        {
        //            sbDetails.AppendLine($"ScheduledTime changed from {config.ScheduledTime} to {Convert.ToInt16(reg.Registry[key].Value)}");
        //            config.ScheduledTime = Convert.ToInt16(reg.Registry[key].Value);
        //            client.LastRefresh = DateTime.UtcNow;
        //        }
        //    }
        //    else
        //    {
        //        config.ScheduledTime = -1;
        //        client.LastRefresh = DateTime.UtcNow;
        //    }

        //    //get WSUS group membership
        //    //get AdvancedPatching by name
        //    //
        //    //set client.ScheduledWeek <== WSUS Group
        //    //
        //    //set   PatchingLevel=0
        //    //      PatchingLevel=1 if client.auoption = 4 or 5
        //    //      PatchingLevel=3 if client.auoptions = 2 or3 
        //    //      PatchingLevel=2 if advPatching found in ARIC and it's enabled
        //    //          Adv.Patching overrides/takes precedence over all other patching levels
        //    //
        //    // put logic into PatchClient??
        //    //      int GetWsusGroup()
        //    //      bool AdvancedPatchingEnabled()

        //    //log.logDebug($"Changes Made:{sbDetails.Length>0}");
        //    log.LogDebug($"UpdateConfig: End");
        //    return sbDetails.ToString();
        //}


        //private string UpdateConfig(AricJob job)
        public async Task<string> ProcessDataAsync(AricJob job, PatchingClient client)
        {
            //log.logDebug($"UpdateConfig: Start");
            //log.logDebug($"Job: {JsonConvert.SerializeObject(job)}");
            //PatchingRegistryValues reg = new PatchingRegistryValues(job.ReturnedData);

            PatchingRegistryValues reg = Parse(job.ReturnedData);


            StringBuilder sbDetails = new StringBuilder();

            log.LogDebug($"[ADHP] Loading Server...");
            //server.Load(job.DeviceNumber);
            server = db.TbServers.SingleOrDefault(s => s.DeviceNumber == job.DeviceNumber);
            //log.LogDebug($"[ADHP] Loading Patching Client...");
            //client.Load(job.DeviceNumber);


            string key = string.Empty;


            // If any value from the registry is different from what is in the database
            // document the change in the Audit trail
            key = "HKLM:\\Software\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\SusClientId";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            log.LogDebug($"     Registry Value: {reg.Registry[key].Value}");
            log.LogDebug($"     Server Value: {server.Wsusid.ToString()}");
            log.LogDebug($"     Client Value: {client.WSUSID.ToString()}");
            if (reg.Registry[key].Exists)
            {
                if ((server.Wsusid.ToString() != reg.Registry[key].Value) || (client.WSUSID.ToString() != reg.Registry[key].Value))
                {
                    log.LogDebug($"UpdateConfig: WSUS id has changed");
                    if (server.Wsusid.ToString() != reg.Registry[key].Value)
                    { 
                        sbDetails.AppendLine($"WSUS ID changed from {server.Wsusid} to {reg.Registry[key].Value}");
                    }
                    else     //client.WSUSID must be different
                    {
                        sbDetails.AppendLine($"WSUS ID changed from {client.WSUSID} to {reg.Registry[key].Value}");
                    }
                    server.Wsusid = string.IsNullOrEmpty(reg.Registry[key].Value) ? Guid.Empty : Guid.Parse(reg.Registry[key].Value);
                    server.LastRefresh = DateTime.UtcNow;
                    client.WSUSID = server.Wsusid;
                    db.SaveChanges();
                }
            }
            else
            {
                //sbDetails.AppendLine($"WSUS ID Error: {reg.Registry[key].ErrorMessages.First()}");
                client.Errors.Add($"WSUS ID Error: {reg.Registry[key].ErrorMessages.First()}");
                server.Wsusid = Guid.Empty;
                client.WSUSID = Guid.Empty;
                server.LastRefresh = DateTime.UtcNow;
                db.SaveChanges();
            }

            key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\WUServer";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            if (reg.Registry[key].Exists)
            {
                if (client.WUServer != reg.Registry[key].Value)
                {
                    sbDetails.AppendLine($"WSUS Server changed from {client.WUServer} to {reg.Registry[key].Value}");
                    client.WUServer = reg.Registry[key].Value;
                }
            }
            else
            {
                client.WUServer = "";
                //client.LastRefresh = DateTime.UtcNow;
            }

            key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\AUOptions";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            if (reg.Registry[key].Exists)
            {
                if (client.AUOptions != Convert.ToInt16(reg.Registry[key].Value))
                {
                    sbDetails.AppendLine($"AUOptions changed from {client.AUOptions} to {Convert.ToInt16(reg.Registry[key].Value)}");
                    client.AUOptions = Convert.ToInt16(reg.Registry[key].Value);
                    //client.LastRefresh = DateTime.UtcNow;
                }
            }
            else
            {
                client.AUOptions = 0;
                //client.LastRefresh = DateTime.UtcNow;
            }

            key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoUpdate";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            bool NoAutoUpdate = false;

            if (reg.Registry[key].Exists)
            {
                NoAutoUpdate = (Convert.ToInt16(reg.Registry[key].Value) == 1);
                if ((client.PatchingLevel != PatchingLevels.None) && (NoAutoUpdate))
                {
                    sbDetails.AppendLine($"Patching Level changed from {client.PatchingLevel} to  0(NONE) because NoAutoUpdate=1");
                    client.PatchingLevel = PatchingLevels.None;
                    //client.LastRefresh = DateTime.UtcNow;
                }
            }
            else
            {
                client.PatchingLevel = PatchingLevels.Basic;
                //client.LastRefresh = DateTime.UtcNow;
            }


            key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\UseWUServer";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            if (reg.Registry[key].Exists)
            {
                if (client.UseWUServer != (Convert.ToInt16(reg.Registry[key].Value) == 1))
                {
                    sbDetails.AppendLine($"UseWUServer changed from {client.UseWUServer} to {Convert.ToInt16(reg.Registry[key].Value) == 1}");
                    client.UseWUServer = Convert.ToInt16(reg.Registry[key].Value) == 1;
                    //client.LastRefresh = DateTime.UtcNow;
                }
            }
            else
            {
                client.UseWUServer = true;
                //client.LastRefresh = DateTime.UtcNow;
            }
            
            key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\NoAutoRebootWithLoggedOnUsers";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            if (reg.Registry[key].Exists)
            {
                short pulledValue = 0;

                switch (reg.Registry[key].Value.ToLower())
                {
                    case "1":
                    case "true": pulledValue = 1; break;

                    case "0":
                    case "false": pulledValue = 0; break;

                }

                //if (config.NoAutoRebootWithLoggedOnUsers != Convert.ToInt16(reg.Registry[key].Value))
                if (client.NoAutoRebootWithLoggedOnUsers != (pulledValue == 1))
                {
                    sbDetails.AppendLine($"NoAutoRebootWithLoggedOnUsers changed from {client.NoAutoRebootWithLoggedOnUsers} to {Convert.ToInt16(reg.Registry[key].Value)}");
                    client.NoAutoRebootWithLoggedOnUsers = (pulledValue == 1);
                    //client.LastRefresh = DateTime.UtcNow;
                }
            }
            else
            {
                client.NoAutoRebootWithLoggedOnUsers = false;
            }

            key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallDay";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            if (reg.Registry[key].Exists)
            {
                if (client.ScheduledDay != Convert.ToInt16(reg.Registry[key].Value))
                {
                    sbDetails.AppendLine($"ScheduledDay changed from {client.ScheduledDay} to {Convert.ToInt16(reg.Registry[key].Value)}");
                    client.ScheduledDay = Convert.ToInt16(reg.Registry[key].Value);
                }
            }
            else
            {
                client.ScheduledDay = -1;
            }

            key = "HKLM:\\Software\\Policies\\Microsoft\\Windows\\WindowsUpdate\\AU\\ScheduledInstallTime";
            log.LogDebug($"UpdateConfig: comparing RegKey {key}");
            if (reg.Registry[key].Exists)
            {
                if (client.ScheduledTime != Convert.ToInt16(reg.Registry[key].Value))
                {
                    sbDetails.AppendLine($"ScheduledTime changed from {client.ScheduledTime} to {Convert.ToInt16(reg.Registry[key].Value)}");
                    client.ScheduledTime = Convert.ToInt16(reg.Registry[key].Value);
                }
            }
            else
            {
                client.ScheduledTime = -1;
            }

            log.LogDebug($"WSUS id: {client.WSUSID.ToString()}");
            if ( (client.WSUSID == null) || (client.WSUSID == Guid.Empty) )
            {
                log.LogDebug($"WSUS id is empty: Unable to check Release Week");
            }
            else
            {
                log.LogDebug($"WUServer: {client.WUServer.ToString()}");
                if (string.IsNullOrEmpty(client.WUServer))
                {
                    log.LogDebug($"WuServer is empty: Unable to check Release Week");
                }
                else
                {
                    try
                    {
                        log.LogDebug($"UpdateConfig: comparing Release Week");
                        int releaseWeek = client.GetWSUSReleaseWeek();

                        log.LogDebug($"UpdateConfig: wsus:{releaseWeek}   db:{client.ScheduledWeek}");

                        if ((releaseWeek > 0) && (client.ScheduledWeek != releaseWeek))
                        {
                            sbDetails.AppendLine($"ScheduledWeek changed from {client.ScheduledWeek} to {releaseWeek}");
                            client.ScheduledWeek = (short?)releaseWeek;
                        }
                    }
                    catch (PatchingWSUSConnectionException pwc) 
                    {
                        client.Errors.Add(pwc.Message);
                    }
                    catch (PatchingWSUSNotFoundException pwnf) 
                    {
                        client.Errors.Add(pwnf.Message);
                    }

                    catch (SqlException sqlex)
                    {
                        log.LogDebug($"*** SQL Exception ***");
                        log.LogError(14999, sqlex, sqlex.Message);
                        client.Errors.Add($"Unable to connect to the WSUS server {client.WUServer} to get current ReleaseWeek");
                    }
                    catch (InvalidOperationException nf)
                    {
                        log.LogDebug($"*** Invalid Operation Exception ***");
                        log.LogError(14999, nf, nf.Message);
                        client.Errors.Add($"WSUS data not found for device {client.DeviceNumber}");
                    }
                }
            }



            log.LogDebug($"UpdateConfig: comparing AuOptions to PatchingLevel");
            //set PatchingLevel = NONE        if NoAutoUpdate = 1
            //      PatchingLevel = BASIC     if auoption = 4 or 5
            //      PatchingLevel = MANUAL    if auoption = 2 or3
            //      PatchingLevel = ADVANCED  if advPatching found in ARIC and it's enabled
            //          Adv.Patching overrides/ takes precedence over all other patching levels
            //
            //      PatchingLevel unchanged if auOption < 2,  > 5, or advPatching data not found

            if (!NoAutoUpdate) // if NoAutoUpdate is not set in registry
            {
                switch (client.AUOptions)
                {
                    case 2:
                    case 3:
                        if (client.PatchingLevel != PatchingLevels.Manual)
                        {
                            sbDetails.AppendLine($"PatchingLevel changed from {client.PatchingLevel} to 3(MANUAL) because AuOption={client.AUOptions}");
                            client.PatchingLevel = PatchingLevels.Manual;
                        }
                        break;

                    case 4:
                    case 5:
                        if (client.PatchingLevel != PatchingLevels.Basic)
                        {
                            sbDetails.AppendLine($"PatchingLevel changed from {client.PatchingLevel} to 1(BASIC) because AuOption={client.AUOptions}");
                            client.PatchingLevel = PatchingLevels.Basic;
                        }
                        break;
                }
            }



            log.LogDebug($"UpdateConfig: Checking ARIC for Adv. Patching schedule...");
            try
            {

                //log.LogDebug($"UpdateConfig: client.AdvancedPatching: {client.AdvancedPatching}");
                //log.LogDebug($"UpdateConfig: client.AdvancedPatching.ID: {client.AdvancedPatching.ID}");
                if (client.AdvancedPatching == null) { client.AdvancedPatching = new PatchingClientAdvancedPatching(); }

                if ((client.AdvancedPatching.ID == null || client.AdvancedPatching.ID == Guid.Empty || client.AdvancedPatching.ProcessName == null))
                {
                    log.LogDebug($"UpdateConfig: Empty ADV Patching Id; searching for pre-existing ARIC Schedule...");
                    Guid id = SearchForAdvancedPatchingId(client.DeviceNumber, token);
                    if (id == Guid.Empty) //no adv patching found
                    {
                        timetable.Enabled = false;
                    }
                    else
                    {
                        client.AdvancedPatching.ID = id;
                        timetable.Load(client.AdvancedPatching.ID, token);
                    }
                }
                else
                {
                    timetable.Load(client.AdvancedPatching.ID, token);
                }

            }
            catch (AricNotFoundException nf)
            {
                timetable.Enabled = false;

            }

            log.LogDebug($"UpdateConfig: Checking ARIC for Adv. Patching schedule...");
            if ((timetable.Enabled) && (client.PatchingLevel != PatchingLevels.Advanced))
            {
                sbDetails.AppendLine($"PatchingLevel changed from {client.PatchingLevel} to 2(ADVANCED) because Advanced Patching Schedule {timetable.Schedule_id} is enabled");
                client.PatchingLevel = PatchingLevels.Advanced;
            }

            log.LogDebug($"UpdateConfig: End");
            client.Save();
            
            return sbDetails.ToString();
        }


        private Guid SearchForAdvancedPatchingId(int deviceNumber, string authToken)
        {
            log.LogDebug($"UpdateConfig: Building API Request");
            HttpClient api = new HttpClient();
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            api.DefaultRequestHeaders.Add("X-Auth-Token", authToken);

            log.LogDebug($"UpdateConfig: Excuting API Request...");
            // HttpContent hc = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage resp = api.GetAsync($"{aricConfig.TimetableAPI}/name/Windows Advanced Patching {deviceNumber}").Result;
            string json = string.Empty;



            if (resp.StatusCode == HttpStatusCode.OK)
            {
                json = resp.Content.ReadAsStringAsync().Result;
                log.LogDebug($"UpdateConfig: API Result: {json}");
                JObject jo = JObject.Parse(json);
                return new Guid(jo["data"][0]["schedule_id"].ToString());
            }
            else
            {
                if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    return Guid.Empty;
                }
                else
                {
                    Exception e = new Exception($"ARIC TimeTable API error: {resp.StatusCode} ");
                    e.Data.Add("HTTP Status Code", resp.StatusCode);
                    e.Data.Add("HTTP Data:", json);
                    log.LogError(e, "ARIC TimeTable API error");
                    return Guid.Empty;
                }
            }
        }



        private PatchingRegistryValues Parse(string json)
        {
            //log.logDebug($"==>[Parse]: Start");
            //log.logDebug($"==>[Parse]: json={json}");
            PatchingRegistryValues reg = new PatchingRegistryValues();
            reg.Registry = new Dictionary<string, PatchingRegistryKeyValue>();

            //byte[] ba = Convert.FromBase64String(json);
            //ja = JArray.Parse(Encoding.UTF8.GetString(ba));
            //
            JArray ja = JArray.Parse(json);

            reg.ErrorMessage = ja[0]["ScriptErrorMsg"].ToString();

            for (int i = 1; i < ja.Count; i++) //start with the 2nd element in the returned array
            {

                PatchingRegistryKeyValue rk = new PatchingRegistryKeyValue();

                // due to idiosyncracies with different versions of Powershell,
                // a custom JSON coverter was written by IAW for Powershell v2.
                // This custom converter will return the ErrorMsg property of each rk (above)
                // as an array with a single string in it.
                //
                // Whereas, newer versions of Powershell have a built-in JSON converter
                // that returns ErrorMsg as a simple string
                //
                // Code below is an attempt to handle either format
                if (ja[i]["ErrorMsg"] is JArray)
                {
                    JArray jErrors = (JArray)ja[i]["ErrorMsg"];
                    rk.ErrorMessages = jErrors.Select(e => e.ToString())?.ToList<string>();
                }
                else
                {
                    if (ja[i]["ErrorMsg"] is JValue)
                    {
                        string msg = ja[i]["ErrorMsg"].ToString();
                        rk.ErrorMessages.Add(msg);
                    }
                    else
                    {
                        throw new AricException($"[ErrorMsg] is not a known type.");
                    }
                }

                rk.Exists = ja[i]["KeyExists"].ToString().ToLower() == "true";
                rk.Value = ja[i]["Value"].ToString();

                //log.logDebug($"==>[Parse]: rk.path={ja[i]["Path"].ToString()}");
                //log.logDebug($"==>[Parse]: rk.Exists={rk.Exists}");
                //log.logDebug($"==>[Parse]: rk.Value={rk.Value.ToString()}");

                reg.Registry.Add(ja[i]["Path"].ToString(), rk);
                

                
            }
            //log.logDebug($"==>[Parse]: End");
            return reg;
        }

        private string Authenticate()
        {
            HttpClient api = new HttpClient();
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            TbConfig dbConfig = db.TbConfig.Single(cfg => cfg.ConfigKey == "SMTP");

            JObject jo = JObject.Parse(dbConfig.ConfigJson);

            string data = $"{{\"auth\": {{\"RAX-AUTH:domain\": {{\"name\": \"Rackspace\"}},\"passwordCredentials\": {{\"username\": \"{jo["user"].ToString()}\",\"password\": \"{jo["password"].ToString()}\"}}}}}}";


            HttpContent hc = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = api.PostAsync("https://identity-internal.api.rackspacecloud.com/v2.0/tokens", hc).Result;

            if (resp.IsSuccessStatusCode)
            {
                string json = resp.Content.ReadAsStringAsync().Result;

                jo = JObject.Parse(json);

                return jo["access"]["token"]["id"].ToString();
            }
            else
            {
                throw new UnauthorizedAccessException($"HTTP Error authenticating service account. HTTP Status Code: {(int)resp.StatusCode} {resp.StatusCode}");
            }

        }
    }
}
