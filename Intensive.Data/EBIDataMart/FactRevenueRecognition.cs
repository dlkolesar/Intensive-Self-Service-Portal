using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class FactRevenueRecognition
    {
        public string RevenueRecognitionSsk { get; set; }
        public int RevenueRecognitionTimeKey { get; set; }
        public int RevenueRecognitionCreateTimeKey { get; set; }
        public int RevenueRecognitionAuthorizedTimeKey { get; set; }
        public int RevenueRecognitionCompletedTimeKey { get; set; }
        public int RevenueRecognitionAccountKey { get; set; }
        public int RevenueRecognitionDeviceKey { get; set; }
        public int RevenueRecognitionTeamKey { get; set; }
        public int RevenueRecognitionBdcContactKey { get; set; }
        public int RevenueRecognitionIncidentKey { get; set; }
        public int RevenueRecognitionIncidentBillingKey { get; set; }
        public int RevenueRecognitionUnitOfMeasureKey { get; set; }
        public int RevenueRecognitionRevenueStatusKey { get; set; }
        public int RevenueRecognitionRevenueDeleteReasonKey { get; set; }
        public int RevenueRecognitionRevenueCategoryKey { get; set; }
        public decimal RevenueRecognitionOneTimePaymentAmount { get; set; }
        public decimal RevenueRecognitionMrrAmount { get; set; }
        public DateTime RevenueRecognitionRecordCreatedDatetime { get; set; }
        public string RevenueRecognitionRecordCreatedBy { get; set; }
        public DateTime RevenueRecognitionRecordUpdatedDatetime { get; set; }
        public string RevenueRecognitionRecordUpdatedBy { get; set; }
        public int RevenueRecognitionTypeKey { get; set; }
    }
}
