using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbInventoryXml
    {
        public int TargetId { get; set; }
        public byte[] CompressedXml { get; set; }
        public string RawXml { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsProcessed { get; set; }

        public virtual TbComputerTarget Target { get; set; }
    }
}
