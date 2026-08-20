using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class Objects
    {
        public Objects()
        {
            MigratedObjectsSourceObject = new HashSet<MigratedObjects>();
            MigratedObjectsTargetObject = new HashSet<MigratedObjects>();
        }

        public Guid ObjectId { get; set; }
        public Guid DomainId { get; set; }
        public string Guid { get; set; }
        public string AdsPath { get; set; }
        public string SamName { get; set; }
        public int Rid { get; set; }
        public string Type { get; set; }
        public int? Flags { get; set; }
        public int? Expires { get; set; }
        public Guid? InvocationId { get; set; }
        public long? Usn { get; set; }
        public string AdsPathTruncated { get; set; }

        public virtual Domains Domain { get; set; }
        public virtual ICollection<MigratedObjects> MigratedObjectsSourceObject { get; set; }
        public virtual ICollection<MigratedObjects> MigratedObjectsTargetObject { get; set; }
    }
}
