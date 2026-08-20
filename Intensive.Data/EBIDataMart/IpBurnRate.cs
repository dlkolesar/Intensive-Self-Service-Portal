using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class IpBurnRate
    {
        public int Recid { get; set; }
        public int? TotalIpsAssignedToDc { get; set; }
        public int? TotalIpsAssigned { get; set; }
        public int? TotalIpsAvaliable { get; set; }
        public decimal? PercentOfTotalIpsUsed { get; set; }
        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }
}
