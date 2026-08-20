using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbEulaProperty
    {
        public byte[] EulaFileDigest { get; set; }
        public int RevisionId { get; set; }
        public int LanguageId { get; set; }

        public virtual TbFile EulaFileDigestNavigation { get; set; }
        public virtual TbLanguage Language { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
