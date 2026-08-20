using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbImplicitCategory
    {
        public int CategoryId { get; set; }
        public int SubscriptionId { get; set; }
        public bool DeltaSync { get; set; }
        public string CategoryType { get; set; }

        public virtual TbCategory Category { get; set; }
    }
}
