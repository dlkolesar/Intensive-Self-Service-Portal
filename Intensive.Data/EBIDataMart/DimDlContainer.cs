using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDlContainer
    {
        public int ContainerKey { get; set; }
        public string ContainerIdNk { get; set; }
        public string ContainerLabel { get; set; }
        public string ContainerNumber { get; set; }
        public string ContainerDatacenterAbbr { get; set; }
        public string ContainerSection { get; set; }
        public string ContainerRow { get; set; }
        public string ContainerKind { get; set; }
        public string ContainerNumberOfSpaces { get; set; }
        public string ContainerColumns { get; set; }
        public string ContainerDescription { get; set; }
        public string ContainerAccountNumber { get; set; }
        public DateTime? EffectiveStartDatetime { get; set; }
        public DateTime? EffectiveEndDatetime { get; set; }
        public DateTime RecordCreatedDatetime { get; set; }
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUdpatedDatetime { get; set; }
        public string RecordUpdatedBy { get; set; }
        public string AccountSourceSystemName { get; set; }
        public string RecordSourceSystem { get; set; }
        public int CurrentRecord { get; set; }
    }
}
