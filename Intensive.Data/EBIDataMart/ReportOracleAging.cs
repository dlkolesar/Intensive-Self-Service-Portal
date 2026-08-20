using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportOracleAging
    {
        public int Id { get; set; }
        public int? TimeKey { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal? TotalDue { get; set; }
        public decimal? CurrentDue { get; set; }
        public decimal? Due130 { get; set; }
        public decimal? Due3160 { get; set; }
        public decimal? Due6190 { get; set; }
        public decimal? Due91120 { get; set; }
        public decimal? Due121180 { get; set; }
        public decimal? Due181 { get; set; }
        public string Team { get; set; }
        public string AccountManager { get; set; }
        public string BusinessUnit { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
