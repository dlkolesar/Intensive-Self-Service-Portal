using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentAssignedTime
    {
        public int FactIncidentAssignedTimeId { get; set; }
        public int StartTimeKey { get; set; }
        public int StartTimeHmsKey { get; set; }
        public int CompletedTimeKey { get; set; }
        public int CompletedTimeHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int IncidentKey { get; set; }
        public int QueueKey { get; set; }
        public int AssignedToEmployeeKey { get; set; }
        public int AssignedByEmployeeKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public int AssignedTimeDuration { get; set; }
        public DateTime IncidentAssignedTimeRecordCreatedDatetime { get; set; }
        public string IncidentAssignedTimeRecordCreatedBy { get; set; }
        public DateTime IncidentAssignedTimeRecordUpdatedDatetime { get; set; }
        public string IncidentAssignedTimeRecordUpdatedBy { get; set; }
        public string IncidentAssignedTimeSourceSystemName { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
