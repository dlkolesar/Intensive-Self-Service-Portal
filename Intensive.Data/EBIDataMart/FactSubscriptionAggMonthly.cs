using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactSubscriptionAggMonthly
    {
        public long SubscriptionAggMonthlyKey { get; set; }
        public int? SubscriptionAggMonthlyAccountKey { get; set; }
        public int? SubscriptionAggMonthlyTimeKey { get; set; }
        public int? SubscriptionAggMonthlyDeviceKey { get; set; }
        public int? SubscriptionAggMonthlyUnitOfMeasureKey { get; set; }
        public int? SubscriptionAggMonthlySubscriptionTypeKey { get; set; }
        public int? SubscriptionAggMonthlyTeamKey { get; set; }
        public decimal? SubscriptionAggMonthlySubscription { get; set; }
        public string SubscriptionAggMonthlySsk { get; set; }
        public DateTime? SubscriptionAggMonthlyRecordAddedDateTime { get; set; }
        public DateTime? SubscriptionAggMonthlyRecordUpdatedDateTime { get; set; }
        public string SubscriptionAggMonthlyRecordAddedBy { get; set; }
        public string SubscriptionAggMonthlyRecordUpdatedBy { get; set; }
        public byte? SubscriptionAggMonthlyValidFlag { get; set; }
        public byte? SubscriptionAggMonthlyCancelled { get; set; }
    }
}
