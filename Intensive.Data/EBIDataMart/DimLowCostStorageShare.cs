using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimLowCostStorageShare
    {
        public int StorageKey { get; set; }
        public string StorageNk { get; set; }
        public string StorageType { get; set; }
        public string StoragePath { get; set; }
        public DateTime EffectiveStartDatetime { get; set; }
        public DateTime EffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDate { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int CurrentRecord { get; set; }
    }
}
