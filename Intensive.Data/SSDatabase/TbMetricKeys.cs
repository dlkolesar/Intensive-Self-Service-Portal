using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbMetricKeys
    {
        public int Id { get; set; }
        public string MetricKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SystemId { get; set; }
    }
}
