using Intensive.Services.CTKAPIWrapper.CTKObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{
    /// <summary>
    /// The CTKContact class represents the contact information for CORE users and customers
    /// </summary>
    public class CTKContact : CTKObject
    {
        /// <summary>
        /// The ID number of the Contact
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// The Name of the Contact
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// default constructor to create an empty object
        /// </summary>
        public CTKContact() : base()
        {
            this.ID = 0;
            this.Name = string.Empty;
        }


        /// <summary>
        /// Initializes a new instance of the CTKContact class for the specified account 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="id">the id number of the Contact to retrieve</param>
        /// <remarks>
        /// Only the ID and Name properties will be populated
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Get contact with no additional properties
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
        ///            CTKContact contact = new CTKContact(core, 1357911);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        /// 
        public CTKContact(CTKAPI instance, int id) : base()
        {
            GetContact(instance, id, new List<string>{"id","name" });
        }

        /// <summary>
        /// Initializes a new instance of the CTKContact class for the specified account and populates the given properties
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="id">the id number of the Contact to retrieve</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary.  The "name" and "ID" properties will be automatically added</param>
        /// <example>
        /// <code>
        /// //
        /// // Get contact with additional properties
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
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; { "crm_userid", "employee_userid", "login_time"  };
        ///
        ///            CTKContact acct = new CTKContact(core, 24680, propsToLoad);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public CTKContact(CTKAPI instance, int id, List<string> propertyNames) : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "id", "name" });
            props.AddRange(propertyNames);
            GetContact(instance, id,props);
        }

        /// <summary>
        ///Initializes a new instance of the CTKContact class using the specified <see cref="CTKWhere"/> object 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereContact">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <remarks>
        /// Only the ID and Name properties will be populated
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Get contact with no additional properties
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
        ///            CTKWhereCondition c1 = new CTKWhereCondition("userid", "=", "joe.racker");
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Contact.ContactWhere";
        ///            wh.Values = c1;
        ///
        ///            CTKAccount acct = new CTKAccount(core, wh);
        ///            
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        /// 
        public CTKContact(CTKAPI instance, CTKWhere whereContact) : base()
        {
            GetContact(instance, whereContact, new List<string> { "id", "name" });
        }

        /// <summary>
        /// Initializes a new instance of the CTKContact class using the specified <see cref="CTKWhere"/> object and populates the given properties
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereContact">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary.  The "name" and "ID" properties will be automatically added</param>
        /// <remarks>
        /// Only the ID and Name properties will be populated
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Get contact with no additional properties
        /// //	
        /// using System;
        /// using System.Collections.Generic;
        ///
        /// using Intensive.Services.CTKAPIWrapper;
        /// using Intensive.Services.CTKAPIWrapper.CTKObjects;
        ///
        /// namespace CTKAPITest.CLI
        /// {
        /// class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///            CTKAPI core = new CTKAPI("joe.racker", "I&lt;3Unicorns");
        ///
        ///            CTKWhereCondition c1 = new CTKWhereCondition("userid", "=", "joe.racker");
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Contact.ContactWhere";
        ///            wh.Values = c1;
        ///
        ///            CTKAccount acct = new CTKAccount(core, wh, new List&lt;string&gt; {"crm_userid","employee_userid","login_time" });
        ///            
        ///            core.Logout();
        ///        }
        ///    }
        /// }
        /// </code>
        /// </example>
        /// 
        public CTKContact(CTKAPI instance, CTKWhere whereContact, List<string> propertyNames) : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "id", "name" });
            props.AddRange(propertyNames);
            GetContact(instance, whereContact, props);
        }


        private void GetContact(CTKAPI instance, object loadArgs, List<string> propertyNames)
        {
            ctk = instance;
            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Contact.Contact";
            qry.Attributes.AddRange(propertyNames);

            qry.LoadArgs = loadArgs;

            string str = qry.ToString();

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            this.ID = Convert.ToInt32(rd[0]["id"]);
            this.Name = rd[0]["name"].ToString();
            this.Properties = rd[0];
        }


        /// <summary>
        /// returns a list a of Contacts that match the conditions of the specified <see cref="CTKWhere"/>
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereContact">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <returns>a list of CTKContact objects, with only the "id" and "name" properties populated</returns>
        /// <example>
        /// <code>
        /// //
        /// // Find all matching Contacts with no additional properties
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
        ///            wh.ClassName = "Contact.ContactWhere";
        ///            wh.Values = new CTKWhereCondition("account", "=", "300007");
        ///
        ///            List&lt;CTKContact&gt; lstAcct = CTKContact.Find(core, wh);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public static List<CTKContact> Find(CTKAPI instance, CTKWhere whereContact) 
        {
           return Find(instance, whereContact, new List<string> { "id", "name" });
        }


        /// <summary>
        /// returns a list a of Contacts that match the conditions of the specified <see cref="CTKWhere"/>
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereContact">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <returns>a list of CTKContact objects/></returns>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary.  The "name" and "number" properties will be automatically added</param>
        /// <returns>a list of CTKContact objects with values for the given property names</returns>
        /// <example>
        /// <code>
        /// //
        /// // Find all matching Contacts with additional properties
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
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; {"crm_userid","employee_userid","login_time" };
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Contact.ContactWhere";
        ///            wh.Values = new CTKWhereCondition("employee_userid", "=", "joe.racker");
        ///            
        ///            List&lt;CTKContact&gt; lstAcctProps = CTKContact.Find(core, wh, propsToLoad);
        ///            
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public static List<CTKContact> Find(CTKAPI instance, CTKWhere whereContact, List<string> propertyNames) 
        {
            List<CTKContact> lst = new List<CTKContact>();
            CTKContact ctkctkContact = new CTKContact();

            List<string> props = new List<string>();
            props.AddRange(new List<string> { "id", "name" });
            props.AddRange(propertyNames);

            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Contact.Contact";
            qry.Attributes.AddRange(props);
            qry.LoadArgs = whereContact;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            foreach (Dictionary<string, object> results in rd)
            {
                ctkctkContact = new CTKContact();
                ctkctkContact.ID = Convert.ToInt32(results["id"]);
                ctkctkContact.Name = results["name"].ToString();
                ctkctkContact.Properties = results;
                lst.Add(ctkctkContact);
            }
            return lst;
        }



        // These methods require CORE_ADMIN or CORE_PERMISSION_ADMIN to execute.
        // Since most developers using this library will not have these permissions
        // these methods have not been implemented.
        //
        //  perhaps in a future release
        //

        //public void SuspendEmployee() { }
        //public void UnSuspendEmployee() { }
        //public void UpdateEmployeeDepartments(List<int> departmentIDs) { }
        //public void UpdateEmployeeInformation(string firstName, string lastName, string employeeUserid, string crmUserid, string title, string primaryEmail, string primaryPhone, int DatacenterID) { }
        //public void TerminateEmployee() { }

    }
}
