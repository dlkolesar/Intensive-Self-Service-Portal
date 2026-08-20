using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimAlertStatus
    {
        public int AlertStatusKey { get; set; }
        public string AlertStatusIdNk { get; set; }
        public string AlertStatusType { get; set; }
        public string AlertStatusText { get; set; }
        public string AlertStatusDescription { get; set; }
        public DateTime AlertStatusEffectiveStartDatetime { get; set; }
        public DateTime AlertStatusEffectiveEndDatetime { get; set; }
        public DateTime AlertStatusRecordCreatedDatetime { get; set; }
        public string AlertStatusRecordCreatedBy { get; set; }
        public DateTime AlertStatusRecordUpdatedDatetime { get; set; }
        public string AlertStatusRecordUpdatedBy { get; set; }
        public string AlertStatusSourceSystemName { get; set; }
        public int AlertStatusCurrentRecordFlag { get; set; }
    }
}
