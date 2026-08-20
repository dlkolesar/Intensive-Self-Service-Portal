using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimContactRole
    {
        public int ContactRoleKey { get; set; }
        public string ContactRoleNk { get; set; }
        public int ContactRoleGroupId { get; set; }
        public int ContactRoleCategoryId { get; set; }
        public string ContactRoleName { get; set; }
        public string ContactRoleDescription { get; set; }
        public DateTime ContactRoleEffectiveStartDatetime { get; set; }
        public DateTime ContactRoleEffectiveEndDatetime { get; set; }
        public DateTime ContactRoleRecordCreatedDatetime { get; set; }
        public string ContactRoleRecordUpdatedBy { get; set; }
        public string ContactRoleRecordCreatedBy { get; set; }
        public DateTime ContactRoleRecordUpdatedDatetime { get; set; }
        public string ContactRoleSourceName { get; set; }
        public int ContactRoleCurrentRecord { get; set; }
    }
}
