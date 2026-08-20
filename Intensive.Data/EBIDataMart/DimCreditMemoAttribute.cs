using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCreditMemoAttribute
    {
        public int CreditMemoAttributeKey { get; set; }
        public string CreditMemoAttributeServiceFailureText { get; set; }
        public string CreditMemoAttributeServiceFailureGroupText { get; set; }
        public byte CreditMemoAttributeEarnedRevenueFlag { get; set; }
        public string CreditMemoAttributeCurrencyType { get; set; }
        public DateTime CreditMemoAttributeEffectiveStartDate { get; set; }
        public DateTime CreditMemoAttributeEffectiveEndDate { get; set; }
        public DateTime CreditMemoAttributeRecordCreatedDatetime { get; set; }
        public string CreditMemoAttributeRecordCreatedBy { get; set; }
        public DateTime CreditMemoAttributeRecordUpdatedDatetime { get; set; }
        public string CreditMemoAttributeRecordUpdatedBy { get; set; }
        public string CreditMemoAttributeSourceSystemName { get; set; }
        public byte CreditMemoAttributeCurrentRecordFlag { get; set; }
        public string CreditMemoAttributeNk { get; set; }
    }
}
