using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimChurnReasonDetailBridge
    {
        public int ChurnBridgeKey { get; set; }
        public string ChurnBridgeNk { get; set; }
        public int? ChurnBridgeParentKey { get; set; }
        public int? ChurnBridgeChildKey { get; set; }
        public int? ChurnBridgeLevel { get; set; }
        public int? ChurnBridgeIsTop { get; set; }
        public int? ChurnBridgeIsBottom { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public int? CurrentRecord { get; set; }
    }
}
