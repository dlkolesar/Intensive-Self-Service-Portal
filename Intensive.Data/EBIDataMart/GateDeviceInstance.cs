using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class GateDeviceInstance
    {
        public int GateDeviceInstanceKey { get; set; }
        public int? DeviceKey { get; set; }
        public int? CloudInstanceKey { get; set; }
        public string RecordType { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public DateTime? ModifiedDatetime { get; set; }
    }
}
