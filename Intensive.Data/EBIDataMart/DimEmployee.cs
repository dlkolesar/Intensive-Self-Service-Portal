using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimEmployee
    {
        public int EmployeeKey { get; set; }
        public int? EmployeeNumber { get; set; }
        public int? EmployeeContactId { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeContactRole { get; set; }
        public string EmployeeStreet { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeState { get; set; }
        public string EmployeePostalCode { get; set; }
        public DateTime? EmployeeCreated { get; set; }
        public string EmployeeCountry { get; set; }
        public string EmployeeCountryAbbrv { get; set; }
        public string EmployeeCountryCode { get; set; }
        public string EmployeePrimaryPhone { get; set; }
        public string EmployeePrimaryEmail { get; set; }
        public DateTime? RecAdded { get; set; }
        public DateTime? RecUpdated { get; set; }
        public int? CurrentRecord { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public string SourceSystemName { get; set; }
        public string EmployeeSso { get; set; }
    }
}
