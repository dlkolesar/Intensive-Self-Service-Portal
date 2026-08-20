using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Intensive.Services.CTKAPIWrapper.Exceptions
{

    /// <summary>
    /// TheIntensive.Services.CTKAPIWrapper.Exceptions contains all of the custom exceptions that can be 
    /// thrown by the CTKAPI.Net library.
    /// </summary>
    internal static class NamespaceDoc { }    //dummy class used to generate Namespace documentation




    ///<summary>
    ///Base Exceptions class from which other, more specific, exceptions are derived
    ///</summary>
    public class CTKHttpException : Exception
    {
        /// <summary>
        /// The HTTP Status code returned by the web server
        /// </summary>
        public HttpStatusCode  HttpStatus { get; set; }

        /// <summary>
        /// The short HTTP Status Description
        /// </summary>
        public string HttpStatusDescription { get; set; }

        /// <summary>
        /// initializes a new instance of the class
        /// </summary>
        public CTKHttpException() : base() { }

        /// <summary>
        /// Initializes a new instance of the class with a specified error message.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        public CTKHttpException(string msg) : base(msg) { }

        /// <summary>
        /// Initializes a new instance of the class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="msg">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public CTKHttpException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
