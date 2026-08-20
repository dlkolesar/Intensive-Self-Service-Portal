using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactMonitoringDeviceConfig
    {
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int? ClosedTimeKey { get; set; }
        public int? ClosedHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int TeamKey { get; set; }
        public int ServicePollerKey { get; set; }
        public int DeviceStatusKey { get; set; }
        public int MonitorKey { get; set; }
        public int? MeasureCount { get; set; }
        public int? RecordCreated { get; set; }
        public int? RecordCreatedHms { get; set; }
        public int? RecordUpdated { get; set; }
        public int? RecordUpdatedHms { get; set; }
        public int MonitoredServiceIdNk { get; set; }
        public int? RecordUpdatedBy { get; set; }
        public int? RecordCreatedBy { get; set; }
        public int Id { get; set; }
        public int? SourceSystemKey { get; set; }
    }
}
