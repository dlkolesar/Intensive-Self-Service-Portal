using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentCreated
    {
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int AccountKey { get; set; }
        public int IncidentKey { get; set; }
        public int TcktTicketId { get; set; }
        public int TeamKey { get; set; }
        public int IncidentCreatedByKey { get; set; }
        public int IncidentSubmittedByKey { get; set; }
        public int IncidentCount { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int QueueKey { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
