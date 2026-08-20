using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEvent
    {
        public TbEvent()
        {
            TbEventInstance = new HashSet<TbEventInstance>();
        }

        public short EventId { get; set; }
        public int EventNamespaceId { get; set; }
        public int StateId { get; set; }
        public int SeverityId { get; set; }
        public short LogLevel { get; set; }

        public virtual ICollection<TbEventInstance> TbEventInstance { get; set; }
        public virtual TbEventMessageTemplate TbEventMessageTemplate { get; set; }
        public virtual TbEventNamespace EventNamespace { get; set; }
    }
}
