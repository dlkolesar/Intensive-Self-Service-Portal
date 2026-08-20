using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportProvisioningPipeline
    {
        public string DeviceDatacenterAbbr { get; set; }
        public string TeamBusinessSegment { get; set; }
        public string TeamBusinessSubSegment { get; set; }
        public string AccountTeamName { get; set; }
        public long? AccountNumber { get; set; }
        public string AccountName { get; set; }
        public int? DeviceNumber { get; set; }
        public string DeviceType { get; set; }
        public int CrFlag { get; set; }
        public int ScFlag { get; set; }
        public int OcFlag { get; set; }
        public DateTime? FirstCrDt { get; set; }
        public DateTime? FirstScDt { get; set; }
        public DateTime? FirstOcDt { get; set; }
        public double? DcopsBuildBusDays { get; set; }
        public double? DcopsBuildDays { get; set; }
        public double? SegmentConfigBuildBusDays { get; set; }
        public double? SegmentConfigBuildDays { get; set; }
        public double? TotalBuildBusDays { get; set; }
        public double? TotalBuildDays { get; set; }
        public DateTime RecCreatedOn { get; set; }
        public int ReportProvisioningPipelineId { get; set; }
        public DateTime? DeviceOnlineDate { get; set; }
        public DateTime? DueToCustomerDate { get; set; }
    }
}
