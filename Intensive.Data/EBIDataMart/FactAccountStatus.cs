using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactAccountStatus
    {
        public int AccountKey { get; set; }
        public int StatusKey { get; set; }
        public int TeamKey { get; set; }
        public int AccountStatusDateCstKey { get; set; }
        public int AccountStatusHmsCstKey { get; set; }
        public int AccountStatusDateUtcKey { get; set; }
        public int AccountStatusHmsUtcKey { get; set; }
        public long AccountStatusMilliSecKey { get; set; }
        public long AccountStatusCounter { get; set; }
        public string AccountStatusRecordCreatedBy { get; set; }
        public DateTime? AccountStatusRecordCreatedDatetime { get; set; }
        public string AccountStatusRecordSourceSystemName { get; set; }

        public virtual DimTime AccountStatusDateCstKeyNavigation { get; set; }
        public virtual DimTime AccountStatusDateUtcKeyNavigation { get; set; }
        public virtual DimHourMinSec AccountStatusHmsCstKeyNavigation { get; set; }
        public virtual DimHourMinSec AccountStatusHmsUtcKeyNavigation { get; set; }
        public virtual DimStatus StatusKeyNavigation { get; set; }
        public virtual DimBillingEventsTeam TeamKeyNavigation { get; set; }
    }
}
