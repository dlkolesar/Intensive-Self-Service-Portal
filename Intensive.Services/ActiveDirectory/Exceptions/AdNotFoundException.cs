using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.ActiveDirectory
{
    public class ADNotFoundException : Exception
    {
        public ADNotFoundException() : base() { }

        public ADNotFoundException(string message) : base(message) { }


        public ADNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
