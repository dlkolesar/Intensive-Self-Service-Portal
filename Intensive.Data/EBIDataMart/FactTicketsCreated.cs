using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactTicketsCreated
    {
        public int CreatedTimeKey { get; set; }
        public int CreatedTimeHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int InitialTeamKey { get; set; }
        public int TicketCreatedByKey { get; set; }
        public int TicketSubmittedByKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int InitialQueueKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int TicketKey { get; set; }
        public int? RecordCreatedByTimeKey { get; set; }
        public int? RecordCreatedByHmsKey { get; set; }
        public int? RecordUpdatedByTimeKey { get; set; }
        public int? RecordUpdatedByHmsKey { get; set; }
        public int CreatedTimeSourceTimezoneUomKey { get; set; }
        public int CreatedTimeKeyCst { get; set; }
        public int CreatedTimeHmsKeyCst { get; set; }
        public int CreatedTimeKeyUtc { get; set; }
        public int CreatedTimeHmsKeyUtc { get; set; }
        public int SourceSystemKey { get; set; }
        public int TicketCount { get; set; }
    }
}
