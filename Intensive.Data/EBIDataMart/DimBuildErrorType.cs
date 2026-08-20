using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimBuildErrorType
    {
        public int BuildErrorTypeKey { get; set; }
        public string BuildErrorTypeIdNk { get; set; }
        public string BuildErrorTypeType { get; set; }
        public string BuildErrorTypeName { get; set; }
        public string BuildErrorTypeDescription { get; set; }
        public DateTime BuildErrorTypeEffectiveStartDatetime { get; set; }
        public DateTime BuildErrorTypeEffectiveEndDatetime { get; set; }
        public DateTime BuildErrorTypeCreatedDatetime { get; set; }
        public string BuildErrorTypeCreatedBy { get; set; }
        public DateTime BuildErrorTypeUpdatedDatetime { get; set; }
        public string BuildErrorTypeUpdatedBy { get; set; }
        public string BuildErrorTypeSourceSystemName { get; set; }
        public int BuildErrorTypeCurrentRecord { get; set; }
    }
}
