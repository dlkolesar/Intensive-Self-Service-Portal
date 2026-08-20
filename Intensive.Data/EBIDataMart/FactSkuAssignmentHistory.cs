using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactSkuAssignmentHistory
    {
        public int TimeKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int DeviceKey { get; set; }
        public int SkuKey { get; set; }
        public int MeasureRecordCount { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int SourceSystemNameKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int ServerPartsId { get; set; }
        public int TimeMonthKey { get; set; }
    }
}
