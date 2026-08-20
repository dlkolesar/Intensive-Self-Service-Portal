using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class COREAccount
    {
        public int Number;
        public string AM;
        public int AM_ContactID;
        public List<int> CustomerContactIDs;
        public string SegmentName;
        public string SupportTeamName;
        public int SupportQueueID;
        public string SupportQueueName;
        public int TicketQueue;
        public int TicketStatus;
        public int TicketSubCategory;
        public bool ManualPatching;
        public string PatchingInstructions;

        public COREAccount() { }
    }
}
