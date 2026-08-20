using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimResolutionProduct
    {
        public int ResolutionProductKey { get; set; }
        public string ResolutionProductIdNk { get; set; }
        public string ResolutionProductSuiteIdNk { get; set; }
        public string ResolutionProductType { get; set; }
        public string ResolutionProductName { get; set; }
        public DateTime ResolutionProductEffectiveStartDate { get; set; }
        public DateTime ResolutionProductEffectiveEndDate { get; set; }
        public DateTime RecordCreatedDate { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int ResolutionProductCurrentRecord { get; set; }
    }
}
