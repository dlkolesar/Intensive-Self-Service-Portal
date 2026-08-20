using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class CORETicket
    {
        public int Account { get; set; }
        public int Assignee { get; set; }
        public int[] ComputerList { get; set; }
        public int ContactEmailType { get; set; }
        public string InitialMessage { get; set; }
        public bool IsPrivate { get; set; }
        //public TicketPriority priority { get; set; }
        public bool PrivateFirstMessage { get; set; }
        public int QueueID { get; set; }
        public string QueueName { get; set; }
        public int[] Recipients { get; set; }
        public int Requester { get; set; }
        public bool SendMessageText { get; set; }
        public int Severity { get; set; }
        public int Status { get; set; }
        public int SubCategory { get; set; }
        public string Subject { get; set; }
    }
}
