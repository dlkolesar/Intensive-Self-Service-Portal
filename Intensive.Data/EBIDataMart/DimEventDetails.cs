using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimEventDetails
    {
        public int EventKey { get; set; }
        public string EventSsk { get; set; }
        public string EventType { get; set; }
        public string ServiceType { get; set; }
        public string ItemType { get; set; }
        public string EventRumName { get; set; }
        public string EventSysDescr { get; set; }
        public string ImpactCategory { get; set; }
        public decimal? ImpactType { get; set; }
        public string ImpactRateTag { get; set; }
        public decimal? ImpactRumId { get; set; }
        public string EventProductType { get; set; }
        public decimal? ImpactCurrencyId { get; set; }
        public string ImpactCurrencyAbbrev { get; set; }
        public string EventRegionId { get; set; }
        public string EventDcId { get; set; }
        public string RumMapRecId { get; set; }
        public string EventManagedFlag { get; set; }
        public string EventName { get; set; }
        public string TaxName { get; set; }
        public decimal? TaxTypeId { get; set; }
        public decimal? TaxElementId { get; set; }
        public double? TaxRatePercent { get; set; }
        public decimal? EventEarnedType { get; set; }
        public decimal? EventFlags { get; set; }
        public string EventGroupType { get; set; }
        public string ImpactBalGrpType { get; set; }
        public string ImpactTaxCode { get; set; }
        public string ImpactOfferingType { get; set; }
        public DateTime RecCreatedDate { get; set; }
        public string SourceSystemName { get; set; }
    }
}
