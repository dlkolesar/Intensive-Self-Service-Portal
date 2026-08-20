using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactNpsScore
    {
        public int StartTimeKey { get; set; }
        public int StartHmsKey { get; set; }
        public int TeamKey { get; set; }
        public int AccountKey { get; set; }
        public int ContactKey { get; set; }
        public int IncidentKey { get; set; }
        public int SurveyKey { get; set; }
        public int SurveyQuestionKey { get; set; }
        public int SurveyNpsAnswerKey { get; set; }
        public int SurveyResponseKey { get; set; }
        public int SurveyTypeKey { get; set; }
        public string NpsSsk { get; set; }
        public int ResponseCount { get; set; }
        public int NpsRating { get; set; }
        public int RecordSourceKey { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int? AmContactKey { get; set; }
        public int? BdcContactKey { get; set; }
    }
}
