using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching
{
    public class AricMetadataPushSettings
    {
        public string DeviceId { get; set; }
        public string WinPatchUrl { get; set; }
        public string Base64Json { get; set; }
        public string SsoUserName { get; set; }

        public AricMetadataPushSettings()
        {

        }
    }   
}

