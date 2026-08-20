using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data.SSDatabase;
using Intensive.Data.EBIDataMart;
using Microsoft.EntityFrameworkCore;


namespace Intensive.Services.Common
{
    public enum CoreAccountServiceLevel {Unknown, Managed, Intensive }
    public class Account
    {
        private Corporate_DMARTContext core;
        private SSDatabaseContext db;

        public int Number { get; set; }
        public string Name { get; set; }
        public CoreAccountServiceLevel ServiceLevel { get; set; }//i.e., Intensive/Managed/etc.....

        public Account(Corporate_DMARTContext coreDbContext,
                        SSDatabaseContext dbContext
                        )
        {
            core = coreDbContext;
            db = dbContext;
            this.Number = 0;
            this.Name = string.Empty;
            this.ServiceLevel = CoreAccountServiceLevel.Unknown;
        }

        //public void Load(int acct)
        //{
        //    DimAccount dimAcct = core.DimAccount.AsNoTracking().SingleOrDefault(a =>
        //                (a.AccountNumber == acct.ToString()) && (a.CurrentRecord == 1) && (a.AccountSourceSystemName == "Salesforce")
        //            );
        //    if (dimAcct != null)
        //    {
        //        this.Number = acct;
        //        this.Name = dimAcct.AccountName;
        //        switch (dimAcct.AccountServiceLevel.ToLower())
        //        {
        //            case "managed":     this.ServiceLevel = CoreAccountServiceLevel.Managed; break;
        //            case "intensive":   this.ServiceLevel = CoreAccountServiceLevel.Intensive; break;
        //            default:            this.ServiceLevel = CoreAccountServiceLevel.Unknown; break;
        //        }
        //    }
        //}//load

        public void Load(int acct)
        {
          
            
        }//load
    }
}
