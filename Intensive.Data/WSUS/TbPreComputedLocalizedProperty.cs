using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbPreComputedLocalizedProperty
    {
        public int PreComputedLocalizedPropertyId { get; set; }
        public string ShortLanguage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseNotes { get; set; }
        public Guid? UpdateId { get; set; }
        public int? RevisionNumber { get; set; }
        public int? RevisionId { get; set; }

        public virtual TbRevision Revision { get; set; }
    }
}
