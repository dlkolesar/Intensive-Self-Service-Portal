using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Intensive.Services.ActiveDirectory
{
    class AdNewIntensiveUser:AdNewUser
    {
        public string Email { get; set; }
        public string EmployeeId { get; set; }
        public bool IsLinuxTech { get; set; }
        public string Ticket { get; set; }
        public string TargetDN { get; set; }
        public string CopyFromDN { get; set; }

        public override bool IsValid()
        {
            bool ok = base.IsValid();

            if (string.IsNullOrEmpty(this.Email))
            {
                this.Errors.Add($"Please provide a valid email address");
            }

            if (string.IsNullOrEmpty(this.EmployeeId))
            {
                this.Errors.Add($"Please provide a EmployeeId");
            }

            if (string.IsNullOrEmpty(this.Ticket))
            {
                this.Errors.Add($"Please provide valid CORE ticket number");
            }

            if (string.IsNullOrEmpty(this.TargetDN))
            {
                this.Errors.Add($"Please provide a DN of an OU or container where the new user should be created");
            }

            return (this.Errors.Count == 0);
        }
    }
}
