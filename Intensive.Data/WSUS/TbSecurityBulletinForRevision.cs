using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbSecurityBulletinForRevision
    {
        public int RevisionId { get; set; }
        public string SecurityBulletinId { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
