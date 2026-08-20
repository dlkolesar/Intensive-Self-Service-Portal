using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEventInstance
    {
        public Guid EventInstanceId { get; set; }
        public short EventId { get; set; }
        public int EventNamespaceId { get; set; }
        public short EventSourceId { get; set; }
        public DateTime TimeAtTarget { get; set; }
        public DateTime? TimeAtServer { get; set; }
        public int Win32Hresult { get; set; }
        public string AppName { get; set; }
        public string MiscData { get; set; }
        public string ReplacementStrings { get; set; }
        public string ComputerId { get; set; }
        public Guid? UpdateId { get; set; }
        public int? RevisionNumber { get; set; }
        public string DeviceId { get; set; }
        public long EventOrdinalNumber { get; set; }

        public virtual TbEvent Event { get; set; }
        public virtual TbEventSource EventNavigation { get; set; }
    }
}
