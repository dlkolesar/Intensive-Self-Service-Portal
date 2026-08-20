using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimProduct
    {
        public int ProductKey { get; set; }
        public string ProductResourceCodeNk { get; set; }
        public DateTime ProductEffectiveStartDatetime { get; set; }
        public DateTime ProductEffectiveEndDatetime { get; set; }
        public DateTime ProductRecordCreatedDatetime { get; set; }
        public string ProductRecordCreatedBy { get; set; }
        public DateTime ProductRecordUpdatedDatetime { get; set; }
        public string ProductRecordUpdatedBy { get; set; }
        public string ProductRecordSourceSystemName { get; set; }
        public byte ProductCurrentRecordFlag { get; set; }
        public string ProductName { get; set; }
        public string ProductResourceCodeSpecialPrice { get; set; }
        public string ProductUnitOfMeasure { get; set; }
        public string ProductGroup { get; set; }
        public string ProductType { get; set; }
        public int? ProductResourceBillingTypeCode { get; set; }
        public int? ProductResourceTieredFlag { get; set; }
        public int? ProductResourceGlRevenueAccount { get; set; }
        public int? ProductResourceCodeStartRange { get; set; }
        public int? ProductResourceCodeEndRange { get; set; }
        public long? ProductSettingStartRange { get; set; }
        public long? ProductSettingEndRange { get; set; }
        public string ProductResourceCode { get; set; }
    }
}
