using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimChatVisitor
    {
        public int VisitorKey { get; set; }
        public string VisitorNk { get; set; }
        public string VisitorId { get; set; }
        public string VisitorRackUid { get; set; }
        public string VisitorName { get; set; }
        public string VisitorEmail { get; set; }
        public string VisitorRecordCreatedBy { get; set; }
        public DateTime? VisitorRecordCreatedDatetime { get; set; }
        public string VisitorRecordUpdatedBy { get; set; }
        public DateTime? VisitorRecordUpdatedDatetime { get; set; }
        public string VisitorSourceSystemNk { get; set; }
        public string SourceSystemName { get; set; }
    }
}
