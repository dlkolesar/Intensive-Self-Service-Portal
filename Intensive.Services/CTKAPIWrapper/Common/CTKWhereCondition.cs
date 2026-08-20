using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// represents a condition that the returned data must meet.
    /// </summary>
    public class CTKWhereCondition
    {
        /// <summary>
        /// The left side of the condition
        /// 
        /// This could be a simple object attribute or another CTKWhereCondition
        /// </summary>
        public object Left { get; set; }

        /// <summary>
        /// if <b>Left</b> is a simple object attribute, then
        /// the operator is a valid SQL operator including  =, &gt;, &gt;=, &lt;, &lt;=, in, &gt;&lt;, is
        /// 
        /// If <b>Left</b> is a CTKWhereCondition then Operator is either &amp; (logical AND) or  | (Logical OR)
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// the right side of the condition.
        /// If <b>Left</b> is a CTKWhereCondition then <b>Right</b> must also be a CTKWhereCondition, 
        /// otherwise an exception will be thrown
        /// </summary>
        public object Right { get; set; }


        /// <summary>
        /// Constructs a where condition based on the values provided
        /// </summary>
        /// <param name="attr">The left side of the condition</param>
        /// <param name="op">the operator to be applied</param>
        /// <param name="val">The right side of the condition</param>
        /// <exception cref="CTKInvalidOperatorException">
        /// Thrown if :<list type="bullet">
        /// <item>an invalid operator is specified</item>
        /// </list>
        /// </exception>
        /// <exception cref="CTKInvalidConditionException">
        /// Thrown if :<list type="bullet">
        /// <item><b>Left</b> is a CTKWhereCondtion and <b>Right</b> is not</item>
        /// <item><b>Left</b> is not a string and not a CTKWhereCondition object</item>
        /// </list>
        /// </exception>
         public CTKWhereCondition(object attr, string op, object val)
        {
            List<string> ValidOperators = new List<string>();

            if (attr is CTKWhereCondition)
            {
                ValidOperators = new List<string> { "&", "|" };

                //if left side is a CTKWhereCondition object, then the 
                // the right side must also be a CTKWhereCondition object
                if (!(val is CTKWhereCondition))
                {
                    throw new CTKInvalidConditionException("Right side of WhereCondition is not valid. The Right side should also a be CTKWhereCondition object");
                }
            }
            else
            {
                if (attr is string)
                {
                    ValidOperators = new List<string> { "=", ">", ">=", "<", "<=", "in", "<>", "is","like"};
                }
                else
                {
                    throw new CTKInvalidConditionException("Left side of WhereCondition is not valid.  ");
                }
            }

            if (!ValidOperators.Contains(op))
            {
                throw new CTKInvalidOperatorException("'" + op + "' is not a valid operator for this WhereCondition");
            }

            this.Left = attr;
            this.Operator = op;
            this.Right = val;
        }


        /// <summary>
        /// returns the JSON representation of the condition        
         /// </summary>
        /// <returns>a JSON string representing the condition</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            //String the left side of the condition
            if (this.Left is CTKWhereCondition)
            {
                sb.Append("[");
                sb.Append(this.Left.ToString());
                sb.Append("]");
                sb.Append(",");
                
            }
            else
            {
                sb.Append("\"");
                sb.Append((string)Left);
                sb.Append("\",");

            }


            //String the operator
            sb.Append("\"");
            sb.Append(this.Operator);
            sb.Append("\",");


            //String the right side of the condition
            string argType = this.Right.GetType().ToString().ToLower();
            switch (argType)
            {
                case "system.boolean":
                    sb.Append(((bool)this.Right) ? "1" : "0");
                    break;

                case "system.string":
                    sb.Append("\"");
                    sb.Append(this.Right);
                    sb.Append("\"");
                    break;

                case "system.string[]":
                    sb.Append("[");
                    sb.Append("\"");
                    sb.Append(string.Join("\",\"", (string[])this.Right));
                    sb.Append("\"");
                    sb.Append("]");
                    break;

                case "system.int32":
                case "system.int64":
                    sb.Append((int)this.Right);
                    break;

                case "system.int32[]":
                case "system.int64[]":
                    sb.Append("[");
                    sb.Append(string.Join(",", (int[])this.Right));
                    sb.Append("]");
                    break;

                case "intensive.services.ctkapiwrapper.ctkwherecondition":
                    sb.Append("[");
                    sb.Append(this.Right.ToString());
                    sb.Append("]");
                    break;
            }
            //sb.Append("]");

            
            return sb.ToString();
        }
    }
}
