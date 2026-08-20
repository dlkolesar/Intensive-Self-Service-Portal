using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimGeography
    {
        public long GeographyKey { get; set; }
        public string GeographySourceSystemIdNk { get; set; }
        public string GeographyCity { get; set; }
        public string GeographyRegion { get; set; }
        public string GeographyCountry { get; set; }
        public string GeographyZip { get; set; }
        public string GeographySourceSystemName { get; set; }
        public string GeographySourceSystemIdColumn { get; set; }
        public string GeographyCreatedBy { get; set; }
        public DateTime? GeographyCreatedDatetime { get; set; }
        public string GeographyUpdatedBy { get; set; }
        public DateTime? GeographyUpdatedDatetime { get; set; }
    }
}
