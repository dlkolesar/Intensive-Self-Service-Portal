using System;
using System.Collections.Generic;

using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Intensive.Services.CTKAPIWrapper;
using System.Reflection;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{

    


    /// <summary>
    /// The CTKAccount class represents a CORE account
    /// </summary>
    public class CTKAccount : CTKObject
    {
        //private CTKAPI ctk;

        /// <summary>
        /// The CORE Account number
        /// </summary>
        public int Number { get; internal set; }

        /// <summary>
        /// The CORE Account Name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// default constructor to create an empty object
        /// </summary>
        public CTKAccount() : base()
        {
            this.Number = 0;
            this.Name = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the CTKAccount class for the specified account 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="account">the account number to retrieve</param>
        /// <remarks>
        /// Only the Number and Name properties will be populated
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Example 1 -- Get account with no additional properties
        /// //	
        ///using System;
        ///using System.Collections.Generic;
        ///
        ///using Intensive.Services.CTKAPIWrapper;
        ///using Intensive.Services.CTKAPIWrapper.CTKObjects;
        ///
        ///namespace CTKAPITest.CLI
        ///{
        ///class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///
        ///            CTKAccount acct = new CTKAccount(core, 300007);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        /// 
        public CTKAccount(CTKAPI instance, int account) :base()
        {
            GetAccount(instance, account, new List<string>{ "number", "name" });
        }

        /// <summary>
        /// Initializes a new instance of the CTKAccount class for the specified account and populates the given properties 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="account">the account number to retrieve</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary.  The "name" and "number" properties will be automatically added</param>
        /// <example>
        /// <code>
        /// //
        /// // Get account with additional properties
        /// //	
        ///using System;
        ///using System.Collections.Generic;
        ///
        ///using Intensive.Services.CTKAPIWrapper;
        ///using Intensive.Services.CTKAPIWrapper.CTKObjects;
        ///
        ///namespace CTKAPITest.CLI
        ///{
        ///class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; { "account_exec.name", "segment_queue.name" };
        ///
        ///            CTKAccount acct = new CTKAccount(core, 300007, propsToLoad);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public CTKAccount(CTKAPI instance, int account, List<string> propertyNames) : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "number", "name" });
            props.AddRange(propertyNames);
            GetAccount(instance, account, props);
        }

        /// <summary>
        /// Initializes a new instance of the CTKAccount class using the specified <see cref="CTKWhere"/> object
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereAccount">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <remarks>
        /// If the <see cref="CTKWhere"/> matches more than one account, only the first matching account will be returned. 
        /// To get multiple matching accounts, use the <see cref="Find"/> method
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Get account using a CTKWhere with no additional properties
        /// //	
        ///using System;
        ///using System.Collections.Generic;
        ///
        ///using Intensive.Services.CTKAPIWrapper;
        ///using Intensive.Services.CTKAPIWrapper.CTKObjects;
        ///
        ///namespace CTKAPITest.CLI
        ///{
        ///    class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Account.AccountWhere";
        ///            wh.Values = new CTKWhereCondition("number", "=", "300007");
        ///
        ///            CTKAccount acct = new CTKAccount(core, wh);
        ///            
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public CTKAccount(CTKAPI instance, CTKWhere whereAccount)
            : base()
        {
            GetAccount(instance, whereAccount, new List<string> { "number", "name" });
        }


        /// <summary>
        /// Initializes a new instance of the CTKAccount class using the specified <see cref="CTKWhere"/> object and populates the given properties
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereAccount">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary.  The "name" and "number" properties will be automatically added</param>
        /// <remarks>
        /// If the <see cref="CTKWhere"/> matches more than one account, only the first matching account will be returned. 
        /// To get multiple matching accounts, use the <see cref="Find"/> method        
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Get account using a CTKWhere object with additional properties
        /// //	
        ///using System;
        ///using System.Collections.Generic;
        ///
        ///using Intensive.Services.CTKAPIWrapper;
        ///using Intensive.Services.CTKAPIWrapper.CTKObjects;
        ///
        ///namespace CTKAPITest.CLI
        ///{
        ///    class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; { "account_exec.name", "segment_queue.name" };
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Account.AccountWhere";
        ///            wh.Values = new CTKWhereCondition("number", "=", "300007");
        ///
        ///            CTKAccount acctPropsWhere = new CTKAccount(core, wh, propsToLoad);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example> 
        public CTKAccount(CTKAPI instance, CTKWhere whereAccount, List<string> propertyNames)
            : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "number", "name" });
            props.AddRange(propertyNames);
            GetAccount(instance, whereAccount, props);
        }

        /// <summary>
        /// returns a list a of accounts that match the conditions of the specified <see cref="CTKWhere"/>
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereAccount">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <returns>a list of CTKAccount objects, with only the "number" and "name" properties populated</returns>
        /// <example>
        /// <code>
        /// //
        /// // Example 5 -- Find all matching accounts with no additional properties
        /// //	
        ///using System;
        ///using System.Collections.Generic;
        ///
        ///using Intensive.Services.CTKAPIWrapper;
        ///using Intensive.Services.CTKAPIWrapper.CTKObjects;
        ///
        ///namespace CTKAPITest.CLI
        ///{
        ///    class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Account.AccountWhere";
        ///            wh.Values = new CTKWhereCondition("number", "like", "30000%");
        ///
        ///            List&lt;CTKAccount&gt; lstAcct = CTKAccount.Find(core, wh);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        static public List<CTKAccount> Find(CTKAPI instance, CTKWhere whereAccount)
        {
            return Find(instance, whereAccount, new List<string> { "number", "name" });
        }

        /// <summary>
        /// returns a list a of accounts that match the conditions of the specified <see cref="CTKWhere"/>
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereAccount">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <returns>a list of CTKAccount objects/></returns>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary.  The "name" and "number" properties will be automatically added</param>
        /// <returns>a list of CTKAccount objects with values for the given property names</returns>
        /// <example>
        /// <code>
        /// //
        /// // Find all matching accounts with additional properties
        /// //	
        ///using System;
        ///using System.Collections.Generic;
        ///
        ///using Intensive.Services.CTKAPIWrapper;
        ///using Intensive.Services.CTKAPIWrapper.CTKObjects
        ///
        ///namespace CTKAPITest.CLI
        ///{
        ///    class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; { "account_exec.name", "segment_queue.name" };
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Account.AccountWhere";
        ///            wh.Values = new CTKWhereCondition("number", "like", "30000%");
        ///            
        ///            List&lt;CTKAccount&gt; lstAcctProps = CTKAccount.Find(core, wh, propsToLoad);
        ///            
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        static public List<CTKAccount> Find(CTKAPI instance, CTKWhere whereAccount, List<string> propertyNames)
        {
            List<CTKAccount> lst = new List<CTKAccount>();
            CTKAccount ctkAcct = new CTKAccount();

            List<string> props = new List<string>();
            props.AddRange(new List<string> { "number", "name" });
            props.AddRange(propertyNames);

            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Account.Account";
            qry.Attributes.AddRange(props);
            qry.LoadArgs = whereAccount;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            foreach (Dictionary<string, object> acct in rd)
            {
                ctkAcct = new CTKAccount();
                ctkAcct.Number = Convert.ToInt32(acct["number"]);
                ctkAcct.Name = acct["name"].ToString();
                ctkAcct.Properties = acct;
                lst.Add(ctkAcct);
            }
            return lst;
        }

        private void GetAccount(CTKAPI instance, object loadArgs, List<string> propertyNames)
        {
            ctk = instance;
            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Account.Account";
            qry.Attributes.AddRange(propertyNames);

            qry.LoadArgs = loadArgs;

            string str = qry.ToString();

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            this.Number = Convert.ToInt32(rd[0]["number"]);
            this.Name = rd[0]["name"].ToString();
            this.Properties = rd[0];
        }


        /// <summary>
        /// Adds a contract to the account
        /// </summary>
        /// <param name="startDate">Date to start the contract</param>
        /// <param name="lengthInMonths">length of the contract in months</param>
        /// <param name="siteID">(optional)Site ID if needed </param>
        /// <param name="label">(optional)if different from the default</param>
        /// <param name="salesRep">(optional)contact ID of the associated sales rep.  If not specified, the current authenticated user will be used</param>
        /// <returns>return the Contract ID of the newly created contract</returns>
        public int AddContract(DateTime startDate, int lengthInMonths, int? siteID = null, string label = null, int? salesRep = null)
        {

            CTKAction addContract = new CTKAction();
            addContract.ClassName = "Account.Account";
            addContract.MethodName = "addContract";

            addContract.MethodArguments = new List<object>()
            {
                startDate.ToString("yyyy-mm-dd HH:mm:ss"),
                lengthInMonths,
                siteID,
                label,
                salesRep
            };

            addContract.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addContract);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

            int contractID = Convert.ToInt32(results[0]["load_value"]);

            return contractID;
        }

        /// <summary>
        /// Adds a note to the account
        /// </summary>
        /// <param name="text">the text to add</param>
        public void AddNote(string text)
        {
            CTKAction addNote = new CTKAction();
            addNote.ClassName = "Account.Account";
            addNote.MethodName = "addNote";

            addNote.MethodArguments = new List<object>() {text };

            addNote.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addNote);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

            //var resp = results[0]["load_value"].ToString();
        }

        /// <summary>
        /// Creates a ticket.
        /// </summary>
        /// <param name="queue">the id number of the CORE queue to place the ticket into</param>
        /// <param name="subCategory">Sub-Category of the ticket; values vary from queue to queue.  
        /// Refer to https://ws.core.rackspace.com/ctkapi/browse/Ticket/Subcategory for possible values
        /// </param>
        /// <param name="source">identifies the originator of the ticket
        /// Refer to https://ws.core.rackspace.com/ctkapi/browse/Ticket/Source> for possible values
        /// </param>
        /// <param name="severity">
        /// <list type="number">
        ///     <item>Standard</item>
        ///     <item>Urgent</item>
        ///     <item>Emergency</item>
        /// </list>
        /// </param>
        /// <param name="subject">The ticket subject</param>
        /// <param name="text">the text/body of the ticket</param>
        /// <param name="computerList">an array of computer numbers to be attached to the ticket</param>
        /// <param name="isPrivateMessage">if true, the text of the ticket will not be visible to customers </param>
        /// <param name="contactList">an array of contact id numbers that will be notified that the ticket has been updated if the "is_private_message" argument is False.</param>
        /// <param name="assignee">the CORE Contact ID number of the person the ticket should be assigned to</param>
        /// <param name="sourceContact">The CORE Contact ID number of the person that is creating the ticket</param>
        /// <param name="isPrivateTicket">if TRUE, the ticket will be a Private ticket</param>
        /// <param name="sendMessageText">if TRUE, a SMS text message will be sent to the contact lists</param>
        /// <param name="status">The initial status of the ticket</param>
        /// <param name="contactEmailType">email Type to use for notifying the contact(s)</param>
        /// <param name="priority">
        /// <list type="number">
        ///     <item>1 = Normal</item>
        ///     <item>2 = Low</item>
        ///     <item>3 = High</item>
        ///     <item>4 = Highest</item>
        /// </list>
        /// </param>
        /// <param name="productSuiteName">???</param>
        /// <param name="productName">???</param>
        /// <param name="actionName">???</param>
        /// <param name="classification">???</param>
        /// <param name="messageTime">???</param>
        /// <param name="requiredRecipients">???</param>
        /// <param name="hasBBcode">TRUE if the message text contains bbCode</param>
        /// <param name="send_mail">controls the notification emails</param>
        /// <returns>the CORE ticket number that was created</returns>
        public string AddTicket(int queue,
                            int subCategory,
                            int source,
                            int severity,
                            string subject,
                            string text,
                            //int[] computerList=null, 
                            List<int> computerList = null,
                            bool isPrivateMessage=false,
                            //int[] contactList, 
                            List<int> contactList = null,
                            int? assignee = null,
                            int? sourceContact = null,
                            bool isPrivateTicket = false,
                            bool sendMessageText = false,
                            int? status = null,
                            int? contactEmailType = null,
                            int? priority = null,
                            string productSuiteName = null,
                            string productName = null,
                            string actionName = null,
                            int? classification = null,
                            DateTime? messageTime = null,
                            //int[] requiredRecipients=null,
                            List<int> requiredRecipients = null,
                            bool hasBBcode = false,
                            bool send_mail = true
                            )
        {
            string tktid = string.Empty;

            CTKAction addTkt = new CTKAction();
            addTkt.ClassName = "Account.Account";
            addTkt.MethodName = "addTicket";

            addTkt.MethodArguments = new List<object>()
            { 
                queue,
                subCategory,
                source,
                severity,
                subject,
                text,
                (computerList == null) ? null : computerList.ToArray(),
                isPrivateMessage,
                (contactList == null) ? new int[] { } : contactList.ToArray(),
                assignee,
                sourceContact,
                isPrivateTicket,
                sendMessageText,
                status,
                contactEmailType,
                priority,
                productSuiteName,
                productName,
                actionName,
                classification,
                messageTime,
                (requiredRecipients == null) ? null : requiredRecipients.ToArray(),
                hasBBcode,
                send_mail
            };

            addTkt.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addTkt);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

            tktid = results[0]["load_value"].ToString();
                
            return tktid;
        }
    }
}
