using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.Exceptions
{
    public class PatchingNotFoundException : Exception
    {
        public PatchingNotFoundException() : base() { }
        public PatchingNotFoundException(string message) : base(message) { }
        public PatchingNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
