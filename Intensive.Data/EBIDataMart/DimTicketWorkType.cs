using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTicketWorkType
    {
        public int TicketWorkTypeKey { get; set; }
        public string TicketWorkTypeNk { get; set; }
        public string TicketWorkTypeName { get; set; }
        public string TicketWorkTypeDescription { get; set; }
        public int? TicketWorkTypeActive { get; set; }
        public DateTime? TicketWorkTypeEffectiveStartDatetime { get; set; }
        public DateTime? TicketWorkTypeEffectiveEndDatetime { get; set; }
        public DateTime? TicketWorkTypeRecordCreatedAt { get; set; }
        public string TicketWorkTypeRecordCreatedBy { get; set; }
        public DateTime? TicketWorkTypeRecordUpdatedAt { get; set; }
        public string TicketWorkTypeRecordUpdatedBy { get; set; }
        public string TicketWorkTypeSourceSystemName { get; set; }
        public int? TicketWorkTypeCurrentRecord { get; set; }
    }
}
