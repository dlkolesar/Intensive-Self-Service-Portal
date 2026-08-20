using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.ActiveDirectory
{

    public class AdNewIntensiveCustAccount : AdNewUserBase
    {
        public string RackerSSO { get; set; }
        public string CoreTicket { get; set; }

        public AdNewIntensiveCustAccount() : base()
        {
        }

        public override bool IsValid()
        {
            base.IsValid();

            if (string.IsNullOrEmpty(this.RackerSSO))
            {
                this.Errors.Add($"Please provide the employee id of the Racker that this account is for");
            }

            if (string.IsNullOrEmpty(this.CoreTicket))
            {
                this.Errors.Add($"Please provide the CORE ticket number documenting the request for Intensive credentials");
            }

            return (this.Errors.Count == 0);
        }
    }

    public class AdNewIntensiveUserAccount : AdNewIntensiveCustAccount
    {
        public bool IsLinuxTech { get; set; }


        public AdNewIntensiveUserAccount(): base()
        {
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }
    }

  
}
