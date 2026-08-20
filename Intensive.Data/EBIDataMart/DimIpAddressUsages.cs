using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIpAddressUsages
    {
        public int IpAddressUsagesKey { get; set; }
        public string IpAddressUsagesIdNk { get; set; }
        public string IpAddressUsagesName { get; set; }
        public string IpAddressUsagesDescription { get; set; }
        public DateTime IpAddressUsagesEffectiveStartDatetime { get; set; }
        public DateTime IpAddressUsagesEffectiveEndDatetime { get; set; }
        public DateTime IpAddressUsagesRecordCreatedDatetime { get; set; }
        public string IpAddressUsagesRecordCreatedBy { get; set; }
        public DateTime IpAddressUsagesRecordUpdatedDatetime { get; set; }
        public string IpAddressUsagesRecordUpdatedBy { get; set; }
        public string IpAddressUsagesSourceSystemName { get; set; }
        public int IpAddressUsagesCurrentRecordFlag { get; set; }
    }
}
