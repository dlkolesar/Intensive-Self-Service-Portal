using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimServicePoller
    {
        public int ServicePollerKey { get; set; }
        public string ServicePollerIdNk { get; set; }
        public string ServicePollerType { get; set; }
        public string ServicePollerName { get; set; }
        public string ServicePollerDescription { get; set; }
        public string ServicePollerMethod { get; set; }
        public int ServicePollerIsActive { get; set; }
        public int ServicePollerIsProvisioned { get; set; }
        public int ServicePollerIsCloseable { get; set; }
        public DateTime ServicePollerEffectiveStartDatetime { get; set; }
        public DateTime ServicePollerEffectiveEndDatetime { get; set; }
        public DateTime ServicePollerRecordCreatedDatetime { get; set; }
        public string ServicePollerRecordCreatedBy { get; set; }
        public DateTime ServicePollerRecordUpdatedDatetime { get; set; }
        public string ServicePollerRecordUpdatedBy { get; set; }
        public string ServicePollerSourceSystemName { get; set; }
        public int ServicePollerCurrentRecordFlag { get; set; }
    }
}
