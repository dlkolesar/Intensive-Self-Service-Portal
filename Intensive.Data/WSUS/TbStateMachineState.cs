using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbStateMachineState
    {
        public int StateMachineId { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
}
