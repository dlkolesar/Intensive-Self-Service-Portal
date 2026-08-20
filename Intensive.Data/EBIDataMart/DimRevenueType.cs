using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimRevenueType
    {
        public int RevenueTypeKey { get; set; }
        public string RevenueTypeName { get; set; }
        public string RevenueTypeCategory { get; set; }
        public string RevenueTypeDetail { get; set; }
        public int RevenueTypeReportRanking { get; set; }
        public DateTime? RecAdded { get; set; }
        public DateTime? RecUpdated { get; set; }
        public int? CurrentRecord { get; set; }
        public string RevenueTypeSubCategory { get; set; }
    }
}
