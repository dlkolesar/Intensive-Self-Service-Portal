using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbPrecomputedCategoryLocalizedProperty
    {
        public int CategoryId { get; set; }
        public string ShortLanguage { get; set; }
        public string Title { get; set; }
        public string CategoryType { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual TbCategoryType CategoryTypeNavigation { get; set; }
    }
}
