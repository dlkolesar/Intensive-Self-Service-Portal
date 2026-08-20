using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbInventoryRule
    {
        public Guid RuleId { get; set; }
        public string Version { get; set; }
        public string RuleXml { get; set; }
    }
}
