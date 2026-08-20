using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbPrerequisiteDependency
    {
        public int RevisionId { get; set; }
        public int PrerequisiteLocalUpdateId { get; set; }
        public int PrerequisiteRevisionId { get; set; }
    }
}
