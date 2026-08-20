using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbFlattenedTargetGroup
    {
        public Guid TargetGroupId { get; set; }
        public Guid ParentGroupId { get; set; }

        public virtual TbTargetGroup ParentGroup { get; set; }
        public virtual TbTargetGroup TargetGroup { get; set; }
    }
}
