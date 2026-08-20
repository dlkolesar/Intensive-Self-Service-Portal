using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimRevenueDeleteReason
    {
        public int RevenueDeleteReasonKey { get; set; }
        public string RevenueDeleteReasonIdNk { get; set; }
        public string RevenueDeleteReasonType { get; set; }
        public string RevenueDeleteReasonName { get; set; }
        public string RevenueDeleteReasonCategory { get; set; }
        public DateTime RevenueDeleteReasonEffectiveStartDatetime { get; set; }
        public DateTime RevenueDeleteReasonEffectiveEndDatetime { get; set; }
        public DateTime RevenueDeleteReasonRecordCreatedDatetime { get; set; }
        public string RevenueDeleteReasonRecordCreatedBy { get; set; }
        public DateTime RevenueDeleteReasonRecordUpdatedDatetime { get; set; }
        public string RevenueDeleteReasonRecordUpdatedBy { get; set; }
        public string RevenueDeleteReasonSourceSystemName { get; set; }
        public int RevenueDeleteReasonCurrentRecordFlag { get; set; }
    }
}
