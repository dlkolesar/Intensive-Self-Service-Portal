using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportSoxManagedVirtDetail
    {
        public int Id { get; set; }
        public DateTime RecTimestamp { get; set; }
        public string AccountId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceHostName { get; set; }
        public string Datacenter { get; set; }
        public string ReconciliationType { get; set; }
        public string RecDeviceType { get; set; }
        public string RecSourceSystem { get; set; }
        public string RecTargetSystem { get; set; }
        public string RecSrcDeviceStatus { get; set; }
        public string MissingIn { get; set; }
        public string ReplicationFlag { get; set; }
    }
}
