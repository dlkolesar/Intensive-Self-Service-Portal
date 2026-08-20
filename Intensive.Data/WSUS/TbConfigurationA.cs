using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbConfigurationA
    {
        public int ConfigurationId { get; set; }
        public DateTime LastConfigChange { get; set; }
        public bool DssAnonymousTargeting { get; set; }
        public bool IsRegistrationRequired { get; set; }
        public int MaxDeltaSyncPeriod { get; set; }
        public string ReportingServiceUrl { get; set; }
        public Guid ServerId { get; set; }
        public long? AnonymousCookieExpirationTime { get; set; }
        public long SimpleTargetingCookieExpirationTime { get; set; }
        public long MaximumServerCookieExpirationTime { get; set; }
        public long DssTargetingCookieExpirationTime { get; set; }
        public byte[] EncryptionKey { get; set; }
        public bool ServerTargeting { get; set; }
        public bool SyncToMu { get; set; }
        public string UpstreamServerName { get; set; }
        public int ServerPortNumber { get; set; }
        public bool UpstreamServerUseSsl { get; set; }
        public bool UseProxy { get; set; }
        public string ProxyName { get; set; }
        public int ProxyServerPort { get; set; }
        public bool AnonymousProxyAccess { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }
        public bool HostOnMu { get; set; }
        public string HandshakeAnchor { get; set; }

        public virtual TbConfigurationB TbConfigurationB { get; set; }
        public virtual TbConfigurationC TbConfigurationC { get; set; }
    }
}
