using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// The CTKWhere class represents a complex codition to filter the results of a query
    /// </summary>
    public class CTKWhere
    {
        /// <summary>
        /// The name of the CTKAPI WHERE class.  The classname is composed of the Module name and the 
        /// WHERE class name separated by a dot. e.g.  "Computer.ComputerWhere"
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// represents a condition or a complex set of conditions that the returned data must meet
        /// </summary>
        public CTKWhereCondition Values { get; set; }

        /// <summary>
        /// Used to limit the number of objects returned.  Hardcoded in CORE to a maximum of 250,
        /// but can be set lower by an application
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// When used with paging operations, this is the number of objects to skip before returning the next
        /// <b>Limit</b> objects
        /// </summary>
        public int Offset { get; set; }


        /// <summary>
        /// initializes a new instance of the class with default values
        /// </summary>
        public CTKWhere()
        {
            this.ClassName = string.Empty;
            this.Values = null;
            this.Limit = 0;
            this.Offset = 0;
        }


        /// <summary>
        /// returns the JSON string representation of the CTKWhere
        /// </summary>
        /// <returns>a JSON string</returns>
        public override string ToString()
        {
            //return base.ToString();

            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            sb.Append("\"class\":\"");
            sb.Append(this.ClassName);
            sb.Append("\",");
            
            
            sb.Append("\"values\":[");
            sb.Append(this.Values.ToString());
            sb.Append("]");

            if (this.Limit > 0)
            {
                sb.Append(",\"limit\":");
                sb.Append(this.Limit.ToString());
                if (this.Offset > 0)
                {
                    sb.Append(",\"offset\":");
                    sb.Append(this.Offset.ToString());
                }
            }
            sb.Append("}");

            return sb.ToString();
        }
    }
}
