using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbFileForRevision
    {
        public int RevisionId { get; set; }
        public byte[] FileDigest { get; set; }
        public byte PatchingType { get; set; }

        public virtual TbFile FileDigestNavigation { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
