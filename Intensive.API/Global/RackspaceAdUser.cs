using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.API.Global
{
    public class RackspaceAdUser : RackspaceAdObject
    {
        public DateTime accountExpirationDate { get; set; }
        public DateTime accountLockoutTime { get; set; }
        public string assistant { get; set; }
        public int badLogonCount { get; set; }
        public string businessCategory { get; set; }
        public string c { get; set; }
        public string co { get; set; }
        public string contingentWorker { get; set; }
        public string contingentWorkerType { get; set; }
        public DateTime continuousServiceDate { get; set; }
        public string continuousServiceDateStr { get; set; }
        public string CORE_contactID { get; set; }
        public string CORE_crmID { get; set; }
        public string CORE_employeeID { get; set; }
        public string costCenter { get; set; }
        public string costCenterDescription { get; set; }
        public string costCenterL1 { get; set; }
        public string costCenterL2 { get; set; }
        public string costCenterL3 { get; set; }
        public string costCenterL4 { get; set; }
        public string costCenterL5 { get; set; }
        public string costCenterL6 { get; set; }
        public string costCenterL7 { get; set; }
        public string countryCode { get; set; }
        public string datapipeDepartment { get; set; }
        public string datapipeEmail { get; set; }
        public string datapipeSSO { get; set; }
        public string department { get; set; }
        public string departmentNumber { get; set; }
        public List<RackspaceAdDNObject> directReports { get; set; }
        public string directSupervisorEmail { get; set; }
        public string division { get; set; }
        public string employeeID { get; set; }
        public string employeeStatus { get; set; }
        public string employeeType { get; set; }
        public string ExponentHRID { get; set; }
        public string GitHubUserName { get; set; }
        public int gidNumber { get; set; }
        public string givenName { get; set; }
        public string homePhone { get; set; }
        public string initials { get; set; }
        public string ipPhone { get; set; }
        public bool isAccountEnabled { get; set; }
        public bool isAccountLockedOut { get; set; }
        public bool isManager { get; set; }
        public string jobCode { get; set; }
        public string l { get; set; }
        public DateTime lastBadPasswordAttempt { get; set; }
        public DateTime lastLogon { get; set; }
        public DateTime lastLogonTimeStamp { get; set; }
        public string loginShell { get; set; }
        public string mail { get; set; }
        public string managementLevel { get; set; }
        public RackspaceAdDNObject manager { get; set; }
        public List<RackspaceAdDNObject> member { get; set; }
        public string managerWorkforceID { get; set; }
        public string mobile { get; set; }
        public string[] msExchCoManagedByLink { get; set; }
        public bool notary { get; set; }
        public DateTime passwordLastSet { get; set; }
        public bool passwordNeverExpires { get; set; }
        public string photo { get; set; }
        public string physicalDeliveryOfficeName { get; set; }
        public string preferredLanguage { get; set; }
        public string preferredName { get; set; }
        public string[] rsBalabitSSHPublicKey { get; set; }
        public string startDate { get; set; }
        public string Strength1 { get; set; }
        public string Strength2 { get; set; }
        public string Strength3 { get; set; }
        public string Strength4 { get; set; }
        public string Strength5 { get; set; }
        public string supportTeam { get; set; }
        public string surname { get; set; }
        public string telephone { get; set; }
        public string thumbnailPhoto { get; set; }
        public string timezone { get; set; }
        public string title { get; set; }
        public string uid { get; set; }
        public string uidNumber { get; set; }
        public string unixHomeDirectory { get; set; }
        public string userPrincipalName { get; set; }
        public string workforceID { get; set; }
        public string workShift { get; set; }
        public string workStartDate { get; set; }
        public string workTermDate { get; set; }
    }
}
