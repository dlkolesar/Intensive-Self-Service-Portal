using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intensive.Services.ActiveDirectory
{
    public class AdMigrationRequest
    {
        public int Account { get; set; }
        //public int TaskId { get; set; }
        public string TargetOU { get; set; }
        public List<string> Objects { get; set; }   //objects to be migrated;  Will be parsed and grouped; separate ADMT.EXE will be executed for each grouping 
        
        public AdMigrationRequest()
        {
            this.Objects = new List<string>();
        }

    }
}
