using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class ManagedCORETicket : CORETicket
    {
        public enum TicketStatus
        {
            RequireFeedback = 4,
            ConfirmSolved = 6,
            Scheduled = 477,
            New = 3455
        }
        public enum TicketSubCategory
        {
            OSPatch = 31,
            OtherOther = 121
        }

        public ManagedCORETicket()
        {
            this.QueueID = 1;   //ManagedAllTeams
            this.QueueName = "Managed (All Teams)";
        }
    }
}
