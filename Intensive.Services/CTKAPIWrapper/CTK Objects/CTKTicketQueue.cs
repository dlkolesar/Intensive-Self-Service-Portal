using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{
    public class CTKTicketQueue : CTKObject
    {
        private static List<string> defaultProperties = new List<string> { "id", "name" };
        /// <summary>
        /// Gets the computer number
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// Gets the name of the computer
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// default constructor to create an empty object
        /// </summary>
        public CTKTicketQueue() : base()
        {
            this.ID = 0;
            this.Name = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the CTKTicketQueue class for the specified device number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="id">the device number to retrieve</param>
        /// <remarks>
        /// Only the Number and Name properties will be populated;  the Properties dictionary will be empty
        /// </remarks>

        public CTKTicketQueue(CTKAPI instance, int id) :base()
        {
            GetTicketQueue(instance, id, defaultProperties);
        }

        /// <summary>
        /// Initializes a new instance of the CTKTicketQueue class for the specified device number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="id">the computer number to retrieve</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        public CTKTicketQueue(CTKAPI instance, int id, List<string> propertyNames) : base()
        {
            List<string> props = new List<string>();
            props.AddRange(defaultProperties);
            props.AddRange(propertyNames);
            GetTicketQueue(instance, id, props);
        }

        /// <summary>
        /// Initializes a new instance of the CTKTicketQueue class using the specified <see cref="CTKWhere"/> object
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicketQueue">a <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <remarks>
        /// If the CTKWhere matches more than one computer, only the first matching computer.  
        /// To get multiple matching computer, use the FindComputers() method
        /// </remarks>
        public CTKTicketQueue(CTKAPI instance, CTKWhere whereTicketQueue)
            : base()
        {
            GetTicketQueue(instance, whereTicketQueue, defaultProperties);
        }


        /// <summary>
        /// Initializes a new instance of the CTKTicketQueue class using the specified <see cref="CTKWhere"/> object
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicketQueue">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        /// <remarks>
        /// If the CTKWhere matches more than one computer, only the first matching computer.  
        /// To get multiple matching computer, use the FindComputers() method
        /// </remarks>
        public CTKTicketQueue(CTKAPI instance, CTKWhere whereTicketQueue, List<string> propertyNames)
            : base()
        {
            //List<string> props = new List<string>();
            //props.AddRange(defaultProperties);
            List<string> props = defaultProperties;
            props.AddRange(propertyNames);
            GetTicketQueue(instance, whereTicketQueue, props);
        }

        /// <summary>
        /// returns a list a of computers that match the conditions of the specified CTKWhere
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicketQueue">a <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <returns>a list of CTKTicketQueue objects</returns>
        static public List<CTKTicketQueue> FindComputers(CTKAPI instance, CTKWhere whereTicketQueue)
        {
            return FindComputers(instance, whereTicketQueue, defaultProperties);
        }

        /// <summary>
        /// returns a list a of computers that match the conditions of the specified CTKWhere
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereTicketQueue">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        /// <returns>a list of CTKTicketQueue objects</returns>
        static public List<CTKTicketQueue> FindComputers(CTKAPI instance, CTKWhere whereTicketQueue, List<string> propertyNames)
        {
            List<CTKTicketQueue> lst = new List<CTKTicketQueue>();

            //List<string> props = new List<string>();
            //props.AddRange(new List<string> { "number", "name" });
            List<string> props = defaultProperties;
            props.AddRange(propertyNames);

            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Ticket.Queue";
            qry.Attributes.AddRange(props);
            qry.LoadArgs = whereTicketQueue;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            CTKTicketQueue ctk;
            foreach (Dictionary<string, object> q in rd)
            {
                ctk = new CTKTicketQueue();
                ctk.ID = Convert.ToInt32(q["id"]);
                ctk.Name = (q["name"] == null) ? "null" : q["name"].ToString();
                ctk.Properties = q;
                lst.Add(ctk);
            }
            return lst;
        }

        private void GetTicketQueue(CTKAPI instance, object loadArgs, List<string> propertyNames)
        {
            ctk = instance;
            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Ticket.Queue";
            qry.Attributes.AddRange(propertyNames);

            qry.LoadArgs = loadArgs;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            this.ID = Convert.ToInt32(rd[0]["id"]);
            this.Name = rd[0]["name"].ToString();
            this.Properties = rd[0];
        }

    }
}
