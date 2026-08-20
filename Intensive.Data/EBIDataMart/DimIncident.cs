using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncident
    {
        public int IncidentKey { get; set; }
        public string IncidentIdNk { get; set; }
        public string IncidentReferenceNumber { get; set; }
        public string IncidentSubject { get; set; }
        public string IncidentCreatedMethod { get; set; }
        public DateTime IncidentEffectiveStartDatetime { get; set; }
        public DateTime IncidentEffectiveEndDatetime { get; set; }
        public DateTime IncidentRecordCreatedDatetime { get; set; }
        public string IncidentRecordCreatedBy { get; set; }
        public DateTime IncidentRecordUdatedDatetime { get; set; }
        public string IncidentRecordUpdatedBy { get; set; }
        public string IncidentSourceSystemName { get; set; }
        public int IncidentCurrentRecordFlag { get; set; }
        public int IncidentPrivateFlag { get; set; }
        public int IncidentSosFlag { get; set; }
        public string IncidentCreatorName { get; set; }
        public string IncidentSubmitterName { get; set; }
        public int IncidentEotr { get; set; }
    }
}
