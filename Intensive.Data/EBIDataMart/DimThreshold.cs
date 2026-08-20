using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimThreshold
    {
        public int ThresholdKey { get; set; }
        public string ThresholdIdNk { get; set; }
        public string ThresholdType { get; set; }
        public string ThresholdName { get; set; }
        public string ThresholdDescription { get; set; }
        public decimal ThresholdAmount { get; set; }
        public string ThresholdUnitOfMeasure { get; set; }
        public DateTime ThresholdEffectiveStartDatetime { get; set; }
        public DateTime ThresholdEffectiveEndDatetime { get; set; }
        public DateTime ThresholdRecordCreatedDatetime { get; set; }
        public string ThresholdRecordCreatedBy { get; set; }
        public DateTime ThresholdRecordUpdatedDatetime { get; set; }
        public string ThresholdRecordUpdatedBy { get; set; }
        public string ThresholdSourceSystemName { get; set; }
        public int ThresholdCurrentRecordFlag { get; set; }
    }
}
