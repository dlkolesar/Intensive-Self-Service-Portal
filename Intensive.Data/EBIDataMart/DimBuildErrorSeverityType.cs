using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimBuildErrorSeverityType
    {
        public int BuildErrorSeverityTypeKey { get; set; }
        public string BuildErrorSeverityTypeIdNk { get; set; }
        public string BuildErrorSeverityTypeType { get; set; }
        public string BuildErrorSeverityTypeName { get; set; }
        public string BuildErrorSeverityTypeDescription { get; set; }
        public DateTime BuildErrorSeverityTypeEffectiveStartDatetime { get; set; }
        public DateTime BuildErrorSeverityTypeEffectiveEndDatetime { get; set; }
        public DateTime BuildErrorSeverityTypeCreatedDatetime { get; set; }
        public string BuildErrorSeverityTypeCreatedBy { get; set; }
        public DateTime BuildErrorSeverityTypeUpdatedDatetime { get; set; }
        public string BuildErrorSeverityTypeUpdatedBy { get; set; }
        public string BuildErrorSeverityTypeSourceSystemName { get; set; }
        public int BuildErrorSeverityTypeCurrentRecord { get; set; }
    }
}
