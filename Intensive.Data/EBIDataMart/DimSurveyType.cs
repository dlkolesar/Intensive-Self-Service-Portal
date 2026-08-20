using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSurveyType
    {
        public int SurveyTypeKey { get; set; }
        public string SurveyTypeNk { get; set; }
        public string SurveyTypeName { get; set; }
        public string SurveyTypeDescription { get; set; }
        public string SurveyTypeSourceSystemName { get; set; }
        public DateTime EffectiveStartDatetime { get; set; }
        public DateTime EffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public int CurrentRecord { get; set; }
    }
}
