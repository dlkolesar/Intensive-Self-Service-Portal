using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class DistributedTasks
    {
        public int TaskId { get; set; }
        public int ComputerId { get; set; }
        public int Status { get; set; }
        public string StatusText { get; set; }
        public byte[] Job { get; set; }
        public int? RetryTaskId { get; set; }
        public int? LogStatus { get; set; }
        public byte[] LogFile { get; set; }

        public virtual Computers Computer { get; set; }
        public virtual LocalTasks Task { get; set; }
    }
}
