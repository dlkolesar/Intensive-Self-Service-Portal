using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactMonitoringMonitorStatusChange
    {
        public string Id { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int? EndTimeKey { get; set; }
        public int? EndHmsKey { get; set; }
        public int MonitorKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int StatusKey { get; set; }
        public int SourceSystemKey { get; set; }
        public int MeasureRecordCount { get; set; }
        public int MeasureStatusDuration { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int? DeviceKey { get; set; }
    }
}
