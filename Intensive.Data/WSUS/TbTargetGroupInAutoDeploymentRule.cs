using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbTargetGroupInAutoDeploymentRule
    {
        public int AutoDeploymentRuleId { get; set; }
        public Guid TargetGroupId { get; set; }

        public virtual TbAutoDeploymentRule AutoDeploymentRule { get; set; }
        public virtual TbTargetGroup TargetGroup { get; set; }
    }
}
