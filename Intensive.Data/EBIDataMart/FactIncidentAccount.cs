using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactIncidentAccount
    {
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int IncidentKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int Count { get; set; }
        public DateTime IncidentAccountRecordCreatedDatetime { get; set; }
        public string IncidentAccountRecordCreatedBy { get; set; }
        public DateTime IncidentAccountRecordUpdatedDatetime { get; set; }
        public string IncidentAccountRecordUpdatedBy { get; set; }
        public string IncidentAccountSourceSystemName { get; set; }
    }
}
