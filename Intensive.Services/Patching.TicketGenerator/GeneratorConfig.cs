using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Intensive.Services.Patching.TicketGenerator
{
    public class GeneratorConfig
    {
        public string SMTPServerName { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPwd { get; set; }

        public string CoreURL { get; set; }
        public string COREUser { get; set; }
        public string COREPwd { get; set; }
        
        public string TicketTemplate { get; set; }
        public string EmailRecipients { get; set; }

        public string ApprovedUpdates { get; set; }
        public string DeclinedUpdates { get; set; }

        public GeneratorConfig()
        {

        }

        
    }
}
