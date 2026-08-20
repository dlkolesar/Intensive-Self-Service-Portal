using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimHourMinSec
    {
        public DimHourMinSec()
        {
            FactAccountStatusAccountStatusHmsCstKeyNavigation = new HashSet<FactAccountStatus>();
            FactAccountStatusAccountStatusHmsUtcKeyNavigation = new HashSet<FactAccountStatus>();
        }

        public int HmsKey { get; set; }
        public DateTime? HmsTime { get; set; }
        public int? HmsMilitaryHourNumber { get; set; }
        public int? HmsStandardHourNumber { get; set; }
        public int? HmsMinuteNumber { get; set; }
        public int? HmsSecondNumber { get; set; }
        public string HmsStandard { get; set; }
        public int? HmsShiftNumber { get; set; }

        public virtual ICollection<FactAccountStatus> FactAccountStatusAccountStatusHmsCstKeyNavigation { get; set; }
        public virtual ICollection<FactAccountStatus> FactAccountStatusAccountStatusHmsUtcKeyNavigation { get; set; }
    }
}
