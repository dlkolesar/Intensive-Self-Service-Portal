using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{

    /// <summary>
    ///Intensive.Services.CTKAPIWrapper.CTKObjects namespace contain a set of convenience objects to make
    /// working with common objects a little easier.  Each class is derived from the <see cref="CTKObject"/> class, and 
    /// contains a limited number of 
    /// unique identifying properties, usually some sort of id and a display name/description.  
    /// Additional properties can be requested and the values for those properties will be held in
    /// a <i>Properties</i> Dictionary object.
    /// 
    /// Additionally, each class can have methods that correspond to the CTKAPI Methods for that object
    /// </summary>
//    internal static class NamespaceDoc { }    //dummy class used to generate Namespace documentation



    /// <summary>
    /// The CTKObject class is a base class for all objects in the CKTObjects namespace
    /// </summary>
    public abstract class CTKObject
    {
        protected CTKAPI ctk;

        /// <summary>
        /// A dictionary object that containing the requested property names and their values
        /// </summary>
        public Dictionary<string, object> Properties { get; internal set; }

        /// <summary>
        /// default constructor to create an empty object
        /// </summary>
        public CTKObject()
        {
            this.Properties = new Dictionary<string, object>();
        }

    }
}
