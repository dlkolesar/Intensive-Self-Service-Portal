using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactSkuAssignmentExtendedAttribute
    {
        public int Id { get; set; }
        public int TimeKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int DeviceKey { get; set; }
        public int SkuKey { get; set; }
        public int SkuExtendedAttributeKey { get; set; }
        public int RecordSourceKey { get; set; }
        public int? MeasureCount { get; set; }
        public int? RecordCreatedTimeKey { get; set; }
        public int? RecordCreatedHmsKey { get; set; }
        public int? RecordUpdatedTimeKey { get; set; }
        public int? RecordUpdatedHmsKey { get; set; }
    }
}
