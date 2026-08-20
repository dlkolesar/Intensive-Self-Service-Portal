using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbLocalizedProperty
    {
        public TbLocalizedProperty()
        {
            TbLocalizedPropertyForRevision = new HashSet<TbLocalizedPropertyForRevision>();
        }

        public int LocalizedPropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseNote { get; set; }

        public virtual ICollection<TbLocalizedPropertyForRevision> TbLocalizedPropertyForRevision { get; set; }
    }
}
