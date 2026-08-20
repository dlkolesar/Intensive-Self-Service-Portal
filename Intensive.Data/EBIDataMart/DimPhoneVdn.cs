using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimPhoneVdn
    {
        public int PhoneVdnKey { get; set; }
        public string PhoneVdnNk { get; set; }
        public string PhoneVdnName { get; set; }
        public string PhoneVdnDescription { get; set; }
        public DateTime? PhoneVdnEffectiveStartDate { get; set; }
        public DateTime? PhoneVdnEffectiveEndDate { get; set; }
        public DateTime? PhoneVdnRecordCreatedDatetime { get; set; }
        public string PhoneVdnRecordCreatedBy { get; set; }
        public DateTime? PhoneVdnRecordUpdatedDatetime { get; set; }
        public string PhoneVdnRecordUpdatedBy { get; set; }
        public string PhoneVdnSourceSystemName { get; set; }
        public int CurrentRecord { get; set; }
    }
}
