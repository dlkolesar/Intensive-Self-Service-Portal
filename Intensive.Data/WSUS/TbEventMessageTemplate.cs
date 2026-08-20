using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEventMessageTemplate
    {
        public short EventId { get; set; }
        public int EventNamespaceId { get; set; }
        public string ShortLanguage { get; set; }
        public string MessageTemplate { get; set; }

        public virtual TbEvent Event { get; set; }
    }
}
