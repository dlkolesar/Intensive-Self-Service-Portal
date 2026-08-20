using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbTargetGroup
    {
        public TbTargetGroup()
        {
            TbDeployment = new HashSet<TbDeployment>();
            TbExpandedTargetInTargetGroup = new HashSet<TbExpandedTargetInTargetGroup>();
            TbFlattenedTargetGroupParentGroup = new HashSet<TbFlattenedTargetGroup>();
            TbFlattenedTargetGroupTargetGroup = new HashSet<TbFlattenedTargetGroup>();
            TbTargetGroupInAutoDeploymentRule = new HashSet<TbTargetGroupInAutoDeploymentRule>();
            TbTargetInTargetGroup = new HashSet<TbTargetInTargetGroup>();
        }

        public int TargetGroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TargetGroupId { get; set; }
        public int OrderValue { get; set; }
        public bool IsBuiltin { get; set; }
        public Guid? ParentGroupId { get; set; }
        public int GroupPriority { get; set; }

        public virtual ICollection<TbDeployment> TbDeployment { get; set; }
        public virtual ICollection<TbExpandedTargetInTargetGroup> TbExpandedTargetInTargetGroup { get; set; }
        public virtual ICollection<TbFlattenedTargetGroup> TbFlattenedTargetGroupParentGroup { get; set; }
        public virtual ICollection<TbFlattenedTargetGroup> TbFlattenedTargetGroupTargetGroup { get; set; }
        public virtual ICollection<TbTargetGroupInAutoDeploymentRule> TbTargetGroupInAutoDeploymentRule { get; set; }
        public virtual ICollection<TbTargetInTargetGroup> TbTargetInTargetGroup { get; set; }
        public virtual TbTargetGroup ParentGroup { get; set; }
        public virtual ICollection<TbTargetGroup> InverseParentGroup { get; set; }
        public virtual TbTargetGroupType TargetGroupType { get; set; }
    }
}
