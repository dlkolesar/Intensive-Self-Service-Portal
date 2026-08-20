using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTicketState
    {
        public int TicketStateKey { get; set; }
        public string TicketStateNk { get; set; }
        public string TicketSeverityValue { get; set; }
        public string TicketSeverityDesc { get; set; }
        public string TicketPriorityValue { get; set; }
        public string TicketPriorityDesc { get; set; }
        public int? TicketDifficultyValue { get; set; }
        public string TicketDifficultyDesc { get; set; }
        public DateTime? TicketStateEffectiveStartDatetime { get; set; }
        public DateTime? TicketStateEffectiveEndDatetime { get; set; }
        public DateTime? TicketStateRecordCreatedDatetime { get; set; }
        public string TicketStateRecordCreatedBy { get; set; }
        public DateTime? TicketStateRecordUpdatedDatetime { get; set; }
        public string TicketStateRecordUpdatedBy { get; set; }
        public string TicketStateSourceSystemName { get; set; }
        public int? TicketStateCurrentRecordFlag { get; set; }
    }
}
