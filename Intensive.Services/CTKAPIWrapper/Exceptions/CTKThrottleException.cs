using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.Exceptions
{
    /// <summary>
    /// This error is returned if you exceed the throttle limits.
    /// It does not indicate an issue with the API, but means that caller should take steps to reduce the
    /// number and/or frequency of requests.
    /// Refer to <a href="https://ws.core.rackspace.com/ctkapi/?page=Throttling%20and%20Caching">CORE CTKAPI docs</a> for more information
    /// This will return a Status Code of 503.
    /// </summary>
    public class CTKThrottleException : CTKHttpException
    {
                /// <summary>
        /// initializes a new instance of the class
        /// </summary>
        public CTKThrottleException() : base() { }

        /// <summary>
        /// Initializes a new instance of the class with a specified error message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public CTKThrottleException(string msg) : base(msg) { }


        /// <summary>
        /// Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CTKThrottleException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
