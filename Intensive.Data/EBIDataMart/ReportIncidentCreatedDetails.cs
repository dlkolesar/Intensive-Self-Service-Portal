using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class ReportIncidentCreatedDetails
    {
        public string IncidentDeviceKey { get; set; }
        public string IncidentReferenceNumber { get; set; }
        public DateTime? IncidentCreatedDate { get; set; }
        public string EmployeeTeamName { get; set; }
        public string TeamBusinessSegment { get; set; }
        public string TeamBusinessSubSegment { get; set; }
        public string AccountNumber { get; set; }
        public string AccountGeographicLocation { get; set; }
        public string EmployeeFullName { get; set; }
        public string CurrentIncidentStatusName { get; set; }
        public int? IncidentOpenedEmployeeContactId { get; set; }
        public string IncidentOpenedTeam { get; set; }
        public int? DeviceNumber { get; set; }
        public string DeviceCaption { get; set; }
        public string DeviceType { get; set; }
    }
}
