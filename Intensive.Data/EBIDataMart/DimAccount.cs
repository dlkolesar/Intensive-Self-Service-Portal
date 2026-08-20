using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimAccount
    {
        public DimAccount()
        {
            FactAccountProductPriceDailySnapshot = new HashSet<FactAccountProductPriceDailySnapshot>();
            FactDeviceBuildError = new HashSet<FactDeviceBuildError>();
            FactDeviceLocationDetail = new HashSet<FactDeviceLocationDetail>();
            FactDeviceLocationMtdHistory = new HashSet<FactDeviceLocationMtdHistory>();
            FactDeviceStatus = new HashSet<FactDeviceStatus>();
            FactIncidentAssignedTime = new HashSet<FactIncidentAssignedTime>();
            FactIncidentCreated = new HashSet<FactIncidentCreated>();
            FactIncidentDevice = new HashSet<FactIncidentDevice>();
            FactIncidentEotr = new HashSet<FactIncidentEotr>();
            FactIncidentMessage = new HashSet<FactIncidentMessage>();
            FactIncidentParentchild = new HashSet<FactIncidentParentchild>();
            FactIncidentQueuetime = new HashSet<FactIncidentQueuetime>();
            FactIncidentWorked = new HashSet<FactIncidentWorked>();
            FactMonitoringAlert = new HashSet<FactMonitoringAlert>();
            FactMonitoringAlertRackwatch = new HashSet<FactMonitoringAlertRackwatch>();
        }

        public int AccountKey { get; set; }
        public string AccountCaption { get; set; }
        public string AccountICompanyId { get; set; }
        public long? AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string AccountTypeDesc { get; set; }
        public long? AccountStatusId { get; set; }
        public string AccountStatus { get; set; }
        public string AccountStatusDesc { get; set; }
        public string AccountSlaType { get; set; }
        public string AccountSlaTypeDesc { get; set; }
        public long? AccountBusinessTypeId { get; set; }
        public string AccountBusinessType { get; set; }
        public string AccountBusinessTypeDesc { get; set; }
        public string AccountTeamName { get; set; }
        public string AccountManagerContactId { get; set; }
        public string AccountManager { get; set; }
        public long? AccountBdcContactId { get; set; }
        public string AccountBdc { get; set; }
        public string AccountPrimaryContactId { get; set; }
        public string AccountPrimaryContact { get; set; }
        public DateTime? AccountFirstServerOnline { get; set; }
        public int? AccountTenureDays { get; set; }
        public short? AccountBackupDeviceCount { get; set; }
        public short? AccountStorageDeviceCount { get; set; }
        public short? AccountOtherNetworkDeviceCount { get; set; }
        public short? AccountServerCount { get; set; }
        public short? AccountUnknownDeviceCount { get; set; }
        public short? AccountAllDeviceCount { get; set; }
        public string AccountRegion { get; set; }
        public string AccountGeographicLocation { get; set; }
        public decimal? AccountSubscriptionAmount { get; set; }
        public byte? AccountEmerInstrExists { get; set; }
        public DateTime? AccountCreatedDate { get; set; }
        public DateTime? RecAdded { get; set; }
        public DateTime? RecUpdated { get; set; }
        public byte? CurrentRecord { get; set; }
        public string AccountNk { get; set; }
        public string AccountBillingStreet { get; set; }
        public string AccountBillingCity { get; set; }
        public string AccountBillingState { get; set; }
        public string AccountBillingPostalCode { get; set; }
        public string AccountBillingCountry { get; set; }
        public string AccountShippingStreet { get; set; }
        public string AccountShippingCity { get; set; }
        public string AccountShippingState { get; set; }
        public string AccountShippingPostalCode { get; set; }
        public string AccountShippingCountry { get; set; }
        public string AccountPhone { get; set; }
        public string AccountFax { get; set; }
        public string AccountWebsite { get; set; }
        public string AccountSic { get; set; }
        public string AccountCustomerType { get; set; }
        public decimal? AccountAnnualRevenue { get; set; }
        public int? AccountNumberOfEmployees { get; set; }
        public string AccountOwnership { get; set; }
        public string AccountTickerSymbol { get; set; }
        public string AccountDescription { get; set; }
        public string AccountRating { get; set; }
        public string AccountSite { get; set; }
        public string AccountCurrencyIsoCode { get; set; }
        public string AccountOwnerId { get; set; }
        public DateTime? AccountRecordCreatedDatetime { get; set; }
        public DateTime? AccountEffectiveStartDatetime { get; set; }
        public string AccountRecordCreatedBy { get; set; }
        public DateTime? AccountEffectiveEndDatetime { get; set; }
        public string AccountRecordUpdatedBy { get; set; }
        public DateTime? AccountRecordUpdatedDatetime { get; set; }
        public string AccountSourceSystemName { get; set; }
        public string AccountExecutiveSponsor { get; set; }
        public string AccountSubType { get; set; }
        public string AccountDoNotCall { get; set; }
        public string AccountDoNotEmail { get; set; }
        public string AccountDoNotMail { get; set; }
        public string AccountIsPartner { get; set; }
        public int? AccountHighProfileFlag { get; set; }
        public int? AccountHasUnmeteredBackup { get; set; }
        public int AccountIsParent { get; set; }
        public int AccountParentId { get; set; }
        public string AccountPromotionCode { get; set; }
        public int? AccountCompedFlag { get; set; }
        public DateTime? AccountLastBilledDate { get; set; }
        public int? AccountDesiredBillingDay { get; set; }
        public string CustomerNumber { get; set; }
        public string AccountServiceLevel { get; set; }
        public string AccountTypeLevel2 { get; set; }
        public int AccountBizsparkFlag { get; set; }
        public string AccountLeadTech { get; set; }
        public string CrossPlatformLeadTech { get; set; }
        public string AccountServiceLevelName { get; set; }
        public string AccountServiceType { get; set; }
        public DateTime? AccountServiceLevelDatetime { get; set; }
        public string AccountClassification { get; set; }
        public byte? IsBillable { get; set; }

        public virtual ICollection<FactAccountProductPriceDailySnapshot> FactAccountProductPriceDailySnapshot { get; set; }
        public virtual ICollection<FactDeviceBuildError> FactDeviceBuildError { get; set; }
        public virtual ICollection<FactDeviceLocationDetail> FactDeviceLocationDetail { get; set; }
        public virtual ICollection<FactDeviceLocationMtdHistory> FactDeviceLocationMtdHistory { get; set; }
        public virtual ICollection<FactDeviceStatus> FactDeviceStatus { get; set; }
        public virtual ICollection<FactIncidentAssignedTime> FactIncidentAssignedTime { get; set; }
        public virtual ICollection<FactIncidentCreated> FactIncidentCreated { get; set; }
        public virtual ICollection<FactIncidentDevice> FactIncidentDevice { get; set; }
        public virtual ICollection<FactIncidentEotr> FactIncidentEotr { get; set; }
        public virtual ICollection<FactIncidentMessage> FactIncidentMessage { get; set; }
        public virtual ICollection<FactIncidentParentchild> FactIncidentParentchild { get; set; }
        public virtual ICollection<FactIncidentQueuetime> FactIncidentQueuetime { get; set; }
        public virtual ICollection<FactIncidentWorked> FactIncidentWorked { get; set; }
        public virtual ICollection<FactMonitoringAlert> FactMonitoringAlert { get; set; }
        public virtual ICollection<FactMonitoringAlertRackwatch> FactMonitoringAlertRackwatch { get; set; }
    }
}
