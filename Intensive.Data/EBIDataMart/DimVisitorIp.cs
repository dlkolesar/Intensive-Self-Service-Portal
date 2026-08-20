using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimVisitorIp
    {
        public long VisitorIpKey { get; set; }
        public string VisitorIpSourceSystemIdNk { get; set; }
        public string VisitorIp { get; set; }
        public string VisitorIpCreatedBy { get; set; }
        public DateTime? VisitorIpCreatedDatetime { get; set; }
        public string VisitorIpUpdatedBy { get; set; }
        public DateTime? VisitorIpUpdatedDatetime { get; set; }
        public string VisitorIpSourceSystemName { get; set; }
        public string VisitorIpSourceSystemColumn { get; set; }
    }
}
