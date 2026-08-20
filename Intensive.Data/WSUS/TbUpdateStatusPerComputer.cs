using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbUpdateStatusPerComputer
    {
        public int SummarizationState { get; set; }
        public int LocalUpdateId { get; set; }
        public int TargetId { get; set; }
        public DateTime LastChangeTime { get; set; }
        public DateTime LastRefreshTime { get; set; }
        public DateTime LastChangeTimeOnServer { get; set; }

        public virtual TbUpdate LocalUpdate { get; set; }
        public virtual TbComputerTarget Target { get; set; }
    }
}
