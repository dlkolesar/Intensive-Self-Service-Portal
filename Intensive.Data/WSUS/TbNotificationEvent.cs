using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbNotificationEvent
    {
        public int NotificationEventId { get; set; }
        public string NotificationEventName { get; set; }
        public int State { get; set; }
        public Guid RowId { get; set; }
    }
}
