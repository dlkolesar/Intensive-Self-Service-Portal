using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentDevice
    {
        public int IncidentDeviceId { get; set; }
        public int DeviceKey { get; set; }
        public int IncidentKey { get; set; }
        public int DeviceAssignmentTimeKey { get; set; }
        public int DeviceAssignmentHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int Count { get; set; }
        public DateTime IncidentDeviceRecordCreatedDatetime { get; set; }
        public string IncidentDeviceRecordCreatedBy { get; set; }
        public DateTime IncidentDeviceRecordUpdatedDatetime { get; set; }
        public string IncidentDeviceRecordUpdatedBy { get; set; }
        public string IncidentDeviceSourceSystemName { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
