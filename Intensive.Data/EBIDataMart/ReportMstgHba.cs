using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportMstgHba
    {
        public int ReportHbaId { get; set; }
        public string DeviceDatacenterAbbr { get; set; }
        public int? AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal? AccountCmrr { get; set; }
        public int? DeviceNumber { get; set; }
        public string DeviceStatus { get; set; }
        public int? DeviceStatusNumber { get; set; }
        public DateTime? DeviceLastModifiedDate { get; set; }
        public int? SkuNumber { get; set; }
        public int? SkuKey { get; set; }
        public string SkuDescription { get; set; }
        public string TeamBusinessSegment { get; set; }
        public DateTime? DeviceOnlineDate { get; set; }
        public DateTime? DeviceOfflineDate { get; set; }
        public DateTime? DeviceContractReceivedDate { get; set; }
    }
}
