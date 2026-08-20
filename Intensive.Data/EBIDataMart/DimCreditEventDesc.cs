using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCreditEventDesc
    {
        public int CreditEventDescKey { get; set; }
        public int CreditEventNk { get; set; }
        public string CreditEventDescription { get; set; }
        public DateTime? CreditEventDescEffectiveStartDate { get; set; }
        public DateTime? CreditEventDescEffectiveEndDate { get; set; }
        public DateTime? RecordCreatedDate { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime? RecordUpdatedDate { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int CurrentRecord { get; set; }
    }
}
