using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactDeviceLocationReservationMtd
    {
        public int Id { get; set; }
        public int TimeKey { get; set; }
        public int? AccountKey { get; set; }
        public int? DeviceKey { get; set; }
        public int? ContainerKey { get; set; }
        public int? ContainerComponentKey { get; set; }
        public int? ErwinShelfKey { get; set; }
        public int? ReservationKey { get; set; }
        public int? RecordCreated { get; set; }
        public int? RecordCreatedHms { get; set; }
        public int? RecordUpdated { get; set; }
        public int? RecordUpdatedHms { get; set; }
    }
}
