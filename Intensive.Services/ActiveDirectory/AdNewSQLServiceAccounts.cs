using System;
using System.Collections.Generic;
using System.Text;

namespace Intensive.Services.ActiveDirectory
{
    public class AdNewSQLServiceAccounts
    {
        public string InstanceName { get; set; }
        public bool CreateBackupAccount { get; set; }
        public bool ReportingServices { get; set; }
        public bool AnalysisServices { get; set; }
        public bool IntegrationServices { get; set; }
        public List<string> Errors { get; set; }



        public AdNewSQLServiceAccounts()
        {
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this.InstanceName))
            {
                this.Errors.Add($"Please provide a SQL Instance Name");
                return false;
            }

            return true;
        }
    }
}
