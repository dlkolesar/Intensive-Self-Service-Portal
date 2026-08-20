using System;
using System.Collections.Generic;

namespace Intensive.Data.EBIDataMart
{
    public partial class DimSkuExtendedAttribute
    {
        public int SkuExtendedAttributeKey { get; set; }
        public int? SkuNumber { get; set; }
        public int? SkuAttributeId { get; set; }
        public string SkuName { get; set; }
        public string SkuLabel { get; set; }
        public string SkuProductDescription { get; set; }
        public string SkuProductRequirements { get; set; }
        public string SkuProductCategory { get; set; }
        public string SkuAttributeToSkuTypeName { get; set; }
        public string SkuAttributeToSkuTypeDescription { get; set; }
        public string SkuAttributeName { get; set; }
        public string SkuPartsAttributeValue { get; set; }
        public string SkuAttributeCategoryName { get; set; }
        public string SkuAttributeTypeName { get; set; }
        public string SkuAttributeTypeDescription { get; set; }
        public string SkuAttributeToSkuVal { get; set; }
        public int? SkuAttributeToSkuMin { get; set; }
        public int? SkuAttributeToSkuMax { get; set; }
        public int? SkuAttributeToSkuAllowBlank { get; set; }
        public int? SkuAttributeToSkuMulti { get; set; }
        public int? SkuSkunitAllowBlank { get; set; }
        public string SkuSkunitLabel { get; set; }
        public string SkuSkunitName { get; set; }
        public int? SkuSkunitActive { get; set; }
        public string SkuSkunitDepartmentRestriction { get; set; }
        public int? SkuSkunitAccountLevel { get; set; }
        public string SkuProductOsName { get; set; }
        public int? SkuProductOsIsRealServer { get; set; }
        public int? SkuProductOsIsVirtual { get; set; }
        public int? SkuProductOsIsNetworked { get; set; }
        public DateTime? SkuExtendedAttributeRecordCreatedDatetime { get; set; }
        public string SkuExtendedAttributeRecordCreatedBy { get; set; }
        public DateTime? SkuExtendedAttributeRecordUpdatedDatetime { get; set; }
        public string SkuExtendedAttributeRecordUpdatedBy { get; set; }
        public DateTime? SkuExtendedAttributeRecordEffectiveStartDatetime { get; set; }
        public DateTime? SkuExtendedAttributeRecordEffectiveEndDatetime { get; set; }
        public string SkuExtendedAttributeSourceSystemName { get; set; }
        public int? SkuExtendedAttributeCurrentRecord { get; set; }
        public string SkuExtendedSsk { get; set; }
    }
}
