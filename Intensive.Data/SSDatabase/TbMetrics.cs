using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbMetrics
    {
        public int Id { get; set; }
        public string MetricKey { get; set; }
        public int MetricValue { get; set; }
        public DateTime MetricDate { get; set; }
    }
}
