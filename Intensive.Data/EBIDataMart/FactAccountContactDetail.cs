using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactAccountContactDetail
    {
        public string TransactionId { get; set; }
        public int StartTimeKey { get; set; }
        public int StartHmsKey { get; set; }
        public int EndTimeKey { get; set; }
        public int EndHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int ContactKey { get; set; }
        public int ContactRoleKey { get; set; }
        public int MeasureCount { get; set; }
        public int MeasureActiveContactCount { get; set; }
        public long MeasureAssignmentDurationSeconds { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int SourceSystemKey { get; set; }
    }
}
