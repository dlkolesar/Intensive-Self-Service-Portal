using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbInstalledUpdateSufficientForPrerequisite
    {
        public int PrerequisiteId { get; set; }
        public int LocalUpdateId { get; set; }

        public virtual TbUpdate LocalUpdate { get; set; }
        public virtual TbPrerequisite Prerequisite { get; set; }
    }
}
