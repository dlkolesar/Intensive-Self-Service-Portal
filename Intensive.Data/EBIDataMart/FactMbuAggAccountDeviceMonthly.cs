using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactMbuAggAccountDeviceMonthly
    {
        public int AccountKey { get; set; }
        public int TimeKey { get; set; }
        public int DeviceKey { get; set; }
        public int ManagedBackupTargetKey { get; set; }
        public int ManagedBackupStatusKey { get; set; }
        public int ManagedBackupLevelKey { get; set; }
        public int ManagedBackupSystemKey { get; set; }
        public decimal? Duration { get; set; }
        public decimal? TotalSizeMb { get; set; }
        public decimal? DaysSizeMb28 { get; set; }
        public int? RecordCreatedByKey { get; set; }
        public int? RecordCreatedTimeKey { get; set; }
        public int? RecordUpdatedByKey { get; set; }
        public int? RecordUpdatedTimeKey { get; set; }
        public int? RecordCreatedHmsKey { get; set; }
        public int? RecordUpdatedHmsKey { get; set; }
    }
}
