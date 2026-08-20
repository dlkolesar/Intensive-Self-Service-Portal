using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactCreditMemoLog
    {
        public int CreditMemoLogKey { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int CreditMemoAttributeKey { get; set; }
        public int SubmittedDateKey { get; set; }
        public int ClosedDateKey { get; set; }
        public int StatusKey { get; set; }
        public int CreditMemoLogTypeKey { get; set; }
        public int CreditMemoId { get; set; }
        public int CreditMemoLogId { get; set; }
        public int CreditMemoTicketCauseId { get; set; }
        public string CreditMemoInvoiceCauseId { get; set; }
        public int CreditMemoTicketId { get; set; }
        public decimal CreditMemoAmount { get; set; }
        public DateTime CreditMemoRecordCreatedDatetime { get; set; }
        public string CreditMemoRecordCreatedBy { get; set; }
        public DateTime CreditMemoRecordUpdatedDatetime { get; set; }
        public string CreditMemoRecordUpdatedBy { get; set; }
        public byte CreditMemoRecordValidFlag { get; set; }
        public int? CreditEventDateKey { get; set; }
        public int? CreditEventHmsKey { get; set; }
        public int? CreditDeviceKey { get; set; }
        public int? LogUserKey { get; set; }
        public int? ProductKey { get; set; }
        public int? DepartmentKey { get; set; }
        public string Prevention { get; set; }
        public string SlaSectionNumber { get; set; }
        public string CreditMemoIncidentId { get; set; }
    }
}
