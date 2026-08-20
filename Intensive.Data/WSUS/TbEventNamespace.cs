using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEventNamespace
    {
        public TbEventNamespace()
        {
            TbEvent = new HashSet<TbEvent>();
            TbEventSource = new HashSet<TbEventSource>();
        }

        public int EventNamespaceId { get; set; }
        public string DisplayNameString { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public int BuildNumber { get; set; }
        public int QfeNumber { get; set; }

        public virtual ICollection<TbEvent> TbEvent { get; set; }
        public virtual ICollection<TbEventSource> TbEventSource { get; set; }
    }
}
