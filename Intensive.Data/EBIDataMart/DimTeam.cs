using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTeam
    {
        public int TeamKey { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string TeamReportHeader { get; set; }
        public int? TeamRoleId { get; set; }
        public int TeamActive { get; set; }
        public string TeamDataSource { get; set; }
        public string TeamBusinessSegment { get; set; }
        public string TeamBusinessSubSegment { get; set; }
        public int? TeamReportHeaderId { get; set; }
        public int? TeamBusinessSegmentReportId { get; set; }
        public int? TeamBusinessSubSegmentReportId { get; set; }
        public DateTime RecAdded { get; set; }
        public DateTime RecUpdated { get; set; }
        public int CurrentRecord { get; set; }
        public int? TeamRecordSourceId { get; set; }
        public string TeamRecordUpdatedBy { get; set; }
        public DateTime? TeamRecordUpdatedDatetime { get; set; }
        public string TeamRecordCreatedBy { get; set; }
        public DateTime? TeamRecordCreatedDatetime { get; set; }
        public DateTime? TeamRecordEffectiveStartDatetime { get; set; }
        public DateTime? TeamRecordEffectiveEndDatetime { get; set; }
        public string TeamCompany { get; set; }
        public string TeamDivision { get; set; }
    }
}
