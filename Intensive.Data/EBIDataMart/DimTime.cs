using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimTime
    {
        public DimTime()
        {
            FactAccountStatusAccountStatusDateCstKeyNavigation = new HashSet<FactAccountStatus>();
            FactAccountStatusAccountStatusDateUtcKeyNavigation = new HashSet<FactAccountStatus>();
        }

        public int TimeKey { get; set; }
        public DateTime TimeFullDate { get; set; }
        public int TimeDayNumber { get; set; }
        public string TimeDayOfWeek { get; set; }
        public int TimeMonthNumber { get; set; }
        public string TimeMonthDesc { get; set; }
        public string TimeMonthAbbr { get; set; }
        public int TimeYearNumber { get; set; }
        public int TimeQuarterNumber { get; set; }
        public string TimeQuarterDesc { get; set; }
        public int TimeBusinessDayNumber { get; set; }
        public int TimeYearMonthKey { get; set; }
        public byte TimeLastDayMonthFlag { get; set; }
        public DateTime RecAdded { get; set; }
        public DateTime RecUpdated { get; set; }
        public int CurrentRecord { get; set; }
        public int? TimeWeekYearNumber { get; set; }
        public int? TimeWeekMonthNumber { get; set; }
        public int? TimeDayYr { get; set; }
        public int? TimeDayWeek { get; set; }

        public virtual ICollection<FactAccountStatus> FactAccountStatusAccountStatusDateCstKeyNavigation { get; set; }
        public virtual ICollection<FactAccountStatus> FactAccountStatusAccountStatusDateUtcKeyNavigation { get; set; }
    }
}
