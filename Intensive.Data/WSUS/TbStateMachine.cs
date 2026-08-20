using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbStateMachine
    {
        public int StateMachineId { get; set; }
        public string StateMachineName { get; set; }
        public string SelectProc { get; set; }
        public string UpdateProc { get; set; }
    }
}
