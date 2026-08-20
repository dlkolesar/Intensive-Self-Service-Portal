using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactMonitoringAvailabilityMetricsCurrent
    {
        public long Id { get; set; }
        public int StartTimeKey { get; set; }
        public int StartHmsKey { get; set; }
        public int EndTimeKey { get; set; }
        public int EndHmsKey { get; set; }
        public int MonitorKey { get; set; }
        public int DeviceKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int SourceSystemKey { get; set; }
        public int MeasureRecordCount { get; set; }
        public int MeasureUptimeSeconds { get; set; }
        public int MeasureDowntimeSeconds { get; set; }
        public decimal MeasureAvailabilityPercent { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int? MeasureEnabledSeconds { get; set; }
        public int? MeasureTotalDownTime { get; set; }
        public decimal? MeasureTotalAvailabilityPercent { get; set; }
    }
}
