using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbBundleAtLeastOne
    {
        public int RevisionId { get; set; }
        public int BundledId { get; set; }

        public virtual TbBundleAll Bundled { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
