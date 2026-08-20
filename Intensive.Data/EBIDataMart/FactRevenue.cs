using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactRevenue
    {
        public int TeamKey { get; set; }
        public int RevenueTypeKey { get; set; }
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int ProductKey { get; set; }
        public int ChurnReasonDetailKey { get; set; }
        public int TimeMonthKey { get; set; }
        public int TimePostedKey { get; set; }
        public string DeviceSsk { get; set; }
        public int LatestEntry { get; set; }
        public string TransactionType { get; set; }
        public string RevenueSsk { get; set; }
        public decimal MeasureDollarAmount { get; set; }
        public long MeasureRecordCount { get; set; }
        public DateTime? RevenueRecordCreatedDatetime { get; set; }
        public string RevenueRecordCreatedBy { get; set; }
        public DateTime? RevenueRecordUpdatedDatetime { get; set; }
        public string RevenueRecordUpdatedBy { get; set; }
        public string RevenueSourceSystemName { get; set; }
        public decimal? LocalCurrencyAmount { get; set; }
        public string LocalCurrencyTypeUom { get; set; }
        public int? TimeDueOfflineDateKey { get; set; }
        public int? SubmittedDateKey { get; set; }
        public int? RevenueSetOfBooksKey { get; set; }
        public int RevenueTypeDeviceLevelKey { get; set; }
        public int RevenueTypeOpportunityLevelKey { get; set; }
        public int RevenueTypeAccountLevelKey { get; set; }
        public int OpportunityKey { get; set; }
        public int IncidentKey { get; set; }
        public int ChurnProbabilityKey { get; set; }
        public byte ChurnWouldConsiderFlag { get; set; }
        public int ChurnBridgeKey { get; set; }
    }
}
