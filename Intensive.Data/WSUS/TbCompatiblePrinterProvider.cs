using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbCompatiblePrinterProvider
    {
        public int RevisionId { get; set; }
        public string CompatibleProvider { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
