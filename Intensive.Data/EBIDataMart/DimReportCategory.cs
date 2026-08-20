using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimReportCategory
    {
        public int ReportCategoryKey { get; set; }
        public string ReportCategoryName { get; set; }
        public int? ReportCategoryRanking { get; set; }
    }
}
