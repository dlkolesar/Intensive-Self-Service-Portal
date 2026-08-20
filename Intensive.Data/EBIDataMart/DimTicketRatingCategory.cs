using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTicketRatingCategory
    {
        public int TicketRatingCategoryKey { get; set; }
        public string TicketRatingCategoryNk { get; set; }
        public string TicketRatingCategoryDescription { get; set; }
        public bool? TicketRatingCategoryActive { get; set; }
        public int? TicketRatingCategoryCategoryId { get; set; }
        public string TicketRatingCategoryBetaProgram { get; set; }
        public string TicketRatingCategorySourceSystemName { get; set; }
        public DateTime EffectiveStartDatetime { get; set; }
        public DateTime EffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string SourceSystemName { get; set; }
        public int CurrentRecord { get; set; }
    }
}
