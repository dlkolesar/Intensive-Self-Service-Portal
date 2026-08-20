using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class LockedObjects
    {
        public DateTime LockTime { get; set; }
        public Guid DomainId { get; set; }
        public string SamName { get; set; }
        public string DistinguishedName { get; set; }
    }
}
