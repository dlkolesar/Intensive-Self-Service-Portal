using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.Patching.TicketGenerator
{
    //carried over from the old WinPatch4.1 code
    // why re-invent the wheel?

    public class PatchingMonth
    {
        private int _month, _year;

        public PatchingMonth(int month = 0, int year = 0)
        {
            _month = (month == 0) ? DateTime.Now.Month : month;
            _year = (year == 0) ? DateTime.Now.Year : year;
        }

        public DateTime GetWeekStartDate(int week = 0)
        {
            DateTime workDate = new DateTime(_year, _month, 1);

            for (int i = 1; i <= DateTime.DaysInMonth(_year, _month); i++)
            {
                int occurrence = ((workDate.Day - 1) / 7) + 1;

                if (workDate.DayOfWeek == DayOfWeek.Tuesday && occurrence == 2)
                {
                    // Back up to Monday once the second Tuesday is found
                    workDate = workDate.AddDays(-1);

                    // Add days for week 1-3
                    workDate = workDate.AddDays(7 * week);
                    break;
                }

                workDate = workDate.AddDays(1);
            }

            return workDate;
        }
    }
}
