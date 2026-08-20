using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSeverity
    {
        public int SeverityKey { get; set; }
        public string SeverityTypeNk { get; set; }
        public string SeverityNk { get; set; }
        public string SeverityShortDescription { get; set; }
        public string SeverityLongDescription { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public byte CurrentRecordFlag { get; set; }
    }
}
