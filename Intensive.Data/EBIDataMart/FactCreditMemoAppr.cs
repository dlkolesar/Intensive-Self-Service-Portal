using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactCreditMemoAppr
    {
        public int CreditMemoApprKey { get; set; }
        public int ApprovalDateKey { get; set; }
        public int ApprovalHmsKey { get; set; }
        public int CreditMemoNk { get; set; }
        public int ApprovedByKey { get; set; }
        public int Count { get; set; }
        public string SourceSystemName { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordCreatedDate { get; set; }
        public string RecordUpdatedBy { get; set; }
        public DateTime RecordUpdatedDate { get; set; }
    }
}
