using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactSurveyQuestionAnswer
    {
        public int ResponseStartTimeKey { get; set; }
        public int ResponseStartHmsKey { get; set; }
        public int ResponseEndTimeKey { get; set; }
        public int ResponseEndHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int ContactKey { get; set; }
        public int SurveyResponseKey { get; set; }
        public int SurveyKey { get; set; }
        public int SurveyQuestionKey { get; set; }
        public int SurveyAnswerKey { get; set; }
        public int AnswerIdNk { get; set; }
        public long ResponseIdNk { get; set; }
        public int MeasureCount { get; set; }
        public string RecordSourceKey { get; set; }
        public int RecordCreatedTimeKey { get; set; }
        public int RecordCreatedHmsKey { get; set; }
        public int RecordCreatedByKey { get; set; }
        public int RecordUpdatedTimeKey { get; set; }
        public int RecordUpdatedHmsKey { get; set; }
        public int RecordUpdatedByKey { get; set; }
        public int? AmContactKey { get; set; }
        public int? ContactRoleKey { get; set; }
        public int? BdcContactKey { get; set; }
    }
}
