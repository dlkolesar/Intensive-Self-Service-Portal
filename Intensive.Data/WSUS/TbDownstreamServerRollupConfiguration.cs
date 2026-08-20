using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDownstreamServerRollupConfiguration
    {
        public int Id { get; set; }
        public DateTime? LatestEventTime { get; set; }
    }
}
