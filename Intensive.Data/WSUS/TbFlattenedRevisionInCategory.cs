using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbFlattenedRevisionInCategory
    {
        public int RevisionId { get; set; }
        public int CategoryId { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
