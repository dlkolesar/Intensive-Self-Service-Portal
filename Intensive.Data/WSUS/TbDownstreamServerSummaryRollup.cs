using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbDownstreamServerSummaryRollup
    {
        public int TargetId { get; set; }
        public int UpdateCount { get; set; }
        public int DeclinedUpdateCount { get; set; }
        public int ApprovedUpdateCount { get; set; }
        public int NotApprovedUpdateCount { get; set; }
        public int UpdatesWithStaleUpdateApprovalsCount { get; set; }
        public int ExpiredUpdateCount { get; set; }
        public int CriticalUpdatesNotApprovedForInstallCount { get; set; }
        public int WsusUpdatesNotApprovedForInstallCount { get; set; }
        public int UpdatesWithClientErrorsCount { get; set; }
        public int UpdatesWithServerErrorsCount { get; set; }
        public int UpdatesNeedingFilesCount { get; set; }
        public int UpdatesNeededByComputersCount { get; set; }
        public int UpdatesUpToDateCount { get; set; }
        public int CustomComputerTargetGroupCount { get; set; }
        public int ComputerTargetCount { get; set; }
        public int ComputerTargetsNeedingUpdatesCount { get; set; }
        public int ComputerTargetsWithUpdateErrorsCount { get; set; }
        public int ComputersUpToDateCount { get; set; }

        public virtual TbTarget Target { get; set; }
    }
}
