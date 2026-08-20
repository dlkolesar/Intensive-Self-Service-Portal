using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbSingletonData
    {
        public int Id { get; set; }
        public bool UssHostOnMu { get; set; }
        public DateTime? LastAutoPurgeDateTime { get; set; }
        public bool ResetStateMachineNeeded { get; set; }
        public DateTime LastTimeReportToMu { get; set; }
        public string OfflineSyncExclusionListXml { get; set; }
    }
}
