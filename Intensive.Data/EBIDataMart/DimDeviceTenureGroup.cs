using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDeviceTenureGroup
    {
        public int DeviceTenureGroupKey { get; set; }
        public string DeviceTenureGroupNk { get; set; }
        public string DeviceTenureDescription { get; set; }
        public int? DeviceTenureBeginDay { get; set; }
        public int? DeviceTenureEndDay { get; set; }
        public DateTime? RecordCreatedDate { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime? RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int? CurrentRecord { get; set; }
        public DateTime? RecordEffectiveStartDatetime { get; set; }
        public DateTime? RecordEffectiveEndDatetime { get; set; }
    }
}
