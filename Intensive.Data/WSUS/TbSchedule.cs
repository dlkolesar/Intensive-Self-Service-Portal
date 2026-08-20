using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbSchedule
    {
        public int ScheduleTarget { get; set; }
        public int ScheduleId { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
        public int? ScheduledTimeOfDay { get; set; }
        public DateTime? ScheduledRunTime { get; set; }
        public DateTime LastRunTime { get; set; }
        public int? Frequency { get; set; }
    }
}
