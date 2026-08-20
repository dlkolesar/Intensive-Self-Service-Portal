using System;
//using System.Collections.Generic;
//using System.Linq;

//using Intensive.Data.SSDatabase;
//using Intensive.Data.WSUS;

//using Intensive.Services.Patching.Exceptions;
//using System.Net;
//using Microsoft.Extensions.Options;
//using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Extensions;
//using System.Data.SqlClient;
//using System.Data.Common;
//using System.Data;

namespace Intensive.Services.Patching
{
    public class PatchStatus: Patch
    {
        public enum PatchingState { Unknown,
                                    NotApplicable,
                                    NotInstalled,
                                    Downloaded,
                                    Installed,
                                    InstallFailed,
                                    InstalledPendingReboot
                                  }
        public int State { get; set; }
        public DateTime ChangeDate { get; set; }
        public int TargetId { get; set; }

        public PatchStatus(): base() { }
        //public PatchStatus(ILogger<PatchingClient> logger,
        //                     SSDatabaseContext dbContext,
        //                     WSUSDBContextFactory wsusFactory,
        //                     IOptions<PatchingSystemConfig> patchConfig
        //                     ) : base(logger, dbContext, wsusFactory, patchConfig)
        //{
            
        //}

        //public void Load(string dc, int clientTargetId, Guid patchid)
        //{
        //    base.Load(dc, patchid);

        //    try
        //    {
        //        TbUpdateStatusPerComputer tbStatus = wsus.TbUpdateStatusPerComputer.Single(
        //                                                 p => p.LocalUpdateId == this.LocalId && p.TargetId == clientTargetId
        //                                             );

        //        this.State = (PatchingState)tbStatus.SummarizationState;
        //        this.ChangeDate = tbStatus.LastChangeTime;
        //        this.TargetId = clientTargetId;
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        throw new PatchingWSUSNotFoundException($"Status information not found for patch", ex);
        //    }
        //}
    }
}
