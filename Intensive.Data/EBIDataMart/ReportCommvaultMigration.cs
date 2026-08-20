using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportCommvaultMigration
    {
        public int ReportCommvaultMigriationId { get; set; }
        public int ChildId { get; set; }
        public string ClientName { get; set; }
        public string DeviceNumber { get; set; }
        public string DisplayName { get; set; }
        public string InterfaceName { get; set; }
        public string Description { get; set; }
        public string CommCell { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
