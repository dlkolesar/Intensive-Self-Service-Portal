using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class PasswordAgeDomains
    {
        public PasswordAgeDomains()
        {
            PasswordAgeComputers = new HashSet<PasswordAgeComputers>();
        }

        public int DomainId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PasswordAgeComputers> PasswordAgeComputers { get; set; }
    }
}
