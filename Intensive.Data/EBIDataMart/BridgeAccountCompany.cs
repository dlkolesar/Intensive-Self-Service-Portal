using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class BridgeAccountCompany
    {
        public long BridgeAccountCompanyKey { get; set; }
        public long? AccountKey { get; set; }
        public long? CompanyKey { get; set; }
        public long TeamKey { get; set; }
        public string BridgeSsk { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public int CurrentRecord { get; set; }
        public DateTime DwTimestamp { get; set; }
    }
}
