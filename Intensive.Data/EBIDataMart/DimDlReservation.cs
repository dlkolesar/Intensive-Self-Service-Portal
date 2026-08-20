using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDlReservation
    {
        public int ReservationKey { get; set; }
        public string ReservationIdNk { get; set; }
        public string ReservationName { get; set; }
        public string ReservationAccountNumber { get; set; }
        public int? ReservationUHeight { get; set; }
        public int? ReservationNumPerWidth { get; set; }
        public string ReservationNumber { get; set; }
        public string ReservationComment { get; set; }
        public int? ReservationStartingSpace { get; set; }
        public int? ReservationUndermountSpace { get; set; }
        public int? ReservationDeviceId { get; set; }
        public int? ReservationContainerId { get; set; }
        public int? ReservationErwinShelfId { get; set; }
        public DateTime? RecordEffectiveStartDatetime { get; set; }
        public DateTime? RecordEffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUdpatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string AccountSourceSystemName { get; set; }
        public string RecordSourceSystem { get; set; }
        public int CurrentRecord { get; set; }
    }
}
