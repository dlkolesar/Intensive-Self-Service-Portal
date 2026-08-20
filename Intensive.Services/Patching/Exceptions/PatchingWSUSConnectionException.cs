using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.Exceptions
{
    public class PatchingWSUSConnectionException : Exception
    {
        public PatchingWSUSConnectionException() : base() { }
        public PatchingWSUSConnectionException(string message) : base(message) { }
        public PatchingWSUSConnectionException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
