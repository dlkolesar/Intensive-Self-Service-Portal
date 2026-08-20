using System;
using System.Collections.Generic;
using System.Linq;

using Intensive.Data.SSDatabase;

using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LinqKit;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Intensive.Services.Aric
{
    public class AricJob
    {
        //const string ARIC_EVENTS_URL = "https://automation.api.rackspacecloud.com/internal/events/";

        public int SystemId { get; set; }
        public Guid EventId { get; set; }
        public string ProcessName { get; set; }
        public int AccountNumber { get; set; }
        public int DeviceNumber { get; set; }
        public string State { get; set; }
        public string Message { get; set; }
        public string ReturnedData { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Completed { get; set; }
        public string UserId { get; set; }

        ILogger<AricJob> log;
        SSDatabaseContext db;
        AricDataHandlerPatching PatchingDataHandler;
        AricSystemConfig config;


        public AricJob() { }

        public AricJob( ILogger<AricJob> logger,
                        SSDatabaseContext dbContext,
                        AricDataHandlerPatching pdh,
                        IOptions<AricSystemConfig> cfg
                        )

        {
            log = logger;
            db = dbContext;
            PatchingDataHandler = pdh;
            config = cfg.Value;
        }

       

        public void Load(Guid eventid)
        {
            TbAricJob status;
            try
            {
                status = db.TbAricJob.Single(p => p.EventId == eventid);
                this.EventId = status.EventId;
                this.AccountNumber = status.AccountNumber;
                this.DeviceNumber = status.DeviceNumber;
                this.ProcessName = status.ProcessName;
                this.State = status.State;
                this.Message = status.Message;
                this.ReturnedData = status.ReturnedData;
                this.Submitted = status.Submitted;
                this.Started = status.Started;
                this.Completed = status.Completed;
                this.SystemId = status.SystemId;
                this.UserId = status.UserId;
            }
            catch(InvalidOperationException ioe)
            {
                log.LogError($"AricNotFoundException: {ioe.ToString()}");
                throw new AricNotFoundException();
            }
            catch (Exception ex)
            {
                log.LogError($"Unknown Exception: {ex.ToString()}");
                throw;
            }
        }

        //public void Load(int systemid, int devicenumber)
        //{
        //    TbAricJob status;
        //    try
        //    {
        //        status = db.TbAricJob.FirstOrDefault(p => p.SystemId == systemid && p.DeviceNumber == devicenumber);

        //        if (status == null) //no active jobs for system/device
        //        {
        //            throw new AricNotFoundException();
        //        }

        //        this.EventId = status.EventId;
        //        this.AccountNumber = status.AccountNumber;
        //        this.DeviceNumber = status.DeviceNumber;
        //        this.ProcessName = status.ProcessName;
        //        this.State = status.State;
        //        this.Message = status.Message;
        //        this.ReturnedData = status.ReturnedData;
        //        this.Submitted = status.Submitted;
        //        this.Started = status.Started;
        //        this.Completed = status.Completed;
        //        this.SystemId = status.SystemId;
        //        this.UserId = status.UserId;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public List<AricJob> Find(int systemid, int accountNumber, int deviceNumber)
        {
            List<AricJob> jobs = new List<AricJob>();
            AricJob job;

            //third-party depenedency - LinqKit
            // http://www.albahari.com/nutshell/predicatebuilder.aspx
            // https://www.codeproject.com/Articles/28580/LINQ-and-Dynamic-Predicate-Construction-at-Runtime
            var predicate = PredicateBuilder.New<TbAricJob>();

            predicate.And(a => a.SystemId == systemid);

            if (accountNumber > 0)
            {
                predicate.And(a => a.AccountNumber == accountNumber);
            }

            if (deviceNumber > 0)
            {
                predicate.And(a => a.DeviceNumber == deviceNumber);
            }

            try
            {
                List<TbAricJob> tbjobs = db.TbAricJob
                                            .AsNoTracking()
                                            .AsExpandable()
                                            .Where(predicate)  
                                            .ToList<TbAricJob>();

                foreach (TbAricJob j in tbjobs)
                {
                    job = new AricJob();
                    job.EventId = j.EventId;
                    job.AccountNumber = j.AccountNumber;
                    job.DeviceNumber = j.DeviceNumber;
                    job.ProcessName = j.ProcessName;
                    job.State = j.State;
                    job.Message = j.Message;
                    job.ReturnedData = j.ReturnedData;
                    job.Submitted = j.Submitted;
                    job.Started = j.Started;
                    job.Completed = j.Completed;
                    job.SystemId = j.SystemId;
                    job.UserId = j.UserId;
                    jobs.Add(job);
                }
                return jobs;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Save()
        {
            TbAricJob status;
            try
            {
                //get current status
                status = db.TbAricJob.Single(p => p.EventId == this.EventId);

                //if it exists, update the existing row
                status.State = this.State;
                status.Message = this.Message;

                switch (this.State.ToLower())
                {
                    case "failed":
                        {
                            status.Completed = DateTime.UtcNow;
                            status.ReturnedData = this.ReturnedData;
                            status.Message = this.Message;
                            //db.SaveChanges();
                            break;
                        }
                    case "success":
                        {
                            status.Completed = DateTime.UtcNow;
                            status.ReturnedData = this.ReturnedData;
                            status.Message = this.Message;

                            //if (string.IsNullOrEmpty(this.ReturnedData))
                            //{
                            //    db.TbAricJob.Remove(status);
                            //}

                            //db.SaveChanges();


                            //if (!string.IsNullOrEmpty(this.ReturnedData) )
                            //{
                            //    ProcessReturnedData();  
                            //}
                            break;
                        }

                    case "running":
                        {
                            if (status.Started == null)
                            {
                                status.Started = DateTime.UtcNow; break;
                            }
                            break;
                        }
                }//switch

                db.SaveChanges();

            }
            catch (InvalidOperationException nf) //event id not found
            {
                //add new eventID status
                this.Submitted = DateTime.UtcNow;
                this.Completed = null;
                this.Started = null;
                //this.State = "pending";

                status = JsonConvert.DeserializeObject<TbAricJob>(JsonConvert.SerializeObject(this));

                db.TbAricJob.Add(status);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        public void Delete()
        {
            TbAricJob status = db.TbAricJob.Single(p => p.EventId == this.EventId);

            db.TbAricJob.Remove(status);
            db.SaveChanges();
        }

        public void Create(string sso, string token, int systemid, AricJobPayload postData)
        {
            AricRestClient client = new AricRestClient();
            Guid jobid = Guid.Empty;

            try
            {
                //client.URL = ARIC_EVENTS_URL;
                client.URL = config.EventsAPI;
                client.Token = token;
                client.Verb = "POST";
                //client.PostData = postData;
                client.PostData = JsonConvert.SerializeObject(postData, new JsonSerializerSettings
                                                                        {
                                                                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                                        });

                log.LogDebug($"Creating ARIC job...");
                log.LogDebug($"{client.PostData}");
                client.Submit();

                string json = client.ReadJsonResponse();
                ////log.logDebug($"ARIC Response(json): {json}");
                if (client.StatusCode == HttpStatusCode.Accepted)
                {
                    JObject jo = JObject.Parse(json);
                    this.EventId = new Guid(jo["ID"].ToString());
                }
                else
                {
                    log.LogDebug($"ARIC status code: {client.StatusCode} - {client.StatusDescription}");
                    log.LogDebug($"{json}");
                    this.EventId = Guid.Empty;

                    //failed to submit job to ARIC   
                    //throw error to caller?
                    throw new AricException($"Failed to submit process to ARIC: {client.StatusCode} - {client.StatusDescription}");
                }
                string[] parts = postData.Targets.First().href.Split(new char[] { '/' });
                this.AccountNumber = postData.Tenant;
                this.DeviceNumber = Convert.ToInt32(parts[parts.Length - 1]);
                this.ProcessName = postData.Name;
                this.SystemId = systemid;
                this.UserId = sso;
                this.State = "pending";
            }
            catch (Exception ex)
            {
                if (ex is AricException) { throw; }
                else
                {
                    throw new AricException($"Unexpected Error submitting process to ARIC: {ex.Message}", ex);
                }
            }

            //delete any old jobs for this systemid/device combo
            try
            {
                IEnumerable<TbAricJob> jobs = db.TbAricJob.Where(j => j.DeviceNumber == this.DeviceNumber && 
                                                                        j.SystemId == this.SystemId &&
                                                                        j.State.ToLower() == "failed");

                db.TbAricJob.RemoveRange(jobs);
                    
            }
            catch (Exception ex)
            {
                throw new AricException($"Unexpected Error saving ARIC job to the database:{ex.Message}", ex);
            }

            //save the new job to the DB so, the state can be updated by the job as it runs
            try
            {
                this.Save();
            }
            catch (Exception ex)
            {
                throw new AricException($"Unexpected Error saving ARIC job to the database:{ex.Message}", ex);
            }

        }

        public Task CreateAsync(string sso, string token, int systemid, AricJobPayload postData)
        {
            this.Create(sso, token, systemid, postData);
            return Task.CompletedTask;
        }

        //private async void ProcessReturnedData()  //async?
        //{
        //    log.LogDebug($"processing Returned Data....");
        //    switch (this.SystemId)
        //    {
        //        case 14: { await PatchingDataHandler.ProcessDataAsync(this); break; }
        //    }
        //}
    }
}
