using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.ActiveDirectory
{
    class ADConnectionException: Exception
    {
            public ADConnectionException() : base() { }
            public ADConnectionException(string message) : base(message) { }
            public ADConnectionException(string message, Exception innerException)
                : base(message, innerException) { }
    }
}
