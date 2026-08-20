using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactTicketsFirstresponse
    {
        public int TicketKey { get; set; }
        public int FirstResponseTimeKey { get; set; }
        public int FirstResponseHmsKey { get; set; }
        public int CstFirstResponseTimeKey { get; set; }
        public int CstFirstResponseHmsKey { get; set; }
        public int UtcFirstResponseTimeKey { get; set; }
        public int UtcFirstResponseHmsKey { get; set; }
        public int SourceSystemKey { get; set; }
        public int SourceDateUomKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int FirstResponseByKey { get; set; }
        public int TicketCreatedByKey { get; set; }
        public int TicketSubmittedByKey { get; set; }
        public int TicketCreatedTimeKey { get; set; }
        public int TicketCreatedHmsKey { get; set; }
        public int CstTicketCreatedTimeKey { get; set; }
        public int CstTicketCreatedHmsKey { get; set; }
        public int UtcTicketCreatedTimeKey { get; set; }
        public int UtcTicketCreatedHmsKey { get; set; }
        public int? FirstResponseDurationUk { get; set; }
        public int? FirstResponseDurationUs { get; set; }
        public int? RecordUpdatedByKey { get; set; }
        public int? RecordCreatedByKey { get; set; }
        public int? RecordCreatedByTimeKey { get; set; }
        public int? RecordCreatedByHmsKey { get; set; }
        public int? RecordUpdatedByTimeKey { get; set; }
        public int? RecordUpdatedByHmsKey { get; set; }
        public string FirstResponseCommentKey { get; set; }
    }
}
