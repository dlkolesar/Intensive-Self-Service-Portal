using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimLeadExtended
    {
        public long LeadExtendedKey { get; set; }
        public long LeadKey { get; set; }
        public string LeadId { get; set; }
        public string LeadGeneratorId { get; set; }
        public string LeadGeneratorName { get; set; }
        public string LeadGeneratorRoleId { get; set; }
        public string LeadGeneratorRoleDesc { get; set; }
        public string LeadOwnerId { get; set; }
        public string LeadOwnerName { get; set; }
        public string LeadOwnerRole { get; set; }
        public string LeadOwnerRoleId { get; set; }
        public string LeadPartnerId { get; set; }
        public string LeadPartnerName { get; set; }
        public string LeadStatus { get; set; }
        public string LeadRepId { get; set; }
        public string LeadRepName { get; set; }
        public string LeadRepRoleId { get; set; }
        public string LeadRepRoleDesc { get; set; }
        public DateTime? LeadRepDatePassed { get; set; }
        public DateTime? LeadRepDatePassedUtc { get; set; }
        public DateTime? LeadDatePassed { get; set; }
        public DateTime? LeadDatePassedUtc { get; set; }
        public int? LeadCurrentRecord { get; set; }
        public DateTime? LeadEffectiveStartDate { get; set; }
        public DateTime? LeadEffectiveStartDateUtc { get; set; }
        public DateTime? LeadEffectiveEndDate { get; set; }
        public DateTime? LeadEffectiveEndDateUtc { get; set; }
        public string LeadRecordCreatedBy { get; set; }
        public DateTime? LeadRecordCreatedDatetime { get; set; }
        public string LeadRecordUpdatedBy { get; set; }
        public DateTime? LeadRecordUpdatedDatetime { get; set; }
        public string ChkSumNbr { get; set; }
        public string LeadFieldNames { get; set; }
        public string LeadSourceSystemName { get; set; }
        public string LeadInsUpdFlg { get; set; }
    }
}
