using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportQueueStats
    {
        public int? IncidentKey { get; set; }
        public string IncidentReferenceNumber { get; set; }
        public string QueueName { get; set; }
        public string TcktQuecatInstance { get; set; }
        public int? AccountKey { get; set; }
        public string AccountName { get; set; }
        public long? AccountNumber { get; set; }
        public int? TeamKey { get; set; }
        public string TeamName { get; set; }
        public string TeamBusinessSegment { get; set; }
        public string TeamBusinessSubSegment { get; set; }
        public string IncidentCategoryName { get; set; }
        public string IncidentSubcategoryName { get; set; }
        public DateTime? QueueInstanceEntryDate { get; set; }
        public DateTime? QueueInstanceExitDate { get; set; }
        public DateTime? QueueInstanceConfirmSolveDate { get; set; }
        public DateTime? QueueInstanceFirstAssignDate { get; set; }
        public int? TimeToAssignMi { get; set; }
        public int? QueueInstanceFirstAssignerKey { get; set; }
        public string QueueInstanceFirstAssigner { get; set; }
        public int? QueueInstanceFirstAssigneeKey { get; set; }
        public string QueueInstanceFirstAssignee { get; set; }
        public int? ActiveTimeMi { get; set; }
        public int? QueueInstanceEntryTimeKey { get; set; }
        public int? QueueInstanceEntryTimeHmsKey { get; set; }
        public DateTime? QueueInstanceFirstRespDate { get; set; }
        public int? ResponseTimeMi { get; set; }
        public int? QueueInstanceFirstResponderKey { get; set; }
        public string QueueInstanceFirstResponder { get; set; }
        public DateTime? QueueInstanceFirstPrivRespDate { get; set; }
        public int? QueueInstanceFirstPrivResponderKey { get; set; }
        public string QueueInstanceFirstPrivResponder { get; set; }
        public DateTime? QueueInstanceFirstPubRespDate { get; set; }
        public int? QueueInstanceFirstPubResponderKey { get; set; }
        public string QueueInstanceFirstPubResponder { get; set; }
        public int? QueueInstanceLastAssigneeKey { get; set; }
        public string QueueInstanceLastAssignee { get; set; }
        public string QueueInstanceLastStatus { get; set; }
        public DateTime? QueueInstanceFirstStsChgDate { get; set; }
        public int? QueueInstanceFirstStsChgByKey { get; set; }
        public string QueueInstanceFirstStsChgBy { get; set; }
        public int? TimeToStsChgMi { get; set; }
        public DateTime RecCreatedOn { get; set; }
        public int Id { get; set; }
    }
}
