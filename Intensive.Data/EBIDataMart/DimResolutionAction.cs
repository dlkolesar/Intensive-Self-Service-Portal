using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimResolutionAction
    {
        public int ResolutionActionKey { get; set; }
        public string ResolutionActionIdNk { get; set; }
        public string ResolutionActionType { get; set; }
        public string ResolutionActionName { get; set; }
        public DateTime ResolutionActionEffectiveStartDate { get; set; }
        public DateTime ResolutionActionEffectiveEndDate { get; set; }
        public DateTime RecordCreatedDate { get; set; }
        public string RecordCreatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int ResolutionActionCurrentRecord { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
    }
}
