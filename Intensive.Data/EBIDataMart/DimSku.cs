using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSku
    {
        public int SkuKey { get; set; }
        public int SkuNumber { get; set; }
        public string SkuNumberExternal { get; set; }
        public string SkuName { get; set; }
        public string SkuDescription { get; set; }
        public string SkuProductCategory { get; set; }
        public string SkuProductSubCategory { get; set; }
        public string SkuRequirements { get; set; }
        public string SkuCoreCategory { get; set; }
        public int SkuItemQuantity { get; set; }
        public decimal? SkuLicenseCost { get; set; }
        public string SkuLicenseManufacturer { get; set; }
        public string SkuLicenseGroupName { get; set; }
        public decimal? SkuLicenseProcessorMultiplier { get; set; }
        public decimal? SkuLicenseCalMultiplier { get; set; }
        public int? SkuLicenseMsAdvancedOrStandard { get; set; }
        public int? SkuLicenseMsAuthOrUnAuth { get; set; }
        public int? SkuLicenseMsStandardOrEnterprise { get; set; }
        public int? SkuLicenseMsMomPack { get; set; }
        public string SkuLicenseOsVersion { get; set; }
        public int? SkuLicenseOsFreeOrPaid { get; set; }
        public int? SkuLicenseBackupAgentBase { get; set; }
        public int? SkuLicenseBackupAgentSql { get; set; }
        public int? SkuLicenseBackupAgentCluster { get; set; }
        public int? SkuLicenseBackupAgentOracle { get; set; }
        public int? SkuLicenseBackupAgentTier { get; set; }
        public string SkuHardwareFirewallType { get; set; }
        public string SkuHardwareFirewallCapacity { get; set; }
        public string SkuHardwareLoadBalancerType { get; set; }
        public int? SkuHardwareLoadBalancerRedundant { get; set; }
        public int? SkuHardwareChassisUnitSize { get; set; }
        public string SkuSoftwareTypeName { get; set; }
        public string SkuSoftwareVersion { get; set; }
        public string SkuSoftwareSeats { get; set; }
        public int? SkuSoftwareHostwareSupport { get; set; }
        public int SkuBounceBackup { get; set; }
        public DateTime? SkuRecAdded { get; set; }
        public DateTime SkuRecUpdated { get; set; }
        public int SkuRecCount { get; set; }
        public int SkuCurrentRecord { get; set; }
        public string SkuLevel1 { get; set; }
        public string SkuLevel2 { get; set; }
        public string SkuLevel3 { get; set; }
        public string SkuLevel4 { get; set; }
        public int? SkuReportable { get; set; }
        public string SkuCaptionDisplayName { get; set; }
        public string SkuProductKey { get; set; }
        public string SkuProductId { get; set; }
        public decimal? SkuAcademicLicenseCost { get; set; }
        public decimal? SkuBizsparkLicenseCost { get; set; }
        public DateTime SkuEffectiveStartDatetime { get; set; }
        public DateTime SkuEffectiveEndDatetime { get; set; }
        public DateTime SkuRecordCreatedDatetime { get; set; }
        public string SkuRecordCreatedBy { get; set; }
        public DateTime SkuRecordUpdatedDatetime { get; set; }
        public string SkuRecordUpdatedBy { get; set; }
        public string SkuSourceSystemName { get; set; }
    }
}
