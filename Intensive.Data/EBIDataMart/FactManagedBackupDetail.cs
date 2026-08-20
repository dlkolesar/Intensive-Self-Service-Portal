using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactManagedBackupDetail
    {
        public int MbuDetailKey { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int TeamKey { get; set; }
        public int ManagedBackupTargetKey { get; set; }
        public short ManagedBackupStatusKey { get; set; }
        public int ManagedBackupServerKey { get; set; }
        public int ManagedBackupLevelKey { get; set; }
        public double? TotalSizeMb { get; set; }
        public double? Duration { get; set; }
        public DateTime? MbuDetailRecordCreatedDatetime { get; set; }
        public string MbuDetailRecordCreatedBy { get; set; }
        public DateTime? MbuDetailRecordUpdatedDatetime { get; set; }
        public string MbuDetailRecordUpdatedBy { get; set; }
        public string MbuDetailRecordSourceSystemName { get; set; }
        public byte? MbuDetailRecordValidFlag { get; set; }
        public int? TimezoneKey { get; set; }
        public int? RegionTimezoneKey { get; set; }
        public int? RegionTimeKey { get; set; }
        public int? RegionHmsKey { get; set; }
        public int? EndTimeKey { get; set; }
        public int? EndHmsKey { get; set; }
        public int? RegionEndTimeKey { get; set; }
        public int? RegionEndHmsKey { get; set; }
        public decimal? DurationProcess { get; set; }
    }
}
