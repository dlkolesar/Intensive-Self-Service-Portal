using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbRequestedTargetGroupsForTarget
    {
        public int TargetId { get; set; }
        public int RequestedTargetGroupId { get; set; }

        public virtual TbRequestedTargetGroup RequestedTargetGroup { get; set; }
        public virtual TbTarget Target { get; set; }
    }
}
