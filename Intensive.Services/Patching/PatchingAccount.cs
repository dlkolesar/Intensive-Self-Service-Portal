using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Hosting;
using Intensive.Data.SSDatabase;
using Intensive.Data.EBIDataMart;
//using Intensive.Services.Aric;
//using Intensive.Data.WSUS;
using Intensive.Services.Patching.Exceptions;
using Intensive.Services.Common;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.CTKAPIWrapper.CTKObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;

//using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Intensive.Services.Patching
{
    public class PatchingAccount
    {
        public int Number { get; set; }
        public bool OptedOut { get; set; }
        public DateTime? OptInOutDate { get; set; }
        public string OptInOutTicket { get; set; }
        public bool OptedOutOfTicketing { get; set; }
        public DateTime? LastRefresh { get; set; }
        
        SSDatabaseContext db;
        Corporate_DMARTContext dmart;
        PatchingClient client;
        //AricJob aricJob;
        ILogger<PatchingAccount> log;
        CTKAPI core;
        //AricSystemConfig aricConfig;
        IConfiguration config;

        public PatchingAccount() { }

        public PatchingAccount(SSDatabaseContext dbContext,
                                Corporate_DMARTContext dm,
                                PatchingClient pc,
                                //AricJob arjob,
                                //IOptions<AricSystemConfig> cfgAric,
                                IConfiguration cfg,
                                CTKAPI ctkapi,
                                ILogger<PatchingAccount> logger)
        {
            dmart = dm;
            db = dbContext;
            client = pc;
            //aricJob = arjob;
            log = logger;
            core = ctkapi;
            //aricConfig = cfgAric.Value;
            config = cfg;
        }
        public void Load(int acct)
        {
            try
            {
                log.LogDebug($"Loading Account {acct}");

                //if (db == null) { log.LogDebug("db is null"); }

                TbPatchingAccounts tbPatchAcct = db.TbPatchingAccounts.AsNoTracking().Single(a => a.Number == acct);

                //if (tbPatchAcct == null) { log.LogDebug("tbPatchAcct is null"); }

                this.Number = tbPatchAcct.Number;
                this.OptedOut = tbPatchAcct.OptedOut;
                this.OptInOutDate = tbPatchAcct.OptInOutDate;
                this.OptInOutTicket = tbPatchAcct.OptInOutTicket;
                this.OptedOutOfTicketing = tbPatchAcct.OptedOutOfTicketing;
                this.LastRefresh = tbPatchAcct.LastRefresh;
            }
            catch (InvalidOperationException ex)
            {
                throw new PatchingNotFoundException($"Patching Account {acct} not found in database", ex);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PatchingAccount> AllOptedInAccounts()
        {
            List<PatchingAccount> accounts = new List<PatchingAccount>();
            try
            {
                List<TbPatchingAccounts> tbPatchAcct = db.TbPatchingAccounts
                                                        .AsNoTracking()
                                                        .Where(a => !a.OptedOut)
                                                        .ToList<TbPatchingAccounts>();

                PatchingAccount pa = new PatchingAccount();
                foreach (TbPatchingAccounts tbpa in tbPatchAcct)
                {
                    pa = new PatchingAccount();
                    pa.Number = tbpa.Number;
                    pa.OptedOut = tbpa.OptedOut;
                    pa.OptInOutDate = tbpa.OptInOutDate;
                    pa.OptInOutTicket = tbpa.OptInOutTicket;
                    pa.OptedOutOfTicketing = tbpa.OptedOutOfTicketing;
                    pa.LastRefresh = tbpa.LastRefresh;

                    accounts.Add(pa);
                }
                return accounts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Server> GetPatchingClients()
        {
            //Account exists, now get the list of clients for the account
            List<Server> clients = new List<Server>();
            //log.LogDebug($"Loading {this.Number} Client List....");
            List<TbServers> Servers = db.TbServers
                                            .AsNoTracking()
                                            //.Where(s => ( 
                                            //                (s.Account == this.Number) && 
                                            //                (s.Wsusid != null) 
                                            //                //(s.Wsusid != Guid.Empty)
                                            //            )
                                            //      )
                                            .Where(s => s.Account == this.Number )
                                            .ToList<TbServers>();

            Server svr;

            foreach (TbServers s in Servers)
            {
                svr = new Server(s);
                clients.Add(svr);
            }

            return clients;

            //PatchingClient pc;

            //foreach (TbServers svr in Servers)
            //{
            //    try
            //    {
            //        client.Load(svr.DeviceNumber);
            //        //clients.Add(client);
            //    }
            //    catch(Exception ex)
            //    {
            //        //continue;
            //    }
            //    finally
            //    {
            //        pc = JsonConvert.DeserializeObject<PatchingClient>(JsonConvert.SerializeObject(client));
            //        clients.Add(pc);
            //    }

            //}
            //return clients;


        }

        public void Create()
        {
            TbPatchingAccounts tbPatchAcct = new TbPatchingAccounts();
            tbPatchAcct.Number = this.Number;
            tbPatchAcct.OptedOut = this.OptedOut;
            tbPatchAcct.OptInOutDate = DateTime.UtcNow;
            tbPatchAcct.OptInOutTicket = this.OptInOutTicket;
            tbPatchAcct.OptedOutOfTicketing = this.OptedOutOfTicketing;

            db.TbPatchingAccounts.Add(tbPatchAcct);
            db.SaveChanges();
        }

        public void Save()
        {
            TbPatchingAccounts tbPatchAcct;
            try
            {
                tbPatchAcct = db.TbPatchingAccounts.First(a => a.Number == this.Number);

                tbPatchAcct.OptedOutOfTicketing = this.OptedOutOfTicketing;

                db.SaveChanges();
            }
            catch(InvalidOperationException ex)
            {
                throw new PatchingNotFoundException(ex.Message, ex);
            }
        }


        //public async Task<List<int>> OptIn(string ticket, string token, string sso)
        public void OptIn(string ticket, string token, string sso)
        {
            TbPatchingAccounts tbPatchAcct;
            try
            {
                tbPatchAcct = db.TbPatchingAccounts.Single(a => a.Number == this.Number);

                tbPatchAcct.OptedOut = false;
                tbPatchAcct.OptInOutDate = DateTime.UtcNow;
                tbPatchAcct.OptInOutTicket = ticket;

                db.SaveChanges();

            }
            catch (InvalidOperationException ex)
            {
                //throw new PatchingNotFoundException(ex.Message, ex);
                this.Create();
            }

            //List<int> newDevices = await RefreshAccount(sso, token);
            //return newDevices;
        }

        public void OptOut(string ticket)
        {
            TbPatchingAccounts tbPatchAcct;
            try
            {
                tbPatchAcct = db.TbPatchingAccounts.First(a => a.Number == this.Number);

                tbPatchAcct.OptedOut = true;
                tbPatchAcct.OptInOutDate = DateTime.UtcNow;
                tbPatchAcct.OptInOutTicket = ticket;

                db.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                throw new PatchingNotFoundException(ex.Message, ex);
            }
        }

   
        public async Task<List<int>> RefreshAccount(string sso, string token)
        {
            log.LogDebug($"Updating Patching Client list....");
            List<int> NewClients = new List<int>();

            List<string> Attributes = new List<string>()
                                                {
                                                    "computers.number",
                                                    "computers.name",
                                                    "computers.datacenter.symbol",
                                                    "computers.status.number",
                                                    "computers.is_windows",
                                                    "computers.is_cluster"
                                                };

            if (!core.CurrentUser.valid)    //if token has expired
            {
                JObject jo = JObject.Parse(config.GetValue<string>("CORE"));
                core.Login(jo["user"].ToString(), jo["password"].ToString());
            }

            CTKAccount ctkAccount = new CTKAccount(core, this.Number, Attributes);

            //most effcient way I could think of to get data on ALL computers in the account
            //without running into CORE's throttling limit; it's ugly, but it works
            //takes only about 1min for the largest accounts
            int[] device = ((JArray)ctkAccount.Properties["computers.number"]).Select(j => (int)j).ToArray();
            string[] name = ((JArray)ctkAccount.Properties["computers.name"]).Select(j => (string)j).ToArray();
            string[] dc = ((JArray)ctkAccount.Properties["computers.datacenter.symbol"]).Select(j => (string)j).ToArray();
            int[] status = ((JArray)ctkAccount.Properties["computers.status.number"]).Select(j => (int)j).ToArray();
            bool[] windows = ((JArray)ctkAccount.Properties["computers.is_windows"]).Select(j => (bool)j).ToArray();
            bool[] cluster = ((JArray)ctkAccount.Properties["computers.is_cluster"]).Select(j => (bool)j).ToArray();

            //load current device numbers into memory to avoid excessive DB IO's
            List<int> CurrentServers = await db.TbServers
                                            .AsNoTracking()
                                            .Where(s => s.Account == this.Number)
                                            .Select(s => s.DeviceNumber)
                                            .ToListAsync<int>();


            List<int> CurrentClients = await db.TbPatchingClients.AsNoTracking()
                                                        .Where(c => CurrentServers.Contains(c.DeviceNumber))
                                                        .Select(c => c.DeviceNumber)
                                                        .ToListAsync<int>();

            for (int i = 0; i < device.Length; i++)
            {
                //import if status >= 9(Seg Config), AND is_windows == true AND is_cluster == false

                if ((status[i] >= 9) && (windows[i]) && (!cluster[i]))
                {
                    if (CurrentServers.Contains(device[i])) //server already exists in the DB
                    {
                        continue;
                    }
                    else
                    {
                        log.LogDebug($"   Adding Server {name[i]}....");
                        try
                        {
                            TbServers tbServer = new TbServers();
                            tbServer.Account = this.Number;
                            tbServer.DeviceNumber = device[i];
                            tbServer.DataCenter = dc[i].Substring(0, 3);
                            tbServer.IsCluster = false;
                            tbServer.Name = name[i];
                            tbServer.Os = "";
                            tbServer.LastRefresh = new DateTime(1753, 1, 1);
                            tbServer.IsClusterNode = false;

                            await db.TbServers.AddAsync(tbServer);
                            //await db.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }


                    if (CurrentClients.Contains(device[i])) //patching client already exists in DB
                    {
                        continue;
                    }
                    else
                    {
                        log.LogDebug($"   Adding Patching Client {name[i]}....");
                        try
                        {
                            TbPatchingClients newClient = new TbPatchingClients
                            {
                                Auoptions = 4,
                                DeviceNumber = -1,
                                LastPatchDate = null,
                                OptedOut = false,
                                PatchingLevel = 1,
                                TargetId = -1,
                                UseWuserver = 1,
                                Wsusid = null,
                                Wuserver = string.Empty
                            };
                            newClient.DeviceNumber = device[i];
                            newClient.LastRefresh = new DateTime(1753, 1, 1); ;  //set to minimum value to force a settings refresh

                            await db.TbPatchingClients.AddAsync(newClient);

                            TbPatchingClientConfigBasic config = new TbPatchingClientConfigBasic
                            {
                                DeviceNumber = newClient.DeviceNumber,
                                NoAutoRebootWithLoggedOnUsers = 0,
                                ScheduledWeek = 1,
                                ScheduledDay = 1,
                                ScheduledTime = 1
                            };

                            await db.TbPatchingClientConfigBasic.AddAsync(config);
                            await db.SaveChangesAsync();
                            NewClients.Add(device[i]);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                
                }//if status>=9....

            }

            //return Task.CompletedTask;
            return NewClients;
        }
     }
}
