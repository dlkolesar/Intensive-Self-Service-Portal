using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class PatchingConfiguration
    {
        
        public StringBuilder PatchingConfig;
        public List<int> DeviceList;

        public PatchingConfiguration()
        {
            this.PatchingConfig = new StringBuilder();
            this.DeviceList = new List<int>();
        }
    }
}
