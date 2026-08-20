using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Aric
{
    public class AricException: Exception
    {
        public AricException() : base() { }

        public AricException(string msg) : base(msg) { }

        public AricException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
