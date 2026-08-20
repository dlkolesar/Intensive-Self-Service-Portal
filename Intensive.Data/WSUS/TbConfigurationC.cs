using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbConfigurationC
    {
        public int ConfigurationId { get; set; }
        public int MaxCoreUpdatesPerRequest { get; set; }
        public int MaxExtendedUpdatesPerRequest { get; set; }
        public string DownloadRegulationUrl { get; set; }
        public bool AllowProxyCredentialsOverNonSsl { get; set; }
        public bool LazySync { get; set; }
        public bool DownloadExpressPackages { get; set; }
        public bool DoServerSyncCompression { get; set; }
        public string ProxyUserDomain { get; set; }
        public long BitsHealthScanningInterval { get; set; }
        public bool BitsDownloadPriorityForeground { get; set; }
        public int MaxXmlPerRequest { get; set; }
        public int MaxXmlPerRequestInServerSync { get; set; }
        public int MaxTargetComputers { get; set; }
        public int MaxEventInstances { get; set; }
        public bool ReplicaMode { get; set; }
        public int LogRolloverFileSizeInBytes { get; set; }
        public bool AutoDeployMandatory { get; set; }
        public int WusinstallType { get; set; }
        public int DeploymentChangeDeferral { get; set; }
        public int RevisionDeletionTimeThreshold { get; set; }
        public int RevisionDeletionSizeThreshold { get; set; }
        public int CoreXmlCompressionThreshold { get; set; }
        public int PublishedXmlCompressionThreshold { get; set; }
        public int MaxDownstreamServers { get; set; }
        public bool CollectClientInventory { get; set; }
        public bool DoDetailedRollup { get; set; }
        public Guid RollupResetGuid { get; set; }
        public int HmDetectIntervalInSeconds { get; set; }
        public int HmRefreshIntervalInSeconds { get; set; }
        public int HmCoreDiskSpaceGreenMegabytes { get; set; }
        public int HmCoreDiskSpaceRedMegabytes { get; set; }
        public int HmCoreCatalogSyncIntervalInDays { get; set; }
        public int HmClientsInstallUpdatesGreenPercent { get; set; }
        public int HmClientsInstallUpdatesRedPercent { get; set; }
        public int HmClientsInventoryGreenPercent { get; set; }
        public int HmClientsInventoryRedPercent { get; set; }
        public int HmClientsInventoryScanDiffInHours { get; set; }
        public int HmClientsSilentGreenPercent { get; set; }
        public int HmClientsSilentRedPercent { get; set; }
        public int HmClientsSilentDays { get; set; }
        public int HmCoreFlags { get; set; }
        public int HmClientsFlags { get; set; }
        public int HmDatabaseFlags { get; set; }
        public int HmWebServicesFlags { get; set; }
        public int HmClientsTooManyGreenPercent { get; set; }
        public int HmClientsTooManyRedPercent { get; set; }

        public virtual TbConfigurationA Configuration { get; set; }
    }
}
