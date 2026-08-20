using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimMktgStatus
    {
        public long StatusKey { get; set; }
        public string RecordType { get; set; }
        public string StatusName { get; set; }
        public string StatusDesc { get; set; }
        public string StatusNk { get; set; }
        public string StatusCreatedBy { get; set; }
        public DateTime? StatusCreatedDatetime { get; set; }
        public string StatusUpdatedBy { get; set; }
        public DateTime? StatusUpdatedDatetime { get; set; }
        public string StatusSourceSystemName { get; set; }
    }
}
