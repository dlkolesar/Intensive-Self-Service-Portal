using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimDevice
    {
        public int DeviceKey { get; set; }
        public string DeviceCaption { get; set; }
        public int? DeviceNumber { get; set; }
        public string DeviceType { get; set; }
        public string DeviceStatus { get; set; }
        public int? DeviceStatusNumber { get; set; }
        public long? DeviceAssignedAccountNumber { get; set; }
        public string DeviceDatacenterAbbr { get; set; }
        public decimal? DeviceMonthlyFee { get; set; }
        public decimal? DeviceCmrr { get; set; }
        public decimal? DeviceSetupFee { get; set; }
        public string DeviceContractTerm { get; set; }
        public string DeviceOs { get; set; }
        public string DeviceOsName { get; set; }
        public string DeviceHostName { get; set; }
        public string DeviceManufacturer { get; set; }
        public bool? DeviceBillingUnit { get; set; }
        public DateTime? DeviceOnlineDate { get; set; }
        public DateTime? DeviceOfflineDate { get; set; }
        public int? DeviceTenureDays { get; set; }
        public string DeviceBandWidthSubscription { get; set; }
        public string DeviceOfflineReason { get; set; }
        public string DeviceBackupSubscription { get; set; }
        public decimal? DeviceBackupSubscriptionAmount { get; set; }
        public bool? DeviceBounceBackup { get; set; }
        public DateTime? DeviceCreateDate { get; set; }
        public DateTime? DevicePlacedOrderDate { get; set; }
        public DateTime? DeviceFinishedOrderDate { get; set; }
        public DateTime? DeviceContractReceivedDate { get; set; }
        public DateTime? DeviceContractEndDate { get; set; }
        public DateTime? DeviceLastContractRenewalDate { get; set; }
        public DateTime? DeviceLastModifiedDate { get; set; }
        public string DeviceSalesRep1 { get; set; }
        public string DeviceSalesRep2 { get; set; }
        public string DeviceRackwatchSla { get; set; }
        public byte? DeviceEmerInstrExists { get; set; }
        public DateTime? DeviceEmerInstrUpdatedDate { get; set; }
        public DateTime? RecAdded { get; set; }
        public DateTime? RecUpdated { get; set; }
        public int? CurrentRecord { get; set; }
        public DateTime? DueToCustomerDate { get; set; }
        public DateTime? DueToSupportDate { get; set; }
        public string DeviceConfigBuiltBy { get; set; }
        public string DeviceActiveStatus { get; set; }
        public string DeviceOnlineStatus { get; set; }
        public DateTime? DeviceRecordEffectiveStartDatetime { get; set; }
        public DateTime? DeviceRecordEffectiveEndDatetime { get; set; }
        public string DeviceMbuSiteId { get; set; }
        public string DeviceMakeModel { get; set; }
        public string DeviceMake { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceRaidType { get; set; }
        public string DeviceOsVersion { get; set; }
        public int? ChassisSize { get; set; }
        public string DeviceUsageType { get; set; }
        public string DeviceTypeIcon { get; set; }
    }
}
