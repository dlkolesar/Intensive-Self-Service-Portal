using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class GlobalTasks
    {
        public GlobalTasks()
        {
            LocalTasks = new HashSet<LocalTasks>();
            MigratedObjects = new HashSet<MigratedObjects>();
        }

        public Guid GlobalTaskId { get; set; }
        public DateTime TaskTime { get; set; }

        public virtual ICollection<LocalTasks> LocalTasks { get; set; }
        public virtual ICollection<MigratedObjects> MigratedObjects { get; set; }
    }
}
