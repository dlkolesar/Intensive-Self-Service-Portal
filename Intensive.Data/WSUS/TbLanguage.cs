using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbLanguage
    {
        public TbLanguage()
        {
            TbEulaProperty = new HashSet<TbEulaProperty>();
            TbLanguageInSubscription = new HashSet<TbLanguageInSubscription>();
            TbLocalizedPropertyForRevision = new HashSet<TbLocalizedPropertyForRevision>();
            TbRevisionLanguage = new HashSet<TbRevisionLanguage>();
        }

        public int LanguageIndex { get; set; }
        public int LanguageId { get; set; }
        public string ShortLanguage { get; set; }
        public string LongLanguage { get; set; }
        public bool UssEnabled { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreateTime { get; set; }
        public long LanguageAnchor { get; set; }
        public int FullTextLcid { get; set; }

        public virtual ICollection<TbEulaProperty> TbEulaProperty { get; set; }
        public virtual ICollection<TbLanguageInSubscription> TbLanguageInSubscription { get; set; }
        public virtual ICollection<TbLocalizedPropertyForRevision> TbLocalizedPropertyForRevision { get; set; }
        public virtual ICollection<TbRevisionLanguage> TbRevisionLanguage { get; set; }
    }
}
