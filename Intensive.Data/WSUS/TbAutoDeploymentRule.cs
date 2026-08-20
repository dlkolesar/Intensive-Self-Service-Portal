using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbAutoDeploymentRule
    {
        public TbAutoDeploymentRule()
        {
            TbCategoryInAutoDeploymentRule = new HashSet<TbCategoryInAutoDeploymentRule>();
            TbTargetGroupInAutoDeploymentRule = new HashSet<TbTargetGroupInAutoDeploymentRule>();
            TbUpdateClassificationInAutoDeploymentRule = new HashSet<TbUpdateClassificationInAutoDeploymentRule>();
        }

        public int Id { get; set; }
        public bool Enabled { get; set; }
        public int ActionId { get; set; }
        public string Name { get; set; }
        public short? DateOffset { get; set; }
        public short? MinutesAfterMidnight { get; set; }

        public virtual ICollection<TbCategoryInAutoDeploymentRule> TbCategoryInAutoDeploymentRule { get; set; }
        public virtual ICollection<TbTargetGroupInAutoDeploymentRule> TbTargetGroupInAutoDeploymentRule { get; set; }
        public virtual ICollection<TbUpdateClassificationInAutoDeploymentRule> TbUpdateClassificationInAutoDeploymentRule { get; set; }
    }
}
