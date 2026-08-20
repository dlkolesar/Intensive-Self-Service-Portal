using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// The CTKResponse class holds the response from a <see cref="CTKQuery"/>
    /// </summary>
    public class CTKResponse
    {
        /// <summary>
        /// The HTTP Status code returned by the CORE CTAKAPI web service
        /// </summary>
        public int StatusCode { get; set; }


        /// <summary>
        /// Error message returned by the CORE CTAKAPI web service
        /// </summary>
        public string ErrorMessage { get; set; }


        /// <summary>
        /// the raw JSON string returned by the request to the CORE CTAKAPI web service
        /// </summary>
        public string jsonResult { get; internal set; }

        /// <summary>
        /// The <b>jsonResult</b> property parsed into one of the following objects:
        /// <list type="bullet">
        ///     <item>a <see cref="CTKResultDictionary"/></item>
        ///     <item>a <see cref="CTKResultTuple"/></item>
        /// </list>
        /// </summary>

        public object Results { get; internal set; }

        /// <summary>
        /// The number items in the Results property
        /// </summary>
        public int Count { get; set; }
    }
}
