using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportBandwidthOverage
    {
        public long? AccountNumber { get; set; }
        public long? DeviceNumber { get; set; }
        public decimal? Usage { get; set; }
        public decimal? Subscription { get; set; }
        public string Team { get; set; }
        public DateTime? RecordCreatedDate { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime? RecordUpdatedDate { get; set; }
        public string RecordUpdatedBy { get; set; }
        public int Id { get; set; }
    }
}
