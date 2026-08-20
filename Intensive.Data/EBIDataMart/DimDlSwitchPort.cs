using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDlSwitchPort
    {
        public int SwitchPortKey { get; set; }
        public string SwitchPortSsk { get; set; }
        public int? SwitchPortUsable { get; set; }
        public int? SwitchPortNumber { get; set; }
        public string SwitchPortInterfaceTypeName { get; set; }
        public string SwitchPortInterfaceTypeDescription { get; set; }
        public int? SwitchPortInterfaceTypeBandwidthMonitorOrder { get; set; }
        public DateTime? RecordEffectiveStartDatetime { get; set; }
        public DateTime? RecordEffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUdpatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string RecordSourceSystem { get; set; }
        public int CurrentRecord { get; set; }
    }
}
