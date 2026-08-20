using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportImNetwork
    {
        public int Recid { get; set; }
        public string DatacenterName { get; set; }
        public string Zone { get; set; }
        public string SwitchNumber { get; set; }
        public string SwitchPortNumber { get; set; }
        public string TeamBusinessSegment { get; set; }
        public string TeamBusinessSubSegment { get; set; }
        public string TeamName { get; set; }
        public string AccountManager { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string DeviceNumber { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactPhone { get; set; }
        public string TechnicalContactName { get; set; }
        public string TechnicalContactPhone { get; set; }
        public decimal? Cmrr { get; set; }
        public int? MeasureCount { get; set; }
        public string ContainerName { get; set; }
    }
}
