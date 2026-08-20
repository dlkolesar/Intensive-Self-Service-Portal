using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIpAddressAutonomousSystems
    {
        public int IpAddressAutonomousSystemsKey { get; set; }
        public string IpAddressAutonomousSystemsIdNk { get; set; }
        public string IpAddressAutonomousSystemsName { get; set; }
        public int IpAddressAutonomousSystemsNumber { get; set; }
        public string IpAddressAutonomousSystemsDescription { get; set; }
        public short IpAddressAutonomousSystemsRackspaceOwned { get; set; }
        public DateTime IpAddressAutonomousSystemsEffectiveStartDatetime { get; set; }
        public DateTime IpAddressAutonomousSystemsEffectiveEndDatetime { get; set; }
        public DateTime IpAddressAutonomousSystemsRecordCreatedDatetime { get; set; }
        public string IpAddressAutonomousSystemsRecordCreatedBy { get; set; }
        public DateTime IpAddressAutonomousSystemsRecordUpdatedDatetime { get; set; }
        public string IpAddressAutonomousSystemsRecordUpdatedBy { get; set; }
        public string IpAddressAutonomousSystemsSourceSystemName { get; set; }
        public int IpAddressAutonomousSystemsCurrentRecordFlag { get; set; }
        public int? NumberOfIpAddresses { get; set; }
    }
}
