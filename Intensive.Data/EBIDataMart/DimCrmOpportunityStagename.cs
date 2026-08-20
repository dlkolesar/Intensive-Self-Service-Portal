using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCrmOpportunityStagename
    {
        public int CrmOpportunityStageKey { get; set; }
        public string CrmOpportunityStageNk { get; set; }
        public string CrmOpportunityStageName { get; set; }
        public string CrmOpportunityStageStatus { get; set; }
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
