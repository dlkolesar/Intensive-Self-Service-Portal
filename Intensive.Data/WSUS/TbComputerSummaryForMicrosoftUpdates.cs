using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbComputerSummaryForMicrosoftUpdates
    {
        public int TargetId { get; set; }
        public int Unknown { get; set; }
        public int NotInstalled { get; set; }
        public int Downloaded { get; set; }
        public int Installed { get; set; }
        public int Failed { get; set; }
        public int InstalledPendingReboot { get; set; }
        public DateTime LastChangeTime { get; set; }

        public virtual TbComputerTarget Target { get; set; }
    }
}
