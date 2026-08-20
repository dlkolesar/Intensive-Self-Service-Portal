using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEventRollupCounters
    {
        public int Id { get; set; }
        public DateTime? LatestRollupTime { get; set; }
        public int? LatestRollupCount { get; set; }
        public byte? LatestRollupState { get; set; }
        public int? CurrentRollupTotal { get; set; }
        public int? CurrentRollupDone { get; set; }
        public byte? CurrentRollupState { get; set; }
    }
}
