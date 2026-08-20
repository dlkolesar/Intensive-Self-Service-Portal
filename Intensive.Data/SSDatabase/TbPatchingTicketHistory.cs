using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbPatchingTicketHistory
    {
        public int Id { get; set; }
        public string RunId { get; set; }
        public int Account { get; set; }
        public string CoreTicket { get; set; }
        public string TicketType { get; set; }
        public bool Updated { get; set; }
    }
}
