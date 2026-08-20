using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTimezone
    {
        public int TimezoneKey { get; set; }
        public string TimezoneIdNk { get; set; }
        public string TimezoneAbbreviation { get; set; }
        public string TimezoneDescription { get; set; }
        public string TimezoneRegion { get; set; }
        public string TimezoneConversionText { get; set; }
        public decimal? TimezoneUtcOffset { get; set; }
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
