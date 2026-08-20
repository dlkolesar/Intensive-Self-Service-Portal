using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbRevisionSupersedesUpdate
    {
        public int RevisionId { get; set; }
        public Guid SupersededUpdateId { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
