using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.Exceptions
{
    /// <summary>
    /// These errors indicate that either a request lacks a valid authentication token via X-Auth header or cookie, or that the
    /// credentials provided to the login method are not valid.
    /// The exception message will provide information on why this status was returned.
    /// This will return a HttpStatus of 403. 
    /// </summary>
    public class CTKAuthenticationException : CTKHttpException
    {
        /// <summary>
        /// initializes a new instance of the class
        /// </summary>
        public CTKAuthenticationException() : base() { }

        /// <summary>
        /// Initializes a new instance of the class with a specified error message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public CTKAuthenticationException(string msg) : base(msg) { }


        /// <summary>
        /// Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CTKAuthenticationException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
