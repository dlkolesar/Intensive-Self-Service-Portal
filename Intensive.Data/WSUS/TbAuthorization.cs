using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbAuthorization
    {
        public TbAuthorization()
        {
            TbGroupAuthorization = new HashSet<TbGroupAuthorization>();
        }

        public string PluginId { get; set; }
        public string ServiceUrl { get; set; }
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        public string Parameters { get; set; }
        public byte[] AuthorizationData { get; set; }

        public virtual ICollection<TbGroupAuthorization> TbGroupAuthorization { get; set; }
    }
}
