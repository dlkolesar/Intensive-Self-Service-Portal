using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbTarget
    {
        public TbTarget()
        {
            TbDownstreamServerClientSummaryRollup = new HashSet<TbDownstreamServerClientSummaryRollup>();
            TbExpandedTargetInTargetGroup = new HashSet<TbExpandedTargetInTargetGroup>();
            TbRequestedTargetGroupsForTarget = new HashSet<TbRequestedTargetGroupsForTarget>();
            TbTargetInTargetGroup = new HashSet<TbTargetInTargetGroup>();
        }

        public int TargetId { get; set; }
        public int TargetTypeId { get; set; }
        public string Name { get; set; }
        public bool IsNewClient { get; set; }
        public string Description { get; set; }

        public virtual TbComputerTarget TbComputerTarget { get; set; }
        public virtual ICollection<TbDownstreamServerClientSummaryRollup> TbDownstreamServerClientSummaryRollup { get; set; }
        public virtual TbDownstreamServerSummaryRollup TbDownstreamServerSummaryRollup { get; set; }
        public virtual TbDownstreamServerTarget TbDownstreamServerTarget { get; set; }
        public virtual ICollection<TbExpandedTargetInTargetGroup> TbExpandedTargetInTargetGroup { get; set; }
        public virtual ICollection<TbRequestedTargetGroupsForTarget> TbRequestedTargetGroupsForTarget { get; set; }
        public virtual ICollection<TbTargetInTargetGroup> TbTargetInTargetGroup { get; set; }
        public virtual TbTargetType TargetType { get; set; }
    }
}
