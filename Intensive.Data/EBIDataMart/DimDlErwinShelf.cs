using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDlErwinShelf
    {
        public int ErwinShelfKey { get; set; }
        public string ErwinShelfIdNk { get; set; }
        public int? ErwinShelfContainerId { get; set; }
        public int? ErwinShelfUHeight { get; set; }
        public int? ErwinShelfNumberOfSpaces { get; set; }
        public int? ErwinShelfNumPerWidth { get; set; }
        public int? ErwinShelfStartingSpace { get; set; }
        public DateTime? RecordEffectiveStartDatetime { get; set; }
        public DateTime? RecordEffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUdpatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string RecordSourceSystem { get; set; }
        public int CurrentRecord { get; set; }
    }
}
