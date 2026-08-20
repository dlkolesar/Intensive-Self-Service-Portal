using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class EntityMatch
    {
        public long Id { get; set; }
        public string MatchRule { get; set; }
        public string MatchPriority { get; set; }
        public string EntityType { get; set; }
        public int? EntityNumber1 { get; set; }
        public string EntitySource1 { get; set; }
        public int? EntityNumber2 { get; set; }
        public string EntitySource2 { get; set; }
        public string Status { get; set; }
        public int? MatchOrder { get; set; }
        public DateTime? MatchTime { get; set; }
        public DateTime? DwTimestamp { get; set; }
    }
}
