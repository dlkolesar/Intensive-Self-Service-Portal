using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentWorktype
    {
        public int IncidentWorkTypeKey { get; set; }
        public string IncidentWorkTypeIdNk { get; set; }
        public string IncidentWorkTypeName { get; set; }
        public string IncidentWorkTypeDescription { get; set; }
        public string IncidentWorkTypeActive { get; set; }
        public DateTime IncidentWorkTypeEffectiveStartDatetime { get; set; }
        public DateTime IncidentWorkTypeEffectiveEndDatetime { get; set; }
        public DateTime IncidentWorkTypeRecordCreatedDatetime { get; set; }
        public string IncidentWorkTypeRecordCreatedBy { get; set; }
        public DateTime IncidentWorkTypeRecordUpdatedDatetime { get; set; }
        public string IncidentWorkTypeRecordUpdatedBy { get; set; }
        public string IncidentWorkTypeSourceSystemName { get; set; }
        public int IncidentWorkTypeCurrentRecordFlag { get; set; }
    }
}
