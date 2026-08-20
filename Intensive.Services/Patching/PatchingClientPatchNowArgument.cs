using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.Patching
{
    public class PatchingClientPatchNowArguments
    {
        public DateTime? Endtime { get; set; }
        public bool DownloadPatches { get; set; }
        public bool InstallPatches { get; set; }
        public bool Reboot { get; set; }
        public bool ForceReboot { get; set; }

        public PatchingClientPatchNowArguments()
        {

        }
    }
}
