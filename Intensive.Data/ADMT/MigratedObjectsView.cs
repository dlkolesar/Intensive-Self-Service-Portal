using System;
using System.Collections.Generic;

namespace Intensive.Data.ADMT
{
    public partial class MigratedObjectsView
    {
        public int TaskId { get; set; }
        public DateTime Time { get; set; }
        public string SourceDomain { get; set; }
        public string SourceDomainDns { get; set; }
        public string SourceDomainFlat { get; set; }
        public string TargetDomain { get; set; }
        public string TargetDomainDns { get; set; }
        public string TargetDomainFlat { get; set; }
        public string SourceAdsPath { get; set; }
        public string TargetAdsPath { get; set; }
        public int Status { get; set; }
        public string SourceSamName { get; set; }
        public string TargetSamName { get; set; }
        public string Type { get; set; }
        public string Guid { get; set; }
        public int SourceRid { get; set; }
        public int TargetRid { get; set; }
        public string SourceDomainSid { get; set; }
    }
}
