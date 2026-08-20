using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbUpdateFlag
    {
        public int LocalUpdateId { get; set; }
        public bool? FromCatalogSite { get; set; }
    }
}
