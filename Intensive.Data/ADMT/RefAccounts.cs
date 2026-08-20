using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class RefAccounts
    {
        public RefAccounts()
        {
            References = new HashSet<References>();
        }

        public int AccountId { get; set; }
        public int DomainId { get; set; }
        public string Name { get; set; }
        public string Sid { get; set; }

        public virtual RefDomains Domain { get; set; }
        public virtual ICollection<References> References { get; set; }
    }
}
