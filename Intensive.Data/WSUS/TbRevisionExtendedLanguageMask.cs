using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbRevisionExtendedLanguageMask
    {
        public int RevisionId { get; set; }
        public long LanguageMask2 { get; set; }
        public long LanguageMask3 { get; set; }
        public long LanguageMask4 { get; set; }
        public long LanguageMask5 { get; set; }
        public long LanguageMask6 { get; set; }
        public long LanguageMask7 { get; set; }
        public long LanguageMask8 { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
