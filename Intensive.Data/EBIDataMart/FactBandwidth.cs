using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactBandwidth
    {
        public int BandwidthAccountKey { get; set; }
        public int BandwidthTeamKey { get; set; }
        public int BandwidthTimeKey { get; set; }
        public int BandwidthDeviceKey { get; set; }
        public double GigabytesUsed { get; set; }
        public double? GigabytesSubscription { get; set; }
        public string BandwidthRecordCreatedBy { get; set; }
        public DateTime BandwidthRecordCreatedDatetime { get; set; }
        public string BandwidthRecordUpdatedBy { get; set; }
        public DateTime BandwidthRecordUpdatedDatetime { get; set; }
        public string BandwidthSourceSystemName { get; set; }
    }
}
