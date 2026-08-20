using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSearchTerm
    {
        public long SearchKey { get; set; }
        public string SearchTermSourceSystemIdNk { get; set; }
        public string SearchTerm { get; set; }
        public string SearchEngine { get; set; }
        public string SearchType { get; set; }
        public string SearchTermCreatedBy { get; set; }
        public DateTime? SearchTermCreatedDatetime { get; set; }
        public DateTime? SearchTermUpdatedDatetime { get; set; }
        public string SearchTermUpdatedBy { get; set; }
        public string SearchTermSourceSystemColumn { get; set; }
        public string SearchTermSourceSystemName { get; set; }
    }
}
