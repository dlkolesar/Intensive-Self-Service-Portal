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
    public class AricTimeTableSchedule
    {
        public string Schedule_type { get; set; }
        public string Minute { get; set; }
        public string Hour { get; set; }
        public string Day_of_week { get; set; }
        public string Day_of_month { get; set; }
        public string Month_of_year { get; set; }

        public AricTimeTableSchedule()
        {
            this.Schedule_type = "crontab";
            this.Minute = "*";
            this.Hour = "*";
            this.Day_of_week = "*";
            this.Month_of_year = "*";
            this.Day_of_month = "*";
        }


        public AricTimeTableSchedule(string crontab)
        {
            this.Schedule_type = "crontab";

            string[] cron = crontab.Split(new char[] { ' ' });  //split on the spaces
            this.Minute =        cron[0];
            this.Hour =          cron[1];
            this.Day_of_month =  cron[2];
            this.Month_of_year = cron[3];
            this.Day_of_week =   cron[4];

        }
    }

    // ARIC Timetable API docs: https://one.rackspace.com/display/RBA/Timetable+API?searchId=E1CRDQFPY

    public class AricTimeTable
    {
       // const string ARIC_TIMETABLE_URL = "https://timetable.api.rba.rackspace.com/v1.0/schedules";
        const string SYSTEM_TOKEN = "$[ApplicationConfig.globalauth.2.0.us.session]";
        public Guid Schedule_id { get; set; }
        public string Name { get; set; }
        public string Task { get; set; }
        public AricTimeTableSchedule Schedule { get; set; }
        public List<string> Args { get; set; }
            //[0] = token
            //[1] = tenant/account number
            //[2] = json arguments to be passed to the ARIC Events API (from PatchingClient.AdvancePatching.Arguments)
        public List<string> Tags { get; set; }
        public bool Run_once { get; set; }
        public bool Call_back { get; set; }
        public bool Enabled { get; set; }
        public DateTime? NextRun { get; set; }
        public DateTime? LastRun { get; set; }

        protected ILogger<AricTimeTable> log;
        protected SSDatabaseContext db;

        private AricRestClient client = new AricRestClient();
        AricSystemConfig config;

        public AricTimeTable(ILogger<AricTimeTable> logger,
                                SSDatabaseContext dbContext,
                                 IOptions<AricSystemConfig> cfg
                            )

        {
            log = logger;
            db = dbContext;
            config = cfg.Value;

            this.Schedule = new AricTimeTableSchedule();
            this.Args = new List<string>();
            this.Args.Add(SYSTEM_TOKEN);

            this.Tags = new List<string>();
            this.Task = "rba_event";
            this.Run_once = false;
            this.Call_back = false;
            this.Enabled = true;
            this.NextRun = null;
            this.LastRun = null;
        }
         public void Load(Guid id, string token)
        {
            try
            {
                client.URL = $"{config.TimetableAPI}/{ id.ToString()}";
                client.Token = token;
                client.Verb = "GET";

                //log.logDebug($"ARIC TimeTable URL: {client.URL}");
                //log.logDebug($"ARIC TimeTable token: {client.Token}");
                client.Submit();

                string json = client.ReadJsonResponse();

                log.LogDebug($"ARIC TimeTable API Response:  {client.StatusCode} {client.StatusDescription}");
                log.LogDebug($"ARIC TimeTable API Response:(json): {json}");
                if (client.StatusCode == HttpStatusCode.OK)
                {
                    JObject jo = JObject.Parse(json);

                    this.Schedule_id = new Guid(jo["data"][0]["schedule_id"].ToString());
                    this.Name = jo["data"][0]["name"].ToString();
                    this.Task = jo["data"][0]["task"].ToString();
                    this.Call_back = (bool)jo["data"][0]["call_back"];
                    this.Enabled = (bool)jo["data"][0]["enabled"];
                    string dt = jo["data"][0]["next_run_at"].ToString();
                    if (string.IsNullOrEmpty(dt))
                    {
                        this.NextRun = null;
                    }
                    else
                    {
                        this.NextRun = DateTime.Parse(dt);
                    }
                    
                    //dt = jo["data"][0]["last_run_at"].ToString();
                    //if (string.IsNullOrEmpty(dt))
                    //{
                    //    this.LastRun = null;
                    //}
                    //else
                    //{
                    //    this.LastRun = DateTime.Parse(dt);
                    //}

                    //log.logDebug($"ARIC TimeTable schedule...");
                    this.Schedule = new AricTimeTableSchedule();
                    this.Schedule.Minute = jo["data"][0]["schedule"]["minute"].ToString();
                    this.Schedule.Hour = jo["data"][0]["schedule"]["hour"].ToString();
                    this.Schedule.Day_of_week = jo["data"][0]["schedule"]["day_of_week"].ToString();
                    this.Schedule.Day_of_month = jo["data"][0]["schedule"]["day_of_month"].ToString();
                    this.Schedule.Month_of_year = jo["data"][0]["schedule"]["month_of_year"].ToString();


                    this.Args = new List<string>();
                    foreach (string arg in jo["data"][0]["args"])
                    {
                        //log.logDebug($"ARIC TimeTable args: {arg}");
                        this.Args.Add(arg);
                    }

                    foreach (string tag in jo["data"][0]["tags"])
                    {
                        //log.logDebug($"ARIC TimeTable tags: {tag}");
                        this.Tags.Add(tag);
                    }
                    this.Run_once = (bool)jo["data"][0]["run_once"];
                }
                else
                {
                    //throw new AricNotFoundException();
                    if (client.StatusCode == HttpStatusCode.NotFound)
                    {
                        log.LogError($"ARIC Returned NotFound for job {id.ToString()}");
                        throw new AricNotFoundException();
                    }
                    else
                    {
                        Exception e = new Exception($"ARIC TimeTable API error");
                        e.Data.Add("HTTP Status Code", client.StatusCode);
                        e.Data.Add("HTTP Data:", json);
                        throw e;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Schedule ID", id.ToString());
                ex.Data.Add("token", token);
                ex.Data.Add("client", JsonConvert.SerializeObject(client));
                if (ex is AricException) { throw; }
                else
                {
                    throw new AricException($"Unexpected Error submitting process to ARIC: {ex.Message}", ex);
                }
            }

        }

        public void Load(string name, string token)
        {
            try
            {
                client.URL = $"{config.TimetableAPI}/name/{name}";
                client.Token = token;
                client.Verb = "GET";

                //log.logDebug($"ARIC TimeTable URL: {client.URL}");
                //log.logDebug($"ARIC TimeTable token: {client.Token}");
                client.Submit();

                string json = client.ReadJsonResponse();

                log.LogDebug($"ARIC TimeTable API Response:  {client.StatusCode} {client.StatusDescription}");
                log.LogDebug($"ARIC TimeTable API Response:(json): {json}");
                if (client.StatusCode == HttpStatusCode.OK)
                {
                    JObject jo = JObject.Parse(json);

                    this.Schedule_id = new Guid(jo["data"][0]["schedule_id"].ToString());
                    this.Name = jo["data"][0]["name"].ToString();
                    this.Task = jo["data"][0]["task"].ToString();
                    this.Call_back = (bool)jo["data"][0]["call_back"];
                    this.Enabled = (bool)jo["data"][0]["enabled"];
                    this.NextRun = DateTime.Parse(jo["data"][0]["next_run_at"].ToString());
                    this.LastRun = DateTime.Parse(jo["data"][0]["last_run_at"].ToString());

                    ////log.logDebug($"ARIC TimeTable schedule...");
                    this.Schedule = new AricTimeTableSchedule();
                    this.Schedule.Minute = jo["data"][0]["schedule"]["minute"].ToString();
                    this.Schedule.Hour = jo["data"][0]["schedule"]["hour"].ToString();
                    this.Schedule.Day_of_week = jo["data"][0]["schedule"]["day_of_week"].ToString();
                    this.Schedule.Day_of_month = jo["data"][0]["schedule"]["day_of_month"].ToString();
                    this.Schedule.Month_of_year = jo["data"][0]["schedule"]["month_of_year"].ToString();


                    this.Args = new List<string>();
                    foreach (string arg in jo["data"][0]["args"])
                    {
                        ////log.logDebug($"ARIC TimeTable args: {arg}");
                        this.Args.Add(arg);
                    }

                    foreach (string tag in jo["data"][0]["tags"])
                    {
                        ////log.logDebug($"ARIC TimeTable tags: {tag}");
                        this.Tags.Add(tag);
                    }
                    this.Run_once = (bool)jo["data"][0]["run_once"];
                }
                else
                {
                    if (client.StatusCode == HttpStatusCode.NotFound)
                    {
                        log.LogError($"TimeTable returned NotFound for {name}");
                        throw new AricNotFoundException();
                    }
                    else
                    {
                        Exception e = new Exception($"ARIC TimeTable API error");
                        e.Data.Add("HTTP Status Code", client.StatusCode);
                        e.Data.Add("HTTP Data:", json);
                        throw e;
                    }
                    
                }


            }
            catch (Exception ex)
            {
                ex.Data.Add("Schedule name", name);
                ex.Data.Add("token", token);
                ex.Data.Add("client", JsonConvert.SerializeObject(client));
                if (ex is AricException) { throw; }
                else
                {
                    throw new AricException($"Unexpected Error submitting process to ARIC: {ex.Message}", ex);
                }
            }
        }

        public Guid Save(string token)
        {
            if ((this.Schedule_id == null) || (this.Schedule_id == Guid.Empty))
            {
                //query by name to see if a schedule already exists
                CreateTimetable(token);
            }
            else
            {
                UpdateTimetable(token);
            }
            return this.Schedule_id;
        }

        private void  CreateTimetable(string token)
        {
            try
            {
                //initialize fields that may not be passed in 
                // but are required by the API
                this.Tags = new List<string>();
                this.Task = "rba_event";
                this.Run_once = false;
                this.Call_back = false;
                this.Enabled = true;

                client.URL = config.TimetableAPI;
                client.Token = token;
                client.Verb = "POST";
                client.PostData = JsonConvert.SerializeObject(this, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

                //log.logDebug($"ARIC TimeTable URL: {client.URL}");
                //log.logDebug($"ARIC TimeTable TOKEN: {client.Token}");
                //log.logDebug($"ARIC TimeTable POSTDATA: {client.PostData}");


                client.Submit();

                string json = client.ReadJsonResponse();
                ////log.logDebug($"ARIC Response(json): {json}");
                if (client.StatusCode == HttpStatusCode.Created)
                {
                    JObject jo = JObject.Parse(json);
                    this.Schedule_id = new Guid(jo["data"][0]["schedule_id"].ToString());
                }
                else
                {
                    log.LogDebug($"ARIC status code: {client.StatusCode} - {client.StatusDescription}");
                    log.LogDebug($"ARIC Error Data: {json}");
                    throw new AricException($"Failed to create ARIC TimeTable entry");
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("id", this.Schedule_id);
                if (ex is AricException) { throw; }
                else
                {
                    throw new AricException($"Unexpected Error creating ARIC Timetable: {ex.Message}", ex);
                }
            }
        }

        private void UpdateTimetable(string token)
        {
            try
            {
                client.URL = $"{config.TimetableAPI}/{this.Schedule_id.ToString()}";
                client.Token = token;
                client.Verb = "PUT";
                client.PostData = JsonConvert.SerializeObject(this, new JsonSerializerSettings
                                                    {
                                                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                    });
                log.LogDebug($"ARIC TimeTable URL: {client.URL}");
                log.LogDebug($"ARIC TimeTable TOKEN: {client.Token}");
                log.LogDebug($"ARIC TimeTable POSTDATA: {client.PostData}");

                client.Submit();

                string json = client.ReadJsonResponse();
                //log.logDebug($"ARIC Response(json): {json}");
                if (client.StatusCode == HttpStatusCode.OK)
                {
                    
                }
                else if (client.StatusCode == HttpStatusCode.NotFound)
                {
                    CreateTimetable(token);
                }
                else
                {
                    log.LogDebug($"ARIC status code: {client.StatusCode} - {client.StatusDescription}");
                    log.LogDebug($"ARIC Error Data: {json}");
                    throw new AricException($"Failed to update ARIC TimeTable entry: {client.StatusCode} - {client.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("id", this.Schedule_id);
                if (ex is AricException) { throw; }
                else
                {
                    throw new AricException($"Unexpected Error updating ARIC Timetable: {ex.Message}", ex);
                }
            }
        }

        private void Delete(string token)
        {
            try
            {
                client.URL = $"{config.TimetableAPI}/{this.Schedule_id.ToString()}";
                client.Token = token;
                client.Verb = "DELETE";
                //client.PostData = JsonConvert.SerializeObject(this, new JsonSerializerSettings
                //{
                //    ContractResolver = new CamelCasePropertyNamesContractResolver()
                //});
                //log.logDebug($"ARIC TimeTable URL: {client.URL}");
                //log.logDebug($"ARIC TimeTable TOKEN: {client.Token}");
                ////log.logDebug($"ARIC TimeTable POSTDATA: {client.PostData}");

                client.Submit();

                string json = client.ReadJsonResponse();
                //log.logDebug($"ARIC Response(json): {json}");
                if (client.StatusCode != HttpStatusCode.NoContent)
                {
                    //log.logDebug($"ARIC status code: {client.StatusCode} - {client.StatusDescription}");
                    //log.logDebug($"ARIC Error Data: {json}");
                    throw new AricException("Failed to Delete ARIC TimeTable entry");
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("id", this.Schedule_id);
                if (ex is AricException) { throw; }
                else
                {
                    throw new AricException($"Unexpected Error Deleteing ARIC Timetable: {ex.Message}", ex);
                }
            }
        }


    }

}

