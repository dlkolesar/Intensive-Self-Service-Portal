using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactSubscription
    {
        public int SubscriptionKey { get; set; }
        public int TimeKey { get; set; }
        public int TeamKey { get; set; }
        public int AccountKey { get; set; }
        public int DeviceKey { get; set; }
        public int SubscriptionTypeKey { get; set; }
        public int UnitOfMeasureKey { get; set; }
        public int? SubscriptionStatusKey { get; set; }
        public int? BillableStatusKey { get; set; }
        public int? ManagedExchangeDomainKey { get; set; }
        public string ManagedExchangeAccountNumber { get; set; }
        public decimal SubscriptionAmount { get; set; }
        public string SubscriptionSsk { get; set; }
        public DateTime SubscriptionRecordCreatedDateTime { get; set; }
        public DateTime SubscriptionRecordUpdatedDateTime { get; set; }
        public string SubscriptionRecordCreatedBy { get; set; }
        public string SubscriptionRecordUpdatedBy { get; set; }
        public string SubscriptionSourceSystemName { get; set; }
        public byte SubscriptionValidFlag { get; set; }
        public byte? SubscriptionCancelled { get; set; }
    }
}
