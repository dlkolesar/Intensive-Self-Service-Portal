using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class NameConflicts
    {
        public int SourceDomainId { get; set; }
        public int TargetDomainId { get; set; }

        public virtual NameConflictsDomains SourceDomain { get; set; }
        public virtual NameConflictsDomains TargetDomain { get; set; }
    }
}
