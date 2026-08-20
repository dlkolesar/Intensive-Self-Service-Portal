using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentMessage
    {
        public int IncidentMessageId { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int EmployeeKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int IncidentKey { get; set; }
        public int QueueKey { get; set; }
        public int IncidentMessageTypeKey { get; set; }
        public int Count { get; set; }
        public DateTime IncidentMessageRecordCreatedDatetime { get; set; }
        public string IncidentMessageRecordCreatedBy { get; set; }
        public DateTime IncidentMessageRecordUpdatedDatetime { get; set; }
        public string IncidentMessageRecordUpdatedBy { get; set; }
        public string IncidentMessageSourceSystemName { get; set; }
        public int IncidentMessageCreatedSourceKey { get; set; }
        public int SourceContactKey { get; set; }
        public int PrivatizeContactKey { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
