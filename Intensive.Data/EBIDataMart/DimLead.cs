using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimLead
    {
        public long LeadKey { get; set; }
        public string LeadId { get; set; }
        public string LeadSfId { get; set; }
        public string LeadCompany { get; set; }
        public string LeadName { get; set; }
        public string LeadType { get; set; }
        public string LeadSource { get; set; }
        public DateTime? LeadCreatedDate { get; set; }
        public DateTime? LeadCreatedDateUtc { get; set; }
        public string LeadOrigination { get; set; }
        public string LeadBucket { get; set; }
        public string LeadCommissionsRole { get; set; }
        public string LeadConvertedAccountId { get; set; }
        public string LeadConvertedContactId { get; set; }
        public string LeadConvertedOpportunityId { get; set; }
        public string LeadIsConvertedFlag { get; set; }
        public DateTime? LeadConvertedDate { get; set; }
        public DateTime? LeadConvertedDateUtc { get; set; }
        public string LeadTsrSpecialist { get; set; }
        public string LeadSalesAssociate { get; set; }
        public string LeadStreet { get; set; }
        public string LeadCity { get; set; }
        public string LeadState { get; set; }
        public string LeadPostalcode { get; set; }
        public string LeadCountry { get; set; }
        public string LeadTerritory { get; set; }
        public string LeadIteamPersona { get; set; }
        public string LeadFinalOpportunityType { get; set; }
        public string LeadReferrerContractType { get; set; }
        public string LeadPartnerAccountNum { get; set; }
        public string LeadDeletedFlag { get; set; }
        public string LeadCreatedFromLeadFlag { get; set; }
        public string LeadCurrentCustomerFlag { get; set; }
        public string LeadSolutionArea { get; set; }
        public string LeadSolutionAreaWorkload { get; set; }
        public string LeadRecordCreatedBy { get; set; }
        public DateTime? LeadRecordCreatedDatetime { get; set; }
        public string LeadRecordUpdatedBy { get; set; }
        public DateTime? LeadRecordUpdatedDatetime { get; set; }
        public string LeadSourceSystemName { get; set; }
        public short? LeadCurrentRecord { get; set; }
        public string LeadLpid { get; set; }
        public string LeadCampaignInterest { get; set; }
    }
}
