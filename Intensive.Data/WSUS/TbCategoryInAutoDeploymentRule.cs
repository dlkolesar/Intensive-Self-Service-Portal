using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbCategoryInAutoDeploymentRule
    {
        public int AutoDeploymentRuleId { get; set; }
        public int CategoryId { get; set; }

        public virtual TbAutoDeploymentRule AutoDeploymentRule { get; set; }
        public virtual TbUpdate Category { get; set; }
    }
}
