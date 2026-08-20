using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDownstreamServerClientSummaryRollup
    {
        public TbDownstreamServerClientSummaryRollup()
        {
            TbDownstreamServerClientActivityRollup = new HashSet<TbDownstreamServerClientActivityRollup>();
        }

        public int? TargetId { get; set; }
        public int ClientSummaryId { get; set; }
        public int OsmajorVersion { get; set; }
        public int OsminorVersion { get; set; }
        public int OsbuildNumber { get; set; }
        public int OsservicePackMajorNumber { get; set; }
        public int OsservicePackMinorNumber { get; set; }
        public string Oslocale { get; set; }
        public string ProcessorArchitecture { get; set; }
        public int ClientCount { get; set; }
        public byte OldProductType { get; set; }
        public int NewProductType { get; set; }
        public int SystemMetrics { get; set; }
        public short SuiteMask { get; set; }

        public virtual ICollection<TbDownstreamServerClientActivityRollup> TbDownstreamServerClientActivityRollup { get; set; }
        public virtual TbTarget Target { get; set; }
    }
}
