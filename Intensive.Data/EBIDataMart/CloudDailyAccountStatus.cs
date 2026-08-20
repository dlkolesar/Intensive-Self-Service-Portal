using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class CloudDailyAccountStatus
    {
        public string AccountNumber { get; set; }
        public int? GroupId { get; set; }
        public int AccountStatusId { get; set; }
        public DateTime StatusDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
