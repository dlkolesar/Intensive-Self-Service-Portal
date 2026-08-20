using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimManagedExchangeDomain
    {
        public int ManagedExchangeDomainKey { get; set; }
        public string ManagedExchangeDomainName { get; set; }
        public DateTime ManagedExchangeDomainEffectiveStartDatetime { get; set; }
        public DateTime ManagedExchangeDomainEffectiveEndDatetime { get; set; }
        public DateTime ManagedExchangeDomainRecordCreatedDatetime { get; set; }
        public string ManagedExchangeDomainCreatedBy { get; set; }
        public DateTime ManagedExchangeDomainRecordUpdatedDatetime { get; set; }
        public string ManagedExchangeDomainRecordUpdatedBy { get; set; }
        public string ManagedExchangeDomainSourceSystemName { get; set; }
        public byte ManagedExchangeDomainCurrentRecordFlag { get; set; }
    }
}
