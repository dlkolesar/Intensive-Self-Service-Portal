using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data;
using Intensive.Data.EBIDataMart;

namespace Intensive.Services.Common
{
    public class CommonServices
    {
        //private SSDatabaseContext db;
        private Corporate_DMARTContext core;

        //List<TbServers> ServerList = new List<TbServers>();

        public CommonServices(Corporate_DMARTContext coreDbContext)
        {
            this.core = coreDbContext;
        }

        #region Account
        public Account NewAccount()
        {
            return new Account(this.core);
        }
        public Account NewAccount(int acctNumber)
        {
            return new Account(this.core, acctNumber);
        }

        #endregion

        #region Server
        //public Server NewServer()
        //{
        //    return new Server(this.db);
        //}
        //public Server NewServer(int deviceNumber)
        //{
        //    return new Server(this.db, deviceNumber);
        //}
        #endregion
    }
}
