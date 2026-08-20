using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIpBlock
    {
        public int IpBlockKey { get; set; }
        public string IpBlockCidrAddress { get; set; }
        public string IpBlockAddress { get; set; }
        public int? IpBlockCidrMask { get; set; }
        public long? NumberOfIpAddresses { get; set; }
        public int? IpBlockNk { get; set; }
        public int? CurrentRecordFlag { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public DateTime? RecordCreatedDatetime { get; set; }
        public DateTime? RecordUpdatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string IpBlockType { get; set; }
        public string IpBlockAutonomusSystemName { get; set; }
        public string IpBlockPolicy { get; set; }
        public int? IsAutonomusSystem { get; set; }
        public int? ParentId { get; set; }
        public int? RootId { get; set; }
        public int? IsActive { get; set; }
        public long? AccountNumber { get; set; }
        public string AccountSourceSystemName { get; set; }
    }
}
