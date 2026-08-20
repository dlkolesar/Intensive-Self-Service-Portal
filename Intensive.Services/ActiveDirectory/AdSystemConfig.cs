using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Intensive.Services.ActiveDirectory
{
    public class AdSystemConfig
    {
        public int SystemId { get; set; }
        public string  DomainName { get; set; }
        public string DomainFQDN { get; set; }
        public int PasswordLength { get; set; }
        public int PasswordLifeHours { get; set; }
        public int AccountAccessLifeHours { get; set; }
        //public string ADMTServer { get; set; }

        public AdSystemConfig()
        {
        }
    }
}

