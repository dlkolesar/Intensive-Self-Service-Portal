using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimCampaign
    {
        public long CampaignKey { get; set; }
        public string CampaignSourceSystemIdNk { get; set; }
        public string CampaignTrackingCode { get; set; }
        public string CampaignChannel { get; set; }
        public string CampaignPaidSearchTerm { get; set; }
        public string CampaignCreatedBy { get; set; }
        public DateTime? CampaignCreatedDatetime { get; set; }
        public string CampaignUpdatedBy { get; set; }
        public DateTime? CampaignUpdatedDatetime { get; set; }
        public string CampaignSourceSystemIdColumn { get; set; }
        public string CampaignSourceSystemName { get; set; }
    }
}
