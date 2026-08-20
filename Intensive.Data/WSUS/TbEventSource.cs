using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEventSource
    {
        public TbEventSource()
        {
            TbEventInstance = new HashSet<TbEventInstance>();
        }

        public short EventSourceId { get; set; }
        public int EventNamespaceId { get; set; }
        public string DisplayNameString { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int BuildNumber { get; set; }
        public int QfeNumber { get; set; }

        public virtual ICollection<TbEventInstance> TbEventInstance { get; set; }
        public virtual TbEventNamespace EventNamespace { get; set; }
    }
}
