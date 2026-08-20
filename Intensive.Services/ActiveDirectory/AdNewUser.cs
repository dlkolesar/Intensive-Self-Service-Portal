using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.ActiveDirectory
{
    public class AdNewUser : AdNewUserBase
    {

        public bool ServiceAccount { get; set; }

        public AdNewUser() : base()
        {
            
        }

        public override bool IsValid()
        {
            return base.IsValid();
        }
    }
}
