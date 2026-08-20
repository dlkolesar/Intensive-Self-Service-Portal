using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIpAddressO2o
    {
        public int IpAddressKey { get; set; }
        public string IpAddressNk { get; set; }
        public string IpAddress { get; set; }
        public DateTime EffectiveStartDatetime { get; set; }
        public DateTime EffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string IpAddressSourceSystemName { get; set; }
        public byte CurrentRecordFlag { get; set; }
        public string IpAddressPublicPrivate { get; set; }
        public string IpAddressIsPrimary { get; set; }
        public byte? IpAddressIsAssigned { get; set; }
        public byte? IpAddressIsFailover { get; set; }
    }
}
