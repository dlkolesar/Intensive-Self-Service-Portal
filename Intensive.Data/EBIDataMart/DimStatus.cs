using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimStatus
    {
        public DimStatus()
        {
            FactAccountStatus = new HashSet<FactAccountStatus>();
        }

        public int StatusKey { get; set; }
        public string StatusTypeNk { get; set; }
        public string StatusNk { get; set; }
        public string StatusShortDescription { get; set; }
        public string StatusLongDescription { get; set; }
        public int StatusOpenFlag { get; set; }
        public DateTime StatusEffectiveStartDate { get; set; }
        public DateTime StatusEffectiveEndDate { get; set; }
        public DateTime StatusRecordCreatedDatetime { get; set; }
        public string StatusRecordCreatedBy { get; set; }
        public DateTime StatusRecordUpdatedDatetime { get; set; }
        public string StatusRecordUpdatedBy { get; set; }
        public string StatusSourceSystemName { get; set; }
        public byte StatusCurrentRecordFlag { get; set; }
        public int? StatusRank { get; set; }
        public string StatusActive { get; set; }
        public string StatusOnline { get; set; }

        public virtual ICollection<FactAccountStatus> FactAccountStatus { get; set; }
    }
}
