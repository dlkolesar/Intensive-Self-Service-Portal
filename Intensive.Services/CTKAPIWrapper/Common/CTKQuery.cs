using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// The CTKQuery class provides properties and methods to build complex queries to 
    /// fetch data from CORE
    /// </summary>
    /// <example>
    /// example that Logs in, builds a query, executes it, shows the results, and logs out
    /// <code>
    ///using System;
    ///using System.Collections.Generic;
    ///using System.Linq;
    ///using System.Text;
    ///using Rackspace.CTKAPI;
    ///
    ///namespace CTKAPI
    ///{
    ///    class Program
    ///    {
    ///        static void Main(string[] args)
    ///        {
    ///             CTKAPI core = new CTKAPI(joe.racker", "I&lt;3Unicorns");
    ///
    ///            //show user info
    ///            CTKUser u = core.GetUser(token);
    ///
    ///            //build a query to get tickets in Feedback Received status 
    ///            // and in one of the segment support queues
    ///            CTKWhereCondition expWhereQueue = new CTKWhereCondition("queue", "in", new int[] { 554, 572, 176, 181 });
    ///            CTKWhereCondition expWhereStatus = new CTKWhereCondition("status_name", "=", "Feedback Received");
    ///            CTKWhere wh = new CTKWhere();
    ///            wh.ClassName = "Ticket.TicketWhere";
    ///            wh.Values = new CTKWhereCondition(expWhereQueue, "&amp;", expWhereStatus);
    ///
    ///            CTKQuery req = new CTKQuery();
    ///            req.ClassName = "Ticket.Ticket";
    ///            req.LoadArgs = wh;
    ///            req.Attributes = new List&lt;string&gt;() {   "number", 
    ///                                                "account.number",
    ///                                                "account.name",
    ///                                                "assignee.name",
    ///                                                "queue.name",
    ///                                            };
    ///
    ///            //submit the request
    ///            CTKResponse resp = core.Submit(req);
    ///
    ///            string fmt = "{0,-12} {1,-7} {2,-30} {3,-35} {4,-20}\r\n";
    ///            string s = string.Format(fmt, "Ticket",
    ///                                          "Account",
    ///                                          "Account Name",
    ///                                          "Assigned To",
    ///                                          "Queue Name"
    ///                                       );
    ///            Console.WriteLine(s);
    ///            
    ///            foreach (Dictionary&lt;string, object&gt; d in resp.Results)
    ///            {
    ///                s = string.Format(fmt, (d["number"] == null) ? string.Empty : d["number"].ToString(),
    ///                                         (d["account.number"] == null) ? string.Empty : d["account.number"].ToString(),
    ///                                         (d["account.name"] == null) ? string.Empty : d["account.name"].ToString(),
    ///                                         (d["assignee.name"] == null) ? string.Empty : d["assignee.name"].ToString(),
    ///                                         (d["number"] == null) ? string.Empty : d["queue.name"].ToString()
    ///                                 );
    ///
    ///                Console.WriteLine(s);
    ///            }
    ///
    ///
    ///            //logout of CORE
    ///            core.Logout(token);
    ///        }
    ///
    ///    }
    ///}
    ///
    /// //Output:
    /// Ticket		 Account Account Name					Assigned To				Queue Name
    /// 131023-07793 1786196 Mint Wireless Australia        joe.racker        		Segment Support
    /// 131120-12736 1036207 Acutech Group        									Segment Support
    /// 131130-01701 34823   Global Net Services, Inc       jane.racker        		Segment Support
    /// 131204-09800 884123  Positive Technology        							Segment Support
    /// 131205-06664 1792843 Right Star Systems        								Segment Support
    /// 131209-10216        														Segment Support
    /// </code>
    /// </example>

    public class CTKQuery
    {
 #region Properties
        /// <summary>
        /// Consists of a string in the following format: "module.classname".
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// <para> The load_method parameter specifies the method called on the class to load an instance
        /// of the CKT object. This parameter is optional, and the API should be able to determine
        /// the correct method based upon the value of load_arg. This is provided in case the
        /// load method needs to be overridden for any reason.
        /// </para>
        /// <para>The most common load methods are: "load" and "loadList".</para>
        /// <list type="bullet">
        ///   <item>
        ///     <strong>load</strong> is used when loading a single instance and will always return a single CTK object.
        ///   </item>
        ///   <item>
        ///     <strong>loadList</strong> can return a list of objects based upon the load_arg as defined below.
        ///   </item>
        ///   <item>
        ///     <strong>loadQueueView</strong> is a special load_method that will load tickets that exist in a QueueView
        ///   </item>
        /// </list>
        /// <para>
        /// <strong>Note:</strong>Only class methods that start with "load" can be passed to this parameter.
        /// </para>
        /// </summary>
        public string LoadMethod { get; set; }

        /// <summary>
        /// The load_arg parameter provides the definition used when selecting which CTK object(s) to load.
        /// As described in the schema, load_arg can be in one of three formats:
        /// <list type="bullet">
        ///   <item>
        ///     <term>string</term>
        ///     <description>This will load a single instance of a CTK object where the provided string is the load_value of a
        ///classes load_key, such as a ticket number.</description>
        ///    </item>
        ///    <item>
        ///         <term>Number</term>
        ///         <description>This will usually be the ID of an object, such as an account number or device number</description>
        ///     </item>
        ///     <item>
        ///         <term>a <see cref="CTKWhere"/> object</term>
        ///         <description>an object that encapsulates a set of complex conditions that are used to determine what 
        ///         object(s) to return</description>
        ///     </item>
        /// </list>
        /// </summary>
        public object LoadArgs { get; set; }

        /// <summary>
        /// specifies the attributes of the object(s) to be returned
        /// </summary>
        public List<string> Attributes { get; set; }

        /// <summary>
        /// The "limit" parameter allows you to limit the number of CTK objects returned. If your requests are
        /// taking a long time to complete, you probably want to lower the limit and perform your operations in
        /// batches.
        /// If no limit is provided or the provided limit exceeds the system limit set by the API, the limit will be
        /// reduced to the default system limit of 250.
        /// </summary>
        // public int Limit { get; set; }

        /// <summary>
        /// The offset provides the objects returned by the query offset by provided amount. For example, if a query
        /// might return 100 items, an offset of 0 with a limit of 10 will return items 1-10, and an offset of 10
        /// would return item 11-20.
        /// If no offset is provided, the offset defaults to 0.
        /// </summary>
        //  public int Offset { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Creates a new, empty instance 
        /// </summary>
        public CTKQuery()
        {
            //this.Limit = 250;
            //this.Offset = 0;
            this.Attributes = new List<string>();
        }

        /// <summary>
        /// Converts the CTKQuery object to a JSON string, more specifically, it is the JSON string that is passed
        /// to the CORE CTKAPI
        /// </summary>
        /// <returns>a JSON string representing the query</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            sb.Append("\"class\":\"");
            sb.Append(this.ClassName);
            sb.Append("\",");
            sb.Append("\"load_arg\":");

            string argType = this.LoadArgs.GetType().ToString().ToLower();
            switch(argType)
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
                    sb.Append(((bool)this.LoadArgs) ? "1" : "0");
                    break;

                case "intensive.services.ctkapiwrapper.ctkwhere":
                    sb.Append(this.LoadArgs.ToString());
                    break;
            }

            if ((this.Attributes != null) && (this.Attributes.Count > 0))
            {
                sb.Append(",");
                sb.Append("\"attributes\":");
                sb.Append("[\"");
                sb.Append(string.Join("\",\"", this.Attributes));
                sb.Append("\"]");
            }
            //sb.Append("\"limit\":" + this.Limit.ToString() + ",");
            //sb.Append("\"offset\":" + this.Offset.ToString());
            sb.Append("}");

            return sb.ToString();
        }

       
    }
#endregion
}
