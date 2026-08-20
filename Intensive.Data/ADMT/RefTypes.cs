using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class RefTypes
    {
        public RefTypes()
        {
            References = new HashSet<References>();
        }

        public int TypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<References> References { get; set; }
    }
}
