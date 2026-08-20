using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class References
    {
        public int AccountId { get; set; }
        public int ComputerId { get; set; }
        public int TypeId { get; set; }
        public int RefCount { get; set; }

        public virtual RefAccounts Account { get; set; }
        public virtual RefComputers Computer { get; set; }
        public virtual RefTypes Type { get; set; }
    }
}
