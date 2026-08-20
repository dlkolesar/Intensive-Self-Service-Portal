using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimProductSource
    {
        public int ProductSourceKey { get; set; }
        public string ProductSourceNk { get; set; }
        public string ProductSourceName { get; set; }
        public string ProductSourceCategory { get; set; }
        public DateTime ProductSourceEffectiveStartDatetime { get; set; }
        public DateTime ProductSourceEffectiveEndDatetime { get; set; }
        public DateTime ProductSourceRecordCreatedDatetime { get; set; }
        public string ProductSourceRecordCreatedBy { get; set; }
        public DateTime ProductSourceRecordUpdatedDatetime { get; set; }
        public string ProductSourceRecordUpdatedBy { get; set; }
        public string ProductSourceSourceSystemName { get; set; }
        public int ProductSourceCurrentRecord { get; set; }
    }
}
