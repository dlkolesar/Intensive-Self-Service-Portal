using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbRequestedTargetGroup
    {
        public TbRequestedTargetGroup()
        {
            TbRequestedTargetGroupsForTarget = new HashSet<TbRequestedTargetGroupsForTarget>();
        }

        public int RequestedTargetGroupId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TbRequestedTargetGroupsForTarget> TbRequestedTargetGroupsForTarget { get; set; }
    }
}
