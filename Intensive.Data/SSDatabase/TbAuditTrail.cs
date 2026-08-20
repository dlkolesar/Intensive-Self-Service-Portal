using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbAuditTrail
    {
        public int Id { get; set; }
        public int SystemId { get; set; }
        public int? DeviceNumber { get; set; }
        public int? Account { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public string Detail { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
