using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class NameConflictsDomains
    {
        public NameConflictsDomains()
        {
            NameConflictsNames = new HashSet<NameConflictsNames>();
            NameConflictsSourceDomain = new HashSet<NameConflicts>();
            NameConflictsTargetDomain = new HashSet<NameConflicts>();
        }

        public int DomainId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NameConflictsNames> NameConflictsNames { get; set; }
        public virtual ICollection<NameConflicts> NameConflictsSourceDomain { get; set; }
        public virtual ICollection<NameConflicts> NameConflictsTargetDomain { get; set; }
    }
}
