using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using Intensive.Data.SSDatabase;
using Intensive.Data.ADMT;
using System.Security;
using Newtonsoft.Json;


namespace Intensive.Services.ActiveDirectory
{

    public class AdMigrationHistory
    {
        public Guid ID { get; set; }
        public int Account { get; set; }
        public int TaskId { get; set; }
        public DateTime Submitted { get; set; }
        public string MigrationType { get; set; }
        public string SSO { get; set; }
        public string DataCenter { get; set; }
        public string SourceDomain { get; set; }
        public string Datacenter { get; set; }
        //public string SourceOU { get; set; }
        public string TargetOU { get; set; }
        public string Status { get; set; }
        public List<string> Objects { get; set; }   //DNs of objects to be migrated;  Will be parsed and grouped; separate ADMT.EXE will be executed for each grouping 



        private ILogger<AdMigrationHistory> log;
        private AdSystemConfig config;
        private ADMTConfig admtConfig;
        //private ADMTContext admtDB;
        private SSDatabaseContext db;


        public AdMigrationHistory() {
            this.Objects = new List<string>();
            this.DataCenter = null;
        }

        public AdMigrationHistory(ILogger<AdMigrationHistory> logger,
                            IOptions<AdSystemConfig> adconfig,
                            IOptions<ADMTConfig> admtconfig,
                            //ADMTDBContextFactory admt,
                            SSDatabaseContext dbcontext
                            )
        {
            log = logger;
            log.LogDebug($"log initialized");
            config = adconfig.Value;
            admtConfig = admtconfig.Value;
            //log.LogDebug($"admt db conn string: {admtConfig.Database}");
            //admtDB = admt.Create(admtConfig.Database);//create DB Context
            db = dbcontext;
            this.Objects = new List<string>();
        }


        //Find
        public List<AdMigrationHistory> Find(int account, string status=null)
        {
            List<AdMigrationHistory> lst = new List<AdMigrationHistory>();
            AdMigrationHistory hist;
            List<TbAdmigrations> dbList;

            try
            {

                if (string.IsNullOrEmpty(status))
                {
                    dbList = db.TbAdmigrations.AsNoTracking().Where(h => h.Account == account).ToList<TbAdmigrations>();
                }
                else
                {
                    if (account == -1)
                    {
                        dbList = db.TbAdmigrations.AsNoTracking().Where(h => h.Status == status).ToList<TbAdmigrations>();
                    }
                    else
                    {
                        dbList = db.TbAdmigrations.AsNoTracking().Where(h => h.Account == account && h.Status == status).ToList<TbAdmigrations>();
                    }

                }
            }
            catch (InvalidOperationException nf)
            {
                dbList = new List<TbAdmigrations>();  //return empty list
            }
            catch(Exception ex)
            {
                throw;
            }

            foreach (TbAdmigrations t in dbList)
            {
                hist = new AdMigrationHistory()
                {
                    Account = t.Account,
                    MigrationType = t.MigrationType,
                    SourceDomain = t.SourceDomain,
                    //SourceOU = t.SourceDomain,
                    Datacenter = t.Datacenter,
                    SSO = t.Sso,
                    Status = t.Status,
                    Submitted = t.Submitted,
                    TargetOU = t.TargetOu,
                    TaskId = t.TaskId,
                    ID = t.Id,
                    Objects = JsonConvert.DeserializeObject<List<string>>(t.Objects)
                };
                lst.Add(hist);
            }

            return lst;
        }

        public Task<List<AdMigrationHistory>> FindAsync(int account)
        {
            List<AdMigrationHistory> lst = new List<AdMigrationHistory>();
            AdMigrationHistory hist;

            List<TbAdmigrations> dbList = db.TbAdmigrations.AsNoTracking().Where(h => h.Account == account).ToList<TbAdmigrations>();
            foreach (TbAdmigrations t in dbList)
            {
                hist = new AdMigrationHistory()
                {
                    Account = t.Account,
                    MigrationType = t.MigrationType,
                    SourceDomain = t.SourceDomain,
                    //SourceOU = t.SourceDomain,
                    Datacenter = t.Datacenter,
                    SSO = t.Sso,
                    Status = t.Status,
                    Submitted = t.Submitted,
                    TargetOU = t.TargetOu,
                    TaskId = t.TaskId,
                    ID = t.Id,
                    
                };
                lst.Add(hist);
            }

            return Task.FromResult(lst);
        }

        //Load
        public void Load(Guid id)
        {
            TbAdmigrations t = db.TbAdmigrations.AsNoTracking().FirstOrDefault(h => h.Id == id);

            if (t == null) //not found;
            {
                throw new ADNotFoundException($"No migration history for migration id {id}");
            }
            this.ID = t.Id;
            this.Account = t.Account;
            this.MigrationType = t.MigrationType;
            this.SourceDomain = t.SourceDomain;
            this.Datacenter = t.Datacenter;
            this.SSO = t.Sso;
            this.Status = t.Status;
            this.Submitted = t.Submitted;
            this.TargetOU = t.TargetOu;
            this.TaskId = t.TaskId;
            this.Objects = JsonConvert.DeserializeObject<List<string>>(t.Objects);
        }
        public async Task LoadAsync(Guid id)
        {
            TbAdmigrations t = await db.TbAdmigrations.AsNoTracking().FirstOrDefaultAsync(h => h.Id == id);

            if (t == null) //not found;
            {
                throw new ADNotFoundException($"No migration history for migration id {id}");
            }
            this.ID = t.Id;
            this.Account = t.Account;
            this.MigrationType = t.MigrationType;
            this.SourceDomain = t.SourceDomain;
            this.Datacenter = t.Datacenter;
            this.SSO = t.Sso;
            this.Status = t.Status;
            this.Submitted = t.Submitted;
            this.TargetOU = t.TargetOu;
            this.TaskId = t.TaskId;
            this.Objects = JsonConvert.DeserializeObject<List<string>>(t.Objects);
        }

        //Save
        public void Save()
        {
            log.LogDebug("==>Saving ADMT Status(Synchronous)....");
            log.LogDebug($"==>{JsonConvert.SerializeObject(this)}");
            TbAdmigrations curr = db.TbAdmigrations.FirstOrDefault(h => h.Id == this.ID);

            if (curr == null)   //does not exist
            {
                log.LogDebug("==>Inserting NEW ADMT Status....");
                curr = new TbAdmigrations();
                curr.Account = this.Account;
                curr.MigrationType = this.MigrationType;
                curr.SourceDomain = this.SourceDomain;
                curr.Datacenter = this.Datacenter;
                curr.Sso = this.SSO;
                curr.Status = this.Status;
                curr.Submitted = this.Submitted;
                curr.TargetOu = this.TargetOU;
                curr.TaskId = this.TaskId;
                curr.Id = this.ID;
                curr.Objects = JsonConvert.SerializeObject(this.Objects);
                db.TbAdmigrations.Add(curr);
            }
            else
            {
                log.LogDebug("==>Updating ADMT Status....");
                curr.Account = this.Account;
                curr.MigrationType = this.MigrationType;
                curr.SourceDomain = this.SourceDomain;
                curr.Datacenter = this.Datacenter;
                curr.Sso = this.SSO;
                curr.Status = this.Status;
                curr.Submitted = this.Submitted;
                curr.TargetOu = this.TargetOU;
                curr.TaskId = this.TaskId;
                curr.Id = this.ID;
                curr.Objects = JsonConvert.SerializeObject(this.Objects);
            }

            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            log.LogDebug("==>Saving ADMT Status(Asynchronous)....");
            log.LogDebug($"==>{JsonConvert.SerializeObject(this)}");

            TbAdmigrations curr = db.TbAdmigrations.FirstOrDefault(h => h.Id == this.ID);

            if (curr == null)   //does not exist
            {
                log.LogDebug("==>Inserting NEW ADMT Status....");

                curr = new TbAdmigrations();
                curr.Account = this.Account;
                curr.MigrationType = this.MigrationType;
                curr.SourceDomain = this.SourceDomain;
                curr.Datacenter = this.Datacenter;
                curr.Sso = this.SSO;
                curr.Status = this.Status;
                curr.Submitted = this.Submitted;
                curr.TargetOu = this.TargetOU;
                curr.TaskId = this.TaskId;
                curr.Id = this.ID;
                curr.Objects = JsonConvert.SerializeObject(this.Objects);
                db.TbAdmigrations.Add(curr);
            }
            else  //update current row
            {
                log.LogDebug("==>Updating ADMT Status....");

                curr.Account = this.Account;
                curr.MigrationType = this.MigrationType;
                curr.SourceDomain = this.SourceDomain;
                curr.Datacenter = this.Datacenter;
                curr.Sso = this.SSO;

                log.LogDebug($"==>updating status from {curr.Status} to {this.Status}....");
                curr.Status = this.Status;
                curr.Submitted = this.Submitted;
                curr.TargetOu = this.TargetOU;
                log.LogDebug($"==>updating taskid from {curr.TaskId} to {this.TaskId}....");
                curr.TaskId = this.TaskId;
                //curr.Id = this.ID;
                curr.Objects = JsonConvert.SerializeObject(this.Objects);
            }

            log.LogDebug("==>SaveChangesAsync()....");
            await db.SaveChangesAsync();
        }

        public string GetMigrationLog()
        {
            log.LogDebug($"[GetMigrationLog]");
            string dc = string.Empty;

            if ( (this.MigrationType == "computer") && (this.SourceDomain == "intensive.int") )
            {
                //dc = $"{this.SourceDomain.Substring(0, 3).ToUpper()}-{this.Datacenter.ToUpper()}";
                dc = this.Datacenter.ToUpper();
            }
            else
            {
                dc = this.SourceDomain.Substring(0, 3).ToUpper();
            }
            log.LogDebug($"[GetMigrationLog]dc={dc}");
            string svr = admtConfig.ADMTServers[dc];
            log.LogDebug($"[GetMigrationLog]svr={svr}");
            string fileName = $"Migration{this.TaskId.ToString("D6")}.log";
            log.LogDebug($"[GetMigrationLog]logfile={fileName}");

            string unc = $"\\\\{svr}\\ADMTLogs\\{fileName}";
            log.LogDebug($"UNC path: {unc}");
            string logText = File.ReadAllText(unc);

            return logText;
        }

        public string GetUserMigrationPasswords()
        {
            string dc = string.Empty;

            if (this.MigrationType == "computer")
            {
                dc = $"{this.SourceDomain.Substring(0, 3).ToUpper()}-{this.Datacenter.ToUpper()}";
            }
            else
            {
                dc = this.SourceDomain.Substring(0, 3).ToUpper();
            }
            string svr = admtConfig.ADMTServers[dc];
            string fileName = $"Passwords_{this.ID.ToString()}.txt";
            string unc = $"\\\\{svr}\\ADMTLogs\\{fileName}";

            log.LogDebug($"UNC path: {unc}");
            string logText = File.ReadAllText(unc);

            return logText;
        }

    }
}
