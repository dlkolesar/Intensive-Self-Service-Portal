using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactDeviceLocationMtdHistory
    {
        public int TimeKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int DeviceKey { get; set; }
        public int DeviceContainerKey { get; set; }
        public int DatacenterKey { get; set; }
        public int ContainerComponentKey { get; set; }
        public int ErwinShelfKey { get; set; }
        public int SwitchKey { get; set; }
        public int SwitchContainerKey { get; set; }
        public int SwitchPortKey { get; set; }
        public int ReservationKey { get; set; }
        public int MeasureCount { get; set; }
        public string RecordSourceKey { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordUpdatedByKey { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
