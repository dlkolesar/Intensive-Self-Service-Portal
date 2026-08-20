using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbRevisionLanguage
    {
        public int LanguageId { get; set; }
        public int RevisionId { get; set; }
        public bool Expanded { get; set; }

        public virtual TbLanguage Language { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
