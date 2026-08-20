using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{
    /// <summary>
    /// The CTKProduct class represents a Product, also referred to as a SKU
    /// </summary>
    public class CTKProduct : CTKObject
    {
        //private CTKAPI ctk;
        private static List<string> defaultProperties = new List<string> { "id", "name","description" };
        /// <summary>
        /// Gets the computer number
        /// </summary>
        public int ID { get; internal set; }

        /// <summary>
        /// Gets the name of the computer
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Product Description
        /// </summary>
        public string Description { get; internal set; }



        /// <summary>
        /// default constructor to create an empty object
        /// </summary>
        public CTKProduct() : base()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the CTKProduct class for the specified device number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="id">the device number to retrieve</param>
        /// <remarks>
        /// Only the Number and Name properties will be populated;  the Properties dictionary will be empty
        /// </remarks>

        public CTKProduct(CTKAPI instance, int id) :base()
        {
            GetProduct(instance, id, defaultProperties);
        }

        /// <summary>
        /// Initializes a new instance of the CTKProduct class for the specified device number 
        /// </summary>
        /// <param name="instance">a CTKAPI object</param>
        /// <param name="id">the computer number to retrieve</param>
        /// <param name="propertyNames">a list of property names whose values should be retrieved and added to the Properties dictionary</param>
        public CTKProduct(CTKAPI instance, int id, List<string> propertyNames) : base()
        {
            List<string> props = new List<string>();
            props.AddRange(defaultProperties);
            props.AddRange(propertyNames);
            GetProduct(instance, id, props);
        }

        private void GetProduct(CTKAPI instance, object loadArgs, List<string> propertyNames)
        {
            ctk = instance;
            CTKQuery qry = new CTKQuery();
            qry.ClassName = "Product.Product";
            qry.Attributes.AddRange(propertyNames);

            qry.LoadArgs = loadArgs;

            //submit the request
            CTKResponse resp = instance.Submit(qry);
            CTKResultDictionary rd = (CTKResultDictionary)resp.Results;
            this.ID = Convert.ToInt32(rd[0]["id"]);
            this.Name = rd[0]["name"].ToString();
            this.Description = rd[0]["description"].ToString();
            this.Properties = rd[0];
        }

    }
}
