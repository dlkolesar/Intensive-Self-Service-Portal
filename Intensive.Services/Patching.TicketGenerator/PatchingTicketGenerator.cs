using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data.SSDatabase;
using Intensive.Services.Common;
using Intensive.Services.CTKAPIWrapper;
using Intensive.Services.CTKAPIWrapper.CTKObjects;
using Intensive.Services.Patching.Exceptions;
//using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prometheus;

namespace Intensive.Services.Patching.TicketGenerator
{
    //register with DI as a Singleton
    //Call the Generate() method with the account number to generate patching ticket(s) for the account

    public class PatchingTicketGenerator
    {
        //move to Config table in DB?
        const string IDENTITY_API = "https://identity-internal.api.rackspacecloud.com/v2.0/tokens";
        const string PATCHING_CLIENT_API = "https://api.selfservice.intensive.int/winpatch/v1";

        ILogger log;
        SSDatabaseContext db;
        PatchingAccount patchingAccount;
        PatchingClient client;
        PatchingSystemConfig patchingConfig;

        GeneratorConfig config;

        COREAccount coreAccount = null;
        CTKAPI core = null;
        CTKQuery CORERequest = new CTKQuery();

        AutomaticPatchingTicket AutomaticTicket;
        ManualPatchingTicket ManualTicket;
        PatchingTicketHistory patchingHistory;
        List<Claim> claims = new List<Claim>();

        //Metrics
        static Counter TotalServers = Metrics.CreateCounter("ptg_ticket_servers_total", "Ticket Servers",
                                                                        new CounterConfiguration
                                                                        {
                                                                            LabelNames = new[] { "ticket_type" }
                                                                        }
                                                                     );

        static Counter TotalTickets = Metrics.CreateCounter("ptg_tickets_total", "Tickets Created",
                                                                        new CounterConfiguration
                                                                        {
                                                                            LabelNames = new[] { "ticket_type" }
                                                                        }
                                                                     );
  

        static MetricPusher pusher = new MetricPusher(new MetricPusherOptions
        {
            Endpoint = "https://prom-push-mon-sstools-prod.iad.devapps.rsi.rackspace.net/metrics",
            Job = "PatchingTicketGenerator",
            Instance = DateTime.Now.ToString("yyyyMM")
        });

        public PatchingTicketGenerator(ILogger<PatchingTicketGenerator> logger,
                                        SSDatabaseContext dbContext,
                                        PatchingAccount pa,
                                        PatchingClient pc,
                                        PatchingTicketHistory pth,
                                        CTKAPI coreCTKAPI,
                                        AutomaticPatchingTicket autoTkt,
                                        ManualPatchingTicket manTkt,
                                        IOptions<PatchingSystemConfig> psc,
                                        IOptions<GeneratorConfig> gc
                                        )
        {
            log = logger;
            db = dbContext;
            patchingAccount = pa;
            client = pc;
            core = coreCTKAPI;

            AutomaticTicket = autoTkt;
            ManualTicket = manTkt;
            patchingHistory = pth;
            //config = this.GetConfig();
            config = gc.Value;
            patchingConfig = psc.Value;

            //timetable = tt;
            
        }

        public List<string> GeneratePreview(int acct)
        {
            return this.Generate(acct, true);
        }

        //pass in PatchingAccount object???
        public List<string> Generate(int acct, bool PreviewOnly = false)
        {
            log.LogDebug($"Generator starting....");
           // pusher.Start();
            string RunID = DateTime.Now.ToString("yyyyMM");

            List<string> returnData = new List<string>();

            claims = Authenticate().Result;

            coreAccount = GetCoreAccountData(acct);

            patchingAccount.Load(acct);

            //List<Server> AllServers = patchingAccount.GetPatchingClients().ToList<Server>();
            List<Server> AllServers = patchingAccount.GetPatchingClients();
            log.LogDebug($"Account has {AllServers.Count} servers with a WSUSID...");

            List<PatchingClient> AllPatchingClients = new List<PatchingClient>();
            PatchingClient client = null;

            log.LogDebug($"Building Patching Client List...");
            foreach (Server svr in AllServers)
            {
                try
                {
                    client = GetPatchingClient(svr.DeviceNumber);
                    //client.Load(svr.DeviceNumber);
                    AllPatchingClients.Add(client); //add to list regardless of errors/exceptions
                }
                catch (Exception ex)
                {
                    //ignore exceptions
                    log.LogDebug($"==> ERROR: {ex}");
                }
            }
      
            //log.LogInformation("  " + AllPatchingClients.Count.ToString() + " Devices");

            log.LogDebug($"Clients: {AllPatchingClients.Count}");

            List<PatchingClient> AutoPatchingClients = AllPatchingClients
                                                        .Where(c => (
                                                                        ((c.PatchingLevel == PatchingLevels.Basic) || (c.PatchingLevel == PatchingLevels.Advanced))
                                                                        &&
                                                                        (c.UnSupportedOS == false)
                                                                    )
                                                              )
                                                        .ToList<PatchingClient>();

            List<PatchingClient> ManualPatchingClients = AllPatchingClients
                                                                .Where(c => (c.PatchingLevel == PatchingLevels.Manual)
                                                                         && (c.UnSupportedOS == false)
                                                                )
                                                                .ToList<PatchingClient>();


            //List<PatchingClient> AdvancedPatchingClients = AllPatchingClients
            //                                                    .Where(c => c.PatchingLevel == PatchingLevels.Advanced)
            //                                                    .ToList<PatchingClient>();


            log.LogDebug($"  Clients(Auto): {AutoPatchingClients.Count}");
            //foreach (PatchingClient pc in AutoPatchingClients)
            //{
            //    log.LogDebug($"    {JsonConvert.SerializeObject(pc)}");
            //}

            log.LogDebug($"  Clients(Manual): {ManualPatchingClients.Count}");
            //foreach (PatchingClient pc in ManualPatchingClients)
            //{
            //    log.LogDebug($"    {JsonConvert.SerializeObject(pc)}");
            //}

            

            //call in multiple threads --parallel tasks ?
            if (ManualPatchingClients.Count > 0)
            {
                if (PreviewOnly)
                {
                    string preview = ManualTicket.GeneratePreview(coreAccount,
                                                                    ManualPatchingClients,
                                                                    config);
                    returnData.Add(preview);
                }
                else
                {
                    log.LogDebug($"Generating MANUAL ticket");
                    string tktNumber;
                    
                    tktNumber = ManualTicket.GenerateTicket(coreAccount,
                                                                    ManualPatchingClients,
                                                                    config);

                    //log.LogDebug($"ticket: {tktNumber}");

                    //hist = new PatchingTicketHistory(RunID, acct, tktNumber, "Manual");
                    patchingHistory.Account = acct;
                    patchingHistory.CoreTicket = tktNumber;
                    patchingHistory.RunId = RunID;
                    patchingHistory.TicketType = "Manual";

                    patchingHistory.Save();

                    returnData.Add(tktNumber);
                    TotalTickets.Inc();
                    TotalTickets.WithLabels(patchingHistory.TicketType).Inc();

                    TotalServers.Inc(ManualPatchingClients.Count);
                    TotalServers.WithLabels(patchingHistory.TicketType).Inc(ManualPatchingClients.Count);
                }
            }

            if (AutoPatchingClients.Count > 0)
            {
                if (PreviewOnly)
                {
                    string preview = AutomaticTicket.GeneratePreview(coreAccount,
                                                                    AutoPatchingClients,
                                                                    config);
                    returnData.Add(preview);
                }
                else
                {
                    log.LogDebug($"Generating AUTOMATIC ticket");
                    string tktNumber = AutomaticTicket.GenerateTicket(coreAccount,
                                                                    AutoPatchingClients,
                                                                    config);


                    patchingHistory.Account = acct;
                    patchingHistory.CoreTicket = tktNumber;
                    patchingHistory.RunId = RunID;
                    patchingHistory.TicketType = "Automatic";

                    patchingHistory.Save();
                    returnData.Add(tktNumber);

                    TotalTickets.Inc();
                    TotalTickets.WithLabels(patchingHistory.TicketType).Inc();

                    TotalServers.Inc(AutoPatchingClients.Count);
                    TotalServers.WithLabels(patchingHistory.TicketType).Inc(AutoPatchingClients.Count);
                }
            }
           // pusher.Stop();
            return returnData;
        }

        //replaced by DI GeneratorConfig
        //public GeneratorConfig GetConfig()
        //{
        //    GeneratorConfig config = null;
        //    try
        //    {
        //        TbConfig tbConfig = db.TbConfig.AsNoTracking().Single(c => c.ConfigKey == "PatchingTicketGenerator");
        //        config = JsonConvert.DeserializeObject<GeneratorConfig>(tbConfig.ConfigJson);
        //    }
        //    catch (InvalidOperationException ioe)
        //    {
        //        throw new PatchingNotFoundException("Error getting config for Patching Ticket Generator", ioe);
        //    }
        //    return config;
        //}

        public void SaveConfig(GeneratorConfig newConfig)
        {
            TbConfig tbConfig = db.TbConfig.Single(c =>  c.ConfigKey == "PatchingTicketGenerator");

            string json = JsonConvert.SerializeObject(newConfig);

            tbConfig.ConfigJson = json;
            db.SaveChanges();
        }
        private COREAccount GetCoreAccountData(int acct)
        {
            List<string> ticketRoles = new List<string>() { "Primary Contact", "Administrative", "Technical", "Reviewer" };
            COREAccount a = new COREAccount();


            //log.LogDebug($"core.url: {core.BaseURL}");
            //log.LogDebug($"core.token: {core.Token}");
            List<string> Attributes = new List<string>(){"account_exec.id",
                                                "account_exec.name",
                                                "support_team.name",
                                                "support_queue.id",
                                                "support_queue.name",
                                                "segment.name",
                                                "customer_patching_instructions.note",
                                                "customer_contacts.contact.id",
                                                "customer_contacts.role.description"
                                                };

            CTKAccount ctkAccount = new CTKAccount(core, acct, Attributes);

            a.Number = acct;
            a.SupportTeamName = ctkAccount.Properties["support_team.name"].ToString();
            a.SupportQueueID = Convert.ToInt32(ctkAccount.Properties["support_queue.id"].ToString());
            a.SupportQueueName = ctkAccount.Properties["support_queue.name"].ToString();

            a.SegmentName = ctkAccount.Properties["segment.name"].ToString();

            if (a.SupportTeamName.StartsWith("ENT"))
            {
                a.SegmentName = "Enterprise Services";
            }

            if (ctkAccount.Properties["account_exec.name"] == null) 
            {
                a.AM = "None";
                a.AM_ContactID = -1;
            } 
            else
            {
                a.AM = ctkAccount.Properties["account_exec.name"].ToString();
                a.AM_ContactID = Convert.ToInt32(ctkAccount.Properties["account_exec.id"]);
            }
            if (a.AM_ContactID == 0) { a.AM_ContactID = 77038; } //Segment Support Account

            a.CustomerContactIDs = new List<int>();

            JArray ja_ids = (JArray)ctkAccount.Properties["customer_contacts.contact.id"];
            string[] ids = ja_ids.ToObject<string[]>();

            JArray ja_roles = (JArray)ctkAccount.Properties["customer_contacts.role.description"];
            string[] roles = ja_roles.ToObject<string[]>();

            for (int i = 0; i < roles.Length; i++)
            {
                if (ticketRoles.Contains(roles[i]))
                {
                    a.CustomerContactIDs.Add(Convert.ToInt32(ids[i]));
                }
            }

            a.ManualPatching = false;

            if (ctkAccount.Properties["customer_patching_instructions.note"] == null)
            {
                a.PatchingInstructions = string.Empty;
            }
            else
            {
                a.PatchingInstructions = ctkAccount.Properties["customer_patching_instructions.note"].ToString();
            }

            return a;

        }

        //public List<PatchingTicketHistory> Find(int? account, string ticket, string runid, string ticketType)
        //{
        //    //third-party depenedency - LinqKit
        //    // http://www.albahari.com/nutshell/predicatebuilder.aspx
        //    // https://www.codeproject.com/Articles/28580/LINQ-and-Dynamic-Predicate-Construction-at-Runtime
        //    var predicate = PredicateBuilder.New<TbPatchingTicketHistory>();

        //    if ((account != null) && (account > 0))
        //    {
        //        predicate.And(a => a.Account == account);
        //    }

        //    if (!string.IsNullOrEmpty(ticket))
        //    {
        //        predicate.And(a => a.CoreTicket == ticket);
        //    }

        //    if (!string.IsNullOrEmpty(runid))
        //    {
        //        predicate.And(a => a.RunId == runid);
        //    }

        //    if (!string.IsNullOrEmpty(ticketType))
        //    {
        //        predicate.And(a => a.TicketType == ticketType);
        //    }

        //    List<PatchingTicketHistory> list = new List<PatchingTicketHistory>();

        //    List<TbPatchingTicketHistory> rows = db.TbPatchingTicketHistory
        //                                                .AsNoTracking()
        //                                                .AsExpandable()
        //                                                .Where(predicate)
        //                                                .ToList<TbPatchingTicketHistory>();

        //    PatchingTicketHistory hist = new PatchingTicketHistory();

        //    foreach (TbPatchingTicketHistory r in rows)
        //    {
        //        hist = new PatchingTicketHistory();
        //        hist.Account = r.Account;
        //        hist.CoreTicket = r.CoreTicket;
        //        hist.RunId = r.RunId;
        //        hist.TicketType = r.TicketType;
        //        hist.Updated = r.Updated;
        //        list.Add(hist);
        //    }

        //    return list;
        //}

        //public void SaveTicketHistory(PatchingTicketHistory hist)
        //{
        //    log.LogDebug($"Saving History Entry: {hist.Account}/{hist.CoreTicket}");
        //    TbPatchingTicketHistory newHistory = new TbPatchingTicketHistory();
        //    newHistory.Account = hist.Account;
        //    newHistory.CoreTicket = hist.CoreTicket;
        //    newHistory.RunId = hist.RunId;
        //    newHistory.TicketType = hist.TicketType;
        //    newHistory.Updated = false;

        //    db.TbPatchingTicketHistory.Add(newHistory);
        //    db.SaveChanges();
        //}

        public double GetTicketGeneratorProgress(string runid)//assumes the runid for the current month/year
        {
            List<PatchingTicketHistory> list = new List<PatchingTicketHistory>();
          
            TbPatchingTicketHistory r = db.TbPatchingTicketHistory.AsNoTracking()
                                              .SingleOrDefault<TbPatchingTicketHistory>(t => t.RunId == runid && t.Account == -1);
            if (r == null)
            {
                throw new PatchingNotFoundException("Progress record not found. Ticket Generator is not running");
            }
            else
            {
                double pct = Convert.ToDouble(r.CoreTicket);
                return pct;
            }
            
        }


        //public void ClearUpdateFlag(string runid)
        //{
        //    List<TbPatchingTicketHistory> rows = db.TbPatchingTicketHistory.Where(h => h.RunId == runid).ToList<TbPatchingTicketHistory>();
        //    foreach (TbPatchingTicketHistory row in rows)
        //    {
        //        row.Updated = false;
        //    }

        //    db.SaveChanges();
        //}

        //public void SetUpdateFlag(string ticket)
        //{
        //    try
        //    {
        //        TbPatchingTicketHistory row = db.TbPatchingTicketHistory.Single(h => h.CoreTicket == ticket);
        //        row.Updated = true;

        //        db.SaveChanges();
        //    }
        //    catch (InvalidOperationException nf)
        //    {
        //        throw new PatchingNotFoundException($"No Ticket History found for ticket {ticket}");
        //    }
        //}

        async Task<List<Claim>> Authenticate()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, cert, chain, sslPolicyErrors) => true;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient api = new HttpClient();
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            TbConfig dbConfig = db.TbConfig.Single(cfg => cfg.ConfigKey == "SMTP");

            JObject jo = JObject.Parse(dbConfig.ConfigJson);

            string data =$"{{\"auth\": {{\"RAX-AUTH:domain\": {{\"name\": \"Rackspace\"}},\"passwordCredentials\": {{\"username\": \"{jo["user"].ToString()}\",\"password\": \"{jo["password"].ToString()}\"}}}}}}";


            HttpContent hc = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = api.PostAsync(IDENTITY_API, hc).Result;

            if (resp.IsSuccessStatusCode)
            {
                string json = resp.Content.ReadAsStringAsync().Result;

                jo = JObject.Parse(json);

                List<Claim> claims = new List<Claim>()
                        {
                            new Claim("sso", jo["access"]["user"]["name"].ToString() ),
                            new Claim("token", jo["access"]["token"]["id"].ToString() ),
                            new Claim("expires", jo["access"]["token"]["expires"].ToString())
                        };
                return claims;
            }
            else
            {
                throw new UnauthorizedAccessException($"HTTP Error authenticating service account. HTTP Status Code: {(int)resp.StatusCode} {resp.StatusCode}");
            }
        }

        PatchingClient GetPatchingClient(int num)
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                   (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            //log.LogDebug($"[GetPatchingClient] devicenumber={num}");
            HttpClient api = new HttpClient();
            api.DefaultRequestHeaders.Accept.Clear();
            api.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            api.DefaultRequestHeaders.Add("X-Auth-Token", claims[1].Value);

            HttpResponseMessage resp = api.GetAsync($"{PATCHING_CLIENT_API}/clients/{num}").Result;

            //if (resp.IsSuccessStatusCode)
            //{
            //    string json = resp.Content.ReadAsStringAsync().Result;
            //    //log.LogDebug($"[GetPatchingClient] client json: {json}");
            //    PatchingClient pc = JsonConvert.DeserializeObject<PatchingClient>(json);

            //    return pc;
            //}
            //else
            //{
            //    throw new HttpRequestException($"HTTP Error authenticating service account. HTTP Status Code: {(int)resp.StatusCode} {resp.StatusCode}");
            //}
            switch(resp.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        string json = resp.Content.ReadAsStringAsync().Result;
                        PatchingClient pc = JsonConvert.DeserializeObject<PatchingClient>(json);
                        return pc;
                    }
                case HttpStatusCode.NotFound:
                    {
                        throw new Exception($"Patching Client not found for device {num}");
                    }
                default:
                    {
                        throw new Exception($"Unexpected error getting Patching Client for device {num}: {resp.StatusCode} {resp.Content.ReadAsStringAsync().Result}");
                    }
            }//switch
        }
        //AdvancedPatchingParameters GetAdvancedPatchingData(PatchingClient pc)
        //{
        //    if ( (pc.AdvancedPatching.ID == null) || (pc.AdvancedPatching.ID == Guid.Empty) )
        //    {
        //        throw new AricNotFoundException();
        //    }

        //    AdvancedPatchingParameters data = new AdvancedPatchingParameters();
        //    //log.LogDebug($"Getting Advanced Patching Timetable.....");

        //    timetable.Load(pc.AdvancedPatching.ID, claims[1].Value);
        //    data.Minute = timetable.Schedule.Minute;
        //    data.Hour = timetable.Schedule.Hour;
        //    data.DayOfWeek = timetable.Schedule.Day_of_week;
        //    data.DayOfMonth = timetable.Schedule.Day_of_month;
        //    data.MonthOfYear = timetable.Schedule.Month_of_year;

        //    data.Arguments = timetable.Args;
        //    AricJobPayload aricJob = JsonConvert.DeserializeObject<AricJobPayload>(timetable.Args[2]);
        //    data.ProcessName = aricJob.Name;

        //    return data;
        //}
    }
}



