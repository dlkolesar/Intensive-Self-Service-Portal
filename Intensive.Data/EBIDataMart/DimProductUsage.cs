using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimProductUsage
    {
        public int ProductUsageKey { get; set; }
        public string ProductUsageSsk { get; set; }
        public string ProductUsageType { get; set; }
        public string ProductUsageObjType { get; set; }
        public string AccountObjType { get; set; }
        public string ProductUsageName { get; set; }
        public string ProductUsageCode { get; set; }
        public string ProductUsageDescription { get; set; }
        public string ProductUsagePermitted { get; set; }
        public DateTime? RecCreatedDate { get; set; }
        public DateTime? RecUpdatedDate { get; set; }
        public DateTime? RecEndDate { get; set; }
        public string ItemType { get; set; }
        public string ItemGlSegment { get; set; }
        public DateTime? ProductUsageCreationDate { get; set; }
        public DateTime? ProductUsageUpdatedDate { get; set; }
        public string ProductUsageCreationBy { get; set; }
        public string ProductUsageUpdatedBy { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public string SourceSystemName { get; set; }
        public int? CurrentRecord { get; set; }
        public string ProductUsageNk { get; set; }
        public string ProductUsageNameByTag { get; set; }
        public string RateTag { get; set; }
    }
}
