using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class RefDomains
    {
        public RefDomains()
        {
            RefAccounts = new HashSet<RefAccounts>();
        }

        public int DomainId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RefAccounts> RefAccounts { get; set; }
    }
}
