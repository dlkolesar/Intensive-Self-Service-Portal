using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbUpdateSummaryForAllComputers
    {
        public int LocalUpdateId { get; set; }
        public int Unknown { get; set; }
        public int NotInstalled { get; set; }
        public int Downloaded { get; set; }
        public int Installed { get; set; }
        public int Failed { get; set; }
        public int InstalledPendingReboot { get; set; }
        public DateTime LastChangeTime { get; set; }

        public virtual TbUpdate LocalUpdate { get; set; }
    }
}
