using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class MigratedObjects
    {
        public Guid SourceObjectId { get; set; }
        public Guid TargetObjectId { get; set; }
        public Guid GlobalTaskId { get; set; }
        public int Status { get; set; }
        public DateTime MigrationTime { get; set; }
        public DateTime? PasswordCopyTime { get; set; }

        public virtual GlobalTasks GlobalTask { get; set; }
        public virtual Objects SourceObject { get; set; }
        public virtual Objects TargetObject { get; set; }
    }
}
