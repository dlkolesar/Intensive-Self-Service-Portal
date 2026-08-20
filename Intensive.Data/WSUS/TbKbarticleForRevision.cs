using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbKbarticleForRevision
    {
        public int RevisionId { get; set; }
        public string KbarticleId { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
