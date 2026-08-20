using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportIncidentMessageData
    {
        public int Id { get; set; }
        public int? TimeYearNumber { get; set; }
        public int? TimeMonthNumber { get; set; }
        public string TimeMonthAbbr { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string TitleBucket { get; set; }
        public int? CommentsCount { get; set; }
    }
}
