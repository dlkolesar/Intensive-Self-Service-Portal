using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbRevision
    {
        public TbRevision()
        {
            TbBundleAll = new HashSet<TbBundleAll>();
            TbBundleAtLeastOne = new HashSet<TbBundleAtLeastOne>();
            TbCompatiblePrinterProvider = new HashSet<TbCompatiblePrinterProvider>();
            TbDeployment = new HashSet<TbDeployment>();
            TbDriver = new HashSet<TbDriver>();
            TbEulaProperty = new HashSet<TbEulaProperty>();
            TbFileForRevision = new HashSet<TbFileForRevision>();
            TbFlattenedRevisionInCategory = new HashSet<TbFlattenedRevisionInCategory>();
            TbLocalizedPropertyForRevision = new HashSet<TbLocalizedPropertyForRevision>();
            TbMoreInfoUrlforRevision = new HashSet<TbMoreInfoUrlforRevision>();
            TbPreComputedLocalizedProperty = new HashSet<TbPreComputedLocalizedProperty>();
            TbPrerequisite = new HashSet<TbPrerequisite>();
            TbRevisionInCategory = new HashSet<TbRevisionInCategory>();
            TbRevisionLanguage = new HashSet<TbRevisionLanguage>();
            TbRevisionSupersedesUpdate = new HashSet<TbRevisionSupersedesUpdate>();
            TbXml = new HashSet<TbXml>();
        }

        public int RevisionId { get; set; }
        public int LocalUpdateId { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime? LastIsLeafChange { get; set; }
        public bool IsLeaf { get; set; }
        public bool IsBeta { get; set; }
        public DateTime? TimeToGoLiveOnCatalog { get; set; }
        public Guid RowId { get; set; }
        public byte State { get; set; }
        public int Origin { get; set; }
        public bool IsCritical { get; set; }
        public long LanguageMask { get; set; }
        public bool IsLatestRevision { get; set; }
        public bool IsMandatory { get; set; }

        public virtual ICollection<TbBundleAll> TbBundleAll { get; set; }
        public virtual ICollection<TbBundleAtLeastOne> TbBundleAtLeastOne { get; set; }
        public virtual ICollection<TbCompatiblePrinterProvider> TbCompatiblePrinterProvider { get; set; }
        public virtual ICollection<TbDeployment> TbDeployment { get; set; }
        public virtual ICollection<TbDriver> TbDriver { get; set; }
        public virtual ICollection<TbEulaProperty> TbEulaProperty { get; set; }
        public virtual ICollection<TbFileForRevision> TbFileForRevision { get; set; }
        public virtual ICollection<TbFlattenedRevisionInCategory> TbFlattenedRevisionInCategory { get; set; }
        public virtual TbKbarticleForRevision TbKbarticleForRevision { get; set; }
        public virtual ICollection<TbLocalizedPropertyForRevision> TbLocalizedPropertyForRevision { get; set; }
        public virtual ICollection<TbMoreInfoUrlforRevision> TbMoreInfoUrlforRevision { get; set; }
        public virtual ICollection<TbPreComputedLocalizedProperty> TbPreComputedLocalizedProperty { get; set; }
        public virtual ICollection<TbPrerequisite> TbPrerequisite { get; set; }
        public virtual TbProperty TbProperty { get; set; }
        public virtual TbRevisionExtendedLanguageMask TbRevisionExtendedLanguageMask { get; set; }
        public virtual TbRevisionExtendedProperty TbRevisionExtendedProperty { get; set; }
        public virtual ICollection<TbRevisionInCategory> TbRevisionInCategory { get; set; }
        public virtual ICollection<TbRevisionLanguage> TbRevisionLanguage { get; set; }
        public virtual ICollection<TbRevisionSupersedesUpdate> TbRevisionSupersedesUpdate { get; set; }
        public virtual TbSecurityBulletinForRevision TbSecurityBulletinForRevision { get; set; }
        public virtual ICollection<TbXml> TbXml { get; set; }
        public virtual TbUpdate LocalUpdate { get; set; }
    }
}
