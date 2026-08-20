using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentMessageType
    {
        public int IncidentMessageTypeKey { get; set; }
        public string IncidentMessageTypeIdNk { get; set; }
        public string IncidentMessageTypeName { get; set; }
        public DateTime IncidentMessageTypeEffectiveStartDatetime { get; set; }
        public DateTime IncidentMessageTypeEffectiveEndDatetime { get; set; }
        public DateTime IncidentMessageTypeRecordCreatedDatetime { get; set; }
        public string IncidentMessageTypeRecordCreatedBy { get; set; }
        public DateTime IncidentMessageTypeRecordUdatedDatetime { get; set; }
        public string IncidentMessageTypeRecordUpdatedBy { get; set; }
        public string IncidentMessageTypeSourceSystemName { get; set; }
        public int IncidentMessageTypeCurrentRecordFlag { get; set; }
    }
}
