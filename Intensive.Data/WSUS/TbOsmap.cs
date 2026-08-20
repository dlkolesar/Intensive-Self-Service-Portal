using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbOsmap
    {
        public byte Osid { get; set; }
        public short OsmajorVersion { get; set; }
        public short OsminorVersion { get; set; }
        public short OsbuildNumber { get; set; }
        public short OsservicePackMajorNumber { get; set; }
        public short OsservicePackMinorNumber { get; set; }
        public string ProcessorArchitecture { get; set; }
        public string OsshortName { get; set; }
        public string OslongName { get; set; }
    }
}
