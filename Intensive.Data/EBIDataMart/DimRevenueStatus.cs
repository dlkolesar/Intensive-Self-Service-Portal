using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimRevenueStatus
    {
        public int RevenueStatusKey { get; set; }
        public string RevenueStatusIdNk { get; set; }
        public string RevenueStatusType { get; set; }
        public string RevenueStatusName { get; set; }
        public string RevenueStatusDescription { get; set; }
        public DateTime RevenueStatusEffectiveStartDatetime { get; set; }
        public DateTime RevenueStatusEffectiveEndDatetime { get; set; }
        public DateTime RevenueStatusRecordCreatedDatetime { get; set; }
        public string RevenueStatusRecordCreatedBy { get; set; }
        public DateTime RevenueStatusRecordUpdatedDatetime { get; set; }
        public string RevenueStatusRecordUpdatedBy { get; set; }
        public string RevenueStatusSourceSystemName { get; set; }
        public int RevenueStatusCurrentRecordFlag { get; set; }
    }
}
