using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbUpdate
    {
        public TbUpdate()
        {
            TbCategoryInAutoDeploymentRule = new HashSet<TbCategoryInAutoDeploymentRule>();
            TbInstalledUpdateSufficientForPrerequisite = new HashSet<TbInstalledUpdateSufficientForPrerequisite>();
            TbRevision = new HashSet<TbRevision>();
            TbUpdateClassificationInAutoDeploymentRule = new HashSet<TbUpdateClassificationInAutoDeploymentRule>();
            TbUpdateStatusPerComputer = new HashSet<TbUpdateStatusPerComputer>();
        }

        public int LocalUpdateId { get; set; }
        public Guid UpdateId { get; set; }
        public Guid UpdateTypeId { get; set; }
        public bool IsClientSelfUpdate { get; set; }
        public Guid PublisherId { get; set; }
        public bool IsPublic { get; set; }
        public bool IsHidden { get; set; }
        public string DetectoidType { get; set; }
        public string LegacyName { get; set; }
        public DateTime? LastUndeclinedTime { get; set; }
        public bool IsLocallyPublished { get; set; }
        public DateTime ImportedTime { get; set; }

        public virtual TbCategory TbCategory { get; set; }
        public virtual ICollection<TbCategoryInAutoDeploymentRule> TbCategoryInAutoDeploymentRule { get; set; }
        public virtual ICollection<TbInstalledUpdateSufficientForPrerequisite> TbInstalledUpdateSufficientForPrerequisite { get; set; }
        public virtual ICollection<TbRevision> TbRevision { get; set; }
        public virtual ICollection<TbUpdateClassificationInAutoDeploymentRule> TbUpdateClassificationInAutoDeploymentRule { get; set; }
        public virtual ICollection<TbUpdateStatusPerComputer> TbUpdateStatusPerComputer { get; set; }
        public virtual TbUpdateSummaryForAllComputers TbUpdateSummaryForAllComputers { get; set; }
        public virtual TbUpdateType UpdateType { get; set; }
    }
}
