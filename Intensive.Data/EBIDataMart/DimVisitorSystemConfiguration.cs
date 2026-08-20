using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimVisitorSystemConfiguration
    {
        public long VisitorSystemConfigurationKey { get; set; }
        public string VisitorSystemConfigurationSourceSystemIdNk { get; set; }
        public string VisitorSystemConfigurationBrowsers { get; set; }
        public string VisitorSystemConfigurationBrowserType { get; set; }
        public string VisitorSystemConfigurationOperatingSystems { get; set; }
        public string VisitorSystemConfigurationJava { get; set; }
        public string VisitorSystemConfigurationJavascript { get; set; }
        public string VisitorSystemConfigurationJavascriptVersion { get; set; }
        public string VisitorSystemConfigurationCookies { get; set; }
        public string VisitorSystemConfigurationConnectionTypes { get; set; }
        public string VisitorSystemConfigurationConnectionName { get; set; }
        public string VisitorSystemConfigurationMobileCarrier { get; set; }
        public string VisitorSystemConfigurationCarrierDomain { get; set; }
        public string VisitorSystemConfigurationLanguages { get; set; }
        public string VisitorSystemConfigurationLanguageName { get; set; }
        public string VisitorSystemConfigurationBrowserWidth { get; set; }
        public string VisitorSystemConfigurationBrowserHeight { get; set; }
        public string VisitorSystemConfigurationMonitorColorDepths { get; set; }
        public string VisitorSystemConfigurationMonitorResolutions { get; set; }
        public string VisitorSystemConfigurationCreatedBy { get; set; }
        public DateTime? VisitorSystemConfigurationCreatedDatetime { get; set; }
        public string VisitorSystemConfigurationUpdatedBy { get; set; }
        public DateTime? VisitorSystemConfigurationUpdatedDatetime { get; set; }
        public string VisitorSystemConfigurationSourceSystemName { get; set; }
        public string VisitorSystemConfigurationSourceSystemColumn { get; set; }
    }
}
