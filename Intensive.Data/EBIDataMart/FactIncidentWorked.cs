using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentWorked
    {
        public int IncidentWorkedId { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int EmployeeKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int IncidentKey { get; set; }
        public int IncidentWorktypeKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public int Duration { get; set; }
        public int QueueKey { get; set; }
        public int StatusKey { get; set; }
        public DateTime IncidentWorkedRecordCreatedDatetime { get; set; }
        public string IncidentWorkedRecordCreatedBy { get; set; }
        public DateTime IncidentWorkedRecordUpdatedDatetime { get; set; }
        public string IncidentWorkedRecordUpdatedBy { get; set; }
        public string IncidentWorkedSourceSystemName { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
