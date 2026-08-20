using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimChurnReasonDetail
    {
        public int ChurnReasonDetailKey { get; set; }
        public int? ChurnReasonDetailNumber { get; set; }
        public string ChurnReasonDetailGroupName { get; set; }
        public string ChurnReasonDetailCategory { get; set; }
        public string ChurnReasonDetailReportGroupName { get; set; }
        public int? ChurnReasonDetailReportRanking { get; set; }
        public DateTime? RecAdded { get; set; }
        public DateTime? RecUpdated { get; set; }
        public int? CurrentRecord { get; set; }
    }
}
