using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbTags
    {
        public int Id { get; set; }
        public int? Account { get; set; }
        public string Tag { get; set; }
    }
}
