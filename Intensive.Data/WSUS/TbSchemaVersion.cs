using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbSchemaVersion
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }
        public string BuildNumber { get; set; }
        public int SchemaVersion { get; set; }
    }
}
