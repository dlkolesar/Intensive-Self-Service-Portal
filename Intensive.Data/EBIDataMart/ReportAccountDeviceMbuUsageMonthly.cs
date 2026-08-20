using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportAccountDeviceMbuUsageMonthly
    {
        public string AccountNumber { get; set; }
        public long DeviceNumber { get; set; }
        public string TimeMonthKey { get; set; }
        public decimal? TotalSizeGb { get; set; }
        public decimal? TotalDaysSizeGb28 { get; set; }
        public decimal? DurationInMinutes { get; set; }
        public decimal Subscription { get; set; }
        public string AccountTeamName { get; set; }
        public string AccountManager { get; set; }
        public string AccountBdc { get; set; }
        public string TeamBusinessSegment { get; set; }
        public string TeamBusinessSubSegment { get; set; }
        public string AccountHasUnmetered { get; set; }
        public decimal OverageRate { get; set; }
        public string OverageFeeType { get; set; }
        public decimal LocalCurrencyOverageFee { get; set; }
        public string LocalCurrencyType { get; set; }
    }
}
