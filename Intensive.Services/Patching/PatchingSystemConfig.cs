using System;
using System.Collections.Generic;


namespace Intensive.Services.Patching
{
    public class PatchingSystemConfig
    {

        /*system id into ERIS
         *
         * 	System							ERIS SiteId
	     *   =============================	=============
	     *   AD									11
	     *   Password Manager					27
	     *   WSUS/Windows PAtching				14
	     *   ***REMOVED***							250
	     *   Nimbus								25
	     *   SCOM								24
	     *   AV									22
	     *   linux PAtching						16
         */

        public int SystemId { get; set; }       

        //Error Thresholds
        public int LastContactTimeout {get; set;}   //hours? Days?
        public int LastPatchDateTimeout { get; set; } //months

        
        public Guid[] WSUSGroupID { get; set; }     //GUIDs for WSUS groups assigned to Early, Default, and Delayed Release Weeks
        public int StaleAccountAgeDays { get; set; } //How often to update the account devices list and pull settings

        // put defaults in ARIC Process(es) ??
        public Dictionary<string, int> DefaultScheduleDay { get; set; } //key=DC,value=day number 0-7
        public Dictionary<string, string> DefaultWUServer { get; set; } //key=DC,value=servername

        public Dictionary<string, string> WSUSDBServers { get; set; } //key=DC,value=connection string

        //public PatchingClientBasic ClientDefaultsBasic { get; set; }
        //public PatchingClientAdvanced ClientDefaultsAdvanced { get; set; }
        public PatchingClient DefaultClient { get; set; }

        public int MinimumOSBuild { get; set; }    
        
        public List<int> ExcludeOSBuilds { get; set; }
        public string AricCallbackUrl { get; set; }
        public PatchingSystemConfig() {  }

     
    }
}
