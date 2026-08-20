using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbConfigurationB
    {
        public int ConfigurationId { get; set; }
        public string LocalContentCacheLocation { get; set; }
        public bool ServerSupportsAllLanguages { get; set; }
        public int LogLevel { get; set; }
        public string LogPath { get; set; }
        public int SubscriptionFailureNumberOfRetries { get; set; }
        public long SubscriptionFailureWaitBetweenRetriesTime { get; set; }
        public long DispatchManagerPollingInterval { get; set; }
        public bool StateMachineTransitionLoggingEnabled { get; set; }
        public long StateMachineTransitionErrorCaptureLength { get; set; }
        public int MaxSimultaneousFileDownloads { get; set; }
        public string Muurl { get; set; }
        public int MaxNumberOfIdsToRequestDataFromUss { get; set; }
        public long EventLogFloodProtectTime { get; set; }
        public bool DoReportingDataValidation { get; set; }
        public bool DoReportingSummarization { get; set; }
        public string StatsDotNetWebServiceUri { get; set; }
        public int QueueFlushTimeInMs { get; set; }
        public int QueueFlushCount { get; set; }
        public int QueueRejectCount { get; set; }
        public int SleepTimeAfterErrorInMs { get; set; }
        public int LogDestinations { get; set; }
        public bool AutoRefreshDeployments { get; set; }
        public long RedirectorChangeNumber { get; set; }
        public string ImportLocalPath { get; set; }
        public bool UseCookieValidation { get; set; }
        public int? AutoPurgeDetectionPeriod { get; set; }
        public int? AutoPurgeClientEventAgeThreshold { get; set; }
        public int? AutoPurgeServerEventAgeThreshold { get; set; }

        public virtual TbConfigurationA Configuration { get; set; }
    }
}
