using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactAccountProductPriceDailySnapshot
    {
        public int AccountProductPriceDailySnapshotKey { get; set; }
        public int TimeKey { get; set; }
        public int TeamKey { get; set; }
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int ProductKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public decimal AccountProductPriceDailySnapshotAmount { get; set; }
        public decimal AccountProductPriceDailySnapshotQuantity { get; set; }
        public DateTime AccountProductPriceDailySnapshotRecordCreatedDatetime { get; set; }
        public string AccountProductPriceDailySnapshotRecordCreatedBy { get; set; }
        public DateTime AccountProductPriceDailySnapshotRecordUpdatedDatetime { get; set; }
        public string AccountProductPriceDailySnapshotRecordUpdatedBy { get; set; }
        public string AccountProductPriceDailySnapshotSourceSystemName { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
