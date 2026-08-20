using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentQueuetime
    {
        public int StartQueueTimeKey { get; set; }
        public int StartQueueTimeHmsKey { get; set; }
        public int EndQueueTimeKey { get; set; }
        public int EndQueueTimeHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int IncidentKey { get; set; }
        public int QueueKey { get; set; }
        public int IncidentCategoryKey { get; set; }
        public int IncidentSubcategoryKey { get; set; }
        public int IncidentStatusKey { get; set; }
        public int EmployeeChangedByKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public int TcktLogTicketStateId { get; set; }
        public long QueueTimeDuration { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordUpdatedByKey { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
