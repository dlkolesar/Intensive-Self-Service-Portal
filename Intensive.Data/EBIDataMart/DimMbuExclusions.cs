using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimMbuExclusions
    {
        public long MbuExclusionsKey { get; set; }
        public string MbuExclusionNk { get; set; }
        public int MbuCollectionPointId { get; set; }
        public string MbuCollectionPointName { get; set; }
        public string MbuExclusions { get; set; }
        public string MbuExclusionType { get; set; }
        public string MbuExclusionTypeDetail { get; set; }
        public string MbuSource { get; set; }
        public DateTime RecordEffectiveStartDate { get; set; }
        public DateTime RecordEffectiveEndDate { get; set; }
        public byte CurrentRecord { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordCreatedOn { get; set; }
        public string RecordUpdatedBy { get; set; }
        public DateTime RecordUpdatedOn { get; set; }
    }
}
