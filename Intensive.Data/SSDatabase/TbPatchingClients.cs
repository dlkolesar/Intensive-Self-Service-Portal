using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbPatchingClients
    {
        public int DeviceNumber { get; set; }
        public Guid? Wsusid { get; set; }
        public int? TargetId { get; set; }
        public short PatchingLevel { get; set; }
        public short UseWuserver { get; set; }
        public string Wuserver { get; set; }
        public short Auoptions { get; set; }
        public bool OptedOut { get; set; }
        public DateTime? LastPatchDate { get; set; }
        public DateTime? LastRefresh { get; set; }
    }
}
