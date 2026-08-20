using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSfCurrencyConversion
    {
        public int CurrencyKey { get; set; }
        public string CurrencyDeleteFlag { get; set; }
        public string CurrencyFromIsocode { get; set; }
        public string CurrencyToIsocode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextStartDate { get; set; }
        public decimal ConversionRate { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordCreatedDatetimeCst { get; set; }
        public DateTime RecordCreatedDatetimeUtc { get; set; }
        public string RecordUpdatedBy { get; set; }
        public DateTime RecordUpdatedDatetimeCst { get; set; }
        public DateTime RecordUpdatedDatetimeUtc { get; set; }
        public string SourceSystemName { get; set; }
    }
}
