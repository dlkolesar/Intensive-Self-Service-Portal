using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimBillingEventsTeam
    {
        public DimBillingEventsTeam()
        {
            FactAccountStatus = new HashSet<FactAccountStatus>();
        }

        public int TeamKey { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string TeamReportHeader { get; set; }
        public int? TeamRoleId { get; set; }
        public int? TeamActive { get; set; }
        public string TeamDataSource { get; set; }
        public string TeamBusinessSegment { get; set; }
        public string TeamBusinessSubSegment { get; set; }
        public int? TeamReportHeaderId { get; set; }
        public int? TeamBusinessSegmentReportId { get; set; }
        public int? TeamBusinessSubSegmentReportId { get; set; }
        public string TeamSuperRegion { get; set; }
        public string TeamRegion { get; set; }
        public string TeamSubregion { get; set; }
        public string TeamCountry { get; set; }
        public string TeamBusinessUnit { get; set; }
        public string TeamParentNk { get; set; }
        public string TeamCompany { get; set; }
        public string TeamDivision { get; set; }
        public DateTime? TeamCreationDate { get; set; }
        public DateTime? TeamModificationDate { get; set; }
        public string SourceSystemName { get; set; }
        public string TeamRecordCreatedBy { get; set; }
        public DateTime? TeamRecordCreatedAt { get; set; }
        public string TeamRecordUpdatedBy { get; set; }
        public DateTime? TeamRecordUpdatedAt { get; set; }
        public DateTime? TeamEffectiveStartDatetime { get; set; }
        public DateTime? TeamEffectiveEndDatetime { get; set; }
        public int? CurrentRecord { get; set; }
        public string TeamRecordSourceId { get; set; }
        public DateTime? RecAdded { get; set; }
        public DateTime? RecUpdated { get; set; }
        public string TeamSsk { get; set; }

        public virtual ICollection<FactAccountStatus> FactAccountStatus { get; set; }
    }
}
