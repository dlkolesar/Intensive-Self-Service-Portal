using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class PreviewFileException: Exception
    {
        public PreviewFileException() : base() { }
        public PreviewFileException(string msg) : base(msg) { }
        public PreviewFileException(string msg, Exception innerException) : base(msg, innerException) { }

    }
    public class CoreTicketException : Exception
    {
        public CoreTicketException() : base() { }
        public CoreTicketException(string msg) : base(msg) { }
        public CoreTicketException(string msg, Exception innerException) : base(msg, innerException) { }

    }
    public class TranslationException : Exception
    {
        public TranslationException() : base() { }
        public TranslationException(string msg) : base(msg) { }
        public TranslationException(string msg, Exception innerException) : base(msg, innerException) { }

    }
}
