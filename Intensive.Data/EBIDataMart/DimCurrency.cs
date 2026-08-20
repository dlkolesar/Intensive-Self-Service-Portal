using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCurrency
    {
        public int CurrencyKey { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyDescription { get; set; }
        public int CurrencyIsoNumericCode { get; set; }
        public string CurrencyRecordType { get; set; }
        public DateTime CurrencyRecordCreatedDatetime { get; set; }
        public string CurrencyRecordCreatedBy { get; set; }
        public DateTime CurrencyRecordUpdatedDatetime { get; set; }
        public string CurrencyRecordUpdatedBy { get; set; }
    }
}
