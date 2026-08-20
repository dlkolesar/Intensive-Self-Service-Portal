using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbLocaleMap
    {
        public byte LocaleId { get; set; }
        public int Lcid { get; set; }
        public string LocaleName { get; set; }
        public string LocaleLongName { get; set; }
    }
}
