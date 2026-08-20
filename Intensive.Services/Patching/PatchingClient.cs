using System;
using System.Collections.Generic;
using System.Linq;

using Intensive.Data.SSDatabase;
using Intensive.Data.WSUS;
//using Microsoft.UpdateServices.Administration;

using Intensive.Services.Patching.Exceptions;

using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Extensions;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Intensive.Services.Patching
{
    public enum PatchingLevels { None, Basic, Advanced, Manual };

    public class PatchingClient
    {
        [Required]
        public int DeviceNumber { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        public string DataCenter { get; set; }
        public string OSVersion
        {
            get
            {
                return string.Concat(this.OSMajorVersion.ToString(),
                                    ".",
                                    this.OSMinorVersion.ToString(),
                                    ".",
                                    this.OSBuildNumber.ToString()
                                    );
            }
        } //in Major.minor.build format
        public int? OSMajorVersion { get; set; }
        public int? OSMinorVersion { get; set; }
        public int? OSBuildNumber { get; set; }
        public bool UnSupportedOS
        {
            get; set;
            //get { return (this.OSBuildNumber == null) ? false : (int)this.OSBuildNumber < config.MinimumOSBuild; }
        }
        public Guid? WSUSID { get; set; }
        public int? TargetId { get; set; }
        public PatchingLevels PatchingLevel { get; set; }
        public bool UseWUServer { get; set; }
        public string WUServer { get; set; }
        public short AUOptions { get; set; }
        public bool OptedOut { get; set; }
        public DateTime? LastContact { get; set; } //UTC time
        public DateTime? LastPatchDate { get; set; } 
        public DateTime? NextPatchDate { get; set; } //will not be populated until config is read
        public bool? RebootPending { get; set; }
        public List<string> Errors { get; set; }

        public bool? NoAutoRebootWithLoggedOnUsers { get; set; }
        public short? ScheduledWeek { get; set; }
        public short? ScheduledDay { get; set; }
        public short? ScheduledTime { get; set; }
        public PatchingClientAdvancedPatching AdvancedPatching { get; set; }


        private ILogger<PatchingClient> log;
        private SSDatabaseContext db;

        private WSUSDBContextFactory wsusDBFactory;
        private SUSDBContext wsus = null;
        private PatchingSystemConfig config;

        private StringBuilder sb = new StringBuilder();

        public PatchingClient()
        {
            this.Errors = new List<string>();
            this.AdvancedPatching = null;
        }
        public PatchingClient(ILogger<PatchingClient> logger,
                              SSDatabaseContext dbContext, 
                              WSUSDBContextFactory wsusFactory,
                              IOptions<PatchingSystemConfig> patchConfig
                              )
        {
            log = logger;            
            db = dbContext;
            wsusDBFactory = wsusFactory;
            config = patchConfig.Value;
            this.Errors = new List<string>();
            this.AdvancedPatching = null;
        }

        public void Load(int deviceNumber)
        {
            ClearData();
            
            log.LogDebug($"Loading Patching Client {deviceNumber} ....");
            try
            {
                #region Load current client data
                try
                {
                    TbPatchingClients tbClient = null;
                    this.DeviceNumber = deviceNumber;
                    tbClient = db.TbPatchingClients.AsNoTracking().Single(c => c.DeviceNumber == deviceNumber);
                    
                    this.AUOptions = tbClient.Auoptions;

                    this.OptedOut = tbClient.OptedOut;
                    this.PatchingLevel = (PatchingLevels)tbClient.PatchingLevel;
                    this.TargetId = tbClient.TargetId;
                    this.UseWUServer = tbClient.UseWuserver == 1;
                    this.WSUSID = tbClient.Wsusid;
                    this.WUServer = tbClient.Wuserver;

                }
                catch (InvalidOperationException ex)
                {
                    log.LogDebug($"*** Invalid Operation Exception ***");
                    log.LogError(14999, ex, ex.Message);
                    throw new PatchingNotFoundException($"Patching Client {deviceNumber} not found in database", ex);
                }

                log.LogDebug($"Loading Server {deviceNumber} ....");
                try
                {
                    TbServers tbServer = null;

                    tbServer = db.TbServers.AsNoTracking().Single(c => c.DeviceNumber == deviceNumber);
                    this.DataCenter = tbServer.DataCenter;
                    this.Name = tbServer.Name;
                }
                catch (InvalidOperationException ex)
                {
                    //log.LogDebug($"*** Invalid Operation Exception ***");
                    //log.LogError(14999, ex, ex.Message);
                    throw new PatchingNotFoundException($"Server {deviceNumber} not found in database", ex);
                }


                log.LogDebug($"Loading Basic Patching Config ....");
                try
                {
                    TbPatchingClientConfigBasic config = null;
                    config = db.TbPatchingClientConfigBasic.AsNoTracking().Single(c => c.DeviceNumber == deviceNumber);
                    this.NoAutoRebootWithLoggedOnUsers = config.NoAutoRebootWithLoggedOnUsers == 1;
                    this.ScheduledDay = config.ScheduledDay;
                    this.ScheduledTime = config.ScheduledTime;
                    this.ScheduledWeek = config.ScheduledWeek;
                }
                catch (InvalidOperationException ex)
                {
                    //log.LogDebug($"*** Invalid Operation Exception ***");
                    //log.LogError(14999, ex, ex.Message);
                    throw new PatchingNotFoundException($"Config data for Patching Client {deviceNumber} was not found in the database", ex);
                }
                #endregion

                #region Load Advanced Patching data
                log.LogDebug($"Loading Advanced Patching ID ....");
                try
                {
                    this.AdvancedPatching = new PatchingClientAdvancedPatching();
                    TbPatchingClientConfigAdvanced advConfig = null;
                    advConfig = db.TbPatchingClientConfigAdvanced.AsNoTracking().SingleOrDefault(c => c.DeviceNumber == deviceNumber);

                    //this.AdvancedPatching = new PatchingClientAdvancedPatching();

                    if (advConfig != null)
                    {
                       //this.AdvancedPatching = new AdvancedPatchingParameters();
                        this.AdvancedPatching.ID = advConfig.ArictimeTableId;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    if (this.PatchingLevel == PatchingLevels.Advanced)
                    {
                        //this.AdvancedPatching = new PatchingClientAdvancedPatching();
                        throw new PatchingNotFoundException($"Config data for Patching Client {deviceNumber} was not found in the database", ex);
                    }
                    //else
                    //{
                    //    this.AdvancedPatching = new PatchingClientAdvancedPatching();
                    //}
                }

                this.NextPatchDate = this.CalculateNextPatchingDate();
                #endregion


                #region Load WSUS data
                try
                {
                    if (this.WUServer.ToLower().Contains("rackspace.com"))
                    {
                        if (wsus == null)
                        {
                            wsus = this.ConnectToWSUS();    //connects to the DB associated with the current WUServer
                        }

                        this.LoadWSUSData();
                    }
                    else
                    {
                        this.OSMajorVersion = null;
                        this.OSMinorVersion = null;
                        this.OSBuildNumber = null;
                        this.RebootPending = null;
                        this.LastContact = null;
                        if (string.IsNullOrEmpty(this.WUServer))
                        {
                            throw new PatchingWSUSConnectionException($"WSUS Server name is empty");
                        }
                        else
                        {
                            throw new PatchingWSUSConnectionException($"Unable to connect to the 3rd party WSUS server {this.WUServer}");
                        }
                    }

                    
                }
                catch(SqlException sqlex)
                {
                    log.LogDebug($"*** SQL Exception ***");
                    //log.LogError(14999, sqlex, sqlex.Message);
                    this.OSMajorVersion = null;
                    this.OSMinorVersion = null;
                    this.OSBuildNumber = null;
                    this.RebootPending = null;
                    this.LastContact = null;
                    throw new PatchingWSUSConnectionException($"Unable to connect to the Intensive WSUS server {this.WUServer}", sqlex);
                }
                catch (InvalidOperationException nf)
                {
                    log.LogDebug($"*** Invalid Operation Exception ***");
                    log.LogError(14999, nf, nf.Message);
                    this.OSMajorVersion = null;
                    this.OSMinorVersion = null;
                    this.OSBuildNumber = null;
                    this.RebootPending = null;
                    this.LastContact = null;
                    throw new PatchingWSUSNotFoundException($"WSUS data not found for device {deviceNumber}", nf);
                }
                #endregion

            }
            catch (Exception ex)    //catch any unhandled exceptions
            {
                if (ex is PatchingWSUSConnectionException) { throw; }
                if (ex is PatchingWSUSNotFoundException) { throw; }
                if (ex is PatchingNotFoundException) { throw; }
                

                log.LogDebug($"*** Generic Exception ***");
                log.LogError(14999, ex, ex.Message);
                
                sb.AppendLine(ex.Message);
                if (ex.InnerException != null)
                {
                    sb.AppendLine(ex.InnerException.Message);
                    sb.AppendLine(ex.InnerException.StackTrace);
                }
                this.Errors.Add($"Unexpected error loading Patching Client data: {ex.Message} \r\n\r\n {sb.ToString()}");
                

                //throw;  //re-throw the exception and let the caller handle it
            }
            //return Task.CompletedTask;
        }

        private void LoadWSUSData()
        {
            log.LogDebug($"WSUS DB Connected; Get Computer Target");
            TbComputerTarget wsusComputer = wsus.TbComputerTarget
                                                    .AsNoTracking()
                                                    .Single(s => s.ComputerId == this.WSUSID.ToString());


            this.LastContact = wsusComputer.LastSyncTime;

            //get update/status info for this computer
            // summarization state = 4(update installed) or 6(installed, but pending reboot)
            IQueryable<TbUpdateStatusPerComputer> wsusStatusInfo;
            log.LogDebug($"Get Update Status for Computer");
            wsusStatusInfo = wsus.TbUpdateStatusPerComputer.AsNoTracking()
                                    .Where(s =>
                                        (s.SummarizationState == 4 || s.SummarizationState == 6)
                                            && (s.TargetId == wsusComputer.TargetId)
                                    )
                                    .OrderByDescending(s => s.LastChangeTime);//most current on top

            this.TargetId = wsusComputer.TargetId;
            this.RebootPending = wsusStatusInfo.Where(r => r.SummarizationState == 6).Count() > 0;
            this.LastPatchDate = wsusStatusInfo.First().LastChangeTime;

            log.LogDebug($"Get Computer Target Detail");
            TbComputerTargetDetail wsusComputerDetails = wsus.TbComputerTargetDetail
                                                                .AsNoTracking()
                                                                .Single(d => d.TargetId == wsusComputer.TargetId);

            this.OSMajorVersion = wsusComputerDetails.OsmajorVersion;
            this.OSMinorVersion = wsusComputerDetails.OsminorVersion;
            this.OSBuildNumber = wsusComputerDetails.OsbuildNumber;


            log.LogDebug($"Setting UnsopportedOS Flag");
            log.LogDebug($"config.MinimumOSBuild: {config.MinimumOSBuild}");
            log.LogDebug($"config.ExcludeOSBuilds: {config.ExcludeOSBuilds}");

            this.UnSupportedOS = (this.OSBuildNumber == null) ?
                                        false :
                                        (
                                            ((int)this.OSBuildNumber < config.MinimumOSBuild) ||
                                            (config.ExcludeOSBuilds.Contains((int)this.OSBuildNumber))
                                        );
        }

        //protected void ValidateData()
        //{
        //    //auOptions =2-5
        //    //WSUS id <> GUiD.Empty
        //    if ((this.PatchingLevel < PatchingLevels.None) || (this.PatchingLevel > PatchingLevels.Manual))
        //    {
        //        this.Errors.Add($"PatchingLevel value '{this.PatchingLevel}' must be 0, 1, 2, or 3");
        //    }

        //    if ( (this.AUOptions <2) || (this.AUOptions > 5))
        //    {
        //        this.Errors.Add($"AUOptions value '{this.AUOptions}' must be 2, 3, 4, or 5");
        //    }

        //    //Basic Patching Level must have AUOptions 4 or 5
        //    if (this.PatchingLevel == PatchingLevels.Basic)
        //    {
        //        if ((this.AUOptions != 4) && (this.AUOptions != 5))
        //        {
        //            this.Errors.Add($"AUOptions '{this.AUOptions}' is not valid with Basic Patching Level");
        //        }
        //    }

        //    //Manual Patching Level must have AUOptions 2 or 3
        //    if (this.PatchingLevel == PatchingLevels.Manual)
        //    {
        //        if ((this.AUOptions != 2) && (this.AUOptions != 3))
        //        {
        //            this.Errors.Add($"AUOptions '{this.AUOptions}' is not valid with Manual Patching Level");
        //        }
        //    }

        //    if (this.WSUSID == Guid.Empty)
        //    {
        //        this.Errors.Add($"WSUS ID is empty");
        //    }

        //    if (this.PatchingLevel != PatchingLevels.Advanced)
        //    {
        //        if ((this.ScheduledWeek == null) || (this.ScheduledWeek < 1) || (this.ScheduledWeek > 3))
        //        {
        //            this.Errors.Add($"Scheduled Week is not valid");
        //        }

        //        if ((this.ScheduledDay == null) || (this.ScheduledDay < 0) || (this.ScheduledDay > 7))
        //        {
        //            this.Errors.Add($"Scheduled Day is not valid");
        //        }

        //        if ((this.ScheduledTime == null) || (this.ScheduledTime < 0) || (this.ScheduledTime > 23))
        //        {
        //            this.Errors.Add($"Scheduled Time is not valid");
        //        }
        //    }

        //}
        private DateTime? CalculateNextPatchingDate()
        {
            DateTime? npd;
            switch(this.PatchingLevel)
            {
                case PatchingLevels.None: { npd = null; break; }
                case PatchingLevels.Advanced: { npd = CalculateNextPatchingDate_Advanced(); break; }
                case PatchingLevels.Basic:
                    {
                        npd = CalculateNextPatchingDate_Basic(DateTime.UtcNow.Date);//date with time 00:00:00

                        //if next patching date has already passed, recalculate for next month
                        if (npd < DateTime.UtcNow)
                        {
                            log.LogDebug("recalculating for next month...");
                            npd = CalculateNextPatchingDate_Basic(DateTime.UtcNow.AddMonths(1));
                        }
                        break;
                    }

                case PatchingLevels.Manual: { npd = null; break; }
                default: { npd = null; break; }
            }

            return npd;
        }


        private DateTime? CalculateNextPatchingDate_Basic(DateTime patchingMonth )
        {
            log.LogDebug($"*** Calculating Next Patching Date ({patchingMonth.ToShortDateString()})");
            DateTime pt = CalculatePatchTuesday(patchingMonth);
            log.LogDebug($"Patch Tue: {pt.ToShortDateString()}");
            //
            // ScheduledWeek and ScheduledDay each have a minimum value of 1
            // To make the math below work, we need to subtract 1 from each
            //
            // Patch Tuesday + 6 days = Monday of the following week, i.e EarlyReleaseWeek
            //
            // Release Weeks start on Monday
            //

            int days = 5 + (((int)this.ScheduledWeek - 1) * 7);  //the first day of the scheduled week
            log.LogDebug($"ScheduledWeek: {this.ScheduledWeek.ToString()}");
            log.LogDebug($"ScheduledDay: {this.ScheduledDay.ToString()}");
            log.LogDebug($"days: {days.ToString()}");

            if (this.ScheduledDay == 0)
            {
                DateTime weekStart = pt.AddDays(days);
                DateTime nextWeekStart = weekStart.AddDays(7);
                DateTime now = DateTime.UtcNow.Date; //ignore the time

                if (now < weekStart) //not in the Release Week yet
                {
                    return weekStart.AddHours((int)this.ScheduledTime);   //next patch date is first day of release week
                }

                if (now >= nextWeekStart) //beyond the release week
                {
                    return now.AddDays(-1);   //return "yesterday" to force recalculation for next month
                }

                // "now" is IN the Release Week
                if (now.DayOfWeek != DayOfWeek.Sunday) //if today is any day except Sunday of the Release Week
                {
                    return now.AddDays(1).AddHours((int)this.ScheduledTime);  //next Patching Date is tomorrow
                }
            }
            else
            {
                if (this.ScheduledDay == 1)
                {
                    days += 7;
                }
                else
                {
                    days += ((int)this.ScheduledDay - 1);
                }
                
                log.LogDebug($"days2: {days.ToString()}");
                log.LogDebug($"next patching date: {pt.AddDays(days).ToShortDateString()}");

                return pt.AddDays(days).AddHours((int)this.ScheduledTime);
            }

            return null;
        }
        private DateTime? CalculateNextPatchingDate_Advanced()
        {
            //get ARIC timetable entry
            return null;
        }


        private DateTime CalculatePatchTuesday(DateTime patchingMonth)
        {
            //patching tuesday = 2nd Tuesday of the month
            //therefore, Patching Tuesday will always be between 8th - 14th inclusive

            DateTime dt = new DateTime(patchingMonth.Year, patchingMonth.Month, 8); //start on the 8th day of the month
            DateTime dtTest;
            for (int i = 0; i < 7; i++) //for each day upto and including the 14th
            {
                dtTest = dt.AddDays(i);
                if (dtTest.DayOfWeek == DayOfWeek.Tuesday)   //if that day is a Tuesday
                {
                    return dtTest.Date;  //return the date without time
                }
            }

            return DateTime.MinValue;   //make the compiler happy.  All code paths return a value now

        }



        public void Save()
        {
            TbPatchingClients tbPatchClient;
            try
            {
                tbPatchClient = db.TbPatchingClients.First(a => a.DeviceNumber == this.DeviceNumber);
                tbPatchClient.Wsusid = this.WSUSID;
                tbPatchClient.LastRefresh = DateTime.UtcNow;
                tbPatchClient.PatchingLevel = (short)this.PatchingLevel;
                tbPatchClient.UseWuserver = (this.UseWUServer) ? (short)1 : (short)0;
                tbPatchClient.Wuserver = this.WUServer;
                tbPatchClient.Auoptions = this.AUOptions;
                tbPatchClient.OptedOut = this.OptedOut;
                tbPatchClient.TargetId = this.TargetId;
                log.LogDebug($"Saving Basic Patching Config ....");
                TbPatchingClientConfigBasic config = null;
                try
                {
                    config = db.TbPatchingClientConfigBasic.Single(c => c.DeviceNumber == this.DeviceNumber);
                    config.NoAutoRebootWithLoggedOnUsers = ((bool)this.NoAutoRebootWithLoggedOnUsers) ? (short)1 : (short)0;
                    config.ScheduledDay = (short)this.ScheduledDay;
                    config.ScheduledTime = (short)this.ScheduledTime;

                    //if the week is changing, need to update WSUS group membership
                    //if (config.ScheduledWeek != (short)this.ScheduledWeek)
                    //{
                    //    log.LogDebug("WSUSChangeGroupMembership - UPDATE");
                    //    this.WSUSChangeGroupMembership();
                    //    config.ScheduledWeek = (short)this.ScheduledWeek;
                    //}

                }
                catch (InvalidOperationException ex)
                {
                    //config data does not exist for some reason, so create it

                    //throw new PatchingNotFoundException($"Config data for Patching Client {this.DeviceNumber} was not found in the database", ex);
                    config = new TbPatchingClientConfigBasic();

                    config.NoAutoRebootWithLoggedOnUsers = ((bool)this.NoAutoRebootWithLoggedOnUsers) ? (short)1 : (short)0;
                    config.ScheduledDay = (short)this.ScheduledDay;
                    config.ScheduledTime = (short)this.ScheduledTime;
                    config.ScheduledWeek = -1;

                    //log.LogDebug("WSUSChangeGroupMembership - ADD");
                    //this.WSUSChangeGroupMembership();

                    db.TbPatchingClientConfigBasic.Add(config);
                }


                // Update WSUS Group membership, if needed
                try
                {
                    log.LogDebug($"Checking for WSUS Group membership change ....");
                    log.LogDebug($"DB week  : {config.ScheduledWeek}");
                    log.LogDebug($"curr week: {this.ScheduledWeek}");
                    if (config.ScheduledWeek != (short)this.ScheduledWeek)
                    {
                        this.WSUSChangeGroupMembership();
                        config.ScheduledWeek = (short)this.ScheduledWeek;
                    }
                }
                catch(Exception ex)
                {
                    log.LogError(11999, ex, "Unexpected error Updating WSU Group membership");
                    if (ex.InnerException != null)
                    {
                        log.LogError(11999, ex.InnerException, "Inner Exception");
                    }
                }



                log.LogDebug($"Saving Advanced Patching Config ....");
                try
                {
                    if ((this.AdvancedPatching != null) && (this.AdvancedPatching.ID != Guid.Empty) && (this.AdvancedPatching.ProcessName != null))
                    {
                        //log.LogDebug($"  Query row....");
                        TbPatchingClientConfigAdvanced advConfig = db.TbPatchingClientConfigAdvanced.First(c => c.DeviceNumber == this.DeviceNumber);
                        //log.LogDebug($"  Update row....");
                        advConfig.ArictimeTableId = (Guid)this.AdvancedPatching.ID;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    //config data does not exist for some reason, so create it
                    log.LogDebug($"  Insert row....");
                    TbPatchingClientConfigAdvanced advConfig = new TbPatchingClientConfigAdvanced();
                    advConfig.ArictimeTableId = (Guid)this.AdvancedPatching.ID;
                    advConfig.DeviceNumber = this.DeviceNumber;
                    log.LogDebug($"  {JsonConvert.SerializeObject(this)}");
                    db.TbPatchingClientConfigAdvanced.Add(advConfig);
                }



                //if (this.PatchingLevel == PatchingLevels.Advanced)
                //{
                //    log.LogDebug($"Saving Advanced Patching Config ....");
                //    try
                //    {
                //        log.LogDebug($"  Query row....");
                //        TbPatchingClientConfigAdvanced config = db.TbPatchingClientConfigAdvanced.First(c => c.DeviceNumber == this.DeviceNumber);
                //        log.LogDebug($"  Update row....");

                //        config.ArictimeTableId = (Guid)this.AdvancedPatching.ID;
                //    }
                //    catch (InvalidOperationException ex)
                //    {
                //        //config data does not exist for some reason, so create it
                //        log.LogDebug($"  Insert row....");
                //        TbPatchingClientConfigAdvanced config = new TbPatchingClientConfigAdvanced();
                //        config.ArictimeTableId = (Guid)this.AdvancedPatching.ID;
                //        config.DeviceNumber = this.DeviceNumber;
                //        log.LogDebug($"  {JsonConvert.SerializeObject(this)}");
                //        db.TbPatchingClientConfigAdvanced.Add(config);
                //    }
                //}
                //else
                //{
                //    log.LogDebug($"Saving Basic Patching Config ....");
                //    try
                //    {
                //        TbPatchingClientConfigBasic config = null;
                //        config = db.TbPatchingClientConfigBasic.Single(c => c.DeviceNumber == this.DeviceNumber);
                //        config.NoAutoRebootWithLoggedOnUsers = ((bool)this.NoAutoRebootWithLoggedOnUsers) ? (short)1 : (short)0;
                //        config.ScheduledDay = (short)this.ScheduledDay;
                //        config.ScheduledTime = (short)this.ScheduledTime;

                //        //if the week is changing, need to update WSUS group membership
                //        if (config.ScheduledWeek != (short)this.ScheduledWeek)
                //        {
                //            this.WSUSChangeGroupMembership();
                //            config.ScheduledWeek = (short)this.ScheduledWeek;
                //        }

                //    }
                //    catch (InvalidOperationException ex)
                //    {
                //        //config data does not exist for some reason, so create it

                //        //throw new PatchingNotFoundException($"Config data for Patching Client {this.DeviceNumber} was not found in the database", ex);
                //        TbPatchingClientConfigBasic config = new TbPatchingClientConfigBasic();

                //        config.NoAutoRebootWithLoggedOnUsers = ((bool)this.NoAutoRebootWithLoggedOnUsers) ? (short)1 : (short)0;
                //        config.ScheduledDay = (short)this.ScheduledDay;
                //        config.ScheduledTime = (short)this.ScheduledTime;
                //        config.ScheduledWeek = (short)this.ScheduledWeek;

                //        this.WSUSChangeGroupMembership();

                //        db.TbPatchingClientConfigBasic.Add(config);
                //    }
                //}

                log.LogDebug($"Saving DB Changes....");
                db.SaveChanges();
            }
            catch (Exception ex)    //throw any exception up to the caller
            {
                throw;
            }
        }

        public void ClearData()
        {
            DeviceNumber = -1;
            Name = "";
            DataCenter = "";

            OSMajorVersion = null;
            OSMinorVersion = null;
            OSBuildNumber = null;
            UnSupportedOS = false;
            WSUSID = null;
            TargetId = null;
            PatchingLevel = PatchingLevels.None;
            UseWUServer = false;
            WUServer = "";
            AUOptions = 0;
            OptedOut = true;
            LastContact = null;
            LastPatchDate = null;
            NextPatchDate = null;
            RebootPending = null;
            Errors = new List<string>();

            NoAutoRebootWithLoggedOnUsers = null;
            ScheduledWeek = null; 
            ScheduledDay = null;
            ScheduledTime = null;
        }

        private SUSDBContext ConnectToWSUS()
        {
            SUSDBContext db = null;
            string[] segments = this.WUServer.Split(new char[] { '.' });
            string dc = segments[1].ToUpper();
            if (dc.Length > 3)
            {
                dc = dc.Substring(0, 3);
            }

            //log.LogDebug($"dc: {dc}");
            //log.LogDebug("WSUSDBServer:");
            //foreach (string k in config.WSUSDBServers.Keys)
            //{
            //    log.LogDebug($"   {k}: {config.WSUSDBServers[k]}");
            //}

            if (!config.WSUSDBServers.ContainsKey(dc))
            {
                throw new Exception("No Database connection string for " + dc);
            }
            string wsusDBconn = config.WSUSDBServers[dc];
            log.LogDebug($"Connecting to WSUS DB for {dc} ...");
            log.LogDebug($"   {wsusDBconn}");
            //wsus = wsusDBFactory.Create(config.WSUSDBServers[this.DataCenter]);
            db = wsusDBFactory.Create(wsusDBconn);

            return db;
        }

        private void WSUSChangeGroupMembership()
        {
            log.LogDebug("WSUSChangeGroupMembership start");
            if (this.ScheduledWeek > 0) 
            {
                if (wsus == null)
                {
                    wsus = this.ConnectToWSUS();    //connects to the DB associated with the current WUServer
                }
                log.LogDebug($"sched week = {this.ScheduledWeek}");
                log.LogDebug($"WSUS Group = {config.WSUSGroupID[(int)this.ScheduledWeek]}");
                Guid grpGuid = config.WSUSGroupID[(int)this.ScheduledWeek];

                string sql = $"EXEC SUSDB.dbo.spAddCOmputerToTargetGroup '{grpGuid.ToString()}', '{this.WSUSID.ToString()}'";
                //int rc = wsus.Database.ExecuteSqlCommand("EXEC SUSDB.dbo.spAddComputerToTargetGroup", grpGuid.ToString()', this.WSUSID.ToString());
                log.LogDebug($"WSUS Group SQL = {sql}");
                //int rc = wsus.Database.ExecuteSqlCommand(sql);
                int rc = wsus.Database.ExecuteSqlRaw(sql);

                //System.Threading.Thread.Sleep(1000);    //sleep for 1 second to simulate updating WSUS
            }
            log.LogDebug("WSUSChangeGroupMembership exit");
        }


        //
        // called by the ARIC Data Handler to determine if ReleaseWeek was 
        // changed in WSUS but not in Portal
        //
        public int GetWSUSReleaseWeek()
        {
            int releaseWeek = 0;

            if (wsus == null)
            {
                wsus = this.ConnectToWSUS();    //connects to the DB associated with the current WUServer
            }

            //load the TargetId and other data; called just in case this is a new client and we are prcessing the first
            //client PullSettings data
            if (this.TargetId<=0) this.LoadWSUSData(); 

            log.LogDebug($"[PatchingClient] WSUS:{wsus.Database.GetDbConnection().ConnectionString}");

            log.LogDebug("[PatchingClient] Get WSUS Release Week....");
            log.LogDebug($"[PatchingClient] TargetID:{this.TargetId}");
            List<TbExpandedTargetInTargetGroup> grps = wsus.TbExpandedTargetInTargetGroup
                                                                .Where(g => g.TargetId == this.TargetId 
                                                                        && g.IsExplicitMember
                                                                        )
                                                                .ToList<TbExpandedTargetInTargetGroup>();
            List<Guid> ValidGroupIds = config.WSUSGroupID.ToList<Guid>();
            int i = 0; ;

            if (grps.Count == 0)
            {
                log.LogDebug($"[PatchingClient] No direct group memberships");
            }
            else
            {
                foreach (TbExpandedTargetInTargetGroup g in grps)
                {
                    log.LogDebug($"[PatchingClient] member of {g.TargetGroupId.ToString()}");
                }
            }

            foreach(TbExpandedTargetInTargetGroup g in grps)
            {
                i = ValidGroupIds.IndexOf(g.TargetGroupId);
                if (i > -1)
                {
                    releaseWeek = i;
                    break;  //found a match; no sense looking for any more
                }
            }

            log.LogDebug($"[PatchingClient] WSUS Release Week={releaseWeek}");

            return releaseWeek;

            //config.WSUSGroupID.ToList<Guid>().IndexOf();
            //System.Threading.Thread.Sleep(1000);    //sleep for 1 second to simulate updating WSUS
        }

        public void OptIn()
        {
            TbPatchingClients tbPatchClient;
            try
            {
                tbPatchClient = db.TbPatchingClients.First(a => a.DeviceNumber == this.DeviceNumber);

                tbPatchClient.OptedOut = false;

                db.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw new PatchingNotFoundException(ex.Message, ex);
            }
        }

        public void OptOut()
        {
            TbPatchingClients tbPatchClient;
            try
            {
                tbPatchClient = db.TbPatchingClients.First(a => a.DeviceNumber == this.DeviceNumber);

                tbPatchClient.OptedOut = true;

                db.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw new PatchingNotFoundException(ex.Message, ex);
            }
        }

        public List<Guid> FindMissingPatches()
        {
            List<Guid> OutstandingPatches = new List<Guid>();
            DbCommand cmd = null;

            if (this.WUServer.ToLower().Contains("rackspace.com"))
            {
                try
                {
                    log.LogInformation($"Creating connection to WSUS Server...");
                    if (wsus == null)
                    {
                        wsus = this.ConnectToWSUS();    //connects to the DB associated with the current WUServer
                    }


                    //possible imporvements:
                    // limit ArrivalDates to a shorter period
                    // UpdateApprovalActions = 1(Install) ??

                    string updateScope = "<?xml version =\"1.0\" encoding=\"utf-16\"?>" +
                             "<UpdateScope ApprovedStates=\"-1\" UpdateTypes=\"-1\" FromArrivalDate=\"01-01-1753 00:00:00.000\"" +
                             " ToArrivalDate=\"12-31-9999 23:59:59.997\" IncludedInstallationStates=\"44\" ExcludedInstallationStates=\"0\"" +
                             " IsWsusInfrastructureUpdate=\"0\" FromCreationDate=\"01-01-1753 00:00:00.000\"" +
                             " ToCreationDate=\"12-31-9999 23:59:59.997\" UpdateApprovalActions=\"-1\" UpdateSources=\"1\"" +
                             " ExcludeOptionalUpdates=\"0\" />";


                    wsus.Database.OpenConnection();

                    cmd = wsus.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = "spGetUpdateInstallationInfoForComputer";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p = new SqlParameter("@computerID", SqlDbType.NVarChar);
                    p.Direction = ParameterDirection.Input;
                    p.Value = this.WSUSID.ToString();
                    cmd.Parameters.Add(p);

                    p = new SqlParameter("@updateScopeXml", SqlDbType.NText);
                    p.Direction = ParameterDirection.Input;
                    p.Value = updateScope;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter("@publicationState", SqlDbType.Int);
                    p.Direction = ParameterDirection.Input;
                    p.Value = null;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter("@preferredCulture", SqlDbType.NVarChar);
                    p.Direction = ParameterDirection.Input;
                    p.Value = "en";
                    cmd.Parameters.Add(p);

                    p = new SqlParameter("@apiVersion", SqlDbType.Int);
                    p.Direction = ParameterDirection.Input;
                    p.Value = 196608;
                    cmd.Parameters.Add(p);

                    int state = 0;
                    int action = 0;
                    Guid id = Guid.Empty;
                    int rows = 0;

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                rows++;
                                //if the update status is 2("Not Installed"), 3("Downloaded"), or 5("Failed"), AND the EffectiveDeploymentAction = 0("Install")
                                state = reader.GetInt32(2);
                                action = reader.GetInt32(3);
                                id = reader.GetGuid("UpdateID");
                                log.LogDebug($"   ({rows.ToString()}) id={id.ToString()}, state={reader.GetInt32("SummarizationState").ToString()}, action={action.ToString()}");

                                if (((state == 2) || (state == 3) || (state == 5)) && (action == 0))
                                {
                                    OutstandingPatches.Add(reader.GetGuid(0));
                                }
                            }
                            log.LogDebug($"rows read from SP: {rows}");
                            log.LogDebug($"Matching Patches Found: {OutstandingPatches.Count}");
                        }
                        reader.Close();
                    }
                }//try

                catch (SqlException sqlex)
                {
                    log.LogInformation($"==>SQL Error Code: {sqlex.ErrorCode}");
                    log.LogInformation($"==>SQL Error Message: [{sqlex.Number}] {sqlex.Message}");
                    log.LogInformation($"==>SQL Procedure: {sqlex.Procedure}");
                    log.LogInformation($"==>SQL Error State: {sqlex.State}");
                    throw new PatchingWSUSConnectionException($"Unable to connect to the Intensive WSUS server {this.WUServer}");
                }
                finally
                {
                    wsus.Database.CloseConnection();
                    cmd?.Dispose();

                }
            }//if wuserver contains rackspace.com
            else
            {
                if (string.IsNullOrEmpty(this.WUServer))
                {
                    this.Errors.Add("WSUS Server name is empty");
                    throw new PatchingWSUSConnectionException($"WSUS Server name is empty");
                }
                else
                {
                    this.Errors.Add($"Unable to connect to the 3rd party WSUS server {this.WUServer}");
                    throw new PatchingWSUSConnectionException($"Unable to connect to the 3rd party WSUS server {this.WUServer}");
                }
            }

            return OutstandingPatches;

        }

        public List<Guid> FindPatches(DateTime from, DateTime to, int includeStates, int excludeStates)
        {
            List<Guid> Patches = new List<Guid>();
            DbCommand cmd = null;

            if (this.WUServer.ToLower().Contains("rackspace.com"))
            {
                try
                {
                    log.LogInformation($"Creating connection to WSUS Server...");
                    if (wsus == null)
                    {
                        wsus = this.ConnectToWSUS();    //connects to the DB associated with the current WUServer
                    }

                    StringBuilder sb = new StringBuilder();
                    sb.Append("<?xml version =\"1.0\" encoding=\"utf-16\"?>");
                    sb.Append("<UpdateScope ApprovedStates=\"-1\"");
                    sb.Append(" UpdateTypes=\"-1\"");
                    sb.Append($" FromArrivalDate=\"{from.ToString("MM-dd-yyy")} 00:00:00.000\"");
                    sb.Append($" ToArrivalDate=\"{to.ToString("MM-dd-yyy")} 23:59:59.997\"");
                    sb.Append($" IncludedInstallationStates=\"{includeStates.ToString()}\"");
                    //sb.Append($" ExcludedInstallationStates=\"{excludeStates.ToString()}\"");
                    sb.Append($" ExcludedInstallationStates=\"0\"");
                    sb.Append(" IsWsusInfrastructureUpdate=\"0\"");
                    sb.Append(" FromCreationDate=\"01-01-1753 00:00:00.000\"");
                    sb.Append(" ToCreationDate=\"12-31-9999 23:59:59.997\"");
                    sb.Append(" UpdateApprovalActions =\"-1\"");
                    sb.Append(" UpdateSources=\"-1\"");
                    sb.Append(" ExcludeOptionalUpdates=\"0\" />");

                    wsus.Database.OpenConnection();

                    cmd = wsus.Database.GetDbConnection().CreateCommand();
                    cmd.CommandText = "spGetUpdateInstallationInfoForComputer";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter p = new SqlParameter("@computerID", SqlDbType.NVarChar);
                    p.Direction = ParameterDirection.Input;
                    p.Value = this.WSUSID.ToString();
                    cmd.Parameters.Add(p);

                    p = new SqlParameter("@updateScopeXml", SqlDbType.NText);
                    p.Direction = ParameterDirection.Input;
                    p.Value = sb.ToString(); ;
                    cmd.Parameters.Add(p);
                    log.LogDebug($"updateScope: {sb.ToString()}");

                    //p = new SqlParameter("@publicationState", SqlDbType.Int);
                    //p.Direction = ParameterDirection.Input;
                    //p.Value = null;
                    //cmd.Parameters.Add(p);

                    //p = new SqlParameter("@preferredCulture", SqlDbType.NVarChar);
                    //p.Direction = ParameterDirection.Input;
                    //p.Value = "en";
                    //cmd.Parameters.Add(p);

                    //p = new SqlParameter("@apiVersion", SqlDbType.Int);
                    //p.Direction = ParameterDirection.Input;
                    //p.Value = 196608;
                    //cmd.Parameters.Add(p);

                    int action = 0;
                    int rows = 0;
                    Guid id = Guid.Empty;
                    int state = 0;
                    bool addToList = false;

                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            log.LogDebug($"rows returned. reading...");
                            while (reader.Read())
                            {
                                rows++;
                                //log.LogDebug("getting Action...");
                                action = reader.GetInt32("EffectiveDeploymentAction");
                                //log.LogDebug("getting Patching Guid...");
                                object obj = reader.GetValue("UpdateID");
                                //log.LogDebug("casting ID as a GUiD...");
                                id = (Guid)obj;
                                //log.LogDebug("GetGuid()...");
                                id = reader.GetGuid("UpdateID");
                                //log.LogDebug("GetGuid() worked.");
                                state = reader.GetInt32("SummarizationState");

                                //log.LogDebug($"   ({rows.ToString()}) id={id.ToString()}, state={state.ToString()}, action={action.ToString()}");
                                //if ((state != 1) && (action == 0))
                                //if (action == 0)  //0=install the patch/update
                                //{
                                    addToList = false;
                                    //log.LogDebug($"includeStates: {includeStates}   state: {state}");
                                    if (
                                         (((includeStates &  4) != 0) && (state == 2)) ||
                                         (((includeStates &  8) != 0) && (state == 3)) ||
                                         (((includeStates & 16) != 0) && (state == 4)) ||
                                         (((includeStates & 32) != 0) && (state == 5)) ||
                                         (((includeStates & 64) != 0) && (state == 6))
                                       )
                                    {
                                        //log.LogDebug($"Adding ({rows.ToString()}) id={id.ToString()}, state={state.ToString()}");
                                        addToList = true;
                                    }

                                    if (
                                         (((excludeStates & 4) != 0) && (state == 2)) ||
                                         (((excludeStates & 8) != 0) && (state == 3)) ||
                                         (((excludeStates & 16) != 0) && (state == 4)) ||
                                         (((excludeStates & 32) != 0) && (state == 5)) ||
                                         (((excludeStates & 64) != 0) && (state == 6))
                                       )
                                    {
                                        //log.LogDebug($"Excluding ({rows.ToString()}) id={id.ToString()}, state={state.ToString()}");
                                        addToList = false;
                                    }

                                    if (addToList)
                                    {
                                        log.LogDebug($"Adding Patch ID {id} to return list");
                                        Patches.Add(id);
                                    }
                                //}
                            }//while
                        } //if hasRows()

                        reader.Close();
                        log.LogDebug($"rows read from SP: {rows}");
                        log.LogDebug($"Matching Patches Found: {Patches.Count}");
                    }
                }//try

                catch (SqlException sqlex)
                {
                    log.LogError($"==>SQL Error Code: {sqlex.ErrorCode}");
                    log.LogError($"==>SQL Error Message: [{sqlex.Number}] {sqlex.Message}");
                    log.LogError($"==>SQL Procedure: {sqlex.Procedure}");
                    log.LogError($"==>SQL Error State: {sqlex.State}");
                    throw new PatchingWSUSConnectionException($"Unable to connect to the Intensive WSUS server {this.WUServer}");
                }
                finally
                {
                    wsus.Database.CloseConnection();
                    cmd?.Dispose();

                }
            }//if wuserver contains rackspace.com
            else
            {
                if (string.IsNullOrEmpty(this.WUServer))
                {
                    throw new PatchingWSUSConnectionException($"WSUS Server name is empty");
                }
                else
                {
                    throw new PatchingWSUSConnectionException($"Unable to connect to the 3rd party WSUS server {this.WUServer}");
                }
            }

            return Patches;
        }


        public List<PatchStatus> GetMissingPatches()
        {
            List<PatchStatus> OutstandingPatches = new List<PatchStatus>();

            List<Guid> MissingPatchIds = FindMissingPatches();

            foreach (Guid id in MissingPatchIds)
            {
                PatchStatus p = GetClientPatchStatus(id);
                OutstandingPatches.Add(p);
            }

            return OutstandingPatches;

        }

        //private PatchStatus GetPatchStatus(Guid id)
        //{
        //    PatchStatus patch = new PatchStatus();
        //    try
        //    {
        //        wsus.Database.OpenConnection();

        //        DbCommand cmd = wsus.Database.GetDbConnection().CreateCommand();
        //        cmd.CommandText = "SELECT SecurityBulletin, MsrcSeverity, DefaultTitle, InstallationRebootBehavior, KnowledgbaseArticle";
        //        cmd.CommandText += " Where UpdateId = @updateID";
        //        cmd.CommandType = System.Data.CommandType.Text;

        //        SqlParameter p = new SqlParameter("@updateID", SqlDbType.UniqueIdentifier);
        //        p.Direction = ParameterDirection.Input;
        //        p.Value = id;
        //        cmd.Parameters.Add(p);
        //        using (DbDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    patch.Bulletin = reader.GetString(0);
        //                    patch.Severity = reader.GetString(1);
        //                    patch.Title = reader.GetString(2);
        //                    patch.RequiresReboot = (reader.GetString(3).ToLower() != "neverreboots");
        //                    patch.KbArticle = reader.GetString(4);
        //                }
        //            }
        //            reader.Close();
        //        }
        //    }//try
        //    catch (SqlException sqlex)
        //    {
        //        log.LogInformation($"==>SQL Error Code: {sqlex.ErrorCode}");
        //        log.LogInformation($"==>SQL Error Message: [{sqlex.Number}] {sqlex.Message}");
        //        log.LogInformation($"==>SQL Error State: {sqlex.State}");
        //        throw new PatchingWSUSNotFoundException($"Erro getting Missing Patch Details: [{sqlex.Number}] {sqlex.Message}");
        //    }

        //    try
        //    {
        //        TbUpdateStatusPerComputer tbStatus = wsus.TbUpdateStatusPerComputer.Single(
        //                                                 p => p.LocalUpdateId == this.LocalId && p.TargetId == clientTargetId
        //                                             );

        //        patch.State = tbStatus.SummarizationState;
        //        patch.ChangeDate = tbStatus.LastChangeTime;
        //        patch.TargetId = (int)this.TargetId;
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        throw new PatchingWSUSNotFoundException($"Status information not found for patch", ex);
        //    }
        //}

        private PatchStatus GetPatchStatus(Guid id)
        {
            log.LogDebug($"Get Patch Status: {id.ToString()}");
            PatchStatus patch = new PatchStatus();
            try
            {
                //possible improvements:
                // Use XXXXAsync where possible(.SingleAsync, FirstAsync)??



                log.LogDebug($"Getting tbUpdate {id.ToString()}...");
                TbUpdate tbUpdate = wsus.TbUpdate
                                            .AsNoTracking()
                                            .Single(u => u.UpdateId == id);
                patch.PatchId = id;
                patch.LocalId = tbUpdate.LocalUpdateId;

                log.LogDebug($"Getting tbRevision for LocalUpdateID {tbUpdate.LocalUpdateId}...");
                TbRevision tbRevision = wsus.TbRevision
                                                .AsNoTracking()
                                                .Single(r => r.LocalUpdateId == tbUpdate.LocalUpdateId && r.IsLatestRevision);
                log.LogDebug($"RESULT: tbRevision.RevisionId={tbRevision.RevisionId}");


                log.LogDebug($"Getting tbProperty for {tbRevision.RevisionId}...");
                TbProperty tbProperty = wsus.TbProperty
                                                .AsNoTracking()
                                                .Single(p => p.RevisionId == tbRevision.RevisionId && p.ExplicitlyDeployable);
                log.LogDebug($"RESULT: tbProperty.MsrcSeverity={tbProperty.MsrcSeverity}");


                log.LogDebug($"Getting tbLPR for revision={tbRevision.RevisionId} and languageID={tbProperty.DefaultPropertiesLanguageId}...");
                TbLocalizedPropertyForRevision tbLPR = wsus.TbLocalizedPropertyForRevision
                                                                .AsNoTracking()
                                                                .Single(lpr => lpr.RevisionId == tbRevision.RevisionId && lpr.LanguageId == tbProperty.DefaultPropertiesLanguageId);
                log.LogDebug($"RESULT: tbLPR.LocalizedPropertyId={tbLPR.LocalizedPropertyId}");


                log.LogDebug($"Getting tbLocalizedProperty for localpropID={tbLPR.LocalizedPropertyId}...");
                TbLocalizedProperty tbLocalizedProperty = wsus.TbLocalizedProperty
                                                                .AsNoTracking()
                                                                .Single(p => p.LocalizedPropertyId == tbLPR.LocalizedPropertyId);
                log.LogDebug($"RESULT: tbLocalizedProperty.Title={tbLocalizedProperty.Title}");


                log.LogDebug($"Getting tbKbArticle for revisionid={tbRevision.RevisionId}...");
                TbKbarticleForRevision tbKbArticle = wsus.TbKbarticleForRevision
                                                            .AsNoTracking()
                                                            .Where(kb => kb.RevisionId == tbRevision.RevisionId)
                                                            .OrderBy(k => k.KbarticleId)
                                                            .First();
                log.LogDebug($"RESULT: tbKbArticle.KbarticleId={tbKbArticle.KbarticleId}");


                log.LogDebug($"Getting tbBulletin for revisionid={tbRevision.RevisionId}...");
                IQueryable<TbSecurityBulletinForRevision> tbBulletin = wsus.TbSecurityBulletinForRevision
                                                                    .AsNoTracking()
                                                                    .Where(sb => sb.RevisionId == tbRevision.RevisionId)
                                                                    .OrderBy(b => b.SecurityBulletinId);

                patch.Bulletin = (tbBulletin.Count() == 0) ? null : tbBulletin.First().SecurityBulletinId;
                patch.KbArticle = tbKbArticle.KbarticleId;
                patch.Title = tbLocalizedProperty.Title;
                patch.Severity = tbProperty.MsrcSeverity;
                patch.RequiresReboot = ((tbProperty.InstallRebootBehavior == 1) || (tbProperty.InstallRebootBehavior == 2));

                TbUpdateStatusPerComputer tbStatus = wsus.TbUpdateStatusPerComputer
                                                            .AsNoTracking()
                                                            .Single(
                                                                p => p.LocalUpdateId == patch.LocalId && p.TargetId == this.TargetId
                                                            );

                patch.State = Enum.GetName(typeof(PatchStatus.PatchingState), tbStatus.SummarizationState);
                patch.StateChangeDate = tbStatus.LastChangeTime;
                //patch.TargetId = (int)this.TargetId;

                return patch;

            }
            catch (InvalidOperationException ex)
            {
                throw new PatchingWSUSNotFoundException($"Status information not found for patch", ex);
            }
        }

        public PatchStatus GetClientPatchStatus(Guid id)
        {
            log.LogDebug($"Get Patch Status: {id.ToString()}");
            PatchStatus patch = new PatchStatus();
            patch.WsusId = this.WSUSID;
            DbCommand cmd = null;

            try
            {
                if (this.WUServer.ToLower().Contains("rackspace.com"))
                {
                    try
                    {
                        //log.LogDebug($"Connecting to WSUS Server...");
                        if (wsus == null)
                        {
                            wsus = this.ConnectToWSUS();    //connects to the DB associated with the current WUServer
                        }

                        wsus.Database.OpenConnection();
                        
                        cmd = wsus.Database.GetDbConnection().CreateCommand();
                        cmd.CommandText = "spGetUpdateByID";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter p = new SqlParameter("@updateID", SqlDbType.NVarChar);
                        p.Direction = ParameterDirection.Input;
                        p.Value = id.ToString();
                        cmd.Parameters.Add(p);

                        p = new SqlParameter("@revisionNumber", SqlDbType.Int);
                        p.Direction = ParameterDirection.Input;
                        p.Value = 0;
                        cmd.Parameters.Add(p);

                        p = new SqlParameter("@preferredCulture", SqlDbType.NVarChar);
                        p.Direction = ParameterDirection.Input;
                        p.Value = "en";
                        cmd.Parameters.Add(p);

                        p = new SqlParameter("@apiVersion", SqlDbType.Int);
                        p.Direction = ParameterDirection.Input;
                        p.Value = 196608;
                        cmd.Parameters.Add(p);

                        log.LogDebug($"Getting Patch data for patch {id}...");


                        //the spGetUpdateByID stored Proc will return 5 result sets
                        using (DbDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                //log.LogDebug($"Patch Data row found");
                                while (reader.Read())
                                {
                                    //populate PatchInfo structure
                                    patch.PatchId = id;
                                    patch.LocalId = reader.GetInt32("LocalUpdateID");
                                    patch.Title = reader.GetString("Title");
                                    patch.Severity = reader.GetString("MsrcSeverity");
                                    //patch.RequiresReboot = ((reader.GetInt32(7) == 1) || (reader.GetInt32(7) == 2));
                                    patch.RequiresReboot = (reader.GetInt32("InstallationRebootBehavior") != 0); //0=no Reboot,
                                    patch.ReleaseDate = reader.GetDateTime("CreationDate");
                                }
                            }
                            //log.LogDebug("get next result set 2");
                            reader.NextResult(); //skip over Revision data

                            //log.LogDebug("get next result set 3");
                            reader.NextResult();
                            if (reader.HasRows)
                            {
                                //log.LogDebug($"Data row found");
                                while (reader.Read())
                                {
                                    patch.KbArticle = reader.GetString(1);
                                }
                            }
                            else
                            {
                                patch.KbArticle = string.Empty;
                            }

                            //log.LogDebug("get next result set 2");
                            reader.NextResult();
                            if (reader.HasRows)
                            {
                                //log.LogDebug($"Data row found");
                                while (reader.Read())
                                {
                                    patch.Bulletin = reader.GetString(1);
                                }
                            }
                            else
                            {
                                patch.Bulletin = string.Empty;
                            }


                            //get patch URL
                            //log.LogDebug("get next result set 2");
                            reader.NextResult();
                           
                            if (reader.HasRows)
                            {
                                //log.LogDebug($"Data row found");
                                while (reader.Read())
                                {
                                    patch.Url = reader.GetString(1);
                                }
                            }
                            else
                            {
                                patch.Url = string.Empty;
                            }

                            reader.Close();
                        }
                    }//try
                    catch (SqlException sqlex)
                    {
                        log.LogError($"==>SQL Error Code: {sqlex.ErrorCode}");
                        log.LogError($"==>SQL Error Message: [{sqlex.Number}] {sqlex.Message}");
                        log.LogError($"==>SQL Procedure: {sqlex.Procedure}");
                        log.LogError($"==>SQL Error State: {sqlex.State}");
                        throw new PatchingWSUSConnectionException($"Unable to connect to the Intensive WSUS server {this.WUServer}");
                    }
                    finally
                    {
                        cmd?.Dispose();

                    }
                }//if wuserver contains rackspace.com
                else
                {
                    if (string.IsNullOrEmpty(this.WUServer))
                    {
                        throw new PatchingWSUSConnectionException($"WSUS Server name is empty");
                    }
                    else
                    {
                        throw new PatchingWSUSConnectionException($"Unable to connect to the 3rd party WSUS server {this.WUServer}");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                throw new PatchingWSUSNotFoundException($"Patch data not found in WSUS", ex);
            }


            try 
            { 
                //log.LogDebug($"Getting Patch status for this client...");
                TbUpdateStatusPerComputer tbStatus = wsus.TbUpdateStatusPerComputer
                                                            .AsNoTracking()
                                                            .Single(
                                                                p => p.LocalUpdateId == patch.LocalId && p.TargetId == this.TargetId
                                                            );
               
                patch.State = Enum.GetName(typeof(PatchStatus.PatchingState),tbStatus.SummarizationState);
                patch.StateChangeDate = tbStatus.LastChangeTime;
                //patch.TargetId = (int)this.TargetId;

                return patch;

            }
            catch (InvalidOperationException ex)
            {
                throw new PatchingWSUSNotFoundException($"Status information not found for patch", ex);
            }
        }


        public void Refresh() { } //pull setting from device via ARIC process

        public  void PatchNow() { } //initiate ARIC process to install patches
    }
}
