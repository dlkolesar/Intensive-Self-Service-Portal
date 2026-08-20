using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimChatConfiguration
    {
        public int ChatConfigurationKey { get; set; }
        public string ChatConfigurationNk { get; set; }
        public string ChatUserLocation { get; set; }
        public string ChatUserAgent { get; set; }
        public string ChatUserBrowser { get; set; }
        public string ChatUserPlatform { get; set; }
        public string ChatUserBrowserLanguage { get; set; }
        public string ChatUserScreenResolution { get; set; }
        public string ChatUserLanguage { get; set; }
        public string ChatUserTerritory { get; set; }
        public string ChatUserPortal { get; set; }
        public string ChatConfigurationRecordCreatedBy { get; set; }
        public DateTime ChatConfigurationRecordCreatedDatetime { get; set; }
        public string ChatConfigurationRecordUpdatedBy { get; set; }
        public DateTime ChatConfigurationRecordUpdatedDatetime { get; set; }
        public string ChatConfigurationNkColumns { get; set; }
        public string StatusSourceSystemName { get; set; }
    }
}
