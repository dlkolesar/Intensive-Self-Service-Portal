using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimAlertType
    {
        public int AlertTypeKey { get; set; }
        public string AlertTypeIdNk { get; set; }
        public string AlertTypeMonitoringSystemName { get; set; }
        public string AlertTypeName { get; set; }
        public string AlertTypeDescription { get; set; }
        public DateTime AlertTypeEffectiveStartDatetime { get; set; }
        public DateTime AlertTypeEffectiveEndDatetime { get; set; }
        public DateTime AlertTypeRecordCreatedDatetime { get; set; }
        public string AlertTypeRecordCreatedBy { get; set; }
        public DateTime AlertTypeRecordUpdatedDatetime { get; set; }
        public string AlertTypeRecordUpdatedBy { get; set; }
        public string AlertTypeSourceSystemName { get; set; }
        public int AlertTypeCurrentRecordFlag { get; set; }
    }
}
