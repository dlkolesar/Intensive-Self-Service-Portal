using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDriver
    {
        public int RevisionId { get; set; }
        public string HardwareId { get; set; }
        public DateTime DriverVerDate { get; set; }
        public long DriverVerVersion { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Provider { get; set; }
        public int ClassId { get; set; }
        public long WhqlDriverId { get; set; }
        public string Company { get; set; }

        public virtual TbDriverClass Class { get; set; }
        public virtual TbRevision Revision { get; set; }
    }
}
