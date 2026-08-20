using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentStatus
    {
        public int IncidentStatusId { get; set; }
        public string IncidentStatusIdNk { get; set; }
        public string IncidentStatusQueueName { get; set; }
        public string IncidentStatusName { get; set; }
        public string IncidentStatusDescription { get; set; }
        public int IncidentStatusActiveFlag { get; set; }
        public DateTime IncidentStatusEffectiveStartDatetime { get; set; }
        public DateTime IncidentStatusEffectiveEndDatetime { get; set; }
        public DateTime IncidentStatusRecordCreatedDatetime { get; set; }
        public string IncidentStatusRecordCreatedBy { get; set; }
        public DateTime IncidentStatusRecordUpdatedDatetime { get; set; }
        public string IncidentStatusRecordUpdatedBy { get; set; }
        public string IncidentStatusSourceSystemName { get; set; }
        public int IncidentStatusCurrentRecordFlag { get; set; }
    }
}
