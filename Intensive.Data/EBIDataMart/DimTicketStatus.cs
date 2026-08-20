using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTicketStatus
    {
        public int TicketStatusKey { get; set; }
        public string TicketStatusNk { get; set; }
        public string TicketStatusQueueName { get; set; }
        public string TicketStatusName { get; set; }
        public string TicketStatusDescription { get; set; }
        public int? TicketStatusActiveFlag { get; set; }
        public DateTime? TicketStatusEffectiveStartDatetime { get; set; }
        public DateTime? TicketStatusEffectiveEndDatetime { get; set; }
        public DateTime? TicketStatusRecordCreatedDatetime { get; set; }
        public string TicketStatusRecordCreatedBy { get; set; }
        public DateTime? TicketStatusRecordUpdatedDatetime { get; set; }
        public string TicketStatusRecordUpdatedBy { get; set; }
        public string TicketStatusSourceSystemName { get; set; }
        public int? TicketStatusCurrentRecordFlag { get; set; }
        public string TicketStatusQueueId { get; set; }
    }
}
