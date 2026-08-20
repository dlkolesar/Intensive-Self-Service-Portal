using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentSource
    {
        public int IncidentSourceKey { get; set; }
        public string IncidentSourceIdNk { get; set; }
        public string IncidentSourceName { get; set; }
        public string IncidentSourceDescription { get; set; }
        public DateTime IncidentSourceEffectiveStartDatetime { get; set; }
        public DateTime IncidentSourceEffectiveEndDatetime { get; set; }
        public DateTime IncidentSourceRecordCreatedDatetime { get; set; }
        public string IncidentSourceRecordCreatedBy { get; set; }
        public DateTime IncidentSourceRecordUpdatedDatetime { get; set; }
        public string IncidentSourceRecordUpdatedBy { get; set; }
        public string IncidentSourceSourceSystemName { get; set; }
        public int IncidentSourceCurrentRecordFlag { get; set; }
    }
}
