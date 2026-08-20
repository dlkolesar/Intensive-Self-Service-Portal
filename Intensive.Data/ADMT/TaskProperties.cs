using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class TaskProperties
    {
        public int TaskId { get; set; }
        public string PropertyName { get; set; }
        public object PropertyValue { get; set; }

        public virtual LocalTasks Task { get; set; }
    }
}
