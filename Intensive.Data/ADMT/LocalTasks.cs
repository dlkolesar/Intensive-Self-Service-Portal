using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class LocalTasks
    {
        public LocalTasks()
        {
            DistributedTasks = new HashSet<DistributedTasks>();
            TaskProperties = new HashSet<TaskProperties>();
        }

        public int TaskId { get; set; }
        public Guid GlobalTaskId { get; set; }
        public Guid? AdmtId { get; set; }
        public string AdmtComputer { get; set; }
        public string AdmtUser { get; set; }
        public int? Status { get; set; }
        public int? LogStatus { get; set; }
        public byte[] LogFile { get; set; }
        public byte[] AccountFile { get; set; }

        public virtual GlobalTasks GlobalTask { get; set; }
        public virtual ICollection<DistributedTasks> DistributedTasks { get; set; }
        public virtual ICollection<TaskProperties> TaskProperties { get; set; }
    }
}
