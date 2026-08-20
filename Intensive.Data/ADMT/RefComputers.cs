using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class RefComputers
    {
        public RefComputers()
        {
            References = new HashSet<References>();
        }

        public int ComputerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<References> References { get; set; }
    }
}
