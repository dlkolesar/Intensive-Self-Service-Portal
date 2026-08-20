using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbTargetInTargetGroup
    {
        public Guid TargetGroupId { get; set; }
        public int TargetId { get; set; }
        public bool IsExplicitMember { get; set; }

        public virtual TbTargetGroup TargetGroup { get; set; }
        public virtual TbTarget Target { get; set; }
    }
}
