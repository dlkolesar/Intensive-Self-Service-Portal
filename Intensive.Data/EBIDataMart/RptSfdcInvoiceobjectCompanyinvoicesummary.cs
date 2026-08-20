using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class RptSfdcInvoiceobjectCompanyinvoicesummary
    {
        public int Id { get; set; }
        public string CompanyId { get; set; }
        public string AccountNumber { get; set; }
        public string BusinessUnit { get; set; }
        public string CompanyStatus { get; set; }
        public string DunsNumber { get; set; }
        public string InvoiceMonth { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public decimal? InvoiceLocalAmount { get; set; }
        public string InvoiceLocalCurrency { get; set; }
        public decimal? MonthOverMonthDeltaAmount { get; set; }
        public DateTime? DataAsOf { get; set; }
        public int? Timemonthkey { get; set; }
    }
}
