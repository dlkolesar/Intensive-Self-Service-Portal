using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intensive.Data.SSDatabase;
using Newtonsoft.Json;

namespace Intensive.Services.Patching
{
    public class PatchingService
    {
        const int SYSTEM_ID = 3;

        private SSDatabaseContext db = null;
        public PatchingSystemConfig Config;


        public PatchingService(SSDatabaseContext dbContext)
        {
            db = dbContext;
            LoadConfig();
        }


        public List<int> GetActivePatchingAccounts()
        {
            List<int> accounts = new List<int>();
            List<TbPatchingAccounts> tbAccounts = db.TbPatchingAccounts.Where(a => a.OptedOut == false).ToList();
            foreach (TbPatchingAccounts acct in tbAccounts)
            {
                accounts.Add(acct.Number);
            }
            return accounts;
        }

        //public PatchingClient GetPatchingClient(Guid id)
        //{
        //    tbPatchingClient tbClient = (PatchingClient)db.PatchingClients.FirstOrDefault(c => c.WSUSID == id);
        //    tbPatchingClientConfigBasic basicConfig;
        //    tbPatchingClientConfigAdvanced advConfig;
        //
        //    PatchingClient Client = (PatchingClient)tbClient;
        //    PatchingClientBasic BasicClient;
        //    PatchingClientAdvanced AdvancedClient;
        //
        //    switch (Client.PatchingLevel)
        //    {
        //        case 0: //return patchingClient
        //            return Client;
        //
        //        case 1:
        //        case 3:
        //            basicConfig = db.PatchingClientConfigsBasic.FirstOrDefault(c => c.WSUSID == id);
        //            BasicClient = (PatchingClientBasic)Client;
        //            BasicClient.DetectionFrequency = basicConfig.DetectionFrequency;
        //            BasicClient.DetectionFrequencyEnabled = basicConfig.DetectionFrequencyEnabled;
        //            BasicClient.NoAutoRebotWithLoggedOnusers = basicConfig.NoAutoRebotWithLoggedOnusers;
        //            BasicClient.ScheduledWeek = basicConfig.ScheduledWeek;
        //            BasicClient.ScheduledDay = basicConfig.ScheduledDay;
        //            BasicClient.ScheduledTime = basicConfig.ScheduledTime;
        //            return BasicClient;
        //
        //        case 2:
        //            advConfig = db.PatchingClientConfigsAdvanced.FirstOrDefault(c => c.WSUSID == id);
        //            AdvancedClient = (PatchingClientAdvanced)Client;
        //            AdvancedClient.ARICProcessID = advConfig.ARICProcessID;
        //            //AdvancedClient.ARICProcessName = advConfig.ARICProcessName;
        //            AdvancedClient.ARICProcessArguments = advConfig.ARICProcessArguments;
        //            AdvancedClient.ARICTimeTableID = advConfig.ARICTimeTableID;
        //
        //            return AdvancedClient;
        //
        //        default: return Client;
        //    }
        //}







        private void LoadConfig()
        {
            //TbManagedSystems sys = db.TbManagedSystems.First(s => s.SystemId == SYSTEM_ID);
            //this.Config = JsonConvert.DeserializeObject<PatchingSystemConfig>(sys.Config);
        }


    }
}
