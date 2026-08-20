using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.ActiveDirectory
{
    public abstract class AdNewUserBase
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
       
        public List<string> Errors { get; set; }

        public AdNewUserBase()
        {
            this.Errors = new List<string>();
        }

        public virtual bool IsValid()
        {
            if (string.IsNullOrEmpty(this.UserId))
            {
                this.Errors.Add($"Please provide a UserID");
            }

            if ( (string.IsNullOrEmpty(FirstName)) && (string.IsNullOrEmpty(LastName)) && (string.IsNullOrEmpty(FullName)) )
            {
                this.Errors.Add($"Please provide a first name and a last name, or a full name");
            }

            return (this.Errors.Count == 0);
        }
    }
}
