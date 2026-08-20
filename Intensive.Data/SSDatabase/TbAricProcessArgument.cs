using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbAricProcessArgument
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Description { get; set; }
    }
}
