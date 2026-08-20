using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbLanguageInSubscription
    {
        public int SubscriptionId { get; set; }
        public int LanguageId { get; set; }
        public bool DeltaSync { get; set; }

        public virtual TbLanguage Language { get; set; }
    }
}
