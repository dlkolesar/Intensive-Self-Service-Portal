using System;
using System.Collections.Generic;

namespace Intensive.Data.SSDatabase
{
    public partial class TbAdmigrations
    {
        public Guid Id { get; set; }
        public int Account { get; set; }
        public int TaskId { get; set; }
        public DateTime Submitted { get; set; }
        public string MigrationType { get; set; }
        public string Sso { get; set; }
        public string SourceDomain { get; set; }
        public string TargetOu { get; set; }
        public string Objects { get; set; }
        public string Status { get; set; }
    }
}
