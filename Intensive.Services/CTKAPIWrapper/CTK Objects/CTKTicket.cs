using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{
    /// <summary>
    /// The CTKTicket class represents a CORE ticket.
    /// </summary>
    public class CTKTicket : CTKObject
    {
        /// <summary>
        /// The Ticket ID number
        /// </summary>
        public string Number { get; internal set; }

        /// <summary>
        /// Ticket Subject
        /// </summary>
        public string Subject { get; internal set; }

        /// <summary>
        /// default constructor to create an empty ticket
        /// </summary>
        public CTKTicket() : base()
        {
            this.Number = string.Empty;
            this.Subject = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the CTKTicket class using the specified ticket number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="number">the ticket number to retrieve</param>
        /// <remarks>
        /// Only the Number and Subject properties will be populated;  the Properties dictionary will be empty
        /// </remarks>
        public CTKTicket(CTKAPI instance, string number) :base()
        {
            GetTicket(instance, number, new List<string>{ "number", "subject" });
        }

        /// <summary>
        /// Initializes a new instance of the CTKTicket class for the specified ticket number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="number">the ticket number to retrieve</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        public CTKTicket(CTKAPI instance, string number, List<string> propertyNames) : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "subject", "number" });
            props.AddRange(propertyNames);
            GetTicket(instance, number, props);
        }

        /// <summary>
        /// Initializes a new instance of the CTKTicket class using a <see cref="CTKWhere"/> object
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicket">a  <see cref="CTKWhere"/> object containing the criteria to match</param>
        /// <remarks>
        /// If the CTKWhere matches more than one ticket, only the first matching tiket will be returned.  
        /// To get multiple matching accounts, use the FindTickets() method
        /// </remarks>
        public CTKTicket(CTKAPI instance, CTKWhere whereTicket)
            : base()
        {
            GetTicket(instance, whereTicket, new List<string> { "subject", "number" });
        }


        /// <summary>
        /// Initializes a new instance of the CTKTicket class using a <see cref="CTKWhere"/> object
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicket">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        /// <remarks>
        /// If the CTKWhere matches more than one ticket, only the first matching tiket will be returned.  
        /// To get multiple matching accounts, use the FindTickets() method
        /// </remarks>
        public CTKTicket(CTKAPI instance, CTKWhere whereTicket, List<string> propertyNames)
            : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "subject", "number" });
            props.AddRange(propertyNames);
            GetTicket(instance, whereTicket, props);
        }

        /// <summary>
        /// returns a list a of tickets that match the conditions of a <see cref="CTKWhere"/>
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicket">a <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <returns>a list of CTKTicket objects</returns>
        static public List<CTKTicket> FindTickets(CTKAPI instance, CTKWhere whereTicket)
        {
            return FindTickets(instance, whereTicket, new List<string> { "number", "subject" });
        }

        /// <summary>
        /// returns a list a of ticket that match the conditions of a <see cref="CTKWhere"/>
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicket">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        /// <returns>a list of CTKTicket objects</returns>
        static public List<CTKTicket> FindTickets(CTKAPI instance, CTKWhere whereTicket, List<string> propertyNames)
        {
            List<CTKTicket> lst = new List<CTKTicket>();

            List<string> props = new List<string>();
            props.AddRange(new List<string> { "number", "subject" });
            props.AddRange(propertyNames);

            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Ticket.Ticket";
            qry.Attributes.AddRange(props);
            qry.LoadArgs = whereTicket;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            CTKTicket ctk;
            foreach (Dictionary<string, object> comp in rd)
            {
                ctk = new CTKTicket();
                ctk.Number = comp["number"].ToString();
                ctk.Subject = (comp["subject"] == null) ? "null" : comp["subject"].ToString();
                ctk.Properties = comp;
                lst.Add(ctk);
            }
            return lst;
        }

        private void GetTicket(CTKAPI instance, object loadArgs, List<string> propertyNames)
        {
            ctk = instance;

            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Ticket.Ticket";
            qry.Attributes.AddRange(propertyNames);

            qry.LoadArgs = loadArgs;

            //submit the request
            CTKResponse resp = ctk.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            this.Number = rd[0]["number"].ToString();
            this.Subject = rd[0]["subject"].ToString();
            this.Properties = rd[0];
        }

        /// <summary>
        /// Adds a CORE device to the device list attached to the ticket
        /// </summary>
        /// <param name="deviceNumber">the CORE device number</param>
        public void AddComputer(int deviceNumber)
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Ticket.Ticket";
            action.MethodName = "addComputer";

            action.MethodArguments = new List<object>() { deviceNumber };

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }

        /// <summary>
        /// Adds a Comment to an existing ticket
        /// </summary>
        /// <param name="text">the comment to be added</param>
        /// <param name="source">identifies the originator of the ticket</param>
        /// <param name="privateComment">if true, the text of the ticket will not be visible to customers</param>
        /// <param name="sourceContactId">The CORE Contact ID number of the person that is creating the ticket</param>
        /// <param name="sendMessageText">if TRUE, a SMS text message will be sent to the contact lists</param>
        /// <param name="contactId"></param>
        /// <param name="sendEmail">if TRUE, an email will be sent to the contact list</param>
        /// <param name="messageTime"></param>
        /// <param name="hasBBcode">TRUE if the message text contains bbCode</param>
        public void AddMessage(string text, 
                               int source, 
                               bool privateComment=false, 
                               int? sourceContactId=null, 
                               bool sendMessageText=false, 
                               int? contactId=null, 
                               bool sendEmail=true, 
                               DateTime? messageTime=null, 
                               bool hasBBcode=false)
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Ticket.Ticket";
            action.MethodName = "addMessage";

            action.MethodArguments = new List<object>()
            {
                text,
                source,
                privateComment,
                sourceContactId,
                sendMessageText,
                contactId,
                sendEmail,
                messageTime,
                hasBBcode
            };

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

        }

        /// <summary>
        /// Creates a sub-ticket of the current ticket
        /// </summary>
        /// <param name="subject">The ticket subject</param>
        /// <param name="text">the text/body of the ticket</param>
        /// <param name="queue">the id number of the CORE queue to place the ticket into</param>
        /// <param name="priority">
        ///     <list type="number">
        ///         <item>1 = Normal</item>
        ///         <item>2 = Low</item>
        ///         <item>3 = High</item>
        ///         <item>4 = Highest</item>
        ///     </list>
        /// </param>
        /// <param name="severity">
        ///     <list type="number">
        ///         <item>Standard</item>
        ///         <item>Urgent</item>
        ///         <item>Emergency</item>
        ///     </list>
        /// </param>
        /// <param name="computerList">an array of computer numbers to be attached to the ticket</param>
        /// <param name="isPrivateTicket">if TRUE, the ticket will be a Private ticket</param>
        /// <param name="isPrivateMessage">if true, the text of the ticket will not be visible to customers </param>
        /// <param name="sendMessageText">if TRUE, a SMS text message will be sent to the contact lists</param>
        /// <param name="source">identifies the originator of the ticket
        ///     Refer to https://ws.core.rackspace.com/ctkapi/browse/Ticket/Source> for possible values
        /// </param>
        /// <param name="subCategory">Sub-Category of the ticket; values vary from queue to queue.
        /// <param name="status">The initial status of the ticket</param>
        /// <param name="assignee">the CORE Contact ID number of the person the ticket should be assigned to</param>
        /// <param name="isScheduledService">whether ticket is scheduled service ticket(Maintenance Calendar)</param>
        /// <param name="hasBBcode">TRUE if the message text contains bbCode</param>
        /// <returns>the ticket number of the newly created sub-ticket</returns>
        public string AddSubTicket(string subject, 
                                string text, 
                                int? queue=null, 
                                int? priority=null, 
                                int? severity=null, 
                                int[] computerList = null,
                                int isPrivateTicket = 1, 
                                int isPrivateMessage = 1, 
                                int sendMessageText= 0, 
                                int? source=null, 
                                int? subcategory=null, 
                                int? status=null, 
                                int? assignee=null,
                                int isScheduledService = 0,
                                bool hasBBcode = false)
        {
            string tktid = string.Empty;

            CTKAction action = new CTKAction();
            action.ClassName = "Ticket.Ticket";
            action.MethodName = "addSubTicket";

            action.MethodArguments = new List<object>()
            {
                subject,
                text,
                queue,
                priority,
                severity,
                computerList,
                isPrivateTicket,
                isPrivateMessage,
                sendMessageText,
                source,
                subcategory,
                status,
                assignee,
                isScheduledService,
                hasBBcode
            };

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

            tktid = results[0]["load_value"].ToString();

            return tktid;
        }

        /// <summary>
        /// Adds a record or work performed for this ticket
        /// </summary>
        /// <param name="type"> a CTK WorkType object
        ///    Refer to https://ws.core.rackspace.com/ctkapi/browse/Ticket/WorkType for possible values
        /// </param>
        /// <param name="description">description of the work performed</param>
        /// <param name="duration">amount of time spent on this work</param>
        /// <param name="unitCount">Number of units of work to bill customer</param>
        /// <param name="feeWaived">Whether fee should be waived </param>
        /// <param name="contact">Override contact id for log, defaults to the current authenticated user (i.e. contact)</param>
        public void AddWork(int type, string description, int duration, int unitCount, bool feeWaived, int? contact = null)
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Ticket.Ticket";
            action.MethodName = "addWork";

            action.MethodArguments = new List<object>()
            {
                type,
                description,
                duration,
                unitCount,
                feeWaived,
                contact
            };

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }

        /// <summary>
        /// Removes a CORE device from the device list attached to the ticket
        /// </summary>
        /// <param name="deviceNumber">the CORE device number</param>
        public void RemoveComputer(int deviceNumber)
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Ticket.Ticket";
            action.MethodName = "removeComputer";

            action.MethodArguments = new List<object>()
            {
                deviceNumber
            };

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }

        /// <summary>
        /// Set the status of the ticket using a status name rather than the status ID number
        /// </summary>
        /// <param name="statusName">The name of the status the ticket should be changed to. (Case-Sensitive)</param>
        public void setStatusByName(string statusName)
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Ticket.Ticket";
            action.MethodName = "setStatusByName";

            action.MethodArguments = new List<object>()
            {
                statusName
            };

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }
    }
}
