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

namespace Intensive.Services.Aric
{
    public class AricProcess
    {
       // const string ARIC_EVENTS_URL = "https://automation.api.rackspacecloud.com/internal/events/";

        public string ProcessName { get; set; }
        public int SystemId { get; set; }
        public string DisplayName { get; set; }
        public string Source { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
        public bool InternalOnly { get; set; }  //true if process is to be used internally and not presented to a UI


        protected ILogger log;
        protected SSDatabaseContext db;
        protected AricJob job;

        public AricProcess(ILogger<AricProcess> logger,
                             SSDatabaseContext dbContext,
                             AricJob aricjob
                             //IOptions<PatchingSystemConfig> patchConfig
                             )
        //public PatchingClient(SSDatabaseContext dbContext)
        {
            log = logger;
            db = dbContext;
            job = aricjob;
        }

        public void Load(string processName)
        {
            TbAricProcess tbProcess = new TbAricProcess();

            tbProcess = db.TbAricProcess.AsNoTracking().Single(
                            p => p.ProcessName.ToLower() == processName.ToLower()
                        );

            this.ProcessName = tbProcess.ProcessName;
            this.SystemId = tbProcess.SystemId;
            this.DisplayName = tbProcess.DisplayName;
            this.Source = tbProcess.Source;
            this.Classification = tbProcess.Classification;
            this.Description = tbProcess.Description;
            this.InternalOnly = tbProcess.InternalOnly;
        }

        public List<AricProcess> Find()
        {
            List<TbAricProcess> tbProcesses = new List<TbAricProcess>();
            List<AricProcess> processes = new List<AricProcess>();

            tbProcesses = db.TbAricProcess.AsNoTracking()
                            .Where(p => p.InternalOnly == false)
                            .OrderBy(p => p.DisplayName)
                            .ToList<TbAricProcess>();


            //tbAricProcess and AricProcess have the same structure
            //use the JS serialize/de-serialize trick to copy one to the other
            processes = JsonConvert.DeserializeObject<List<AricProcess>>(JsonConvert.SerializeObject(tbProcesses));

            return processes;
        }

        public List<AricProcess> Find(int systemid)
        {
            List<TbAricProcess> tbProcesses = new List<TbAricProcess>();
            List<AricProcess> processes = new List<AricProcess>();

            tbProcesses = db.TbAricProcess.AsNoTracking()
                            .Where(p => p.SystemId == systemid && p.InternalOnly == false)
                            .OrderBy(p => p.DisplayName)
                            .ToList<TbAricProcess>();


            //tbAricProcess and AricProcess have the same structure
            //use the JS serialize/de-serialize trick to copy one to the other
            processes = JsonConvert.DeserializeObject<List<AricProcess>>(JsonConvert.SerializeObject(tbProcesses));

            return processes;
        }

        public List<AricProcess> Find(string name)
        {
            List<TbAricProcess> tbProcesses = new List<TbAricProcess>();
            List<AricProcess> processes = new List<AricProcess>();

            tbProcesses = db.TbAricProcess.AsNoTracking()
                            .Where(p => 
                                    (
                                        p.ProcessName.ToLower().Contains(name.ToLower()) ||
                                        p.DisplayName.ToLower().Contains(name.ToLower())
                                    ) 
                                    &&  p.InternalOnly == false)
                            .OrderBy(p => p.DisplayName)
                            .ToList<TbAricProcess>();


            //tbAricProcess and AricProcess have the same structure
            //use the JS serialize/de-serialize trick to copy one to the other
            processes = JsonConvert.DeserializeObject<List<AricProcess>>(JsonConvert.SerializeObject(tbProcesses));

            return processes;
        }
        public List<AricProcess> Find(int systemid, string name)
        {
            List<TbAricProcess> tbProcesses = new List<TbAricProcess>();
            List<AricProcess> processes = new List<AricProcess>();

            tbProcesses = db.TbAricProcess.AsNoTracking()
                            .Where(p => p.SystemId == systemid 
                                     && (
                                            p.ProcessName.ToLower().Contains(name.ToLower()) ||
                                            p.DisplayName.ToLower().Contains(name.ToLower())
                                        )
                                     && p.InternalOnly == false)
                            .OrderBy(p => p.DisplayName)
                            .ToList<TbAricProcess>();


            //tbAricProcess and AricProcess have the same structure
            //use the JS serialize/de-serialize trick to copy one to the other
            processes = JsonConvert.DeserializeObject<List<AricProcess>>(JsonConvert.SerializeObject(tbProcesses));

            return processes;
        }

    }
}
