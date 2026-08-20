using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbCategoryInSubscription = new HashSet<TbCategoryInSubscription>();
            TbFlattenedRevisionInCategory = new HashSet<TbFlattenedRevisionInCategory>();
            TbImplicitCategory = new HashSet<TbImplicitCategory>();
            TbPrecomputedCategoryLocalizedProperty = new HashSet<TbPrecomputedCategoryLocalizedProperty>();
            TbRevisionInCategory = new HashSet<TbRevisionInCategory>();
        }

        public int CategoryIndex { get; set; }
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string CategoryType { get; set; }
        public DateTime LastChange { get; set; }
        public bool ProhibitsSubcategories { get; set; }
        public bool ProhibitsUpdates { get; set; }
        public int? DisplayOrder { get; set; }

        public virtual ICollection<TbCategoryInSubscription> TbCategoryInSubscription { get; set; }
        public virtual ICollection<TbFlattenedRevisionInCategory> TbFlattenedRevisionInCategory { get; set; }
        public virtual ICollection<TbImplicitCategory> TbImplicitCategory { get; set; }
        public virtual ICollection<TbPrecomputedCategoryLocalizedProperty> TbPrecomputedCategoryLocalizedProperty { get; set; }
        public virtual ICollection<TbRevisionInCategory> TbRevisionInCategory { get; set; }
        public virtual TbUpdate Category { get; set; }
        public virtual TbCategoryType CategoryTypeNavigation { get; set; }
        public virtual TbCategory ParentCategory { get; set; }
        public virtual ICollection<TbCategory> InverseParentCategory { get; set; }
    }
}
