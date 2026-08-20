using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCrmOpportunity
    {
        public int OpportunityKey { get; set; }
        public string OpportunityIdNk { get; set; }
        public string OpportunityNumber { get; set; }
        public string OpportunityName { get; set; }
        public string OpportunityAccountid { get; set; }
        public string OpportunityAccountNumber { get; set; }
        public string OpportunityAccountName { get; set; }
        public string OpportunityLeadSource { get; set; }
        public string OpportunityType { get; set; }
        public string OpportunityIswon { get; set; }
        public string OpportunityIsclosed { get; set; }
        public string OpportunityDeleteFlag { get; set; }
        public string OpportunityIsdeleted { get; set; }
        public DateTime? OpportunityCloseddate { get; set; }
        public string OpportunityOwner { get; set; }
        public string OpportunityOwnerRole { get; set; }
        public string OpportunityCampaignName { get; set; }
        public decimal? OpportunityExpectedRevenue { get; set; }
        public string OpportunityCurrencyCode { get; set; }
        public string OpportunityOppType { get; set; }
        public decimal? OpportunityConfirmedAmount { get; set; }
        public string OpportunitySegmentx { get; set; }
        public string OpportunitySupportTeam { get; set; }
        public string OpportunitySupportSegment { get; set; }
        public decimal? OpportunityCurrentMrr { get; set; }
        public decimal? OpportunityNewMrr { get; set; }
        public string OpportunityApprovalReason { get; set; }
        public string OpportunityReject { get; set; }
        public DateTime? OpportunityRejectedDate { get; set; }
        public string OpportunityReason { get; set; }
        public string OpportunityReason1 { get; set; }
        public string OpportunityReason2 { get; set; }
        public string OpportunityEvaGrade { get; set; }
        public string OpportunitySalesRep { get; set; }
        public string OpportunityResolution1 { get; set; }
        public string OpportunityResolution2 { get; set; }
        public int? OpportunityFiscalquarter { get; set; }
        public int? OpportunityFiscalyear { get; set; }
        public string OpportunityFiscal { get; set; }
        public string OpportunityTerritory { get; set; }
        public string OpportunityCategory { get; set; }
        public string OpportunityPartneraccountid { get; set; }
        public string OpportunityLpid { get; set; }
        public string OpportunityLeadGenerator { get; set; }
        public string OpportunityLeadGeneratorId { get; set; }
        public string OpportunityLeadGeneratorRole { get; set; }
        public decimal? OpportunityLeadToProposalDays { get; set; }
        public string OpportunityLeadId { get; set; }
        public DateTime? OpportunityLeadDatePassed { get; set; }
        public decimal? OpportunityLeadToCloseDays { get; set; }
        public string OpportunityCreatedFromLead { get; set; }
        public decimal? OpportunityProposalToCloseDays { get; set; }
        public string OpportunityCloned { get; set; }
        public string OpportunityCloneOpportunity { get; set; }
        public DateTime? OpportunityContractStartDate { get; set; }
        public decimal? OpportunityContractLength { get; set; }
        public decimal? OpportunityApprovalAmount { get; set; }
        public string OpportunityProposal { get; set; }
        public string OpportunityNurtureReason { get; set; }
        public string OpportunitySupportOffice { get; set; }
        public string OpportunitySubType { get; set; }
        public decimal? OpportunityValuex { get; set; }
        public string OpportunityRevived { get; set; }
        public string OpportunityRevivedOpp { get; set; }
        public string OpportunityContractReceived { get; set; }
        public string OpportunityRepRating { get; set; }
        public string OpportunityCloudAccountNumber { get; set; }
        public string OpportunityQuoteType { get; set; }
        public string OpportunityFinalOpportunityType { get; set; }
        public DateTime? OpportunityLastactivitydate { get; set; }
        public DateTime? OpportunityCreateddate { get; set; }
        public string OpportunityCreatedby { get; set; }
        public DateTime? OpportunityLastmodifieddate { get; set; }
        public string OpportunityLastmodifiedby { get; set; }
        public string OpportunityDbMarketing { get; set; }
        public DateTime? OpportunityDbMarketingDate { get; set; }
        public DateTime? OpportunityLdtDatePassed { get; set; }
        public string OpportunityLdtRep { get; set; }
        public string OpportunityLdtRole { get; set; }
        public DateTime? OpportunityNurtureFollowUpDate { get; set; }
        public DateTime? OpportunityMaxDatePassed { get; set; }
        public DateTime? RecordEffectiveStartDate { get; set; }
        public DateTime? RecordEffectiveEndDate { get; set; }
        public string SourceSystemName { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public int CurrentRecord { get; set; }
    }
}
