using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimPage
    {
        public long PageKey { get; set; }
        public string PageSourceSystemIdNk { get; set; }
        public string Page { get; set; }
        public string PageUrl { get; set; }
        public string PageSiteSections { get; set; }
        public string PageServers { get; set; }
        public string PageSiteType { get; set; }
        public string PageWebsiteDomain { get; set; }
        public string PageCreatedBy { get; set; }
        public DateTime? PageCreatedDatetime { get; set; }
        public string PageUpdatedBy { get; set; }
        public DateTime? PageUpdatedDatetime { get; set; }
        public string PageSourceSystemName { get; set; }
        public string PageSourceSystemIdColumn { get; set; }
    }
}
