using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimRevenueCostType
    {
        public int RevenueCostTypeKey { get; set; }
        public string RevenueCostTypeNk { get; set; }
        public string RevenueCostTypeName { get; set; }
        public string RevenueCostTypeDescription { get; set; }
        public string RevenueCostTypeGroupName { get; set; }
        public DateTime RevenueCostTypeEffectiveStartDateTime { get; set; }
        public DateTime RevenueCostTypeEffectiveEndDateTime { get; set; }
        public DateTime RevenueCostTypeRecordCreatedDateTime { get; set; }
        public DateTime RevenueCostTypeRecordUpdatedDateTime { get; set; }
        public string RevenueCostTypeRecordCreatedBy { get; set; }
        public string RevenueCostTypeRecordUpdatedBy { get; set; }
        public int RevenueCostTypeCurrentRecordFlag { get; set; }
    }
}
