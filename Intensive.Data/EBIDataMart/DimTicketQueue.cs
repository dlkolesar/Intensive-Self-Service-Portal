using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTicketQueue
    {
        public int TicketQueueKey { get; set; }
        public string TicketQueueNk { get; set; }
        public string TicketQueueName { get; set; }
        public string TicketQueueDescription { get; set; }
        public int? TicketQueuePrivateFlag { get; set; }
        public int? TicketQueueActiveFlag { get; set; }
        public DateTime? TicketQueueEffectiveStartDatetime { get; set; }
        public DateTime? TicketQueueEffectiveEndDatetime { get; set; }
        public DateTime? TicketQueueRecordCreatedDatetime { get; set; }
        public string TicketQueueRecordCreatedBy { get; set; }
        public DateTime? TicketQueueRecordUpdatedDatetime { get; set; }
        public string TicketQueueRecordUpdatedBy { get; set; }
        public string TicketQueueSourceSystemName { get; set; }
        public int? TicketQueueCurrentRecordFlag { get; set; }
    }
}
