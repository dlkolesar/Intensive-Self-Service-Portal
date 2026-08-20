using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDriverClass
    {
        public TbDriverClass()
        {
            TbDriver = new HashSet<TbDriver>();
        }

        public int ClassId { get; set; }
        public string Class { get; set; }

        public virtual ICollection<TbDriver> TbDriver { get; set; }
    }
}
