using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactPhoneSkillUsageDetail
    {
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int PhoneSkillKey { get; set; }
        public int AcdCallCount { get; set; }
        public int InboundCallCount { get; set; }
        public int InboundCallTime { get; set; }
        public int OutboundCallCount { get; set; }
        public int OutboundCallTime { get; set; }
        public int AbandonedCallCount { get; set; }
        public int RonaCallCount { get; set; }
        public int AcdDurationSeconds { get; set; }
        public int AcwDurationSeconds { get; set; }
        public int RingDurationSeconds { get; set; }
        public int AuxDurationSeconds { get; set; }
        public int AvailableDurationSeconds { get; set; }
        public int StaffedDurationSeconds { get; set; }
        public int MaxDelayDurationSeconds { get; set; }
        public int AnswerDurationSeconds { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int CallsOffered { get; set; }
    }
}
