using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDatacenter
    {
        public int DatacenterKey { get; set; }
        public int? DatacenterNumber { get; set; }
        public string DatacenterName { get; set; }
        public string DatacenterCity { get; set; }
        public string DatacenterState { get; set; }
        public string DatacenterCountry { get; set; }
        public string DatacenterAbbr { get; set; }
        public int? DatacenterNtwkValWanconnectionId { get; set; }
        public int? DatacenterUnitCapacity { get; set; }
        public decimal? DatacenterRentCost { get; set; }
        public decimal? DatacenterRentCostPerUnit { get; set; }
        public DateTime? DatacenterRecordCreatedDatetime { get; set; }
        public string DatacenterRecordCreatedBy { get; set; }
        public DateTime? DatacenterRecordUpdatedDatetime { get; set; }
        public string DatacenterRecordUpdatedBy { get; set; }
        public string DatacenterSourceSystemName { get; set; }
        public byte DatacenterCurrentRecordFlag { get; set; }
        public DateTime? DatacenterRecordEffectiveStartDatetime { get; set; }
        public DateTime? DatacenterRecordEffectiveEndDatetime { get; set; }
    }
}
