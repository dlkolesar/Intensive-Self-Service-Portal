using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimVisitor
    {
        public long VisitorKey { get; set; }
        public string VisitorSourceSystemIdNk { get; set; }
        public string VisitorId { get; set; }
        public string VisitorRackuid { get; set; }
        public string VisitorCreatedBy { get; set; }
        public DateTime? VisitorCreatedDatetime { get; set; }
        public string VisitorUpdatedBy { get; set; }
        public DateTime? VisitorUpdatedDatetime { get; set; }
        public string VisitorSourceSystemName { get; set; }
        public string VisitorSourceSystemColumn { get; set; }
    }
}
