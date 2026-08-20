using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbManagedSystems
    {
        public int SystemId { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public string ManagerSso { get; set; }
        public string PrimaryOwner { get; set; }
        public string PrimaryOwnerSso { get; set; }
        public string SecondaryOwner { get; set; }
        public string SecondaryOwnerSso { get; set; }
        public string Config { get; set; }
    }
}
