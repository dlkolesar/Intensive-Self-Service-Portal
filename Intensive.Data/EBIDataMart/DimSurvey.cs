using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSurvey
    {
        public int SurveyKey { get; set; }
        public string SurveyIdNk { get; set; }
        public string SurveyName { get; set; }
        public string SurveyTitle { get; set; }
        public string SurveyDescription { get; set; }
        public string SurveyCreatedBySs { get; set; }
        public short? SurveyAllowEditCompleted { get; set; }
        public short? SurveyAllowResumeSurvey { get; set; }
        public int? SurveyMaxTotalResponses { get; set; }
        public int? SurveyMaxResponsesPerUser { get; set; }
        public short? SurveyIsActive { get; set; }
        public DateTime? RecordEffectiveStartDatetime { get; set; }
        public DateTime? RecordEffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SurveySourceSystemName { get; set; }
        public int CurrentRecord { get; set; }
    }
}
