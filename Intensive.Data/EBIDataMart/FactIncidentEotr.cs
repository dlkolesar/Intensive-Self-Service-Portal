using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentEotr
    {
        public int FactIncidentEotrKey { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int TeamKey { get; set; }
        public int AccountKey { get; set; }
        public int IncidentKey { get; set; }
        public int EotrGrade { get; set; }
        public DateTime IncidentEotrRecordCreatedDatetime { get; set; }
        public string IncidentEotrRecordCreatedBy { get; set; }
        public DateTime IncidentEotrRecordUpdatedDatetime { get; set; }
        public string IncidentEotrRecordUpdatedBy { get; set; }
        public string IncidentEotrSourceSystemName { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
