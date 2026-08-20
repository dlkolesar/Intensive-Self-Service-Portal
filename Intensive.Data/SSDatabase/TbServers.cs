using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbServers
    {
        public int DeviceNumber { get; set; }
        public Guid? Wsusid { get; set; }
        public string NimBusrobotId { get; set; }
        public Guid? ScomagentId { get; set; }
        public int? AntiVirusId { get; set; }
        public string Name { get; set; }
        public int Account { get; set; }
        public string DataCenter { get; set; }
        public string Os { get; set; }
        public string Tags { get; set; }
        public bool IsCluster { get; set; }
        public bool IsClusterNode { get; set; }
        public DateTime LastRefresh { get; set; }
    }
}
