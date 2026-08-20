using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Intensive.Services.ActiveDirectory
{
    public class AdNewIntensiveServiceAccount: AdNewUserBase    
    {
        //
        // see https://one.rackspace.com/pages/viewpage.action?spaceKey=SegSup&title=Service+Account+Creation for Service Account creation policies
        //

        public string Owner { get; set; }   //Department/BU that "owns" the service account; set in the description attribute "Owned by {this.Owner}
        public string MailingList { get; set; }   //populates the "mail" attribute

        public AdNewIntensiveServiceAccount(): base()
        {  
        }

        public override bool IsValid()
        {
            base.IsValid(); //will populate the Errors List if any issues

            if ( string.IsNullOrEmpty(this.Owner) )
            {
                this.Errors.Add($"Please provide the name of the department, group, business unit, that will 'own' the account");
            }

            if (string.IsNullOrEmpty(this.MailingList))
            {
                this.Errors.Add($"Please provide the name of the department, group, business unit, that will 'own' the account");
            }

            if ( (!this.MailingList.ToLower().EndsWith("@rackspace.com")) && (this.MailingList.Length !> 14) )   
            {
                this.Errors.Add($"Please provide a valid Rackspace email address for a distribution list for communications concerning the service account");
            }

            return (this.Errors.Count == 0);
        }

    }
}
