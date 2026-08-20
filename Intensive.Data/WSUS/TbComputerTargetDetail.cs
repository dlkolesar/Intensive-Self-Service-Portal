using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbComputerTargetDetail
    {
        public int TargetId { get; set; }
        public int? OsmajorVersion { get; set; }
        public int? OsminorVersion { get; set; }
        public int? OsbuildNumber { get; set; }
        public int? OsservicePackMajorNumber { get; set; }
        public int? OsservicePackMinorNumber { get; set; }
        public string Oslocale { get; set; }
        public string ComputerMake { get; set; }
        public string ComputerModel { get; set; }
        public string BiosVersion { get; set; }
        public string BiosName { get; set; }
        public DateTime? BiosReleaseDate { get; set; }
        public string ProcessorArchitecture { get; set; }
        public DateTime? LastStatusRollupTime { get; set; }
        public int LastReceivedStatusRollupNumber { get; set; }
        public int LastSentStatusRollupNumber { get; set; }
        public int SamplingValue { get; set; }
        public DateTime CreatedTime { get; set; }
        public short SuiteMask { get; set; }
        public byte OldProductType { get; set; }
        public int NewProductType { get; set; }
        public int SystemMetrics { get; set; }
        public string ClientVersion { get; set; }
        public bool TargetGroupMembershipChanged { get; set; }
        public string Osfamily { get; set; }
        public string Osdescription { get; set; }
    }
}
