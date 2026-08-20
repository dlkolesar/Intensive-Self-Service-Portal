using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimManagedBackupStatus
    {
        public short ManagedBackupStatusKey { get; set; }
        public string ManagedBackupStatusName { get; set; }
        public DateTime? MbuStatusRecordEffectiveStartDatetime { get; set; }
        public DateTime? MbuStatusRecordEffectiveEndDatetime { get; set; }
        public DateTime? MbuStatusRecordCreatedDatetime { get; set; }
        public DateTime? MbuStatusRecordUpdatedDatetime { get; set; }
        public string MbuStatusRecordCreatedBy { get; set; }
        public string MbuStatusRecordUpdatedBy { get; set; }
        public int? MbuStatusCurrentRecordFlag { get; set; }
    }
}
