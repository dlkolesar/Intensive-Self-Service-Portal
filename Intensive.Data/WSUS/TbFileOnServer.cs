using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbFileOnServer
    {
        public byte[] FileDigest { get; set; }
        public int ConfigurationId { get; set; }
        public Guid RowId { get; set; }
        public int DesiredState { get; set; }
        public int ActualState { get; set; }
        public DateTime? TimeAddedToQueue { get; set; }
        public bool DssrequestedDownload { get; set; }

        public virtual TbFile FileDigestNavigation { get; set; }
    }
}
