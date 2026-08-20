using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactAccountDevice
    {
        public int TimeKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int DeviceKey { get; set; }
        public int MeasureRecordCount { get; set; }
        public int TimeMonthKey { get; set; }
    }
}
