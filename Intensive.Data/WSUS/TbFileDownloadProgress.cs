using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbFileDownloadProgress
    {
        public long Id { get; set; }
        public Guid RowId { get; set; }
        public long TotalBytesForDownload { get; set; }
        public long BytesDownloaded { get; set; }
    }
}
