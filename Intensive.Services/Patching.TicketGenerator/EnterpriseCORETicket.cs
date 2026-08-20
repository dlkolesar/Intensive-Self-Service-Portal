using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    class EnterpriseCORETicket :CORETicket
    {
        public enum TicketStatus
        {
            ConfirmSolved = 4430,
            Scheduled = 4532,
            RequireFeedback = 4538,
            New = 4541
        }
        public enum TicketSubcategory
        {
            WindowsPatching = 13372,
            WindowsOther = 13376
        }

        public EnterpriseCORETicket()
        {
            this.QueueID = 390; //Enterprise All Teams
            this.QueueName = "Enterprise(All Teams)";
            this.SubCategory = (int)TicketSubcategory.WindowsPatching;
        }
    }
}
