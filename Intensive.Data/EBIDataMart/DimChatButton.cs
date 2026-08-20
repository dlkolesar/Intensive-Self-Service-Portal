using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimChatButton
    {
        public int ChatButtonKey { get; set; }
        public string ChatButtonId { get; set; }
        public string ChatButtonDeleteFlag { get; set; }
        public string MasterLabel { get; set; }
        public DateTime? CreatedDateLocal { get; set; }
        public DateTime? CreatedDateCst { get; set; }
        public DateTime? CreatedDateUtc { get; set; }
        public string ChatButtonSkillId { get; set; }
        public string ChatButtonSiteId { get; set; }
        public string ChatPageId { get; set; }
        public string ChatButtonType { get; set; }
        public string ChatButtonIsActive { get; set; }
        public string ChatButtonRoutingType { get; set; }
        public DateTime? ChatButtonEffectiveStartDateTimeCst { get; set; }
        public DateTime? ChatButtonEffectiveEndDateTimeCst { get; set; }
        public DateTime? ChatButtonEffectiveStartDateTimeUtc { get; set; }
        public DateTime? ChatButtonEffectiveEndDateTimeUtc { get; set; }
        public int? ChatButtonCurrentRecord { get; set; }
        public string ChatButtonCreatedBy { get; set; }
        public DateTime? ChatButtonCreatedDatetime { get; set; }
        public string ChatButtonUpdatedBy { get; set; }
        public DateTime? ChatButtonUpdatedDatetime { get; set; }
        public string ChatButtonSourceSystemName { get; set; }
    }
}
