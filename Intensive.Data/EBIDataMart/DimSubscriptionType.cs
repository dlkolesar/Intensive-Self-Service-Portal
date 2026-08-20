using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSubscriptionType
    {
        public int SubscriptionTypeKey { get; set; }
        public int? SubscriptionTypeNk { get; set; }
        public string SubscriptionTypeName { get; set; }
        public string SubscriptionTypeDescription { get; set; }
        public decimal? SubscriptionTypeMonthlyMultiplier { get; set; }
        public string SubscriptionTypeFrequency { get; set; }
        public DateTime? SubscriptionTypeEffectiveStartDateTime { get; set; }
        public DateTime? SubscriptionTypeEffectiveEndDateTime { get; set; }
        public DateTime? SubscriptionTypeRecordCreatedDateTime { get; set; }
        public DateTime? SubscriptionTypeRecordUpdatedDateTime { get; set; }
        public string SubscriptionTypeRecordCreatedBy { get; set; }
        public string SubscriptionTypeRecordUpdatedBy { get; set; }
        public byte? SubscriptionTypeCurrentRecordFlag { get; set; }
        public string SubscriptionTypeGroup { get; set; }
        public string SubscriptionTypeLevel { get; set; }
    }
}
