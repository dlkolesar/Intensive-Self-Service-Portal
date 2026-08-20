using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbInventoryPropertyInstance
    {
        public int ClassInstanceId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }

        public virtual TbInventoryClassInstance ClassInstance { get; set; }
        public virtual TbInventoryProperty Property { get; set; }
    }
}
