using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbAricProcess
    {
        public string ProcessName { get; set; }
        public int SystemId { get; set; }
        public string DisplayName { get; set; }
        public string Source { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
        public bool InternalOnly { get; set; }
    }
}
