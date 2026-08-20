using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactDeptCreditMemo
    {
        public int DeptCreditMemoKey { get; set; }
        public int TimeKey { get; set; }
        public int HmsKey { get; set; }
        public int DepartmentKey { get; set; }
        public int CreditMemoNk { get; set; }
        public int DepartmentNk { get; set; }
        public int Count { get; set; }
        public string SourceSystemName { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime? RecordCreatedDate { get; set; }
        public string RecordUpdatedBy { get; set; }
        public DateTime? RecordUpdatedDate { get; set; }
    }
}
