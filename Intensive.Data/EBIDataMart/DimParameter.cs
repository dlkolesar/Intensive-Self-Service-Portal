using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimParameter
    {
        public long ParameterKey { get; set; }
        public string ParameterSourceSystemIdNk { get; set; }
        public string Parameter { get; set; }
        public string ParameterCreatedBy { get; set; }
        public DateTime? ParameterCreatedDatetime { get; set; }
        public string ParameterUpdatedBy { get; set; }
        public DateTime? ParameterUpdatedDatetime { get; set; }
        public string ParameterSourceSystemName { get; set; }
        public string ParameterSourceSystemColumn { get; set; }
    }
}
