using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbInventoryClass
    {
        public TbInventoryClass()
        {
            TbInventoryClassInstance = new HashSet<TbInventoryClassInstance>();
            TbInventoryProperty = new HashSet<TbInventoryProperty>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TbInventoryClassInstance> TbInventoryClassInstance { get; set; }
        public virtual ICollection<TbInventoryProperty> TbInventoryProperty { get; set; }
    }
}
