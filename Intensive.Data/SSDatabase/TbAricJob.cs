using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbAricJob
    {
        public Guid EventId { get; set; }
        public string ProcessName { get; set; }
        public int AccountNumber { get; set; }
        public int DeviceNumber { get; set; }
        public string State { get; set; }
        public string Message { get; set; }
        public string ReturnedData { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Completed { get; set; }
        public int SystemId { get; set; }
        public string UserId { get; set; }
    }
}
