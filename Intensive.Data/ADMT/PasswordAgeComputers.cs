using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class PasswordAgeComputers
    {
        public string Name { get; set; }
        public int DomainId { get; set; }
        public string Description { get; set; }
        public int PasswordAge { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual PasswordAgeDomains Domain { get; set; }
    }
}
