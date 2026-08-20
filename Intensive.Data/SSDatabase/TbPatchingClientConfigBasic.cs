using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbPatchingClientConfigBasic
    {
        public int DeviceNumber { get; set; }
        public short NoAutoRebootWithLoggedOnUsers { get; set; }
        public short ScheduledWeek { get; set; }
        public short ScheduledDay { get; set; }
        public short ScheduledTime { get; set; }
    }
}
