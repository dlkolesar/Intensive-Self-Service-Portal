using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactPhoneVdnUsageDetail
    {
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int PhoneVdnKey { get; set; }
        public int AcdCallCount { get; set; }
        public int AcdDurationSeconds { get; set; }
        public int MainAcdCallCount { get; set; }
        public int AnswerDurationSeconds { get; set; }
        public int AvgAnswerDurationSeconds { get; set; }
        public int InboundCallCount { get; set; }
        public int InboundDurationSeconds { get; set; }
        public int InflowCallCount { get; set; }
        public int OutflowCallCount { get; set; }
        public int OutflowDurationSeconds { get; set; }
        public int AbandonedCallCount { get; set; }
        public int AbandonedDurationSeconds { get; set; }
        public int AvgAbandonDurationSeconds { get; set; }
        public int RonaCallCount { get; set; }
        public int AcwDurationSeconds { get; set; }
        public int MaxDelayDurationSeconds { get; set; }
        public int BackupCallCount { get; set; }
        public int RingDurationSeconds { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
    }
}
