using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbStateMachineTransition
    {
        public int StateMachineId { get; set; }
        public int StateId { get; set; }
        public int EventId { get; set; }
        public int NewStateId { get; set; }
        public string StoredProcedure { get; set; }
    }
}
