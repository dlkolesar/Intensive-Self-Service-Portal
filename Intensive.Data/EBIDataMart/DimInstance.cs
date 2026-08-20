using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimInstance
    {
        public long InstanceKey { get; set; }
        public string InstanceNk { get; set; }
        public string InstanceType { get; set; }
        public string AssignedInstanceNumber { get; set; }
        public string AssignedAccountNumber { get; set; }
        public string InstanceName { get; set; }
        public string InstanceDescription { get; set; }
        public string InstanceStatus { get; set; }
        public string InstanceDatacenter { get; set; }
        public DateTime? RecCreatedDate { get; set; }
        public DateTime? RecUpdatedDate { get; set; }
        public DateTime? InstanceCreationDate { get; set; }
        public DateTime? InstanceUpdatedDate { get; set; }
        public string InstanceCreationBy { get; set; }
        public string InstanceUpdatedBy { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public string SourceSystemName { get; set; }
        public string CurrentRecord { get; set; }
    }
}
