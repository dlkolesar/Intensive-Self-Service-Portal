using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.Common
{
    public class TagNotFoundException: Exception
    {
        public TagNotFoundException() : base() { }

        public TagNotFoundException(string msg) : base(msg) { }

        public TagNotFoundException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
