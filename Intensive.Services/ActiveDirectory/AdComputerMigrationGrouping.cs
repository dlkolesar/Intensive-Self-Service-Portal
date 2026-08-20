using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.ActiveDirectory
{
    public class AdComputerMigrationGrouping
    {
        public string  Datacenter { get; set; }
        public string Domain { get; set; }
        public List<AdObject> Computers { get; set; }
    }
}
