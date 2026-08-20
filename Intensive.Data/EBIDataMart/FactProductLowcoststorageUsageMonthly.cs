using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactProductLowcoststorageUsageMonthly
    {
        public int TimeKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int BillingDeviceKey { get; set; }
        public int StorageKey { get; set; }
        public int UomHardThresholdKey { get; set; }
        public int UomAdvisoryThresholdKey { get; set; }
        public int UomStorageUsageKey { get; set; }
        public decimal HardThreshold { get; set; }
        public decimal AdvisoryThreshold { get; set; }
        public decimal StorageUsage { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
    }
}
