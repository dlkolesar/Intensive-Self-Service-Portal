using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.Aric
{
    public class AricMetadataPatchNow
    {
        public string DeviceId { get; set; }
        public string WinPatchUrl { get; set; }
        public string SsoUserName { get; set; }
        public DateTime? Endtime { get; set; }
        public bool DownloadPatches { get; set; }
        public bool InstallPatches { get; set; }
        public bool Reboot { get; set; }
        public bool ForceReboot { get; set; }
        public string TriggeredBy { get; set; }
        public string StreamId { get; set; }

        public AricMetadataPatchNow()
        {
            this.TriggeredBy = "portal";
            this.WinPatchUrl = "";
        }
    }
}
