using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDownstreamServerTarget
    {
        public TbDownstreamServerTarget()
        {
            TbComputerTarget = new HashSet<TbComputerTarget>();
        }

        public int TargetId { get; set; }
        public byte[] Sid { get; set; }
        public string AccountName { get; set; }
        public Guid? AccountServerId { get; set; }
        public DateTime? LastSyncTime { get; set; }
        public DateTime? RollupLastSyncTime { get; set; }
        public DateTime? LastDeploymentSyncTime { get; set; }
        public int? ParentServerTargetId { get; set; }
        public DateTime? LastRollupTime { get; set; }
        public string Version { get; set; }
        public bool IsReplica { get; set; }

        public virtual ICollection<TbComputerTarget> TbComputerTarget { get; set; }
        public virtual TbDownstreamServerTarget ParentServerTarget { get; set; }
        public virtual ICollection<TbDownstreamServerTarget> InverseParentServerTarget { get; set; }
        public virtual TbTarget Target { get; set; }
    }
}
