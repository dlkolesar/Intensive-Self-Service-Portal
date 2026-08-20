using System;
using System.Collections.Generic;

namespace Intensive.Data.WSUS
{
    public partial class TbServerSyncResult
    {
        public string LanguageList { get; set; }
        public string CategoryList { get; set; }
        public string UpdateClassificationList { get; set; }
        public string ResultXml { get; set; }
    }
}
