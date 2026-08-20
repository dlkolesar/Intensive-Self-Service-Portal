using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEulaAcceptance
    {
        public Guid EulaId { get; set; }
        public DateTime AcceptedDate { get; set; }
        public string AdminName { get; set; }
    }
}
