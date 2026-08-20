using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactTicketsWorked
    {
        public int TicketKey { get; set; }
        public int WorkDoneAtTimeKey { get; set; }
        public int WorkDoneAtHmsKey { get; set; }
        public int? WorkDoneAtCstTimeKey { get; set; }
        public int? WorkDoneAtCstHmsKey { get; set; }
        public int? WorkDoneAtUtcTimeKey { get; set; }
        public int? WorkDoneAtUtcHmsKey { get; set; }
        public int SourceDateUomKey { get; set; }
        public int TicketWorktypeKey { get; set; }
        public int WorkDoneByKey { get; set; }
        public int CurrentQueueKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int SourceSystemKey { get; set; }
        public int? Durationworked { get; set; }
        public int? Durationbilled { get; set; }
        public int? TicketWorkedRecordCreatedTimeKey { get; set; }
        public int? TicketWorkedRecordCreatedHmsKey { get; set; }
        public int? TicketWorkedRecordCreatedByKey { get; set; }
        public int? TicketWorkedRecordUpdatedTimeKey { get; set; }
        public int? TicketWorkedRecordUpdatedHmsKey { get; set; }
        public int? TicketWorkedRecordUpdatedByKey { get; set; }
    }
}
