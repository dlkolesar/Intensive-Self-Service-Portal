using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimOpportunity
    {
        public long OpportunityKey { get; set; }
        public string OpportunityId { get; set; }
        public string OpportunitySalesforceId { get; set; }
        public string OpportunityName { get; set; }
        public string OpportunityCurrencyCode { get; set; }
        public decimal? OpportunityExpectedRevenue { get; set; }
        public DateTime? OpportunityCreatedDate { get; set; }
        public DateTime? OpportunityCreatedDateUtc { get; set; }
        public string OpportunityNextStep { get; set; }
        public decimal? OpportunityProbability { get; set; }
        public string OpportunityType { get; set; }
        public string OpportunityAccountId { get; set; }
        public string OpportunityLeadId { get; set; }
        public string OpportunityCampaignId { get; set; }
        public string OpportunityCampaignName { get; set; }
        public string OpportunityCampaignType { get; set; }
        public string Ddi { get; set; }
        public string OpportunityBucket { get; set; }
        public string OpportunityCategory { get; set; }
        public string OpportunityLiveCall { get; set; }
        public string OpportunityClone { get; set; }
        public string OpportunitySplitCategory { get; set; }
        public decimal? OpportunitySplitCategoryPercentage { get; set; }
        public string OpportunityDeletedFlag { get; set; }
        public string OpportunityOnDemandReconciled { get; set; }
        public string OpportunityContractType { get; set; }
        public string OpportunityCreatedFromLead { get; set; }
        public decimal? OpportunityAgeDays { get; set; }
        public decimal? OpportunityBooking { get; set; }
        public string OpportunitySalesInvolvement { get; set; }
        public string OpportunitySolutionArea { get; set; }
        public string OpportunitySolutionAreaWorkload { get; set; }
        public string OpportunityCommissionRole { get; set; }
        public string OpportunityRecordCreatedBy { get; set; }
        public DateTime? OpportunityRecordCreatedDatetime { get; set; }
        public string OpportunityRecordUpdatedBy { get; set; }
        public DateTime? OpportunityRecordUpdatedDatetime { get; set; }
        public string OpportunitySourceSystemName { get; set; }
        public short? OpportunityCurrentRecord { get; set; }
        public string OpportunityAccountName { get; set; }
        public string OpportunityPlatformSubCategory { get; set; }
        public string OpportunityPlatform { get; set; }
        public string LeadOrigination { get; set; }
        public string OpportunityIsTopOpp { get; set; }
        public string OpportunityCvpVerified { get; set; }
        public string OpportunityMarketSector { get; set; }
        public string OpportunityDebookType { get; set; }
        public DateTime? OpportunityDebookDate { get; set; }
        public string OpportunityNewton { get; set; }
        public string OpportunityResolution1 { get; set; }
        public string OpportunityResolution2 { get; set; }
        public string OpportunityInvalidContract { get; set; }
        public decimal? OpportunityNutcaseDealProbability { get; set; }
        public string OpportunityRequestedProducts { get; set; }
        public string OpportunityBucketSource { get; set; }
        public string OpportunityWorkloadField { get; set; }
        public decimal? OpportunityDebookAmount { get; set; }
        public string OpportunityQuoteId { get; set; }
        public string OpportunityIsWon { get; set; }
        public string OpportunityIsClosed { get; set; }
        public string OpportunityAccountSalesforceId { get; set; }
        public string OpportunityAccountType { get; set; }
        public string OpportunityAccountSubType { get; set; }
        public decimal? OpportunityCloudRevenueForecast { get; set; }
        public decimal? OpportunityOtherUtilityFee { get; set; }
        public string OpportunityOverlayProducts { get; set; }
        public string OpportunityUpside { get; set; }
        public string OpportunityFocusArea { get; set; }
    }
}
