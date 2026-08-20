using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbInventoryProperty
    {
        public TbInventoryProperty()
        {
            TbInventoryPropertyInstance = new HashSet<TbInventoryPropertyInstance>();
        }

        public int PropertyId { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TbInventoryPropertyInstance> TbInventoryPropertyInstance { get; set; }
        public virtual TbInventoryClass Class { get; set; }
    }
}
