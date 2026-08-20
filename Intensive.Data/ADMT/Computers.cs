using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class Computers
    {
        public Computers()
        {
            DistributedTasks = new HashSet<DistributedTasks>();
            Services = new HashSet<Services>();
        }

        public int ComputerId { get; set; }
        public string Name { get; set; }
        public string DnsName { get; set; }
        public string FlatName { get; set; }

        public virtual ICollection<DistributedTasks> DistributedTasks { get; set; }
        public virtual ICollection<Services> Services { get; set; }
    }
}
