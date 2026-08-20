using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentCategory
    {
        public int IncidentCategoryKey { get; set; }
        public string IncidentCategoryIdNk { get; set; }
        public string IncidentCategoryName { get; set; }
        public string IncidentCategoryDescription { get; set; }
        public DateTime IncidentCategoryEffectiveStartDatetime { get; set; }
        public DateTime IncidentCategoryEffectiveEndDatetime { get; set; }
        public DateTime IncidentCategoryRecordCreatedDatetime { get; set; }
        public string IncidentCategoryRecordCreatedBy { get; set; }
        public DateTime IncidentCategoryRecordUpdatedDatetime { get; set; }
        public string IncidentCategoryRecordUpdatedBy { get; set; }
        public string IncidentCategorySourceSystemName { get; set; }
        public int IncidentCategoryCurrentRecordFlag { get; set; }
    }
}
