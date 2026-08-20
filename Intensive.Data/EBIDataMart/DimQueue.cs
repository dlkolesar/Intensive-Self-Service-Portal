using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimQueue
    {
        public int QueueKey { get; set; }
        public int QueueIdNk { get; set; }
        public string QueueType { get; set; }
        public string QueueName { get; set; }
        public string QueueDescription { get; set; }
        public int QueuePrivateFlag { get; set; }
        public int QueueActiveFlag { get; set; }
        public DateTime QueueEffectiveStartDatetime { get; set; }
        public DateTime QueueEffectiveEndDatetime { get; set; }
        public DateTime QueueRecordCreatedDatetime { get; set; }
        public string QueueRecordCreatedBy { get; set; }
        public DateTime QueueRecordUdatedDatetime { get; set; }
        public string QueueRecordUpdatedBy { get; set; }
        public string QueueSourceSystemName { get; set; }
        public int QueueCurrentRecordFlag { get; set; }
    }
}
