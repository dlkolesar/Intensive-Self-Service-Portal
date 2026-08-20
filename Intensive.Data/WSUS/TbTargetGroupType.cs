using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbTargetGroupType
    {
        public TbTargetGroupType()
        {
            TbTargetGroup = new HashSet<TbTargetGroup>();
        }

        public int TargetGroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TbTargetGroup> TbTargetGroup { get; set; }
    }
}
