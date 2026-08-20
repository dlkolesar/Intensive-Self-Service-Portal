using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimManagedBackupConfig
    {
        public int MbuConfigKey { get; set; }
        public string MbuInclusionLst { get; set; }
        public string MbuExclusionLst { get; set; }
        public short MbuDaysRetainedNbr { get; set; }
        public short MbuRtntnPeriodNbr { get; set; }
        public string MbuRtntnPeriodTxt { get; set; }
        public string MbuRtntnSrcSysTxt { get; set; }
        public string MbuScheduledTm { get; set; }
        public byte MbuSendOffsiteFlg { get; set; }
        public string MbuGroupSrcSysTxt { get; set; }
        public string MbuFullBuDay { get; set; }
        public string MbuNonFullTyp { get; set; }
        public string MbuScheduleSrcSysTxt { get; set; }
        public string MbuConfigSrcSysTxt { get; set; }
        public string MbuBackupServerNm { get; set; }
        public DateTime RecAddedDttm { get; set; }
        public DateTime RecUpdatedDttm { get; set; }
        public string MbuDataAgent { get; set; }
        public string MbuDatabaseInstance { get; set; }
        public string MbuBackupSet { get; set; }
        public string MbuSubClient { get; set; }
        public string MbuFilteredFileName { get; set; }
        public string MbuCopyName { get; set; }
        public int? MbuModifiedDttm { get; set; }
        public string MbuConfigNk { get; set; }
        public DateTime? MbuConfigEffectiveStartDate { get; set; }
        public DateTime? MbuConfigEffectiveEndDate { get; set; }
        public DateTime? MbuConfigRecordCreatedDatetime { get; set; }
        public string MbuConfigRecordCreatedBy { get; set; }
        public DateTime? MbuConfigRecordUpdatedDatetime { get; set; }
        public string MbuConfigRecordUpdatedBy { get; set; }
        public int? CurrentRecord { get; set; }
    }
}
