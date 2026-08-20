using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimPhoneSkill
    {
        public int PhoneSkillKey { get; set; }
        public string PhoneSkillNk { get; set; }
        public string PhoneSkillName { get; set; }
        public string PhoneSkillDescription { get; set; }
        public DateTime? PhoneSkillEffectiveStartDate { get; set; }
        public DateTime? PhoneSkillEffectiveEndDate { get; set; }
        public DateTime? PhoneSkillRecordCreatedDatetime { get; set; }
        public string PhoneSkillRecordCreatedBy { get; set; }
        public DateTime? PhoneSkillRecordUpdatedDatetime { get; set; }
        public string PhoneSkillRecordUpdatedBy { get; set; }
        public string PhoneSkillSourceSystemName { get; set; }
        public int CurrentRecord { get; set; }
    }
}
