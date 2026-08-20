using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.API.Global
{
    public class APICollection
    {
        public int Count
        {
            get { return Resources.Count;  }
            internal set { }
        }

        public List<string> Resources { get; internal set; }

        public APICollection()
        {
            this.Resources = new List<string>();
        }
    }
}
