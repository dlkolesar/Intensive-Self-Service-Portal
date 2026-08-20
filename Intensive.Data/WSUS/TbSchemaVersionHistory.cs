using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbSchemaVersionHistory
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public string BuildNumber { get; set; }
        public int SchemaVersion { get; set; }
        public DateTime ArchivedTime { get; set; }
    }
}
