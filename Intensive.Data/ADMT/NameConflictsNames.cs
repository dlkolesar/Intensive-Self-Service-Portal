using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class NameConflictsNames
    {
        public int DomainId { get; set; }
        public string Sam { get; set; }
        public string Rdn { get; set; }
        public string Canonical { get; set; }
        public string Type { get; set; }

        public virtual NameConflictsDomains Domain { get; set; }
    }
}
