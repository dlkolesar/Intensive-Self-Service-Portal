using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    class EnterpriseAmCORETicket : CORETicket
    {
        public enum TicketStatus
        {
            ConfirmSolved = 4404,
            New = 4411,
            RequireFeedback = 4425
        }
        public enum TicketSubcategory
        {
            WindowsPatching = 15304
        }

        public EnterpriseAmCORETicket()
        {
            this.QueueID = 389; //Account Management Enterprise
            this.QueueName = "Enterprise - Account Management";
        }

    }
}
