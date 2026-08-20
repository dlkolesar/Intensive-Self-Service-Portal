using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactDeviceBuildError
    {
        public string DeviceBuildErrorId { get; set; }
        public int DeviceBuildErrorTimeKey { get; set; }
        public int DeviceBuildErrorHmsKey { get; set; }
        public int DeviceBuildErrorAccountKey { get; set; }
        public int DeviceBuildErrorTeamKey { get; set; }
        public int DeviceBuildErrorDeviceKey { get; set; }
        public int DeviceBuildErrorBuildErrorTypeKey { get; set; }
        public int DeviceBuildErrorBuildErrorSeverityTypeKey { get; set; }
        public int DeviceBuildErrorCount { get; set; }
        public DateTime DeviceBuildErrorRecordCreatedDatetime { get; set; }
        public string DeviceBuildErrorRecordCreatedBy { get; set; }
        public DateTime DeviceBuildErrorRecordUpdatedDatetime { get; set; }
        public string DeviceBuildErrorRecordUpdatedBy { get; set; }
        public string DeviceBuildErrorSourceSystemName { get; set; }

        public virtual DimAccount DeviceBuildErrorAccountKeyNavigation { get; set; }
    }
}
