using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbCategoryType
    {
        public TbCategoryType()
        {
            TbCategory = new HashSet<TbCategory>();
            TbPrecomputedCategoryLocalizedProperty = new HashSet<TbPrecomputedCategoryLocalizedProperty>();
        }

        public string CategoryType { get; set; }
        public int Level { get; set; }

        public virtual ICollection<TbCategory> TbCategory { get; set; }
        public virtual ICollection<TbPrecomputedCategoryLocalizedProperty> TbPrecomputedCategoryLocalizedProperty { get; set; }
    }
}
