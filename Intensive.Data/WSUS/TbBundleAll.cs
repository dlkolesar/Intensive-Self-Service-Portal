using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbBundleAll
    {
        public TbBundleAll()
        {
            TbBundleAtLeastOne = new HashSet<TbBundleAtLeastOne>();
        }

        public int RevisionId { get; set; }
        public int BundledId { get; set; }

        public virtual ICollection<TbBundleAtLeastOne> TbBundleAtLeastOne { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
