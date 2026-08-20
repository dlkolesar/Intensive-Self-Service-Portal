using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbMoreInfoUrlforRevision
    {
        public int RevisionUrlid { get; set; }
        public int RevisionId { get; set; }
        public string MoreInfoUrl { get; set; }
        public string ShortLanguage { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
