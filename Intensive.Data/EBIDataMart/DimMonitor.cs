using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimMonitor
    {
        public int MonitorKey { get; set; }
        public string MonitorIdNk { get; set; }
        public string MonitorType { get; set; }
        public string MonitorName { get; set; }
        public string MonitorDescription { get; set; }
        public string MonitorFrequency { get; set; }
        public string MonitorErrorFrequency { get; set; }
        public string MonitorRetries { get; set; }
        public string MonitorProtocol { get; set; }
        public string MonitorPort { get; set; }
        public string MonitorHost { get; set; }
        public string MonitorSilo { get; set; }
        public string MonitorPoller { get; set; }
        public string MonitorStatus { get; set; }
        public string SourceSystemName { get; set; }
        public int? CurrentRecordFlag { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordUpdatedBy { get; set; }
        public DateTime? RecordCreatedDatetime { get; set; }
        public DateTime? RecordUpdatedDatetime { get; set; }
        public string MonitorGroup { get; set; }
        public string ImplementationType { get; set; }
        public string MonitorId { get; set; }
        public string MonitorDeployedStatus { get; set; }
    }
}
