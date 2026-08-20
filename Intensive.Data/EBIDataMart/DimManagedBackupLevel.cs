using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimManagedBackupLevel
    {
        public int ManagedBackupLevelKey { get; set; }
        public string ManagedBackupLevelName { get; set; }
        public string ManagedBackupLevelDescription { get; set; }
        public DateTime? MbuLevelRecordEffectiveStartDatetime { get; set; }
        public DateTime? MbuLevelRecordEffectiveEndDatetime { get; set; }
        public DateTime? MbuLevelRecordCreatedDatetime { get; set; }
        public DateTime? MbuLevelRecordUpdatedDatetime { get; set; }
        public string MbuLevelRecordCreatedBy { get; set; }
        public string MbuLevelRecordUpdatedBy { get; set; }
        public int? MbuLevelCurrentRecordFlag { get; set; }
    }
}
