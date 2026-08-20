using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportSoxManagedVirtSummary
    {
        public int Id { get; set; }
        public DateTime RecTimestamp { get; set; }
        public string Datacenter { get; set; }
        public string ReconciliationType { get; set; }
        public string RecDeviceType { get; set; }
        public string RecSourceSystem { get; set; }
        public int SourceSystemCount { get; set; }
        public string RecTargetSystem { get; set; }
        public int TargetSystemCount { get; set; }
        public int Difference { get; set; }
        public double DifferenceAsPcOfSource { get; set; }
        public string Result { get; set; }
    }
}
