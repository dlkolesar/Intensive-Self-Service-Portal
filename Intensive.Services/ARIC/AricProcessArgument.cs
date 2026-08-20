using System;
using System.Collections.Generic;
using System.Linq;

using Intensive.Data.SSDatabase;

using System.Net;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Intensive.Services.Aric
{
    class AricProcessArgument
    {
        public int ID { get; set; }
        public string ProcessName { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }

        protected ILogger log;
        protected SSDatabaseContext db;
        //protected AricSystemConfig config;

        public AricProcessArgument(ILogger<AricProcessArgument> logger,
                             SSDatabaseContext dbContext
                             //IOptions<PatchingSystemConfig> patchConfig
                             )
        //public PatchingClient(SSDatabaseContext dbContext)
        {
            log = logger;
            db = dbContext;
            //config = patchConfig.Value;
        }


        public List<AricProcessArgument> GetProcessesArguments(string processName)
        {
            List<TbAricProcessArgument> tbArguments = new List<TbAricProcessArgument>();
            List<AricProcessArgument> arguments = new List<AricProcessArgument>();

            tbArguments = db.TbAricProcessArgument.AsNoTracking()
                            .Where(p => p.ProcessName== processName)
                            .OrderBy(p => p.Name)
                            .ToList<TbAricProcessArgument>();

            //tbAricProcess and AricProcess have the same structure
            //use the JS serialize/de-serialize trick to copy one to the other
            arguments = JsonConvert.DeserializeObject<List<AricProcessArgument>>(JsonConvert.SerializeObject(tbArguments));

            return arguments;
        }
    }
}
