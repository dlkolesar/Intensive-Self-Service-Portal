using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTicket
    {
        public int TicketKey { get; set; }
        public string TicketNk { get; set; }
        public string TicketReferenceNumber { get; set; }
        public string TicketSubject { get; set; }
        public string TicketCreatedMethod { get; set; }
        public int? TicketPrivateFlag { get; set; }
        public string TicketCreatorName { get; set; }
        public string TicketSubmitterName { get; set; }
        public int? TicketCurrentNpsT { get; set; }
        public string TicketCurrentSeverity { get; set; }
        public string TicketCurrentPriority { get; set; }
        public string TicketCurrentCategory { get; set; }
        public string TicketCurrentSubcategory { get; set; }
        public string TicketCurrentStatus { get; set; }
        public int? TicketCurrentDifficulty { get; set; }
        public DateTime? TicketCreatedDatetime { get; set; }
        public DateTime? TicketModifiedDatetime { get; set; }
        public string TicketSourceSystemName { get; set; }
        public DateTime? TicketEffectiveStartDatetime { get; set; }
        public DateTime? TicketEffectiveEndDatetime { get; set; }
        public DateTime? TicketRecordCreatedDatetime { get; set; }
        public string TicketRecordCreatedBy { get; set; }
        public DateTime? TicketRecordUpdatedDatetime { get; set; }
        public string TicketRecordUpdatedBy { get; set; }
        public string SourceTimezone { get; set; }
        public int? TicketCurrentRecordFlag { get; set; }
        public string TicketRatingComment { get; set; }
        public int TicketMassFlag { get; set; }
        public string TicketDescription { get; set; }
    }
}
