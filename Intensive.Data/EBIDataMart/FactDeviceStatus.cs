using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactDeviceStatus
    {
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int AccountStatusKey { get; set; }
        public int DeviceKey { get; set; }
        public int DeviceStatusKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public int? MeasureCount { get; set; }
        public decimal? MeasureStatusDuration { get; set; }
        public int? RecordCreated { get; set; }
        public int? RecordCreatedHms { get; set; }
        public int? RecordUpdated { get; set; }
        public int? RecordUpdatedHms { get; set; }
        public int? DeviceNk { get; set; }
        public int? RecordCreatedBy { get; set; }
        public int? RecordUpdatedBy { get; set; }
        public int? StatusSsk { get; set; }
        public int? ContactKey { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
