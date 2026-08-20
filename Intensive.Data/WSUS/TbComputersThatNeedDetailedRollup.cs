using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbComputersThatNeedDetailedRollup
    {
        public int TargetId { get; set; }
        public bool IsBeingRolledUp { get; set; }

        public virtual TbComputerTarget Target { get; set; }
    }
}
