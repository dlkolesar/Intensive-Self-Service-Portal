using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbTargetType
    {
        public TbTargetType()
        {
            TbTarget = new HashSet<TbTarget>();
        }

        public int TargetTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TbTarget> TbTarget { get; set; }
    }
}
