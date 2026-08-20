using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDlContainerComponent
    {
        public int ContainerComponentKey { get; set; }
        public string ContainerComponentSsk { get; set; }
        public string ContainerComponentNumber { get; set; }
        public string ContainerComponentName { get; set; }
        public string ContainerComponentAccountNumber { get; set; }
        public string ContainerComponentAccountSourceSystemName { get; set; }
        public int? ContainerComponentStartingSpace { get; set; }
        public int? ContainerComponentUndermountSpace { get; set; }
        public int? ContainerComponentIsUnowned { get; set; }
        public string ContainerComponentConfigurationNumber { get; set; }
        public DateTime? ContainerComponentPendingDeletionDatetime { get; set; }
        public string ContainerComponentConfigurationTypeName { get; set; }
        public int? ContainerComponentConfigurationTypeUHeight { get; set; }
        public int? ContainerComponentConfigurationTypeNumPerWidth { get; set; }
        public int? ContainerComponentConfigurationTypeCanBeVertical { get; set; }
        public int? ContainerComponentConfigurationTypeCanBeUndermount { get; set; }
        public string ContainerComponentConfigurationTypeRegex { get; set; }
        public int? ContainerComponentConfigurationTypePrecedence { get; set; }
        public int? ContainerComponentConfigurationCaseSensitive { get; set; }
        public int? ContainerComponentConfigurationRegexForSku { get; set; }
        public string ContainerComponentConfigurationDatacenterAbbr { get; set; }
        public int? ContainerComponentDeviceIdNk { get; set; }
        public int? ContainerComponentConfigurationIdNk { get; set; }
        public DateTime? RecordCreatedDatetime { get; set; }
        public DateTime? RecordUpdatedDatetime { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public string RecordSource { get; set; }
        public int? CurrentRecord { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordUpdatedBy { get; set; }
    }
}
