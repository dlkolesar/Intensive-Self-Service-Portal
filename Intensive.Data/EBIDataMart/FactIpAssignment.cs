using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIpAssignment
    {
        public int Id { get; set; }
        public int IpAddressKey { get; set; }
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int TeamKey { get; set; }
        public int DatacenterKey { get; set; }
        public int AssignedTimeKey { get; set; }
        public int AssignedHmsKey { get; set; }
        public int UnassignedTimeKey { get; set; }
        public int UnassignedHmsKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public int IpBlockKey { get; set; }
        public int AutonomusSystemKey { get; set; }
        public int? MeasureCount { get; set; }
        public int? MeasureAssignedTime { get; set; }
        public int? MeasureAssign48Hours { get; set; }
        public int? RecordCreatedByKey { get; set; }
        public int? RecordUpdatedByKey { get; set; }
        public int? RecordCreatedTimeKey { get; set; }
        public int? RecordUpdatedTimeKey { get; set; }
        public int? RecordCreatedHmsKey { get; set; }
        public int? RecordUpdatedHmsKey { get; set; }
    }
}
