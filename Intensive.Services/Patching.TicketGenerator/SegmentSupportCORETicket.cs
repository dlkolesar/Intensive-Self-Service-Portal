using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class SegmentSupportCORETicket : CORETicket
    {
        public enum TicketStatus
        {
            RequireFeedback = 7619,
            ConfirmSolved = 7612,
            Scheduled = 7625,
            New = 7611
        }
        public enum TicketSubCategory
        {
            Other = 27946
        }

        public SegmentSupportCORETicket()
        {
            this.QueueID = 572;   //INF-SS
           // this.QueueID = 554;   //Segment Support
           // this.QueueID = 176;   //INF-MON
           // this.QueueID = 181;   //Segment Support - Linux Patching
            
            this.QueueName = "INF-SS";
            this.SubCategory = (int)TicketSubCategory.Other;
        }
    }
}
