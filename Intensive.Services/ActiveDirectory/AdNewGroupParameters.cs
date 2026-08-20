using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.ActiveDirectory
{
    public class AdNewGroupParameters: AdNewObjectParameters
    {
        public AdGroupType GroupType { get; set; }
    }
}
