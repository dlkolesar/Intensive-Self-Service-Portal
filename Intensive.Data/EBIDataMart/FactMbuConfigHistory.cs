using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactMbuConfigHistory
    {
        public int MbuConfigHistoryKey { get; set; }
        public int MbuConfigKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int DeviceKey { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public short MbuConfigCnt { get; set; }
        public byte CurrentRecordFlg { get; set; }
        public DateTime RecAddedDttm { get; set; }
        public DateTime RecUpdatedDttm { get; set; }
        public string MbuConfigHistorySourceSystemName { get; set; }
        public int? MbuExclusionsKey { get; set; }
    }
}
