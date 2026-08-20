using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.ActiveDirectory
{
    public class AdCustomerAccess
    {
        public int Account { get; set; }
        public DateTime Expires { get; set; }

        public AdCustomerAccess(int acct, DateTime expires)
        {
            this.Account = acct;
            this.Expires = expires;
        }
    }
}
