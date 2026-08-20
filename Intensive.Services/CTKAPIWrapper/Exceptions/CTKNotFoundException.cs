using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.Exceptions
{
    /// <summary>
    /// This error indicates that there is an error in the data provided to the API, or an unallowed action is requested.
    /// Sample reasons for this error include:
    /// <list type="bullet">
    ///     <item>Missing parameters in a request.</item>
    ///     <item>Passing the wrong type of data as a parameter.</item>
    ///     <item>Trying to modify a read-only attribute.</item>
    ///  </list>
    ///  
    ///  The exception message will provide information about the reason for the error.
    ///  A request that results in a this type of error should not be resubmitted without modifying the request.
    ///  This will return a Status Code of 400.
    /// </summary>
    public class CTKNotFoundException : CTKHttpException
    {
        /// <summary>
        /// initializes a new instance of the class
        /// </summary>
        public CTKNotFoundException() : base() { }

        /// <summary>
        /// Initializes a new instance of the class with a specified error message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public CTKNotFoundException(string msg) : base(msg) { }


        /// <summary>
        /// Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CTKNotFoundException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
