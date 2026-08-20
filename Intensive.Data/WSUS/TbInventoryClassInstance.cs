using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbInventoryClassInstance
    {
        public TbInventoryClassInstance()
        {
            TbInventoryPropertyInstance = new HashSet<TbInventoryPropertyInstance>();
        }

        public int ClassInstanceId { get; set; }
        public int ClassId { get; set; }
        public int TargetId { get; set; }
        public string KeyValue { get; set; }

        public virtual ICollection<TbInventoryPropertyInstance> TbInventoryPropertyInstance { get; set; }
        public virtual TbInventoryClass Class { get; set; }
        public virtual TbComputerTarget Target { get; set; }
    }
}
