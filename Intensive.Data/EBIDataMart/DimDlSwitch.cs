using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDlSwitch
    {
        public int SwitchKey { get; set; }
        public string SwitchSsk { get; set; }
        public string SwitchName { get; set; }
        public string SwitchNumber { get; set; }
        public long? SwitchIpAddress { get; set; }
        public int? SwitchPollable { get; set; }
        public int? SwitchStartingSpace { get; set; }
        public string SwitchConfigurationNumber { get; set; }
        public string SwitchTypeName { get; set; }
        public int? SwitchTypeNumberOfPorts { get; set; }
        public int? SwitchTypeUHeight { get; set; }
        public int? SwitchTypeNumPerWidth { get; set; }
        public string SwitchDataCenterAbbr { get; set; }
        public int? SwitchIdNk { get; set; }
        public int? SwitchTypeIdNk { get; set; }
        public DateTime? RecordCreatedDatetime { get; set; }
        public DateTime? RecordUpdatedDatetime { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string RecordSource { get; set; }
        public int? CurrentRecord { get; set; }
    }
}
