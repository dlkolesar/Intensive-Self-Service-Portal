using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbLocalizedPropertyForRevision
    {
        public int RevisionId { get; set; }
        public int LocalizedPropertyId { get; set; }
        public int LanguageId { get; set; }

        public virtual TbLanguage Language { get; set; }
        public virtual TbLocalizedProperty LocalizedProperty { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
