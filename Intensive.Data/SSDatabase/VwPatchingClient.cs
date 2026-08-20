using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class VwPatchingClient
    {
        public string Name { get; set; }
        public int Account { get; set; }
        public string Os { get; set; }
        public string DataCenter { get; set; }
        public bool IsCluster { get; set; }
        public bool IsClusterNode { get; set; }
        public Guid? Wsusid { get; set; }
        public short PatchingLevel { get; set; }
        public short UseWuserver { get; set; }
        public string Wuserver { get; set; }
        public short Auoptions { get; set; }
        public bool OptedOut { get; set; }
        public DateTime? LastRefresh { get; set; }
        public int? TargetId { get; set; }
        public DateTime? LastPatchDate { get; set; }
        public int DeviceNumber { get; set; }
    }
}
