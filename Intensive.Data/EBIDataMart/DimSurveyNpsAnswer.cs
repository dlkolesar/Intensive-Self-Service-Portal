using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSurveyNpsAnswer
    {
        public int SurveyNpsAnswerKey { get; set; }
        public string SurveyNpsAnswerNk { get; set; }
        public string SurveyNpsAnswer { get; set; }
        public string SurveyNpsRatingType { get; set; }
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
