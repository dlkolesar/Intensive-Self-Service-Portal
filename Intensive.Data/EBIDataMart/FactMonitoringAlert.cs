using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactMonitoringAlert
    {
        public int FactMonitoringAlertKey { get; set; }
        public int TimeOpenKey { get; set; }
        public int TimeOpenHmsKey { get; set; }
        public int TimeAcknowledgedKey { get; set; }
        public int TimeAcknowledgedHmsKey { get; set; }
        public int TimeSolvedKey { get; set; }
        public int TimeSolvedHmsKey { get; set; }
        public int TimeClosedKey { get; set; }
        public int TimeClosedHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int TeamKey { get; set; }
        public int QueueKey { get; set; }
        public int AlertTypeKey { get; set; }
        public int AlertStatusKey { get; set; }
        public int IncidentKey { get; set; }
        public int ServicePollerKey { get; set; }
        public int ThresholdKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public string MonitoringAlertReferenceNumber { get; set; }
        public DateTime MonitoringAlertRecordCreatedDatetime { get; set; }
        public string MonitoringAlertRecordCreatedBy { get; set; }
        public DateTime MonitoringAlertRecordUpdatedDatetime { get; set; }
        public string MonitoringAlertUpdatedBy { get; set; }
        public int MonitoringAlertResponseTime { get; set; }
        public int MonitoringAlertResolutionTime { get; set; }
        public int EmployeeKey { get; set; }
        public int? MonitorKey { get; set; }
        public int SourceSystemKey { get; set; }
        public int? SeverityKey { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
