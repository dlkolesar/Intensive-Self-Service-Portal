using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbPrerequisite
    {
        public TbPrerequisite()
        {
            TbInstalledUpdateSufficientForPrerequisite = new HashSet<TbInstalledUpdateSufficientForPrerequisite>();
        }

        public int PrerequisiteId { get; set; }
        public int RevisionId { get; set; }

        public virtual ICollection<TbInstalledUpdateSufficientForPrerequisite> TbInstalledUpdateSufficientForPrerequisite { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
