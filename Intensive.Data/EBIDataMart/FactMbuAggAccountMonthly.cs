using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactMbuAggAccountMonthly
    {
        public int AccountKey { get; set; }
        public int TimeKey { get; set; }
        public int ManagedBackupStatusKey { get; set; }
        public decimal? Duration { get; set; }
        public decimal? TotalSizeMb { get; set; }
        public decimal? DaysSizeMb28 { get; set; }
        public int? RecordCreatedByKey { get; set; }
        public int? RecordCreatedTimeKey { get; set; }
        public int? RecordUpdatedByKey { get; set; }
        public int? RecordUpdatedTimeKey { get; set; }
        public int? RecordCreatedHmsKey { get; set; }
        public int? RecordUpdatedHmsKey { get; set; }
        public decimal? FullMonthOverageUsageGb { get; set; }
        public decimal? FullMonthProjectedUsageGb { get; set; }
        public decimal? FullMonthProjectedOverageUsageGb { get; set; }
        public decimal? _28DayOverageUsageGb { get; set; }
        public decimal? _28DayProjectedUsageGb { get; set; }
        public decimal? _28DayProjectedOverageUsageGb { get; set; }
    }
}
