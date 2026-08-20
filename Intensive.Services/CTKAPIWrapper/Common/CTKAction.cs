using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// The CTKAction class is derived from the <see cref=" CTKQuery"/> class and is used to 
    /// execute methods on CORE CTK objects.  The response is returned in a <see cref=" CTKActionResponse"/>
    /// object.
    /// </summary>
    /// <example>
    /// example that logs into CORE adds a public message to a ticket then logs out of CORE
    /// <code>
    ///   static void Main(string[] args)
    ///    {
    ///        CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
    ///
    ///        CTKWhereCondition expWhere = new CTKWhereCondition("number", "=", "140128-00573");
    ///
    ///        CTKWhere wh = new CTKWhere();
    ///        wh.ClassName = "Ticket.TicketWhere";
    ///        wh.Values = expWhere;
    ///
    ///        string msg = "Ticket is being updated by the CTKAPI";
    ///
    ///        wh.ClassName = "Ticket.TicketWhere";
    ///        wh.Values = expWhere;
    ///
    ///        CTKAction req = new CTKAction();
    ///        req.ClassName = "Ticket.Ticket";
    ///        req.LoadArgs = wh;
    ///        req.MethodName = "addMessage";
    ///
    ///        //submit the request, with arguments for the "addMessage" method
    ///        CTKActionResponse resp = core.Submit(req, msg, 3);
    ///      
    ///        core.Logout();
    ///
    ///    }
    /// </code>
    /// </example>
    public class CTKAction : CTKQuery
    {
        private Dictionary<string, object> _setattributes = new Dictionary<string,object>();

        /// <summary>
        /// <para>Does not support using a CTK object per the CTKAPI docs
        /// as shown in Example 2 at https://ws.core.rackspace.com/ctkapi/doc/query/ under the
        /// <b>set_attribute: Changing an Attribute</b> section
        /// </para>
        /// <para>
        /// MethodName, SetAttributes, and MetaAction are mutually exclusive.
        /// </para>
        /// </summary>
        public Dictionary<string, object> SetAttributes { 
        
            get {return _setattributes;} 
            set
            {
                if ((this.MethodName != string.Empty) || (this.MetaAction != string.Empty))
                {
                    throw new CTKMutuallyExclusiveOptionsException("MethodName, SetAttributes, and MetaAction are mutually exclusive.");
                }
                else
                {
                    _setattributes = value;
                }
            }

        } 

        private string _method = string.Empty;
        /// <summary>
        /// The Method to execute.  
        /// MethodName, SetAttributes, and MetaAction are mutually exclusive.
        /// </summary>
        public string MethodName {
            get { return _method; }
            set
            {
                if ((this.SetAttributes.Count > 0) || (this.MetaAction != string.Empty))
                {
                    throw new CTKMutuallyExclusiveOptionsException("MethodName, SetAttributes, and MetaAction are mutually exclusive.");
                }
                else
                {
                    _method = value;
                }
            }
        }

        List<object> _methodArgs = new List<object>();
        /// <summary>
        /// The list of arguments to be passed to MethodName
        /// </summary>
        public List<object> MethodArguments
        {
            get { return _methodArgs; }
            set { _methodArgs = value; }
        }

        private string _meta = string.Empty;
        /// <summary>
        /// only COUNT and GROUPED_COUNT are supported at this time
        /// MethodName, SetAttributes, and MetaAction are mutually exclusive.
        /// </summary>
        public string MetaAction {
            get { return _meta; }
            set
            {
                if ((this.SetAttributes.Count > 0) || (this.MethodName != string.Empty))
                {
                    throw new CTKMutuallyExclusiveOptionsException("MethodName, SetAttributes, and MetaAction are mutually exclusive.");
                }
                else
                {
                    _meta = value;
                }
            }
        }  

        /// <summary>
        /// Many times when executing a method, the response will return a CTK Object, however you may
        /// wish to view particular attributes of that object just as you would via the "attributes" property
        /// on a <see cref=" CTKQuery"/> object.
        /// 
        /// This can be achieved by populating the "result_map" property.
        /// The key is a display name for the atrribute, and the value is the attribute name
        /// </summary>
        public Dictionary<string, string> ResultMap { get; set; }

        /// <summary>
        /// Converts the CTKQuery object to a JSON string
        /// </summary>
        /// <returns>a JSON string representing the query</returns>
        public override string  ToString()
        {
            //return base.ToString();
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            sb.Append("\"class\":\"");
            sb.Append(this.ClassName);
            sb.Append("\",");


            sb.Append("\"load_arg\":");

            string argType = this.LoadArgs.GetType().ToString().ToLower();
            switch (argType)
            {
                case "system.string":
                    sb.Append("\"");
                    sb.Append((string)this.LoadArgs);
                    sb.Append("\"");
                    break;

                case "system.int32":
                case "system.int64":
                    sb.Append(this.LoadArgs.ToString());
                    break;

                case "system.boolean":
                    sb.Append(((bool)this.LoadArgs)?"1":"0");
                    break;

                case "rackspace.ctkapi.net.ctkwhere":
                    sb.Append(this.LoadArgs.ToString());
                    break;
            }

            object o = string.Empty;

            if (this.SetAttributes.Count > 0)
            {
                sb.Append(",\"set_attribute\":");
                sb.Append(JsonConvert.SerializeObject(this.SetAttributes));
            }

            if (this.MethodName != string.Empty)
            {
                sb.Append(",\"method\":\"");
                sb.Append(this.MethodName);
                sb.Append("\"");

                sb.Append(",\"args\":[");
                


                if (this.MethodArguments.Count > 0)
                {
                    o = this.MethodArguments[0];
                    argType = o.GetType().ToString().ToLower();
                    switch (argType)
                    {
                        case "system.string":
                            sb.Append("\"");
                            sb.Append(o);
                            sb.Append("\"");
                            break;

                        case "system.int32":
                        case "system.int64":
                            sb.Append(o);
                            break;


                        case "system.boolean":
                            sb.Append(((bool)o) ? "1" : "0");
                            break;

                        case "system.int32[]":
                        case "system.int64[]":
                            sb.Append("[");
                            sb.Append(string.Join(",",(int[])o));
                            sb.Append("]");
                            break;
                    }
                                        
                    for (int i = 1; i < this.MethodArguments.Count; i++)
                    {
                        sb.Append(",");
                        o = this.MethodArguments[i];
                        
                        if (o == null) 
                        {
                            sb.Append("null");
                            continue; 
                        }

                        argType = o.GetType().ToString().ToLower();
                        switch (argType)
                        {
                            case "system.string":
                                sb.Append("\"");
                                sb.Append(o);
                                sb.Append("\"");
                                break;

                            case "system.int32":
                            case "system.int64":
                                sb.Append(o);
                                break;

                            case "system.boolean":
                                sb.Append(((bool)o) ? "1" : "0");
                                break;
                            
                            case "system.int32[]":
                            case "system.int64[]":
                                sb.Append("[");
                                sb.Append(string.Join(",",(int[])o));
                                sb.Append("]");
                                break;
                        }
                    }
                }
                sb.Append("]");

                sb.Append(",\"keyword_args\":{}");
            }//methodname

            if (this.MetaAction != string.Empty)
            {
                sb.Append(",\"meta\":\"");
                sb.Append(this.MetaAction);
                sb.Append("\"");
            }

            if ( (this.ResultMap != null) && (this.ResultMap.Count > 0) )
            {
                sb.Append(JsonConvert.SerializeObject(this.ResultMap));
            }


            if ( (this.Attributes != null) && (this.Attributes.Count > 0) )
            {
                sb.Append(",\"attributes\":");
                sb.Append("[\"");
                sb.Append(string.Join("\",\"", this.Attributes));
                sb.Append("\"]");
            }
            sb.Append("}");

            return sb.ToString();

        }
    }
}
