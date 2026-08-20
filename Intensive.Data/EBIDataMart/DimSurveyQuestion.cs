using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSurveyQuestion
    {
        public int SurveyQuestionKey { get; set; }
        public string SurveyQuestionNk { get; set; }
        public int SurveyQuestionPagePosition { get; set; }
        public int SurveyQuestionQuestionPosition { get; set; }
        public string SurveyQuestionQuestionAlias { get; set; }
        public string SurveyQuestionQuestionType { get; set; }
        public string SurveyQuestionQuestionCategory { get; set; }
        public string SurveyQuestionQuestionText { get; set; }
        public string SurveyQuestionQuestionSubText { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int CurrentRecord { get; set; }
    }
}
