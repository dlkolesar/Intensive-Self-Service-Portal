using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbGroupAuthorization
    {
        public string PluginId { get; set; }
        public Guid GroupId { get; set; }

        public virtual TbAuthorization Plugin { get; set; }
    }
}
