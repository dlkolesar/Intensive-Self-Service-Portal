using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intensive.Services.CTKAPIWrapper;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{
    /// <summary>
    /// The CTKComputer class represents a CORE device
    /// </summary>
    
    public class CTKComputer:CTKObject
    {
        // CTKAPI ctk;
        /// <summary>
        /// Gets the computer number
        /// </summary>
        public int Number { get; internal set; }

        /// <summary>
        /// Gets the name of the computer
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// default constructor to create an empty object
        /// </summary>
        public CTKComputer() : base()
        {
            this.Number = 0;
            this.Name = string.Empty;

        }

        /// <summary>
        /// Initializes a new instance of the CTKComputer class for the specified device number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="number">the device number to retrieve</param>
        /// <remarks>
        /// Only the Number and Name properties will be populated;  the Properties dictionary will be empty
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Get computer with no additional properties
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
        ///            CTKComputer acct = new CTKComputer(core, 299455);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public CTKComputer(CTKAPI instance, int number) :base()
        {
            GetComputer(instance, number, new List<string>{ "number", "name" });
        }

        /// <summary>
        /// Initializes a new instance of the CTKComputer class for the specified device number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="number">the computer number to retrieve</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        /// <example>
        ///  <code>
        /// //
        /// // Get computer with additional properties
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
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; { "account.number", "datacenter.symbol" };
        ///
        ///            CTKComputer acct = new CTKComputer(core, 299455, propsToLoad);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        /// 
        public CTKComputer(CTKAPI instance, int number, List<string> propertyNames) : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "number", "name" });
            props.AddRange(propertyNames);
            GetComputer(instance, number, props);
        }

        /// <summary>
        /// Initializes a new instance of the CTKComputer class using the specified <see cref="CTKWhere"/> object
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereComputer">a <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <remarks>
        /// If the CTKWhere matches more than one computer, only the first matching computer.  
        /// To get multiple matching computer, use the FindComputers() method
        /// </remarks>
        /// <example>
        /// <code>
        /// //
        /// // Get computer using a CTKWhere object with additional properties
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
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; {"account.number", "datacenter.symbol" };
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Computer.ComputerWhere";
        ///            wh.Values = new CTKWhereCondition("number", "=", "299455");
        ///
        ///            CTKComputer acctPropsWhere = new CTKComputer(core, wh, propsToLoad);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public CTKComputer(CTKAPI instance, CTKWhere whereComputer)
            : base()
        {
            GetComputer(instance, whereComputer, new List<string> { "number", "name" });
        }


        /// <summary>
        /// Initializes a new instance of the CTKComputer class using the specified <see cref="CTKWhere"/> object
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereComputer">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        /// <remarks>
        /// If the CTKWhere matches more than one computer, only the first matching computer.  
        /// To get multiple matching computer, use the FindComputers() method
        /// </remarks>
        ///  <example>
        /// <code>
        /// //
        /// // Get computer using a CTKWhere object with additional properties
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
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; {"account.number", "datacenter.symbol" };
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Computer.ComputerWhere";
        ///            wh.Values = new CTKWhereCondition("number", "=", "299455");
        ///
        ///            CTKComputer acctPropsWhere = new CTKComputer(core, wh, propsToLoad);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        public CTKComputer(CTKAPI instance, CTKWhere whereComputer, List<string> propertyNames)
            : base()
        {
            List<string> props = new List<string>();
            props.AddRange(new List<string> { "number", "name" });
            props.AddRange(propertyNames);
            GetComputer(instance, whereComputer, props);
        }

        /// <summary>
        /// returns a list a of computers that match the conditions of the specified CTKWhere
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereComputer">a <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <returns>a list of CTKComputer objects</returns>
        /// <example>
        /// <code>
        /// //
        /// // Find all matching computers with no additional properties
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
        ///            wh.ClassName = "Computer.ComputerWhere";
        ///            wh.Values = new CTKWhereCondition("number", "like", "29945%");
        ///
        ///            List&lt;CTKComputer&gt; lstAcct = CTKComputer.Findcomputers(core, wh);
        ///
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        static public List<CTKComputer> FindComputers(CTKAPI instance, CTKWhere whereComputer)
        {
            return FindComputers(instance, whereComputer, new List<string> { "number", "name" });
        }

        /// <summary>
        /// returns a list a of computers that match the conditions of the specified CTKWhere
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="whereComputer">a  <see cref="CTKWhere"/> object containing the criteria to match on</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        /// <returns>a list of CTKComputer objects</returns>
        /// <example>
        /// 
        /// <code>
        /// //
        /// // Find all matching computers with additional properties
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
        ///            List&lt;string&gt; propsToLoad = new List&lt;string&gt; { "account.number", "datacenter.symbol" };
        ///
        ///            CTKWhere wh = new CTKWhere();
        ///            wh.ClassName = "Computer.ComputerWhere";
        ///            wh.Values = new CTKWhereCondition("number", "like", "29945%");
        ///            
        ///            List&lt;CTKComputer&gt; lstAcctProps = CTKComputer.Findcomputers(core, wh, propsToLoad);
        ///            
        ///            core.Logout();
        ///        }
        ///    }
        ///}
        /// </code>
        /// </example>
        static public List<CTKComputer> FindComputers(CTKAPI instance, CTKWhere whereComputer, List<string> propertyNames)
        {
            List<CTKComputer> lst = new List<CTKComputer>();

            List<string> props = new List<string>();
            props.AddRange(new List<string> { "number", "name" });
            props.AddRange(propertyNames);

            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Computer.Computer";
            qry.Attributes.AddRange(props);
            qry.LoadArgs = whereComputer;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            if (resp.Count > 0)
            {
                CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
                CTKComputer ctk;
                foreach (Dictionary<string, object> comp in rd)
                {
                    ctk = new CTKComputer();
                    ctk.Number = Convert.ToInt32(comp["number"]);
                    ctk.Name = (comp["name"] == null) ? "null" : comp["name"].ToString();
                    ctk.Properties = comp;
                    lst.Add(ctk);
                }
            }
            return lst;
        }

        private void GetComputer(CTKAPI instance, object loadArgs, List<string> propertyNames)
        {
            ctk = instance;
            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Computer.Computer";
            qry.Attributes.AddRange(propertyNames);

            qry.LoadArgs = loadArgs;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            this.Number = Convert.ToInt32(rd[0]["number"]);
            this.Name = rd[0]["name"].ToString();
            this.Properties = rd[0];
        }

        //public void AddDASDiskGroup(int diskGroupId, int raidLevel, int diskCount, int diskSize){ }
        //public void AddDASISCSIConf(string ipAddress, int dasSwitchPort, int dasPort, int dasIQN, int vlanId) { }
        //public void addDedicatedSan(lun_id, raid_level, mount_point, hlu, disk_type, capacity, hosts, storage_array) { }

        /// <summary>
        /// Adds this computer/Device behind another 
        /// </summary>
        /// <param name="deviceNumber">The device number of the computer/device that sits in front of the current device</param>
        public void AddDeviceBehind(int deviceNumber)
        {
            CTKAction addTkt = new CTKAction();
            addTkt.ClassName = "Computer.Computer";
            addTkt.MethodName = "addDeviceBehind";

            addTkt.MethodArguments = new List<object>()
            {
                deviceNumber
            };

            addTkt.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addTkt);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }

        //public void addHostISCSIConf(ip_address, host, port, host_iqn, pci_slot) { }
        //public void addHotSpare(quantity, slot, size) { }
        //public void addManagedStorage(lun_id, uuid, raid_level, storage_group_name, storage_array, purpose, host_name, capacity) { }
        //public void addRPAClusterConfig(target_lun_id, source_lun_id, raid_level, mount_point, hlu, disk_type, capacity, hosts, storage_array) { }

        /// <summary>
        /// Add or replace a SKU for the computer/device.  
        /// </summary>
        /// <remarks>
        /// <para>
        /// If there already is a sku with the skunit given (checks for skunit.name
        /// and skunit.mapping)- this will replace it, otherwise just adds the sku
        /// </para>
        /// <para>
        /// if admin_user == 0 it will only allow sku to be added if it a member of
        /// a skunit that is valid for this computer's platform
        /// </para>
        /// <para>
        /// THIS IS ONLY REALLY VALID FOR SKUNIVERSE READY DEVICES.I will add
        /// skus to non-skuniverse ready devices but it may not replace the old
        /// sku- because the skunit.name / mapping may not map to what's there-
        /// and you could get duplicate skus
        /// /// </para>
        /// </remarks>
        /// <param name="sku">The SKU ID of the product to add/replace</param>
        /// <param name="skunit">The SKU Unit id</param>
        public void AddReplacePart(int sku, int skunit)
        {
            CTKAction addTkt = new CTKAction();
            addTkt.ClassName = "Computer.Computer";
            addTkt.MethodName = "addReplacePart";

            addTkt.MethodArguments = new List<object>()
            {
                sku, 
                skunit
            };

            addTkt.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addTkt);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }

        /// <summary>
        /// Changes the status for a device, ensuring all activator rules are activated.
        /// </summary>
        /// <param name="newStatus">the id number of the new status</param>
        public void ChangeStatus(int newStatus)
        {
            CTKAction addTkt = new CTKAction();
            addTkt.ClassName = "Computer.Computer";
            addTkt.MethodName = "addReplacePart";

            addTkt.MethodArguments = new List<object>()
            {
                newStatus
            };

            addTkt.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addTkt);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }

        //public void Clone(string name, int accountNumber, int? DataCenterId)
        //{

        //}

        //public void forceDisableRackwatchMonitoring

        /// <summary>
        /// Returns a dictionary object providing the vlan, ip, and network for each type of network associated with this device.
        /// </summary>
        public void GetNetworks()
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Computer.Computer";
            action.MethodName = "getNetworks";

            action.MethodArguments = new List<object>();

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

            // [{networktype: { vlan:999, IP:xx.xx.xx.xx, network:xxxxxxxxxxx}}]
        }

        /// <summary>
        /// Returns a list of 4-tuples containing SKU, label, display_label, description for this computer's parts. 
        /// For convenience, the list will be sorted by SKU number.
        /// </summary>
        /// <returns>a CTKResultTuples containing SKU, label, display_label, description</returns>
        public CTKResultTuple GetSKUsAndLabels()
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Computer.Computer";
            action.MethodName = "getSKUsAndLabels";

            action.MethodArguments = new List<object>();

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultTuple results = (CTKResultTuple)resp.Results;

            return results;
            

            // [{networktype: { vlan:999, IP:xx.xx.xx.xx, network:xxxxxxxxxxx}}]
        }

        /// <summary>
        /// Returns a list of skunits, and a list of skus for each skunit and information about each one.
        /// </summary>
        /// <returns>a CTKResultDictionary containing SKU Unit information and their associated SKU ids</returns>
        public CTKResultDictionary GetValidSkunitsAndSkus()
        {
            CTKAction action = new CTKAction();
            action.ClassName = "Computer.Computer";
            action.MethodName = "getValidSkunitsAndSkus";

            action.MethodArguments = new List<object>();

            action.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(action);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

            return results;
        }


        /// <summary>
        /// Removes this computer/Devicefrom behind another 
        /// </summary>
        /// <param name="deviceNumber">The device number of the computer/device that sits in front of the current device</param>
        public void RemoveDeviceBehind(int deviceNumber)
        {
            CTKAction addTkt = new CTKAction();
            addTkt.ClassName = "Computer.Computer";
            addTkt.MethodName = "removeDeviceBehind";

            addTkt.MethodArguments = new List<object>()
            {
                deviceNumber
            };

            addTkt.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addTkt);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;
        }


        //public void removeManagedStorage

        /// <summary>
        /// Removes a SKU or SKU Unit from the device
        /// </summary>
        /// <param name="skuUnitName">The SKU Unit name to remove.  This is because a sku can be assigned to multiple skunits </param>
        /// <param name="sku">SKU Id number of the specific Product to remove</param>
        public void RemovePart(string skuUnitName, int? sku=null)
        {
            CTKAction addTkt = new CTKAction();
            addTkt.ClassName = "Computer.Computer";
            addTkt.MethodName = "removePart";

            addTkt.MethodArguments = new List<object>()
            {
                skuUnitName,
                sku,
            };

            addTkt.LoadArgs = this.Number;

            CTKActionResponse resp = ctk.Submit(addTkt);

            CTKResultDictionary results = (CTKResultDictionary)resp.Results;

        }

        //public void setSalesRep(int employeeID)
        //{
        //    CTKAction addTkt = new CTKAction();
        //    addTkt.ClassName = "Computer.Computer";
        //    addTkt.MethodName = "setSalesRep";

        //    addTkt.MethodArguments = new List<object>()
        //    {
        //        employeeID
        //    };

        //    addTkt.LoadArgs = this.Number;

        //    CTKActionResponse resp = ctk.Submit(addTkt);

        //    CTKResultDictionary results = (CTKResultDictionary)resp.Results;

        //}
        
        
        //public void statusChangeNotice(int statusId?)






    }
}
