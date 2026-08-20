using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class Services
    {
        public int ComputerId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Account { get; set; }
        public int Status { get; set; }

        public virtual Computers Computer { get; set; }
    }
}
