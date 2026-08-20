using System.Collections.Generic;

namespace Intensive.API.Global
{
    public class Constants
    {

        public enum SubSystem
        {
            ActiveDirectory = 11,
            WindowsPatching = 14
        }

        public const string RACKSPACE_AD_API = "https://api.identity.rackspace.corp/v1.0/ad";
        
        //  first 2 digits corresponds to ERIS system id;  refer to SubSystem enum above


        // 100-199 Auditing

        /* 200-299 Common API's, not related to a specific system, or shared by multiple system
         * APIError(ex, 200, $"Unexpected error finding servers for account {number}");
         * APIError(ex, 201, $"Unable to load server {serverNumber}");
         */

        /* 300-399 ARIC
        * APIError(ex, 300, $"Unexpected error has occured while querying ARIC for matching processes");
        * APIError(ex, 301, $"Unable to load ARIC process {name}");
		* APIError(ex, 302, $"Unexpected error has occured while querying ARIC for matching jobs");
		* APIError(ex, 303, $"Unable to load ARIC job {jobid}");
		* APIError(ex, 304, $"Unexpected submitting job to ARIC");
		* APIError(ex, 305, $"Unexpected Error updating job {jobid}");
		* APIError(ex, 306, $"ARIC process failed: {ex.Message}");
       */


        /* 400-499 eDirectory
         * APIError(ex, 400, "Unable to connect to eDirectory");
         * APIError(ex, 401, "Unexpected error has occured while querying eDirectory for Users");
         * APIError(ex, 402, $"Unexpected error has occured while querying eDirectory for userid {userid}");
         * APIError(ex, 403, "Unexpected error has occured while querying eDirectory for Groups");
         * APIError(ex, 404, $"Unexpected error has occured while querying eDirectory for group {name}");
         * APIError(ex, 405, $"Unable to load group membership list for userid {userid}");
         * APIError(ex, 406, $"Unable to load member list for group {name}");
        */

        /* 11000-11999 Active Directory
        *  APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
        *  APIError(ex, 11001, $"Unable to load domain information");
        *  APIError(ex, 11002, $"Unexpected error searching for users that match '{filter}'");
        *  APIError(ex, 11003, $"Unable to load user data for {userid}");
        *  APIError(ex, 11004, $"Unexpected error updating user data for {userid}");
        *  APIError(ex, 11005, $"Unexpected error Generating/Setting new password for '{userid}'");
        *  APIError(ex, 11006, "Unexpected error during Active Directory API authentication and/or authorization");
        */

        /* 14000-14999 Patching(Windows)
        *  APIError(ex, 14000, ");
        *  APIError(ex, 14001, $"Unexpected error loading Opted In Accounts");
        *  APIError(ex, 14002, $"Unable to load account {acctNumber}");
        *  APIError(ex, 14003, $"Unexpected error loading clients for account {acctNumber}");
        *  APIError(ex, 14004, $"");
        *  APIError(ex, 14005, $"Unable to {action} account {acctNumber}");
        *  APIError(ex, 14006, $"Unexpected error when updating account {acctNumber}");
        *  
        *  APIError(ex, 14007, $"Unable load patching client {deviceNumber}");
        *  APIError(ex, 14008, $"Unable to {action} patching client {deviceNumber}");
        *  APIError(ex, 14009, $"Unexpected error when updating patching client {deviceNumber}");
        *  
        *  APIError(ex, 14100, $"Unable to load Ticket Generator configuration");
        *  APIError(ex, 14101, $"Unexpected error saving Ticket Generator configuration");
        *  APIError(ex, 14102, $"Unable to load Ticket Generator progress data");
        *  APIError(ex, 14103, $"Unexpected error when generating preview ticket(s)");
        *  APIError(ex, 14104, $"Unable to load Ticket Generator history");
        */
    }
}


// APIError(ex, 100, $"Unexpected error writing Audit Trail entry");

//APIError err = new APIError(ex, 11000, $"Unable to connect to the {ad.Config.DomainName} Active Directory domain");
//log.LogError(err.ErrorCode, err.FormattedException());
//return new ServerError(err);