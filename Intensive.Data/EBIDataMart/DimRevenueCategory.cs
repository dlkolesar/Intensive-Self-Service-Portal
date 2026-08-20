using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimRevenueCategory
    {
        public int RevenueCategoryKey { get; set; }
        public string RevenueCategoryIdNk { get; set; }
        public string RevenueCategoryType { get; set; }
        public string RevenueCategoryName { get; set; }
        public string RevenueCategoryDescription { get; set; }
        public DateTime RevenueCategoryEffectiveStartDatetime { get; set; }
        public DateTime RevenueCategoryEffectiveEndDatetime { get; set; }
        public DateTime RevenueCategoryRecordCreatedDatetime { get; set; }
        public string RevenueCategoryRecordCreatedBy { get; set; }
        public DateTime RevenueCategoryRecordUpdatedDatetime { get; set; }
        public string RevenueCategoryRecordUpdatedBy { get; set; }
        public string RevenueCategorySourceSystemName { get; set; }
        public int RevenueCategoryCurrentRecordFlag { get; set; }
    }
}
