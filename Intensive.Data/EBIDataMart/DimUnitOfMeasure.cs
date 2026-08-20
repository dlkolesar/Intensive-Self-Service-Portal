using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimUnitOfMeasure
    {
        public int UnitOfMeasureKey { get; set; }
        public int? UnitOfMeasureNk { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string UnitOfMeasureDescription { get; set; }
        public string UnitOfMeasureAbbreviation { get; set; }
        public DateTime? UnitOfMeasureEffectiveStartDateTime { get; set; }
        public DateTime? UnitOfMeasureEffectiveEndDateTime { get; set; }
        public DateTime? UnitOfMeasureRecordCreatedDateTime { get; set; }
        public DateTime? UnitOfMeasureRecordUpdatedDateTime { get; set; }
        public string UnitOfMeasureRecordCreatedBy { get; set; }
        public string UnitOfMeasureRecordUpdatedBy { get; set; }
        public byte? UnitOfMeasureCurrentRecordFlag { get; set; }
    }
}
