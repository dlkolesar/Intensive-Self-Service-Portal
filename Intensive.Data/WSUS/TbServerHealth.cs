using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbServerHealth
    {
        public string ComponentName { get; set; }
        public DateTime HeartBeat { get; set; }
        public bool IsRunning { get; set; }
    }
}
