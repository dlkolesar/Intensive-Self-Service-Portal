using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbUpdateType
    {
        public TbUpdateType()
        {
            TbUpdate = new HashSet<TbUpdate>();
        }

        public Guid UpdateTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TbUpdate> TbUpdate { get; set; }
    }
}
