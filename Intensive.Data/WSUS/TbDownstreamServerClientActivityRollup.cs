using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDownstreamServerClientActivityRollup
    {
        public int ClientSummaryId { get; set; }
        public Guid UpdateId { get; set; }
        public int RevisionNumber { get; set; }
        public int InstallSuccessCount { get; set; }
        public int InstallFailureCount { get; set; }

        public virtual TbDownstreamServerClientSummaryRollup ClientSummary { get; set; }
    }
}
