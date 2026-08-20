using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Aric
{
    public class AricNotFoundException: AricException
    {
        public AricNotFoundException() : base() { }

        public AricNotFoundException(string msg) : base(msg) { }

        public AricNotFoundException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
