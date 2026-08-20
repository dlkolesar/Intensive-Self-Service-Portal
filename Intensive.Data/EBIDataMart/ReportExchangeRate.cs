using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportExchangeRate
    {
        public int ReportExchangeRateId { get; set; }
        public string ExchangeRateFromCurrencyCode { get; set; }
        public string ExchangeRateFromCurrencyDescription { get; set; }
        public string ExchangeRateToCurrencyCode { get; set; }
        public string ExchangeRateToCurrencyDescription { get; set; }
        public string ExchangeRateToCurrencySymbol { get; set; }
        public int? ExchangeRateMonth { get; set; }
        public int? ExchangeRateYear { get; set; }
        public decimal? ExchangeRateExchangeRateValue { get; set; }
        public string ExchangeRateFromCurrencySymbol { get; set; }
        public string SourceSystemName { get; set; }
    }
}
