using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDepartment
    {
        public int DepartmentKey { get; set; }
        public string DepartmentNk { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public string DepartmentActiveStatus { get; set; }
        public DateTime DepartmentEffectiveStartDate { get; set; }
        public DateTime DepartmentEffectiveEndDate { get; set; }
        public DateTime DepartmentRecordCreatedDatetime { get; set; }
        public string DepartmentRecordCreatedBy { get; set; }
        public DateTime DepartmentRecordUpdatedDatetime { get; set; }
        public string DepartmentRecordUpdatedBy { get; set; }
        public string DepartmentSourceSystemName { get; set; }
        public int DepartmentCurrentRecordFlag { get; set; }
    }
}
