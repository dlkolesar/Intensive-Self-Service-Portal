using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimRevenueSetOfBooks
    {
        public int RevenueSetOfBooksKey { get; set; }
        public string SetOfBooksNk { get; set; }
        public string RevenueSetOfBooksId { get; set; }
        public string SetOfBooksName { get; set; }
        public string SetOfBooksShortName { get; set; }
        public string SetOfBooksChartOfAccountsId { get; set; }
        public string SetOfBooksCurrencyCode { get; set; }
        public string SetOfBooksPeriodSetName { get; set; }
        public DateTime? SetOfBooksCreationDate { get; set; }
        public DateTime? SetOfBooksLastUpdateDate { get; set; }
        public string SetOfBooksLatestOpenedPeriodName { get; set; }
        public string GlPeriodName { get; set; }
        public string GlPeriodClosingStatus { get; set; }
        public DateTime? GlPeriodStartDate { get; set; }
        public DateTime? GlPeriodEndDate { get; set; }
        public DateTime? GlPeriodYearStartDate { get; set; }
        public int? GlPeriodQuarterNum { get; set; }
        public DateTime? GlPeriodQuarterStartDate { get; set; }
        public string GlPeriodType { get; set; }
        public int? GlPeriodYear { get; set; }
        public int? GlPeriodEffectivePeriodNum { get; set; }
        public int? GlPeriodNum { get; set; }
        public DateTime? GlPeriodCreationDate { get; set; }
        public DateTime? GlPeriodLastUpdateDate { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationShortName { get; set; }
        public string ApplicationBasepath { get; set; }
        public string ApplicationProductCode { get; set; }
        public DateTime? ApplicationCreationDate { get; set; }
        public DateTime? ApplicationLastUpdateDate { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUdpatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string RecordSourceSystem { get; set; }
        public int CurrentRecord { get; set; }
    }
}
