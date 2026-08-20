using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbStateMachineEvent
    {
        public int StateMachineId { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
    }
}
