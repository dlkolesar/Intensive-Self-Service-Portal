using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimResolutionProductSuite
    {
        public int ResolutionProductSuiteKey { get; set; }
        public string ResolutionProductSuiteIdNk { get; set; }
        public string ResolutionProductSuiteType { get; set; }
        public string ResolutionProductSuiteName { get; set; }
        public DateTime ResolutionProductSuiteEffectiveStartDate { get; set; }
        public DateTime ResolutionProductSuiteEffectiveEndDate { get; set; }
        public DateTime RecordCreatedDate { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int ResolutionProductSuiteCurrentRecord { get; set; }
    }
}
