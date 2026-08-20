using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCreditMemoLogType
    {
        public int CreditMemoLogTypeKey { get; set; }
        public string CreditMemoLogType { get; set; }
        public string CreditMemoLogTypeDescription { get; set; }
        public DateTime CreditMemoLogTypeEffectiveStartDate { get; set; }
        public DateTime CreditMemoLogTypeEffectiveEndDate { get; set; }
        public DateTime CreditMemoLogTypeRecordCreatedDatetime { get; set; }
        public string CreditMemoLogTypeRecordCreatedBy { get; set; }
        public DateTime CreditMemoLogTypeRecordUpdatedDatetime { get; set; }
        public string CreditMemoLogTypeRecordUpdatedBy { get; set; }
        public string CreditMemoLogTypeSourceSystemName { get; set; }
        public byte CreditMemoLogTypeCurrentRecordFlag { get; set; }
        public int CreditMemoLogTypeNk { get; set; }
    }
}
