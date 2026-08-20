using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.API.Global
{
    public class RackspaceAdObject
    {
        public string cn { get; set; }
        public string description { get; set; }
        public string displayName { get; set; }
        public string distinguishedName { get; set; }
        public string groupType { get; set; }
        public string info { get; set; }
        public string managedBy { get; set; }
        public List<RackspaceAdDNObject> memberOf { get; set; }
        public string name { get; set; }
        public string[] objectClass { get; set; }
        public string objectGUID { get; set; }
        public string objectSID { get; set; }
        public string samAccountName { get; set; }
        public string userAccountControl { get; set; }
        public DateTime whenChanged { get; set; }
        public DateTime whenCreated { get; set; }
    }
}
