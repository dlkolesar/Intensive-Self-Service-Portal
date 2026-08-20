using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbComputerTarget
    {
        public TbComputerTarget()
        {
            TbInventoryClassInstance = new HashSet<TbInventoryClassInstance>();
            TbUpdateStatusPerComputer = new HashSet<TbUpdateStatusPerComputer>();
        }

        public int TargetId { get; set; }
        public string ComputerId { get; set; }
        public byte[] Sid { get; set; }
        public DateTime? LastSyncTime { get; set; }
        public DateTime? LastReportedStatusTime { get; set; }
        public DateTime? LastReportedRebootTime { get; set; }
        public string Ipaddress { get; set; }
        public string FullDomainName { get; set; }
        public bool IsRegistered { get; set; }
        public DateTime? LastInventoryTime { get; set; }
        public DateTime? LastNameChangeTime { get; set; }
        public DateTime? EffectiveLastDetectionTime { get; set; }
        public int? ParentServerTargetId { get; set; }
        public int LastSyncResult { get; set; }

        public virtual TbComputersThatNeedDetailedRollup TbComputersThatNeedDetailedRollup { get; set; }
        public virtual TbComputerSummaryForMicrosoftUpdates TbComputerSummaryForMicrosoftUpdates { get; set; }
        public virtual ICollection<TbInventoryClassInstance> TbInventoryClassInstance { get; set; }
        public virtual TbInventoryXml TbInventoryXml { get; set; }
        public virtual ICollection<TbUpdateStatusPerComputer> TbUpdateStatusPerComputer { get; set; }
        public virtual TbDownstreamServerTarget ParentServerTarget { get; set; }
        public virtual TbTarget Target { get; set; }
    }
}
