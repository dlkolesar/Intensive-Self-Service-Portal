using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Aric
{
    public class AricProcessException : AricException
    {
        public AricProcessException() : base() { }

        public AricProcessException(string msg) : base(msg) { }

        public AricProcessException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
