using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCrmLead
    {
        public int LeadKey { get; set; }
        public string LeadIdNk { get; set; }
        public string LeadDeletedFlag { get; set; }
        public string LeadIsdeleted { get; set; }
        public string LeadNamex { get; set; }
        public string LeadCompany { get; set; }
        public string LeadEmail { get; set; }
        public string LeadSource { get; set; }
        public string LeadRating { get; set; }
        public string LeadOwner { get; set; }
        public string LeadLeadType { get; set; }
        public DateTime? LeadProjectedCloseDate { get; set; }
        public string LeadTerritory { get; set; }
        public string LeadLead { get; set; }
        public string LeadCreatedFromLead { get; set; }
        public string LeadSalesRep { get; set; }
        public string LeadLeadGeneratorRole { get; set; }
        public string LeadLpid { get; set; }
        public string LeadLeadGenerator { get; set; }
        public string LeadIsconverted { get; set; }
        public DateTime? LeadConverteddate { get; set; }
        public string LeadConvertedaccountid { get; set; }
        public string LeadConvertedaccountNumber { get; set; }
        public string LeadConvertedcontactid { get; set; }
        public string LeadConvertedcontactName { get; set; }
        public string LeadConvertedopportunityid { get; set; }
        public DateTime? LeadCreateddate { get; set; }
        public string LeadCreatedby { get; set; }
        public DateTime? LeadLastmodifieddate { get; set; }
        public string LeadLastmodifiedby { get; set; }
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
