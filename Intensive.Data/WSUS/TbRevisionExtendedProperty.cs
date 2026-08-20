using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbRevisionExtendedProperty
    {
        public int RevisionId { get; set; }
        public long? RecommendedMemory { get; set; }
        public long? RecommendedHardDiskSpace { get; set; }
        public string PrerequisitesXml { get; set; }
        public string IsInstalledXml { get; set; }
        public string IsInstallableXml { get; set; }
        public string HandlerSpecificDataXml { get; set; }
        public string ExtendedApplicabilityXml { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
