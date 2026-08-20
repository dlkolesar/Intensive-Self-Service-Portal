using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDeadDeployment
    {
        public int DeploymentId { get; set; }
        public DateTime TimeOfDeath { get; set; }
        public int ActionId { get; set; }
        public DateTime DeploymentTime { get; set; }
        public DateTime GoLiveTime { get; set; }
        public DateTime? Deadline { get; set; }
        public string AdminName { get; set; }
        public byte DownloadPriority { get; set; }
        public Guid DeploymentGuid { get; set; }
        public bool IsAssigned { get; set; }
        public int RevisionId { get; set; }
        public Guid TargetGroupId { get; set; }
        public byte TargetGroupTypeId { get; set; }
        public string AdminNameWhoDeleted { get; set; }
        public long LastChangeNumber { get; set; }
        public Guid UpdateId { get; set; }
        public int RevisionNumber { get; set; }
        public string UpdateType { get; set; }
    }
}
