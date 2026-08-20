using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.Exceptions
{
    /// <summary>
    /// Thrown when a <see cref=" CTKWhereCondition"/> is contains an invalid operator
    /// </summary>
    public class CTKInvalidOperatorException:Exception
    {
        /// <summary>
        /// initializes a new instance of the class
        /// </summary>
        public CTKInvalidOperatorException() : base() { }

        /// <summary>
        /// Initializes a new instance of the class with a specified error message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public CTKInvalidOperatorException(string msg):base(msg){}

        /// <summary>
        /// Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CTKInvalidOperatorException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
