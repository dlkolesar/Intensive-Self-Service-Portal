using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDeletedComputer
    {
        public string ComputerId { get; set; }
        public DateTime DeletedTime { get; set; }
    }
}
