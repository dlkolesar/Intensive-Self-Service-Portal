using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbFile
    {
        public TbFile()
        {
            TbEulaProperty = new HashSet<TbEulaProperty>();
            TbFileForRevision = new HashSet<TbFileForRevision>();
            TbFileOnServer = new HashSet<TbFileOnServer>();
        }

        public byte[] FileDigest { get; set; }
        public string FileName { get; set; }
        public DateTime? Modified { get; set; }
        public long Size { get; set; }
        public bool IsEula { get; set; }
        public string Muurl { get; set; }
        public string Ussurl { get; set; }
        public bool IsExternalCab { get; set; }
        public bool IsSecure { get; set; }
        public bool IsEncrypted { get; set; }
        public byte[] DecryptionKey { get; set; }

        public virtual ICollection<TbEulaProperty> TbEulaProperty { get; set; }
        public virtual ICollection<TbFileForRevision> TbFileForRevision { get; set; }
        public virtual ICollection<TbFileOnServer> TbFileOnServer { get; set; }
    }
}
