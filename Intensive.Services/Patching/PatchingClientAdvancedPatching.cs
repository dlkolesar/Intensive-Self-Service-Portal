using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.Patching
{
    public class PatchingClientAdvancedPatching
    {
        public Guid ID { get; set; }        //ARIC Timetable schedule_id
        public string ProcessName { get; set; }
        public object Arguments { get; set; }   //object containing arguments to pass to ProcessName

        // refer to https://one.rackspace.com/display/RBA/Timetable+Schedule+Types
        public string Minute { get; set; }
        public string Hour { get; set; }
        public string DayOfWeek { get; set; }
        public string DayOfMonth { get; set; }
        public string MonthOfYear { get; set; }

        public PatchingClientAdvancedPatching()
        {
            this.Arguments = new Object();
            this.ID = Guid.Empty;
        }
        public string ToCronTab()
        {
            return $"{Minute} {Hour} {DayOfMonth} {MonthOfYear} {DayOfWeek}";
        }
    }
}
