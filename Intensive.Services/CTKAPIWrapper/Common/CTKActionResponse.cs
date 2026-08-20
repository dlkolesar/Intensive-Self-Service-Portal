using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// The CTKResponse class holds the response from a <see cref="CTKAction"/>
    /// </summary>
    public class CTKActionResponse: CTKResponse
    {
        /// <summary>
        /// a boolean value indicating if the request was successful or not
        /// </summary>
        public bool Success { get; set; }

       
    }
}
