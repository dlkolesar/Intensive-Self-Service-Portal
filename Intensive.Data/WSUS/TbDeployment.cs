using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDeployment
    {
        public int DeploymentId { get; set; }
        public DateTime LastChangeTime { get; set; }
        public long LastChangeNumber { get; set; }
        public byte DeploymentStatus { get; set; }
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
        public bool IsLeaf { get; set; }
        public string UpdateType { get; set; }
        public bool IsCritical { get; set; }
        public int Priority { get; set; }
        public bool? IsFeatured { get; set; }
        public byte? AutoSelect { get; set; }
        public byte? AutoDownload { get; set; }
        public byte? SupersedenceBehavior { get; set; }

        public virtual TbRevision Revision { get; set; }
        public virtual TbTargetGroup TargetGroup { get; set; }
    }
}
