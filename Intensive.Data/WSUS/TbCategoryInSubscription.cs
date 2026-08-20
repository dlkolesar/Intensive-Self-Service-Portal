using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbCategoryInSubscription
    {
        public int SubscriptionId { get; set; }
        public int CategoryId { get; set; }

        public virtual TbCategory Category { get; set; }
    }
}
