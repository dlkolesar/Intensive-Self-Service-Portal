using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbUpdateClassificationInAutoDeploymentRule
    {
        public int AutoDeploymentRuleId { get; set; }
        public int UpdateClassificationId { get; set; }

        public virtual TbAutoDeploymentRule AutoDeploymentRule { get; set; }
        public virtual TbUpdate UpdateClassification { get; set; }
    }
}
