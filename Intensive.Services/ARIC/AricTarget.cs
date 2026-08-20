using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Aric
{
    public class AricTarget
    {
        public string href { get; set; }
        public string rel { get; set; }

        public AricTarget() { }

        public AricTarget(int deviceNumber)
        {
            this.href = $"http://core.rackspace.com/py/core/#/device/{deviceNumber}";
            this.rel = "http://schemas.automation.rackspacecloud.com/targets/device";
        }
        public AricTarget(string dc, int tenant, string instance)
        {
            this.href = $"https://{dc}.servers.api.rackspacecloud.com/v2/{tenant}/servers/{instance}";
            this.rel = "http://schemas.automation.rackspacecloud.com/targets/device";
        }
    }
}
