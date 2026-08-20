using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimChurnProbability
    {
        public int ChurnProbabilityKey { get; set; }
        public string ChurnProbabilityNk { get; set; }
        public DateTime? RecordEffectiveStartDatetime { get; set; }
        public DateTime? RecordEffectiveEndDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime? RecordCreatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public DateTime? RecordUpdatedDatetime { get; set; }
        public string SourceSystemName { get; set; }
        public int? CurrentRecord { get; set; }
    }
}
