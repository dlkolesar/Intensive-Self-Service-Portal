using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbStateMachineEventTransitionLog
    {
        public int EntryId { get; set; }
        public DateTime EventTime { get; set; }
        public int StateMachineId { get; set; }
        public Guid RowId { get; set; }
        public int OldStateId { get; set; }
        public int EventId { get; set; }
        public int NewStateId { get; set; }
    }
}
