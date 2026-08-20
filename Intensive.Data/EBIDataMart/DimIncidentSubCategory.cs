using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimIncidentSubCategory
    {
        public int IncidentSubCategoryKey { get; set; }
        public string IncidentSubCategoryIdNk { get; set; }
        public int IncidentCategoryKey { get; set; }
        public string IncidentSubCategoryName { get; set; }
        public string IncidentSubCategoryDescription { get; set; }
        public int IncidentSubCategoryActive { get; set; }
        public DateTime IncidentSubCategoryEffectiveStartDatetime { get; set; }
        public DateTime IncidentSubCategoryEffectiveEndDatetime { get; set; }
        public DateTime IncidentSubCategoryRecordCreatedDatetime { get; set; }
        public string IncidentSubCategoryRecordCreatedBy { get; set; }
        public DateTime IncidentSubCategoryRecordUpdatedDatetime { get; set; }
        public string IncidentSubCategoryRecordUpdatedBy { get; set; }
        public string IncidentSubCategorySourceSystemName { get; set; }
        public int IncidentSubCategoryCurrentRecordFlag { get; set; }
    }
}
