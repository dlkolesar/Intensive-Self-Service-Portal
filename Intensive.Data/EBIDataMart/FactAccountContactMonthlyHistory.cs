using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactAccountContactMonthlyHistory
    {
        public int AccountContactMonthlyTimeKey { get; set; }
        public int AccountContactMonthlyAccountKey { get; set; }
        public int AccountContactMonthlyContactKey { get; set; }
        public int AccountContactMonthlyContactRoleKey { get; set; }
        public int AccountContactMonthlyTimeAssignedKey { get; set; }
        public int? AccountContactMonthlyRecordCount { get; set; }
        public string AccountContactMonthlyRecordCreatedBy { get; set; }
        public DateTime AccountContactMonthlyRecordCreatedDatetime { get; set; }
        public string AccountContactMonthlyRecordUpdatedBy { get; set; }
        public DateTime AccountContactMonthlyRecordUpdatedDatetime { get; set; }
        public string AccountContactMonthlyRecordSourceSystemName { get; set; }
    }
}
