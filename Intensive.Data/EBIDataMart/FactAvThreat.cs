using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactAvThreat
    {
        public int ThreatDetectedDateKey { get; set; }
        public int? ThreatDetectedDateHmsKey { get; set; }
        public int AccountKey { get; set; }
        public int TeamKey { get; set; }
        public int DeviceKey { get; set; }
        public int ThreatKey { get; set; }
        public int ActionKey { get; set; }
        public int ThreatActionDateKey { get; set; }
        public int? ThreatActionDateHmsKey { get; set; }
        public int PathKey { get; set; }
        public string ThreatEventId { get; set; }
        public int ThreatCount { get; set; }
        public string AvThreatSourceName { get; set; }
        public DateTime? AvThreatRecordCreatedDate { get; set; }
        public string AvThreatRecordCreatedBy { get; set; }
        public DateTime? AvThreatRecordUpdatedDate { get; set; }
        public string AvThreatRecordUpdatedBy { get; set; }
        public int ThreatDetectedLocalDateKey { get; set; }
        public int? ThreatDetectedLocalDateHmsKey { get; set; }
        public int ThreatActionLocalDateKey { get; set; }
        public int? ThreatActionLocalDateHmsKey { get; set; }
        public int ThreatId { get; set; }
        public string Username { get; set; }
        public int? ThreatTypeKey { get; set; }
    }
}
