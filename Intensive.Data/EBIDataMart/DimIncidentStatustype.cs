using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentStatustype
    {
        public int IncidentStatusTypeKey { get; set; }
        public string IncidentStatusTypeIdNk { get; set; }
        public string IncidentStatusTypeName { get; set; }
        public string IncidentStatusTypeDescription { get; set; }
        public DateTime IncidentStatusTypeEffectiveStartDatetime { get; set; }
        public DateTime IncidentStatusTypeEffectiveEndDatetime { get; set; }
        public DateTime IncidentStatusTypeRecordCreatedDatetime { get; set; }
        public string IncidentStatusTypeRecordCreatedBy { get; set; }
        public DateTime IncidentStatusTypeRecordUpdatedDatetime { get; set; }
        public string IncidentStatusTypeRecordUpdatedBy { get; set; }
        public string IncidentStatusTypeSourceSystemName { get; set; }
        public int IncidentStatusTypeCurrentRecordFlag { get; set; }
    }
}
