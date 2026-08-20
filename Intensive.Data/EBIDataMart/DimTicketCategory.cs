using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTicketCategory
    {
        public int TicketCategoryKey { get; set; }
        public string TicketCategoryNk { get; set; }
        public string TicketCategoryName { get; set; }
        public string TicketCategoryDescription { get; set; }
        public string TicketSubcategoryName { get; set; }
        public string TicketSubcategoryDescription { get; set; }
        public int? TicketSubcategoryActive { get; set; }
        public DateTime? TicketCategoryEffectiveStartDatetime { get; set; }
        public DateTime? TicketCategoryEffectiveEndDatetime { get; set; }
        public DateTime? TicketCategoryRecordCreatedDatetime { get; set; }
        public string TicketCategoryRecordCreatedBy { get; set; }
        public DateTime? TicketCategoryRecordUpdatedDatetime { get; set; }
        public string TicketCategoryRecordUpdatedBy { get; set; }
        public string TicketCategorySourceSystemName { get; set; }
        public int? TicketCategoryCurrentRecordFlag { get; set; }
    }
}
