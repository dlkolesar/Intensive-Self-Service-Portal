using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentParentchild
    {
        public int RelationCreatedTimeKey { get; set; }
        public int RelationCreatedHmsKey { get; set; }
        public int TeamKey { get; set; }
        public int AccountKey { get; set; }
        public int IncidentParentKey { get; set; }
        public int IncidentChildKey { get; set; }
        public int Count { get; set; }
        public DateTime IncidentParentChildRecordCreatedDatetime { get; set; }
        public string IncidentParentChildRecordCreatedBy { get; set; }
        public DateTime IncidentParentChildRecordUpdatedDatetime { get; set; }
        public string IncidentParentChildRecordUpdatedBy { get; set; }
        public string IncidentParentChildSourceSystemName { get; set; }

        public virtual DimAccount AccountKeyNavigation { get; set; }
    }
}
