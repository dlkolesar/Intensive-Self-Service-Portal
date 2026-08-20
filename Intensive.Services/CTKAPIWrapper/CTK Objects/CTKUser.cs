using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper.CTKObjects
{
    /// <summary>
    /// The CTKUSer object represents the current CORE CTKAPI user.  This object is returned by the 
    /// <see cref="CTKAPI"/><b>.CurrentUser</b> property.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class CTKUser
    {
        /// <summary>
        /// The CORE username
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Indicates if the user is a real User or a system userid
        /// </summary>
        public bool valid { get; set; }

        /// <summary>
        /// The CORE Contact ID number
        /// </summary>
        public string contact_id { get; set; }

        /// <summary>
        /// The Employee ID number
        /// </summary>
        public string employee_number { get; set; }

        /// <summary>
        /// a list of the departments the user belongs to
        /// </summary>
        public List<string> departments { get; set; }


        /// <summary>
        /// initialize the class with default values
        /// </summary>
        public CTKUser()
        {
        }



    }
}
