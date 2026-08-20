using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDeviceCapEx
    {
        public int DimDeviceCapExKey { get; set; }
        public int AssetId { get; set; }
        public int YearMonthKey { get; set; }
        public int DeviceKey { get; set; }
        public string DeviceNumber { get; set; }
        public DateTime? DatePlacedInService { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? AcquisitionCost { get; set; }
        public decimal? AdjustedCost { get; set; }
        public decimal? MonthDepreciation { get; set; }
        public decimal? AccumulatedDepreciation { get; set; }
        public int? LifeInMonths { get; set; }
        public string FaLocation1 { get; set; }
        public string FaLocation2 { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? AcquisitionCostUsd { get; set; }
        public DateTime RecordEffectiveStartDate { get; set; }
        public DateTime RecordEffectiveEndDate { get; set; }
        public int CurrentRecord { get; set; }
        public DateTime RecordCreatedtt { get; set; }
        public string RecordCreateby { get; set; }
        public DateTime RecordUpdatedtt { get; set; }
        public string RecordUpdatedby { get; set; }
    }
}
