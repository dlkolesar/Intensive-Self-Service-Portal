using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class Domains
    {
        public Domains()
        {
            Objects = new HashSet<Objects>();
        }

        public Guid DomainId { get; set; }
        public string Guid { get; set; }
        public string Sid { get; set; }
        public string DnsName { get; set; }
        public string FlatName { get; set; }

        public virtual ICollection<Objects> Objects { get; set; }
    }
}
