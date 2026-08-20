using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentSeverity
    {
        public int IncidentSeverityKey { get; set; }
        public string IncidentSeverityNk { get; set; }
        public string IncidentSeverityName { get; set; }
        public string IncidentSeverityDescription { get; set; }
        public DateTime IncidentSeverityEffectiveStartDatetime { get; set; }
        public DateTime IncidentSeverityEffectiveEndDatetime { get; set; }
        public DateTime IncidentSeverityRecordCreatedDatetime { get; set; }
        public string IncidentSeverityRecordCreatedBy { get; set; }
        public DateTime IncidentSeverityRecordUpdatedDatetime { get; set; }
        public string IncidentSeverityRecordUpdatedBy { get; set; }
        public string IncidentSeveritySourceSystemName { get; set; }
        public int IncidentSeverityCurrentRecordFlag { get; set; }
    }
}
