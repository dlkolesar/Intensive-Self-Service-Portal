using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimManagedBackupTarget
    {
        public int ManagedBackupTargetKey { get; set; }
        public string ManagedBackupTargetName { get; set; }
        public DateTime? MbuTargetRecordEffectiveStartDatetime { get; set; }
        public DateTime? MbuTargetRecordEffectiveEndDatetime { get; set; }
        public DateTime? MbuTargetRecordCreatedDatetime { get; set; }
        public DateTime? MbuTargetRecordUpdatedDatetime { get; set; }
        public string MbuTargetRecordCreatedBy { get; set; }
        public string MbuTargetRecordUpdatedBy { get; set; }
        public int? MbuTargetCurrentRecordFlag { get; set; }
    }
}
