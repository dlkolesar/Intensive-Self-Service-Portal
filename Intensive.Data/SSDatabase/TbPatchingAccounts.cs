using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbPatchingAccounts
    {
        public int Number { get; set; }
        public bool OptedOut { get; set; }
        public DateTime? OptInOutDate { get; set; }
        public string OptInOutTicket { get; set; }
        public bool OptedOutOfTicketing { get; set; }
        public DateTime? LastRefresh { get; set; }
        public bool? Refreshing { get; set; }
    }
}
