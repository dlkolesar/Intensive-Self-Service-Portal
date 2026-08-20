using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactProductUsage
    {
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int ProductKey { get; set; }
        public int TeamKey { get; set; }
        public int TimeKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public int SourceKey { get; set; }
        public int SpecialPricingFlag { get; set; }
        public decimal UsageQuantity { get; set; }
        public int UsageCount { get; set; }
        public decimal ProvisionedQuantity { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int StatusKey { get; set; }
        public decimal? UsageQuantityRunningSum { get; set; }
    }
}
