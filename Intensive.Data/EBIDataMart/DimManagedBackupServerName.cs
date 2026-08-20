using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimManagedBackupServerName
    {
        public int ManagedBackupServerNameKey { get; set; }
        public string ManagedBackupServerName { get; set; }
        public DateTime? MbuServerRecordEffectiveStartDatetime { get; set; }
        public DateTime? MbuServerRecordEffectiveEndDatetime { get; set; }
        public int? MbuServerCurrentRecordFlag { get; set; }
        public DateTime? MbuServerRecordCreatedDatetime { get; set; }
        public DateTime? MbuServerRecordUpdatedDatetime { get; set; }
        public string MbuServerRecordCreatedBy { get; set; }
        public string MbuServerRecordUpdatedBy { get; set; }
    }
}
