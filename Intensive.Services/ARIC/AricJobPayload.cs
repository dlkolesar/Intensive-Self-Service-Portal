using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Aric
{
    public class AricJobPayload
    {
        public int Tenant { get; set; }
        public List<AricTarget> Targets { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public object Metadata { get; set; }

        public AricJobPayload()
        {
            this.Targets = new List<AricTarget>();
        }
    }

    public class ARICTarget
    {
        public string Href { get; set; }
        public string Rel { get; set; }
    }

    public class ARICDedicatedTarget: AricTarget
    {
        public ARICDedicatedTarget(int deviceNumber)
        {
            this.href = $"http://core.rackspace.com/py/core/#/device/{deviceNumber}";
            this.rel = $"http://schemas.automation.rackspacecloud.com/targets/device";
        }
    }



}
