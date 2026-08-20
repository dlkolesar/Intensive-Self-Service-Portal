using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.Exceptions
{
    public class PatchingWSUSNotFoundException : Exception
    {
        public PatchingWSUSNotFoundException() : base() { }
        public PatchingWSUSNotFoundException(string message) : base(message) { }
        public PatchingWSUSNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
