using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimInstanceConfiguration
    {
        public int InstanceConfigurationKey { get; set; }
        public string InstanceConfigurationSsk { get; set; }
        public string InstanceConfigurationType { get; set; }
        public string InstanceCategory { get; set; }
        public string FlavorId { get; set; }
        public string FlavorName { get; set; }
        public string Option { get; set; }
        public string BackupFlag { get; set; }
        public string CpuAmount { get; set; }
        public string CpuCoreAmount { get; set; }
        public string MemoryAmount { get; set; }
        public string StorageAmount { get; set; }
        public string BandwidthAmount { get; set; }
        public string UnitAmount { get; set; }
        public string OsName { get; set; }
        public string OsVersion { get; set; }
        public string OsPlatform { get; set; }
        public string DbName { get; set; }
        public string DbVersion { get; set; }
        public string DbPlatform { get; set; }
        public string DbSizeAmount { get; set; }
        public string ProtocolType { get; set; }
        public string ProtocolName { get; set; }
        public string PortNumber { get; set; }
        public string Algorithm { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public DateTime? RecordCreatedAt { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime? RecordUpdatedAt { get; set; }
        public string RecordUpdatedBy { get; set; }
        public int? CurrentRecord { get; set; }
    }
}
