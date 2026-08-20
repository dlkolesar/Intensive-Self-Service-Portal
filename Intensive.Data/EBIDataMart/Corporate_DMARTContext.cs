using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Intensive.Data.EBIDataMart
{
    public partial class Corporate_DMARTContext : DbContext
    {
        public virtual DbSet<BridgeAccountCompany> BridgeAccountCompany { get; set; }
        public virtual DbSet<CloudDailyAccountStatus> CloudDailyAccountStatus { get; set; }
        public virtual DbSet<DbaReplicationTest> DbaReplicationTest { get; set; }
        public virtual DbSet<DimAccount> DimAccount { get; set; }
        public virtual DbSet<DimAlertStatus> DimAlertStatus { get; set; }
        public virtual DbSet<DimAlertType> DimAlertType { get; set; }
        public virtual DbSet<DimBillingEventsTeam> DimBillingEventsTeam { get; set; }
        public virtual DbSet<DimBuildErrorSeverityType> DimBuildErrorSeverityType { get; set; }
        public virtual DbSet<DimBuildErrorType> DimBuildErrorType { get; set; }
        public virtual DbSet<DimCampaign> DimCampaign { get; set; }
        public virtual DbSet<DimChatButton> DimChatButton { get; set; }
        public virtual DbSet<DimChatConfiguration> DimChatConfiguration { get; set; }
        public virtual DbSet<DimChatVisitor> DimChatVisitor { get; set; }
        public virtual DbSet<DimChurnProbability> DimChurnProbability { get; set; }
        public virtual DbSet<DimChurnReasonDetail> DimChurnReasonDetail { get; set; }
        public virtual DbSet<DimChurnReasonDetailBridge> DimChurnReasonDetailBridge { get; set; }
        public virtual DbSet<DimCompany> DimCompany { get; set; }
        public virtual DbSet<DimContact> DimContact { get; set; }
        public virtual DbSet<DimContactRole> DimContactRole { get; set; }
        public virtual DbSet<DimCreditEventDesc> DimCreditEventDesc { get; set; }
        public virtual DbSet<DimCreditMemoAttribute> DimCreditMemoAttribute { get; set; }
        public virtual DbSet<DimCreditMemoLogType> DimCreditMemoLogType { get; set; }
        public virtual DbSet<DimCrmLead> DimCrmLead { get; set; }
        public virtual DbSet<DimCrmOpportunity> DimCrmOpportunity { get; set; }
        public virtual DbSet<DimCrmOpportunityStagename> DimCrmOpportunityStagename { get; set; }
        public virtual DbSet<DimCurrency> DimCurrency { get; set; }
        public virtual DbSet<DimDatacenter> DimDatacenter { get; set; }
        public virtual DbSet<DimDepartment> DimDepartment { get; set; }
        public virtual DbSet<DimDevice> DimDevice { get; set; }
        public virtual DbSet<DimDeviceCapEx> DimDeviceCapEx { get; set; }
        public virtual DbSet<DimDeviceTenureGroup> DimDeviceTenureGroup { get; set; }
        public virtual DbSet<DimDlContainer> DimDlContainer { get; set; }
        public virtual DbSet<DimDlContainerComponent> DimDlContainerComponent { get; set; }
        public virtual DbSet<DimDlErwinShelf> DimDlErwinShelf { get; set; }
        public virtual DbSet<DimDlReservation> DimDlReservation { get; set; }
        public virtual DbSet<DimDlSwitch> DimDlSwitch { get; set; }
        public virtual DbSet<DimDlSwitchPort> DimDlSwitchPort { get; set; }
        public virtual DbSet<DimEmployee> DimEmployee { get; set; }
        public virtual DbSet<DimEventDetails> DimEventDetails { get; set; }
        public virtual DbSet<DimGeography> DimGeography { get; set; }
        public virtual DbSet<DimHourMinSec> DimHourMinSec { get; set; }
        public virtual DbSet<DimIncident> DimIncident { get; set; }
        public virtual DbSet<DimIncidentCategory> DimIncidentCategory { get; set; }
        public virtual DbSet<DimIncidentMessageType> DimIncidentMessageType { get; set; }
        public virtual DbSet<DimIncidentSeverity> DimIncidentSeverity { get; set; }
        public virtual DbSet<DimIncidentSource> DimIncidentSource { get; set; }
        public virtual DbSet<DimIncidentStatus> DimIncidentStatus { get; set; }
        public virtual DbSet<DimIncidentStatustype> DimIncidentStatustype { get; set; }
        public virtual DbSet<DimIncidentSubCategory> DimIncidentSubCategory { get; set; }
        public virtual DbSet<DimIncidentWorktype> DimIncidentWorktype { get; set; }
        public virtual DbSet<DimInstance> DimInstance { get; set; }
        public virtual DbSet<DimInstanceConfiguration> DimInstanceConfiguration { get; set; }
        public virtual DbSet<DimIpAddressAutonomousSystems> DimIpAddressAutonomousSystems { get; set; }
        public virtual DbSet<DimIpAddressO2o> DimIpAddressO2o { get; set; }
        public virtual DbSet<DimIpAddressUsages> DimIpAddressUsages { get; set; }
        public virtual DbSet<DimIpBlock> DimIpBlock { get; set; }
        public virtual DbSet<DimLead> DimLead { get; set; }
        public virtual DbSet<DimLeadExtended> DimLeadExtended { get; set; }
        public virtual DbSet<DimLowCostStorageShare> DimLowCostStorageShare { get; set; }
        public virtual DbSet<DimManagedBackupConfig> DimManagedBackupConfig { get; set; }
        public virtual DbSet<DimManagedBackupLevel> DimManagedBackupLevel { get; set; }
        public virtual DbSet<DimManagedBackupServerName> DimManagedBackupServerName { get; set; }
        public virtual DbSet<DimManagedBackupStatus> DimManagedBackupStatus { get; set; }
        public virtual DbSet<DimManagedBackupTarget> DimManagedBackupTarget { get; set; }
        public virtual DbSet<DimManagedExchangeDomain> DimManagedExchangeDomain { get; set; }
        public virtual DbSet<DimMbuExclusions> DimMbuExclusions { get; set; }
        public virtual DbSet<DimMktgStatus> DimMktgStatus { get; set; }
        public virtual DbSet<DimMonitor> DimMonitor { get; set; }
        public virtual DbSet<DimOpportunity> DimOpportunity { get; set; }
        public virtual DbSet<DimPage> DimPage { get; set; }
        public virtual DbSet<DimParameter> DimParameter { get; set; }
        public virtual DbSet<DimPhoneSkill> DimPhoneSkill { get; set; }
        public virtual DbSet<DimPhoneVdn> DimPhoneVdn { get; set; }
        public virtual DbSet<DimProduct> DimProduct { get; set; }
        public virtual DbSet<DimProductSource> DimProductSource { get; set; }
        public virtual DbSet<DimProductUsage> DimProductUsage { get; set; }
        public virtual DbSet<DimQueue> DimQueue { get; set; }
        public virtual DbSet<DimReportCategory> DimReportCategory { get; set; }
        public virtual DbSet<DimResolutionAction> DimResolutionAction { get; set; }
        public virtual DbSet<DimResolutionProduct> DimResolutionProduct { get; set; }
        public virtual DbSet<DimResolutionProductSuite> DimResolutionProductSuite { get; set; }
        public virtual DbSet<DimRevRptBridge> DimRevRptBridge { get; set; }
        public virtual DbSet<DimRevenueCategory> DimRevenueCategory { get; set; }
        public virtual DbSet<DimRevenueCostType> DimRevenueCostType { get; set; }
        public virtual DbSet<DimRevenueDeleteReason> DimRevenueDeleteReason { get; set; }
        public virtual DbSet<DimRevenueSetOfBooks> DimRevenueSetOfBooks { get; set; }
        public virtual DbSet<DimRevenueStatus> DimRevenueStatus { get; set; }
        public virtual DbSet<DimRevenueType> DimRevenueType { get; set; }
        public virtual DbSet<DimSearchTerm> DimSearchTerm { get; set; }
        public virtual DbSet<DimServicePoller> DimServicePoller { get; set; }
        public virtual DbSet<DimSeverity> DimSeverity { get; set; }
        public virtual DbSet<DimSfCurrencyConversion> DimSfCurrencyConversion { get; set; }
        public virtual DbSet<DimSku> DimSku { get; set; }
        public virtual DbSet<DimSkuExtendedAttribute> DimSkuExtendedAttribute { get; set; }
        public virtual DbSet<DimStatus> DimStatus { get; set; }
        public virtual DbSet<DimSubscriptionType> DimSubscriptionType { get; set; }
        public virtual DbSet<DimSurvey> DimSurvey { get; set; }
        public virtual DbSet<DimSurveyAnswer> DimSurveyAnswer { get; set; }
        public virtual DbSet<DimSurveyNpsAnswer> DimSurveyNpsAnswer { get; set; }
        public virtual DbSet<DimSurveyQuestion> DimSurveyQuestion { get; set; }
        public virtual DbSet<DimSurveyResponse> DimSurveyResponse { get; set; }
        public virtual DbSet<DimSurveyType> DimSurveyType { get; set; }
        public virtual DbSet<DimTeam> DimTeam { get; set; }
        public virtual DbSet<DimThreshold> DimThreshold { get; set; }
        public virtual DbSet<DimTicket> DimTicket { get; set; }
        public virtual DbSet<DimTicketCategory> DimTicketCategory { get; set; }
        public virtual DbSet<DimTicketQueue> DimTicketQueue { get; set; }
        public virtual DbSet<DimTicketRatingCategory> DimTicketRatingCategory { get; set; }
        public virtual DbSet<DimTicketState> DimTicketState { get; set; }
        public virtual DbSet<DimTicketStatus> DimTicketStatus { get; set; }
        public virtual DbSet<DimTicketWorkType> DimTicketWorkType { get; set; }
        public virtual DbSet<DimTime> DimTime { get; set; }
        public virtual DbSet<DimTimezone> DimTimezone { get; set; }
        public virtual DbSet<DimUnitOfMeasure> DimUnitOfMeasure { get; set; }
        public virtual DbSet<DimVisitor> DimVisitor { get; set; }
        public virtual DbSet<DimVisitorIp> DimVisitorIp { get; set; }
        public virtual DbSet<DimVisitorSystemConfiguration> DimVisitorSystemConfiguration { get; set; }
        public virtual DbSet<EntityMatch> EntityMatch { get; set; }
        public virtual DbSet<FactAccountContactDetail> FactAccountContactDetail { get; set; }
        public virtual DbSet<FactAccountContactMonthlyCurrentMonth> FactAccountContactMonthlyCurrentMonth { get; set; }
        public virtual DbSet<FactAccountContactMonthlyHistory> FactAccountContactMonthlyHistory { get; set; }
        public virtual DbSet<FactAccountDevice> FactAccountDevice { get; set; }
        public virtual DbSet<FactAccountProductPriceDailySnapshot> FactAccountProductPriceDailySnapshot { get; set; }
        public virtual DbSet<FactAccountStatus> FactAccountStatus { get; set; }
        public virtual DbSet<FactAvThreat> FactAvThreat { get; set; }
        public virtual DbSet<FactBandwidth> FactBandwidth { get; set; }
        public virtual DbSet<FactCreditMemoAppr> FactCreditMemoAppr { get; set; }
        public virtual DbSet<FactCreditMemoLog> FactCreditMemoLog { get; set; }
        public virtual DbSet<FactDeptCreditMemo> FactDeptCreditMemo { get; set; }
        public virtual DbSet<FactDeviceBuildError> FactDeviceBuildError { get; set; }
        public virtual DbSet<FactDeviceLocationDetail> FactDeviceLocationDetail { get; set; }
        public virtual DbSet<FactDeviceLocationMtdCurrentMonth> FactDeviceLocationMtdCurrentMonth { get; set; }
        public virtual DbSet<FactDeviceLocationMtdHistory> FactDeviceLocationMtdHistory { get; set; }
        public virtual DbSet<FactDeviceLocationReservationMtd> FactDeviceLocationReservationMtd { get; set; }
        public virtual DbSet<FactDeviceStatus> FactDeviceStatus { get; set; }
        public virtual DbSet<FactIncidentAccount> FactIncidentAccount { get; set; }
        public virtual DbSet<FactIncidentAssignedTime> FactIncidentAssignedTime { get; set; }
        public virtual DbSet<FactIncidentCreated> FactIncidentCreated { get; set; }
        public virtual DbSet<FactIncidentDevice> FactIncidentDevice { get; set; }
        public virtual DbSet<FactIncidentEotr> FactIncidentEotr { get; set; }
        public virtual DbSet<FactIncidentMessage> FactIncidentMessage { get; set; }
        public virtual DbSet<FactIncidentParentchild> FactIncidentParentchild { get; set; }
        public virtual DbSet<FactIncidentQueuetime> FactIncidentQueuetime { get; set; }
        public virtual DbSet<FactIncidentState> FactIncidentState { get; set; }
        public virtual DbSet<FactIncidentWorked> FactIncidentWorked { get; set; }
        public virtual DbSet<FactIpAssignment> FactIpAssignment { get; set; }
        public virtual DbSet<FactManagedBackupDetail> FactManagedBackupDetail { get; set; }
        public virtual DbSet<FactManagedBackupDetail13Month> FactManagedBackupDetail13Month { get; set; }
        public virtual DbSet<FactMbuAggAccountDeviceMonthly> FactMbuAggAccountDeviceMonthly { get; set; }
        public virtual DbSet<FactMbuAggAccountMonthly> FactMbuAggAccountMonthly { get; set; }
        public virtual DbSet<FactMbuConfigHistory> FactMbuConfigHistory { get; set; }
        public virtual DbSet<FactMonitoringAlert> FactMonitoringAlert { get; set; }
        public virtual DbSet<FactMonitoringAlertRackwatch> FactMonitoringAlertRackwatch { get; set; }
        public virtual DbSet<FactMonitoringAvailabilityMetricsCurrent> FactMonitoringAvailabilityMetricsCurrent { get; set; }
        public virtual DbSet<FactMonitoringDeviceConfig> FactMonitoringDeviceConfig { get; set; }
        public virtual DbSet<FactMonitoringMonitorStatusChange> FactMonitoringMonitorStatusChange { get; set; }
        public virtual DbSet<FactNpsMot> FactNpsMot { get; set; }
        public virtual DbSet<FactNpsScore> FactNpsScore { get; set; }
        public virtual DbSet<FactPhoneAgentUsageDetail> FactPhoneAgentUsageDetail { get; set; }
        public virtual DbSet<FactPhoneSkillUsageDetail> FactPhoneSkillUsageDetail { get; set; }
        public virtual DbSet<FactPhoneVdnUsageDetail> FactPhoneVdnUsageDetail { get; set; }
        public virtual DbSet<FactProductLowcoststorageUsage> FactProductLowcoststorageUsage { get; set; }
        public virtual DbSet<FactProductLowcoststorageUsageDaily> FactProductLowcoststorageUsageDaily { get; set; }
        public virtual DbSet<FactProductLowcoststorageUsageMonthly> FactProductLowcoststorageUsageMonthly { get; set; }
        public virtual DbSet<FactProductUsage> FactProductUsage { get; set; }
        public virtual DbSet<FactRevenue> FactRevenue { get; set; }
        public virtual DbSet<FactRevenueRecognition> FactRevenueRecognition { get; set; }
        public virtual DbSet<FactSkuAssignmentCurrentMonth> FactSkuAssignmentCurrentMonth { get; set; }
        public virtual DbSet<FactSkuAssignmentExtendedAttribute> FactSkuAssignmentExtendedAttribute { get; set; }
        public virtual DbSet<FactSkuAssignmentExtendedAttributeMonthly> FactSkuAssignmentExtendedAttributeMonthly { get; set; }
        public virtual DbSet<FactSkuAssignmentHistory> FactSkuAssignmentHistory { get; set; }
        public virtual DbSet<FactSubscription> FactSubscription { get; set; }
        public virtual DbSet<FactSubscriptionAggMonthly> FactSubscriptionAggMonthly { get; set; }
        public virtual DbSet<FactSurveyQuestionAnswer> FactSurveyQuestionAnswer { get; set; }
        public virtual DbSet<FactTicketsCreated> FactTicketsCreated { get; set; }
        public virtual DbSet<FactTicketsFirstresponse> FactTicketsFirstresponse { get; set; }
        public virtual DbSet<FactTicketsWorked> FactTicketsWorked { get; set; }
        public virtual DbSet<GateDeviceInstance> GateDeviceInstance { get; set; }
        public virtual DbSet<IpBurnRate> IpBurnRate { get; set; }
        public virtual DbSet<ReportAccountDeviceMbuUsageMonthly> ReportAccountDeviceMbuUsageMonthly { get; set; }
        public virtual DbSet<ReportBandwidthOverage> ReportBandwidthOverage { get; set; }
        public virtual DbSet<ReportCommvaultMigration> ReportCommvaultMigration { get; set; }
        public virtual DbSet<ReportExchangeRate> ReportExchangeRate { get; set; }
        public virtual DbSet<ReportImNetwork> ReportImNetwork { get; set; }
        public virtual DbSet<ReportImPower> ReportImPower { get; set; }
        public virtual DbSet<ReportIncidentCreatedDetails> ReportIncidentCreatedDetails { get; set; }
        public virtual DbSet<ReportIncidentMessageData> ReportIncidentMessageData { get; set; }
        public virtual DbSet<ReportMktEmailList> ReportMktEmailList { get; set; }
        public virtual DbSet<ReportMstgHba> ReportMstgHba { get; set; }
        public virtual DbSet<ReportOracleAging> ReportOracleAging { get; set; }
        public virtual DbSet<ReportProvisioningPipeline> ReportProvisioningPipeline { get; set; }
        public virtual DbSet<ReportQueueStats> ReportQueueStats { get; set; }
        public virtual DbSet<ReportSoxManagedVirtDetail> ReportSoxManagedVirtDetail { get; set; }
        public virtual DbSet<ReportSoxManagedVirtSummary> ReportSoxManagedVirtSummary { get; set; }
        public virtual DbSet<RptSfdcInvoiceobjectAccountinvoicesummary> RptSfdcInvoiceobjectAccountinvoicesummary { get; set; }
        public virtual DbSet<RptSfdcInvoiceobjectCompanyinvoicesummary> RptSfdcInvoiceobjectCompanyinvoicesummary { get; set; }
        public virtual DbSet<TempVwNpsMot> TempVwNpsMot { get; set; }

        // Unable to generate entity type for table 'dbo.Fact_Account_Activation'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Site_Visit_Information'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Dim_Time_Month'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_CLoud_Churn_Adjustments'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Bridge_Owner_Hierarchy'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Auto_Users'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Cloud_Account_Contact_Info_Current'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Account_Activation_History'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.fact_site_visit'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.fact_billing_events_detail'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Opportunity_Stage'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Opportunity_Assignment'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.GCN_Account_Matches'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.GCN_Customer_Match'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Opportunity_Partner_Assignment'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Opportunity_Passed'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.GCN_MATCH'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DIM_OPPORTUNITY_BKP_20161130'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DIM_OPPORTUNITY_EXTENDED_BKP_20161130'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DIM_MKTG_STATUS_BKP_20161130'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.FACT_OPPORTUNITY_PASSED_BKP_20161130'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Account_Product_Activation'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Resolution'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Account_Product_Activation_History'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_State'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Site_Visit_EMEA_Information'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Historic_Assignment_05032016'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Core_Confirmed_Churn_Exclusion'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Dim_Opportunity_Extended'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Lead_Status'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Lead_Assignment'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Lead_Partner_Assignment'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Current_Assignment_05032016'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Lead_Passed'. Please see the warning messages.
        // Unable to generate entity type for table 'MyAccounts.Account_BDC'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DIM_LEAD_BKP_20161130'. Please see the warning messages.
        // Unable to generate entity type for table 'MyAccounts.Account_Lead_Tech'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DIM_LEAD_EXTENDED_BKP_20161130'. Please see the warning messages.
        // Unable to generate entity type for table 'MyAccounts.Account_Manager'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DIM_MKTG_STATUS_BKP_20161202'. Please see the warning messages.
        // Unable to generate entity type for table 'MyAccounts.Account_Team_Name'. Please see the warning messages.
        // Unable to generate entity type for table 'MyAccounts.Cross_Platform_Lead_Tech'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DATAMART_CUTOVERTGT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DATAMART_CUTOVERSRC'. Please see the warning messages.
        // Unable to generate entity type for table 'HR.tbl_HR_BI_Feed'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Dim_Device_CapEx_old'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Hypervisor_Status'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Opportunity_State'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Booking_History'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Booking_Live'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Opportunity_Closed_History'. Please see the warning messages.
        // Unable to generate entity type for table 'janus.daily_usage_true_delta'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Opportunity_Closed_Live'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Opportunity_Created_History'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Current_Assignment'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Opportunity_Created_Live'. Please see the warning messages.
        // Unable to generate entity type for table 'janus.daily_usage'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Historic_Assignment'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Opportunity_Pipeline'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Quota_History'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.FIN_Customer_DeviceSKU'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.LanceRules'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Cloud_Usage_Options_Reference'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Chat_Information'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Device_Topology'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CUSTOMER_EXPENSES_BY_GROUP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Account_Company'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RPT_TBL_INVOICE_OBJECT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Etl_Dst_Date_Info'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Site_Visit_Information_old'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Churn'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cloud_total'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Comment'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Current_Queuetime'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Relationship'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Historic_Queuetime'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Tickets_Account_Instance'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.FixedAssets'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Fact_Account_Signup'. Please see the warning messages.
        // Unable to generate entity type for table 'janus.Daily_Delta'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Data Source=10.10.97.94;Initial Catalog=Corporate_DMART;Integrated Security=False;User ID=SS_Read;Password=RvkifoNw1xzp;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public Corporate_DMARTContext(DbContextOptions<Corporate_DMARTContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BridgeAccountCompany>(entity =>
            {
                entity.HasKey(e => e.BridgeAccountCompanyKey)
                    .HasName("PK_BRIDGE_ACCOUNT_COMPANY_KEY");

                entity.ToTable("Bridge_Account_Company");

                entity.HasIndex(e => e.CurrentRecord)
                    .HasName("IDX_CURRENT_RECORD");

                entity.HasIndex(e => new { e.EffectiveStartDate, e.EffectiveEndDate, e.CurrentRecord })
                    .HasName("IDX_CURRENT_RECORD_ESD_EED");

                entity.Property(e => e.BridgeAccountCompanyKey)
                    .HasColumnName("Bridge_Account_Company_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.BridgeSsk)
                    .IsRequired()
                    .HasColumnName("Bridge_SSK")
                    .HasColumnType("varchar(225)");

                entity.Property(e => e.CompanyKey).HasColumnName("Company_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.DwTimestamp)
                    .HasColumnName("dw_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnName("Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");
            });

            modelBuilder.Entity<CloudDailyAccountStatus>(entity =>
            {
                entity.HasKey(e => new { e.AccountNumber, e.AccountStatusId, e.StatusDate })
                    .HasName("PK_ACCTNUMBERSTSIDSTSDT");

                entity.ToTable("CLOUD_DAILY_ACCOUNT_STATUS");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("ACCOUNT_NUMBER")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountStatusId).HasColumnName("ACCOUNT_STATUS_ID");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("STATUS_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroupId).HasColumnName("GROUP_ID");

                entity.Property(e => e.LastUpdateDate)
                    .HasColumnName("LAST_UPDATE_DATE")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DbaReplicationTest>(entity =>
            {
                entity.ToTable("dba_replication_test");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<DimAccount>(entity =>
            {
                entity.HasKey(e => e.AccountKey)
                    .HasName("PK_Dim_Account");

                entity.ToTable("Dim_Account");

                entity.HasIndex(e => e.AccountBdc)
                    .HasName("IX_Account_BDC");

                entity.HasIndex(e => e.AccountBdcContactId)
                    .HasName("IX_Account_BDC_Contact_ID");

                entity.HasIndex(e => e.AccountGeographicLocation)
                    .HasName("IX_Account_Geographic_Location");

                entity.HasIndex(e => e.AccountICompanyId)
                    .HasName("IX_Account_iCompanyID");

                entity.HasIndex(e => e.AccountManager)
                    .HasName("IX_Account_Manager");

                entity.HasIndex(e => e.AccountManagerContactId)
                    .HasName("IX_Account_AM_Contact_ID");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("IDX_Account_Number");

                entity.HasIndex(e => e.AccountRecordUpdatedDatetime)
                    .HasName("IX_Account_Record_Updated_DT");

                entity.HasIndex(e => e.AccountRegion)
                    .HasName("IX_Account_Region");

                entity.HasIndex(e => e.AccountSourceSystemName)
                    .HasName("IDX_acct_Source");

                entity.HasIndex(e => e.AccountStatus)
                    .HasName("IX_Account_Status");

                entity.HasIndex(e => new { e.AccountId, e.CurrentRecord })
                    .HasName("IX_Account_ID");

                entity.HasIndex(e => new { e.CurrentRecord, e.AccountNumber })
                    .HasName("IX_Account_Current_Record");

                entity.HasIndex(e => new { e.AccountId, e.AccountEffectiveStartDatetime, e.AccountEffectiveEndDatetime })
                    .HasName("IDX_Account_ID_Effective_Start_End_Date");

                entity.HasIndex(e => new { e.AccountManagerContactId, e.CurrentRecord, e.AccountNumber })
                    .HasName("IX_Account_Manager_Contact_ID");

                entity.HasIndex(e => new { e.AccountName, e.AccountNumber, e.CurrentRecord })
                    .HasName("IX_Account_Name");

                entity.HasIndex(e => new { e.AccountTeamName, e.AccountBdc, e.AccountManager })
                    .HasName("IX_Account_Team_Name");

                entity.HasIndex(e => new { e.CurrentRecord, e.AccountNk, e.AccountSourceSystemName })
                    .HasName("IDX_Account_NK");

                entity.HasIndex(e => new { e.AccountNumber, e.AccountType, e.CurrentRecord, e.AccountSourceSystemName })
                    .HasName("IDX_Acct_Type");

                entity.HasIndex(e => new { e.AccountName, e.AccountNumber, e.CurrentRecord, e.AccountLeadTech, e.AccountStatus })
                    .HasName("IX__Current_Record__Account_Lead_Tech__Account_Status");

                entity.HasIndex(e => new { e.AccountNumber, e.CurrentRecord, e.AccountSourceSystemName, e.AccountStatus, e.AccountTeamName })
                    .HasName("IX_C_ACC_ACCS_ATN");

                entity.HasIndex(e => new { e.AccountKey, e.AccountName, e.AccountNumber, e.AccountBillingCountry, e.AccountPhone, e.AccountStatus, e.CurrentRecord, e.AccountParentId, e.AccountSourceSystemName })
                    .HasName("IX__Account_Status__Current_Record__Account_Parent_ID__Account_Source_System_Name");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.AccountAllDeviceCount).HasColumnName("Account_All_Device_Count");

                entity.Property(e => e.AccountAnnualRevenue)
                    .HasColumnName("Account_Annual_Revenue")
                    .HasColumnType("decimal");

                entity.Property(e => e.AccountBackupDeviceCount).HasColumnName("Account_Backup_Device_Count");

                entity.Property(e => e.AccountBdc)
                    .HasColumnName("Account_BDC")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountBdcContactId).HasColumnName("Account_BDC_Contact_ID");

                entity.Property(e => e.AccountBillingCity)
                    .HasColumnName("Account_Billing_City")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountBillingCountry)
                    .HasColumnName("Account_Billing_Country")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountBillingPostalCode)
                    .HasColumnName("Account_Billing_Postal_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountBillingState)
                    .HasColumnName("Account_Billing_State")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountBillingStreet)
                    .HasColumnName("Account_Billing_Street")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountBizsparkFlag).HasColumnName("Account_Bizspark_Flag");

                entity.Property(e => e.AccountBusinessType)
                    .HasColumnName("Account_Business_Type")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountBusinessTypeDesc)
                    .HasColumnName("Account_Business_Type_Desc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountBusinessTypeId).HasColumnName("Account_Business_Type_ID");

                entity.Property(e => e.AccountCaption)
                    .HasColumnName("Account_Caption")
                    .HasMaxLength(150);

                entity.Property(e => e.AccountClassification).HasColumnType("varchar(20)");

                entity.Property(e => e.AccountCompedFlag).HasColumnName("Account_Comped_Flag");

                entity.Property(e => e.AccountCreatedDate)
                    .HasColumnName("Account_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountCurrencyIsoCode)
                    .HasColumnName("Account_Currency_ISO_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountCustomerType)
                    .HasColumnName("Account_Customer_Type")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountDescription)
                    .HasColumnName("Account_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountDesiredBillingDay).HasColumnName("Account_Desired_Billing_Day");

                entity.Property(e => e.AccountDoNotCall)
                    .HasColumnName("Account_Do_Not_Call")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.AccountDoNotEmail)
                    .HasColumnName("Account_Do_Not_Email")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.AccountDoNotMail)
                    .HasColumnName("Account_Do_Not_Mail")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.AccountEffectiveEndDatetime)
                    .HasColumnName("Account_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountEffectiveStartDatetime)
                    .HasColumnName("Account_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountEmerInstrExists).HasColumnName("Account_Emer_Instr_Exists");

                entity.Property(e => e.AccountExecutiveSponsor)
                    .HasColumnName("Account_Executive_Sponsor")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountFax)
                    .HasColumnName("Account_FAX")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountFirstServerOnline)
                    .HasColumnName("Account_First_Server_Online")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountGeographicLocation)
                    .HasColumnName("Account_Geographic_Location")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountHasUnmeteredBackup).HasColumnName("Account_Has_Unmetered_Backup");

                entity.Property(e => e.AccountHighProfileFlag).HasColumnName("Account_High_Profile_Flag");

                entity.Property(e => e.AccountICompanyId)
                    .HasColumnName("Account_iCompanyID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.AccountIsParent).HasColumnName("Account_Is_Parent");

                entity.Property(e => e.AccountIsPartner)
                    .HasColumnName("Account_IsPartner")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.AccountLastBilledDate)
                    .HasColumnName("Account_Last_Billed_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountLeadTech)
                    .HasColumnName("Account_Lead_Tech")
                    .HasColumnType("varchar(65)");

                entity.Property(e => e.AccountManager)
                    .HasColumnName("Account_Manager")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountManagerContactId)
                    .HasColumnName("Account_Manager_Contact_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountNk)
                    .HasColumnName("Account_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("Account_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountNumberOfEmployees).HasColumnName("Account_Number_of_Employees");

                entity.Property(e => e.AccountOtherNetworkDeviceCount).HasColumnName("Account_Other_Network_Device_Count");

                entity.Property(e => e.AccountOwnerId)
                    .HasColumnName("Account_Owner_ID")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.AccountOwnership)
                    .HasColumnName("Account_Ownership")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountParentId).HasColumnName("Account_Parent_ID");

                entity.Property(e => e.AccountPhone)
                    .HasColumnName("Account_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountPrimaryContact)
                    .HasColumnName("Account_Primary_Contact")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountPrimaryContactId)
                    .HasColumnName("Account_Primary_Contact_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountPromotionCode)
                    .HasColumnName("Account_Promotion_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountRating)
                    .HasColumnName("Account_Rating")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountRecordCreatedBy)
                    .HasColumnName("Account_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountRecordCreatedDatetime)
                    .HasColumnName("Account_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountRecordUpdatedBy)
                    .HasColumnName("Account_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountRecordUpdatedDatetime)
                    .HasColumnName("Account_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountRegion)
                    .HasColumnName("Account_Region")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountServerCount).HasColumnName("Account_Server_Count");

                entity.Property(e => e.AccountServiceLevel)
                    .HasColumnName("Account_Service_Level")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountServiceLevelDatetime)
                    .HasColumnName("account_service_level_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountServiceLevelName)
                    .HasColumnName("account_service_level_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountServiceType)
                    .HasColumnName("account_service_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountShippingCity)
                    .HasColumnName("Account_Shipping_City")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountShippingCountry)
                    .HasColumnName("Account_Shipping_Country")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountShippingPostalCode)
                    .HasColumnName("Account_Shipping_Postal_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountShippingState)
                    .HasColumnName("Account_Shipping_State")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountShippingStreet)
                    .HasColumnName("Account_Shipping_Street")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountSic)
                    .HasColumnName("Account_SIC")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.AccountSite)
                    .HasColumnName("Account_Site")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.AccountSlaType)
                    .HasColumnName("Account_SLA_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountSlaTypeDesc)
                    .HasColumnName("Account_SLA_Type_Desc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountSourceSystemName)
                    .HasColumnName("Account_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountStatus)
                    .HasColumnName("Account_Status")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountStatusDesc)
                    .HasColumnName("Account_Status_Desc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountStatusId).HasColumnName("Account_Status_ID");

                entity.Property(e => e.AccountStorageDeviceCount).HasColumnName("Account_Storage_Device_Count");

                entity.Property(e => e.AccountSubType)
                    .HasColumnName("Account_Sub_Type")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountSubscriptionAmount)
                    .HasColumnName("Account_Subscription_Amount")
                    .HasColumnType("decimal");

                entity.Property(e => e.AccountTeamName)
                    .HasColumnName("Account_Team_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountTenureDays).HasColumnName("Account_Tenure_Days");

                entity.Property(e => e.AccountTickerSymbol)
                    .HasColumnName("Account_Ticker_Symbol")
                    .HasMaxLength(60);

                entity.Property(e => e.AccountType)
                    .HasColumnName("Account_Type")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountTypeDesc)
                    .HasColumnName("Account_Type_Desc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountTypeLevel2)
                    .HasColumnName("Account_Type_Level2")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.AccountUnknownDeviceCount).HasColumnName("Account_Unknown_Device_Count");

                entity.Property(e => e.AccountWebsite)
                    .HasColumnName("Account_Website")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.CrossPlatformLeadTech)
                    .HasColumnName("Cross_Platform_Lead_Tech")
                    .HasColumnType("varchar(65)");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.CustomerNumber)
                    .HasColumnName("Customer_Number")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("Rec_Updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimAlertStatus>(entity =>
            {
                entity.HasKey(e => e.AlertStatusKey)
                    .HasName("PK_Dim_Alert_Status");

                entity.ToTable("Dim_Alert_Status");

                entity.HasIndex(e => e.AlertStatusCurrentRecordFlag)
                    .HasName("IDX03_Dim_Alert_Status_Current_Flag");

                entity.HasIndex(e => e.AlertStatusType)
                    .HasName("IDX04_Dim_Alert_Status_Type");

                entity.HasIndex(e => new { e.AlertStatusEffectiveStartDatetime, e.AlertStatusEffectiveEndDatetime })
                    .HasName("IDX02_Dim_Alert_Status");

                entity.HasIndex(e => new { e.AlertStatusIdNk, e.AlertStatusSourceSystemName })
                    .HasName("IDX01_Dim_Alert_Status");

                entity.Property(e => e.AlertStatusKey).HasColumnName("Alert_Status_Key");

                entity.Property(e => e.AlertStatusCurrentRecordFlag).HasColumnName("Alert_Status_Current_Record_Flag");

                entity.Property(e => e.AlertStatusDescription)
                    .IsRequired()
                    .HasColumnName("Alert_Status_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AlertStatusEffectiveEndDatetime)
                    .HasColumnName("Alert_Status_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertStatusEffectiveStartDatetime)
                    .HasColumnName("Alert_Status_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertStatusIdNk)
                    .HasColumnName("Alert_Status_ID_NK")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.AlertStatusRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Alert_Status_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AlertStatusRecordCreatedDatetime)
                    .HasColumnName("Alert_Status_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertStatusRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Alert_Status_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AlertStatusRecordUpdatedDatetime)
                    .HasColumnName("Alert_Status_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertStatusSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Alert_Status_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AlertStatusText)
                    .IsRequired()
                    .HasColumnName("Alert_Status_Text")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AlertStatusType)
                    .IsRequired()
                    .HasColumnName("Alert_Status_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimAlertType>(entity =>
            {
                entity.HasKey(e => e.AlertTypeKey)
                    .HasName("PK_Dim_Alert_Type");

                entity.ToTable("Dim_Alert_Type");

                entity.HasIndex(e => e.AlertTypeCurrentRecordFlag)
                    .HasName("IDX03_Dim_Alert_Type_Current_Flag");

                entity.HasIndex(e => e.AlertTypeName)
                    .HasName("IDX01_Dim_Alert_Type_Name");

                entity.HasIndex(e => new { e.AlertTypeEffectiveStartDatetime, e.AlertTypeEffectiveEndDatetime })
                    .HasName("IDX02_Dim_Alert_Type");

                entity.HasIndex(e => new { e.AlertTypeIdNk, e.AlertTypeSourceSystemName })
                    .HasName("IDX01_Dim_Alert_Type");

                entity.Property(e => e.AlertTypeKey).HasColumnName("Alert_Type_KEY");

                entity.Property(e => e.AlertTypeCurrentRecordFlag).HasColumnName("Alert_Type_Current_Record_Flag");

                entity.Property(e => e.AlertTypeDescription)
                    .IsRequired()
                    .HasColumnName("Alert_Type_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.AlertTypeEffectiveEndDatetime)
                    .HasColumnName("Alert_Type_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertTypeEffectiveStartDatetime)
                    .HasColumnName("Alert_Type_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertTypeIdNk)
                    .HasColumnName("Alert_Type_ID_NK")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.AlertTypeMonitoringSystemName)
                    .IsRequired()
                    .HasColumnName("Alert_Type_Monitoring_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AlertTypeName)
                    .IsRequired()
                    .HasColumnName("Alert_Type_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AlertTypeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Alert_Type_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AlertTypeRecordCreatedDatetime)
                    .HasColumnName("Alert_Type_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertTypeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Alert_Type_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AlertTypeRecordUpdatedDatetime)
                    .HasColumnName("Alert_Type_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlertTypeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Alert_Type_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimBillingEventsTeam>(entity =>
            {
                entity.HasKey(e => e.TeamKey)
                    .HasName("PK_dim_billing_events_team");

                entity.ToTable("dim_billing_events_team");

                entity.Property(e => e.TeamKey)
                    .HasColumnName("team_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.CurrentRecord).HasColumnName("current_record");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("rec_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("rec_updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("source_system_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamActive).HasColumnName("team_active");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("team_business_segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSegmentReportId).HasColumnName("team_business_segment_report_id");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("team_business_sub_segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSubSegmentReportId).HasColumnName("team_business_sub_segment_report_id");

                entity.Property(e => e.TeamBusinessUnit)
                    .HasColumnName("team_business_unit")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamCompany)
                    .HasColumnName("team_company")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamCountry)
                    .HasColumnName("team_country")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamCreationDate)
                    .HasColumnName("team_creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamDataSource)
                    .HasColumnName("team_data_source")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamDescription)
                    .HasColumnName("team_description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TeamDivision)
                    .HasColumnName("team_division")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamEffectiveEndDatetime)
                    .HasColumnName("team_effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamEffectiveStartDatetime)
                    .HasColumnName("team_effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.TeamModificationDate)
                    .HasColumnName("team_modification_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamName)
                    .HasColumnName("team_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TeamParentNk)
                    .HasColumnName("team_parent_nk")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamRecordCreatedAt)
                    .HasColumnName("team_record_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamRecordCreatedBy)
                    .HasColumnName("team_record_created_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamRecordSourceId)
                    .HasColumnName("team_record_source_id")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamRecordUpdatedAt)
                    .HasColumnName("team_record_updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamRecordUpdatedBy)
                    .HasColumnName("team_record_updated_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamRegion)
                    .HasColumnName("team_region")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamReportHeader)
                    .HasColumnName("team_report_header")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TeamReportHeaderId).HasColumnName("team_report_header_id");

                entity.Property(e => e.TeamRoleId).HasColumnName("team_role_id");

                entity.Property(e => e.TeamSsk)
                    .HasColumnName("Team_ssk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TeamSubregion)
                    .HasColumnName("team_subregion")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamSuperRegion)
                    .HasColumnName("team_super_region")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimBuildErrorSeverityType>(entity =>
            {
                entity.HasKey(e => e.BuildErrorSeverityTypeKey)
                    .HasName("PK_Dim_Build_Error_Severity_Type");

                entity.ToTable("Dim_Build_Error_Severity_Type");

                entity.HasIndex(e => e.BuildErrorSeverityTypeIdNk)
                    .HasName("ix_build_error_severity_type_id_nk");

                entity.Property(e => e.BuildErrorSeverityTypeKey).HasColumnName("Build_Error_Severity_Type_Key");

                entity.Property(e => e.BuildErrorSeverityTypeCreatedBy)
                    .IsRequired()
                    .HasColumnName("Build_Error_Severity_Type_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.BuildErrorSeverityTypeCreatedDatetime)
                    .HasColumnName("Build_Error_Severity_Type_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BuildErrorSeverityTypeCurrentRecord).HasColumnName("Build_Error_Severity_Type_Current_Record");

                entity.Property(e => e.BuildErrorSeverityTypeDescription)
                    .IsRequired()
                    .HasColumnName("Build_Error_Severity_Type_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildErrorSeverityTypeEffectiveEndDatetime)
                    .HasColumnName("Build_Error_Severity_Type_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BuildErrorSeverityTypeEffectiveStartDatetime)
                    .HasColumnName("Build_Error_Severity_Type_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BuildErrorSeverityTypeIdNk)
                    .IsRequired()
                    .HasColumnName("Build_Error_Severity_Type_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BuildErrorSeverityTypeName)
                    .IsRequired()
                    .HasColumnName("Build_Error_Severity_Type_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildErrorSeverityTypeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Build_Error_Severity_Type_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BuildErrorSeverityTypeType)
                    .IsRequired()
                    .HasColumnName("Build_Error_Severity_Type_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BuildErrorSeverityTypeUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Build_Error_Severity_Type_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.BuildErrorSeverityTypeUpdatedDatetime)
                    .HasColumnName("Build_Error_Severity_Type_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimBuildErrorType>(entity =>
            {
                entity.HasKey(e => e.BuildErrorTypeKey)
                    .HasName("PK_Dim_Build_Error_Type");

                entity.ToTable("Dim_Build_Error_Type");

                entity.HasIndex(e => e.BuildErrorTypeIdNk)
                    .HasName("ix_build_error_type_id_nk");

                entity.Property(e => e.BuildErrorTypeKey).HasColumnName("Build_Error_Type_Key");

                entity.Property(e => e.BuildErrorTypeCreatedBy)
                    .IsRequired()
                    .HasColumnName("Build_Error_Type_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.BuildErrorTypeCreatedDatetime)
                    .HasColumnName("Build_Error_Type_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BuildErrorTypeCurrentRecord).HasColumnName("Build_Error_Type_Current_Record");

                entity.Property(e => e.BuildErrorTypeDescription)
                    .IsRequired()
                    .HasColumnName("Build_Error_Type_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildErrorTypeEffectiveEndDatetime)
                    .HasColumnName("Build_Error_Type_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BuildErrorTypeEffectiveStartDatetime)
                    .HasColumnName("Build_Error_Type_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BuildErrorTypeIdNk)
                    .IsRequired()
                    .HasColumnName("Build_Error_Type_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BuildErrorTypeName)
                    .IsRequired()
                    .HasColumnName("Build_Error_Type_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildErrorTypeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Build_Error_Type_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BuildErrorTypeType)
                    .IsRequired()
                    .HasColumnName("Build_Error_Type_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.BuildErrorTypeUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Build_Error_Type_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.BuildErrorTypeUpdatedDatetime)
                    .HasColumnName("Build_Error_Type_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimCampaign>(entity =>
            {
                entity.HasKey(e => e.CampaignKey)
                    .HasName("PK__dim_camp__9A1392D51BEAB2AD");

                entity.ToTable("dim_campaign");

                entity.Property(e => e.CampaignKey)
                    .HasColumnName("campaign_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignChannel)
                    .IsRequired()
                    .HasColumnName("campaign_channel")
                    .HasMaxLength(255);

                entity.Property(e => e.CampaignCreatedBy)
                    .HasColumnName("campaign_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.CampaignCreatedDatetime)
                    .HasColumnName("campaign_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CampaignPaidSearchTerm)
                    .IsRequired()
                    .HasColumnName("campaign_paid_search_term")
                    .HasMaxLength(255);

                entity.Property(e => e.CampaignSourceSystemIdColumn)
                    .IsRequired()
                    .HasColumnName("campaign_source_system_id_column")
                    .HasMaxLength(200);

                entity.Property(e => e.CampaignSourceSystemIdNk)
                    .HasColumnName("campaign_source_system_id_nk")
                    .HasMaxLength(255);

                entity.Property(e => e.CampaignSourceSystemName)
                    .IsRequired()
                    .HasColumnName("campaign_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.CampaignTrackingCode)
                    .IsRequired()
                    .HasColumnName("campaign_tracking_code")
                    .HasMaxLength(255);

                entity.Property(e => e.CampaignUpdatedBy)
                    .HasColumnName("campaign_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.CampaignUpdatedDatetime)
                    .HasColumnName("campaign_updated_datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimChatButton>(entity =>
            {
                entity.HasKey(e => e.ChatButtonKey)
                    .HasName("PK__Dim_Chat__5DA8CD749156012D");

                entity.ToTable("Dim_Chat_Button");

                entity.HasIndex(e => e.ChatButtonEffectiveStartDateTimeCst)
                    .HasName("INDX_ChatButton_Effective_Start_DateTime_CST");

                entity.HasIndex(e => e.ChatButtonId)
                    .HasName("INDX_ChatButton_Id");

                entity.Property(e => e.ChatButtonKey)
                    .HasColumnName("ChatButton_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChatButtonCreatedBy)
                    .HasColumnName("ChatButton_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatButtonCreatedDatetime).HasColumnName("ChatButton_Created_Datetime");

                entity.Property(e => e.ChatButtonCurrentRecord).HasColumnName("ChatButton_Current_Record");

                entity.Property(e => e.ChatButtonDeleteFlag)
                    .HasColumnName("ChatButton_DeleteFlag")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.ChatButtonEffectiveEndDateTimeCst).HasColumnName("ChatButton_Effective_End_DateTime_cst");

                entity.Property(e => e.ChatButtonEffectiveEndDateTimeUtc).HasColumnName("ChatButton_Effective_End_DateTime_Utc");

                entity.Property(e => e.ChatButtonEffectiveStartDateTimeCst).HasColumnName("ChatButton_Effective_Start_DateTime_cst");

                entity.Property(e => e.ChatButtonEffectiveStartDateTimeUtc).HasColumnName("ChatButton_Effective_Start_DateTime_Utc");

                entity.Property(e => e.ChatButtonId)
                    .HasColumnName("ChatButton_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.ChatButtonIsActive)
                    .HasColumnName("ChatButton_IsActive")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.ChatButtonRoutingType)
                    .HasColumnName("ChatButton_RoutingType")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ChatButtonSiteId)
                    .HasColumnName("ChatButton_Site_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.ChatButtonSkillId)
                    .HasColumnName("ChatButton_Skill_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.ChatButtonSourceSystemName)
                    .HasColumnName("ChatButton_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatButtonType)
                    .HasColumnName("ChatButton_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatButtonUpdatedBy)
                    .HasColumnName("ChatButton_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatButtonUpdatedDatetime).HasColumnName("ChatButton_Updated_Datetime");

                entity.Property(e => e.ChatPageId)
                    .HasColumnName("Chat_Page_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CreatedDateCst).HasColumnName("CreatedDate_Cst");

                entity.Property(e => e.CreatedDateLocal).HasColumnName("CreatedDate_Local");

                entity.Property(e => e.CreatedDateUtc).HasColumnName("CreatedDate_Utc");

                entity.Property(e => e.MasterLabel)
                    .HasColumnName("Master_Label")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimChatConfiguration>(entity =>
            {
                entity.HasKey(e => e.ChatConfigurationNk)
                    .HasName("PK__Dim_Chat__951304346CE96D10");

                entity.ToTable("Dim_Chat_Configuration");

                entity.HasIndex(e => e.ChatConfigurationRecordCreatedDatetime)
                    .HasName("Idx_ChatConfiguration_Record_Created_Datetime");

                entity.Property(e => e.ChatConfigurationNk)
                    .HasColumnName("ChatConfiguration_Nk")
                    .HasColumnType("varchar(450)");

                entity.Property(e => e.ChatConfigurationKey).HasColumnName("ChatConfiguration_Key");

                entity.Property(e => e.ChatConfigurationNkColumns)
                    .IsRequired()
                    .HasColumnName("ChatConfiguration_Nk_Columns")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ChatConfigurationRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("ChatConfiguration_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ChatConfigurationRecordCreatedDatetime).HasColumnName("ChatConfiguration_Record_Created_Datetime");

                entity.Property(e => e.ChatConfigurationRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("ChatConfiguration_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ChatConfigurationRecordUpdatedDatetime).HasColumnName("ChatConfiguration_Record_Updated_Datetime");

                entity.Property(e => e.ChatUserAgent)
                    .IsRequired()
                    .HasColumnName("ChatUser_Agent")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.ChatUserBrowser)
                    .IsRequired()
                    .HasColumnName("ChatUser_Browser")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.ChatUserBrowserLanguage)
                    .IsRequired()
                    .HasColumnName("ChatUser_BrowserLanguage")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatUserLanguage)
                    .IsRequired()
                    .HasColumnName("ChatUser_Language")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatUserLocation)
                    .IsRequired()
                    .HasColumnName("ChatUser_Location")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ChatUserPlatform)
                    .IsRequired()
                    .HasColumnName("ChatUser_Platform")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatUserPortal)
                    .IsRequired()
                    .HasColumnName("ChatUser_Portal")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatUserScreenResolution)
                    .IsRequired()
                    .HasColumnName("ChatUser_ScreenResolution")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChatUserTerritory)
                    .IsRequired()
                    .HasColumnName("ChatUser_Territory")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StatusSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Status_Source_System_Name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimChatVisitor>(entity =>
            {
                entity.HasKey(e => new { e.VisitorKey, e.VisitorNk })
                    .HasName("PK__Dim_Chat__57CF6A5A1F45313C");

                entity.ToTable("Dim_Chat_Visitor");

                entity.HasIndex(e => e.VisitorId)
                    .HasName("Idx_Dmart_Chat_Visitor_Id");

                entity.Property(e => e.VisitorKey).HasColumnName("Visitor_Key");

                entity.Property(e => e.VisitorNk)
                    .HasColumnName("Visitor_Nk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VisitorEmail)
                    .HasColumnName("Visitor_Email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VisitorId)
                    .IsRequired()
                    .HasColumnName("Visitor_ID")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VisitorName)
                    .HasColumnName("Visitor_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VisitorRackUid)
                    .HasColumnName("Visitor_RackUID")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.VisitorRecordCreatedBy)
                    .HasColumnName("Visitor_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.VisitorRecordCreatedDatetime).HasColumnName("Visitor_Record_Created_Datetime");

                entity.Property(e => e.VisitorRecordUpdatedBy)
                    .HasColumnName("Visitor_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.VisitorRecordUpdatedDatetime).HasColumnName("Visitor_Record_Updated_Datetime");

                entity.Property(e => e.VisitorSourceSystemNk)
                    .HasColumnName("Visitor_Source_System_Nk")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimChurnProbability>(entity =>
            {
                entity.HasKey(e => e.ChurnProbabilityKey)
                    .HasName("PK_Dim_Churn_Probability");

                entity.ToTable("dim_churn_probability");

                entity.Property(e => e.ChurnProbabilityKey).HasColumnName("Churn_Probability_Key");

                entity.Property(e => e.ChurnProbabilityNk)
                    .HasColumnName("Churn_Probability_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDatetime)
                    .HasColumnName("Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDatetime)
                    .HasColumnName("Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimChurnReasonDetail>(entity =>
            {
                entity.HasKey(e => e.ChurnReasonDetailKey)
                    .HasName("PK_Dim_Churn_Reason_Detail");

                entity.ToTable("Dim_Churn_Reason_Detail");

                entity.HasIndex(e => e.ChurnReasonDetailCategory)
                    .HasName("IX_Churn_Reason_Detail_Category");

                entity.HasIndex(e => e.ChurnReasonDetailGroupName)
                    .HasName("IX_Churn_Reason_Detail_Group_Name");

                entity.HasIndex(e => e.ChurnReasonDetailNumber)
                    .HasName("IX_Churn_Reason_Detail_Number");

                entity.HasIndex(e => e.ChurnReasonDetailReportGroupName)
                    .HasName("IX_Churn_Reason_Detail_Report_Group_Name");

                entity.HasIndex(e => e.ChurnReasonDetailReportRanking)
                    .HasName("IX_Churn_Reason_Detail_Report_Ranking");

                entity.Property(e => e.ChurnReasonDetailKey).HasColumnName("Churn_Reason_Detail_KEY");

                entity.Property(e => e.ChurnReasonDetailCategory)
                    .HasColumnName("Churn_Reason_Detail_Category")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ChurnReasonDetailGroupName)
                    .HasColumnName("Churn_Reason_Detail_Group_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ChurnReasonDetailNumber).HasColumnName("Churn_Reason_Detail_Number");

                entity.Property(e => e.ChurnReasonDetailReportGroupName)
                    .HasColumnName("Churn_Reason_Detail_Report_Group_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ChurnReasonDetailReportRanking).HasColumnName("Churn_Reason_Detail_Report_Ranking");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("Rec_Updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimChurnReasonDetailBridge>(entity =>
            {
                entity.HasKey(e => e.ChurnBridgeKey)
                    .HasName("PK_Dim_Bridge_Churn_Reason_Detail");

                entity.ToTable("dim_churn_reason_detail_bridge");

                entity.Property(e => e.ChurnBridgeKey).HasColumnName("Churn_Bridge_Key");

                entity.Property(e => e.ChurnBridgeChildKey).HasColumnName("Churn_Bridge_Child_Key");

                entity.Property(e => e.ChurnBridgeIsBottom).HasColumnName("Churn_Bridge_Is_Bottom");

                entity.Property(e => e.ChurnBridgeIsTop).HasColumnName("Churn_Bridge_Is_Top");

                entity.Property(e => e.ChurnBridgeLevel).HasColumnName("Churn_Bridge_Level");

                entity.Property(e => e.ChurnBridgeNk)
                    .HasColumnName("Churn_Bridge_Nk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ChurnBridgeParentKey).HasColumnName("Churn_Bridge_Parent_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimCompany>(entity =>
            {
                entity.HasKey(e => e.CompanyKey)
                    .HasName("PK_COMPANY_KEY");

                entity.ToTable("Dim_Company");

                entity.HasIndex(e => e.CurrentRecord)
                    .HasName("IDX_CURRENT_RECORD");

                entity.HasIndex(e => new { e.EffectiveStartDate, e.EffectiveEndDate, e.CurrentRecord })
                    .HasName("IDX_ETL_INDEX");

                entity.Property(e => e.CompanyKey)
                    .HasColumnName("Company_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyAccessSubmitter)
                    .HasColumnName("Company_Access_Submitter")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyAccountNumber)
                    .HasColumnName("Company_Account_Number")
                    .HasMaxLength(40);

                entity.Property(e => e.CompanyAccountSource)
                    .HasColumnName("Company_Account_Source")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyAllAccountsOwnedByInactive)
                    .HasColumnName("Company_All_Accounts_Owned_By_Inactive")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyAnnualRevenue)
                    .HasColumnName("Company_Annual_Revenue")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyApplicationsHosted).HasColumnName("Company_Applications_Hosted");

                entity.Property(e => e.CompanyBillingAddress).HasColumnName("Company_Billing_Address");

                entity.Property(e => e.CompanyBillingCity)
                    .HasColumnName("Company_Billing_City")
                    .HasMaxLength(40);

                entity.Property(e => e.CompanyBillingCountry)
                    .HasColumnName("Company_Billing_Country")
                    .HasMaxLength(80);

                entity.Property(e => e.CompanyBillingCountryCode)
                    .HasColumnName("Company_Billing_Country_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyBillingCounty)
                    .HasColumnName("Company_Billing_County")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyBillingGeoCodeAccuracy)
                    .HasColumnName("Company_Billing_Geo_Code_Accuracy")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyBillingLatitude)
                    .HasColumnName("Company_Billing_Latitude")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyBillingLongitude)
                    .HasColumnName("Company_Billing_Longitude")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyBillingPostalCode)
                    .HasColumnName("Company_Billing_Postal_Code")
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyBillingState)
                    .HasColumnName("Company_Billing_State")
                    .HasMaxLength(80);

                entity.Property(e => e.CompanyBillingStateCode)
                    .HasColumnName("Company_Billing_State_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyBillingStreet)
                    .HasColumnName("Company_Billing_Street")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyBudget)
                    .HasColumnName("Company_Budget")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyCleanStatus)
                    .HasColumnName("Company_Clean_Status")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyClosedWonOpps)
                    .HasColumnName("Company_Closed_Won_Opps")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyCloudOnlyCustomer)
                    .HasColumnName("Company_Cloud_Only_Customer")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyComplianceRegulatoryObligation).HasColumnName("Company_Compliance_Regulatory_Obligation");

                entity.Property(e => e.CompanyConnectionReceivedId)
                    .HasColumnName("Company_Connection_Received_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyConnectionSentId)
                    .HasColumnName("Company_Connection_Sent_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyCountryNotSupported)
                    .HasColumnName("Company_Country_Not_Supported")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyCreatedById)
                    .HasColumnName("Company_Created_By_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyCreatedDatetimeCst)
                    .HasColumnName("Company_Created_Datetime_Cst")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CompanyCreatedDatetimeUtc)
                    .HasColumnName("Company_Created_Datetime_Utc")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CompanyCreatedbyProfilename)
                    .HasColumnName("Company_Createdby_Profilename")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyCrunchbase)
                    .HasColumnName("Company_Crunchbase")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CompanyCurrencyIsoCode)
                    .HasColumnName("Company_Currency_Iso_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyCustomRevenue)
                    .HasColumnName("Company_Custom_Revenue")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyDandBId)
                    .HasColumnName("Company_DandB_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyDataCleanHoldingAccount)
                    .HasColumnName("Company_Data_Clean_Holding_Account")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyDataMigrationSegmentation)
                    .HasColumnName("Company_Data_Migration_Segmentation")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyDataQualityDescription)
                    .HasColumnName("Company_Data_Quality_Description")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyDataQualityScore)
                    .HasColumnName("Company_Data_Quality_Score")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyDeleteRecord)
                    .HasColumnName("Company_Delete_Record")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyDeleted)
                    .HasColumnName("Company_Deleted")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyDescription).HasColumnName("Company_Description");

                entity.Property(e => e.CompanyDunsNumber)
                    .HasColumnName("Company_Duns_Number")
                    .HasMaxLength(9);

                entity.Property(e => e.CompanyEffectiveEndDatetimeCst)
                    .HasColumnName("Company_Effective_End_Datetime_Cst")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CompanyEffectiveEndDatetimeUtc)
                    .HasColumnName("Company_Effective_End_Datetime_Utc")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CompanyEffectiveStartDatetimeCst)
                    .HasColumnName("Company_Effective_Start_Datetime_Cst")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CompanyEffectiveStartDatetimeUtc)
                    .HasColumnName("Company_Effective_Start_Datetime_Utc")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CompanyEscalationNotes)
                    .HasColumnName("Company_Escalation_Notes")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyEverEscalatedToRackspace)
                    .HasColumnName("Company_Ever_Escalated_To_Rackspace")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyFax)
                    .HasColumnName("Company_Fax")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.CompanyFortuneRank)
                    .HasColumnName("Company_Fortune_Rank")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyHighestLevelName)
                    .HasColumnName("Company_Highest_Level_Name")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyHipoTeamActivelyWorking)
                    .HasColumnName("Company_Hipo_Team_Actively_Working")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyHipoTeamAssignedDate)
                    .HasColumnName("Company_Hipo_Team_Assigned_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CompanyHostingProvider)
                    .HasColumnName("Company_Hosting_Provider")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasColumnName("Company_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyIndustry)
                    .HasColumnName("Company_Industry")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyIsRackspaceCustomer)
                    .HasColumnName("Company_Is_Rackspace_Customer")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyJigsaw)
                    .HasColumnName("Company_Jigsaw")
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyJigsawCompanyId)
                    .HasColumnName("Company_Jigsaw_Company_Id")
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyJsimpactsAddedFromDataCom)
                    .HasColumnName("Company_Jsimpacts_Added_From_Data_Com")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyJsimpactsDataComDoesNot)
                    .HasColumnName("Company_Jsimpacts_Data_Com_Does_Not")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyJsimpactsDataComManaged)
                    .HasColumnName("Company_Jsimpacts_Data_Com_Managed")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyJsimpactsDataComMatched)
                    .HasColumnName("Company_Jsimpacts_Data_Com_Matched")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyLastReviewedBy)
                    .HasColumnName("Company_Last_Reviewed_By")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyLastReviewedOn)
                    .HasColumnName("Company_Last_Reviewed_On")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CompanyLidLinkedinCompanyId)
                    .HasColumnName("Company_Lid_Linkedin_Company_Id")
                    .HasMaxLength(80);

                entity.Property(e => e.CompanyLogo)
                    .HasColumnName("Company_Logo")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyLogoUrl)
                    .HasColumnName("Company_Logo_Url")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyMarketSector)
                    .HasColumnName("Company_Market_Sector")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyMatchedWithDataComOn)
                    .HasColumnName("Company_Matched_With_Data_Com_On")
                    .HasColumnType("datetime");

                entity.Property(e => e.CompanyMrr)
                    .HasColumnName("Company_Mrr")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNaicCode)
                    .HasColumnName("Company_NAIC_Code")
                    .HasMaxLength(8);

                entity.Property(e => e.CompanyNaicDescription)
                    .HasColumnName("Company_NAIC_Description")
                    .HasMaxLength(120);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("Company_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyNumOfAccountsOwnedByInactive)
                    .HasColumnName("Company_Num_Of_Accounts_Owned_By_Inactive")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfAccounts)
                    .HasColumnName("Company_Number_Of_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfCloudAccounts)
                    .HasColumnName("Company_Number_Of_Cloud_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfCustomerAccounts)
                    .HasColumnName("Company_Number_Of_Customer_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfEmployees).HasColumnName("Company_Number_Of_Employees");

                entity.Property(e => e.CompanyNumberOfP1Accounts)
                    .HasColumnName("Company_Number_Of_P1_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfP2Accounts)
                    .HasColumnName("Company_Number_Of_P2_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfP3Accounts)
                    .HasColumnName("Company_Number_Of_P3_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfP4Accounts)
                    .HasColumnName("Company_Number_Of_P4_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyNumberOfP5Accounts)
                    .HasColumnName("Company_Number_Of_P5_Accounts")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyOpenOpps)
                    .HasColumnName("Company_Open_Opps")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyOptOut)
                    .HasColumnName("Company_Opt_Out")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyOtherApplicationHosted)
                    .HasColumnName("Company_Other_Application_Hosted")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyOwnership)
                    .HasColumnName("Company_Ownership")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyParentId)
                    .HasColumnName("Company_Parent_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyParentedStatus)
                    .HasColumnName("Company_Parented_Status")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyPhone)
                    .HasColumnName("Company_Phone")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.CompanyPhotoUrl)
                    .HasColumnName("Company_Photo_Url")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CompanyPriority)
                    .HasColumnName("Company_Priority")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyRating)
                    .HasColumnName("Company_Rating")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyReferenceAccount)
                    .HasColumnName("Company_Reference_Account")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyRegistrationNumber)
                    .HasColumnName("Company_Registration_Number")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyReviewPriority)
                    .HasColumnName("Company_Review_Priority")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyReviewStatus)
                    .HasColumnName("Company_Review_Status")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyRkpi2DeletedFromRainking)
                    .HasColumnName("Company_Rkpi2_Deleted_From_Rainking")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.CompanyRkpi2RkCompanyId)
                    .HasColumnName("Company_Rkpi2_Rk_Company_Id")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyRkpi2RkDefaultVisibility)
                    .HasColumnName("Company_Rkpi2_Rk_Default_Visibility")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyRkpi2RkRetrievalFlag)
                    .HasColumnName("Company_Rkpi2_Rk_Retrieval_Flag")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyRtbRecordId)
                    .HasColumnName("Company_Rtb_Record_Id")
                    .HasMaxLength(100);

                entity.Property(e => e.CompanySearchInHoovers)
                    .HasColumnName("Company_Search_In_Hoovers")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanyShippingAddress).HasColumnName("Company_Shipping_Address");

                entity.Property(e => e.CompanyShippingCity)
                    .HasColumnName("Company_Shipping_City")
                    .HasMaxLength(40);

                entity.Property(e => e.CompanyShippingCountry)
                    .HasColumnName("Company_Shipping_Country")
                    .HasMaxLength(80);

                entity.Property(e => e.CompanyShippingCountryCode)
                    .HasColumnName("Company_Shipping_Country_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyShippingCounty)
                    .HasColumnName("Company_Shipping_County")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyShippingGeoCodeAccuracy)
                    .HasColumnName("Company_Shipping_Geo_Code_Accuracy")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyShippingLatitude)
                    .HasColumnName("Company_Shipping_Latitude")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyShippingLongitude)
                    .HasColumnName("Company_Shipping_Longitude")
                    .HasColumnType("decimal");

                entity.Property(e => e.CompanyShippingPostalCode)
                    .HasColumnName("Company_Shipping_Postal_Code")
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyShippingState)
                    .HasColumnName("Company_Shipping_State")
                    .HasMaxLength(80);

                entity.Property(e => e.CompanyShippingStateCode)
                    .HasColumnName("Company_Shipping_State_Code")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyShippingStreet)
                    .HasColumnName("Company_Shipping_Street")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanySic)
                    .HasColumnName("Company_SIC")
                    .HasMaxLength(20);

                entity.Property(e => e.CompanySicDescription)
                    .HasColumnName("Company_SIC_Description")
                    .HasMaxLength(80);

                entity.Property(e => e.CompanySite)
                    .HasColumnName("Company_Site")
                    .HasMaxLength(80);

                entity.Property(e => e.CompanyStatus)
                    .HasColumnName("Company_Status")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanySubsidiaryLevel)
                    .HasColumnName("Company_Subsidiary_Level")
                    .HasMaxLength(1300);

                entity.Property(e => e.CompanySupportOffice)
                    .HasColumnName("Company_Support_Office")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyTaxIdVatNumber)
                    .HasColumnName("Company_Tax_Id_Vat_Number")
                    .HasMaxLength(100);

                entity.Property(e => e.CompanyTerritory)
                    .HasColumnName("Company_Territory")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyTickerSymbol)
                    .HasColumnName("Company_Ticker_Symbol")
                    .HasMaxLength(20);

                entity.Property(e => e.CompanyTradeStyle)
                    .HasColumnName("Company_Trade_Style")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyType)
                    .HasColumnName("Company_Type")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyWebsite)
                    .HasColumnName("Company_Website")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CompanyYearStarted)
                    .HasColumnName("Company_Year_Started")
                    .HasMaxLength(4);

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.DwTimestamp)
                    .HasColumnName("dw_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnName("Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OldRecordId)
                    .HasColumnName("OLD_RECORD_ID")
                    .HasMaxLength(18);

                entity.Property(e => e.RackspaceOwnerId)
                    .HasColumnName("Rackspace_Owner_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.RackspaceOwnerName)
                    .HasColumnName("Rackspace_Owner_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasMaxLength(100);

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasMaxLength(100);

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("Updated_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimContact>(entity =>
            {
                entity.HasKey(e => e.ContactKey)
                    .HasName("PK_Dim_Contact_122016");

                entity.ToTable("Dim_Contact");

                entity.HasIndex(e => e.ContactCoreContactId)
                    .HasName("IDX_CONTACT_CORE_ID_NX01");

                entity.HasIndex(e => e.ContactLastName)
                    .HasName("idx_contact_last_name");

                entity.HasIndex(e => e.ContactNk)
                    .HasName("IX_Dim_Contact_Contact_NK");

                entity.HasIndex(e => new { e.ContactEmail, e.ContactCurrentRecord })
                    .HasName("IDX_Email_Address");

                entity.HasIndex(e => new { e.ContactSourceName, e.ContactCurrentRecord })
                    .HasName("IX_Dim_Contact_Current_Record_Source_Name");

                entity.HasIndex(e => new { e.ContactFullName, e.ContactSourceName, e.ContactCurrentRecord })
                    .HasName("IDX_Dim_Contact_Contact_Full_Name");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_KEY");

                entity.Property(e => e.ContactAccountId)
                    .HasColumnName("Contact_Account_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactAssistantName)
                    .HasColumnName("Contact_Assistant_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactAssistantPhone)
                    .HasColumnName("Contact_Assistant_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactBirthdate)
                    .HasColumnName("Contact_Birthdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactBusinessCategory)
                    .HasColumnName("Contact_BusinessCategory")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactCompany)
                    .HasColumnName("Contact_Company")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactContactTitle)
                    .HasColumnName("Contact_Contact_Title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactCoreContactId)
                    .HasColumnName("Contact_CORE_Contact_ID")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContactCreatedById)
                    .HasColumnName("Contact_Created_By_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactCreatedDate)
                    .HasColumnName("Contact_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactCurrencyIsoCode)
                    .HasColumnName("Contact_Currency_ISO_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactCurrentRecord).HasColumnName("Contact_Current_Record");

                entity.Property(e => e.ContactDeletedDateKey).HasColumnName("Contact_Deleted_Date_Key");

                entity.Property(e => e.ContactDepartment)
                    .HasColumnName("Contact_Department")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactDescription)
                    .HasColumnName("Contact_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactDiscProfile)
                    .HasColumnName("Contact_Disc_Profile")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactDivision)
                    .HasColumnName("Contact_Division")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactDoNotCall)
                    .HasColumnName("Contact_Do_Not_Call")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactDoNotMail)
                    .HasColumnName("Contact_Do_Not_Mail")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactEffectiveEndDatetime)
                    .HasColumnName("Contact_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactEffectiveStartDatetime)
                    .HasColumnName("Contact_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("Contact_Email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactEmail2)
                    .HasColumnName("Contact_Email2")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmail3)
                    .HasColumnName("Contact_Email3")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmail4)
                    .HasColumnName("Contact_Email4")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmail5)
                    .HasColumnName("Contact_Email5")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmployeeNumber)
                    .HasColumnName("Contact_Employee_Number")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.ContactEmployeeType)
                    .HasColumnName("Contact_Employee_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactEthnicity)
                    .IsRequired()
                    .HasColumnName("Contact_Ethnicity")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ContactExponenthrid)
                    .IsRequired()
                    .HasColumnName("Contact_Exponenthrid")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ContactFax)
                    .HasColumnName("Contact_FAX")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactFirstName)
                    .HasColumnName("Contact_First_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactFullName)
                    .HasColumnName("Contact_Full_Name")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactGender)
                    .IsRequired()
                    .HasColumnName("Contact_Gender")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactGroup)
                    .HasColumnName("Contact_Group")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactHasOptedOutOfEmail)
                    .HasColumnName("Contact_Has_Opted_Out_Of_Email")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactHobbies)
                    .HasColumnName("Contact_Hobbies")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactHomePhone)
                    .HasColumnName("Contact_Home_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactInactive)
                    .HasColumnName("Contact_Inactive")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactLanguagePreference)
                    .HasColumnName("Contact_Language_Preference")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactLastActivityDate)
                    .HasColumnName("Contact_Last_Activity_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactLastCuRequestDate)
                    .HasColumnName("Contact_Last_CU_Request_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactLastCuUpdateDate)
                    .HasColumnName("Contact_Last_CU_Update_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactLastModifiedBy)
                    .HasColumnName("Contact_Last_Modified_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactLastName)
                    .HasColumnName("Contact_Last_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactLeadSource)
                    .HasColumnName("Contact_Lead_Source")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactLocation)
                    .HasColumnName("Contact_Location")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingCity)
                    .HasColumnName("Contact_Mailing_City")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactMailingCountry)
                    .HasColumnName("Contact_Mailing_Country")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingPostalCode)
                    .HasColumnName("Contact_Mailing_Postal_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingState)
                    .HasColumnName("Contact_Mailing_State")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingStreet)
                    .HasColumnName("Contact_Mailing_Street")
                    .HasColumnType("varchar(800)");

                entity.Property(e => e.ContactMobilePhone)
                    .HasColumnName("Contact_Mobile_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactNk)
                    .HasColumnName("Contact_NK")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactOtherCity)
                    .HasColumnName("Contact_Other_City")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactOtherCountry)
                    .HasColumnName("Contact_Other_Country")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactOtherPhone)
                    .HasColumnName("Contact_Other_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactOtherPostalCode)
                    .HasColumnName("Contact_Other_Postal_Code")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.ContactOtherState)
                    .HasColumnName("Contact_Other_State")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactOtherStreet)
                    .HasColumnName("Contact_Other_Street")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.ContactOwnerId)
                    .HasColumnName("Contact_Owner_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("Contact_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactPhone2)
                    .HasColumnName("Contact_Phone2")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhone3)
                    .HasColumnName("Contact_Phone3")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhone4)
                    .HasColumnName("Contact_Phone4")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhone5)
                    .HasColumnName("Contact_Phone5")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhoneExtension).HasColumnName("Contact_Phone_Extension");

                entity.Property(e => e.ContactPreferredName)
                    .HasColumnName("Contact_PreferredName")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactRecordCreatedBy)
                    .HasColumnName("Contact_Record_Created_By")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactRecordCreatedDatetime)
                    .HasColumnName("Contact_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactRecordUpdatedBy)
                    .HasColumnName("Contact_Record_Updated_By")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactRecordUpdatedDatetime)
                    .HasColumnName("Contact_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactRegion)
                    .HasColumnName("Contact_Region")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactReportsToId)
                    .HasColumnName("Contact_Reports_To_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactSalutation)
                    .HasColumnName("Contact_Salutation")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactSecretAnswer)
                    .HasColumnName("Contact_Secret_Answer")
                    .HasColumnType("varchar(600)");

                entity.Property(e => e.ContactSecretQuestion)
                    .HasColumnName("Contact_Secret_Question")
                    .HasColumnType("varchar(600)");

                entity.Property(e => e.ContactSourceName)
                    .HasColumnName("Contact_Source_Name")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactSso)
                    .HasColumnName("Contact_SSO")
                    .HasMaxLength(255);

                entity.Property(e => e.ContactSubGroup)
                    .HasColumnName("Contact_Sub_Group")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactSupervisor)
                    .HasColumnName("Contact_Supervisor")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactSupervisorEmail)
                    .HasColumnName("Contact_Supervisor_Email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactSupportTeam)
                    .HasColumnName("Contact_Support_Team")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContactSurveyBlackList)
                    .IsRequired()
                    .HasColumnName("Contact_Survey_Black_List")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactSystemModStamp)
                    .HasColumnName("Contact_System_Mod_Stamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactTitle)
                    .HasColumnName("Contact_Title")
                    .HasColumnType("varchar(384)");

                entity.Property(e => e.ContactType)
                    .HasColumnName("Contact_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactWorkShift)
                    .HasColumnName("Contact_Work_Shift")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimContactRole>(entity =>
            {
                entity.HasKey(e => e.ContactRoleKey)
                    .HasName("PK_Dim_Contact_Role");

                entity.ToTable("dim_contact_role");

                entity.HasIndex(e => e.ContactRoleNk)
                    .HasName("ix_dim_contact_role_contact_nk");

                entity.HasIndex(e => e.ContactRoleSourceName)
                    .HasName("IX_Dim_Contact_Role_Source_System_Name");

                entity.Property(e => e.ContactRoleKey).HasColumnName("Contact_Role_KEY");

                entity.Property(e => e.ContactRoleCategoryId).HasColumnName("Contact_Role_Category_ID");

                entity.Property(e => e.ContactRoleCurrentRecord).HasColumnName("Contact_Role_Current_Record");

                entity.Property(e => e.ContactRoleDescription)
                    .IsRequired()
                    .HasColumnName("Contact_Role_Description")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.ContactRoleEffectiveEndDatetime)
                    .HasColumnName("Contact_Role_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactRoleEffectiveStartDatetime)
                    .HasColumnName("Contact_Role_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactRoleGroupId).HasColumnName("Contact_Role_Group_ID");

                entity.Property(e => e.ContactRoleName)
                    .IsRequired()
                    .HasColumnName("Contact_Role_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactRoleNk)
                    .IsRequired()
                    .HasColumnName("Contact_Role_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactRoleRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Contact_Role_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContactRoleRecordCreatedDatetime)
                    .HasColumnName("Contact_Role_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactRoleRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Contact_Role_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContactRoleRecordUpdatedDatetime)
                    .HasColumnName("Contact_Role_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactRoleSourceName)
                    .IsRequired()
                    .HasColumnName("Contact_Role_Source_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimCreditEventDesc>(entity =>
            {
                entity.HasKey(e => e.CreditEventDescKey)
                    .HasName("PK_Dim_Credit_Event_Desc");

                entity.ToTable("dim_credit_event_desc");

                entity.Property(e => e.CreditEventDescKey).HasColumnName("Credit_Event_Desc_Key");

                entity.Property(e => e.CreditEventDescEffectiveEndDate)
                    .HasColumnName("Credit_Event_Desc_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditEventDescEffectiveStartDate)
                    .HasColumnName("Credit_Event_Desc_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditEventDescription)
                    .HasColumnName("Credit_Event_Description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.CreditEventNk).HasColumnName("Credit_Event_NK");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordUpdatedDate)
                    .HasColumnName("Record_Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DimCreditMemoAttribute>(entity =>
            {
                entity.HasKey(e => e.CreditMemoAttributeKey)
                    .HasName("PK_Dim_Credit_Memo_Attribute");

                entity.ToTable("dim_credit_memo_attribute");

                entity.Property(e => e.CreditMemoAttributeKey).HasColumnName("Credit_Memo_Attribute_Key");

                entity.Property(e => e.CreditMemoAttributeCurrencyType)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Attribute_Currency_Type")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CreditMemoAttributeCurrentRecordFlag).HasColumnName("Credit_Memo_Attribute_Current_Record_Flag");

                entity.Property(e => e.CreditMemoAttributeEarnedRevenueFlag).HasColumnName("Credit_Memo_Attribute_Earned_Revenue_Flag");

                entity.Property(e => e.CreditMemoAttributeEffectiveEndDate)
                    .HasColumnName("Credit_Memo_Attribute_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoAttributeEffectiveStartDate)
                    .HasColumnName("Credit_Memo_Attribute_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoAttributeNk)
                    .HasColumnName("Credit_Memo_Attribute_NK")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.CreditMemoAttributeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Attribute_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CreditMemoAttributeRecordCreatedDatetime)
                    .HasColumnName("Credit_Memo_Attribute_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoAttributeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Attribute_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CreditMemoAttributeRecordUpdatedDatetime)
                    .HasColumnName("Credit_Memo_Attribute_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoAttributeServiceFailureGroupText)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Attribute_Service_Failure_Group_Text")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CreditMemoAttributeServiceFailureText)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Attribute_Service_Failure_Text")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CreditMemoAttributeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Attribute_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimCreditMemoLogType>(entity =>
            {
                entity.HasKey(e => e.CreditMemoLogTypeKey)
                    .HasName("PK_Dim_Credit_Memo_Log_Type");

                entity.ToTable("dim_credit_memo_log_type");

                entity.Property(e => e.CreditMemoLogTypeKey).HasColumnName("Credit_Memo_Log_Type_Key");

                entity.Property(e => e.CreditMemoLogType)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Log_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CreditMemoLogTypeCurrentRecordFlag).HasColumnName("Credit_Memo_Log_Type_Current_Record_Flag");

                entity.Property(e => e.CreditMemoLogTypeDescription)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Log_Type_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreditMemoLogTypeEffectiveEndDate)
                    .HasColumnName("Credit_Memo_Log_Type_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoLogTypeEffectiveStartDate)
                    .HasColumnName("Credit_Memo_Log_Type_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoLogTypeNk).HasColumnName("Credit_Memo_Log_Type_NK");

                entity.Property(e => e.CreditMemoLogTypeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Log_Type_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CreditMemoLogTypeRecordCreatedDatetime)
                    .HasColumnName("Credit_Memo_Log_Type_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoLogTypeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Log_Type_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CreditMemoLogTypeRecordUpdatedDatetime)
                    .HasColumnName("Credit_Memo_Log_Type_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoLogTypeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Log_Type_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimCrmLead>(entity =>
            {
                entity.HasKey(e => e.LeadKey)
                    .HasName("PK_dim_crm_lead");

                entity.ToTable("dim_crm_lead");

                entity.HasIndex(e => e.CurrentRecord)
                    .HasName("IDX_CURRENT_RECORD");

                entity.HasIndex(e => e.LeadIdNk)
                    .HasName("idx_lead_id_nk");

                entity.HasIndex(e => e.SourceSystemName)
                    .HasName("IDX_SOURCE_SYSTEM_NAME");

                entity.Property(e => e.LeadKey).HasColumnName("lead_key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.LeadCompany)
                    .HasColumnName("lead_company")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.LeadConvertedaccountNumber)
                    .HasColumnName("lead_CONVERTEDACCOUNT_NUMBER")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadConvertedaccountid)
                    .HasColumnName("lead_CONVERTEDACCOUNTID")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadConvertedcontactName)
                    .HasColumnName("lead_CONVERTEDCONTACT_NAME")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadConvertedcontactid)
                    .HasColumnName("lead_CONVERTEDCONTACTID")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadConverteddate)
                    .HasColumnName("lead_CONVERTEDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeadConvertedopportunityid)
                    .HasColumnName("lead_CONVERTEDOPPORTUNITYID")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadCreatedFromLead)
                    .HasColumnName("lead_CREATED_FROM_LEAD")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.LeadCreatedby)
                    .HasColumnName("lead_CREATEDBY")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadCreateddate)
                    .HasColumnName("lead_CREATEDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeadDeletedFlag)
                    .HasColumnName("lead_DELETED_FLAG")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.LeadEmail)
                    .HasColumnName("lead_email")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadIdNk)
                    .HasColumnName("lead_id_nk")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadIsconverted)
                    .HasColumnName("lead_ISCONVERTED")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.LeadIsdeleted)
                    .HasColumnName("lead_ISDELETED")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.LeadLastmodifiedby)
                    .HasColumnName("lead_LASTMODIFIEDBY")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadLastmodifieddate)
                    .HasColumnName("lead_LASTMODIFIEDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeadLead)
                    .HasColumnName("lead_LEAD")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadLeadGenerator)
                    .HasColumnName("lead_LEAD_GENERATOR")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadLeadGeneratorRole)
                    .HasColumnName("lead_LEAD_GENERATOR_ROLE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadLeadType)
                    .HasColumnName("lead_LEAD_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadLpid)
                    .HasColumnName("lead_LPID")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.LeadNamex)
                    .HasColumnName("lead_namex")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadOwner)
                    .HasColumnName("lead_OWNER")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadProjectedCloseDate)
                    .HasColumnName("lead_PROJECTED_CLOSE_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeadRating)
                    .HasColumnName("lead_RATING")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadSalesRep)
                    .HasColumnName("lead_SALES_REP")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadSource)
                    .HasColumnName("lead_SOURCE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadTerritory)
                    .HasColumnName("lead_TERRITORY")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDate)
                    .HasColumnName("Record_effective_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDate)
                    .HasColumnName("Record_effective_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimCrmOpportunity>(entity =>
            {
                entity.HasKey(e => e.OpportunityKey)
                    .HasName("PK_dim_crm_opportunity");

                entity.ToTable("dim_crm_opportunity");

                entity.HasIndex(e => e.OpportunityAccountNumber)
                    .HasName("idx_opp_account_number");

                entity.HasIndex(e => e.OpportunityDeleteFlag)
                    .HasName("idx_opp_delete_flag");

                entity.HasIndex(e => e.OpportunityIdNk)
                    .HasName("idx_opp_id_nk");

                entity.HasIndex(e => e.OpportunityNumber)
                    .HasName("idx_opp_number");

                entity.HasIndex(e => e.OpportunityType)
                    .HasName("idx_opp_type");

                entity.Property(e => e.OpportunityKey).HasColumnName("opportunity_key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.OpportunityAccountName)
                    .HasColumnName("opportunity_account_name")
                    .HasColumnType("varchar(768)");

                entity.Property(e => e.OpportunityAccountNumber)
                    .HasColumnName("opportunity_account_number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OpportunityAccountid)
                    .HasColumnName("opportunity_accountid")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.OpportunityApprovalAmount)
                    .HasColumnName("opportunity_APPROVAL_AMOUNT")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityApprovalReason)
                    .HasColumnName("opportunity_APPROVAL_REASON")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunityCampaignName)
                    .HasColumnName("opportunity_campaign_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityCategory)
                    .HasColumnName("opportunity_CATEGORY")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityCloneOpportunity)
                    .HasColumnName("opportunity_CLONE_OPPORTUNITY")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunityCloned)
                    .HasColumnName("opportunity_CLONED")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityCloseddate)
                    .HasColumnName("opportunity_closeddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityCloudAccountNumber)
                    .HasColumnName("opportunity_CLOUD_ACCOUNT_NUMBER")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunityConfirmedAmount)
                    .HasColumnName("opportunity_CONFIRMED_AMOUNT")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityContractLength)
                    .HasColumnName("opportunity_CONTRACT_LENGTH")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityContractReceived)
                    .HasColumnName("opportunity_CONTRACT_RECEIVED")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityContractStartDate)
                    .HasColumnName("opportunity_CONTRACT_START_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityCreatedFromLead)
                    .HasColumnName("opportunity_CREATED_FROM_LEAD")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityCreatedby)
                    .HasColumnName("opportunity_CREATEDBY")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.OpportunityCreateddate)
                    .HasColumnName("opportunity_CREATEDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityCurrencyCode)
                    .HasColumnName("opportunity_currency_code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityCurrentMrr)
                    .HasColumnName("opportunity_CURRENT_MRR")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityDbMarketing)
                    .HasColumnName("opportunity_DB_MARKETING")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityDbMarketingDate)
                    .HasColumnName("opportunity_DB_MARKETING_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityDeleteFlag)
                    .HasColumnName("opportunity_DELETE_FLAG")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityEvaGrade)
                    .HasColumnName("opportunity_EVA_GRADE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityExpectedRevenue)
                    .HasColumnName("opportunity_expected_revenue")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityFinalOpportunityType)
                    .HasColumnName("opportunity_FINAL_OPPORTUNITY_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityFiscal)
                    .HasColumnName("opportunity_FISCAL")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.OpportunityFiscalquarter).HasColumnName("opportunity_FISCALQUARTER");

                entity.Property(e => e.OpportunityFiscalyear).HasColumnName("opportunity_FISCALYEAR");

                entity.Property(e => e.OpportunityIdNk)
                    .IsRequired()
                    .HasColumnName("opportunity_id_nk")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OpportunityIsclosed)
                    .HasColumnName("opportunity_isclosed")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityIsdeleted)
                    .HasColumnName("opportunity_ISDELETED")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityIswon)
                    .HasColumnName("opportunity_iswon")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityLastactivitydate)
                    .HasColumnName("opportunity_LASTACTIVITYDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityLastmodifiedby)
                    .HasColumnName("opportunity_LASTMODIFIEDBY")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.OpportunityLastmodifieddate)
                    .HasColumnName("opportunity_LASTMODIFIEDDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityLdtDatePassed)
                    .HasColumnName("opportunity_LDT_DATE_PASSED")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityLdtRep)
                    .HasColumnName("opportunity_LDT_REP")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.OpportunityLdtRole)
                    .HasColumnName("opportunity_LDT_ROLE")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.OpportunityLeadDatePassed)
                    .HasColumnName("opportunity_LEAD_DATE_PASSED")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityLeadGenerator)
                    .HasColumnName("opportunity_LEAD_GENERATOR")
                    .HasColumnType("varchar(768)");

                entity.Property(e => e.OpportunityLeadGeneratorId)
                    .HasColumnName("opportunity_LEAD_GENERATOR_ID")
                    .HasColumnType("varchar(400)");

                entity.Property(e => e.OpportunityLeadGeneratorRole)
                    .HasColumnName("opportunity_LEAD_GENERATOR_ROLE")
                    .HasColumnType("varchar(400)");

                entity.Property(e => e.OpportunityLeadId)
                    .HasColumnName("opportunity_LEAD_ID")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.OpportunityLeadSource)
                    .HasColumnName("opportunity_lead_source")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityLeadToCloseDays)
                    .HasColumnName("opportunity_LEAD_TO_CLOSE_DAYS")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityLeadToProposalDays)
                    .HasColumnName("opportunity_LEAD_TO_PROPOSAL_DAYS")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityLpid)
                    .HasColumnName("opportunity_LPID")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunityMaxDatePassed)
                    .HasColumnName("opportunity_MAX_DATE_PASSED")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityName)
                    .HasColumnName("opportunity_name")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.OpportunityNewMrr)
                    .HasColumnName("opportunity_NEW_MRR")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityNumber)
                    .HasColumnName("opportunity_number")
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.OpportunityNurtureFollowUpDate)
                    .HasColumnName("opportunity_NURTURE_FOLLOW_UP_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityNurtureReason)
                    .HasColumnName("opportunity_NURTURE_REASON")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.OpportunityOppType)
                    .HasColumnName("opportunity_opp_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityOwner)
                    .HasColumnName("opportunity_owner")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.OpportunityOwnerRole)
                    .HasColumnName("opportunity_owner_role")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityPartneraccountid)
                    .HasColumnName("opportunity_PARTNERACCOUNTID")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.OpportunityProposal)
                    .HasColumnName("opportunity_PROPOSAL")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityProposalToCloseDays)
                    .HasColumnName("opportunity_PROPOSAL_TO_CLOSE_DAYS")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityQuoteType)
                    .HasColumnName("opportunity_QUOTE_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityReason)
                    .HasColumnName("opportunity_REASON")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.OpportunityReason1)
                    .HasColumnName("opportunity_REASON_1")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityReason2)
                    .HasColumnName("opportunity_REASON_2")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityReject)
                    .HasColumnName("opportunity_REJECT")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityRejectedDate)
                    .HasColumnName("opportunity_REJECTED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityRepRating)
                    .HasColumnName("opportunity_REP_RATING")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityResolution1)
                    .HasColumnName("opportunity_RESOLUTION_1")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityResolution2)
                    .HasColumnName("opportunity_RESOLUTION_2")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityRevived)
                    .HasColumnName("opportunity_REVIVED")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityRevivedOpp)
                    .HasColumnName("opportunity_REVIVED_OPP")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunitySalesRep)
                    .HasColumnName("opportunity_SALES_REP")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.OpportunitySegmentx)
                    .HasColumnName("opportunity_SEGMENTX")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySubType)
                    .HasColumnName("opportunity_SUB_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySupportOffice)
                    .HasColumnName("opportunity_SUPPORT_OFFICE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySupportSegment)
                    .HasColumnName("opportunity_SUPPORT_SEGMENT")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySupportTeam)
                    .HasColumnName("opportunity_SUPPORT_TEAM")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityTerritory)
                    .HasColumnName("opportunity_TERRITORY")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityType)
                    .HasColumnName("opportunity_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityValuex)
                    .HasColumnName("opportunity_VALUEX")
                    .HasColumnType("decimal");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDate)
                    .HasColumnName("Record_effective_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDate)
                    .HasColumnName("Record_effective_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimCrmOpportunityStagename>(entity =>
            {
                entity.HasKey(e => e.CrmOpportunityStageKey)
                    .HasName("dim_crm_opportunity_stage_PK");

                entity.ToTable("dim_crm_opportunity_stagename");

                entity.HasIndex(e => e.CrmOpportunityStageStatus)
                    .HasName("idx_opp_stage_status");

                entity.Property(e => e.CrmOpportunityStageKey).HasColumnName("crm_opportunity_stage_key");

                entity.Property(e => e.CrmOpportunityStageName)
                    .IsRequired()
                    .HasColumnName("crm_opportunity_stage_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CrmOpportunityStageNk)
                    .IsRequired()
                    .HasColumnName("crm_opportunity_stage_NK")
                    .HasColumnType("varchar(512)");

                entity.Property(e => e.CrmOpportunityStageStatus)
                    .IsRequired()
                    .HasColumnName("crm_opportunity_stage_status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDate)
                    .HasColumnName("Record_effective_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDate)
                    .HasColumnName("Record_effective_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyKey)
                    .HasName("PK_Dim_Currency");

                entity.ToTable("Dim_Currency");

                entity.Property(e => e.CurrencyKey).HasColumnName("Currency_Key");

                entity.Property(e => e.CurrencyDescription)
                    .IsRequired()
                    .HasColumnName("Currency_Description")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.CurrencyIsoCode)
                    .IsRequired()
                    .HasColumnName("Currency_Iso_Code")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.CurrencyIsoNumericCode).HasColumnName("Currency_Iso_Numeric_Code");

                entity.Property(e => e.CurrencyRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Currency_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CurrencyRecordCreatedDatetime)
                    .HasColumnName("Currency_Record_Created_Datetime")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CurrencyRecordType)
                    .IsRequired()
                    .HasColumnName("Currency_Record_Type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CurrencyRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Currency_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CurrencyRecordUpdatedDatetime)
                    .HasColumnName("Currency_Record_Updated_Datetime")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.CurrencySymbol).HasColumnName("Currency_Symbol");
            });

            modelBuilder.Entity<DimDatacenter>(entity =>
            {
                entity.HasKey(e => e.DatacenterKey)
                    .HasName("PK_Dim_Datacenter");

                entity.ToTable("dim_datacenter");

                entity.Property(e => e.DatacenterKey).HasColumnName("Datacenter_Key");

                entity.Property(e => e.DatacenterAbbr)
                    .HasColumnName("Datacenter_abbr")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DatacenterCity)
                    .HasColumnName("Datacenter_city")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DatacenterCountry)
                    .HasColumnName("Datacenter_country")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DatacenterCurrentRecordFlag).HasColumnName("Datacenter_Current_Record_Flag");

                entity.Property(e => e.DatacenterName)
                    .HasColumnName("Datacenter_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DatacenterNtwkValWanconnectionId).HasColumnName("Datacenter_NTWK_val_WANConnectionID");

                entity.Property(e => e.DatacenterNumber).HasColumnName("Datacenter_number");

                entity.Property(e => e.DatacenterRecordCreatedBy)
                    .HasColumnName("Datacenter_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DatacenterRecordCreatedDatetime)
                    .HasColumnName("Datacenter_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatacenterRecordEffectiveEndDatetime)
                    .HasColumnName("Datacenter_Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatacenterRecordEffectiveStartDatetime)
                    .HasColumnName("Datacenter_Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatacenterRecordUpdatedBy)
                    .HasColumnName("Datacenter_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DatacenterRecordUpdatedDatetime)
                    .HasColumnName("Datacenter_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DatacenterRentCost)
                    .HasColumnName("Datacenter_Rent_Cost")
                    .HasColumnType("money");

                entity.Property(e => e.DatacenterRentCostPerUnit)
                    .HasColumnName("Datacenter_Rent_Cost_Per_Unit")
                    .HasColumnType("money");

                entity.Property(e => e.DatacenterSourceSystemName)
                    .HasColumnName("Datacenter_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DatacenterState)
                    .HasColumnName("Datacenter_state")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DatacenterUnitCapacity).HasColumnName("Datacenter_Unit_Capacity");
            });

            modelBuilder.Entity<DimDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentKey)
                    .HasName("PK_Dim_Department");

                entity.ToTable("dim_department");

                entity.Property(e => e.DepartmentKey).HasColumnName("Department_Key");

                entity.Property(e => e.DepartmentActiveStatus)
                    .IsRequired()
                    .HasColumnName("Department_Active_Status")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.DepartmentCurrentRecordFlag).HasColumnName("Department_Current_Record_Flag");

                entity.Property(e => e.DepartmentDescription)
                    .IsRequired()
                    .HasColumnName("Department_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.DepartmentEffectiveEndDate)
                    .HasColumnName("Department_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentEffectiveStartDate)
                    .HasColumnName("Department_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasColumnName("Department_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DepartmentNk)
                    .IsRequired()
                    .HasColumnName("Department_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DepartmentRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Department_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DepartmentRecordCreatedDatetime)
                    .HasColumnName("Department_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Department_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DepartmentRecordUpdatedDatetime)
                    .HasColumnName("Department_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Department_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimDevice>(entity =>
            {
                entity.HasKey(e => e.DeviceKey)
                    .HasName("PK_Dim_Device");

                entity.ToTable("Dim_Device");

                entity.HasIndex(e => e.CurrentRecord)
                    .HasName("IX_Current_Record");

                entity.HasIndex(e => e.DeviceDatacenterAbbr)
                    .HasName("IX_Device_Datacenter_Abbr");

                entity.HasIndex(e => e.DeviceOfflineDate)
                    .HasName("IX_Device_Offline_Date");

                entity.HasIndex(e => e.DeviceOnlineDate)
                    .HasName("IX_Device_Online_Date");

                entity.HasIndex(e => e.DeviceSalesRep1)
                    .HasName("IX_SR1");

                entity.HasIndex(e => e.DeviceSalesRep2)
                    .HasName("IX_SR2");

                entity.HasIndex(e => e.DeviceStatus)
                    .HasName("IX_Device_Status");

                entity.HasIndex(e => e.RecUpdated)
                    .HasName("IX_DD_Rec_Updated");

                entity.HasIndex(e => new { e.DeviceAssignedAccountNumber, e.CurrentRecord })
                    .HasName("IX_Device_Asgn_Acct_Num");

                entity.HasIndex(e => new { e.DeviceNumber, e.CurrentRecord })
                    .HasName("IX_Device_Number");

                entity.HasIndex(e => new { e.DeviceType, e.CurrentRecord })
                    .HasName("IX_Device_Type");

                entity.HasIndex(e => new { e.DeviceStatusNumber, e.DeviceType, e.CurrentRecord, e.DeviceAssignedAccountNumber })
                    .HasName("IX_Device_Status_Number");

                entity.HasIndex(e => new { e.DeviceStatusNumber, e.DeviceType, e.DeviceNumber, e.CurrentRecord, e.DeviceAssignedAccountNumber })
                    .HasName("IX_Device_Details");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.ChassisSize).HasColumnName("Chassis_Size");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.DeviceActiveStatus)
                    .HasColumnName("Device_Active_Status")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceAssignedAccountNumber).HasColumnName("Device_Assigned_Account_Number");

                entity.Property(e => e.DeviceBackupSubscription)
                    .HasColumnName("Device_Backup_Subscription")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceBackupSubscriptionAmount)
                    .HasColumnName("Device_Backup_Subscription_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.DeviceBandWidthSubscription)
                    .HasColumnName("Device_BandWidth_Subscription")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceBillingUnit).HasColumnName("Device_Billing_Unit");

                entity.Property(e => e.DeviceBounceBackup).HasColumnName("Device_Bounce_Backup");

                entity.Property(e => e.DeviceCaption)
                    .HasColumnName("Device_Caption")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.DeviceCmrr)
                    .HasColumnName("Device_CMRR")
                    .HasColumnType("money");

                entity.Property(e => e.DeviceConfigBuiltBy)
                    .HasColumnName("Device_Config_Built_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceContractEndDate)
                    .HasColumnName("Device_Contract_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceContractReceivedDate)
                    .HasColumnName("Device_Contract_Received_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceContractTerm)
                    .HasColumnName("Device_Contract_Term")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DeviceCreateDate)
                    .HasColumnName("Device_Create_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceDatacenterAbbr)
                    .HasColumnName("Device_Datacenter_Abbr")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.DeviceEmerInstrExists).HasColumnName("Device_Emer_Instr_Exists");

                entity.Property(e => e.DeviceEmerInstrUpdatedDate)
                    .HasColumnName("Device_Emer_Instr_Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceFinishedOrderDate)
                    .HasColumnName("Device_Finished_Order_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceHostName)
                    .HasColumnName("Device_Host_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DeviceLastContractRenewalDate)
                    .HasColumnName("Device_Last_Contract_Renewal_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceLastModifiedDate)
                    .HasColumnName("Device_Last_Modified_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceMake)
                    .HasColumnName("Device_Make")
                    .HasColumnType("varchar(254)");

                entity.Property(e => e.DeviceMakeModel)
                    .HasColumnName("Device_Make_Model")
                    .HasColumnType("varchar(254)");

                entity.Property(e => e.DeviceManufacturer)
                    .HasColumnName("Device_Manufacturer")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceMbuSiteId)
                    .HasColumnName("Device_MBU_Site_ID")
                    .HasMaxLength(255);

                entity.Property(e => e.DeviceModel)
                    .HasColumnName("Device_Model")
                    .HasColumnType("varchar(254)");

                entity.Property(e => e.DeviceMonthlyFee)
                    .HasColumnName("Device_Monthly_Fee")
                    .HasColumnType("money");

                entity.Property(e => e.DeviceNumber).HasColumnName("Device_Number");

                entity.Property(e => e.DeviceOfflineDate)
                    .HasColumnName("Device_Offline_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceOfflineReason)
                    .HasColumnName("Device_Offline_Reason")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceOnlineDate)
                    .HasColumnName("Device_Online_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceOnlineStatus)
                    .HasColumnName("Device_Online_Status")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceOs)
                    .HasColumnName("Device_OS")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DeviceOsName)
                    .HasColumnName("Device_OS_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceOsVersion)
                    .HasColumnName("Device_OS_Version")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.DevicePlacedOrderDate)
                    .HasColumnName("Device_Placed_Order_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceRackwatchSla)
                    .HasColumnName("Device_Rackwatch_SLA")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.DeviceRaidType)
                    .HasColumnName("Device_Raid_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceRecordEffectiveEndDatetime)
                    .HasColumnName("Device_Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceRecordEffectiveStartDatetime)
                    .HasColumnName("Device_Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceSalesRep1)
                    .HasColumnName("Device_Sales_Rep_1")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceSalesRep2)
                    .HasColumnName("Device_Sales_Rep_2")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceSetupFee)
                    .HasColumnName("Device_Setup_Fee")
                    .HasColumnType("money");

                entity.Property(e => e.DeviceStatus)
                    .HasColumnName("Device_Status")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.DeviceStatusNumber).HasColumnName("Device_Status_Number");

                entity.Property(e => e.DeviceTenureDays).HasColumnName("Device_Tenure_Days");

                entity.Property(e => e.DeviceType)
                    .HasColumnName("Device_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceTypeIcon)
                    .HasColumnName("Device_Type_Icon")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceUsageType)
                    .HasColumnName("device_usage_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DueToCustomerDate)
                    .HasColumnName("Due_to_Customer_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DueToSupportDate)
                    .HasColumnName("Due_to_Support_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("Rec_Updated")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimDeviceCapEx>(entity =>
            {
                entity.HasKey(e => e.DimDeviceCapExKey)
                    .HasName("PK_DIM_DEVICE_CAPEX");

                entity.ToTable("Dim_Device_CapEx");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IDX_Device_Key");

                entity.HasIndex(e => e.YearMonthKey)
                    .HasName("IDX_Year_Month_Key");

                entity.Property(e => e.DimDeviceCapExKey).HasColumnName("Dim_Device_CapEx_key");

                entity.Property(e => e.AccumulatedDepreciation)
                    .HasColumnName("Accumulated_Depreciation")
                    .HasColumnType("decimal");

                entity.Property(e => e.AcquisitionCost)
                    .HasColumnName("Acquisition_Cost")
                    .HasColumnType("decimal");

                entity.Property(e => e.AcquisitionCostUsd)
                    .HasColumnName("Acquisition_cost_usd")
                    .HasColumnType("decimal");

                entity.Property(e => e.AdjustedCost)
                    .HasColumnName("Adjusted_Cost")
                    .HasColumnType("decimal");

                entity.Property(e => e.AssetId).HasColumnName("Asset_ID");

                entity.Property(e => e.CurrencyCode)
                    .HasColumnName("Currency_Code")
                    .HasMaxLength(15);

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.DatePlacedInService)
                    .HasColumnName("Date_placed_in_Service")
                    .HasColumnType("date");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.DeviceNumber)
                    .HasColumnName("Device_Number")
                    .HasMaxLength(40);

                entity.Property(e => e.FaLocation1)
                    .HasColumnName("Fa_Location1")
                    .HasMaxLength(30);

                entity.Property(e => e.FaLocation2)
                    .HasColumnName("Fa_Location2")
                    .HasMaxLength(30);

                entity.Property(e => e.LifeInMonths).HasColumnName("Life_in_Months");

                entity.Property(e => e.MonthDepreciation)
                    .HasColumnName("Month_Depreciation")
                    .HasColumnType("decimal");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnName("Purchase_Date")
                    .HasColumnType("date");

                entity.Property(e => e.RecordCreateby)
                    .IsRequired()
                    .HasColumnName("RECORD_CREATEBY")
                    .HasMaxLength(64);

                entity.Property(e => e.RecordCreatedtt)
                    .HasColumnName("RECORD_CREATEDTT")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDate)
                    .HasColumnName("Record_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDate)
                    .HasColumnName("Record_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedby)
                    .IsRequired()
                    .HasColumnName("RECORD_UPDATEDBY")
                    .HasMaxLength(64);

                entity.Property(e => e.RecordUpdatedtt)
                    .HasColumnName("RECORD_UPDATEDTT")
                    .HasColumnType("datetime");

                entity.Property(e => e.YearMonthKey).HasColumnName("Year_Month_Key");
            });

            modelBuilder.Entity<DimDeviceTenureGroup>(entity =>
            {
                entity.HasKey(e => e.DeviceTenureGroupKey)
                    .HasName("PK_Dim_Device_Tenure_Group");

                entity.ToTable("dim_device_tenure_group");

                entity.Property(e => e.DeviceTenureGroupKey).HasColumnName("Device_Tenure_Group_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.DeviceTenureBeginDay).HasColumnName("Device_Tenure_Begin_Day");

                entity.Property(e => e.DeviceTenureDescription)
                    .HasColumnName("Device_Tenure_Description")
                    .HasMaxLength(50);

                entity.Property(e => e.DeviceTenureEndDay).HasColumnName("Device_Tenure_End_Day");

                entity.Property(e => e.DeviceTenureGroupNk)
                    .HasColumnName("Device_Tenure_Group_NK")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDatetime)
                    .HasColumnName("Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDatetime)
                    .HasColumnName("Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimDlContainer>(entity =>
            {
                entity.HasKey(e => e.ContainerKey)
                    .HasName("PK_dim_container");

                entity.ToTable("Dim_DL_Container");

                entity.HasIndex(e => e.ContainerAccountNumber)
                    .HasName("idx_container_account_number");

                entity.HasIndex(e => e.ContainerColumns)
                    .HasName("idx_container_columns");

                entity.HasIndex(e => e.ContainerDatacenterAbbr)
                    .HasName("idx_container_datacenter_abbr");

                entity.HasIndex(e => e.ContainerKind)
                    .HasName("idx_container_kind");

                entity.HasIndex(e => e.ContainerLabel)
                    .HasName("idx_container_label");

                entity.HasIndex(e => e.ContainerNumber)
                    .HasName("idx_container_number");

                entity.HasIndex(e => e.ContainerNumberOfSpaces)
                    .HasName("idx_container_number_of_spaces");

                entity.HasIndex(e => e.ContainerRow)
                    .HasName("idx_row");

                entity.HasIndex(e => e.ContainerSection)
                    .HasName("idx_container_section");

                entity.HasIndex(e => new { e.ContainerIdNk, e.CurrentRecord })
                    .HasName("idx_container_id_nk");

                entity.Property(e => e.ContainerKey).HasColumnName("Container_key");

                entity.Property(e => e.AccountSourceSystemName)
                    .HasColumnName("Account_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContainerAccountNumber)
                    .HasColumnName("Container_account_number")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ContainerColumns)
                    .HasColumnName("Container_columns")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ContainerDatacenterAbbr)
                    .HasColumnName("Container_datacenter_abbr")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ContainerDescription)
                    .HasColumnName("Container_description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerIdNk)
                    .HasColumnName("Container_ID_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContainerKind)
                    .HasColumnName("Container_kind")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ContainerLabel)
                    .HasColumnName("Container_label")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerNumber)
                    .HasColumnName("Container_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerNumberOfSpaces)
                    .HasColumnName("Container_number_of_spaces")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ContainerRow)
                    .HasColumnName("Container_row")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.ContainerSection)
                    .HasColumnName("Container_section")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordSourceSystem)
                    .IsRequired()
                    .HasColumnName("Record_Source_System")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUdpatedDatetime)
                    .HasColumnName("Record_udpated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_by")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimDlContainerComponent>(entity =>
            {
                entity.HasKey(e => e.ContainerComponentKey)
                    .HasName("PK_Container_Component");

                entity.ToTable("dim_dl_container_component");

                entity.HasIndex(e => new { e.ContainerComponentSsk, e.CurrentRecord })
                    .HasName("IDX_NK_Container_Component");

                entity.HasIndex(e => new { e.ContainerComponentDeviceIdNk, e.ContainerComponentConfigurationIdNk, e.RecordSource, e.CurrentRecord })
                    .HasName("IX_Dim_DL_Container_Component_NKMI");

                entity.Property(e => e.ContainerComponentKey).HasColumnName("Container_Component_Key");

                entity.Property(e => e.ContainerComponentAccountNumber)
                    .HasColumnName("Container_Component_Account_Number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerComponentAccountSourceSystemName)
                    .HasColumnName("Container_Component_Account_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContainerComponentConfigurationCaseSensitive).HasColumnName("Container_Component_Configuration_Case_Sensitive");

                entity.Property(e => e.ContainerComponentConfigurationDatacenterAbbr)
                    .HasColumnName("Container_Component_Configuration_Datacenter_Abbr")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerComponentConfigurationIdNk).HasColumnName("Container_Component_Configuration_id_Nk");

                entity.Property(e => e.ContainerComponentConfigurationNumber)
                    .HasColumnName("Container_Component_Configuration_Number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerComponentConfigurationRegexForSku).HasColumnName("Container_Component_Configuration_Regex_for_Sku");

                entity.Property(e => e.ContainerComponentConfigurationTypeCanBeUndermount).HasColumnName("Container_Component_Configuration_Type_Can_be_Undermount");

                entity.Property(e => e.ContainerComponentConfigurationTypeCanBeVertical).HasColumnName("Container_Component_Configuration_Type_Can_be_Vertical");

                entity.Property(e => e.ContainerComponentConfigurationTypeName)
                    .HasColumnName("Container_Component_Configuration_Type_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerComponentConfigurationTypeNumPerWidth).HasColumnName("Container_Component_Configuration_Type_Num_Per_width");

                entity.Property(e => e.ContainerComponentConfigurationTypePrecedence).HasColumnName("Container_Component_Configuration_Type_Precedence");

                entity.Property(e => e.ContainerComponentConfigurationTypeRegex)
                    .HasColumnName("Container_Component_Configuration_Type_Regex")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerComponentConfigurationTypeUHeight).HasColumnName("Container_Component_Configuration_Type_U_height");

                entity.Property(e => e.ContainerComponentDeviceIdNk).HasColumnName("Container_Component_Device_id_Nk");

                entity.Property(e => e.ContainerComponentIsUnowned).HasColumnName("Container_Component_is_Unowned");

                entity.Property(e => e.ContainerComponentName)
                    .HasColumnName("Container_Component_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerComponentNumber)
                    .HasColumnName("Container_Component_Number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContainerComponentPendingDeletionDatetime)
                    .HasColumnName("Container_Component_Pending_Deletion_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContainerComponentSsk)
                    .HasColumnName("Container_Component_Ssk")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContainerComponentStartingSpace).HasColumnName("Container_Component_Starting_Space");

                entity.Property(e => e.ContainerComponentUndermountSpace).HasColumnName("Container_Component_Undermount_Space");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordSource)
                    .HasColumnName("Record_Source")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimDlErwinShelf>(entity =>
            {
                entity.HasKey(e => e.ErwinShelfKey)
                    .HasName("PK_Dim_DL_Erwin_Shelf");

                entity.ToTable("dim_dl_erwin_shelf");

                entity.HasIndex(e => new { e.ErwinShelfIdNk, e.CurrentRecord })
                    .HasName("IDX_Shelf_NK");

                entity.Property(e => e.ErwinShelfKey).HasColumnName("Erwin_Shelf_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_record");

                entity.Property(e => e.ErwinShelfContainerId).HasColumnName("Erwin_Shelf_Container_ID");

                entity.Property(e => e.ErwinShelfIdNk)
                    .HasColumnName("Erwin_Shelf_ID_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ErwinShelfNumPerWidth).HasColumnName("Erwin_Shelf_Num_Per_Width");

                entity.Property(e => e.ErwinShelfNumberOfSpaces).HasColumnName("Erwin_Shelf_Number_of_Spaces");

                entity.Property(e => e.ErwinShelfStartingSpace).HasColumnName("Erwin_Shelf_Starting_Space");

                entity.Property(e => e.ErwinShelfUHeight).HasColumnName("Erwin_Shelf_U_Height");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDatetime)
                    .HasColumnName("Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDatetime)
                    .HasColumnName("Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordSourceSystem)
                    .IsRequired()
                    .HasColumnName("Record_Source_System")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecordUdpatedDatetime)
                    .HasColumnName("Record_udpated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_by")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimDlReservation>(entity =>
            {
                entity.HasKey(e => e.ReservationKey)
                    .HasName("PK_Dim_DL_Reservation");

                entity.ToTable("dim_dl_reservation");

                entity.HasIndex(e => e.ReservationAccountNumber)
                    .HasName("idx_reservation_account_number");

                entity.HasIndex(e => e.ReservationNumber)
                    .HasName("idx_reservation_number");

                entity.HasIndex(e => new { e.ReservationIdNk, e.CurrentRecord })
                    .HasName("IDX_NK_Reservation");

                entity.Property(e => e.ReservationKey).HasColumnName("Reservation_Key");

                entity.Property(e => e.AccountSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Account_Source_System_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_record");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDatetime)
                    .HasColumnName("Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDatetime)
                    .HasColumnName("Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordSourceSystem)
                    .IsRequired()
                    .HasColumnName("Record_Source_System")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecordUdpatedDatetime)
                    .HasColumnName("Record_udpated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_by")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ReservationAccountNumber)
                    .HasColumnName("Reservation_Account_Number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ReservationComment)
                    .HasColumnName("Reservation_Comment")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ReservationContainerId).HasColumnName("Reservation_Container_ID");

                entity.Property(e => e.ReservationDeviceId).HasColumnName("Reservation_Device_ID");

                entity.Property(e => e.ReservationErwinShelfId).HasColumnName("Reservation_Erwin_Shelf_ID");

                entity.Property(e => e.ReservationIdNk)
                    .HasColumnName("Reservation_ID_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ReservationName)
                    .HasColumnName("Reservation_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ReservationNumPerWidth).HasColumnName("Reservation_Num_Per_Width");

                entity.Property(e => e.ReservationNumber)
                    .HasColumnName("Reservation_Number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ReservationStartingSpace).HasColumnName("Reservation_Starting_Space");

                entity.Property(e => e.ReservationUHeight).HasColumnName("Reservation_U_Height");

                entity.Property(e => e.ReservationUndermountSpace).HasColumnName("Reservation_Undermount_Space");
            });

            modelBuilder.Entity<DimDlSwitch>(entity =>
            {
                entity.HasKey(e => e.SwitchKey)
                    .HasName("PK_switch");

                entity.ToTable("dim_dl_switch");

                entity.HasIndex(e => new { e.SwitchSsk, e.CurrentRecord })
                    .HasName("IDX_Swithc_NK");

                entity.Property(e => e.SwitchKey).HasColumnName("switch_key");

                entity.Property(e => e.CurrentRecord).HasColumnName("current_record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("record_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordSource)
                    .HasColumnName("record_source")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("record_updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SwitchConfigurationNumber)
                    .HasColumnName("switch_configuration_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SwitchDataCenterAbbr)
                    .HasColumnName("switch_data_center_abbr")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SwitchIdNk).HasColumnName("switch_id_nk");

                entity.Property(e => e.SwitchIpAddress).HasColumnName("switch_ip_address");

                entity.Property(e => e.SwitchName)
                    .HasColumnName("switch_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SwitchNumber)
                    .HasColumnName("switch_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SwitchPollable).HasColumnName("switch_pollable");

                entity.Property(e => e.SwitchSsk)
                    .HasColumnName("switch_ssk")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SwitchStartingSpace).HasColumnName("switch_starting_space");

                entity.Property(e => e.SwitchTypeIdNk).HasColumnName("switch_type_id_nk");

                entity.Property(e => e.SwitchTypeName)
                    .HasColumnName("switch_type_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SwitchTypeNumPerWidth).HasColumnName("switch_type_num_per_width");

                entity.Property(e => e.SwitchTypeNumberOfPorts).HasColumnName("switch_type_number_of_ports");

                entity.Property(e => e.SwitchTypeUHeight).HasColumnName("switch_type_u_height");
            });

            modelBuilder.Entity<DimDlSwitchPort>(entity =>
            {
                entity.HasKey(e => e.SwitchPortKey)
                    .HasName("PK_Dim_DL_Switch_Port");

                entity.ToTable("dim_dl_switch_port");

                entity.HasIndex(e => new { e.SwitchPortSsk, e.CurrentRecord })
                    .HasName("IDX_Switch_Port_SSK");

                entity.Property(e => e.SwitchPortKey).HasColumnName("switch_Port_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_record");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDatetime)
                    .HasColumnName("Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDatetime)
                    .HasColumnName("Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordSourceSystem)
                    .IsRequired()
                    .HasColumnName("Record_Source_System")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecordUdpatedDatetime)
                    .HasColumnName("Record_Udpated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_by")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SwitchPortInterfaceTypeBandwidthMonitorOrder).HasColumnName("Switch_Port_Interface_Type_Bandwidth_Monitor_Order");

                entity.Property(e => e.SwitchPortInterfaceTypeDescription)
                    .HasColumnName("switch_Port_Interface_Type_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SwitchPortInterfaceTypeName)
                    .HasColumnName("Switch_Port_Interface_Type_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SwitchPortNumber).HasColumnName("Switch_Port_Number");

                entity.Property(e => e.SwitchPortSsk)
                    .HasColumnName("Switch_Port_SSK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SwitchPortUsable).HasColumnName("Switch_Port_Usable");
            });

            modelBuilder.Entity<DimEmployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey)
                    .HasName("PK_Dim_Employee123");

                entity.ToTable("Dim_Employee");

                entity.HasIndex(e => e.EmployeeNumber)
                    .HasName("IX_Dim_Employee_EN2MI");

                entity.HasIndex(e => new { e.EmployeeContactId, e.CurrentRecord })
                    .HasName("idx_employee_id");

                entity.HasIndex(e => new { e.EmployeeNumber, e.CurrentRecord })
                    .HasName("IX_Dim_Employee_EN1CRMI");

                entity.Property(e => e.EmployeeKey).HasColumnName("Employee_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeCity)
                    .HasColumnName("Employee_City")
                    .HasMaxLength(255);

                entity.Property(e => e.EmployeeContactId).HasColumnName("Employee_Contact_ID");

                entity.Property(e => e.EmployeeContactRole)
                    .HasColumnName("Employee_Contact_Role")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmployeeCountry)
                    .HasColumnName("Employee_Country")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmployeeCountryAbbrv)
                    .HasColumnName("Employee_Country_Abbrv")
                    .HasMaxLength(8);

                entity.Property(e => e.EmployeeCountryCode)
                    .HasColumnName("Employee_Country_Code")
                    .HasColumnType("nchar(3)");

                entity.Property(e => e.EmployeeCreated)
                    .HasColumnName("Employee_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeFirstName)
                    .HasColumnName("Employee_First_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeLastName)
                    .HasColumnName("Employee_Last_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeNumber).HasColumnName("Employee_Number");

                entity.Property(e => e.EmployeePostalCode)
                    .HasColumnName("Employee_Postal_Code")
                    .HasMaxLength(10);

                entity.Property(e => e.EmployeePrimaryEmail)
                    .HasColumnName("Employee_Primary_Email")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EmployeePrimaryPhone)
                    .HasColumnName("Employee_Primary_Phone")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EmployeeSso)
                    .HasColumnName("Employee_Sso")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EmployeeState)
                    .HasColumnName("Employee_State")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.EmployeeStreet)
                    .HasColumnName("Employee_Street")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmployeeTitle)
                    .HasColumnName("Employee_Title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("Rec_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimEventDetails>(entity =>
            {
                entity.HasKey(e => e.EventKey)
                    .HasName("PK_DIM_EVENT");

                entity.ToTable("Dim_Event_Details");

                entity.Property(e => e.EventKey)
                    .HasColumnName("EVENT_KEY")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventDcId)
                    .HasColumnName("EVENT_DC_ID")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventEarnedType)
                    .HasColumnName("EVENT_EARNED_TYPE")
                    .HasColumnType("numeric");

                entity.Property(e => e.EventFlags)
                    .HasColumnName("EVENT_FLAGS")
                    .HasColumnType("numeric");

                entity.Property(e => e.EventGroupType)
                    .HasColumnName("EVENT_GROUP_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventManagedFlag)
                    .HasColumnName("EVENT_MANAGED_FLAG")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventName)
                    .HasColumnName("EVENT_NAME")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventProductType)
                    .HasColumnName("EVENT_PRODUCT_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventRegionId)
                    .HasColumnName("EVENT_REGION_ID")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventRumName)
                    .HasColumnName("EVENT_RUM_NAME")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventSsk)
                    .IsRequired()
                    .HasColumnName("EVENT_SSK")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventSysDescr)
                    .HasColumnName("EVENT_SYS_DESCR")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasColumnName("EVENT_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImpactBalGrpType)
                    .HasColumnName("IMPACT_BAL_GRP_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImpactCategory)
                    .HasColumnName("IMPACT_CATEGORY")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImpactCurrencyAbbrev)
                    .HasColumnName("IMPACT_CURRENCY_ABBREV")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImpactCurrencyId)
                    .HasColumnName("IMPACT_CURRENCY_ID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ImpactOfferingType)
                    .HasColumnName("IMPACT_OFFERING_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImpactRateTag)
                    .HasColumnName("IMPACT_RATE_TAG")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImpactRumId)
                    .HasColumnName("IMPACT_RUM_ID")
                    .HasColumnType("numeric");

                entity.Property(e => e.ImpactTaxCode)
                    .HasColumnName("IMPACT_TAX_CODE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ImpactType)
                    .HasColumnName("IMPACT_TYPE")
                    .HasColumnType("numeric");

                entity.Property(e => e.ItemType)
                    .HasColumnName("ITEM_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecCreatedDate)
                    .HasColumnName("REC_CREATED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.RumMapRecId)
                    .HasColumnName("RUM_MAP_REC_ID")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ServiceType)
                    .HasColumnName("SERVICE_TYPE")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("SOURCE_SYSTEM_NAME")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TaxElementId)
                    .HasColumnName("TAX_ELEMENT_ID")
                    .HasColumnType("numeric");

                entity.Property(e => e.TaxName)
                    .HasColumnName("TAX_NAME")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TaxRatePercent).HasColumnName("TAX_RATE_PERCENT");

                entity.Property(e => e.TaxTypeId)
                    .HasColumnName("TAX_TYPE_ID")
                    .HasColumnType("numeric");
            });

            modelBuilder.Entity<DimGeography>(entity =>
            {
                entity.HasKey(e => e.GeographyKey)
                    .HasName("PK__dim_geog__FD9AECBF5255D497");

                entity.ToTable("dim_geography");

                entity.Property(e => e.GeographyKey)
                    .HasColumnName("geography_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.GeographyCity)
                    .HasColumnName("geography_city")
                    .HasMaxLength(255);

                entity.Property(e => e.GeographyCountry)
                    .HasColumnName("geography_country")
                    .HasMaxLength(255);

                entity.Property(e => e.GeographyCreatedBy)
                    .HasColumnName("geography_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.GeographyCreatedDatetime)
                    .HasColumnName("geography_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GeographyRegion)
                    .HasColumnName("geography_region")
                    .HasMaxLength(255);

                entity.Property(e => e.GeographySourceSystemIdColumn)
                    .HasColumnName("geography_source_system_id_column")
                    .HasMaxLength(100);

                entity.Property(e => e.GeographySourceSystemIdNk)
                    .IsRequired()
                    .HasColumnName("geography_source_system_id_nk")
                    .HasMaxLength(255);

                entity.Property(e => e.GeographySourceSystemName)
                    .HasColumnName("geography_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.GeographyUpdatedBy)
                    .HasColumnName("geography_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.GeographyUpdatedDatetime)
                    .HasColumnName("geography_updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GeographyZip)
                    .HasColumnName("geography_zip")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DimHourMinSec>(entity =>
            {
                entity.HasKey(e => e.HmsKey)
                    .HasName("PK_Dim_Hour_Min_Sec");

                entity.ToTable("dim_hour_min_sec");

                entity.HasIndex(e => e.HmsTime)
                    .HasName("NCI_HMS_Time");

                entity.HasIndex(e => new { e.HmsMilitaryHourNumber, e.HmsMinuteNumber, e.HmsSecondNumber })
                    .HasName("NCI_HHMMSS")
                    .IsUnique();

                entity.HasIndex(e => new { e.HmsStandardHourNumber, e.HmsMinuteNumber, e.HmsSecondNumber, e.HmsStandard })
                    .HasName("NCI_HMS_Standard");

                entity.Property(e => e.HmsKey)
                    .HasColumnName("HMS_KEY")
                    .ValueGeneratedNever();

                entity.Property(e => e.HmsMilitaryHourNumber)
                    .IsRequired()
                    .HasColumnName("HMS_Military_Hour_Number");

                entity.Property(e => e.HmsMinuteNumber)
                    .IsRequired()
                    .HasColumnName("HMS_Minute_Number");

                entity.Property(e => e.HmsSecondNumber)
                    .IsRequired()
                    .HasColumnName("HMS_Second_Number");

                entity.Property(e => e.HmsShiftNumber).HasColumnName("HMS_Shift_Number");

                entity.Property(e => e.HmsStandard)
                    .HasColumnName("HMS_Standard")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.HmsStandardHourNumber).HasColumnName("HMS_Standard_Hour_Number");

                entity.Property(e => e.HmsTime)
                    .HasColumnName("HMS_Time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimIncident>(entity =>
            {
                entity.HasKey(e => e.IncidentKey)
                    .HasName("PK_Dim_Incident");

                entity.ToTable("dim_incident");

                entity.HasIndex(e => e.IncidentCreatedMethod)
                    .HasName("ix_dim_incident_created_method");

                entity.HasIndex(e => e.IncidentCurrentRecordFlag)
                    .HasName("ix_dim_incident_current_record");

                entity.HasIndex(e => e.IncidentIdNk)
                    .HasName("ix_dim_incident_nk");

                entity.HasIndex(e => e.IncidentPrivateFlag)
                    .HasName("ix_dim_incident_private_flag");

                entity.HasIndex(e => e.IncidentReferenceNumber)
                    .HasName("ix_dim_incident_reference_number");

                entity.HasIndex(e => e.IncidentSosFlag)
                    .HasName("ix_dim_incident_sos_flag");

                entity.HasIndex(e => e.IncidentSourceSystemName)
                    .HasName("ix_Incident_Source_System_Name");

                entity.HasIndex(e => new { e.IncidentIdNk, e.IncidentEffectiveStartDatetime })
                    .HasName("IDX1");

                entity.HasIndex(e => new { e.IncidentIdNk, e.IncidentSourceSystemName })
                    .HasName("IDX01_Dim_Incident");

                entity.HasIndex(e => new { e.IncidentIdNk, e.IncidentCreatedMethod, e.IncidentCurrentRecordFlag })
                    .HasName("IDX_DimIncident");

                entity.HasIndex(e => new { e.IncidentIdNk, e.IncidentEffectiveStartDatetime, e.IncidentEffectiveEndDatetime })
                    .HasName("IDX02_Dim_Incident");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_KEY");

                entity.Property(e => e.IncidentCreatedMethod)
                    .IsRequired()
                    .HasColumnName("Incident_Created_Method")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentCreatorName)
                    .HasColumnName("Incident_Creator_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentCurrentRecordFlag).HasColumnName("Incident_Current_Record_Flag");

                entity.Property(e => e.IncidentEffectiveEndDatetime)
                    .HasColumnName("Incident_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentEffectiveStartDatetime)
                    .HasColumnName("Incident_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentEotr).HasColumnName("Incident_EOTR");

                entity.Property(e => e.IncidentIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentPrivateFlag).HasColumnName("Incident_Private_Flag");

                entity.Property(e => e.IncidentRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentRecordCreatedDatetime)
                    .HasColumnName("Incident_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentRecordUdatedDatetime)
                    .HasColumnName("Incident_Record_Udated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentReferenceNumber)
                    .IsRequired()
                    .HasColumnName("Incident_Reference_Number")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSosFlag).HasColumnName("Incident_SOS_Flag");

                entity.Property(e => e.IncidentSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Source_System_Name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentSubject)
                    .IsRequired()
                    .HasColumnName("Incident_Subject")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentSubmitterName)
                    .HasColumnName("Incident_Submitter_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimIncidentCategory>(entity =>
            {
                entity.HasKey(e => e.IncidentCategoryKey)
                    .HasName("PK_Dim_Incident_Category");

                entity.ToTable("Dim_Incident_Category");

                entity.HasIndex(e => e.IncidentCategoryCurrentRecordFlag)
                    .HasName("ix_dim_incident_Category_current_record");

                entity.HasIndex(e => e.IncidentCategoryIdNk)
                    .HasName("ix_dim_incident_Category_nk");

                entity.HasIndex(e => e.IncidentCategorySourceSystemName)
                    .HasName("ix_dim_incident_Category_source_system");

                entity.HasIndex(e => new { e.IncidentCategoryEffectiveStartDatetime, e.IncidentCategoryEffectiveEndDatetime })
                    .HasName("ix_dim_incident_Category_eff_startdatetime_eff_enddatetime");

                entity.Property(e => e.IncidentCategoryKey).HasColumnName("Incident_Category_Key");

                entity.Property(e => e.IncidentCategoryCurrentRecordFlag).HasColumnName("Incident_Category_Current_Record_Flag");

                entity.Property(e => e.IncidentCategoryDescription)
                    .IsRequired()
                    .HasColumnName("Incident_Category_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentCategoryEffectiveEndDatetime)
                    .HasColumnName("Incident_Category_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentCategoryEffectiveStartDatetime)
                    .HasColumnName("Incident_Category_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentCategoryIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_Category_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentCategoryName)
                    .IsRequired()
                    .HasColumnName("Incident_Category_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentCategoryRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Category_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentCategoryRecordCreatedDatetime)
                    .HasColumnName("Incident_Category_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentCategoryRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Category_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentCategoryRecordUpdatedDatetime)
                    .HasColumnName("Incident_Category_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentCategorySourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Category_Source_System_Name")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<DimIncidentMessageType>(entity =>
            {
                entity.HasKey(e => e.IncidentMessageTypeKey)
                    .HasName("PK_Dim_Incident_Message_Type");

                entity.ToTable("dim_incident_message_type");

                entity.Property(e => e.IncidentMessageTypeKey).HasColumnName("Incident_Message_Type_KEY");

                entity.Property(e => e.IncidentMessageTypeCurrentRecordFlag).HasColumnName("Incident_Message_Type_Current_Record_Flag");

                entity.Property(e => e.IncidentMessageTypeEffectiveEndDatetime)
                    .HasColumnName("Incident_Message_Type_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentMessageTypeEffectiveStartDatetime)
                    .HasColumnName("Incident_Message_Type_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentMessageTypeIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Type_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentMessageTypeName)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Type_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentMessageTypeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Type_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentMessageTypeRecordCreatedDatetime)
                    .HasColumnName("Incident_Message_Type_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentMessageTypeRecordUdatedDatetime)
                    .HasColumnName("Incident_Message_Type_Record_Udated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentMessageTypeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Type_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentMessageTypeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Type_Source_System_Name")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<DimIncidentSeverity>(entity =>
            {
                entity.HasKey(e => e.IncidentSeverityKey)
                    .HasName("PK_Dim_Incident_Severity");

                entity.ToTable("dim_incident_severity");

                entity.Property(e => e.IncidentSeverityKey).HasColumnName("Incident_Severity_KEY");

                entity.Property(e => e.IncidentSeverityCurrentRecordFlag).HasColumnName("Incident_Severity_Current_Record_Flag");

                entity.Property(e => e.IncidentSeverityDescription)
                    .IsRequired()
                    .HasColumnName("Incident_Severity_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentSeverityEffectiveEndDatetime)
                    .HasColumnName("Incident_Severity_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSeverityEffectiveStartDatetime)
                    .HasColumnName("Incident_Severity_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSeverityName)
                    .IsRequired()
                    .HasColumnName("Incident_Severity_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSeverityNk)
                    .IsRequired()
                    .HasColumnName("Incident_Severity_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSeverityRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Severity_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentSeverityRecordCreatedDatetime)
                    .HasColumnName("Incident_Severity_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSeverityRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Severity_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentSeverityRecordUpdatedDatetime)
                    .HasColumnName("Incident_Severity_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSeveritySourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Severity_Source_System_Name")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<DimIncidentSource>(entity =>
            {
                entity.HasKey(e => e.IncidentSourceKey)
                    .HasName("PK_Dim_Incident_Source");

                entity.ToTable("dim_incident_source");

                entity.HasIndex(e => e.IncidentSourceCurrentRecordFlag)
                    .HasName("ix_dim_incident_source_current_record");

                entity.HasIndex(e => e.IncidentSourceIdNk)
                    .HasName("ix_dim_incident_source_nk");

                entity.HasIndex(e => new { e.IncidentSourceIdNk, e.IncidentSourceCurrentRecordFlag })
                    .HasName("ix_dim_incident_source_nk_source_name");

                entity.Property(e => e.IncidentSourceKey).HasColumnName("Incident_Source_KEY");

                entity.Property(e => e.IncidentSourceCurrentRecordFlag).HasColumnName("Incident_Source_Current_Record_Flag");

                entity.Property(e => e.IncidentSourceDescription)
                    .IsRequired()
                    .HasColumnName("Incident_Source_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentSourceEffectiveEndDatetime)
                    .HasColumnName("Incident_Source_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSourceEffectiveStartDatetime)
                    .HasColumnName("Incident_Source_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSourceIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_Source_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSourceName)
                    .IsRequired()
                    .HasColumnName("Incident_Source_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentSourceRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Source_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentSourceRecordCreatedDatetime)
                    .HasColumnName("Incident_Source_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSourceRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Source_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentSourceRecordUpdatedDatetime)
                    .HasColumnName("Incident_Source_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSourceSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Source_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimIncidentStatus>(entity =>
            {
                entity.HasKey(e => e.IncidentStatusId)
                    .HasName("PK__Dim_Incident_Sta__75F77EB0");

                entity.ToTable("dim_incident_status");

                entity.HasIndex(e => e.IncidentStatusCurrentRecordFlag)
                    .HasName("ix_dim_incident_current_record");

                entity.HasIndex(e => e.IncidentStatusIdNk)
                    .HasName("ix_dim_incident_status_nk");

                entity.HasIndex(e => e.IncidentStatusName)
                    .HasName("IX_incident_status_name");

                entity.HasIndex(e => new { e.IncidentStatusIdNk, e.IncidentStatusSourceSystemName })
                    .HasName("ix_dim_incident_status_nk_source_name");

                entity.HasIndex(e => new { e.IncidentStatusIdNk, e.IncidentStatusName, e.IncidentStatusCurrentRecordFlag })
                    .HasName("IX_Dim_Incident_Status_CRMI");

                entity.Property(e => e.IncidentStatusId).HasColumnName("Incident_Status_ID");

                entity.Property(e => e.IncidentStatusActiveFlag).HasColumnName("Incident_Status_Active_Flag");

                entity.Property(e => e.IncidentStatusCurrentRecordFlag).HasColumnName("Incident_Status_Current_Record_Flag");

                entity.Property(e => e.IncidentStatusDescription)
                    .IsRequired()
                    .HasColumnName("Incident_Status_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentStatusEffectiveEndDatetime)
                    .HasColumnName("Incident_Status_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusEffectiveStartDatetime)
                    .HasColumnName("Incident_Status_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_Status_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentStatusName)
                    .IsRequired()
                    .HasColumnName("Incident_Status_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentStatusQueueName)
                    .IsRequired()
                    .HasColumnName("Incident_Status_Queue_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentStatusRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Status_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentStatusRecordCreatedDatetime)
                    .HasColumnName("Incident_Status_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Status_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentStatusRecordUpdatedDatetime)
                    .HasColumnName("Incident_Status_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Status_Source_System_Name")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<DimIncidentStatustype>(entity =>
            {
                entity.HasKey(e => e.IncidentStatusTypeKey)
                    .HasName("PK_Dim_Incident_StatusType");

                entity.ToTable("dim_incident_statustype");

                entity.Property(e => e.IncidentStatusTypeKey).HasColumnName("Incident_StatusType_KEY");

                entity.Property(e => e.IncidentStatusTypeCurrentRecordFlag).HasColumnName("Incident_StatusType_Current_Record_Flag");

                entity.Property(e => e.IncidentStatusTypeDescription)
                    .IsRequired()
                    .HasColumnName("Incident_StatusType_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentStatusTypeEffectiveEndDatetime)
                    .HasColumnName("Incident_StatusType_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusTypeEffectiveStartDatetime)
                    .HasColumnName("Incident_StatusType_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusTypeIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_StatusType_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentStatusTypeName)
                    .IsRequired()
                    .HasColumnName("Incident_StatusType_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentStatusTypeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_StatusType_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentStatusTypeRecordCreatedDatetime)
                    .HasColumnName("Incident_StatusType_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusTypeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_StatusType_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentStatusTypeRecordUpdatedDatetime)
                    .HasColumnName("Incident_StatusType_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStatusTypeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_StatusType_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimIncidentSubCategory>(entity =>
            {
                entity.HasKey(e => e.IncidentSubCategoryKey)
                    .HasName("PK_Dim_Incident_SubCategory");

                entity.ToTable("Dim_Incident_SubCategory");

                entity.HasIndex(e => e.IncidentCategoryKey)
                    .HasName("ix_dim_incident_subcategory_category_key");

                entity.HasIndex(e => e.IncidentSubCategoryCurrentRecordFlag)
                    .HasName("ix_dim_incident_subcategory_current_record");

                entity.HasIndex(e => e.IncidentSubCategoryIdNk)
                    .HasName("ix_dim_incident_subcategory_nk");

                entity.HasIndex(e => e.IncidentSubCategorySourceSystemName)
                    .HasName("ix_dim_incident_subcategory_source_system");

                entity.HasIndex(e => new { e.IncidentSubCategoryEffectiveStartDatetime, e.IncidentSubCategoryEffectiveEndDatetime })
                    .HasName("ix_dim_incident_subcategory_eff_startdatetime_eff_enddatetime");

                entity.Property(e => e.IncidentSubCategoryKey).HasColumnName("Incident_SubCategory_Key");

                entity.Property(e => e.IncidentCategoryKey).HasColumnName("Incident_Category_Key");

                entity.Property(e => e.IncidentSubCategoryActive).HasColumnName("Incident_SubCategory_Active");

                entity.Property(e => e.IncidentSubCategoryCurrentRecordFlag).HasColumnName("Incident_SubCategory_Current_Record_Flag");

                entity.Property(e => e.IncidentSubCategoryDescription)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentSubCategoryEffectiveEndDatetime)
                    .HasColumnName("Incident_SubCategory_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSubCategoryEffectiveStartDatetime)
                    .HasColumnName("Incident_SubCategory_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSubCategoryIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSubCategoryName)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSubCategoryRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentSubCategoryRecordCreatedDatetime)
                    .HasColumnName("Incident_SubCategory_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSubCategoryRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentSubCategoryRecordUpdatedDatetime)
                    .HasColumnName("Incident_SubCategory_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentSubCategorySourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_Source_System_Name")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<DimIncidentWorktype>(entity =>
            {
                entity.HasKey(e => e.IncidentWorkTypeKey)
                    .HasName("PK_Dim_Incident_WorkType");

                entity.ToTable("dim_incident_worktype");

                entity.HasIndex(e => e.IncidentWorkTypeCurrentRecordFlag)
                    .HasName("ix_dim_incident_worktype_current_record");

                entity.HasIndex(e => new { e.IncidentWorkTypeIdNk, e.IncidentWorkTypeSourceSystemName })
                    .HasName("ix_dim_incident_worktype_nk_source_name");

                entity.Property(e => e.IncidentWorkTypeKey).HasColumnName("Incident_WorkType_KEY");

                entity.Property(e => e.IncidentWorkTypeActive)
                    .IsRequired()
                    .HasColumnName("Incident_WorkType_Active")
                    .HasColumnType("char(1)");

                entity.Property(e => e.IncidentWorkTypeCurrentRecordFlag).HasColumnName("Incident_WorkType_Current_Record_Flag");

                entity.Property(e => e.IncidentWorkTypeDescription)
                    .IsRequired()
                    .HasColumnName("Incident_WorkType_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentWorkTypeEffectiveEndDatetime)
                    .HasColumnName("Incident_WorkType_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentWorkTypeEffectiveStartDatetime)
                    .HasColumnName("Incident_WorkType_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentWorkTypeIdNk)
                    .IsRequired()
                    .HasColumnName("Incident_WorkType_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentWorkTypeName)
                    .IsRequired()
                    .HasColumnName("Incident_WorkType_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentWorkTypeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_WorkType_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentWorkTypeRecordCreatedDatetime)
                    .HasColumnName("Incident_WorkType_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentWorkTypeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_WorkType_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentWorkTypeRecordUpdatedDatetime)
                    .HasColumnName("Incident_WorkType_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentWorkTypeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_WorkType_Source_System_Name")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<DimInstance>(entity =>
            {
                entity.HasKey(e => e.InstanceKey)
                    .HasName("PK__dim_inst__20C3C1D928C03EE6");

                entity.ToTable("dim_instance");

                entity.Property(e => e.InstanceKey)
                    .HasColumnName("instance_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.AssignedAccountNumber)
                    .HasColumnName("assigned_account_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AssignedInstanceNumber)
                    .HasColumnName("assigned_instance_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CurrentRecord)
                    .HasColumnName("current_record")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstanceCreationBy)
                    .HasColumnName("instance_creation_by")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceCreationDate)
                    .HasColumnName("instance_creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.InstanceDatacenter)
                    .HasColumnName("instance_datacenter")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceDescription)
                    .HasColumnName("instance_description")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.InstanceName)
                    .HasColumnName("instance_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceNk)
                    .IsRequired()
                    .HasColumnName("instance_nk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceStatus)
                    .HasColumnName("instance_status")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.InstanceType)
                    .HasColumnName("instance_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.InstanceUpdatedBy)
                    .HasColumnName("instance_updated_by")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceUpdatedDate)
                    .HasColumnName("instance_updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecCreatedDate)
                    .HasColumnName("rec_created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdatedDate)
                    .HasColumnName("rec_updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("source_system_name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimInstanceConfiguration>(entity =>
            {
                entity.HasKey(e => e.InstanceConfigurationKey)
                    .HasName("pk_dim_instance_configuration");

                entity.ToTable("dim_instance_configuration");

                entity.Property(e => e.InstanceConfigurationKey)
                    .HasColumnName("instance_configuration_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.Algorithm)
                    .HasColumnName("algorithm")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BackupFlag)
                    .HasColumnName("backup_flag")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BandwidthAmount)
                    .HasColumnName("bandwidth_amount")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CpuAmount)
                    .HasColumnName("cpu_amount")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CpuCoreAmount)
                    .HasColumnName("cpu_core_amount")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CurrentRecord).HasColumnName("current_record");

                entity.Property(e => e.DbName)
                    .HasColumnName("db_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DbPlatform)
                    .HasColumnName("db_platform")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DbSizeAmount)
                    .HasColumnName("db_size_amount")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DbVersion)
                    .HasColumnName("db_version")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlavorId)
                    .HasColumnName("flavor_id")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FlavorName)
                    .HasColumnName("flavor_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceCategory)
                    .HasColumnName("instance_category")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceConfigurationSsk)
                    .HasColumnName("instance_configuration_ssk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InstanceConfigurationType)
                    .HasColumnName("instance_configuration_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MemoryAmount)
                    .HasColumnName("memory_amount")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Option)
                    .HasColumnName("option")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OsName)
                    .HasColumnName("os_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OsPlatform)
                    .HasColumnName("os_platform")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OsVersion)
                    .HasColumnName("os_version")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PortNumber)
                    .HasColumnName("port_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProtocolName)
                    .HasColumnName("protocol_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProtocolType)
                    .HasColumnName("protocol_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecordCreatedAt)
                    .HasColumnName("record_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("record_created_by")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecordUpdatedAt)
                    .HasColumnName("record_updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("record_updated_by")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StorageAmount)
                    .HasColumnName("storage_amount")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UnitAmount)
                    .HasColumnName("unit_amount")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimIpAddressAutonomousSystems>(entity =>
            {
                entity.HasKey(e => e.IpAddressAutonomousSystemsKey)
                    .HasName("PK_Dim_IP_Address_Autonomous_Systems");

                entity.ToTable("dim_ip_address_autonomous_systems");

                entity.Property(e => e.IpAddressAutonomousSystemsKey).HasColumnName("IP_Address_Autonomous_Systems_Key");

                entity.Property(e => e.IpAddressAutonomousSystemsCurrentRecordFlag).HasColumnName("IP_Address_Autonomous_Systems_Current_Record_Flag");

                entity.Property(e => e.IpAddressAutonomousSystemsDescription)
                    .IsRequired()
                    .HasColumnName("IP_Address_Autonomous_Systems_Description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IpAddressAutonomousSystemsEffectiveEndDatetime)
                    .HasColumnName("IP_Address_Autonomous_Systems_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressAutonomousSystemsEffectiveStartDatetime)
                    .HasColumnName("IP_Address_Autonomous_Systems_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressAutonomousSystemsIdNk)
                    .IsRequired()
                    .HasColumnName("IP_Address_Autonomous_Systems_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressAutonomousSystemsName)
                    .IsRequired()
                    .HasColumnName("IP_Address_Autonomous_Systems_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IpAddressAutonomousSystemsNumber).HasColumnName("IP_Address_Autonomous_Systems_Number");

                entity.Property(e => e.IpAddressAutonomousSystemsRackspaceOwned).HasColumnName("IP_Address_Autonomous_Systems_Rackspace_Owned");

                entity.Property(e => e.IpAddressAutonomousSystemsRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("IP_Address_Autonomous_Systems_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressAutonomousSystemsRecordCreatedDatetime)
                    .HasColumnName("IP_Address_Autonomous_Systems_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressAutonomousSystemsRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("IP_Address_Autonomous_Systems_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressAutonomousSystemsRecordUpdatedDatetime)
                    .HasColumnName("IP_Address_Autonomous_Systems_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressAutonomousSystemsSourceSystemName)
                    .IsRequired()
                    .HasColumnName("IP_Address_Autonomous_Systems_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.NumberOfIpAddresses).HasColumnName("Number_of_IP_Addresses");
            });

            modelBuilder.Entity<DimIpAddressO2o>(entity =>
            {
                entity.HasKey(e => e.IpAddressKey)
                    .HasName("IP_Address_Key_PK1");

                entity.ToTable("dim_ip_address_o2o");

                entity.HasIndex(e => e.IpAddress)
                    .HasName("IX_Dim_IP_Address_IP_Address1");

                entity.HasIndex(e => new { e.CurrentRecordFlag, e.IpAddressNk })
                    .HasName("IX_Dim_IP_Address_Current_Record_Flag1");

                entity.HasIndex(e => new { e.IpAddressNk, e.CurrentRecordFlag })
                    .HasName("IX_Dim_IP_Address_NK1");

                entity.Property(e => e.IpAddressKey).HasColumnName("IP_Address_Key");

                entity.Property(e => e.CurrentRecordFlag).HasColumnName("Current_Record_Flag");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasColumnName("IP_Address")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressIsAssigned).HasColumnName("IP_Address_Is_Assigned");

                entity.Property(e => e.IpAddressIsFailover).HasColumnName("IP_Address_Is_Failover");

                entity.Property(e => e.IpAddressIsPrimary)
                    .HasColumnName("IP_Address_Is_Primary")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressNk)
                    .IsRequired()
                    .HasColumnName("IP_Address_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressPublicPrivate)
                    .HasColumnName("IP_Address_Public_Private")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressSourceSystemName)
                    .IsRequired()
                    .HasColumnName("IP_Address_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimIpAddressUsages>(entity =>
            {
                entity.HasKey(e => e.IpAddressUsagesKey)
                    .HasName("PK_Dim_IP_Address_Usages");

                entity.ToTable("dim_ip_address_usages");

                entity.Property(e => e.IpAddressUsagesKey).HasColumnName("IP_Address_Usages_Key");

                entity.Property(e => e.IpAddressUsagesCurrentRecordFlag).HasColumnName("IP_Address_Usages_Current_Record_Flag");

                entity.Property(e => e.IpAddressUsagesDescription)
                    .IsRequired()
                    .HasColumnName("IP_Address_Usages_Description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IpAddressUsagesEffectiveEndDatetime)
                    .HasColumnName("IP_Address_Usages_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressUsagesEffectiveStartDatetime)
                    .HasColumnName("IP_Address_Usages_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressUsagesIdNk)
                    .IsRequired()
                    .HasColumnName("IP_Address_Usages_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressUsagesName)
                    .IsRequired()
                    .HasColumnName("IP_Address_Usages_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressUsagesRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("IP_Address_Usages_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressUsagesRecordCreatedDatetime)
                    .HasColumnName("IP_Address_Usages_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressUsagesRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("IP_Address_Usages_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpAddressUsagesRecordUpdatedDatetime)
                    .HasColumnName("IP_Address_Usages_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpAddressUsagesSourceSystemName)
                    .IsRequired()
                    .HasColumnName("IP_Address_Usages_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimIpBlock>(entity =>
            {
                entity.HasKey(e => e.IpBlockKey)
                    .HasName("PK_Dim_IP_Block");

                entity.ToTable("dim_ip_block");

                entity.HasIndex(e => new { e.IpBlockAutonomusSystemName, e.IsAutonomusSystem })
                    .HasName("IDX_Autonomous_System");

                entity.Property(e => e.IpBlockKey).HasColumnName("IP_Block_Key");

                entity.Property(e => e.AccountNumber).HasColumnName("account_number");

                entity.Property(e => e.AccountSourceSystemName)
                    .HasColumnName("account_source_system_name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CurrentRecordFlag).HasColumnName("Current_Record_flag");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IpBlockAddress)
                    .HasColumnName("IP_Block_Address")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpBlockAutonomusSystemName)
                    .HasColumnName("IP_Block_Autonomus_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpBlockCidrAddress)
                    .HasColumnName("IP_Block_CIDR_Address")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpBlockCidrMask).HasColumnName("IP_Block_CIDR_Mask");

                entity.Property(e => e.IpBlockNk).HasColumnName("IP_Block_NK");

                entity.Property(e => e.IpBlockPolicy)
                    .HasColumnName("IP_Block_Policy")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IpBlockType)
                    .HasColumnName("IP_Block_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.IsAutonomusSystem).HasColumnName("Is_Autonomus_System");

                entity.Property(e => e.NumberOfIpAddresses).HasColumnName("Number_of_IP_Addresses");

                entity.Property(e => e.ParentId).HasColumnName("Parent_ID");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RootId).HasColumnName("Root_ID");
            });

            modelBuilder.Entity<DimLead>(entity =>
            {
                entity.HasKey(e => e.LeadId)
                    .HasName("PK__Dim_Lead__8C42D74134A6D265");

                entity.ToTable("Dim_Lead");

                entity.HasIndex(e => e.LeadKey)
                    .HasName("Lead_Key_indx");

                entity.HasIndex(e => e.LeadSfId)
                    .HasName("Lead_Sf_Id_indx");

                entity.Property(e => e.LeadId)
                    .HasColumnName("Lead_Id")
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.LeadBucket)
                    .HasColumnName("Lead_Bucket")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.LeadCampaignInterest)
                    .HasColumnName("Lead_Campaign_Interest")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.LeadCity)
                    .HasColumnName("Lead_City")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.LeadCommissionsRole)
                    .HasColumnName("Lead_Commissions_Role")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadCompany)
                    .HasColumnName("Lead_Company")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.LeadConvertedAccountId)
                    .HasColumnName("Lead_Converted_Account_Id")
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.LeadConvertedContactId)
                    .HasColumnName("Lead_Converted_Contact_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadConvertedDate).HasColumnName("Lead_Converted_Date");

                entity.Property(e => e.LeadConvertedDateUtc).HasColumnName("Lead_Converted_Date_UTC");

                entity.Property(e => e.LeadConvertedOpportunityId)
                    .HasColumnName("Lead_Converted_Opportunity_Id")
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.LeadCountry)
                    .HasColumnName("Lead_Country")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadCreatedDate).HasColumnName("Lead_Created_Date");

                entity.Property(e => e.LeadCreatedDateUtc).HasColumnName("Lead_Created_Date_utc");

                entity.Property(e => e.LeadCreatedFromLeadFlag)
                    .HasColumnName("Lead_Created_From_Lead_Flag")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.LeadCurrentCustomerFlag)
                    .HasColumnName("Lead_Current_Customer_Flag")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.LeadCurrentRecord).HasColumnName("Lead_Current_Record");

                entity.Property(e => e.LeadDeletedFlag)
                    .HasColumnName("Lead_Deleted_Flag")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.LeadFinalOpportunityType)
                    .HasColumnName("Lead_Final_Opportunity_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadIsConvertedFlag)
                    .HasColumnName("Lead_Is_Converted_Flag")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.LeadIteamPersona)
                    .HasColumnName("Lead_Iteam_Persona")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.LeadKey).HasColumnName("Lead_Key");

                entity.Property(e => e.LeadLpid)
                    .HasColumnName("Lead_Lpid")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.LeadName)
                    .HasColumnName("Lead_Name")
                    .HasColumnType("varchar(363)");

                entity.Property(e => e.LeadOrigination)
                    .HasColumnName("Lead_Origination")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadPartnerAccountNum)
                    .HasColumnName("Lead_Partner_Account_Num")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadPostalcode)
                    .HasColumnName("Lead_Postalcode")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.LeadRecordCreatedBy)
                    .HasColumnName("Lead_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LeadRecordCreatedDatetime).HasColumnName("Lead_Record_Created_Datetime");

                entity.Property(e => e.LeadRecordUpdatedBy)
                    .HasColumnName("Lead_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LeadRecordUpdatedDatetime).HasColumnName("Lead_Record_Updated_Datetime");

                entity.Property(e => e.LeadReferrerContractType)
                    .HasColumnName("Lead_Referrer_Contract_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadSalesAssociate)
                    .HasColumnName("Lead_Sales_Associate")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadSfId)
                    .IsRequired()
                    .HasColumnName("Lead_Sf_Id")
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.LeadSolutionArea)
                    .HasColumnName("Lead_Solution_Area")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadSolutionAreaWorkload)
                    .HasColumnName("Lead_Solution_Area_Workload")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadSource)
                    .HasColumnName("Lead_Source")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadSourceSystemName)
                    .HasColumnName("Lead_Source_System_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadState)
                    .HasColumnName("Lead_State")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadStreet)
                    .HasColumnName("Lead_Street")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.LeadTerritory)
                    .HasColumnName("Lead_Territory")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadTsrSpecialist)
                    .HasColumnName("Lead_Tsr_Specialist")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadType)
                    .HasColumnName("Lead_Type")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimLeadExtended>(entity =>
            {
                entity.HasKey(e => e.LeadExtendedKey)
                    .HasName("PK__Dim_Lead__79D0C06C38B250AA");

                entity.ToTable("Dim_Lead_Extended");

                entity.Property(e => e.LeadExtendedKey)
                    .HasColumnName("Lead_Extended_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.ChkSumNbr)
                    .HasColumnName("Chk_Sum_Nbr")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.LeadCurrentRecord).HasColumnName("Lead_Current_Record");

                entity.Property(e => e.LeadDatePassed).HasColumnName("Lead_Date_Passed");

                entity.Property(e => e.LeadDatePassedUtc).HasColumnName("Lead_Date_Passed_Utc");

                entity.Property(e => e.LeadEffectiveEndDate).HasColumnName("Lead_Effective_End_Date");

                entity.Property(e => e.LeadEffectiveEndDateUtc).HasColumnName("Lead_Effective_End_Date_Utc");

                entity.Property(e => e.LeadEffectiveStartDate).HasColumnName("Lead_Effective_Start_Date");

                entity.Property(e => e.LeadEffectiveStartDateUtc).HasColumnName("Lead_Effective_Start_Date_Utc");

                entity.Property(e => e.LeadFieldNames)
                    .HasColumnName("Lead_Field_Names")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LeadGeneratorId)
                    .HasColumnName("Lead_Generator_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadGeneratorName)
                    .HasColumnName("Lead_Generator_Name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadGeneratorRoleDesc)
                    .HasColumnName("Lead_Generator_Role_Desc")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadGeneratorRoleId)
                    .HasColumnName("Lead_Generator_Role_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadId)
                    .IsRequired()
                    .HasColumnName("Lead_Id")
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.LeadInsUpdFlg)
                    .HasColumnName("Lead_Ins_Upd_Flg")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.LeadKey).HasColumnName("Lead_Key");

                entity.Property(e => e.LeadOwnerId)
                    .HasColumnName("Lead_Owner_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadOwnerName)
                    .HasColumnName("Lead_Owner_Name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadOwnerRole)
                    .HasColumnName("Lead_Owner_Role")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.LeadOwnerRoleId)
                    .HasColumnName("Lead_Owner_Role_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadPartnerId)
                    .HasColumnName("Lead_Partner_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadPartnerName)
                    .HasColumnName("Lead_Partner_Name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadRecordCreatedBy)
                    .HasColumnName("Lead_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LeadRecordCreatedDatetime).HasColumnName("Lead_Record_Created_Datetime");

                entity.Property(e => e.LeadRecordUpdatedBy)
                    .HasColumnName("Lead_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LeadRecordUpdatedDatetime).HasColumnName("Lead_Record_Updated_Datetime");

                entity.Property(e => e.LeadRepDatePassed).HasColumnName("Lead_Rep_Date_Passed");

                entity.Property(e => e.LeadRepDatePassedUtc).HasColumnName("Lead_Rep_Date_Passed_Utc");

                entity.Property(e => e.LeadRepId)
                    .HasColumnName("Lead_Rep_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadRepName)
                    .HasColumnName("Lead_Rep_Name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadRepRoleDesc)
                    .HasColumnName("Lead_Rep_Role_Desc")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.LeadRepRoleId)
                    .HasColumnName("Lead_Rep_Role_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.LeadSourceSystemName)
                    .HasColumnName("Lead_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LeadStatus)
                    .HasColumnName("Lead_Status")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimLowCostStorageShare>(entity =>
            {
                entity.HasKey(e => e.StorageKey)
                    .HasName("PK_Dim_LowCostStorage_Share");

                entity.ToTable("Dim_LowCostStorage_Share");

                entity.HasIndex(e => e.StorageNk)
                    .HasName("IX_Share_Storage_NK");

                entity.HasIndex(e => e.StoragePath)
                    .HasName("IX_Share_Storage_Path");

                entity.HasIndex(e => e.StorageType)
                    .HasName("IX_Share_Storage_Type");

                entity.Property(e => e.StorageKey).HasColumnName("Storage_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StorageNk)
                    .IsRequired()
                    .HasColumnName("Storage_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StoragePath)
                    .IsRequired()
                    .HasColumnName("Storage_Path")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StorageType)
                    .IsRequired()
                    .HasColumnName("Storage_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimManagedBackupConfig>(entity =>
            {
                entity.HasKey(e => e.MbuConfigKey)
                    .HasName("PK_Dim_Managed_Backup_Config");

                entity.ToTable("Dim_Managed_Backup_Config");

                entity.HasIndex(e => new { e.MbuConfigNk, e.MbuRtntnPeriodNbr })
                    .HasName("IX_MBU_Config_NK");

                entity.Property(e => e.MbuConfigKey).HasColumnName("MBU_Config_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.MbuBackupServerNm)
                    .IsRequired()
                    .HasColumnName("MBU_Backup_Server_NM")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuBackupSet)
                    .HasColumnName("MBU_Backup_SET")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuConfigEffectiveEndDate)
                    .HasColumnName("MBU_Config_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuConfigEffectiveStartDate)
                    .HasColumnName("MBU_Config_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuConfigNk)
                    .HasColumnName("MBU_Config_NK")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.MbuConfigRecordCreatedBy)
                    .HasColumnName("MBU_Config_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuConfigRecordCreatedDatetime)
                    .HasColumnName("MBU_Config_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuConfigRecordUpdatedBy)
                    .HasColumnName("MBU_Config_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuConfigRecordUpdatedDatetime)
                    .HasColumnName("MBU_Config_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuConfigSrcSysTxt)
                    .IsRequired()
                    .HasColumnName("MBU_Config_SrcSys_TXT")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuCopyName)
                    .HasColumnName("MBU_Copy_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuDataAgent)
                    .HasColumnName("MBU_Data_Agent")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuDatabaseInstance)
                    .HasColumnName("MBU_Database_Instance")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuDaysRetainedNbr).HasColumnName("MBU_Days_Retained_NBR");

                entity.Property(e => e.MbuExclusionLst)
                    .IsRequired()
                    .HasColumnName("MBU_Exclusion_LST")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.MbuFilteredFileName)
                    .HasColumnName("MBU_Filtered_File_Name")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.MbuFullBuDay)
                    .IsRequired()
                    .HasColumnName("MBU_Full_BU_DAY")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuGroupSrcSysTxt)
                    .IsRequired()
                    .HasColumnName("MBU_Group_SrcSys_TXT")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuInclusionLst)
                    .IsRequired()
                    .HasColumnName("MBU_Inclusion_LST")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.MbuModifiedDttm).HasColumnName("MBU_Modified_DTTM");

                entity.Property(e => e.MbuNonFullTyp)
                    .IsRequired()
                    .HasColumnName("MBU_NonFull_TYP")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.MbuRtntnPeriodNbr).HasColumnName("MBU_Rtntn_Period_NBR");

                entity.Property(e => e.MbuRtntnPeriodTxt)
                    .IsRequired()
                    .HasColumnName("MBU_Rtntn_Period_TXT")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuRtntnSrcSysTxt)
                    .IsRequired()
                    .HasColumnName("MBU_Rtntn_SrcSys_TXT")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuScheduleSrcSysTxt)
                    .IsRequired()
                    .HasColumnName("MBU_Schedule_SrcSys_TXT")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuScheduledTm)
                    .IsRequired()
                    .HasColumnName("MBU_Scheduled_TM")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuSendOffsiteFlg).HasColumnName("MBU_Send_Offsite_FLG");

                entity.Property(e => e.MbuSubClient)
                    .HasColumnName("MBU_SubClient")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecAddedDttm)
                    .HasColumnName("Rec_Added_DTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdatedDttm)
                    .HasColumnName("Rec_Updated_DTTM")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimManagedBackupLevel>(entity =>
            {
                entity.HasKey(e => e.ManagedBackupLevelKey)
                    .HasName("PK_Dim_Managed_Backup_Level");

                entity.ToTable("dim_managed_backup_level");

                entity.HasIndex(e => e.ManagedBackupLevelName)
                    .HasName("IX_Level_Name");

                entity.Property(e => e.ManagedBackupLevelKey).HasColumnName("Managed_Backup_Level_KEY");

                entity.Property(e => e.ManagedBackupLevelDescription)
                    .HasColumnName("Managed_Backup_Level_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ManagedBackupLevelName)
                    .IsRequired()
                    .HasColumnName("Managed_Backup_Level_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuLevelCurrentRecordFlag).HasColumnName("MBU_Level_current_record_flag");

                entity.Property(e => e.MbuLevelRecordCreatedBy)
                    .HasColumnName("MBU_Level_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuLevelRecordCreatedDatetime)
                    .HasColumnName("MBU_Level_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuLevelRecordEffectiveEndDatetime)
                    .HasColumnName("MBU_Level_Record_Effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuLevelRecordEffectiveStartDatetime)
                    .HasColumnName("MBU_Level_Record_Effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuLevelRecordUpdatedBy)
                    .HasColumnName("MBU_Level_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuLevelRecordUpdatedDatetime)
                    .HasColumnName("MBU_Level_Record_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimManagedBackupServerName>(entity =>
            {
                entity.HasKey(e => e.ManagedBackupServerNameKey)
                    .HasName("PK_Dim_Managed_Backup_Server_Name");

                entity.ToTable("Dim_Managed_Backup_Server_Name");

                entity.HasIndex(e => e.ManagedBackupServerName)
                    .HasName("IX_Server_Name");

                entity.Property(e => e.ManagedBackupServerNameKey).HasColumnName("Managed_Backup_Server_Name_KEY");

                entity.Property(e => e.ManagedBackupServerName)
                    .IsRequired()
                    .HasColumnName("Managed_Backup_Server_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuServerCurrentRecordFlag).HasColumnName("MBU_Server_current_record_flag");

                entity.Property(e => e.MbuServerRecordCreatedBy)
                    .HasColumnName("MBU_Server_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuServerRecordCreatedDatetime)
                    .HasColumnName("MBU_Server_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuServerRecordEffectiveEndDatetime)
                    .HasColumnName("MBU_Server_record_effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuServerRecordEffectiveStartDatetime)
                    .HasColumnName("MBU_Server_record_Effective_Start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuServerRecordUpdatedBy)
                    .HasColumnName("MBU_Server_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuServerRecordUpdatedDatetime)
                    .HasColumnName("MBU_Server_Record_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimManagedBackupStatus>(entity =>
            {
                entity.HasKey(e => e.ManagedBackupStatusKey)
                    .HasName("PK_Dim_Managed_Backup_Status_KEY");

                entity.ToTable("Dim_Managed_Backup_Status");

                entity.HasIndex(e => e.ManagedBackupStatusName)
                    .HasName("IX_Status");

                entity.Property(e => e.ManagedBackupStatusKey).HasColumnName("Managed_Backup_Status_KEY");

                entity.Property(e => e.ManagedBackupStatusName)
                    .IsRequired()
                    .HasColumnName("Managed_Backup_Status_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuStatusCurrentRecordFlag).HasColumnName("MBU_status_current_record_flag");

                entity.Property(e => e.MbuStatusRecordCreatedBy)
                    .HasColumnName("MBU_status_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuStatusRecordCreatedDatetime)
                    .HasColumnName("MBU_status_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuStatusRecordEffectiveEndDatetime)
                    .HasColumnName("MBU_status_Record_Effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuStatusRecordEffectiveStartDatetime)
                    .HasColumnName("MBU_status_Record_Effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuStatusRecordUpdatedBy)
                    .HasColumnName("MBU_status_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuStatusRecordUpdatedDatetime)
                    .HasColumnName("MBU_status_Record_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimManagedBackupTarget>(entity =>
            {
                entity.HasKey(e => e.ManagedBackupTargetKey)
                    .HasName("PK_Dim_Managed_Backup_Target_KEY");

                entity.ToTable("dim_managed_backup_target");

                entity.HasIndex(e => e.ManagedBackupTargetName)
                    .HasName("IDX_Target_Name");

                entity.Property(e => e.ManagedBackupTargetKey).HasColumnName("Managed_Backup_Target_KEY");

                entity.Property(e => e.ManagedBackupTargetName)
                    .IsRequired()
                    .HasColumnName("Managed_Backup_Target_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MbuTargetCurrentRecordFlag).HasColumnName("MBU_Target_current_record_flag");

                entity.Property(e => e.MbuTargetRecordCreatedBy)
                    .HasColumnName("MBU_Target_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuTargetRecordCreatedDatetime)
                    .HasColumnName("MBU_Target_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuTargetRecordEffectiveEndDatetime)
                    .HasColumnName("MBU_Target_Record_Effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuTargetRecordEffectiveStartDatetime)
                    .HasColumnName("MBU_Target_Record_Effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuTargetRecordUpdatedBy)
                    .HasColumnName("MBU_Target_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MbuTargetRecordUpdatedDatetime)
                    .HasColumnName("MBU_Target_Record_Updated_Datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimManagedExchangeDomain>(entity =>
            {
                entity.HasKey(e => e.ManagedExchangeDomainKey)
                    .HasName("PK_Dim_Managed_Exchange_Domain");

                entity.ToTable("dim_managed_exchange_domain");

                entity.Property(e => e.ManagedExchangeDomainKey).HasColumnName("Managed_Exchange_Domain_Key");

                entity.Property(e => e.ManagedExchangeDomainCreatedBy)
                    .IsRequired()
                    .HasColumnName("Managed_Exchange_Domain_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ManagedExchangeDomainCurrentRecordFlag).HasColumnName("Managed_Exchange_Domain_Current_Record_Flag");

                entity.Property(e => e.ManagedExchangeDomainEffectiveEndDatetime)
                    .HasColumnName("Managed_Exchange_Domain_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManagedExchangeDomainEffectiveStartDatetime)
                    .HasColumnName("Managed_Exchange_Domain_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManagedExchangeDomainName)
                    .IsRequired()
                    .HasColumnName("Managed_Exchange_Domain_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ManagedExchangeDomainRecordCreatedDatetime)
                    .HasColumnName("Managed_Exchange_Domain_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManagedExchangeDomainRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Managed_Exchange_Domain_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ManagedExchangeDomainRecordUpdatedDatetime)
                    .HasColumnName("Managed_Exchange_Domain_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ManagedExchangeDomainSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Managed_Exchange_Domain_Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimMbuExclusions>(entity =>
            {
                entity.HasKey(e => e.MbuExclusionsKey)
                    .HasName("PK_MBU_Exclusions_Key");

                entity.ToTable("dim_mbu_exclusions");

                entity.Property(e => e.MbuExclusionsKey).HasColumnName("MBU_Exclusions_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.MbuCollectionPointId).HasColumnName("MBU_Collection_Point_ID");

                entity.Property(e => e.MbuCollectionPointName)
                    .IsRequired()
                    .HasColumnName("MBU_Collection_Point_Name")
                    .HasMaxLength(255);

                entity.Property(e => e.MbuExclusionNk)
                    .IsRequired()
                    .HasColumnName("MBU_Exclusion_NK")
                    .HasColumnType("varchar(72)");

                entity.Property(e => e.MbuExclusionType)
                    .IsRequired()
                    .HasColumnName("MBU_Exclusion_Type")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.MbuExclusionTypeDetail)
                    .IsRequired()
                    .HasColumnName("MBU_Exclusion_Type_Detail")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.MbuExclusions)
                    .IsRequired()
                    .HasColumnName("MBU_Exclusions")
                    .HasMaxLength(2000);

                entity.Property(e => e.MbuSource)
                    .IsRequired()
                    .HasColumnName("MBU_Source")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedOn)
                    .HasColumnName("Record_Created_On")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDate)
                    .HasColumnName("Record_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDate)
                    .HasColumnName("Record_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedOn)
                    .HasColumnName("Record_Updated_On")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimMktgStatus>(entity =>
            {
                entity.HasKey(e => e.StatusKey)
                    .HasName("PK_Dim_Mktg_Status_Status_Key");

                entity.ToTable("Dim_Mktg_Status");

                entity.HasIndex(e => new { e.StatusNk, e.RecordType })
                    .HasName("UQ_Dim_Mktg_Status")
                    .IsUnique();

                entity.Property(e => e.StatusKey)
                    .HasColumnName("Status_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.RecordType)
                    .IsRequired()
                    .HasColumnName("Record_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StatusCreatedBy)
                    .HasColumnName("Status_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StatusCreatedDatetime).HasColumnName("Status_Created_Datetime");

                entity.Property(e => e.StatusDesc)
                    .HasColumnName("Status_Desc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StatusName)
                    .HasColumnName("Status_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StatusNk)
                    .IsRequired()
                    .HasColumnName("Status_Nk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StatusSourceSystemName)
                    .HasColumnName("Status_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StatusUpdatedBy)
                    .HasColumnName("Status_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StatusUpdatedDatetime).HasColumnName("Status_Updated_Datetime");
            });

            modelBuilder.Entity<DimMonitor>(entity =>
            {
                entity.HasKey(e => e.MonitorKey)
                    .HasName("PK_Dim_Monitor");

                entity.ToTable("dim_monitor");

                entity.HasIndex(e => new { e.MonitorId, e.CurrentRecordFlag })
                    .HasName("IDX_Monitor_Id_Current_Record");

                entity.Property(e => e.MonitorKey).HasColumnName("Monitor_Key");

                entity.Property(e => e.CurrentRecordFlag).HasColumnName("Current_Record_Flag");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImplementationType)
                    .HasColumnName("Implementation_Type")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.MonitorDeployedStatus)
                    .HasColumnName("monitor_deployed_status")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MonitorDescription)
                    .HasColumnName("Monitor_Description")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.MonitorErrorFrequency)
                    .HasColumnName("Monitor_Error_Frequency")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitorFrequency)
                    .HasColumnName("Monitor_Frequency")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitorGroup)
                    .HasColumnName("Monitor_Group")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitorHost)
                    .HasColumnName("Monitor_Host")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MonitorId)
                    .HasColumnName("Monitor_ID")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MonitorIdNk)
                    .HasColumnName("Monitor_ID_NK")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MonitorName)
                    .HasColumnName("Monitor_Name")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.MonitorPoller)
                    .HasColumnName("Monitor_Poller")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MonitorPort)
                    .IsRequired()
                    .HasColumnName("Monitor_Port")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitorProtocol)
                    .HasColumnName("Monitor_Protocol")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitorRetries)
                    .HasColumnName("Monitor_Retries")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitorSilo)
                    .HasColumnName("Monitor_Silo")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitorStatus)
                    .HasColumnName("Monitor_Status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.MonitorType)
                    .HasColumnName("Monitor_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimOpportunity>(entity =>
            {
                entity.HasKey(e => e.OpportunityId)
                    .HasName("PK__Dim_Oppo__C10D18507BAF3CD2");

                entity.ToTable("Dim_Opportunity");

                entity.Property(e => e.OpportunityId)
                    .HasColumnName("Opportunity_Id")
                    .HasColumnType("varchar(90)");

                entity.Property(e => e.Ddi).HasColumnType("varchar(300)");

                entity.Property(e => e.LeadOrigination)
                    .HasColumnName("Lead_Origination")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityAccountId)
                    .HasColumnName("Opportunity_Account_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.OpportunityAccountName)
                    .HasColumnName("Opportunity_Account_Name")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.OpportunityAccountSalesforceId)
                    .HasColumnName("Opportunity_Account_Salesforce_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.OpportunityAccountSubType)
                    .HasColumnName("Opportunity_Account_Sub_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityAccountType)
                    .HasColumnName("Opportunity_Account_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityAgeDays)
                    .HasColumnName("Opportunity_Age_Days")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityBooking)
                    .HasColumnName("Opportunity_Booking")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityBucket)
                    .HasColumnName("Opportunity_Bucket")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.OpportunityBucketSource)
                    .HasColumnName("Opportunity_Bucket_Source")
                    .HasMaxLength(50);

                entity.Property(e => e.OpportunityCampaignId)
                    .HasColumnName("Opportunity_Campaign_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.OpportunityCampaignName)
                    .HasColumnName("Opportunity_Campaign_Name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.OpportunityCampaignType)
                    .HasColumnName("Opportunity_Campaign_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityCategory)
                    .HasColumnName("Opportunity_Category")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityClone)
                    .HasColumnName("Opportunity_Clone")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunityCloudRevenueForecast)
                    .HasColumnName("Opportunity_Cloud_Revenue_Forecast")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityCommissionRole)
                    .HasColumnName("Opportunity_Commission_Role")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityContractType)
                    .HasColumnName("Opportunity_Contract_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityCreatedDate).HasColumnName("Opportunity_Created_Date");

                entity.Property(e => e.OpportunityCreatedDateUtc).HasColumnName("Opportunity_Created_Date_Utc");

                entity.Property(e => e.OpportunityCreatedFromLead)
                    .HasColumnName("Opportunity_Created_From_Lead")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityCurrencyCode)
                    .HasColumnName("Opportunity_Currency_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityCurrentRecord).HasColumnName("Opportunity_Current_Record");

                entity.Property(e => e.OpportunityCvpVerified)
                    .HasColumnName("Opportunity_CVP_Verified")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityDebookAmount)
                    .HasColumnName("Opportunity_Debook_Amount")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityDebookDate)
                    .HasColumnName("Opportunity_Debook_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.OpportunityDebookType)
                    .HasColumnName("Opportunity_Debook_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityDeletedFlag)
                    .HasColumnName("Opportunity_Deleted_Flag")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.OpportunityExpectedRevenue)
                    .HasColumnName("Opportunity_Expected_Revenue")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityFocusArea).HasColumnName("Opportunity_Focus_Area");

                entity.Property(e => e.OpportunityInvalidContract)
                    .HasColumnName("Opportunity_Invalid_Contract")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityIsClosed)
                    .HasColumnName("Opportunity_isClosed")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityIsTopOpp)
                    .HasColumnName("Opportunity_Is_Top_Opp")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityIsWon)
                    .HasColumnName("Opportunity_isWon")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityKey).HasColumnName("Opportunity_Key");

                entity.Property(e => e.OpportunityLeadId)
                    .HasColumnName("Opportunity_Lead_Id")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.OpportunityLiveCall)
                    .HasColumnName("Opportunity_Live_Call")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityMarketSector)
                    .HasColumnName("Opportunity_Market_Sector")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityName)
                    .HasColumnName("Opportunity_Name")
                    .HasColumnType("varchar(360)");

                entity.Property(e => e.OpportunityNewton)
                    .HasColumnName("Opportunity_Newton")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityNextStep)
                    .HasColumnName("Opportunity_Next_Step")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.OpportunityNutcaseDealProbability)
                    .HasColumnName("Opportunity_Nutcase_Deal_Probability")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityOnDemandReconciled)
                    .HasColumnName("Opportunity_On_Demand_Reconciled")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityOtherUtilityFee)
                    .HasColumnName("Opportunity_Other_Utility_Fee")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityOverlayProducts).HasColumnName("Opportunity_Overlay_Products");

                entity.Property(e => e.OpportunityPlatform)
                    .HasColumnName("Opportunity_Platform")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityPlatformSubCategory)
                    .HasColumnName("Opportunity_Platform_Sub_Category")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityProbability)
                    .HasColumnName("Opportunity_Probability")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityQuoteId)
                    .HasColumnName("Opportunity_Quote_Id")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunityRecordCreatedBy)
                    .HasColumnName("Opportunity_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OpportunityRecordCreatedDatetime).HasColumnName("Opportunity_Record_Created_Datetime");

                entity.Property(e => e.OpportunityRecordUpdatedBy)
                    .HasColumnName("Opportunity_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OpportunityRecordUpdatedDatetime).HasColumnName("Opportunity_Record_Updated_Datetime");

                entity.Property(e => e.OpportunityRequestedProducts).HasColumnName("Opportunity_Requested_Products");

                entity.Property(e => e.OpportunityResolution1)
                    .HasColumnName("Opportunity_Resolution_1")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityResolution2)
                    .HasColumnName("Opportunity_Resolution_2")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySalesInvolvement)
                    .HasColumnName("Opportunity_Sales_Involvement")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.OpportunitySalesforceId)
                    .IsRequired()
                    .HasColumnName("Opportunity_Salesforce_Id")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.OpportunitySolutionArea)
                    .HasColumnName("Opportunity_Solution_Area")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySolutionAreaWorkload)
                    .HasColumnName("Opportunity_Solution_Area_Workload")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySourceSystemName)
                    .HasColumnName("Opportunity_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.OpportunitySplitCategory)
                    .HasColumnName("Opportunity_Split_Category")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunitySplitCategoryPercentage)
                    .HasColumnName("Opportunity_Split_Category_Percentage")
                    .HasColumnType("decimal");

                entity.Property(e => e.OpportunityType)
                    .HasColumnName("Opportunity_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OpportunityUpside)
                    .HasColumnName("Opportunity_Upside")
                    .HasColumnType("varchar(5)");

                entity.Property(e => e.OpportunityWorkloadField)
                    .HasColumnName("Opportunity_Workload_Field")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimPage>(entity =>
            {
                entity.HasKey(e => e.PageKey)
                    .HasName("PK__dim_page__1FC2DB6D7F1CD39F");

                entity.ToTable("dim_page");

                entity.Property(e => e.PageKey)
                    .HasColumnName("page_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.Page)
                    .IsRequired()
                    .HasColumnName("page")
                    .HasMaxLength(500);

                entity.Property(e => e.PageCreatedBy)
                    .HasColumnName("page_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.PageCreatedDatetime)
                    .HasColumnName("page_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PageServers)
                    .HasColumnName("page_servers")
                    .HasMaxLength(255);

                entity.Property(e => e.PageSiteSections)
                    .HasColumnName("page_site_sections")
                    .HasMaxLength(255);

                entity.Property(e => e.PageSiteType)
                    .HasColumnName("page_site_type")
                    .HasMaxLength(255);

                entity.Property(e => e.PageSourceSystemIdColumn)
                    .IsRequired()
                    .HasColumnName("page_source_system_id_column")
                    .HasMaxLength(200);

                entity.Property(e => e.PageSourceSystemIdNk)
                    .HasColumnName("page_source_system_id_nk")
                    .HasMaxLength(500);

                entity.Property(e => e.PageSourceSystemName)
                    .IsRequired()
                    .HasColumnName("page_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.PageUpdatedBy)
                    .HasColumnName("page_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.PageUpdatedDatetime)
                    .HasColumnName("page_updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PageUrl)
                    .HasColumnName("page_url")
                    .HasMaxLength(500);

                entity.Property(e => e.PageWebsiteDomain)
                    .HasColumnName("page_website_domain")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DimParameter>(entity =>
            {
                entity.HasKey(e => e.ParameterKey)
                    .HasName("PK__dim_para__A13F3EAB7B781B75");

                entity.ToTable("dim_parameter");

                entity.Property(e => e.ParameterKey)
                    .HasColumnName("parameter_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.Parameter)
                    .HasColumnName("parameter")
                    .HasMaxLength(500);

                entity.Property(e => e.ParameterCreatedBy)
                    .HasColumnName("parameter_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.ParameterCreatedDatetime)
                    .HasColumnName("parameter_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParameterSourceSystemColumn)
                    .HasColumnName("parameter_source_system_column")
                    .HasMaxLength(100);

                entity.Property(e => e.ParameterSourceSystemIdNk)
                    .HasColumnName("parameter_source_system_id_nk")
                    .HasMaxLength(500);

                entity.Property(e => e.ParameterSourceSystemName)
                    .HasColumnName("parameter_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ParameterUpdatedBy)
                    .HasColumnName("parameter_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.ParameterUpdatedDatetime)
                    .HasColumnName("parameter_updated_datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimPhoneSkill>(entity =>
            {
                entity.HasKey(e => e.PhoneSkillKey)
                    .HasName("PK_Dim_Phone_Skill");

                entity.ToTable("dim_phone_skill");

                entity.Property(e => e.PhoneSkillKey).HasColumnName("Phone_Skill_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.PhoneSkillDescription)
                    .HasColumnName("Phone_Skill_Description")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.PhoneSkillEffectiveEndDate)
                    .HasColumnName("Phone_Skill_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneSkillEffectiveStartDate)
                    .HasColumnName("Phone_Skill_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneSkillName)
                    .IsRequired()
                    .HasColumnName("Phone_Skill_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneSkillNk)
                    .HasColumnName("Phone_Skill_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PhoneSkillRecordCreatedBy)
                    .HasColumnName("Phone_Skill_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneSkillRecordCreatedDatetime)
                    .HasColumnName("Phone_Skill_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneSkillRecordUpdatedBy)
                    .HasColumnName("Phone_Skill_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneSkillRecordUpdatedDatetime)
                    .HasColumnName("Phone_Skill_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneSkillSourceSystemName)
                    .HasColumnName("Phone_Skill_Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimPhoneVdn>(entity =>
            {
                entity.HasKey(e => e.PhoneVdnKey)
                    .HasName("PK_Dim_Phone_VDN");

                entity.ToTable("dim_phone_vdn");

                entity.Property(e => e.PhoneVdnKey).HasColumnName("Phone_VDN_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.PhoneVdnDescription)
                    .HasColumnName("Phone_VDN_Description")
                    .HasColumnType("varchar(300)");

                entity.Property(e => e.PhoneVdnEffectiveEndDate)
                    .HasColumnName("Phone_VDN_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneVdnEffectiveStartDate)
                    .HasColumnName("Phone_VDN_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneVdnName)
                    .IsRequired()
                    .HasColumnName("Phone_VDN_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneVdnNk)
                    .HasColumnName("Phone_VDN_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PhoneVdnRecordCreatedBy)
                    .HasColumnName("Phone_VDN_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneVdnRecordCreatedDatetime)
                    .HasColumnName("Phone_VDN_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneVdnRecordUpdatedBy)
                    .HasColumnName("Phone_VDN_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.PhoneVdnRecordUpdatedDatetime)
                    .HasColumnName("Phone_VDN_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhoneVdnSourceSystemName)
                    .HasColumnName("Phone_VDN_Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimProduct>(entity =>
            {
                entity.HasKey(e => e.ProductKey)
                    .HasName("PK_Dim_Product");

                entity.ToTable("Dim_Product");

                entity.HasIndex(e => e.ProductRecordSourceSystemName)
                    .HasName("IDX_SS");

                entity.HasIndex(e => new { e.ProductResourceCode, e.ProductRecordSourceSystemName })
                    .HasName("IDX_Product_NK");

                entity.Property(e => e.ProductKey).HasColumnName("Product_Key");

                entity.Property(e => e.ProductCurrentRecordFlag).HasColumnName("Product_Current_Record_Flag");

                entity.Property(e => e.ProductEffectiveEndDatetime)
                    .HasColumnName("Product_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductEffectiveStartDatetime)
                    .HasColumnName("Product_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductGroup)
                    .HasColumnName("Product_Group")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.ProductRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Product_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProductRecordCreatedDatetime)
                    .HasColumnName("Product_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductRecordSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Product_Record_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProductRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Product_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProductRecordUpdatedDatetime)
                    .HasColumnName("Product_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductResourceBillingTypeCode).HasColumnName("Product_Resource_Billing_Type_Code");

                entity.Property(e => e.ProductResourceCode)
                    .HasColumnName("Product_Resource_Code")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ProductResourceCodeEndRange).HasColumnName("Product_Resource_Code_End_Range");

                entity.Property(e => e.ProductResourceCodeNk)
                    .HasColumnName("Product_Resource_Code_NK")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ProductResourceCodeSpecialPrice)
                    .IsRequired()
                    .HasColumnName("Product_Resource_Code_Special_Price")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProductResourceCodeStartRange).HasColumnName("Product_Resource_Code_Start_Range");

                entity.Property(e => e.ProductResourceGlRevenueAccount).HasColumnName("Product_Resource_GL_Revenue_Account");

                entity.Property(e => e.ProductResourceTieredFlag).HasColumnName("Product_Resource_Tiered_Flag");

                entity.Property(e => e.ProductSettingEndRange).HasColumnName("Product_Setting_End_Range");

                entity.Property(e => e.ProductSettingStartRange).HasColumnName("Product_Setting_Start_Range");

                entity.Property(e => e.ProductType)
                    .HasColumnName("Product_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProductUnitOfMeasure)
                    .IsRequired()
                    .HasColumnName("Product_Unit_Of_Measure")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimProductSource>(entity =>
            {
                entity.HasKey(e => e.ProductSourceKey)
                    .HasName("PK_Dim_Source");

                entity.ToTable("Dim_Product_Source");

                entity.Property(e => e.ProductSourceKey).HasColumnName("Product_Source_KEY");

                entity.Property(e => e.ProductSourceCategory)
                    .HasColumnName("Product_Source_Category")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductSourceCurrentRecord).HasColumnName("Product_Source_Current_Record");

                entity.Property(e => e.ProductSourceEffectiveEndDatetime)
                    .HasColumnName("Product_Source_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductSourceEffectiveStartDatetime)
                    .HasColumnName("Product_Source_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductSourceName)
                    .IsRequired()
                    .HasColumnName("Product_Source_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductSourceNk)
                    .IsRequired()
                    .HasColumnName("Product_Source_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductSourceRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Product_Source_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductSourceRecordCreatedDatetime)
                    .HasColumnName("Product_Source_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductSourceRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Product_Source_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductSourceRecordUpdatedDatetime)
                    .HasColumnName("Product_Source_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductSourceSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Product_Source_Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimProductUsage>(entity =>
            {
                entity.HasKey(e => e.ProductUsageKey)
                    .HasName("PK_product_usage_key");

                entity.ToTable("dim_product_usage");

                entity.Property(e => e.ProductUsageKey)
                    .HasColumnName("product_usage_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountObjType)
                    .HasColumnName("account_obj_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CurrentRecord).HasColumnName("current_record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ItemGlSegment)
                    .HasColumnName("item_gl_segment")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ItemType)
                    .HasColumnName("item_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductUsageCode)
                    .HasColumnName("product_usage_code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductUsageCreationBy)
                    .HasColumnName("product_usage_creation_by")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductUsageCreationDate)
                    .HasColumnName("product_usage_creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductUsageDescription)
                    .HasColumnName("product_usage_description")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ProductUsageName)
                    .HasColumnName("product_usage_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductUsageNameByTag)
                    .HasColumnName("product_usage_name_by_tag")
                    .HasColumnType("varchar(1000)");

                entity.Property(e => e.ProductUsageNk)
                    .HasColumnName("product_usage_nk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductUsageObjType)
                    .HasColumnName("product_usage_obj_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductUsagePermitted)
                    .HasColumnName("product_usage_permitted")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductUsageSsk)
                    .IsRequired()
                    .HasColumnName("product_usage_ssk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductUsageType)
                    .HasColumnName("product_usage_type")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ProductUsageUpdatedBy)
                    .HasColumnName("product_usage_updated_by")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductUsageUpdatedDate)
                    .HasColumnName("product_usage_updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RateTag)
                    .HasColumnName("rate_tag")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecCreatedDate)
                    .HasColumnName("rec_created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecEndDate)
                    .HasColumnName("rec_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdatedDate)
                    .HasColumnName("rec_updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("source_system_name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimQueue>(entity =>
            {
                entity.HasKey(e => e.QueueKey)
                    .HasName("PK_Dim_Queue_1");

                entity.ToTable("dim_queue");

                entity.HasIndex(e => e.QueueIdNk)
                    .HasName("ix_dim_queue_nk");

                entity.HasIndex(e => e.QueueName)
                    .HasName("ix_Dim_Queue_Queue_Name");

                entity.HasIndex(e => e.QueueType)
                    .HasName("ix_dim_queue_type");

                entity.HasIndex(e => new { e.QueueEffectiveStartDatetime, e.QueueEffectiveEndDatetime })
                    .HasName("ix_Dim_Queue_start_end_datetime");

                entity.HasIndex(e => new { e.QueueIdNk, e.QueueSourceSystemName })
                    .HasName("ix_Dim_Queue_nk_source_name");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_KEY");

                entity.Property(e => e.QueueActiveFlag).HasColumnName("Queue_Active_Flag");

                entity.Property(e => e.QueueCurrentRecordFlag).HasColumnName("Queue_Current_Record_Flag");

                entity.Property(e => e.QueueDescription)
                    .IsRequired()
                    .HasColumnName("Queue_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.QueueEffectiveEndDatetime)
                    .HasColumnName("Queue_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueEffectiveStartDatetime)
                    .HasColumnName("Queue_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueIdNk).HasColumnName("Queue_ID_NK");

                entity.Property(e => e.QueueName)
                    .IsRequired()
                    .HasColumnName("Queue_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.QueuePrivateFlag).HasColumnName("Queue_Private_Flag");

                entity.Property(e => e.QueueRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Queue_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.QueueRecordCreatedDatetime)
                    .HasColumnName("Queue_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueRecordUdatedDatetime)
                    .HasColumnName("Queue_Record_Udated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Queue_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.QueueSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Queue_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.QueueType)
                    .IsRequired()
                    .HasColumnName("Queue_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimReportCategory>(entity =>
            {
                entity.HasKey(e => e.ReportCategoryKey)
                    .HasName("PK_Dim_Report_Category");

                entity.ToTable("dim_report_category");

                entity.HasIndex(e => e.ReportCategoryName)
                    .HasName("IX_Report_Category_Name");

                entity.HasIndex(e => e.ReportCategoryRanking)
                    .HasName("IX_Report_Category_Ranking");

                entity.Property(e => e.ReportCategoryKey).HasColumnName("Report_Category_KEY");

                entity.Property(e => e.ReportCategoryName)
                    .HasColumnName("Report_Category_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ReportCategoryRanking).HasColumnName("Report_Category_Ranking");
            });

            modelBuilder.Entity<DimResolutionAction>(entity =>
            {
                entity.HasKey(e => e.ResolutionActionKey)
                    .HasName("PK_Dim_Resolution_Action");

                entity.ToTable("dim_resolution_action");

                entity.Property(e => e.ResolutionActionKey).HasColumnName("Resolution_Action_Key");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionActionCurrentRecord).HasColumnName("Resolution_Action_Current_Record");

                entity.Property(e => e.ResolutionActionEffectiveEndDate)
                    .HasColumnName("Resolution_Action_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionActionEffectiveStartDate)
                    .HasColumnName("Resolution_Action_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionActionIdNk)
                    .IsRequired()
                    .HasColumnName("Resolution_Action_id_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ResolutionActionName)
                    .IsRequired()
                    .HasColumnName("Resolution_Action_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ResolutionActionType)
                    .IsRequired()
                    .HasColumnName("Resolution_Action_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimResolutionProduct>(entity =>
            {
                entity.HasKey(e => e.ResolutionProductKey)
                    .HasName("PK_Dim_Resolution_Product");

                entity.ToTable("dim_resolution_product");

                entity.Property(e => e.ResolutionProductKey).HasColumnName("Resolution_Product_Key");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionProductCurrentRecord).HasColumnName("Resolution_Product_Current_Record");

                entity.Property(e => e.ResolutionProductEffectiveEndDate)
                    .HasColumnName("Resolution_Product_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionProductEffectiveStartDate)
                    .HasColumnName("Resolution_Product_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionProductIdNk)
                    .IsRequired()
                    .HasColumnName("Resolution_Product_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ResolutionProductName)
                    .IsRequired()
                    .HasColumnName("Resolution_Product_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ResolutionProductSuiteIdNk)
                    .IsRequired()
                    .HasColumnName("Resolution_Product_Suite_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ResolutionProductType)
                    .IsRequired()
                    .HasColumnName("Resolution_Product_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimResolutionProductSuite>(entity =>
            {
                entity.HasKey(e => e.ResolutionProductSuiteKey)
                    .HasName("PK_Dim_Resolution_Product_Suite");

                entity.ToTable("dim_resolution_product_suite");

                entity.Property(e => e.ResolutionProductSuiteKey).HasColumnName("Resolution_Product_Suite_Key");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionProductSuiteCurrentRecord).HasColumnName("Resolution_Product_Suite_Current_Record");

                entity.Property(e => e.ResolutionProductSuiteEffectiveEndDate)
                    .HasColumnName("Resolution_Product_Suite_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionProductSuiteEffectiveStartDate)
                    .HasColumnName("Resolution_Product_Suite_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResolutionProductSuiteIdNk)
                    .IsRequired()
                    .HasColumnName("Resolution_Product_Suite_ID_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ResolutionProductSuiteName)
                    .IsRequired()
                    .HasColumnName("Resolution_Product_Suite_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ResolutionProductSuiteType)
                    .IsRequired()
                    .HasColumnName("Resolution_Product_Suite_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimRevRptBridge>(entity =>
            {
                entity.HasKey(e => e.RevRptBridgeKey)
                    .HasName("PK_Dim_Rev_Rpt_Bridge");

                entity.ToTable("dim_rev_rpt_bridge");

                entity.HasIndex(e => e.ReportCategoryKey)
                    .HasName("IX_Revenue_Category_Key");

                entity.HasIndex(e => e.RevenueTypeKey)
                    .HasName("IX_Revenue_Type_Key");

                entity.HasIndex(e => new { e.RevenueTypeKey, e.ReportCategoryKey })
                    .HasName("IX_Unique")
                    .IsUnique();

                entity.Property(e => e.RevRptBridgeKey).HasColumnName("Rev_Rpt_Bridge_KEY");

                entity.Property(e => e.ReportCategoryKey)
                    .IsRequired()
                    .HasColumnName("Report_Category_KEY");

                entity.Property(e => e.RevenueTypeKey)
                    .IsRequired()
                    .HasColumnName("Revenue_Type_KEY");
            });

            modelBuilder.Entity<DimRevenueCategory>(entity =>
            {
                entity.HasKey(e => e.RevenueCategoryKey)
                    .HasName("PK_Dim_Revenue_Category");

                entity.ToTable("dim_revenue_category");

                entity.Property(e => e.RevenueCategoryKey).HasColumnName("Revenue_Category_Key");

                entity.Property(e => e.RevenueCategoryCurrentRecordFlag).HasColumnName("Revenue_Category_Current_Record_Flag");

                entity.Property(e => e.RevenueCategoryDescription)
                    .IsRequired()
                    .HasColumnName("Revenue_Category_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RevenueCategoryEffectiveEndDatetime)
                    .HasColumnName("Revenue_Category_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueCategoryEffectiveStartDatetime)
                    .HasColumnName("Revenue_Category_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueCategoryIdNk)
                    .IsRequired()
                    .HasColumnName("Revenue_Category_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueCategoryName)
                    .IsRequired()
                    .HasColumnName("Revenue_Category_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueCategoryRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Category_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RevenueCategoryRecordCreatedDatetime)
                    .HasColumnName("Revenue_Category_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueCategoryRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Category_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RevenueCategoryRecordUpdatedDatetime)
                    .HasColumnName("Revenue_Category_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueCategorySourceSystemName)
                    .IsRequired()
                    .HasColumnName("Revenue_Category_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueCategoryType)
                    .IsRequired()
                    .HasColumnName("Revenue_Category_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimRevenueCostType>(entity =>
            {
                entity.HasKey(e => e.RevenueCostTypeKey)
                    .HasName("PK_Dim_Revenue_Cost_Type");

                entity.ToTable("dim_revenue_cost_type");

                entity.Property(e => e.RevenueCostTypeKey).HasColumnName("Revenue_Cost_Type_KEY");

                entity.Property(e => e.RevenueCostTypeCurrentRecordFlag).HasColumnName("Revenue_Cost_Type_Current_Record_Flag");

                entity.Property(e => e.RevenueCostTypeDescription)
                    .IsRequired()
                    .HasColumnName("Revenue_Cost_Type_Description")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueCostTypeEffectiveEndDateTime)
                    .HasColumnName("Revenue_Cost_Type_Effective_End_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueCostTypeEffectiveStartDateTime)
                    .HasColumnName("Revenue_Cost_Type_Effective_Start_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueCostTypeGroupName)
                    .IsRequired()
                    .HasColumnName("Revenue_Cost_Type_Group_Name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.RevenueCostTypeName)
                    .IsRequired()
                    .HasColumnName("Revenue_Cost_Type_Name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.RevenueCostTypeNk)
                    .IsRequired()
                    .HasColumnName("Revenue_Cost_Type_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueCostTypeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Cost_Type_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueCostTypeRecordCreatedDateTime)
                    .HasColumnName("Revenue_Cost_Type_Record_Created_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueCostTypeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Cost_Type_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueCostTypeRecordUpdatedDateTime)
                    .HasColumnName("Revenue_Cost_Type_Record_Updated_DateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimRevenueDeleteReason>(entity =>
            {
                entity.HasKey(e => e.RevenueDeleteReasonKey)
                    .HasName("PK_Dim_Revenue_Delete_Reason");

                entity.ToTable("dim_revenue_delete_reason");

                entity.Property(e => e.RevenueDeleteReasonKey).HasColumnName("Revenue_Delete_Reason_Key");

                entity.Property(e => e.RevenueDeleteReasonCategory)
                    .IsRequired()
                    .HasColumnName("Revenue_Delete_Reason_Category")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueDeleteReasonCurrentRecordFlag).HasColumnName("Revenue_Delete_Reason_Current_Record_Flag");

                entity.Property(e => e.RevenueDeleteReasonEffectiveEndDatetime)
                    .HasColumnName("Revenue_Delete_Reason_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueDeleteReasonEffectiveStartDatetime)
                    .HasColumnName("Revenue_Delete_Reason_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueDeleteReasonIdNk)
                    .IsRequired()
                    .HasColumnName("Revenue_Delete_Reason_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueDeleteReasonName)
                    .IsRequired()
                    .HasColumnName("Revenue_Delete_Reason_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueDeleteReasonRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Delete_Reason_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RevenueDeleteReasonRecordCreatedDatetime)
                    .HasColumnName("Revenue_Delete_Reason_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueDeleteReasonRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Delete_Reason_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RevenueDeleteReasonRecordUpdatedDatetime)
                    .HasColumnName("Revenue_Delete_Reason_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueDeleteReasonSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Revenue_Delete_Reason_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueDeleteReasonType)
                    .IsRequired()
                    .HasColumnName("Revenue_Delete_Reason_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimRevenueSetOfBooks>(entity =>
            {
                entity.HasKey(e => e.RevenueSetOfBooksKey)
                    .HasName("PK_Dim_Revenue_Set_of_Books");

                entity.ToTable("dim_revenue_set_of_books");

                entity.HasIndex(e => new { e.SetOfBooksNk, e.CurrentRecord })
                    .HasName("IX_Dim_Revenue_Set_of_Books_NKMI");

                entity.Property(e => e.RevenueSetOfBooksKey).HasColumnName("Revenue_Set_of_Books_key");

                entity.Property(e => e.ApplicationBasepath)
                    .HasColumnName("Application_Basepath")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ApplicationCreationDate)
                    .HasColumnName("Application_Creation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApplicationId)
                    .HasColumnName("Application_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ApplicationLastUpdateDate)
                    .HasColumnName("Application_Last_Update_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApplicationProductCode)
                    .HasColumnName("Application_Product_Code")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ApplicationShortName)
                    .HasColumnName("Application_Short_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlPeriodClosingStatus)
                    .HasColumnName("GL_Period_Closing_Status")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.GlPeriodCreationDate)
                    .HasColumnName("GL_Period_Creation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlPeriodEffectivePeriodNum).HasColumnName("GL_Period_Effective_Period_Num");

                entity.Property(e => e.GlPeriodEndDate)
                    .HasColumnName("GL_Period_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlPeriodLastUpdateDate)
                    .HasColumnName("GL_Period_Last_Update_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlPeriodName)
                    .HasColumnName("GL_Period_Name")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.GlPeriodNum).HasColumnName("GL_Period_Num");

                entity.Property(e => e.GlPeriodQuarterNum).HasColumnName("GL_Period_Quarter_Num");

                entity.Property(e => e.GlPeriodQuarterStartDate)
                    .HasColumnName("GL_Period_Quarter_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlPeriodStartDate)
                    .HasColumnName("GL_Period_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GlPeriodType)
                    .HasColumnName("GL_Period_Type")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.GlPeriodYear).HasColumnName("GL_Period_Year");

                entity.Property(e => e.GlPeriodYearStartDate)
                    .HasColumnName("GL_Period_Year_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordSourceSystem)
                    .IsRequired()
                    .HasColumnName("Record_Source_System")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUdpatedDatetime)
                    .HasColumnName("Record_Udpated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_by")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueSetOfBooksId)
                    .HasColumnName("Revenue_Set_of_Books_ID")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SetOfBooksChartOfAccountsId)
                    .HasColumnName("Set_Of_Books_Chart_Of_Accounts_ID")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.SetOfBooksCreationDate)
                    .HasColumnName("Set_Of_Books_Creation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SetOfBooksCurrencyCode)
                    .HasColumnName("Set_Of_Books_Currency_Code")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.SetOfBooksLastUpdateDate)
                    .HasColumnName("Set_Of_Books_Last_Update_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SetOfBooksLatestOpenedPeriodName)
                    .HasColumnName("Set_Of_Books_Latest_Opened_Period_Name")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.SetOfBooksName)
                    .HasColumnName("Set_Of_Books_Name")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.SetOfBooksNk)
                    .HasColumnName("Set_of_Books_NK")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SetOfBooksPeriodSetName)
                    .HasColumnName("Set_Of_Books_Period_Set_Name")
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.SetOfBooksShortName)
                    .HasColumnName("Set_Of_Books_Short_Name")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<DimRevenueStatus>(entity =>
            {
                entity.HasKey(e => e.RevenueStatusKey)
                    .HasName("PK_Dim_Revenue_Status");

                entity.ToTable("dim_revenue_status");

                entity.Property(e => e.RevenueStatusKey).HasColumnName("Revenue_Status_Key");

                entity.Property(e => e.RevenueStatusCurrentRecordFlag).HasColumnName("Revenue_Status_Current_Record_Flag");

                entity.Property(e => e.RevenueStatusDescription)
                    .IsRequired()
                    .HasColumnName("Revenue_Status_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RevenueStatusEffectiveEndDatetime)
                    .HasColumnName("Revenue_Status_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueStatusEffectiveStartDatetime)
                    .HasColumnName("Revenue_Status_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueStatusIdNk)
                    .IsRequired()
                    .HasColumnName("Revenue_Status_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueStatusName)
                    .IsRequired()
                    .HasColumnName("Revenue_Status_Name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.RevenueStatusRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Status_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RevenueStatusRecordCreatedDatetime)
                    .HasColumnName("Revenue_Status_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueStatusRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Status_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RevenueStatusRecordUpdatedDatetime)
                    .HasColumnName("Revenue_Status_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueStatusSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Revenue_Status_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueStatusType)
                    .IsRequired()
                    .HasColumnName("Revenue_Status_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimRevenueType>(entity =>
            {
                entity.HasKey(e => e.RevenueTypeKey)
                    .HasName("PK_Dim_Revenue_Type");

                entity.ToTable("dim_revenue_type");

                entity.HasIndex(e => e.RevenueTypeCategory)
                    .HasName("IX_Revenue_Type_Category");

                entity.HasIndex(e => e.RevenueTypeDetail)
                    .HasName("IX_Revenue_Type_Detail");

                entity.HasIndex(e => e.RevenueTypeName)
                    .HasName("IX_Revenue_Type_Name");

                entity.HasIndex(e => e.RevenueTypeReportRanking)
                    .HasName("IX_Type_Report_Ranking");

                entity.Property(e => e.RevenueTypeKey).HasColumnName("Revenue_Type_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("Rec_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueTypeCategory)
                    .HasColumnName("Revenue_Type_Category")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueTypeDetail)
                    .HasColumnName("Revenue_Type_Detail")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueTypeName)
                    .HasColumnName("Revenue_Type_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueTypeReportRanking).HasColumnName("Revenue_Type_Report_Ranking");

                entity.Property(e => e.RevenueTypeSubCategory)
                    .HasColumnName("Revenue_Type_Sub_Category")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimSearchTerm>(entity =>
            {
                entity.HasKey(e => e.SearchKey)
                    .HasName("search_key_indx");

                entity.ToTable("dim_search_term");

                entity.Property(e => e.SearchKey)
                    .HasColumnName("search_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.SearchEngine)
                    .IsRequired()
                    .HasColumnName("search_engine")
                    .HasMaxLength(255);

                entity.Property(e => e.SearchTerm)
                    .IsRequired()
                    .HasColumnName("search_term")
                    .HasMaxLength(255);

                entity.Property(e => e.SearchTermCreatedBy)
                    .HasColumnName("search_term_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.SearchTermCreatedDatetime)
                    .HasColumnName("search_term_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SearchTermSourceSystemColumn)
                    .IsRequired()
                    .HasColumnName("search_term_source_system_column")
                    .HasMaxLength(100);

                entity.Property(e => e.SearchTermSourceSystemIdNk)
                    .IsRequired()
                    .HasColumnName("search_term_source_system_id_nk")
                    .HasMaxLength(1000);

                entity.Property(e => e.SearchTermSourceSystemName)
                    .IsRequired()
                    .HasColumnName("search_term_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.SearchTermUpdatedBy)
                    .HasColumnName("search_term_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.SearchTermUpdatedDatetime)
                    .HasColumnName("search_term_updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SearchType)
                    .IsRequired()
                    .HasColumnName("search_type")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DimServicePoller>(entity =>
            {
                entity.HasKey(e => e.ServicePollerKey)
                    .HasName("PK_Dim_Service_Poller");

                entity.ToTable("Dim_Service_Poller");

                entity.HasIndex(e => e.ServicePollerCurrentRecordFlag)
                    .HasName("IDX04_Dim_Service_Poller_Current_Flag");

                entity.HasIndex(e => e.ServicePollerType)
                    .HasName("IDX03_Dim_Service_Poller_Type");

                entity.HasIndex(e => new { e.ServicePollerEffectiveStartDatetime, e.ServicePollerEffectiveEndDatetime })
                    .HasName("IDX02_Dim_Service_Poller");

                entity.HasIndex(e => new { e.ServicePollerIdNk, e.ServicePollerSourceSystemName })
                    .HasName("IDX01_Dim_Service_Poller");

                entity.Property(e => e.ServicePollerKey).HasColumnName("Service_Poller_Key");

                entity.Property(e => e.ServicePollerCurrentRecordFlag).HasColumnName("Service_Poller_Current_Record_Flag");

                entity.Property(e => e.ServicePollerDescription)
                    .IsRequired()
                    .HasColumnName("Service_Poller_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ServicePollerEffectiveEndDatetime)
                    .HasColumnName("Service_Poller_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServicePollerEffectiveStartDatetime)
                    .HasColumnName("Service_Poller_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServicePollerIdNk)
                    .HasColumnName("Service_Poller_ID_NK")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ServicePollerIsActive).HasColumnName("Service_Poller_Is_Active");

                entity.Property(e => e.ServicePollerIsCloseable).HasColumnName("Service_Poller_Is_Closeable");

                entity.Property(e => e.ServicePollerIsProvisioned).HasColumnName("Service_Poller_Is_Provisioned");

                entity.Property(e => e.ServicePollerMethod)
                    .IsRequired()
                    .HasColumnName("Service_Poller_Method")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ServicePollerName)
                    .IsRequired()
                    .HasColumnName("Service_Poller_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ServicePollerRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Service_Poller_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ServicePollerRecordCreatedDatetime)
                    .HasColumnName("Service_Poller_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServicePollerRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Service_Poller_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ServicePollerRecordUpdatedDatetime)
                    .HasColumnName("Service_Poller_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ServicePollerSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Service_Poller_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ServicePollerType)
                    .IsRequired()
                    .HasColumnName("Service_Poller_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimSeverity>(entity =>
            {
                entity.HasKey(e => e.SeverityKey)
                    .HasName("Dim_Severity_PK3");

                entity.ToTable("dim_severity");

                entity.HasIndex(e => new { e.SeverityTypeNk, e.SeverityNk, e.SourceSystemName, e.CurrentRecordFlag })
                    .HasName("IDX_Severity");

                entity.Property(e => e.SeverityKey).HasColumnName("Severity_Key");

                entity.Property(e => e.CurrentRecordFlag).HasColumnName("Current_Record_Flag");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnName("Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SeverityLongDescription)
                    .IsRequired()
                    .HasColumnName("Severity_Long_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SeverityNk)
                    .IsRequired()
                    .HasColumnName("Severity_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SeverityShortDescription)
                    .IsRequired()
                    .HasColumnName("Severity_Short_Description")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SeverityTypeNk)
                    .IsRequired()
                    .HasColumnName("Severity_Type_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimSfCurrencyConversion>(entity =>
            {
                entity.HasKey(e => e.CurrencyKey)
                    .HasName("PK_DBO_Dim_SF_CurrencyConversion");

                entity.ToTable("Dim_SF_CurrencyConversion");

                entity.Property(e => e.CurrencyKey)
                    .HasColumnName("Currency_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.ConversionRate).HasColumnType("decimal");

                entity.Property(e => e.CurrencyDeleteFlag)
                    .HasColumnName("Currency_Delete_Flag")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.CurrencyFromIsocode)
                    .IsRequired()
                    .HasColumnName("Currency_FromISOCode")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.CurrencyToIsocode)
                    .IsRequired()
                    .HasColumnName("Currency_ToISOCode")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.NextStartDate).HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetimeCst)
                    .HasColumnName("Record_Created_Datetime_Cst")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedDatetimeUtc)
                    .HasColumnName("Record_Created_Datetime_Utc")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetimeCst)
                    .HasColumnName("Record_Updated_Datetime_Cst")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedDatetimeUtc)
                    .HasColumnName("Record_Updated_Datetime_Utc")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DimSku>(entity =>
            {
                entity.HasKey(e => e.SkuKey)
                    .HasName("PK_Dim_SKU");

                entity.ToTable("dim_sku");

                entity.HasIndex(e => e.SkuCurrentRecord)
                    .HasName("IX_SKU_Current_Record");

                entity.HasIndex(e => e.SkuDescription)
                    .HasName("IX_SKU_Description");

                entity.HasIndex(e => e.SkuLicenseManufacturer)
                    .HasName("IX_SKU_License_Manufacture");

                entity.HasIndex(e => e.SkuName)
                    .HasName("  IX_SKU_Name");

                entity.HasIndex(e => e.SkuNumber)
                    .HasName("IX_SKU_Number");

                entity.HasIndex(e => e.SkuRecordUpdatedDatetime)
                    .HasName("IX_Dim_Sku_Rec_Upd_DT");

                entity.HasIndex(e => new { e.SkuKey, e.SkuName })
                    .HasName("IX_SKU_KEY+SKU_Name");

                entity.HasIndex(e => new { e.SkuProductCategory, e.SkuProductSubCategory })
                    .HasName("IX_Dim_SKU_Product_Category");

                entity.HasIndex(e => new { e.SkuNumber, e.SkuName, e.SkuDescription })
                    .HasName("  IX_SKU_Name+SKU_Number+SKU_Description");

                entity.HasIndex(e => new { e.SkuNumber, e.SkuCurrentRecord, e.SkuKey, e.SkuDescription })
                    .HasName("_dta_index_Dim_SKU_16_950294445__K2_K40_K1_K5");

                entity.Property(e => e.SkuKey).HasColumnName("SKU_KEY");

                entity.Property(e => e.SkuAcademicLicenseCost)
                    .HasColumnName("SKU_Academic_License_Cost")
                    .HasColumnType("money");

                entity.Property(e => e.SkuBizsparkLicenseCost)
                    .HasColumnName("SKU_Bizspark_License_Cost")
                    .HasColumnType("money");

                entity.Property(e => e.SkuBounceBackup).HasColumnName("SKU_Bounce_Backup");

                entity.Property(e => e.SkuCaptionDisplayName)
                    .HasColumnName("SKU_CaptionDisplay_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SkuCoreCategory)
                    .HasColumnName("SKU_CORE_Category")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuCurrentRecord).HasColumnName("SKU_Current_Record");

                entity.Property(e => e.SkuDescription)
                    .HasColumnName("SKU_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuEffectiveEndDatetime)
                    .HasColumnName("Sku_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuEffectiveStartDatetime)
                    .HasColumnName("Sku_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuHardwareChassisUnitSize).HasColumnName("SKU_Hardware_Chassis_Unit_Size");

                entity.Property(e => e.SkuHardwareFirewallCapacity)
                    .HasColumnName("SKU_Hardware_Firewall_Capacity")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuHardwareFirewallType)
                    .HasColumnName("SKU_Hardware_Firewall_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuHardwareLoadBalancerRedundant).HasColumnName("SKU_Hardware_Load_Balancer_Redundant");

                entity.Property(e => e.SkuHardwareLoadBalancerType)
                    .HasColumnName("SKU_Hardware_Load_Balancer_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuItemQuantity).HasColumnName("SKU_Item_Quantity");

                entity.Property(e => e.SkuLevel1)
                    .HasColumnName("SKU_Level_1")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuLevel2)
                    .HasColumnName("SKU_Level_2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuLevel3)
                    .HasColumnName("SKU_Level_3")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuLevel4)
                    .HasColumnName("SKU_Level_4")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuLicenseBackupAgentBase).HasColumnName("SKU_License_Backup_Agent_Base");

                entity.Property(e => e.SkuLicenseBackupAgentCluster).HasColumnName("SKU_License_Backup_Agent_Cluster");

                entity.Property(e => e.SkuLicenseBackupAgentOracle).HasColumnName("SKU_License_Backup_Agent_Oracle");

                entity.Property(e => e.SkuLicenseBackupAgentSql).HasColumnName("SKU_License_Backup_Agent_SQL");

                entity.Property(e => e.SkuLicenseBackupAgentTier).HasColumnName("SKU_License_Backup_Agent_Tier");

                entity.Property(e => e.SkuLicenseCalMultiplier)
                    .HasColumnName("SKU_License_CAL_Multiplier")
                    .HasColumnType("decimal");

                entity.Property(e => e.SkuLicenseCost)
                    .HasColumnName("SKU_License_Cost")
                    .HasColumnType("money");

                entity.Property(e => e.SkuLicenseGroupName)
                    .HasColumnName("SKU_License_Group_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuLicenseManufacturer)
                    .HasColumnName("SKU_License_Manufacturer")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuLicenseMsAdvancedOrStandard).HasColumnName("SKU_License_MS_Advanced_or_Standard");

                entity.Property(e => e.SkuLicenseMsAuthOrUnAuth).HasColumnName("SKU_License_MS_Auth_or_UnAuth");

                entity.Property(e => e.SkuLicenseMsMomPack).HasColumnName("SKU_License_MS_Mom_Pack");

                entity.Property(e => e.SkuLicenseMsStandardOrEnterprise).HasColumnName("SKU_License_MS_Standard_or_Enterprise");

                entity.Property(e => e.SkuLicenseOsFreeOrPaid).HasColumnName("SKU_License_OS_Free_or_Paid");

                entity.Property(e => e.SkuLicenseOsVersion)
                    .HasColumnName("SKU_License_OS_Version")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuLicenseProcessorMultiplier)
                    .HasColumnName("SKU_License_Processor_Multiplier")
                    .HasColumnType("decimal");

                entity.Property(e => e.SkuName)
                    .HasColumnName("SKU_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuNumber).HasColumnName("SKU_Number");

                entity.Property(e => e.SkuNumberExternal)
                    .HasColumnName("SKU_Number_External")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuProductCategory)
                    .HasColumnName("SKU_Product_Category")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuProductId)
                    .HasColumnName("SKU_Product_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuProductKey)
                    .HasColumnName("SKU_Product_Key")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuProductSubCategory)
                    .HasColumnName("SKU_Product_Sub_Category")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuRecAdded)
                    .HasColumnName("SKU_Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuRecCount).HasColumnName("SKU_Rec_Count");

                entity.Property(e => e.SkuRecUpdated)
                    .HasColumnName("SKU_Rec_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Sku_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SkuRecordCreatedDatetime)
                    .HasColumnName("Sku_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Sku_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SkuRecordUpdatedDatetime)
                    .HasColumnName("Sku_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuReportable).HasColumnName("SKU_Reportable");

                entity.Property(e => e.SkuRequirements)
                    .HasColumnName("SKU_Requirements")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuSoftwareHostwareSupport).HasColumnName("SKU_Software_Hostware_Support");

                entity.Property(e => e.SkuSoftwareSeats)
                    .HasColumnName("SKU_Software_Seats")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuSoftwareTypeName)
                    .HasColumnName("SKU_Software_Type_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuSoftwareVersion)
                    .HasColumnName("SKU_Software_Version")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SkuSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Sku_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimSkuExtendedAttribute>(entity =>
            {
                entity.HasKey(e => e.SkuExtendedAttributeKey)
                    .HasName("PK_dim_sku_extended_attribute");

                entity.ToTable("dim_sku_extended_attribute");

                entity.HasIndex(e => e.SkuExtendedAttributeRecordUpdatedDatetime)
                    .HasName("IX_sku_extended_attr_rec_upd_dt");

                entity.HasIndex(e => new { e.SkuProductDescription, e.SkuExtendedAttributeCurrentRecord, e.SkuNumber, e.SkuAttributeToSkuVal })
                    .HasName("IX__SKU");

                entity.HasIndex(e => new { e.SkuNumber, e.SkuAttributeId, e.SkuPartsAttributeValue, e.SkuLabel, e.SkuExtendedSsk, e.SkuExtendedAttributeCurrentRecord })
                    .HasName("idx_sku_extended");

                entity.Property(e => e.SkuExtendedAttributeKey).HasColumnName("sku_extended_attribute_key");

                entity.Property(e => e.SkuAttributeCategoryName)
                    .HasColumnName("sku_attribute_category_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuAttributeId).HasColumnName("sku_attribute_id");

                entity.Property(e => e.SkuAttributeName)
                    .HasColumnName("sku_attribute_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuAttributeToSkuAllowBlank).HasColumnName("sku_attribute_to_sku_allow_blank");

                entity.Property(e => e.SkuAttributeToSkuMax).HasColumnName("sku_attribute_to_sku_max");

                entity.Property(e => e.SkuAttributeToSkuMin).HasColumnName("sku_attribute_to_sku_min");

                entity.Property(e => e.SkuAttributeToSkuMulti).HasColumnName("sku_attribute_to_sku_multi");

                entity.Property(e => e.SkuAttributeToSkuTypeDescription)
                    .HasColumnName("sku_attribute_to_sku_type_description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuAttributeToSkuTypeName)
                    .HasColumnName("sku_attribute_to_sku_type_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuAttributeToSkuVal)
                    .HasColumnName("sku_attribute_to_sku_val")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuAttributeTypeDescription)
                    .HasColumnName("sku_attribute_type_description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuAttributeTypeName)
                    .HasColumnName("sku_attribute_type_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuExtendedAttributeCurrentRecord).HasColumnName("sku_extended_attribute_current_record");

                entity.Property(e => e.SkuExtendedAttributeRecordCreatedBy)
                    .HasColumnName("sku_extended_attribute_record_created_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SkuExtendedAttributeRecordCreatedDatetime)
                    .HasColumnName("sku_extended_attribute_record_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuExtendedAttributeRecordEffectiveEndDatetime)
                    .HasColumnName("sku_extended_attribute_record_effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuExtendedAttributeRecordEffectiveStartDatetime)
                    .HasColumnName("sku_extended_attribute_record_effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuExtendedAttributeRecordUpdatedBy)
                    .HasColumnName("sku_extended_attribute_record_updated_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SkuExtendedAttributeRecordUpdatedDatetime)
                    .HasColumnName("sku_extended_attribute_record_updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SkuExtendedAttributeSourceSystemName)
                    .HasColumnName("sku_extended_attribute_source_system_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SkuExtendedSsk)
                    .HasColumnName("Sku_Extended_SSK")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuLabel)
                    .HasColumnName("sku_label")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.SkuName)
                    .HasColumnName("sku_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuNumber).HasColumnName("sku_number");

                entity.Property(e => e.SkuPartsAttributeValue)
                    .HasColumnName("sku_parts_attribute_value")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuProductCategory)
                    .HasColumnName("sku_product_category")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuProductDescription)
                    .HasColumnName("sku_product_description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuProductOsIsNetworked).HasColumnName("sku_product_os_is_networked");

                entity.Property(e => e.SkuProductOsIsRealServer).HasColumnName("sku_product_os_is_real_server");

                entity.Property(e => e.SkuProductOsIsVirtual).HasColumnName("sku_product_os_is_virtual");

                entity.Property(e => e.SkuProductOsName)
                    .HasColumnName("sku_product_os_name")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.SkuProductRequirements)
                    .HasColumnName("sku_product_requirements")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuSkunitAccountLevel).HasColumnName("sku_skunit_account_level");

                entity.Property(e => e.SkuSkunitActive).HasColumnName("sku_skunit_active");

                entity.Property(e => e.SkuSkunitAllowBlank).HasColumnName("sku_skunit_allow_blank");

                entity.Property(e => e.SkuSkunitDepartmentRestriction)
                    .HasColumnName("sku_skunit_department_restriction")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.SkuSkunitLabel)
                    .HasColumnName("sku_skunit_label")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.SkuSkunitName)
                    .HasColumnName("sku_skunit_name")
                    .HasColumnType("varchar(1024)");
            });

            modelBuilder.Entity<DimStatus>(entity =>
            {
                entity.HasKey(e => e.StatusKey)
                    .HasName("Dim_Status_PK");

                entity.ToTable("Dim_Status");

                entity.Property(e => e.StatusKey).HasColumnName("Status_Key");

                entity.Property(e => e.StatusActive)
                    .HasColumnName("Status_Active")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StatusCurrentRecordFlag).HasColumnName("Status_Current_Record_Flag");

                entity.Property(e => e.StatusEffectiveEndDate)
                    .HasColumnName("Status_Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusEffectiveStartDate)
                    .HasColumnName("Status_Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusLongDescription)
                    .IsRequired()
                    .HasColumnName("Status_Long_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StatusNk)
                    .HasColumnName("Status_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StatusOnline)
                    .HasColumnName("Status_Online")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StatusOpenFlag).HasColumnName("Status_Open_Flag");

                entity.Property(e => e.StatusRank).HasColumnName("Status_Rank");

                entity.Property(e => e.StatusRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Status_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StatusRecordCreatedDatetime)
                    .HasColumnName("Status_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Status_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StatusRecordUpdatedDatetime)
                    .HasColumnName("Status_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusShortDescription)
                    .IsRequired()
                    .HasColumnName("Status_Short_Description")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StatusSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Status_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StatusTypeNk)
                    .IsRequired()
                    .HasColumnName("Status_Type_NK")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimSubscriptionType>(entity =>
            {
                entity.HasKey(e => e.SubscriptionTypeKey)
                    .HasName("PK_Dim_Subscription_Type");

                entity.ToTable("Dim_Subscription_Type");

                entity.HasIndex(e => new { e.SubscriptionTypeName, e.SubscriptionTypeCurrentRecordFlag })
                    .HasName("IX_Subscription_Type_Name");

                entity.Property(e => e.SubscriptionTypeKey).HasColumnName("Subscription_Type_KEY");

                entity.Property(e => e.SubscriptionTypeCurrentRecordFlag).HasColumnName("Subscription_Type_Current_Record_Flag");

                entity.Property(e => e.SubscriptionTypeDescription)
                    .HasColumnName("Subscription_Type_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubscriptionTypeEffectiveEndDateTime)
                    .HasColumnName("Subscription_Type_Effective_End_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionTypeEffectiveStartDateTime)
                    .HasColumnName("Subscription_Type_Effective_Start_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionTypeFrequency)
                    .HasColumnName("Subscription_Type_Frequency")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionTypeGroup)
                    .HasColumnName("Subscription_Type_Group")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubscriptionTypeLevel)
                    .HasColumnName("Subscription_Type_Level")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SubscriptionTypeMonthlyMultiplier)
                    .HasColumnName("Subscription_Type_Monthly_Multiplier")
                    .HasColumnType("decimal");

                entity.Property(e => e.SubscriptionTypeName)
                    .HasColumnName("Subscription_Type_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubscriptionTypeNk).HasColumnName("Subscription_Type_NK");

                entity.Property(e => e.SubscriptionTypeRecordCreatedBy)
                    .HasColumnName("Subscription_Type_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionTypeRecordCreatedDateTime)
                    .HasColumnName("Subscription_Type_Record_Created_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionTypeRecordUpdatedBy)
                    .HasColumnName("Subscription_Type_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionTypeRecordUpdatedDateTime)
                    .HasColumnName("Subscription_Type_Record_Updated_DateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimSurvey>(entity =>
            {
                entity.HasKey(e => e.SurveyKey)
                    .HasName("PK__Dim_Survey");

                entity.ToTable("dim_survey");

                entity.Property(e => e.SurveyKey).HasColumnName("Survey_key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDatetime)
                    .HasColumnName("Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDatetime)
                    .HasColumnName("Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SurveyAllowEditCompleted).HasColumnName("Survey_Allow_Edit_Completed");

                entity.Property(e => e.SurveyAllowResumeSurvey).HasColumnName("Survey_Allow_Resume_Survey");

                entity.Property(e => e.SurveyCreatedBySs)
                    .HasColumnName("Survey_Created_by_ss")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.SurveyDescription)
                    .HasColumnName("Survey_Description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.SurveyIdNk)
                    .IsRequired()
                    .HasColumnName("Survey_ID_NK")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.SurveyIsActive).HasColumnName("Survey_is_active");

                entity.Property(e => e.SurveyMaxResponsesPerUser).HasColumnName("Survey_Max_Responses_per_User");

                entity.Property(e => e.SurveyMaxTotalResponses).HasColumnName("Survey_Max_Total_Responses");

                entity.Property(e => e.SurveyName)
                    .HasColumnName("Survey_Name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.SurveySourceSystemName)
                    .IsRequired()
                    .HasColumnName("Survey_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyTitle)
                    .HasColumnName("Survey_Title")
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<DimSurveyAnswer>(entity =>
            {
                entity.HasKey(e => e.SurveyAnswerKey)
                    .HasName("PK_Dim_Survey_Answer");

                entity.ToTable("dim_survey_answer");

                entity.Property(e => e.SurveyAnswerKey).HasColumnName("Survey_Answer_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnName("Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyAnswer)
                    .HasColumnName("Survey_Answer")
                    .HasColumnType("varchar(7999)");

                entity.Property(e => e.SurveyAnswerIsOther).HasColumnName("Survey_Answer_IsOther");

                entity.Property(e => e.SurveyAnswerNk)
                    .IsRequired()
                    .HasColumnName("Survey_Answer_NK")
                    .HasColumnType("varchar(7999)");

                entity.Property(e => e.SurveyAnswerWordCount).HasColumnName("Survey_Answer_Word_Count");
            });

            modelBuilder.Entity<DimSurveyNpsAnswer>(entity =>
            {
                entity.HasKey(e => e.SurveyNpsAnswerKey)
                    .HasName("PK_Dim_Survey_NPS_Answer");

                entity.ToTable("dim_survey_nps_answer");

                entity.Property(e => e.SurveyNpsAnswerKey).HasColumnName("Survey_NPS_Answer_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnName("Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyNpsAnswer)
                    .HasColumnName("Survey_NPS_Answer")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SurveyNpsAnswerNk)
                    .IsRequired()
                    .HasColumnName("Survey_NPS_Answer_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SurveyNpsRatingType)
                    .HasColumnName("Survey_NPS_Rating_Type")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<DimSurveyQuestion>(entity =>
            {
                entity.HasKey(e => e.SurveyQuestionKey)
                    .HasName("PK_Dim_Survey_Question");

                entity.ToTable("dim_survey_question");

                entity.Property(e => e.SurveyQuestionKey).HasColumnName("Survey_Question_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnName("Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyQuestionNk)
                    .IsRequired()
                    .HasColumnName("Survey_Question_NK")
                    .HasColumnType("varchar(4096)");

                entity.Property(e => e.SurveyQuestionPagePosition).HasColumnName("Survey_Question_Page_Position");

                entity.Property(e => e.SurveyQuestionQuestionAlias)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Alias")
                    .HasMaxLength(255);

                entity.Property(e => e.SurveyQuestionQuestionCategory)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Category")
                    .HasColumnType("varchar(63)");

                entity.Property(e => e.SurveyQuestionQuestionPosition).HasColumnName("Survey_Question_question_position");

                entity.Property(e => e.SurveyQuestionQuestionSubText)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Sub_Text")
                    .HasColumnType("varchar(4096)");

                entity.Property(e => e.SurveyQuestionQuestionText)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Text")
                    .HasColumnType("varchar(4096)");

                entity.Property(e => e.SurveyQuestionQuestionType)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimSurveyResponse>(entity =>
            {
                entity.HasKey(e => e.SurveyResponseKey)
                    .HasName("PK_Dim_Survey_Response");

                entity.ToTable("dim_survey_response");

                entity.Property(e => e.SurveyResponseKey).HasColumnName("Survey_Response_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnName("Effective_End_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnName("Effective_Start_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyResponseIsComplete).HasColumnName("Survey_Response_Is_Complete");

                entity.Property(e => e.SurveyResponseLastPageNumberViewed).HasColumnName("Survey_Response_Last_Page_Number_Viewed");

                entity.Property(e => e.SurveyResponseNk)
                    .HasColumnName("Survey_Response_NK")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimSurveyType>(entity =>
            {
                entity.HasKey(e => e.SurveyTypeKey)
                    .HasName("PK_Dim_Survey_Type");

                entity.ToTable("dim_survey_type");

                entity.Property(e => e.SurveyTypeKey).HasColumnName("Survey_Type_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SurveyTypeDescription)
                    .HasColumnName("Survey_Type_Description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyTypeName)
                    .HasColumnName("Survey_Type_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyTypeNk)
                    .HasColumnName("Survey_Type_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyTypeSourceSystemName)
                    .HasColumnName("Survey_Type_Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimTeam>(entity =>
            {
                entity.HasKey(e => e.TeamKey)
                    .HasName("PK_team_key_12");

                entity.ToTable("dim_team");

                entity.HasIndex(e => e.TeamBusinessSegment)
                    .HasName("IX_Team_Business_Segment");

                entity.HasIndex(e => e.TeamBusinessSegmentReportId)
                    .HasName("IX_Team_Business_Segment_Report_ID");

                entity.HasIndex(e => e.TeamBusinessSubSegmentReportId)
                    .HasName("IX_Team_Business_Sub_Segment_Report_ID");

                entity.HasIndex(e => e.TeamId)
                    .HasName("IX_Team_ID");

                entity.HasIndex(e => e.TeamName)
                    .HasName("IX_Team_Name");

                entity.HasIndex(e => e.TeamReportHeader)
                    .HasName("IX_Team_Report_Header");

                entity.HasIndex(e => e.TeamReportHeaderId)
                    .HasName("IX_Team_Report_Header_ID");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("Rec_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamActive).HasColumnName("Team_Active");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSegmentReportId).HasColumnName("Team_Business_Segment_Report_ID");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSubSegmentReportId).HasColumnName("Team_Business_Sub_Segment_Report_ID");

                entity.Property(e => e.TeamCompany)
                    .HasColumnName("Team_Company")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamDataSource)
                    .HasColumnName("Team_Data_Source")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.TeamDescription)
                    .HasColumnName("Team_Description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamDivision)
                    .HasColumnName("Team_Division")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamId).HasColumnName("Team_ID");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("Team_Name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.TeamRecordCreatedBy)
                    .HasColumnName("Team_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamRecordCreatedDatetime)
                    .HasColumnName("Team_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamRecordEffectiveEndDatetime)
                    .HasColumnName("Team_Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamRecordEffectiveStartDatetime)
                    .HasColumnName("Team_Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamRecordSourceId).HasColumnName("Team_Record_Source_ID");

                entity.Property(e => e.TeamRecordUpdatedBy)
                    .HasColumnName("Team_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamRecordUpdatedDatetime)
                    .HasColumnName("Team_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamReportHeader)
                    .HasColumnName("Team_Report_Header")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.TeamReportHeaderId).HasColumnName("Team_Report_Header_ID");

                entity.Property(e => e.TeamRoleId).HasColumnName("Team_Role_ID");
            });

            modelBuilder.Entity<DimThreshold>(entity =>
            {
                entity.HasKey(e => e.ThresholdKey)
                    .HasName("PK_Dim_Threshold");

                entity.ToTable("Dim_Threshold");

                entity.HasIndex(e => e.ThresholdCurrentRecordFlag)
                    .HasName("IDX02_Dim_Threshold_Current_Record_Flag");

                entity.HasIndex(e => e.ThresholdType)
                    .HasName("IDX03_Dim_Threshold_Type");

                entity.HasIndex(e => new { e.ThresholdIdNk, e.ThresholdSourceSystemName })
                    .HasName("IDX01_Dim_Threshold_ID_NK_Source_System_Name");

                entity.Property(e => e.ThresholdKey).HasColumnName("Threshold_Key");

                entity.Property(e => e.ThresholdAmount)
                    .HasColumnName("Threshold_Amount")
                    .HasColumnType("numeric");

                entity.Property(e => e.ThresholdCurrentRecordFlag).HasColumnName("Threshold_Current_Record_Flag");

                entity.Property(e => e.ThresholdDescription)
                    .IsRequired()
                    .HasColumnName("Threshold_Description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ThresholdEffectiveEndDatetime)
                    .HasColumnName("Threshold_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThresholdEffectiveStartDatetime)
                    .HasColumnName("Threshold_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThresholdIdNk)
                    .IsRequired()
                    .HasColumnName("Threshold_ID_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ThresholdName)
                    .IsRequired()
                    .HasColumnName("Threshold_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ThresholdRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Threshold_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ThresholdRecordCreatedDatetime)
                    .HasColumnName("Threshold_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThresholdRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Threshold_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ThresholdRecordUpdatedDatetime)
                    .HasColumnName("Threshold_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThresholdSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Threshold_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ThresholdType)
                    .IsRequired()
                    .HasColumnName("Threshold_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ThresholdUnitOfMeasure)
                    .IsRequired()
                    .HasColumnName("Threshold_Unit_Of_Measure")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimTicket>(entity =>
            {
                entity.HasKey(e => e.TicketKey)
                    .HasName("PK_DIM_TICKET");

                entity.ToTable("DIM_TICKET");

                entity.Property(e => e.TicketKey)
                    .HasColumnName("TICKET_KEY")
                    .ValueGeneratedNever();

                entity.Property(e => e.SourceTimezone)
                    .HasColumnName("SOURCE_TIMEZONE")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketCreatedDatetime)
                    .HasColumnName("TICKET_CREATED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketCreatedMethod)
                    .HasColumnName("TICKET_CREATED_METHOD")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketCreatorName)
                    .HasColumnName("TICKET_CREATOR_NAME")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketCurrentCategory)
                    .HasColumnName("TICKET_CURRENT_CATEGORY")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketCurrentDifficulty).HasColumnName("TICKET_CURRENT_DIFFICULTY");

                entity.Property(e => e.TicketCurrentNpsT).HasColumnName("TICKET_CURRENT_NPS_T");

                entity.Property(e => e.TicketCurrentPriority)
                    .HasColumnName("TICKET_CURRENT_PRIORITY")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketCurrentRecordFlag).HasColumnName("TICKET_CURRENT_RECORD_FLAG");

                entity.Property(e => e.TicketCurrentSeverity)
                    .HasColumnName("TICKET_CURRENT_SEVERITY")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketCurrentStatus)
                    .HasColumnName("TICKET_CURRENT_STATUS")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketCurrentSubcategory)
                    .HasColumnName("TICKET_CURRENT_SUBCATEGORY")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketDescription)
                    .IsRequired()
                    .HasColumnName("TICKET_DESCRIPTION");

                entity.Property(e => e.TicketEffectiveEndDatetime)
                    .HasColumnName("TICKET_EFFECTIVE_END_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketEffectiveStartDatetime)
                    .HasColumnName("TICKET_EFFECTIVE_START_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketMassFlag).HasColumnName("TICKET_MASS_FLAG");

                entity.Property(e => e.TicketModifiedDatetime)
                    .HasColumnName("TICKET_MODIFIED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketNk)
                    .IsRequired()
                    .HasColumnName("TICKET_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketPrivateFlag).HasColumnName("TICKET_PRIVATE_FLAG");

                entity.Property(e => e.TicketRatingComment)
                    .IsRequired()
                    .HasColumnName("TICKET_RATING_COMMENT")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.TicketRecordCreatedBy)
                    .HasColumnName("TICKET_RECORD_CREATED_BY")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketRecordCreatedDatetime)
                    .HasColumnName("TICKET_RECORD_CREATED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketRecordUpdatedBy)
                    .HasColumnName("TICKET_RECORD_UPDATED_BY")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketRecordUpdatedDatetime)
                    .HasColumnName("TICKET_RECORD_UPDATED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketReferenceNumber)
                    .HasColumnName("TICKET_REFERENCE_NUMBER")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketSourceSystemName)
                    .HasColumnName("TICKET_SOURCE_SYSTEM_NAME")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketSubject)
                    .HasColumnName("TICKET_SUBJECT")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketSubmitterName)
                    .HasColumnName("TICKET_SUBMITTER_NAME")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimTicketCategory>(entity =>
            {
                entity.HasKey(e => e.TicketCategoryKey)
                    .HasName("PK_DIM_TICKET_CATEGORY");

                entity.ToTable("DIM_TICKET_CATEGORY");

                entity.Property(e => e.TicketCategoryKey)
                    .HasColumnName("Ticket_Category_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicketCategoryCurrentRecordFlag).HasColumnName("Ticket_Category_Current_Record_Flag");

                entity.Property(e => e.TicketCategoryDescription)
                    .HasColumnName("Ticket_Category_Description")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketCategoryEffectiveEndDatetime)
                    .HasColumnName("Ticket_Category_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketCategoryEffectiveStartDatetime)
                    .HasColumnName("Ticket_Category_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketCategoryName)
                    .HasColumnName("Ticket_Category_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketCategoryNk)
                    .IsRequired()
                    .HasColumnName("Ticket_Category_NK")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TicketCategoryRecordCreatedBy)
                    .HasColumnName("Ticket_Category_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketCategoryRecordCreatedDatetime)
                    .HasColumnName("Ticket_Category_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketCategoryRecordUpdatedBy)
                    .HasColumnName("Ticket_Category_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketCategoryRecordUpdatedDatetime)
                    .HasColumnName("Ticket_Category_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketCategorySourceSystemName)
                    .HasColumnName("Ticket_Category_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketSubcategoryActive).HasColumnName("Ticket_Subcategory_Active");

                entity.Property(e => e.TicketSubcategoryDescription)
                    .HasColumnName("Ticket_Subcategory_Description")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketSubcategoryName)
                    .HasColumnName("Ticket_Subcategory_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimTicketQueue>(entity =>
            {
                entity.HasKey(e => e.TicketQueueKey)
                    .HasName("PK_DIM_TICKET_QUEUE");

                entity.ToTable("DIM_TICKET_QUEUE");

                entity.Property(e => e.TicketQueueKey)
                    .HasColumnName("ticket_queue_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicketQueueActiveFlag).HasColumnName("ticket_queue_active_flag");

                entity.Property(e => e.TicketQueueCurrentRecordFlag).HasColumnName("ticket_queue_current_record_flag");

                entity.Property(e => e.TicketQueueDescription)
                    .HasColumnName("ticket_queue_description")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketQueueEffectiveEndDatetime)
                    .HasColumnName("ticket_queue_effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketQueueEffectiveStartDatetime)
                    .HasColumnName("ticket_queue_effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketQueueName)
                    .HasColumnName("ticket_queue_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TicketQueueNk)
                    .HasColumnName("ticket_queue_nk")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TicketQueuePrivateFlag).HasColumnName("ticket_queue_private_flag");

                entity.Property(e => e.TicketQueueRecordCreatedBy)
                    .HasColumnName("ticket_queue_record_created_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketQueueRecordCreatedDatetime)
                    .HasColumnName("ticket_queue_record_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketQueueRecordUpdatedBy)
                    .HasColumnName("ticket_queue_record_updated_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketQueueRecordUpdatedDatetime)
                    .HasColumnName("ticket_queue_record_updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketQueueSourceSystemName)
                    .HasColumnName("ticket_queue_source_system_name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<DimTicketRatingCategory>(entity =>
            {
                entity.HasKey(e => e.TicketRatingCategoryKey)
                    .HasName("PK_Dim_icket_Rating_Category");

                entity.ToTable("dim_ticket_rating_category");

                entity.Property(e => e.TicketRatingCategoryKey).HasColumnName("Ticket_Rating_Category_Key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.EffectiveEndDatetime)
                    .HasColumnName("Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffectiveStartDatetime)
                    .HasColumnName("Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDatetime)
                    .HasColumnName("Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketRatingCategoryActive).HasColumnName("Ticket_Rating_Category_Active");

                entity.Property(e => e.TicketRatingCategoryBetaProgram)
                    .HasColumnName("Ticket_Rating_Category_Beta_Program")
                    .HasMaxLength(100);

                entity.Property(e => e.TicketRatingCategoryCategoryId).HasColumnName("Ticket_Rating_Category_Category_id");

                entity.Property(e => e.TicketRatingCategoryDescription)
                    .HasColumnName("Ticket_Rating_Category_Description")
                    .HasMaxLength(300);

                entity.Property(e => e.TicketRatingCategoryNk)
                    .HasColumnName("Ticket_Rating_Category_NK")
                    .HasMaxLength(50);

                entity.Property(e => e.TicketRatingCategorySourceSystemName)
                    .HasColumnName("Ticket_Rating_Category_Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimTicketState>(entity =>
            {
                entity.HasKey(e => e.TicketStateKey)
                    .HasName("PK_DIM_TICKET_STATE");

                entity.ToTable("DIM_TICKET_STATE");

                entity.Property(e => e.TicketStateKey)
                    .HasColumnName("ticket_state_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicketDifficultyDesc)
                    .HasColumnName("ticket_difficulty_desc")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.TicketDifficultyValue).HasColumnName("ticket_difficulty_value");

                entity.Property(e => e.TicketPriorityDesc)
                    .HasColumnName("ticket_priority_desc")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketPriorityValue)
                    .HasColumnName("ticket_priority_value")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.TicketSeverityDesc)
                    .HasColumnName("ticket_severity_desc")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketSeverityValue)
                    .HasColumnName("ticket_severity_value")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.TicketStateCurrentRecordFlag).HasColumnName("ticket_state_current_record_flag");

                entity.Property(e => e.TicketStateEffectiveEndDatetime)
                    .HasColumnName("ticket_state_effective_end_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStateEffectiveStartDatetime)
                    .HasColumnName("ticket_state_effective_start_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStateNk)
                    .IsRequired()
                    .HasColumnName("ticket_state_nk")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketStateRecordCreatedBy)
                    .HasColumnName("ticket_state_record_created_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketStateRecordCreatedDatetime)
                    .HasColumnName("ticket_state_record_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStateRecordUpdatedBy)
                    .HasColumnName("ticket_state_record_updated_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketStateRecordUpdatedDatetime)
                    .HasColumnName("ticket_state_record_updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStateSourceSystemName)
                    .HasColumnName("ticket_state_source_system_name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimTicketStatus>(entity =>
            {
                entity.HasKey(e => e.TicketStatusKey)
                    .HasName("PK_DIM_TICKET_STATUS");

                entity.ToTable("DIM_TICKET_STATUS");

                entity.Property(e => e.TicketStatusKey)
                    .HasColumnName("TICKET_STATUS_KEY")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicketStatusActiveFlag).HasColumnName("TICKET_STATUS_ACTIVE_FLAG");

                entity.Property(e => e.TicketStatusCurrentRecordFlag).HasColumnName("TICKET_STATUS_CURRENT_RECORD_FLAG");

                entity.Property(e => e.TicketStatusDescription)
                    .HasColumnName("TICKET_STATUS_DESCRIPTION")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketStatusEffectiveEndDatetime)
                    .HasColumnName("TICKET_STATUS_EFFECTIVE_END_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStatusEffectiveStartDatetime)
                    .HasColumnName("TICKET_STATUS_EFFECTIVE_START_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStatusName)
                    .HasColumnName("TICKET_STATUS_NAME")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketStatusNk)
                    .IsRequired()
                    .HasColumnName("TICKET_STATUS_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketStatusQueueId)
                    .HasColumnName("TICKET_STATUS_QUEUE_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketStatusQueueName)
                    .HasColumnName("TICKET_STATUS_QUEUE_NAME")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketStatusRecordCreatedBy)
                    .HasColumnName("TICKET_STATUS_RECORD_CREATED_BY")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketStatusRecordCreatedDatetime)
                    .HasColumnName("TICKET_STATUS_RECORD_CREATED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStatusRecordUpdatedBy)
                    .HasColumnName("TICKET_STATUS_RECORD_UPDATED_BY")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TicketStatusRecordUpdatedDatetime)
                    .HasColumnName("TICKET_STATUS_RECORD_UPDATED_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketStatusSourceSystemName)
                    .HasColumnName("TICKET_STATUS_SOURCE_SYSTEM_NAME")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<DimTicketWorkType>(entity =>
            {
                entity.HasKey(e => e.TicketWorkTypeKey)
                    .HasName("PK_Dim_Ticket_WorkType");

                entity.ToTable("Dim_Ticket_WorkType");

                entity.Property(e => e.TicketWorkTypeKey)
                    .HasColumnName("Ticket_WorkType_KEY")
                    .ValueGeneratedNever();

                entity.Property(e => e.TicketWorkTypeActive).HasColumnName("Ticket_WorkType_Active");

                entity.Property(e => e.TicketWorkTypeCurrentRecord).HasColumnName("Ticket_WorkType_Current_Record");

                entity.Property(e => e.TicketWorkTypeDescription)
                    .HasColumnName("Ticket_WorkType_Description")
                    .HasColumnType("varchar(1024)");

                entity.Property(e => e.TicketWorkTypeEffectiveEndDatetime)
                    .HasColumnName("Ticket_WorkType_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketWorkTypeEffectiveStartDatetime)
                    .HasColumnName("Ticket_WorkType_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketWorkTypeName)
                    .HasColumnName("Ticket_WorkType_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketWorkTypeNk)
                    .HasColumnName("Ticket_WorkType_NK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketWorkTypeRecordCreatedAt)
                    .HasColumnName("Ticket_WorkType_record_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketWorkTypeRecordCreatedBy)
                    .HasColumnName("Ticket_WorkType_record_created_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketWorkTypeRecordUpdatedAt)
                    .HasColumnName("Ticket_WorkType_record_updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.TicketWorkTypeRecordUpdatedBy)
                    .HasColumnName("Ticket_WorkType_record_updated_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TicketWorkTypeSourceSystemName)
                    .HasColumnName("Ticket_WorkType_Source_System_Name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<DimTime>(entity =>
            {
                entity.HasKey(e => e.TimeKey)
                    .HasName("PK_Dim_Time");

                entity.ToTable("dim_time");

                entity.HasIndex(e => e.TimeDayNumber)
                    .HasName("NCI_TIme_Day_Number");

                entity.HasIndex(e => e.TimeFullDate)
                    .HasName("NCI_Time_Full_Date");

                entity.HasIndex(e => e.TimeMonthNumber)
                    .HasName("NCI_Time_Month_Number");

                entity.HasIndex(e => e.TimeQuarterNumber)
                    .HasName("NCI_Time_Month_Quarter");

                entity.HasIndex(e => e.TimeYearMonthKey)
                    .HasName("NCI_Time_Year_Month_Key");

                entity.HasIndex(e => new { e.TimeMonthNumber, e.TimeYearNumber })
                    .HasName("idx_time_month_and_year_number");

                entity.HasIndex(e => new { e.TimeYearMonthKey, e.TimeLastDayMonthFlag })
                    .HasName("NCI_Dim_Time_Year_Month_Key");

                entity.HasIndex(e => new { e.TimeYearNumber, e.TimeMonthNumber, e.TimeLastDayMonthFlag, e.TimeMonthDesc })
                    .HasName("NCI_Dim_Time");

                entity.Property(e => e.TimeKey)
                    .HasColumnName("Time_KEY")
                    .ValueGeneratedNever();

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecAdded)
                    .HasColumnName("Rec_Added")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdated)
                    .HasColumnName("Rec_Updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeBusinessDayNumber).HasColumnName("Time_Business_Day_Number");

                entity.Property(e => e.TimeDayNumber).HasColumnName("Time_Day_Number");

                entity.Property(e => e.TimeDayOfWeek)
                    .IsRequired()
                    .HasColumnName("Time_Day_Of_Week")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.TimeDayWeek).HasColumnName("Time_Day_Week");

                entity.Property(e => e.TimeDayYr).HasColumnName("time_day_yr");

                entity.Property(e => e.TimeFullDate)
                    .HasColumnName("Time_Full_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.TimeLastDayMonthFlag).HasColumnName("Time_Last_Day_Month_Flag");

                entity.Property(e => e.TimeMonthAbbr)
                    .IsRequired()
                    .HasColumnName("Time_Month_Abbr")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.TimeMonthDesc)
                    .IsRequired()
                    .HasColumnName("Time_Month_Desc")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TimeMonthNumber).HasColumnName("Time_Month_Number");

                entity.Property(e => e.TimeQuarterDesc)
                    .IsRequired()
                    .HasColumnName("Time_Quarter_Desc")
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.TimeQuarterNumber).HasColumnName("Time_Quarter_Number");

                entity.Property(e => e.TimeWeekMonthNumber).HasColumnName("Time_Week_Month_Number");

                entity.Property(e => e.TimeWeekYearNumber).HasColumnName("Time_Week_Year_Number");

                entity.Property(e => e.TimeYearMonthKey).HasColumnName("Time_Year_Month_Key");

                entity.Property(e => e.TimeYearNumber).HasColumnName("Time_Year_Number");
            });

            modelBuilder.Entity<DimTimezone>(entity =>
            {
                entity.HasKey(e => e.TimezoneKey)
                    .HasName("PK_Dim_Timezone");

                entity.ToTable("Dim_Timezone");

                entity.Property(e => e.TimezoneKey).HasColumnName("Timezone_key");

                entity.Property(e => e.CurrentRecord).HasColumnName("Current_Record");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveEndDatetime)
                    .HasColumnName("Record_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordEffectiveStartDatetime)
                    .HasColumnName("Record_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TimezoneAbbreviation)
                    .HasColumnName("Timezone_Abbreviation")
                    .HasMaxLength(50);

                entity.Property(e => e.TimezoneConversionText)
                    .HasColumnName("Timezone_Conversion_Text")
                    .HasMaxLength(225);

                entity.Property(e => e.TimezoneDescription)
                    .HasColumnName("Timezone_Description")
                    .HasMaxLength(225);

                entity.Property(e => e.TimezoneIdNk)
                    .HasColumnName("TimezoneID_NK")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TimezoneRegion)
                    .HasColumnName("Timezone_Region")
                    .HasMaxLength(100);

                entity.Property(e => e.TimezoneUtcOffset)
                    .HasColumnName("Timezone_UTC_Offset")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<DimUnitOfMeasure>(entity =>
            {
                entity.HasKey(e => e.UnitOfMeasureKey)
                    .HasName("PK_Dim_Unit_of_Measure");

                entity.ToTable("Dim_Unit_of_Measure");

                entity.Property(e => e.UnitOfMeasureKey)
                    .HasColumnName("Unit_of_Measure_KEY")
                    .ValueGeneratedNever();

                entity.Property(e => e.UnitOfMeasureAbbreviation)
                    .HasColumnName("Unit_of_Measure_Abbreviation")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UnitOfMeasureCurrentRecordFlag).HasColumnName("Unit_of_Measure_Current_Record_Flag");

                entity.Property(e => e.UnitOfMeasureDescription)
                    .HasColumnName("Unit_of_Measure_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UnitOfMeasureEffectiveEndDateTime)
                    .HasColumnName("Unit_of_Measure_Effective_End_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UnitOfMeasureEffectiveStartDateTime)
                    .HasColumnName("Unit_of_Measure_Effective_Start_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UnitOfMeasureName)
                    .HasColumnName("Unit_of_Measure_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UnitOfMeasureNk).HasColumnName("Unit_of_Measure_NK");

                entity.Property(e => e.UnitOfMeasureRecordCreatedBy)
                    .HasColumnName("Unit_of_Measure_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UnitOfMeasureRecordCreatedDateTime)
                    .HasColumnName("Unit_of_Measure_Record_Created_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UnitOfMeasureRecordUpdatedBy)
                    .HasColumnName("Unit_of_Measure_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UnitOfMeasureRecordUpdatedDateTime)
                    .HasColumnName("Unit_of_Measure_Record_Updated_DateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimVisitor>(entity =>
            {
                entity.HasKey(e => e.VisitorKey)
                    .HasName("visitor_key_indx");

                entity.ToTable("dim_visitor");

                entity.Property(e => e.VisitorKey)
                    .HasColumnName("visitor_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.VisitorCreatedBy)
                    .HasColumnName("visitor_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorCreatedDatetime)
                    .HasColumnName("visitor_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitorId)
                    .IsRequired()
                    .HasColumnName("visitor_id")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorRackuid)
                    .IsRequired()
                    .HasColumnName("visitor_rackuid")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSourceSystemColumn)
                    .HasColumnName("visitor_source_system_column")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorSourceSystemIdNk)
                    .IsRequired()
                    .HasColumnName("visitor_source_system_id_nk")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSourceSystemName)
                    .HasColumnName("visitor_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorUpdatedBy)
                    .HasColumnName("visitor_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorUpdatedDatetime)
                    .HasColumnName("visitor_updated_datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimVisitorIp>(entity =>
            {
                entity.HasKey(e => e.VisitorIpKey)
                    .HasName("visitor_ip_key_indx");

                entity.ToTable("dim_visitor_ip");

                entity.Property(e => e.VisitorIpKey)
                    .HasColumnName("visitor_ip_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.VisitorIp)
                    .IsRequired()
                    .HasColumnName("visitor_ip")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorIpCreatedBy)
                    .HasColumnName("visitor_ip_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorIpCreatedDatetime)
                    .HasColumnName("visitor_ip_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitorIpSourceSystemColumn)
                    .HasColumnName("visitor_ip_source_system_column")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorIpSourceSystemIdNk)
                    .IsRequired()
                    .HasColumnName("visitor_ip_source_system_id_nk")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorIpSourceSystemName)
                    .HasColumnName("visitor_ip_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorIpUpdatedBy)
                    .HasColumnName("visitor_ip_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorIpUpdatedDatetime)
                    .HasColumnName("visitor_ip_updated_datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<DimVisitorSystemConfiguration>(entity =>
            {
                entity.HasKey(e => e.VisitorSystemConfigurationKey)
                    .HasName("visitor_system_configuration_key_indx");

                entity.ToTable("dim_visitor_system_configuration");

                entity.Property(e => e.VisitorSystemConfigurationKey)
                    .HasColumnName("visitor_system_configuration_key")
                    .ValueGeneratedNever();

                entity.Property(e => e.VisitorSystemConfigurationBrowserHeight)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_browser_height")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationBrowserType)
                    .HasColumnName("visitor_system_configuration_browser_type")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationBrowserWidth)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_browser_width")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationBrowsers)
                    .HasColumnName("visitor_system_configuration_browsers")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationCarrierDomain)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_carrier_domain")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationConnectionName)
                    .HasColumnName("visitor_system_configuration_connection_name")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationConnectionTypes)
                    .HasColumnName("visitor_system_configuration_connection_types")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationCookies)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_cookies")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationCreatedBy)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorSystemConfigurationCreatedDatetime)
                    .HasColumnName("visitor_system_configuration_created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitorSystemConfigurationJava)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_java")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationJavascript)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_javascript")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationJavascriptVersion)
                    .HasColumnName("visitor_system_configuration_javascript_version")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationLanguageName)
                    .HasColumnName("visitor_system_configuration_language_name")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationLanguages)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_languages")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationMobileCarrier)
                    .HasColumnName("visitor_system_configuration_mobile_carrier")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationMonitorColorDepths)
                    .HasColumnName("visitor_system_configuration_monitor_color_depths")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationMonitorResolutions)
                    .HasColumnName("visitor_system_configuration_monitor_resolutions")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationOperatingSystems)
                    .HasColumnName("visitor_system_configuration_operating_systems")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationSourceSystemColumn)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_source_system_column")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationSourceSystemIdNk)
                    .HasColumnName("visitor_system_configuration_source_system_id_nk")
                    .HasMaxLength(255);

                entity.Property(e => e.VisitorSystemConfigurationSourceSystemName)
                    .IsRequired()
                    .HasColumnName("visitor_system_configuration_source_system_name")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorSystemConfigurationUpdatedBy)
                    .HasColumnName("visitor_system_configuration_updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.VisitorSystemConfigurationUpdatedDatetime)
                    .HasColumnName("visitor_system_configuration_updated_datetime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<EntityMatch>(entity =>
            {
                entity.ToTable("Entity_Match");

                entity.HasIndex(e => e.EntityNumber1)
                    .HasName("IX_Entity_Number_1");

                entity.HasIndex(e => e.EntityNumber2)
                    .HasName("IX_Entity_Number_2");

                entity.HasIndex(e => new { e.EntityType, e.EntityNumber1, e.EntitySource1, e.EntityNumber2, e.EntitySource2 })
                    .HasName("IDX_Match");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DwTimestamp)
                    .HasColumnName("dw_timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.EntityNumber1).HasColumnName("Entity_Number1");

                entity.Property(e => e.EntityNumber2).HasColumnName("Entity_Number2");

                entity.Property(e => e.EntitySource1)
                    .HasColumnName("Entity_Source1")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EntitySource2)
                    .HasColumnName("Entity_Source2")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EntityType).HasColumnType("varchar(50)");

                entity.Property(e => e.MatchPriority)
                    .HasColumnName("Match_Priority")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MatchRule)
                    .HasColumnName("Match_Rule")
                    .HasColumnType("varchar(400)");

                entity.Property(e => e.MatchTime)
                    .HasColumnName("Match_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<FactAccountContactDetail>(entity =>
            {
                entity.HasKey(e => new { e.TransactionId, e.StartTimeKey, e.StartHmsKey, e.EndTimeKey, e.EndHmsKey, e.SourceSystemKey })
                    .HasName("PK_Fact_Account_Contact_Detail");

                entity.ToTable("fact_account_contact_detail");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_ID")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.StartTimeKey).HasColumnName("Start_Time_key");

                entity.Property(e => e.StartHmsKey).HasColumnName("Start_HMS_Key");

                entity.Property(e => e.EndTimeKey).HasColumnName("End_Time_Key");

                entity.Property(e => e.EndHmsKey).HasColumnName("End_HMS_Key");

                entity.Property(e => e.SourceSystemKey).HasColumnName("Source_System_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_Key");

                entity.Property(e => e.ContactRoleKey).HasColumnName("Contact_Role_Key");

                entity.Property(e => e.MeasureActiveContactCount).HasColumnName("Measure_Active_Contact_Count");

                entity.Property(e => e.MeasureAssignmentDurationSeconds).HasColumnName("Measure_Assignment_Duration_Seconds");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_Count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_key");
            });

            modelBuilder.Entity<FactAccountContactMonthlyCurrentMonth>(entity =>
            {
                entity.HasKey(e => new { e.AccountContactMonthlyTimeKey, e.AccountContactMonthlyAccountKey, e.AccountContactMonthlyContactKey, e.AccountContactMonthlyContactRoleKey })
                    .HasName("PK_Fact_Account_Contact_Monthly_Current_Month");

                entity.ToTable("Fact_Account_Contact_Monthly_Current_Month");

                entity.HasIndex(e => e.AccountContactMonthlyAccountKey)
                    .HasName("ix_fact_account_contact_monthly_current_month_account");

                entity.HasIndex(e => e.AccountContactMonthlyContactKey)
                    .HasName("ix_fact_account_contact_monthly_current_month_contact");

                entity.HasIndex(e => e.AccountContactMonthlyContactRoleKey)
                    .HasName("ix_fact_account_contact_monthly_current_contact_role");

                entity.HasIndex(e => new { e.AccountContactMonthlyRecordCreatedDatetime, e.AccountContactMonthlyRecordUpdatedDatetime, e.AccountContactMonthlyTimeKey, e.AccountContactMonthlyAccountKey, e.AccountContactMonthlyContactKey, e.AccountContactMonthlyContactRoleKey })
                    .HasName("IX__Account Contacts - Billing");

                entity.Property(e => e.AccountContactMonthlyTimeKey).HasColumnName("Account_Contact_Monthly_Time_Key");

                entity.Property(e => e.AccountContactMonthlyAccountKey).HasColumnName("Account_Contact_Monthly_Account_Key");

                entity.Property(e => e.AccountContactMonthlyContactKey).HasColumnName("Account_Contact_Monthly_Contact_Key");

                entity.Property(e => e.AccountContactMonthlyContactRoleKey).HasColumnName("Account_Contact_Monthly_Contact_Role_Key");

                entity.Property(e => e.AccountContactMonthlyRecordCount).HasColumnName("Account_Contact_Monthly_Record_Count");

                entity.Property(e => e.AccountContactMonthlyRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Account_Contact_Monthly_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountContactMonthlyRecordCreatedDatetime)
                    .HasColumnName("Account_Contact_Monthly_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountContactMonthlyRecordSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Account_Contact_Monthly_Record_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountContactMonthlyRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Account_Contact_Monthly_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountContactMonthlyRecordUpdatedDatetime)
                    .HasColumnName("Account_Contact_Monthly_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountContactMonthlyTimeAssignedKey).HasColumnName("Account_Contact_Monthly_Time_Assigned_Key");
            });

            modelBuilder.Entity<FactAccountContactMonthlyHistory>(entity =>
            {
                entity.HasKey(e => new { e.AccountContactMonthlyTimeKey, e.AccountContactMonthlyAccountKey, e.AccountContactMonthlyContactKey, e.AccountContactMonthlyContactRoleKey })
                    .HasName("PK_Fact_Account_Contact_Monthly");

                entity.ToTable("fact_account_contact_monthly_history");

                entity.HasIndex(e => e.AccountContactMonthlyAccountKey)
                    .HasName("ix_fact_account_contact_monthly_hist_account");

                entity.HasIndex(e => e.AccountContactMonthlyContactKey)
                    .HasName("ix_fact_account_contact_monthly_hist_contact");

                entity.HasIndex(e => e.AccountContactMonthlyContactRoleKey)
                    .HasName("ix_fact_account_contact_monthly_hist_contact_role");

                entity.Property(e => e.AccountContactMonthlyTimeKey).HasColumnName("Account_Contact_Monthly_Time_Key");

                entity.Property(e => e.AccountContactMonthlyAccountKey).HasColumnName("Account_Contact_Monthly_Account_Key");

                entity.Property(e => e.AccountContactMonthlyContactKey).HasColumnName("Account_Contact_Monthly_Contact_Key");

                entity.Property(e => e.AccountContactMonthlyContactRoleKey).HasColumnName("Account_Contact_Monthly_Contact_Role_Key");

                entity.Property(e => e.AccountContactMonthlyRecordCount).HasColumnName("Account_Contact_Monthly_Record_Count");

                entity.Property(e => e.AccountContactMonthlyRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Account_Contact_Monthly_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountContactMonthlyRecordCreatedDatetime)
                    .HasColumnName("Account_Contact_Monthly_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountContactMonthlyRecordSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Account_Contact_Monthly_Record_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountContactMonthlyRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Account_Contact_Monthly_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountContactMonthlyRecordUpdatedDatetime)
                    .HasColumnName("Account_Contact_Monthly_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountContactMonthlyTimeAssignedKey).HasColumnName("Account_Contact_Monthly_Time_Assigned_Key");
            });

            modelBuilder.Entity<FactAccountDevice>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey })
                    .HasName("PK_Fact_Account_Device");

                entity.ToTable("fact_account_device");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_ACCOUNT_KEY");

                entity.HasIndex(e => e.MeasureRecordCount)
                    .HasName("IX_DEVICE_KEY");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_TEAM_KEY");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_TIME_KEY");

                entity.HasIndex(e => e.TimeMonthKey)
                    .HasName("IX_TIME_MONTH_KEY");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.MeasureRecordCount).HasColumnName("measure_Record_Count");

                entity.Property(e => e.TimeMonthKey).HasColumnName("Time_Month_KEY");
            });

            modelBuilder.Entity<FactAccountProductPriceDailySnapshot>(entity =>
            {
                entity.HasKey(e => e.AccountProductPriceDailySnapshotKey)
                    .HasName("PK_Fact_Account_Product");

                entity.ToTable("Fact_Account_Product_Price_Daily_Snapshot");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_Time_Key");

                entity.HasIndex(e => e.UnitOfMeasureKey)
                    .HasName("IX_UOM_KEY");

                entity.Property(e => e.AccountProductPriceDailySnapshotKey).HasColumnName("Account_Product_Price_Daily_Snapshot_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.AccountProductPriceDailySnapshotAmount)
                    .HasColumnName("Account_Product_Price_Daily_Snapshot_Amount")
                    .HasColumnType("numeric");

                entity.Property(e => e.AccountProductPriceDailySnapshotQuantity)
                    .HasColumnName("Account_Product_Price_Daily_Snapshot_Quantity")
                    .HasColumnType("numeric");

                entity.Property(e => e.AccountProductPriceDailySnapshotRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Account_Product_Price_Daily_Snapshot_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountProductPriceDailySnapshotRecordCreatedDatetime)
                    .HasColumnName("Account_Product_Price_Daily_Snapshot_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountProductPriceDailySnapshotRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Account_Product_Price_Daily_Snapshot_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountProductPriceDailySnapshotRecordUpdatedDatetime)
                    .HasColumnName("Account_Product_Price_Daily_Snapshot_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountProductPriceDailySnapshotSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Account_Product_Price_Daily_Snapshot_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.ProductKey).HasColumnName("Product_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_of_Measure_Key");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactAccountProductPriceDailySnapshot)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Account_Product_Price_Daily_Snapshot_Dim_Account");
            });

            modelBuilder.Entity<FactAccountStatus>(entity =>
            {
                entity.HasKey(e => new { e.AccountKey, e.StatusKey, e.TeamKey, e.AccountStatusDateCstKey, e.AccountStatusHmsCstKey, e.AccountStatusDateUtcKey, e.AccountStatusHmsUtcKey, e.AccountStatusMilliSecKey })
                    .HasName("PK_FACT_ACCOUNT_STATUS");

                entity.ToTable("Fact_Account_Status");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("Account_Key_indx");

                entity.HasIndex(e => e.AccountStatusDateCstKey)
                    .HasName("Account_Status_Date_CST_Key_indx");

                entity.HasIndex(e => e.AccountStatusDateUtcKey)
                    .HasName("Account_Status_Date_UTC_Key_indx");

                entity.HasIndex(e => e.AccountStatusHmsCstKey)
                    .HasName("Account_Status_HMS_CST_Key_indx");

                entity.HasIndex(e => e.AccountStatusHmsUtcKey)
                    .HasName("Account_Status_HMS_UTC_Key_indx");

                entity.HasIndex(e => e.StatusKey)
                    .HasName("Status_Key_indx");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("Team_Key_indx");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.StatusKey).HasColumnName("Status_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.AccountStatusDateCstKey).HasColumnName("Account_Status_Date_CST_Key");

                entity.Property(e => e.AccountStatusHmsCstKey).HasColumnName("Account_Status_HMS_CST_Key");

                entity.Property(e => e.AccountStatusDateUtcKey).HasColumnName("Account_Status_Date_UTC_Key");

                entity.Property(e => e.AccountStatusHmsUtcKey).HasColumnName("Account_Status_HMS_UTC_Key");

                entity.Property(e => e.AccountStatusMilliSecKey).HasColumnName("Account_Status_MilliSec_Key");

                entity.Property(e => e.AccountStatusCounter).HasColumnName("Account_Status_Counter");

                entity.Property(e => e.AccountStatusRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Account_Status_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountStatusRecordCreatedDatetime)
                    .HasColumnName("Account_Status_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountStatusRecordSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Account_Status_Record_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.AccountStatusDateCstKeyNavigation)
                    .WithMany(p => p.FactAccountStatusAccountStatusDateCstKeyNavigation)
                    .HasForeignKey(d => d.AccountStatusDateCstKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Fact_Acco__Accou__68D05D81");

                entity.HasOne(d => d.AccountStatusDateUtcKeyNavigation)
                    .WithMany(p => p.FactAccountStatusAccountStatusDateUtcKeyNavigation)
                    .HasForeignKey(d => d.AccountStatusDateUtcKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Fact_Acco__Accou__6AB8A5F3");

                entity.HasOne(d => d.AccountStatusHmsCstKeyNavigation)
                    .WithMany(p => p.FactAccountStatusAccountStatusHmsCstKeyNavigation)
                    .HasForeignKey(d => d.AccountStatusHmsCstKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Fact_Acco__Accou__69C481BA");

                entity.HasOne(d => d.AccountStatusHmsUtcKeyNavigation)
                    .WithMany(p => p.FactAccountStatusAccountStatusHmsUtcKeyNavigation)
                    .HasForeignKey(d => d.AccountStatusHmsUtcKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Fact_Acco__Accou__6BACCA2C");

                entity.HasOne(d => d.StatusKeyNavigation)
                    .WithMany(p => p.FactAccountStatus)
                    .HasForeignKey(d => d.StatusKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Fact_Acco__Statu__66E8150F");

                entity.HasOne(d => d.TeamKeyNavigation)
                    .WithMany(p => p.FactAccountStatus)
                    .HasForeignKey(d => d.TeamKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__Fact_Acco__Team___67DC3948");
            });

            modelBuilder.Entity<FactAvThreat>(entity =>
            {
                entity.HasKey(e => e.ThreatId)
                    .HasName("PK_Fact_AV_Threat");

                entity.ToTable("Fact_AV_Threat");

                entity.HasIndex(e => new { e.AccountKey, e.TeamKey, e.DeviceKey, e.ThreatKey, e.ActionKey, e.PathKey, e.ThreatEventId, e.AvThreatSourceName })
                    .HasName("ix_Fact_AV_Threat_Composite");

                entity.Property(e => e.ThreatId).HasColumnName("Threat_ID");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.ActionKey).HasColumnName("Action_Key");

                entity.Property(e => e.AvThreatRecordCreatedBy)
                    .HasColumnName("AV_Threat_Record_Created_By")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.AvThreatRecordCreatedDate)
                    .HasColumnName("AV_Threat_Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AvThreatRecordUpdatedBy)
                    .HasColumnName("AV_Threat_Record_Updated_By")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.AvThreatRecordUpdatedDate)
                    .HasColumnName("AV_Threat_Record_Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AvThreatSourceName)
                    .HasColumnName("AV_Threat_Source_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.PathKey).HasColumnName("Path_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.ThreatActionDateHmsKey).HasColumnName("Threat_Action_Date_HMS_Key");

                entity.Property(e => e.ThreatActionDateKey).HasColumnName("Threat_Action_Date_Key");

                entity.Property(e => e.ThreatActionLocalDateHmsKey).HasColumnName("Threat_Action_Local_Date_HMS_Key");

                entity.Property(e => e.ThreatActionLocalDateKey).HasColumnName("Threat_Action_Local_Date_Key");

                entity.Property(e => e.ThreatCount).HasColumnName("Threat_Count");

                entity.Property(e => e.ThreatDetectedDateHmsKey).HasColumnName("Threat_Detected_Date_HMS_Key");

                entity.Property(e => e.ThreatDetectedDateKey).HasColumnName("Threat_Detected_Date_Key");

                entity.Property(e => e.ThreatDetectedLocalDateHmsKey).HasColumnName("Threat_Detected_Local_Date_HMS_Key");

                entity.Property(e => e.ThreatDetectedLocalDateKey).HasColumnName("Threat_Detected_Local_Date_Key");

                entity.Property(e => e.ThreatEventId)
                    .HasColumnName("Threat_Event_ID")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.ThreatKey).HasColumnName("Threat_Key");

                entity.Property(e => e.ThreatTypeKey).HasColumnName("Threat_Type_Key");

                entity.Property(e => e.Username).HasMaxLength(256);
            });

            modelBuilder.Entity<FactBandwidth>(entity =>
            {
                entity.HasKey(e => new { e.BandwidthAccountKey, e.BandwidthTeamKey, e.BandwidthTimeKey, e.BandwidthDeviceKey })
                    .HasName("PK_Fact_Bandwidth");

                entity.ToTable("fact_bandwidth");

                entity.HasIndex(e => e.BandwidthAccountKey)
                    .HasName("ix_Bandwidth_Account_Key");

                entity.HasIndex(e => e.BandwidthDeviceKey)
                    .HasName("ix_Bandwidth_Device_Key");

                entity.HasIndex(e => e.BandwidthTeamKey)
                    .HasName("ix_Bandwidth_Team_Key");

                entity.HasIndex(e => e.BandwidthTimeKey)
                    .HasName("ix_Bandwidth_Time_Key");

                entity.Property(e => e.BandwidthAccountKey).HasColumnName("Bandwidth_Account_Key");

                entity.Property(e => e.BandwidthTeamKey).HasColumnName("Bandwidth_Team_Key");

                entity.Property(e => e.BandwidthTimeKey).HasColumnName("Bandwidth_Time_Key");

                entity.Property(e => e.BandwidthDeviceKey).HasColumnName("Bandwidth_Device_Key");

                entity.Property(e => e.BandwidthRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Bandwidth_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.BandwidthRecordCreatedDatetime)
                    .HasColumnName("Bandwidth_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BandwidthRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Bandwidth_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.BandwidthRecordUpdatedDatetime)
                    .HasColumnName("Bandwidth_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.BandwidthSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Bandwidth_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.GigabytesSubscription).HasColumnName("Gigabytes_Subscription");

                entity.Property(e => e.GigabytesUsed).HasColumnName("Gigabytes_Used");
            });

            modelBuilder.Entity<FactCreditMemoAppr>(entity =>
            {
                entity.HasKey(e => e.CreditMemoApprKey)
                    .HasName("PK_Fact_Credit_Memo_Appr");

                entity.ToTable("fact_credit_memo_appr");

                entity.Property(e => e.CreditMemoApprKey).HasColumnName("Credit_Memo_Appr_Key");

                entity.Property(e => e.ApprovalDateKey).HasColumnName("Approval_Date_Key");

                entity.Property(e => e.ApprovalHmsKey).HasColumnName("Approval_HMS_Key");

                entity.Property(e => e.ApprovedByKey).HasColumnName("Approved_By_Key");

                entity.Property(e => e.CreditMemoNk).HasColumnName("Credit_Memo_NK");

                entity.Property(e => e.RecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordUpdatedDate)
                    .HasColumnName("Record_Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .IsRequired()
                    .HasColumnName("Source_System_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FactCreditMemoLog>(entity =>
            {
                entity.HasKey(e => e.CreditMemoLogKey)
                    .HasName("PK_Fact_Credit_Memo_Log");

                entity.ToTable("Fact_Credit_Memo_Log");

                entity.Property(e => e.CreditMemoLogKey).HasColumnName("Credit_Memo_Log_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.ClosedDateKey).HasColumnName("Closed_Date_Key");

                entity.Property(e => e.CreditDeviceKey).HasColumnName("Credit_Device_Key");

                entity.Property(e => e.CreditEventDateKey).HasColumnName("Credit_Event_Date_Key");

                entity.Property(e => e.CreditEventHmsKey).HasColumnName("Credit_Event_HMS_Key");

                entity.Property(e => e.CreditMemoAmount)
                    .HasColumnName("Credit_Memo_Amount")
                    .HasColumnType("numeric");

                entity.Property(e => e.CreditMemoAttributeKey).HasColumnName("Credit_Memo_Attribute_Key");

                entity.Property(e => e.CreditMemoId).HasColumnName("Credit_Memo_ID");

                entity.Property(e => e.CreditMemoIncidentId)
                    .HasColumnName("CREDIT_MEMO_INCIDENT_ID")
                    .HasMaxLength(255);

                entity.Property(e => e.CreditMemoInvoiceCauseId)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Invoice_Cause_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CreditMemoLogId).HasColumnName("Credit_Memo_Log_ID");

                entity.Property(e => e.CreditMemoLogTypeKey).HasColumnName("Credit_Memo_Log_Type_Key");

                entity.Property(e => e.CreditMemoRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Record_Created_By")
                    .HasMaxLength(100);

                entity.Property(e => e.CreditMemoRecordCreatedDatetime)
                    .HasColumnName("Credit_Memo_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Credit_Memo_Record_Updated_By")
                    .HasMaxLength(100);

                entity.Property(e => e.CreditMemoRecordUpdatedDatetime)
                    .HasColumnName("Credit_Memo_Record_Updated_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.CreditMemoRecordValidFlag).HasColumnName("Credit_Memo_Record_Valid_Flag");

                entity.Property(e => e.CreditMemoTicketCauseId).HasColumnName("Credit_Memo_Ticket_Cause_ID");

                entity.Property(e => e.CreditMemoTicketId).HasColumnName("Credit_Memo_Ticket_ID");

                entity.Property(e => e.DepartmentKey).HasColumnName("Department_Key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_Key");

                entity.Property(e => e.LogUserKey).HasColumnName("Log_User_Key");

                entity.Property(e => e.ProductKey).HasColumnName("Product_Key");

                entity.Property(e => e.SlaSectionNumber)
                    .HasColumnName("Sla_Section_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.StatusKey).HasColumnName("Status_Key");

                entity.Property(e => e.SubmittedDateKey).HasColumnName("Submitted_Date_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");
            });

            modelBuilder.Entity<FactDeptCreditMemo>(entity =>
            {
                entity.HasKey(e => e.DeptCreditMemoKey)
                    .HasName("PK_Fact_Dept_Credit_Memo_1");

                entity.ToTable("fact_dept_credit_memo");

                entity.Property(e => e.DeptCreditMemoKey).HasColumnName("Dept_Credit_Memo_Key");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.CreditMemoNk).HasColumnName("Credit_Memo_NK");

                entity.Property(e => e.DepartmentKey).HasColumnName("Department_Key");

                entity.Property(e => e.DepartmentNk).HasColumnName("Department_NK");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_Key");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordUpdatedDate)
                    .HasColumnName("Record_Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_System_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");
            });

            modelBuilder.Entity<FactDeviceBuildError>(entity =>
            {
                entity.HasKey(e => new { e.DeviceBuildErrorId, e.DeviceBuildErrorTimeKey, e.DeviceBuildErrorHmsKey, e.DeviceBuildErrorAccountKey, e.DeviceBuildErrorTeamKey, e.DeviceBuildErrorDeviceKey, e.DeviceBuildErrorBuildErrorTypeKey, e.DeviceBuildErrorBuildErrorSeverityTypeKey })
                    .HasName("PK_Fact_Device_Build_Error");

                entity.ToTable("Fact_Device_Build_Error");

                entity.HasIndex(e => e.DeviceBuildErrorAccountKey)
                    .HasName("IX_Account_KEY");

                entity.HasIndex(e => e.DeviceBuildErrorBuildErrorSeverityTypeKey)
                    .HasName("IX_Build_Error_Severity_Type_KEY");

                entity.HasIndex(e => e.DeviceBuildErrorBuildErrorTypeKey)
                    .HasName("IX_Build_Error_Type_KEY");

                entity.HasIndex(e => e.DeviceBuildErrorDeviceKey)
                    .HasName("IX_Device_KEY");

                entity.HasIndex(e => e.DeviceBuildErrorHmsKey)
                    .HasName("IX_HMS_KEY");

                entity.HasIndex(e => e.DeviceBuildErrorTeamKey)
                    .HasName("IX_Team_KEY");

                entity.HasIndex(e => e.DeviceBuildErrorTimeKey)
                    .HasName("IX_Time_KEY");

                entity.Property(e => e.DeviceBuildErrorId)
                    .HasColumnName("Device_Build_Error_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceBuildErrorTimeKey).HasColumnName("Device_Build_Error_Time_Key");

                entity.Property(e => e.DeviceBuildErrorHmsKey).HasColumnName("Device_Build_Error_HMS_Key");

                entity.Property(e => e.DeviceBuildErrorAccountKey).HasColumnName("Device_Build_Error_Account_Key");

                entity.Property(e => e.DeviceBuildErrorTeamKey).HasColumnName("Device_Build_Error_Team_Key");

                entity.Property(e => e.DeviceBuildErrorDeviceKey).HasColumnName("Device_Build_Error_Device_Key");

                entity.Property(e => e.DeviceBuildErrorBuildErrorTypeKey).HasColumnName("Device_Build_Error_Build_Error_Type_Key");

                entity.Property(e => e.DeviceBuildErrorBuildErrorSeverityTypeKey).HasColumnName("Device_Build_Error_Build_Error_Severity_Type_Key");

                entity.Property(e => e.DeviceBuildErrorCount).HasColumnName("Device_Build_Error_Count");

                entity.Property(e => e.DeviceBuildErrorRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Device_Build_Error_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceBuildErrorRecordCreatedDatetime)
                    .HasColumnName("Device_Build_Error_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceBuildErrorRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Device_Build_Error_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceBuildErrorRecordUpdatedDatetime)
                    .HasColumnName("Device_Build_Error_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceBuildErrorSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Device_Build_Error_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.DeviceBuildErrorAccountKeyNavigation)
                    .WithMany(p => p.FactDeviceBuildError)
                    .HasForeignKey(d => d.DeviceBuildErrorAccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Device_Build_Error_Dim_Account");
            });

            modelBuilder.Entity<FactDeviceLocationDetail>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.HmsKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.DatacenterKey, e.DeviceContainerKey, e.SwitchContainerKey, e.ContainerComponentKey, e.ErwinShelfKey, e.SwitchKey, e.ReservationKey, e.SwitchPortKey, e.SwitchPortId })
                    .HasName("PK_Fact_Device_Location_Detail");

                entity.ToTable("fact_device_location_detail");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("idx_account");

                entity.HasIndex(e => e.ContainerComponentKey)
                    .HasName("idx_container_component_key");

                entity.HasIndex(e => e.DatacenterKey)
                    .HasName("idx_datacenter_key");

                entity.HasIndex(e => e.DeviceContainerKey)
                    .HasName("idx_device_container_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("idx_device_key");

                entity.HasIndex(e => e.ErwinShelfKey)
                    .HasName("idx_erwin_shelf_key");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("idx_hms_key");

                entity.HasIndex(e => e.ReservationKey)
                    .HasName("idx_reservation_key");

                entity.HasIndex(e => e.SwitchContainerKey)
                    .HasName("idx_switch_container_key");

                entity.HasIndex(e => e.SwitchKey)
                    .HasName("idx_switch_key");

                entity.HasIndex(e => e.SwitchPortId)
                    .HasName("idx_switch_port_id");

                entity.HasIndex(e => e.SwitchPortKey)
                    .HasName("idx_switch_port_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("idx_team_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("idx_time_key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.DatacenterKey).HasColumnName("Datacenter_Key");

                entity.Property(e => e.DeviceContainerKey).HasColumnName("Device_Container_key");

                entity.Property(e => e.SwitchContainerKey).HasColumnName("Switch_Container_key");

                entity.Property(e => e.ContainerComponentKey).HasColumnName("Container_Component_Key");

                entity.Property(e => e.ErwinShelfKey).HasColumnName("Erwin_Shelf_Key");

                entity.Property(e => e.SwitchKey).HasColumnName("Switch_Key");

                entity.Property(e => e.ReservationKey).HasColumnName("Reservation_Key");

                entity.Property(e => e.SwitchPortKey).HasColumnName("Switch_Port_Key");

                entity.Property(e => e.SwitchPortId)
                    .HasColumnName("Switch_Port_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordSourceKey)
                    .IsRequired()
                    .HasColumnName("Record_source_Key")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactDeviceLocationDetail)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Device_Location_Detail_Dim_Account");
            });

            modelBuilder.Entity<FactDeviceLocationMtdCurrentMonth>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.DatacenterKey, e.DeviceContainerKey, e.SwitchContainerKey, e.ContainerComponentKey, e.ErwinShelfKey, e.SwitchKey, e.ReservationKey, e.SwitchPortKey })
                    .HasName("PK_Fact_Device_Location_Mtd_Current_Month");

                entity.ToTable("Fact_Device_Location_Mtd_Current_Month");

                entity.Property(e => e.TimeKey).HasColumnName("time_key");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.DeviceKey).HasColumnName("device_key");

                entity.Property(e => e.DatacenterKey).HasColumnName("datacenter_key");

                entity.Property(e => e.DeviceContainerKey).HasColumnName("device_container_key");

                entity.Property(e => e.SwitchContainerKey).HasColumnName("switch_container_key");

                entity.Property(e => e.ContainerComponentKey).HasColumnName("container_component_key");

                entity.Property(e => e.ErwinShelfKey).HasColumnName("erwin_shelf_key");

                entity.Property(e => e.SwitchKey).HasColumnName("switch_key");

                entity.Property(e => e.ReservationKey).HasColumnName("reservation_key");

                entity.Property(e => e.SwitchPortKey).HasColumnName("switch_port_key");

                entity.Property(e => e.MeasureCount).HasColumnName("measure_count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordSourceKey)
                    .IsRequired()
                    .HasColumnName("Record_source_Key")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");
            });

            modelBuilder.Entity<FactDeviceLocationMtdHistory>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.DatacenterKey, e.DeviceContainerKey, e.SwitchContainerKey, e.ContainerComponentKey, e.ErwinShelfKey, e.SwitchKey, e.ReservationKey, e.SwitchPortKey })
                    .HasName("PK_Fact_Device_Location_Mtd");

                entity.ToTable("fact_device_location_mtd_history");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("idx_account");

                entity.HasIndex(e => e.ContainerComponentKey)
                    .HasName("idx_container_component_key");

                entity.HasIndex(e => e.DatacenterKey)
                    .HasName("idx_datacenter_key");

                entity.HasIndex(e => e.DeviceContainerKey)
                    .HasName("idx_container_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("idx_device_key");

                entity.HasIndex(e => e.ErwinShelfKey)
                    .HasName("idx_erwin_shelf_key");

                entity.HasIndex(e => e.ReservationKey)
                    .HasName("idx_reservation_key");

                entity.HasIndex(e => e.SwitchContainerKey)
                    .HasName("idx_switch_container_key");

                entity.HasIndex(e => e.SwitchKey)
                    .HasName("idx_switch_key");

                entity.HasIndex(e => e.SwitchPortKey)
                    .HasName("idx_switch_port_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("idx_team_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("idx_time_key");

                entity.Property(e => e.TimeKey).HasColumnName("time_key");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.DeviceKey).HasColumnName("device_key");

                entity.Property(e => e.DatacenterKey).HasColumnName("datacenter_key");

                entity.Property(e => e.DeviceContainerKey).HasColumnName("device_container_key");

                entity.Property(e => e.SwitchContainerKey).HasColumnName("switch_container_key");

                entity.Property(e => e.ContainerComponentKey).HasColumnName("container_component_key");

                entity.Property(e => e.ErwinShelfKey).HasColumnName("erwin_shelf_key");

                entity.Property(e => e.SwitchKey).HasColumnName("switch_key");

                entity.Property(e => e.ReservationKey).HasColumnName("reservation_key");

                entity.Property(e => e.SwitchPortKey).HasColumnName("switch_port_key");

                entity.Property(e => e.MeasureCount).HasColumnName("measure_count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordSourceKey)
                    .IsRequired()
                    .HasColumnName("Record_source_Key")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactDeviceLocationMtdHistory)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_fact_device_switch_port_location_mtd_dim_account");
            });

            modelBuilder.Entity<FactDeviceLocationReservationMtd>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TimeKey })
                    .HasName("PK_Fact_Device_Location_Reservation_MTD");

                entity.ToTable("fact_device_location_reservation_mtd");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TimeKey).HasColumnName("time_key");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.ContainerComponentKey).HasColumnName("container_component_key");

                entity.Property(e => e.ContainerKey).HasColumnName("container_key");

                entity.Property(e => e.DeviceKey).HasColumnName("device_key");

                entity.Property(e => e.ErwinShelfKey).HasColumnName("erwin_shelf_key");

                entity.Property(e => e.RecordCreated).HasColumnName("Record_Created");

                entity.Property(e => e.RecordCreatedHms).HasColumnName("Record_Created_HMS");

                entity.Property(e => e.RecordUpdated).HasColumnName("Record_Updated");

                entity.Property(e => e.RecordUpdatedHms).HasColumnName("Record_Updated_HMS");

                entity.Property(e => e.ReservationKey).HasColumnName("reservation_key");
            });

            modelBuilder.Entity<FactDeviceStatus>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.HmsKey, e.AccountKey, e.TeamKey, e.AccountStatusKey, e.DeviceKey, e.DeviceStatusKey, e.UnitOfMeasureKey })
                    .HasName("PK_Fact_Device_Status");

                entity.ToTable("fact_device_status");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("idx_account_key");

                entity.HasIndex(e => e.AccountStatusKey)
                    .HasName("idx_account_status_key");

                entity.HasIndex(e => e.ContactKey)
                    .HasName("idx_contact_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("idx_device_key");

                entity.HasIndex(e => e.DeviceNk)
                    .HasName("idx_Device_NK");

                entity.HasIndex(e => e.DeviceStatusKey)
                    .HasName("idx_device_status_key");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("idx_hms_key");

                entity.HasIndex(e => e.StatusSsk)
                    .HasName("IDX_Device_Status_SSK")
                    .IsUnique();

                entity.HasIndex(e => e.TeamKey)
                    .HasName("idx_team_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("idx_time_key");

                entity.HasIndex(e => e.UnitOfMeasureKey)
                    .HasName("idx_unit_of_measure");

                entity.HasIndex(e => new { e.DeviceNk, e.StatusSsk })
                    .HasName("IDX_SSKeys")
                    .IsUnique();

                entity.HasIndex(e => new { e.DeviceStatusKey, e.MeasureStatusDuration, e.DeviceNk })
                    .HasName("IDX_Fact_Device_lookup");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.AccountStatusKey).HasColumnName("Account_Status_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.DeviceStatusKey).HasColumnName("Device_Status_KEY");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_of_Measure_KEY");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_Key");

                entity.Property(e => e.DeviceNk)
                    .IsRequired()
                    .HasColumnName("Device_NK");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_Count");

                entity.Property(e => e.MeasureStatusDuration)
                    .HasColumnName("Measure_Status_Duration")
                    .HasColumnType("decimal");

                entity.Property(e => e.RecordCreated).HasColumnName("Record_Created");

                entity.Property(e => e.RecordCreatedBy).HasColumnName("Record_Created_By");

                entity.Property(e => e.RecordCreatedHms).HasColumnName("Record_Created_HMS");

                entity.Property(e => e.RecordUpdated).HasColumnName("Record_Updated");

                entity.Property(e => e.RecordUpdatedBy).HasColumnName("Record_Updated_By");

                entity.Property(e => e.RecordUpdatedHms).HasColumnName("Record_Updated_HMS");

                entity.Property(e => e.StatusSsk)
                    .IsRequired()
                    .HasColumnName("Status_SSK");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactDeviceStatus)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Device_Status_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentAccount>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.HmsKey, e.IncidentKey, e.AccountKey, e.TeamKey })
                    .HasName("PK_FACT_Incident_Account");

                entity.ToTable("fact_incident_account");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_fact_incident_account_account_key");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("ix_fact_incident_account_hms_key");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("ix_fact_incident_account_incident_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_fact_incident_account_team_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("ix_fact_incident_account_time_key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_Key");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.IncidentAccountRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Account_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentAccountRecordCreatedDatetime)
                    .HasColumnName("Incident_Account_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentAccountRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Account_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentAccountRecordUpdatedDatetime)
                    .HasColumnName("Incident_Account_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentAccountSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Account_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<FactIncidentAssignedTime>(entity =>
            {
                entity.ToTable("Fact_Incident_AssignedTime");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_fact_incident_assignedtime_account_key");

                entity.HasIndex(e => e.AssignedByEmployeeKey)
                    .HasName("ix_fact_incident_assignedtime_assignedby_employee_key");

                entity.HasIndex(e => e.AssignedToEmployeeKey)
                    .HasName("ix_fact_incident_assignedtime_assignedto_employee_key");

                entity.HasIndex(e => e.CompletedTimeHmsKey)
                    .HasName("ix_fact_incident_assignedtime_completed_hms_key");

                entity.HasIndex(e => e.CompletedTimeKey)
                    .HasName("ix_fact_incident_assignedtime_completed_time_key");

                entity.HasIndex(e => e.IncidentAssignedTimeRecordUpdatedDatetime)
                    .HasName("ix_fiat_rec_upd_dt");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("ix_fact_incident_assignedtime_incident_key");

                entity.HasIndex(e => e.QueueKey)
                    .HasName("ix_fact_incident_assignedtime_queue_key");

                entity.HasIndex(e => e.StartTimeHmsKey)
                    .HasName("ix_fact_incident_assignedtime_start_hms_key");

                entity.HasIndex(e => e.StartTimeKey)
                    .HasName("ix_fact_incident_assignedtime_start_time_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_fact_incident_assignedtime_team_key");

                entity.HasIndex(e => e.UnitOfMeasureKey)
                    .HasName("ix_fact_incident_assignedtime_unit_measure_key");

                entity.Property(e => e.FactIncidentAssignedTimeId)
                    .HasColumnName("Fact_Incident_AssignedTime_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.AssignedByEmployeeKey).HasColumnName("Assigned_by_Employee_Key");

                entity.Property(e => e.AssignedTimeDuration).HasColumnName("Assigned_Time_Duration");

                entity.Property(e => e.AssignedToEmployeeKey).HasColumnName("Assigned_to_Employee_Key");

                entity.Property(e => e.CompletedTimeHmsKey).HasColumnName("Completed_Time_hms_key");

                entity.Property(e => e.CompletedTimeKey).HasColumnName("Completed_Time_key");

                entity.Property(e => e.IncidentAssignedTimeRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_AssignedTime_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentAssignedTimeRecordCreatedDatetime)
                    .HasColumnName("Incident_AssignedTime_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentAssignedTimeRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_AssignedTime_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentAssignedTimeRecordUpdatedDatetime)
                    .HasColumnName("Incident_AssignedTime_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentAssignedTimeSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_AssignedTime_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentKey).HasColumnName("incident_key");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_key");

                entity.Property(e => e.StartTimeHmsKey).HasColumnName("Start_Time_hms_key");

                entity.Property(e => e.StartTimeKey).HasColumnName("Start_Time_key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("unit_of_measure_key");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentAssignedTime)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Incident_AssignedTime_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentCreated>(entity =>
            {
                entity.HasKey(e => new { e.IncidentKey, e.AccountKey, e.TeamKey, e.TimeKey, e.HmsKey, e.IncidentCreatedByKey, e.IncidentSubmittedByKey, e.TcktTicketId })
                    .HasName("PK_FACT_Incident_Created");

                entity.ToTable("fact_incident_created");

                entity.HasIndex(e => e.RecordUpdatedTimeKey)
                    .HasName("ix_fic_rec_upd_tk");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_key");

                entity.Property(e => e.IncidentCreatedByKey).HasColumnName("Incident_Created_By_KEY");

                entity.Property(e => e.IncidentSubmittedByKey).HasColumnName("Incident_Submitted_By_KEY");

                entity.Property(e => e.TcktTicketId).HasColumnName("TCKT_TicketID");

                entity.Property(e => e.IncidentCount).HasColumnName("Incident_Count");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_Key");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentCreated)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Incident_Created_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentDevice>(entity =>
            {
                entity.HasKey(e => e.IncidentDeviceId)
                    .HasName("PK_FACT_Incident_Device");

                entity.ToTable("fact_incident_device");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_fact_incident_device_account_key");

                entity.HasIndex(e => e.DeviceAssignmentHmsKey)
                    .HasName("ix_fact_incident_device_device_assignment_hms_key");

                entity.HasIndex(e => e.DeviceAssignmentTimeKey)
                    .HasName("ix_fact_incident_device_device_assignment_time_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("ix_fact_incident_device_device_key");

                entity.HasIndex(e => e.IncidentDeviceRecordUpdatedDatetime)
                    .HasName("ix_fid_rec_upd_dt");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("ix_fact_incident_device_incident_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_fact_incident_device_team_key");

                entity.Property(e => e.IncidentDeviceId)
                    .HasColumnName("Incident_Device_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.DeviceAssignmentHmsKey).HasColumnName("Device_Assignment_HMS_Key");

                entity.Property(e => e.DeviceAssignmentTimeKey).HasColumnName("Device_Assignment_Time_Key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.IncidentDeviceRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Device_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentDeviceRecordCreatedDatetime)
                    .HasColumnName("Incident_Device_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentDeviceRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Device_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentDeviceRecordUpdatedDatetime)
                    .HasColumnName("Incident_Device_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentDeviceSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Device_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentDevice)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FACT_Incident_Device_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentEotr>(entity =>
            {
                entity.HasKey(e => e.FactIncidentEotrKey)
                    .HasName("PK_Fact_Incident_EOTR");

                entity.ToTable("fact_incident_eotr");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX01_Fact_EOTR");

                entity.Property(e => e.FactIncidentEotrKey)
                    .HasColumnName("Fact_Incident_EOTR_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.EotrGrade).HasColumnName("EOTR_Grade");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_Key");

                entity.Property(e => e.IncidentEotrRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_EOTR_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentEotrRecordCreatedDatetime)
                    .HasColumnName("Incident_EOTR_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentEotrRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_EOTR_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentEotrRecordUpdatedDatetime)
                    .HasColumnName("Incident_EOTR_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentEotrSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_EOTR_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentEotr)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Incident_EOTR_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentMessage>(entity =>
            {
                entity.HasKey(e => e.IncidentMessageId)
                    .HasName("PK_FACT_Incident_Message");

                entity.ToTable("fact_incident_message");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_fact_incident_message_account_key");

                entity.HasIndex(e => e.EmployeeKey)
                    .HasName("ix_fact_incident_message_employee_key");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("ix_fact_incident_message_hms_key");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("ix_fact_incident_message_incident_key");

                entity.HasIndex(e => e.IncidentMessageCreatedSourceKey)
                    .HasName("ix_fact_incident_message_incident_source_key");

                entity.HasIndex(e => e.IncidentMessageRecordUpdatedDatetime)
                    .HasName("ix_fim_rec_upd_dt");

                entity.HasIndex(e => e.IncidentMessageTypeKey)
                    .HasName("ix_fact_incident_message_message_type_key");

                entity.HasIndex(e => e.QueueKey)
                    .HasName("ix_fact_incident_message_queue_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_fact_incident_message_team_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("ix_fact_incident_message_time_key");

                entity.HasIndex(e => new { e.TimeKey, e.AccountKey, e.IncidentKey, e.IncidentMessageCreatedSourceKey, e.SourceContactKey })
                    .HasName("IX_FACT_Incident_Message_SCKMI");

                entity.Property(e => e.IncidentMessageId)
                    .HasColumnName("Incident_Message_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.EmployeeKey).HasColumnName("Employee_Key");

                entity.Property(e => e.HmsKey).HasColumnName("hms_key");

                entity.Property(e => e.IncidentKey).HasColumnName("incident_key");

                entity.Property(e => e.IncidentMessageCreatedSourceKey).HasColumnName("Incident_Message_Created_Source_Key");

                entity.Property(e => e.IncidentMessageRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentMessageRecordCreatedDatetime)
                    .HasColumnName("Incident_Message_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentMessageRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentMessageRecordUpdatedDatetime)
                    .HasColumnName("Incident_Message_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentMessageSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Message_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentMessageTypeKey).HasColumnName("Incident_Message_Type_Key");

                entity.Property(e => e.PrivatizeContactKey).HasColumnName("Privatize_Contact_Key");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_key");

                entity.Property(e => e.SourceContactKey).HasColumnName("Source_Contact_Key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.TimeKey).HasColumnName("time_key");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentMessage)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FACT_Incident_Message_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentParentchild>(entity =>
            {
                entity.HasKey(e => new { e.RelationCreatedTimeKey, e.RelationCreatedHmsKey, e.TeamKey, e.AccountKey, e.IncidentParentKey, e.IncidentChildKey })
                    .HasName("PK_FACT_Incident_ParentChild_1");

                entity.ToTable("fact_incident_parentchild");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_fact_incident_parentchild_account_key");

                entity.HasIndex(e => e.IncidentChildKey)
                    .HasName("ix_fact_incident_parentchild_child_key");

                entity.HasIndex(e => e.IncidentParentKey)
                    .HasName("ix_fact_incident_parentchild_parent_key");

                entity.HasIndex(e => e.RelationCreatedHmsKey)
                    .HasName("ix_fact_incident_parentchild_relation_hms_key");

                entity.HasIndex(e => e.RelationCreatedTimeKey)
                    .HasName("ix_fact_incident_parentchild_relation_created_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_fact_incident_parentchild_team_key");

                entity.Property(e => e.RelationCreatedTimeKey).HasColumnName("Relation_Created_Time_Key");

                entity.Property(e => e.RelationCreatedHmsKey).HasColumnName("Relation_Created_HMS_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.IncidentParentKey).HasColumnName("Incident_Parent_Key");

                entity.Property(e => e.IncidentChildKey).HasColumnName("Incident_Child_Key");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.IncidentParentChildRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_ParentChild_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentParentChildRecordCreatedDatetime)
                    .HasColumnName("Incident_ParentChild_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentParentChildRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_ParentChild_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentParentChildRecordUpdatedDatetime)
                    .HasColumnName("Incident_ParentChild_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentParentChildSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_ParentChild_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentParentchild)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FACT_Incident_ParentChild_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentQueuetime>(entity =>
            {
                entity.HasKey(e => new { e.StartQueueTimeKey, e.StartQueueTimeHmsKey, e.EndQueueTimeKey, e.EndQueueTimeHmsKey, e.AccountKey, e.TeamKey, e.IncidentKey, e.QueueKey, e.IncidentCategoryKey, e.IncidentSubcategoryKey, e.IncidentStatusKey, e.EmployeeChangedByKey, e.UnitOfMeasureKey, e.TcktLogTicketStateId })
                    .HasName("PK_Fact_Incident_QueueTime1");

                entity.ToTable("fact_incident_queuetime");

                entity.HasIndex(e => e.RecordUpdatedTimeKey)
                    .HasName("ix_fiqt_rec_upd_tk");

                entity.Property(e => e.StartQueueTimeKey).HasColumnName("Start_Queue_Time_Key");

                entity.Property(e => e.StartQueueTimeHmsKey).HasColumnName("Start_Queue_Time_HMS_Key");

                entity.Property(e => e.EndQueueTimeKey).HasColumnName("End_Queue_Time_Key");

                entity.Property(e => e.EndQueueTimeHmsKey).HasColumnName("End_Queue_Time_HMS_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_Key");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_Key");

                entity.Property(e => e.IncidentCategoryKey).HasColumnName("Incident_Category_Key");

                entity.Property(e => e.IncidentSubcategoryKey).HasColumnName("Incident_Subcategory_Key");

                entity.Property(e => e.IncidentStatusKey).HasColumnName("Incident_Status_Key");

                entity.Property(e => e.EmployeeChangedByKey).HasColumnName("Employee_Changed_By_Key");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_of_Measure_Key");

                entity.Property(e => e.TcktLogTicketStateId).HasColumnName("TCKT_log_TicketStateID");

                entity.Property(e => e.QueueTimeDuration).HasColumnName("Queue_Time_Duration");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentQueuetime)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Fact_Incident_QueueTime_Dim_Account");
            });

            modelBuilder.Entity<FactIncidentState>(entity =>
            {
                entity.HasKey(e => new { e.IncidentStateId, e.TimeKey, e.HmsKey, e.EmployeeChangedByKey, e.AccountKey, e.TeamKey, e.IncidentKey, e.QueueKey, e.IncidentStatusKey, e.IncidentCategoryKey, e.IncidentSubcategoryKey, e.IncidentSeverityKey })
                    .HasName("PK_FACT_Incident_State2");

                entity.ToTable("FACT_Incident_State");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_fact_incident_state_account2");

                entity.HasIndex(e => e.EmployeeChangedByKey)
                    .HasName("ix_fact_incident_state_employee2");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("ix_fact_incident_state_hms_key2");

                entity.HasIndex(e => e.IncidentCategoryKey)
                    .HasName("ix_fact_incident_state_category_key2");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("ix_fact_incident_state_incident2");

                entity.HasIndex(e => e.IncidentSeverityKey)
                    .HasName("ix_fact_incident_state_severity_key2");

                entity.HasIndex(e => e.IncidentStateRecordUpdatedDatetime)
                    .HasName("ix_fis_rec_upd_dt2");

                entity.HasIndex(e => e.IncidentStatusKey)
                    .HasName("ix_fact_incident_state_status2");

                entity.HasIndex(e => e.IncidentSubcategoryKey)
                    .HasName("ix_fact_incident_state_subcategory_key2");

                entity.HasIndex(e => e.QueueKey)
                    .HasName("ix_fact_incident_state_queue2");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_fact_incident_state_team2");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("ix_fact_incident_state_time_key2");

                entity.Property(e => e.IncidentStateId).HasColumnName("Incident_State_ID");

                entity.Property(e => e.TimeKey).HasColumnName("time_key");

                entity.Property(e => e.HmsKey).HasColumnName("hms_key");

                entity.Property(e => e.EmployeeChangedByKey).HasColumnName("Employee_Changed_By_Key");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.IncidentKey).HasColumnName("incident_key");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_key");

                entity.Property(e => e.IncidentStatusKey).HasColumnName("Incident_Status_Key");

                entity.Property(e => e.IncidentCategoryKey).HasColumnName("Incident_Category_Key");

                entity.Property(e => e.IncidentSubcategoryKey).HasColumnName("Incident_Subcategory_Key");

                entity.Property(e => e.IncidentSeverityKey).HasColumnName("Incident_Severity_Key");

                entity.Property(e => e.IncidentStateRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_State_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentStateRecordCreatedDatetime)
                    .HasColumnName("Incident_State_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStateRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_State_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentStateRecordUpdatedDatetime)
                    .HasColumnName("Incident_State_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentStateSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_State_Source_System_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<FactIncidentWorked>(entity =>
            {
                entity.HasKey(e => e.IncidentWorkedId)
                    .HasName("PK_FACT_Incident_Work1");

                entity.ToTable("fact_incident_worked");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_FACT_Incident_Worked_account_key1");

                entity.HasIndex(e => e.EmployeeKey)
                    .HasName("ix_FACT_Incident_Worked_employee_key1");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("ix_FACT_Incident_Worked_hms_key1");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("ix_FACT_Incident_Worked_incident_key1");

                entity.HasIndex(e => e.IncidentWorktypeKey)
                    .HasName("ix_FACT_Incident_Worked_incident_worktype_key1");

                entity.HasIndex(e => e.QueueKey)
                    .HasName("ix_FACT_Incident_Worked_queue_key1");

                entity.HasIndex(e => e.StatusKey)
                    .HasName("ix_FACT_Incident_Worked_status_key1");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_FACT_Incident_Worked_team_key1");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("ix_FACT_Incident_Worked_time_key1");

                entity.HasIndex(e => e.UnitOfMeasureKey)
                    .HasName("ix_FACT_Incident_Worked_unit_of_measure_key1");

                entity.Property(e => e.IncidentWorkedId)
                    .HasColumnName("Incident_Worked_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.EmployeeKey).HasColumnName("Employee_Key");

                entity.Property(e => e.HmsKey).HasColumnName("hms_key");

                entity.Property(e => e.IncidentKey).HasColumnName("incident_key");

                entity.Property(e => e.IncidentWorkedRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Worked_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentWorkedRecordCreatedDatetime)
                    .HasColumnName("Incident_Worked_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentWorkedRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Worked_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentWorkedRecordUpdatedDatetime)
                    .HasColumnName("Incident_Worked_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentWorkedSourceSystemName)
                    .IsRequired()
                    .HasColumnName("Incident_Worked_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentWorktypeKey).HasColumnName("incident_worktype_key");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_key");

                entity.Property(e => e.StatusKey).HasColumnName("Status_Key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.TimeKey).HasColumnName("time_key");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("unit_of_measure_key");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactIncidentWorked)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FACT_Incident_Worked_Dim_Account2");
            });

            modelBuilder.Entity<FactIpAssignment>(entity =>
            {
                entity.HasKey(e => new { e.IpAddressKey, e.AccountKey, e.DeviceKey, e.TeamKey, e.DatacenterKey, e.AssignedTimeKey, e.AssignedHmsKey, e.UnassignedTimeKey, e.UnassignedHmsKey, e.UnitOfMeasureKey, e.AutonomusSystemKey, e.IpBlockKey, e.Id })
                    .HasName("PK_Fact_IP_Assignment_1");

                entity.ToTable("fact_ip_assignment");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_Account_KEY");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IX_Device_KEY");

                entity.HasIndex(e => e.IpAddressKey)
                    .HasName("IX_IP_Address_KEY");

                entity.HasIndex(e => e.UnassignedHmsKey)
                    .HasName("IX_Unassigned_HMS_KEY");

                entity.HasIndex(e => e.UnassignedTimeKey)
                    .HasName("IX_Unassigned_Time_KEY");

                entity.HasIndex(e => new { e.Id, e.UnassignedTimeKey, e.UnassignedHmsKey })
                    .HasName("IX_Fact_IP_Assignment_IDUTKMI");

                entity.Property(e => e.IpAddressKey).HasColumnName("IP_Address_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_key");

                entity.Property(e => e.DatacenterKey).HasColumnName("Datacenter_key");

                entity.Property(e => e.AssignedTimeKey).HasColumnName("Assigned_Time_Key");

                entity.Property(e => e.AssignedHmsKey).HasColumnName("Assigned_HMS_Key");

                entity.Property(e => e.UnassignedTimeKey).HasColumnName("Unassigned_Time_key");

                entity.Property(e => e.UnassignedHmsKey).HasColumnName("Unassigned_HMS_Key");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_Of_Measure_Key");

                entity.Property(e => e.AutonomusSystemKey).HasColumnName("Autonomus_System_Key");

                entity.Property(e => e.IpBlockKey).HasColumnName("IP_Block_KEY");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MeasureAssign48Hours).HasColumnName("Measure_Assign_48_Hours");

                entity.Property(e => e.MeasureAssignedTime).HasColumnName("Measure_Assigned_Time");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_Count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");
            });

            modelBuilder.Entity<FactManagedBackupDetail>(entity =>
            {
                entity.HasKey(e => e.MbuDetailKey)
                    .HasName("PK_TMP_MBU_Details_UPdate");

                entity.ToTable("fact_managed_backup_detail");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_Account_Key1");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("IX_HMS_Key1");

                entity.HasIndex(e => e.ManagedBackupLevelKey)
                    .HasName("IX_Managed_Backup_Level_Key11");

                entity.HasIndex(e => e.ManagedBackupStatusKey)
                    .HasName("IX_Managed_Backup_Status1");

                entity.HasIndex(e => e.ManagedBackupTargetKey)
                    .HasName("IX_Managed_Backup_Target_Key11");

                entity.HasIndex(e => e.MbuDetailRecordSourceSystemName)
                    .HasName("IX_FACT_Managed_Backup_Detail1");

                entity.HasIndex(e => e.RegionHmsKey)
                    .HasName("IDX_Region_HMS_Key");

                entity.HasIndex(e => e.RegionTimeKey)
                    .HasName("IDX_Region_Time_Key");

                entity.HasIndex(e => e.RegionTimezoneKey)
                    .HasName("IDX_Region_Timezone_Key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_Team_Key1");

                entity.HasIndex(e => e.TimezoneKey)
                    .HasName("IDX_Timezone_Key");

                entity.HasIndex(e => new { e.AccountKey, e.ManagedBackupStatusKey, e.RegionTimeKey })
                    .HasName("IDX_Region_Time_Account_Status");

                entity.HasIndex(e => new { e.AccountKey, e.TeamKey, e.TimeKey })
                    .HasName("IX_Fact_Managed_Backup_Detail_TK2");

                entity.HasIndex(e => new { e.MbuDetailRecordSourceSystemName, e.MbuDetailRecordValidFlag, e.RegionTimeKey })
                    .HasName("IDX_Calcualte_Agg");

                entity.HasIndex(e => new { e.TimeKey, e.ManagedBackupStatusKey, e.MbuDetailRecordSourceSystemName })
                    .HasName("IX_Time_Key1");

                entity.HasIndex(e => new { e.TimeKey, e.AccountKey, e.DeviceKey, e.ManagedBackupTargetKey })
                    .HasName("IX_FACT_Managed_Backup_Detail_11");

                entity.HasIndex(e => new { e.TimeKey, e.ManagedBackupStatusKey, e.Duration, e.TotalSizeMb })
                    .HasName("IX_MBU_Usage1");

                entity.HasIndex(e => new { e.AccountKey, e.DeviceKey, e.ManagedBackupStatusKey, e.MbuDetailRecordSourceSystemName, e.RegionTimeKey })
                    .HasName("IDX_Cals_Agg2");

                entity.HasIndex(e => new { e.AccountKey, e.DeviceKey, e.ManagedBackupLevelKey, e.MbuDetailRecordSourceSystemName, e.RegionTimeKey, e.RegionHmsKey })
                    .HasName("IDX_Calc_Agg1");

                entity.HasIndex(e => new { e.TimeKey, e.HmsKey, e.AccountKey, e.ManagedBackupTargetKey, e.ManagedBackupStatusKey, e.ManagedBackupServerKey, e.ManagedBackupLevelKey, e.DeviceKey })
                    .HasName("IX_Device_Key1");

                entity.HasIndex(e => new { e.TimeKey, e.AccountKey, e.DeviceKey, e.TeamKey, e.ManagedBackupTargetKey, e.ManagedBackupStatusKey, e.ManagedBackupServerKey, e.ManagedBackupLevelKey, e.HmsKey })
                    .HasName("IX_Fact_Managed_Backup_Detail21");

                entity.HasIndex(e => new { e.MbuDetailKey, e.HmsKey, e.AccountKey, e.DeviceKey, e.TeamKey, e.ManagedBackupTargetKey, e.ManagedBackupStatusKey, e.ManagedBackupServerKey, e.ManagedBackupLevelKey, e.TotalSizeMb, e.Duration, e.MbuDetailRecordCreatedDatetime, e.MbuDetailRecordCreatedBy, e.MbuDetailRecordUpdatedDatetime, e.MbuDetailRecordUpdatedBy, e.MbuDetailRecordSourceSystemName, e.MbuDetailRecordValidFlag, e.TimezoneKey, e.RegionTimezoneKey, e.RegionTimeKey, e.RegionHmsKey, e.EndTimeKey, e.EndHmsKey, e.RegionEndTimeKey, e.RegionEndHmsKey, e.DurationProcess, e.TimeKey })
                    .HasName("IX_Fact_Managed_Backup_Detail_TK3MI");

                entity.Property(e => e.MbuDetailKey).HasColumnName("MBU_Detail_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.DurationProcess)
                    .HasColumnName("Duration_Process")
                    .HasColumnType("decimal");

                entity.Property(e => e.EndHmsKey).HasColumnName("End_HMS_Key");

                entity.Property(e => e.EndTimeKey).HasColumnName("End_Time_Key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.ManagedBackupLevelKey).HasColumnName("Managed_Backup_Level_KEY");

                entity.Property(e => e.ManagedBackupServerKey).HasColumnName("Managed_Backup_Server_KEY");

                entity.Property(e => e.ManagedBackupStatusKey).HasColumnName("Managed_Backup_Status_KEY");

                entity.Property(e => e.ManagedBackupTargetKey).HasColumnName("Managed_Backup_Target_KEY");

                entity.Property(e => e.MbuDetailRecordCreatedBy)
                    .HasColumnName("MBU_Detail_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuDetailRecordCreatedDatetime)
                    .HasColumnName("MBU_Detail_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuDetailRecordSourceSystemName)
                    .HasColumnName("MBU_Detail_Record_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuDetailRecordUpdatedBy)
                    .HasColumnName("MBU_Detail_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuDetailRecordUpdatedDatetime)
                    .HasColumnName("MBU_Detail_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuDetailRecordValidFlag).HasColumnName("MBU_Detail_Record_Valid_Flag");

                entity.Property(e => e.RegionEndHmsKey).HasColumnName("Region_End_HMS_Key");

                entity.Property(e => e.RegionEndTimeKey).HasColumnName("Region_End_Time_Key");

                entity.Property(e => e.RegionHmsKey).HasColumnName("Region_HMS_KEY");

                entity.Property(e => e.RegionTimeKey).HasColumnName("Region_Time_KEY");

                entity.Property(e => e.RegionTimezoneKey).HasColumnName("Region_Timezone_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.TimezoneKey).HasColumnName("Timezone_KEY");

                entity.Property(e => e.TotalSizeMb).HasColumnName("Total_Size_MB");
            });

            modelBuilder.Entity<FactManagedBackupDetail13Month>(entity =>
            {
                entity.HasKey(e => e.MbuDetailKey)
                    .HasName("PK_Fact_Managed_Backup_Detail_13_Month");

                entity.ToTable("fact_managed_backup_detail_13_month");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("idx_account_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("idx_device_key");

                entity.HasIndex(e => e.EndHmsKey)
                    .HasName("idx_end_hms_key");

                entity.HasIndex(e => e.EndTimeKey)
                    .HasName("idx_end_time");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("idx_hms_key");

                entity.HasIndex(e => e.ManagedBackupStatusKey)
                    .HasName("idx_mbu_status_key");

                entity.HasIndex(e => e.ManagedBackupTargetKey)
                    .HasName("idx_mbu_target_key");

                entity.HasIndex(e => e.MbuDetailRecordSourceSystemName)
                    .HasName("idx_source_system_name");

                entity.HasIndex(e => e.RegionEndHmsKey)
                    .HasName("idx_region_end_hms_key");

                entity.HasIndex(e => e.RegionEndTimeKey)
                    .HasName("idx_region_end_time_key");

                entity.HasIndex(e => e.RegionHmsKey)
                    .HasName("IDX_Region_HMS_Key");

                entity.HasIndex(e => e.RegionTimeKey)
                    .HasName("IDX_Region_Time_Key");

                entity.HasIndex(e => e.RegionTimezoneKey)
                    .HasName("IDX_Region_Timezone_Key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("idx_time_key");

                entity.HasIndex(e => e.TimezoneKey)
                    .HasName("IDX_Timezone_Key");

                entity.HasIndex(e => new { e.AccountKey, e.ManagedBackupStatusKey, e.RegionTimeKey })
                    .HasName("IDX_Region_Time_Account_Status");

                entity.Property(e => e.MbuDetailKey)
                    .HasColumnName("MBU_Detail_Key")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.DurationProcess)
                    .HasColumnName("Duration_Process")
                    .HasColumnType("decimal");

                entity.Property(e => e.EndHmsKey).HasColumnName("End_HMS_Key");

                entity.Property(e => e.EndTimeKey).HasColumnName("End_Time_Key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.ManagedBackupLevelKey).HasColumnName("Managed_Backup_Level_KEY");

                entity.Property(e => e.ManagedBackupServerKey).HasColumnName("Managed_Backup_Server_KEY");

                entity.Property(e => e.ManagedBackupStatusKey).HasColumnName("Managed_Backup_Status_KEY");

                entity.Property(e => e.ManagedBackupTargetKey).HasColumnName("Managed_Backup_Target_KEY");

                entity.Property(e => e.MbuDetailRecordCreatedBy)
                    .HasColumnName("MBU_Detail_Record_Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuDetailRecordCreatedDatetime)
                    .HasColumnName("MBU_Detail_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuDetailRecordSourceSystemName)
                    .HasColumnName("MBU_Detail_Record_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuDetailRecordUpdatedBy)
                    .HasColumnName("MBU_Detail_Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuDetailRecordUpdatedDatetime)
                    .HasColumnName("MBU_Detail_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MbuDetailRecordValidFlag).HasColumnName("MBU_Detail_Record_Valid_Flag");

                entity.Property(e => e.RegionEndHmsKey).HasColumnName("Region_End_HMS_Key");

                entity.Property(e => e.RegionEndTimeKey).HasColumnName("Region_End_Time_Key");

                entity.Property(e => e.RegionHmsKey).HasColumnName("Region_HMS_KEY");

                entity.Property(e => e.RegionTimeKey).HasColumnName("Region_Time_KEY");

                entity.Property(e => e.RegionTimezoneKey).HasColumnName("Region_Timezone_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.TimezoneKey).HasColumnName("Timezone_KEY");

                entity.Property(e => e.TotalSizeMb).HasColumnName("Total_Size_MB");
            });

            modelBuilder.Entity<FactMbuAggAccountDeviceMonthly>(entity =>
            {
                entity.HasKey(e => new { e.AccountKey, e.TimeKey, e.DeviceKey, e.ManagedBackupTargetKey, e.ManagedBackupStatusKey, e.ManagedBackupLevelKey, e.ManagedBackupSystemKey })
                    .HasName("PK_Fact_MBU_AGG_Account_Device_Monthly");

                entity.ToTable("Fact_MBU_AGG_Account_Device_Monthly");

                entity.HasIndex(e => new { e.AccountKey, e.TimeKey, e.DeviceKey })
                    .HasName("IDX_ACCOUNT_DEVICE_TIME");

                entity.HasIndex(e => new { e.AccountKey, e.TimeKey, e.DeviceKey, e.ManagedBackupLevelKey })
                    .HasName("IDX_ACCT_DEV_LEVEL_TIME");

                entity.HasIndex(e => new { e.AccountKey, e.TimeKey, e.DeviceKey, e.ManagedBackupStatusKey })
                    .HasName("IDX_ACCT_DEV_STATUS_TIME");

                entity.HasIndex(e => new { e.AccountKey, e.TimeKey, e.DeviceKey, e.ManagedBackupSystemKey })
                    .HasName("IDX_ACCT_DEV_SYSTEM_TIME");

                entity.HasIndex(e => new { e.AccountKey, e.TimeKey, e.DeviceKey, e.ManagedBackupTargetKey })
                    .HasName("IDX_ACC_DEVICE_TARGET_TIME");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.ManagedBackupTargetKey).HasColumnName("Managed_Backup_Target_Key");

                entity.Property(e => e.ManagedBackupStatusKey).HasColumnName("Managed_Backup_Status_Key");

                entity.Property(e => e.ManagedBackupLevelKey).HasColumnName("Managed_Backup_Level_Key");

                entity.Property(e => e.ManagedBackupSystemKey).HasColumnName("Managed_Backup_System_Key");

                entity.Property(e => e.DaysSizeMb28)
                    .HasColumnName("Days_Size_MB_28")
                    .HasColumnType("decimal");

                entity.Property(e => e.Duration).HasColumnType("decimal");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.TotalSizeMb)
                    .HasColumnName("Total_Size_MB")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<FactMbuAggAccountMonthly>(entity =>
            {
                entity.HasKey(e => new { e.AccountKey, e.TimeKey, e.ManagedBackupStatusKey })
                    .HasName("PK_Fact_MBU_AGG_Account_Monthly");

                entity.ToTable("fact_mbu_agg_account_monthly");

                entity.HasIndex(e => new { e.AccountKey, e.TimeKey })
                    .HasName("IDX_Time_Acckount");

                entity.HasIndex(e => new { e.TimeKey, e.ManagedBackupStatusKey })
                    .HasName("IDX_Status_Time");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.ManagedBackupStatusKey).HasColumnName("Managed_Backup_Status_Key");

                entity.Property(e => e.DaysSizeMb28)
                    .HasColumnName("Days_Size_MB_28")
                    .HasColumnType("decimal");

                entity.Property(e => e.Duration).HasColumnType("decimal");

                entity.Property(e => e.FullMonthOverageUsageGb)
                    .HasColumnName("Full_Month_Overage_Usage_GB")
                    .HasColumnType("decimal");

                entity.Property(e => e.FullMonthProjectedOverageUsageGb)
                    .HasColumnName("Full_Month_Projected_Overage_Usage_GB")
                    .HasColumnType("decimal");

                entity.Property(e => e.FullMonthProjectedUsageGb)
                    .HasColumnName("Full_Month_Projected_Usage_GB")
                    .HasColumnType("decimal");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.TotalSizeMb)
                    .HasColumnName("Total_Size_MB")
                    .HasColumnType("decimal");

                entity.Property(e => e._28DayOverageUsageGb)
                    .HasColumnName("28_Day_Overage_Usage_GB")
                    .HasColumnType("decimal");

                entity.Property(e => e._28DayProjectedOverageUsageGb)
                    .HasColumnName("28_Day_Projected_Overage_Usage_GB")
                    .HasColumnType("decimal");

                entity.Property(e => e._28DayProjectedUsageGb)
                    .HasColumnName("28_Day_Projected_Usage_GB")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<FactMbuConfigHistory>(entity =>
            {
                entity.HasKey(e => e.MbuConfigHistoryKey)
                    .HasName("PK_Fact_MBU_Config_History");

                entity.ToTable("fact_mbu_config_history");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_MBU_Config_History_Account_Key_");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IX_Fact_MBU_Config_History_Device_Key");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("IX_Fact_MBU_Config_History_HMS_KEY");

                entity.HasIndex(e => e.MbuConfigKey)
                    .HasName("IX_Fact_MBU_Config_History_MBU_Config_KEY");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_Fact_MBU_Config_History_Team_Key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_MBU_Config_History_Time_Key");

                entity.HasIndex(e => new { e.MbuConfigHistorySourceSystemName, e.CurrentRecordFlg })
                    .HasName("IX_Fact_MBU_Config_History");

                entity.HasIndex(e => new { e.MbuConfigKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.TimeKey, e.HmsKey, e.CurrentRecordFlg })
                    .HasName("IX_Fact_MBU_Config_History_Covering");

                entity.HasIndex(e => new { e.MbuConfigKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.HmsKey, e.MbuConfigCnt, e.CurrentRecordFlg, e.MbuConfigHistorySourceSystemName, e.MbuExclusionsKey, e.TimeKey })
                    .HasName("IX_Fact_MBU_Config_History_TKMI");

                entity.Property(e => e.MbuConfigHistoryKey).HasColumnName("MBU_Config_History_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.CurrentRecordFlg).HasColumnName("Current_Record_FLG");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.MbuConfigCnt).HasColumnName("MBU_Config_CNT");

                entity.Property(e => e.MbuConfigHistorySourceSystemName)
                    .IsRequired()
                    .HasColumnName("MBU_Config_History_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MbuConfigKey).HasColumnName("MBU_Config_KEY");

                entity.Property(e => e.MbuExclusionsKey).HasColumnName("MBU_Exclusions_Key");

                entity.Property(e => e.RecAddedDttm)
                    .HasColumnName("Rec_Added_DTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecUpdatedDttm)
                    .HasColumnName("Rec_Updated_DTTM")
                    .HasColumnType("datetime");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");
            });

            modelBuilder.Entity<FactMonitoringAlert>(entity =>
            {
                entity.HasKey(e => new { e.FactMonitoringAlertKey, e.SourceSystemKey })
                    .HasName("PK_FACT_Monitoring_Alert");

                entity.ToTable("fact_monitoring_alert");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX01_FACT_MON_Alert_Account_KEY");

                entity.HasIndex(e => e.AlertStatusKey)
                    .HasName("IX01_FACT_MON_Alert_Alert_Status_KEY");

                entity.HasIndex(e => e.AlertTypeKey)
                    .HasName("IX01_FACT_MON_Alert_Alert_Type_KEY");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IX01_FACT_MON_Alert_Device_Key");

                entity.HasIndex(e => e.FactMonitoringAlertKey)
                    .HasName("IX_FACT_Monitoring_Alert");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("IX01_FACT_MON_Alert_Incident_KEY");

                entity.HasIndex(e => e.MonitoringAlertResolutionTime)
                    .HasName("IX01_FACT_MON_Alert_ResolutionTime");

                entity.HasIndex(e => e.MonitoringAlertResponseTime)
                    .HasName("IX01_FACT_MON_Alert_ResponseTime");

                entity.HasIndex(e => e.QueueKey)
                    .HasName("IX01_FACT_MON_Alert_Queue_KEY");

                entity.HasIndex(e => e.ServicePollerKey)
                    .HasName("IX01_FACT_MON_Alert_Service_Poller_KEY");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX01_FACT_MON_Alert_Team_KEY");

                entity.HasIndex(e => e.ThresholdKey)
                    .HasName("IX01_FACT_MON_Alert_Threshold_KEY");

                entity.HasIndex(e => e.TimeAcknowledgedHmsKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Acknowledged_HMS_KEY");

                entity.HasIndex(e => e.TimeAcknowledgedKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Acknowledged_KEY");

                entity.HasIndex(e => e.TimeClosedHmsKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Closed_HMS_KEY");

                entity.HasIndex(e => e.TimeClosedKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Closed_KEY");

                entity.HasIndex(e => e.TimeOpenHmsKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Open_HMS_KEY");

                entity.HasIndex(e => e.TimeOpenKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Open_KEY");

                entity.HasIndex(e => e.TimeSolvedHmsKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Solved_HMS_KEY");

                entity.HasIndex(e => e.TimeSolvedKey)
                    .HasName("IX01_FACT_MON_Alert_Time_Solved_KEY");

                entity.HasIndex(e => e.UnitOfMeasureKey)
                    .HasName("IX01_FACT_MON_Alert_Unit_of_Measure_KEY");

                entity.Property(e => e.FactMonitoringAlertKey).HasColumnName("FACT_Monitoring_Alert_KEY");

                entity.Property(e => e.SourceSystemKey).HasColumnName("Source_System_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.AlertStatusKey).HasColumnName("Alert_Status_KEY");

                entity.Property(e => e.AlertTypeKey).HasColumnName("Alert_Type_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.EmployeeKey).HasColumnName("Employee_KEY");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_KEY");

                entity.Property(e => e.MonitorKey).HasColumnName("Monitor_Key");

                entity.Property(e => e.MonitoringAlertRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Monitoring_Alert_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.MonitoringAlertRecordCreatedDatetime)
                    .HasColumnName("Monitoring_Alert_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonitoringAlertRecordUpdatedDatetime)
                    .HasColumnName("Monitoring_Alert_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonitoringAlertReferenceNumber)
                    .IsRequired()
                    .HasColumnName("Monitoring_Alert_Reference_Number")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitoringAlertResolutionTime).HasColumnName("Monitoring_Alert_ResolutionTime");

                entity.Property(e => e.MonitoringAlertResponseTime).HasColumnName("Monitoring_Alert_ResponseTime");

                entity.Property(e => e.MonitoringAlertUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Monitoring_Alert_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_KEY");

                entity.Property(e => e.ServicePollerKey).HasColumnName("Service_Poller_KEY");

                entity.Property(e => e.SeverityKey).HasColumnName("Severity_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.ThresholdKey).HasColumnName("Threshold_KEY");

                entity.Property(e => e.TimeAcknowledgedHmsKey).HasColumnName("Time_Acknowledged_HMS_KEY");

                entity.Property(e => e.TimeAcknowledgedKey).HasColumnName("Time_Acknowledged_KEY");

                entity.Property(e => e.TimeClosedHmsKey).HasColumnName("Time_Closed_HMS_KEY");

                entity.Property(e => e.TimeClosedKey).HasColumnName("Time_Closed_KEY");

                entity.Property(e => e.TimeOpenHmsKey).HasColumnName("Time_Open_HMS_KEY");

                entity.Property(e => e.TimeOpenKey).HasColumnName("Time_Open_KEY");

                entity.Property(e => e.TimeSolvedHmsKey).HasColumnName("Time_Solved_HMS_KEY");

                entity.Property(e => e.TimeSolvedKey).HasColumnName("Time_Solved_KEY");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_of_Measure_KEY");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactMonitoringAlert)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FACT_Monitoring_Alert_Dim_Account");
            });

            modelBuilder.Entity<FactMonitoringAlertRackwatch>(entity =>
            {
                entity.HasKey(e => new { e.FactMonitoringAlertRackwatchKey, e.SourceSystemKey })
                    .HasName("PK_FACT_Monitoring_Alert_Rackwatch_Rackwatch");

                entity.ToTable("Fact_Monitoring_Alert_Rackwatch");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("idx_Alert_Account_KEY");

                entity.HasIndex(e => e.AlertStatusKey)
                    .HasName("idx_Alert_Alert_Status_KEY");

                entity.HasIndex(e => e.AlertTypeKey)
                    .HasName("idx_Alert_Alert_Type_KEY");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("idx_Alert_Device_Key");

                entity.HasIndex(e => e.IncidentKey)
                    .HasName("idx_Alert_Incident_KEY");

                entity.HasIndex(e => e.MonitoringAlertResolutionTime)
                    .HasName("idx_Alert_ResolutionTime");

                entity.HasIndex(e => e.MonitoringAlertResponseTime)
                    .HasName("idx_Alert_ResponseTime");

                entity.HasIndex(e => e.QueueKey)
                    .HasName("idx_Alert_Queue_KEY");

                entity.HasIndex(e => e.ServicePollerKey)
                    .HasName("idx_Alert_Service_Poller_KEY");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("idx_Alert_Team_KEY");

                entity.HasIndex(e => e.ThresholdKey)
                    .HasName("idx_Alert_Threshold_KEY");

                entity.HasIndex(e => e.TimeAcknowledgedHmsKey)
                    .HasName("idx_Alert_Time_Acknowledged_HMS_KEY");

                entity.HasIndex(e => e.TimeAcknowledgedKey)
                    .HasName("idx_Alert_Time_Acknowledged_KEY");

                entity.HasIndex(e => e.TimeClosedHmsKey)
                    .HasName("idx_Alert_Time_Closed_HMS_KEY");

                entity.HasIndex(e => e.TimeClosedKey)
                    .HasName("idx_Alert_Time_Closed_KEY");

                entity.HasIndex(e => e.TimeOpenHmsKey)
                    .HasName("idx_Alert_Time_Open_HMS_KEY");

                entity.HasIndex(e => e.TimeOpenKey)
                    .HasName("idx_Alert_Time_Open_KEY");

                entity.HasIndex(e => e.TimeSolvedHmsKey)
                    .HasName("idx_Alert_Time_Solved_HMS_KEY");

                entity.HasIndex(e => e.TimeSolvedKey)
                    .HasName("idx_Alert_Time_Solved_KEY");

                entity.HasIndex(e => e.UnitOfMeasureKey)
                    .HasName("idx_Alert_Unit_of_Measure_KEY");

                entity.Property(e => e.FactMonitoringAlertRackwatchKey).HasColumnName("FACT_Monitoring_Alert_Rackwatch_KEY");

                entity.Property(e => e.SourceSystemKey).HasColumnName("Source_System_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.AlertStatusKey).HasColumnName("Alert_Status_KEY");

                entity.Property(e => e.AlertTypeKey).HasColumnName("Alert_Type_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.EmployeeKey).HasColumnName("Employee_KEY");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_KEY");

                entity.Property(e => e.MonitorKey).HasColumnName("Monitor_Key");

                entity.Property(e => e.MonitoringAlertRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Monitoring_Alert_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.MonitoringAlertRecordCreatedDatetime)
                    .HasColumnName("Monitoring_Alert_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonitoringAlertRecordUpdatedDatetime)
                    .HasColumnName("Monitoring_Alert_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonitoringAlertReferenceNumber)
                    .IsRequired()
                    .HasColumnName("Monitoring_Alert_Reference_Number")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonitoringAlertResolutionTime).HasColumnName("Monitoring_Alert_ResolutionTime");

                entity.Property(e => e.MonitoringAlertResponseTime).HasColumnName("Monitoring_Alert_ResponseTime");

                entity.Property(e => e.MonitoringAlertUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Monitoring_Alert_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.QueueKey).HasColumnName("Queue_KEY");

                entity.Property(e => e.ServicePollerKey).HasColumnName("Service_Poller_KEY");

                entity.Property(e => e.SeverityKey).HasColumnName("Severity_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.ThresholdKey).HasColumnName("Threshold_KEY");

                entity.Property(e => e.TimeAcknowledgedHmsKey).HasColumnName("Time_Acknowledged_HMS_KEY");

                entity.Property(e => e.TimeAcknowledgedKey).HasColumnName("Time_Acknowledged_KEY");

                entity.Property(e => e.TimeClosedHmsKey).HasColumnName("Time_Closed_HMS_KEY");

                entity.Property(e => e.TimeClosedKey).HasColumnName("Time_Closed_KEY");

                entity.Property(e => e.TimeOpenHmsKey).HasColumnName("Time_Open_HMS_KEY");

                entity.Property(e => e.TimeOpenKey).HasColumnName("Time_Open_KEY");

                entity.Property(e => e.TimeSolvedHmsKey).HasColumnName("Time_Solved_HMS_KEY");

                entity.Property(e => e.TimeSolvedKey).HasColumnName("Time_Solved_KEY");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_of_Measure_KEY");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.FactMonitoringAlertRackwatch)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_FACT_Monitoring_Alert_Rackwatch_Dim_Account");
            });

            modelBuilder.Entity<FactMonitoringAvailabilityMetricsCurrent>(entity =>
            {
                entity.ToTable("fact_monitoring_availability_metrics_current");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_Avability_Mtrx_Account_Key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IX_Avability_Mtrx_Device_Key");

                entity.HasIndex(e => e.MonitorKey)
                    .HasName("IX_Avability_Mtrx_Monitor_Key");

                entity.HasIndex(e => e.StartTimeKey)
                    .HasName("IX_Avability_Mtrx_End_Time_Key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_Avability_Mtrx_Team_Key");

                entity.HasIndex(e => new { e.StartHmsKey, e.EndTimeKey, e.EndHmsKey, e.StartTimeKey })
                    .HasName("IX_SHK_ETK_EHK_STK");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountKey).HasColumnName("Account_key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_key");

                entity.Property(e => e.EndHmsKey).HasColumnName("End_Hms_Key");

                entity.Property(e => e.EndTimeKey).HasColumnName("End_Time_Key");

                entity.Property(e => e.MeasureAvailabilityPercent)
                    .HasColumnName("Measure_Availability_Percent")
                    .HasColumnType("decimal");

                entity.Property(e => e.MeasureDowntimeSeconds).HasColumnName("Measure_Downtime_Seconds");

                entity.Property(e => e.MeasureEnabledSeconds).HasColumnName("Measure_Enabled_Seconds");

                entity.Property(e => e.MeasureRecordCount).HasColumnName("Measure_Record_Count");

                entity.Property(e => e.MeasureTotalAvailabilityPercent)
                    .HasColumnName("Measure_Total_Availability_Percent")
                    .HasColumnType("decimal");

                entity.Property(e => e.MeasureTotalDownTime).HasColumnName("Measure_Total_Down_Time");

                entity.Property(e => e.MeasureUptimeSeconds).HasColumnName("Measure_Uptime_Seconds");

                entity.Property(e => e.MonitorKey).HasColumnName("Monitor_key");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_key");

                entity.Property(e => e.SourceSystemKey).HasColumnName("Source_System_Key");

                entity.Property(e => e.StartHmsKey).HasColumnName("Start_HMS_Key");

                entity.Property(e => e.StartTimeKey).HasColumnName("Start_Time_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_key");
            });

            modelBuilder.Entity<FactMonitoringDeviceConfig>(entity =>
            {
                entity.ToTable("Fact_Monitoring_Device_Config");

                entity.HasIndex(e => new { e.MonitoredServiceIdNk, e.SourceSystemKey })
                    .HasName("IDX_Config");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.ClosedHmsKey).HasColumnName("Closed_HMS_KEY");

                entity.Property(e => e.ClosedTimeKey).HasColumnName("Closed_Time_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.DeviceStatusKey).HasColumnName("Device_Status_KEY");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_Count");

                entity.Property(e => e.MonitorKey).HasColumnName("Monitor_Key");

                entity.Property(e => e.MonitoredServiceIdNk).HasColumnName("Monitored_Service_ID_NK");

                entity.Property(e => e.RecordCreated).HasColumnName("Record_Created");

                entity.Property(e => e.RecordCreatedBy).HasColumnName("Record_Created_By");

                entity.Property(e => e.RecordCreatedHms).HasColumnName("Record_Created_HMS");

                entity.Property(e => e.RecordUpdated).HasColumnName("Record_Updated");

                entity.Property(e => e.RecordUpdatedBy).HasColumnName("Record_Updated_By");

                entity.Property(e => e.RecordUpdatedHms).HasColumnName("Record_Updated_HMS");

                entity.Property(e => e.ServicePollerKey).HasColumnName("Service_Poller_KEY");

                entity.Property(e => e.SourceSystemKey).HasColumnName("source_system_key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");
            });

            modelBuilder.Entity<FactMonitoringMonitorStatusChange>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SourceSystemKey })
                    .HasName("PK_Fact_Monitoring_Monitor_Status_Change");

                entity.ToTable("Fact_Monitoring_Monitor_Status_Change");

                entity.HasIndex(e => e.MonitorKey)
                    .HasName("IDX_Monitor_key");

                entity.HasIndex(e => new { e.EndTimeKey, e.EndHmsKey })
                    .HasName("IDX_End_Time");

                entity.HasIndex(e => new { e.TimeKey, e.HmsKey })
                    .HasName("IDX_StartTime");

                entity.Property(e => e.Id).HasColumnType("varchar(50)");

                entity.Property(e => e.SourceSystemKey).HasColumnName("Source_System_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_key");

                entity.Property(e => e.EndHmsKey).HasColumnName("End_HMS_key");

                entity.Property(e => e.EndTimeKey).HasColumnName("End_Time_key");

                entity.Property(e => e.HmsKey).HasColumnName("Hms_Key");

                entity.Property(e => e.MeasureRecordCount).HasColumnName("Measure_Record_Count");

                entity.Property(e => e.MeasureStatusDuration).HasColumnName("Measure_Status_Duration");

                entity.Property(e => e.MonitorKey).HasColumnName("Monitor_Key");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_Hms_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_Hms_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.StatusKey).HasColumnName("Status_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");
            });

            modelBuilder.Entity<FactNpsMot>(entity =>
            {
                entity.HasKey(e => new { e.StartTimeKey, e.StartHmsKey, e.TeamKey, e.AccountKey, e.ContactKey, e.IncidentKey, e.SurveyKey, e.SurveyQuestionKey, e.SurveyNpsAnswerKey, e.TicketRatingCategoryKey, e.SurveyTypeKey, e.SurveyResponseKey, e.NpsSsk })
                    .HasName("PK_Fact_NPS_MOT");

                entity.ToTable("Fact_NPS_MOT");

                entity.Property(e => e.StartTimeKey).HasColumnName("Start_Time_KEY");

                entity.Property(e => e.StartHmsKey).HasColumnName("Start_HMS_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_Key");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_Key");

                entity.Property(e => e.SurveyKey).HasColumnName("Survey_Key");

                entity.Property(e => e.SurveyQuestionKey).HasColumnName("Survey_Question_KEY");

                entity.Property(e => e.SurveyNpsAnswerKey).HasColumnName("Survey_NPS_Answer_KEY");

                entity.Property(e => e.TicketRatingCategoryKey).HasColumnName("Ticket_Rating_Category_Key");

                entity.Property(e => e.SurveyTypeKey).HasColumnName("Survey_Type_Key");

                entity.Property(e => e.SurveyResponseKey).HasColumnName("Survey_Response_KEY");

                entity.Property(e => e.NpsSsk)
                    .HasColumnName("NPS_SSK")
                    .HasColumnType("varchar(225)");

                entity.Property(e => e.AmContactKey).HasColumnName("AM_Contact_Key");

                entity.Property(e => e.BdcContactKey).HasColumnName("BDC_Contact_Key");

                entity.Property(e => e.ContactRoleKey).HasColumnName("Contact_Role_Key");

                entity.Property(e => e.IncidentCategoryKey).HasColumnName("Incident_Category_Key");

                entity.Property(e => e.IncidentSubCategoryKey).HasColumnName("Incident_SubCategory_Key");

                entity.Property(e => e.NpsRating).HasColumnName("NPS_Rating");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordSourceKey).HasColumnName("Record_source_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.Property(e => e.ResponseCount).HasColumnName("Response_Count");

                entity.Property(e => e.SurveyFeedback)
                    .HasColumnName("Survey_Feedback")
                    .HasColumnType("varchar(2000)");
            });

            modelBuilder.Entity<FactNpsScore>(entity =>
            {
                entity.HasKey(e => new { e.StartTimeKey, e.StartHmsKey, e.TeamKey, e.AccountKey, e.ContactKey, e.IncidentKey, e.SurveyKey, e.SurveyQuestionKey, e.SurveyNpsAnswerKey, e.SurveyTypeKey, e.SurveyResponseKey, e.NpsSsk })
                    .HasName("PK_Fact_NPS_Score");

                entity.ToTable("fact_nps_score");

                entity.Property(e => e.StartTimeKey).HasColumnName("Start_Time_KEY");

                entity.Property(e => e.StartHmsKey).HasColumnName("Start_HMS_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_Key");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_Key");

                entity.Property(e => e.SurveyKey).HasColumnName("Survey_Key");

                entity.Property(e => e.SurveyQuestionKey).HasColumnName("Survey_Question_KEY");

                entity.Property(e => e.SurveyNpsAnswerKey).HasColumnName("Survey_NPS_Answer_KEY");

                entity.Property(e => e.SurveyTypeKey).HasColumnName("Survey_Type_Key");

                entity.Property(e => e.SurveyResponseKey).HasColumnName("Survey_Response_KEY");

                entity.Property(e => e.NpsSsk)
                    .HasColumnName("NPS_SSK")
                    .HasColumnType("varchar(225)");

                entity.Property(e => e.AmContactKey).HasColumnName("AM_Contact_Key");

                entity.Property(e => e.BdcContactKey).HasColumnName("BDC_Contact_Key");

                entity.Property(e => e.NpsRating).HasColumnName("NPS_Rating");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordSourceKey).HasColumnName("Record_source_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.Property(e => e.ResponseCount).HasColumnName("Response_Count");
            });

            modelBuilder.Entity<FactPhoneAgentUsageDetail>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.HmsKey, e.ContactKey, e.PhoneSkillKey })
                    .HasName("PK_Fact_Agent_Phone_Usage_Details");

                entity.ToTable("fact_phone_agent_usage_detail");

                entity.HasIndex(e => e.ContactKey)
                    .HasName("IX_Contact_Key");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("IX_HMS_Key");

                entity.HasIndex(e => e.PhoneSkillKey)
                    .HasName("IX_Phone_Skill_Key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_Time_Key");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_KEY");

                entity.Property(e => e.PhoneSkillKey).HasColumnName("Phone_Skill_KEY");

                entity.Property(e => e.AbandonedCallCount).HasColumnName("Abandoned_Call_Count");

                entity.Property(e => e.AcdCallCount).HasColumnName("ACD_Call_Count");

                entity.Property(e => e.AcdDurationSeconds).HasColumnName("ACD_Duration_Seconds");

                entity.Property(e => e.AcwDurationSeconds).HasColumnName("ACW_Duration_Seconds");

                entity.Property(e => e.AuxDurationSeconds).HasColumnName("AUX_Duration_Seconds");

                entity.Property(e => e.AvailableDurationSeconds).HasColumnName("Available_Duration_Seconds");

                entity.Property(e => e.InboundCallCount).HasColumnName("Inbound_Call_Count");

                entity.Property(e => e.OutboundCallCount).HasColumnName("Outbound_Call_Count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.Property(e => e.RingDurationSeconds).HasColumnName("Ring_Duration_Seconds");

                entity.Property(e => e.RonaCallCount).HasColumnName("RONA_Call_Count");

                entity.Property(e => e.StaffedDurationSeconds).HasColumnName("Staffed_Duration_Seconds");
            });

            modelBuilder.Entity<FactPhoneSkillUsageDetail>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.HmsKey, e.PhoneSkillKey })
                    .HasName("PK_Fact_Skill_Phone_Usage_Detail");

                entity.ToTable("fact_phone_skill_usage_detail");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.PhoneSkillKey).HasColumnName("Phone_Skill_KEY");

                entity.Property(e => e.AbandonedCallCount).HasColumnName("Abandoned_Call_Count");

                entity.Property(e => e.AcdCallCount).HasColumnName("ACD_Call_Count");

                entity.Property(e => e.AcdDurationSeconds).HasColumnName("ACD_Duration_Seconds");

                entity.Property(e => e.AcwDurationSeconds).HasColumnName("ACW_Duration_Seconds");

                entity.Property(e => e.AnswerDurationSeconds).HasColumnName("Answer_Duration_Seconds");

                entity.Property(e => e.AuxDurationSeconds).HasColumnName("AUX_Duration_Seconds");

                entity.Property(e => e.AvailableDurationSeconds).HasColumnName("Available_Duration_Seconds");

                entity.Property(e => e.CallsOffered).HasColumnName("Calls_Offered");

                entity.Property(e => e.InboundCallCount).HasColumnName("Inbound_Call_Count");

                entity.Property(e => e.InboundCallTime).HasColumnName("Inbound_Call_Time");

                entity.Property(e => e.MaxDelayDurationSeconds).HasColumnName("Max_Delay_Duration_Seconds");

                entity.Property(e => e.OutboundCallCount).HasColumnName("Outbound_Call_Count");

                entity.Property(e => e.OutboundCallTime).HasColumnName("Outbound_Call_Time");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.Property(e => e.RingDurationSeconds).HasColumnName("Ring_Duration_Seconds");

                entity.Property(e => e.RonaCallCount).HasColumnName("RONA_Call_Count");

                entity.Property(e => e.StaffedDurationSeconds).HasColumnName("Staffed_Duration_Seconds");
            });

            modelBuilder.Entity<FactPhoneVdnUsageDetail>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.HmsKey, e.PhoneVdnKey })
                    .HasName("PK_Fact_VDN_Phone_Usage_Detail");

                entity.ToTable("fact_phone_vdn_usage_detail");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_KEY");

                entity.Property(e => e.PhoneVdnKey).HasColumnName("Phone_VDN_KEY");

                entity.Property(e => e.AbandonedCallCount).HasColumnName("Abandoned_Call_Count");

                entity.Property(e => e.AbandonedDurationSeconds).HasColumnName("Abandoned_Duration_Seconds");

                entity.Property(e => e.AcdCallCount).HasColumnName("ACD_Call_Count");

                entity.Property(e => e.AcdDurationSeconds).HasColumnName("ACD_Duration_Seconds");

                entity.Property(e => e.AcwDurationSeconds).HasColumnName("ACW_Duration_Seconds");

                entity.Property(e => e.AnswerDurationSeconds).HasColumnName("Answer_Duration_Seconds");

                entity.Property(e => e.AvgAbandonDurationSeconds).HasColumnName("AVG_Abandon_Duration_Seconds");

                entity.Property(e => e.AvgAnswerDurationSeconds).HasColumnName("AVG_Answer_Duration_Seconds");

                entity.Property(e => e.BackupCallCount).HasColumnName("Backup_Call_Count");

                entity.Property(e => e.InboundCallCount).HasColumnName("Inbound_Call_Count");

                entity.Property(e => e.InboundDurationSeconds).HasColumnName("Inbound_Duration_Seconds");

                entity.Property(e => e.InflowCallCount).HasColumnName("Inflow_Call_Count");

                entity.Property(e => e.MainAcdCallCount).HasColumnName("Main_ACD_Call_Count");

                entity.Property(e => e.MaxDelayDurationSeconds).HasColumnName("Max_Delay_Duration_Seconds");

                entity.Property(e => e.OutflowCallCount).HasColumnName("Outflow_Call_Count");

                entity.Property(e => e.OutflowDurationSeconds).HasColumnName("Outflow_Duration_Seconds");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");

                entity.Property(e => e.RingDurationSeconds).HasColumnName("Ring_Duration_Seconds");

                entity.Property(e => e.RonaCallCount).HasColumnName("RONA_Call_Count");
            });

            modelBuilder.Entity<FactProductLowcoststorageUsage>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.HmsKey, e.AccountKey, e.TeamKey, e.BillingDeviceKey, e.StorageKey, e.UomHardThresholdKey, e.UomAdvisoryThresholdKey, e.UomStorageUsageKey })
                    .HasName("PK_Fact_Product_LowCostStorage_Usage");

                entity.ToTable("fact_product_lowcoststorage_usage");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_LCS_Usage_Account");

                entity.HasIndex(e => e.AdvisoryThreshold)
                    .HasName("IX_LCS_Usage_Advisory_Threshold");

                entity.HasIndex(e => e.BillingDeviceKey)
                    .HasName("IX_LCS_Usage_Device");

                entity.HasIndex(e => e.HardThreshold)
                    .HasName("IX_LCS_Usage_Hard_Threshold");

                entity.HasIndex(e => e.HmsKey)
                    .HasName("IX_LCS_Usage_HMS");

                entity.HasIndex(e => e.StorageKey)
                    .HasName("IX_LCS_Usage_Storage");

                entity.HasIndex(e => e.StorageUsage)
                    .HasName("IX_LCS_Usage_Storage_Usage");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_LCS_Usage_Team");

                entity.HasIndex(e => e.TimeHmsRecordCreatedKey)
                    .HasName("IX_LCS_Usage_Time_HMS_Record_Created");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_LCS_Usage_Time");

                entity.HasIndex(e => e.TimeRecordCreatedKey)
                    .HasName("IX_LCS_Usage_Time_Record_Created");

                entity.HasIndex(e => e.UomAdvisoryThresholdKey)
                    .HasName("IX_LCS_Usage_UOM_Advisory_Threshold");

                entity.HasIndex(e => e.UomHardThresholdKey)
                    .HasName("IX_LCS_Usage_UOM_Hard_Threshold");

                entity.HasIndex(e => e.UomStorageUsageKey)
                    .HasName("IX_LCS_Usage_UOM_Storage_Usage");

                entity.Property(e => e.TimeKey).HasColumnName("Time_key");

                entity.Property(e => e.HmsKey).HasColumnName("HMS_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TeamKey).HasColumnName("team_Key");

                entity.Property(e => e.BillingDeviceKey).HasColumnName("Billing_Device_KEY");

                entity.Property(e => e.StorageKey).HasColumnName("Storage_Key");

                entity.Property(e => e.UomHardThresholdKey).HasColumnName("UOM_Hard_Threshold_KEY");

                entity.Property(e => e.UomAdvisoryThresholdKey).HasColumnName("UOM_Advisory_Threshold_KEY");

                entity.Property(e => e.UomStorageUsageKey).HasColumnName("UOM_Storage_Usage_KEY");

                entity.Property(e => e.AdvisoryThreshold)
                    .HasColumnName("Advisory_Threshold")
                    .HasColumnType("decimal");

                entity.Property(e => e.HardThreshold)
                    .HasColumnName("Hard_Threshold")
                    .HasColumnType("decimal");

                entity.Property(e => e.StorageUsage)
                    .HasColumnName("Storage_Usage")
                    .HasColumnType("decimal");

                entity.Property(e => e.TimeHmsRecordCreatedKey).HasColumnName("Time_HMS_Record_Created_KEY");

                entity.Property(e => e.TimeRecordCreatedKey).HasColumnName("Time_Record_Created_KEY");
            });

            modelBuilder.Entity<FactProductLowcoststorageUsageDaily>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.AccountKey, e.TeamKey, e.BillingDeviceKey, e.StorageKey, e.UomHardThresholdKey, e.UomAdvisoryThresholdKey, e.UomStorageUsageKey })
                    .HasName("PK_Fact_Product_LowCostStorage_Usage_Daily");

                entity.ToTable("fact_product_lowcoststorage_usage_daily");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_LCS_Usage_Account");

                entity.HasIndex(e => e.AdvisoryThreshold)
                    .HasName("IX_LCS_Usage_Advisory_Threshold");

                entity.HasIndex(e => e.BillingDeviceKey)
                    .HasName("IX_LCS_Usage_Device");

                entity.HasIndex(e => e.HardThreshold)
                    .HasName("IX_LCS_Usage_Hard_Threshold");

                entity.HasIndex(e => e.StorageKey)
                    .HasName("IX_LCS_Usage_Storage");

                entity.HasIndex(e => e.StorageUsage)
                    .HasName("IX_LCS_Usage_Storage_Usage");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_LCS_Usage_Team");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_LCS_Usage_Time");

                entity.HasIndex(e => e.UomAdvisoryThresholdKey)
                    .HasName("IX_LCS_Usage_UOM_Advisory_Threshold");

                entity.HasIndex(e => e.UomHardThresholdKey)
                    .HasName("IX_LCS_Usage_UOM_Hard_Threshold");

                entity.HasIndex(e => e.UomStorageUsageKey)
                    .HasName("IX_LCS_Usage_UOM_Storage_Usage");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.BillingDeviceKey).HasColumnName("Billing_Device_KEY");

                entity.Property(e => e.StorageKey).HasColumnName("Storage_KEY");

                entity.Property(e => e.UomHardThresholdKey).HasColumnName("UOM_Hard_Threshold_KEY");

                entity.Property(e => e.UomAdvisoryThresholdKey).HasColumnName("UOM_Advisory_Threshold_KEY");

                entity.Property(e => e.UomStorageUsageKey).HasColumnName("UOM_Storage_Usage_KEY");

                entity.Property(e => e.AdvisoryThreshold)
                    .HasColumnName("Advisory_Threshold")
                    .HasColumnType("decimal");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.HardThreshold)
                    .HasColumnName("Hard_Threshold")
                    .HasColumnType("decimal");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StorageUsage)
                    .HasColumnName("Storage_Usage")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<FactProductLowcoststorageUsageMonthly>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.AccountKey, e.TeamKey, e.BillingDeviceKey, e.StorageKey, e.UomHardThresholdKey, e.UomAdvisoryThresholdKey, e.UomStorageUsageKey })
                    .HasName("PK_Fact_Product_LowCostStorage_Usage_Monthly");

                entity.ToTable("fact_product_lowcoststorage_usage_monthly");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_LCS_Usage_Account");

                entity.HasIndex(e => e.AdvisoryThreshold)
                    .HasName("IX_LCS_Usage_Advisory_Threshold");

                entity.HasIndex(e => e.BillingDeviceKey)
                    .HasName("IX_LCS_Usage_Device");

                entity.HasIndex(e => e.HardThreshold)
                    .HasName("IX_LCS_Usage_Hard_Threshold");

                entity.HasIndex(e => e.StorageKey)
                    .HasName("IX_LCS_Usage_Storage");

                entity.HasIndex(e => e.StorageUsage)
                    .HasName("IX_LCS_Usage_Storage_Usage");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_LCS_Usage_Team");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_LCS_Usage_Time");

                entity.HasIndex(e => e.UomAdvisoryThresholdKey)
                    .HasName("IX_LCS_Usage_UOM_Advisory_Threshold");

                entity.HasIndex(e => e.UomHardThresholdKey)
                    .HasName("IX_LCS_Usage_UOM_Hard_Threshold");

                entity.HasIndex(e => e.UomStorageUsageKey)
                    .HasName("IX_LCS_Usage_UOM_Storage_Usage");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.BillingDeviceKey).HasColumnName("Billing_Device_KEY");

                entity.Property(e => e.StorageKey).HasColumnName("Storage_KEY");

                entity.Property(e => e.UomHardThresholdKey).HasColumnName("UOM_Hard_Threshold_KEY");

                entity.Property(e => e.UomAdvisoryThresholdKey).HasColumnName("UOM_Advisory_Threshold_KEY");

                entity.Property(e => e.UomStorageUsageKey).HasColumnName("UOM_Storage_Usage_KEY");

                entity.Property(e => e.AdvisoryThreshold)
                    .HasColumnName("Advisory_Threshold")
                    .HasColumnType("decimal");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("Created_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.HardThreshold)
                    .HasColumnName("Hard_Threshold")
                    .HasColumnType("decimal");

                entity.Property(e => e.RecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.RecordUpdatedDatetime)
                    .HasColumnName("Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.StorageUsage)
                    .HasColumnName("Storage_Usage")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<FactProductUsage>(entity =>
            {
                entity.HasKey(e => new { e.AccountKey, e.DeviceKey, e.ProductKey, e.TeamKey, e.TimeKey, e.UnitOfMeasureKey, e.SourceKey, e.StatusKey })
                    .HasName("PK_Fact_Product_Usage");

                entity.ToTable("fact_product_usage");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IDX_FACT_PRODUCT_USAGE_ACCOUNT");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IDX_FACT_PRODUCT_USAGE_DEVICE");

                entity.HasIndex(e => e.ProductKey)
                    .HasName("IDX_FACT_PRODUCT_USAGE_PRODUCT");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IDX_FACT_PRODUCT_USAGE_TIME");

                entity.HasIndex(e => new { e.TimeKey, e.AccountKey, e.ProductKey, e.DeviceKey, e.UsageQuantityRunningSum })
                    .HasName("IDX_Fact_Product_Usage_Load");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.ProductKey).HasColumnName("Product_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_of_Measure_KEY");

                entity.Property(e => e.SourceKey).HasColumnName("Source_Key");

                entity.Property(e => e.StatusKey).HasColumnName("status_key");

                entity.Property(e => e.ProvisionedQuantity)
                    .HasColumnName("Provisioned_Quantity")
                    .HasColumnType("decimal");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.SpecialPricingFlag).HasColumnName("Special_Pricing_Flag");

                entity.Property(e => e.UsageCount).HasColumnName("Usage_Count");

                entity.Property(e => e.UsageQuantity)
                    .HasColumnName("Usage_Quantity")
                    .HasColumnType("decimal");

                entity.Property(e => e.UsageQuantityRunningSum)
                    .HasColumnName("Usage_Quantity_Running_Sum")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<FactRevenue>(entity =>
            {
                entity.HasKey(e => new { e.TeamKey, e.RevenueTypeKey, e.AccountKey, e.DeviceKey, e.ProductKey, e.ChurnReasonDetailKey, e.TimeMonthKey, e.TimePostedKey, e.DeviceSsk, e.LatestEntry, e.TransactionType, e.RevenueSsk, e.OpportunityKey, e.IncidentKey, e.ChurnProbabilityKey, e.ChurnBridgeKey })
                    .HasName("PK_Fact_Revenue");

                entity.ToTable("FACT_Revenue");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_Account_KEY");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IX_Device_KEY");

                entity.HasIndex(e => e.ProductKey)
                    .HasName("IX_Product_KEY");

                entity.HasIndex(e => e.RevenueSsk)
                    .HasName("IX_Revenue_SSK");

                entity.HasIndex(e => e.RevenueTypeKey)
                    .HasName("IX_Revenue_Type_KEY");

                entity.HasIndex(e => e.TimeMonthKey)
                    .HasName("IX_Time_Month_KEY");

                entity.HasIndex(e => new { e.RevenueRecordCreatedBy, e.ChurnProbabilityKey })
                    .HasName("IX_Probability_Key_Record_Type");

                entity.HasIndex(e => new { e.AccountKey, e.TimeMonthKey, e.MeasureDollarAmount, e.LocalCurrencyTypeUom, e.RevenueTypeKey })
                    .HasName("IX_FACT_Revenue_RTKMI");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.RevenueTypeKey).HasColumnName("Revenue_Type_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.ProductKey).HasColumnName("Product_KEY");

                entity.Property(e => e.ChurnReasonDetailKey).HasColumnName("Churn_Reason_Detail_KEY");

                entity.Property(e => e.TimeMonthKey).HasColumnName("Time_Month_KEY");

                entity.Property(e => e.TimePostedKey).HasColumnName("Time_Posted_KEY");

                entity.Property(e => e.DeviceSsk)
                    .HasColumnName("Device_SSK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.LatestEntry).HasColumnName("Latest_Entry");

                entity.Property(e => e.TransactionType)
                    .HasColumnName("Transaction_Type")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.RevenueSsk)
                    .HasColumnName("Revenue_SSK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.OpportunityKey).HasColumnName("Opportunity_KEY");

                entity.Property(e => e.IncidentKey).HasColumnName("Incident_KEY");

                entity.Property(e => e.ChurnProbabilityKey).HasColumnName("Churn_Probability_Key");

                entity.Property(e => e.ChurnBridgeKey).HasColumnName("Churn_Bridge_Key");

                entity.Property(e => e.ChurnWouldConsiderFlag).HasColumnName("Churn_Would_Consider_Flag");

                entity.Property(e => e.LocalCurrencyAmount)
                    .HasColumnName("Local_Currency_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.LocalCurrencyTypeUom)
                    .HasColumnName("Local_Currency_Type_UOM")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.MeasureDollarAmount)
                    .HasColumnName("measure_Dollar_Amount")
                    .HasColumnType("money");

                entity.Property(e => e.MeasureRecordCount).HasColumnName("measure_Record_Count");

                entity.Property(e => e.RevenueRecordCreatedBy)
                    .HasColumnName("Revenue_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueRecordCreatedDatetime)
                    .HasColumnName("Revenue_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueRecordUpdatedBy)
                    .HasColumnName("Revenue_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueRecordUpdatedDatetime)
                    .HasColumnName("Revenue_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueSetOfBooksKey).HasColumnName("Revenue_Set_of_Books_Key");

                entity.Property(e => e.RevenueSourceSystemName)
                    .HasColumnName("Revenue_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueTypeAccountLevelKey).HasColumnName("Revenue_Type_Account_Level_KEY");

                entity.Property(e => e.RevenueTypeDeviceLevelKey).HasColumnName("Revenue_Type_Device_Level_KEY");

                entity.Property(e => e.RevenueTypeOpportunityLevelKey).HasColumnName("Revenue_Type_Opportunity_Level_KEY");

                entity.Property(e => e.SubmittedDateKey).HasColumnName("Submitted_Date_KEY");

                entity.Property(e => e.TimeDueOfflineDateKey).HasColumnName("Time_Due_Offline_Date_Key");
            });

            modelBuilder.Entity<FactRevenueRecognition>(entity =>
            {
                entity.HasKey(e => new { e.RevenueRecognitionSsk, e.RevenueRecognitionTimeKey, e.RevenueRecognitionCreateTimeKey, e.RevenueRecognitionAuthorizedTimeKey, e.RevenueRecognitionCompletedTimeKey, e.RevenueRecognitionAccountKey, e.RevenueRecognitionDeviceKey, e.RevenueRecognitionTeamKey, e.RevenueRecognitionBdcContactKey, e.RevenueRecognitionIncidentKey, e.RevenueRecognitionIncidentBillingKey, e.RevenueRecognitionUnitOfMeasureKey, e.RevenueRecognitionRevenueStatusKey, e.RevenueRecognitionRevenueDeleteReasonKey, e.RevenueRecognitionRevenueCategoryKey })
                    .HasName("PK_Fact_Revenue_Recognition_1");

                entity.ToTable("fact_revenue_recognition");

                entity.HasIndex(e => e.RevenueRecognitionAccountKey)
                    .HasName("IX_Account_Key");

                entity.HasIndex(e => e.RevenueRecognitionAuthorizedTimeKey)
                    .HasName("IX_Authorized_Time_Key");

                entity.HasIndex(e => e.RevenueRecognitionBdcContactKey)
                    .HasName("IX_BDC_Contact_Key");

                entity.HasIndex(e => e.RevenueRecognitionCompletedTimeKey)
                    .HasName("IX_Completed_Time_Key");

                entity.HasIndex(e => e.RevenueRecognitionCreateTimeKey)
                    .HasName("IX_Create_Time_Key");

                entity.HasIndex(e => e.RevenueRecognitionDeviceKey)
                    .HasName("IX_Device_Key");

                entity.HasIndex(e => e.RevenueRecognitionIncidentBillingKey)
                    .HasName("IX_Incident_Billing_Key");

                entity.HasIndex(e => e.RevenueRecognitionIncidentKey)
                    .HasName("IX_Incident_Key");

                entity.HasIndex(e => e.RevenueRecognitionRevenueCategoryKey)
                    .HasName("IX_Category_Key");

                entity.HasIndex(e => e.RevenueRecognitionRevenueDeleteReasonKey)
                    .HasName("IX_Delete_Reason_Key");

                entity.HasIndex(e => e.RevenueRecognitionRevenueStatusKey)
                    .HasName("IX_Status_Key");

                entity.HasIndex(e => e.RevenueRecognitionTeamKey)
                    .HasName("IX_Team_Key");

                entity.HasIndex(e => e.RevenueRecognitionUnitOfMeasureKey)
                    .HasName("IX_Unit_Of_Measure_Key");

                entity.Property(e => e.RevenueRecognitionSsk)
                    .HasColumnName("Revenue_Recognition_SSK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueRecognitionTimeKey).HasColumnName("Revenue_Recognition_Time_Key");

                entity.Property(e => e.RevenueRecognitionCreateTimeKey).HasColumnName("Revenue_Recognition_Create_Time_Key");

                entity.Property(e => e.RevenueRecognitionAuthorizedTimeKey).HasColumnName("Revenue_Recognition_Authorized_Time_Key");

                entity.Property(e => e.RevenueRecognitionCompletedTimeKey).HasColumnName("Revenue_Recognition_Completed_Time_Key");

                entity.Property(e => e.RevenueRecognitionAccountKey).HasColumnName("Revenue_Recognition_Account_Key");

                entity.Property(e => e.RevenueRecognitionDeviceKey).HasColumnName("Revenue_Recognition_Device_Key");

                entity.Property(e => e.RevenueRecognitionTeamKey).HasColumnName("Revenue_Recognition_Team_Key");

                entity.Property(e => e.RevenueRecognitionBdcContactKey).HasColumnName("Revenue_Recognition_BDC_Contact_Key");

                entity.Property(e => e.RevenueRecognitionIncidentKey).HasColumnName("Revenue_Recognition_Incident_Key");

                entity.Property(e => e.RevenueRecognitionIncidentBillingKey).HasColumnName("Revenue_Recognition_Incident_Billing_Key");

                entity.Property(e => e.RevenueRecognitionUnitOfMeasureKey).HasColumnName("Revenue_Recognition_Unit_Of_Measure_Key");

                entity.Property(e => e.RevenueRecognitionRevenueStatusKey).HasColumnName("Revenue_Recognition_Revenue_Status_Key");

                entity.Property(e => e.RevenueRecognitionRevenueDeleteReasonKey).HasColumnName("Revenue_Recognition_Revenue_Delete_Reason_Key");

                entity.Property(e => e.RevenueRecognitionRevenueCategoryKey).HasColumnName("Revenue_Recognition_Revenue_Category_Key");

                entity.Property(e => e.RevenueRecognitionMrrAmount)
                    .HasColumnName("Revenue_Recognition_MRR_Amount")
                    .HasColumnType("decimal");

                entity.Property(e => e.RevenueRecognitionOneTimePaymentAmount)
                    .HasColumnName("Revenue_Recognition_One_Time_Payment_Amount")
                    .HasColumnType("decimal");

                entity.Property(e => e.RevenueRecognitionRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Recognition_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueRecognitionRecordCreatedDatetime)
                    .HasColumnName("Revenue_Recognition_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueRecognitionRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Revenue_Recognition_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RevenueRecognitionRecordUpdatedDatetime)
                    .HasColumnName("Revenue_Recognition_Record_Updated_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevenueRecognitionTypeKey).HasColumnName("Revenue_Recognition_Type_Key");
            });

            modelBuilder.Entity<FactSkuAssignmentCurrentMonth>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.SkuKey })
                    .HasName("PK_Fact_SKU_Assignment_Current_Month");

                entity.ToTable("FACT_SKU_Assignment_Current_Month");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("ix_account_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("ix_device_key");

                entity.HasIndex(e => e.SkuKey)
                    .HasName("ix_sku_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("ix_team_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("ix_time_key");

                entity.HasIndex(e => e.TimeMonthKey)
                    .HasName("ix_time_month_key");

                entity.HasIndex(e => new { e.SkuKey, e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.MeasureRecordCount, e.RecordCreatedTimeKey, e.RecordCreatedByKey, e.RecordUpdatedTimeKey, e.RecordUpdatedByKey, e.SourceSystemNameKey, e.RecordCreatedHmsKey, e.RecordUpdatedHmsKey, e.ServerPartsId, e.TimeMonthKey })
                    .HasName("_dta_index_FACT_SKU_Assignment_Current_Mont_16_1337211964__K5_K1_K2_K3_K4_K6_K7_K8_K9_K10_K11_K12_K13_K14_K15");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.SkuKey).HasColumnName("SKU_KEY");

                entity.Property(e => e.MeasureRecordCount).HasColumnName("measure_Record_Count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.ServerPartsId).HasColumnName("Server_parts_id");

                entity.Property(e => e.SourceSystemNameKey).HasColumnName("Source_System_Name_key");

                entity.Property(e => e.TimeMonthKey).HasColumnName("Time_Month_KEY");
            });

            modelBuilder.Entity<FactSkuAssignmentExtendedAttribute>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.SkuKey, e.SkuExtendedAttributeKey })
                    .HasName("PK_Fact_Sku_Assignment_Extended_Attribute_1");

                entity.ToTable("fact_sku_assignment_extended_attribute");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("idx_account_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("idx_device_key");

                entity.HasIndex(e => e.Id)
                    .HasName("id_fact");

                entity.HasIndex(e => e.SkuExtendedAttributeKey)
                    .HasName("idx_sku_extended_attribute_key");

                entity.HasIndex(e => e.SkuKey)
                    .HasName("idx_sku_key");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("idx_team_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("idx_time_key");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.SkuKey).HasColumnName("Sku_Key");

                entity.Property(e => e.SkuExtendedAttributeKey).HasColumnName("Sku_Extended_Attribute_Key");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_Count");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_Hms_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordSourceKey).HasColumnName("Record_Source_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_Hms_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");
            });

            modelBuilder.Entity<FactSkuAssignmentExtendedAttributeMonthly>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.SkuKey, e.SkuExtendedAttributeKey })
                    .HasName("PK_Fact_Sku_Assignment_Extended_Attribute_Monthly");

                entity.ToTable("Fact_Sku_Assignment_Extended_Attribute_Monthly");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("idx_account_key");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("idx_device_key");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("idx_time_key");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.TimeKey).HasColumnName("Time_Key");

                entity.Property(e => e.AccountKey).HasColumnName("Account_Key");

                entity.Property(e => e.TeamKey).HasColumnName("Team_Key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_Key");

                entity.Property(e => e.SkuKey).HasColumnName("sku_key");

                entity.Property(e => e.SkuExtendedAttributeKey).HasColumnName("Sku_Extended_Attribute_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_Hms_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordSourceKey).HasColumnName("Record_Source_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_Hms_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.SkuAttributeSsk)
                    .HasColumnName("sku_attribute_ssk")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<FactSkuAssignmentHistory>(entity =>
            {
                entity.HasKey(e => new { e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.SkuKey })
                    .HasName("PK_Fact_SKU_Assignment");

                entity.ToTable("Fact_Sku_Assignment_History");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_Account_KEY");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IX_Device_KEY");

                entity.HasIndex(e => e.SkuKey)
                    .HasName("IX_SKU_KEY");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_Team_KEY");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_Time_KEY");

                entity.HasIndex(e => e.TimeMonthKey)
                    .HasName("IX_Time_Month_Key");

                entity.HasIndex(e => new { e.SkuKey, e.TimeKey, e.AccountKey, e.TeamKey, e.DeviceKey, e.MeasureRecordCount, e.RecordCreatedTimeKey, e.RecordCreatedByKey, e.RecordUpdatedTimeKey, e.RecordUpdatedByKey, e.SourceSystemNameKey, e.RecordCreatedHmsKey, e.RecordUpdatedHmsKey, e.ServerPartsId, e.TimeMonthKey })
                    .HasName("_dta_index_Fact_Sku_Assignment_History_16_1638296896__K5_K1_K2_K3_K4_K6_K12_K13_K14_K15_K16_K17_K18_K19_K20");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.SkuKey).HasColumnName("SKU_KEY");

                entity.Property(e => e.MeasureRecordCount).HasColumnName("measure_Record_Count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_Key");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_Key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_Key");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_Key");

                entity.Property(e => e.ServerPartsId).HasColumnName("Server_parts_id");

                entity.Property(e => e.SourceSystemNameKey).HasColumnName("Source_System_Name_key");

                entity.Property(e => e.TimeMonthKey).HasColumnName("Time_Month_KEY");
            });

            modelBuilder.Entity<FactSubscription>(entity =>
            {
                entity.HasKey(e => e.SubscriptionKey)
                    .HasName("PK_Fact_Subscription");

                entity.ToTable("fact_subscription");

                entity.HasIndex(e => e.AccountKey)
                    .HasName("IX_Account_KEY");

                entity.HasIndex(e => e.DeviceKey)
                    .HasName("IX_Device_KEY");

                entity.HasIndex(e => e.SubscriptionTypeKey)
                    .HasName("IX_Subscription_Type_KEY");

                entity.HasIndex(e => e.TeamKey)
                    .HasName("IX_Team_KEY");

                entity.HasIndex(e => e.TimeKey)
                    .HasName("IX_Time_KEY");

                entity.HasIndex(e => e.UnitOfMeasureKey)
                    .HasName("IX_UOM_KEY");

                entity.Property(e => e.SubscriptionKey).HasColumnName("Subscription_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.BillableStatusKey).HasColumnName("Billable_Status_Key");

                entity.Property(e => e.DeviceKey).HasColumnName("Device_KEY");

                entity.Property(e => e.ManagedExchangeAccountNumber)
                    .HasColumnName("Managed_Exchange_Account_Number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ManagedExchangeDomainKey).HasColumnName("Managed_Exchange_Domain_Key");

                entity.Property(e => e.SubscriptionAmount)
                    .HasColumnName("Subscription_Amount")
                    .HasColumnType("decimal");

                entity.Property(e => e.SubscriptionCancelled).HasColumnName("Subscription_Cancelled");

                entity.Property(e => e.SubscriptionRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Subscription_Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionRecordCreatedDateTime)
                    .HasColumnName("Subscription_Record_Created_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Subscription_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionRecordUpdatedDateTime)
                    .HasColumnName("Subscription_Record_Updated_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionSourceSystemName)
                    .HasColumnName("Subscription_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionSsk)
                    .IsRequired()
                    .HasColumnName("Subscription_SSK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubscriptionStatusKey).HasColumnName("Subscription_Status_Key");

                entity.Property(e => e.SubscriptionTypeKey).HasColumnName("Subscription_Type_KEY");

                entity.Property(e => e.SubscriptionValidFlag).HasColumnName("Subscription_Valid_Flag");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.TimeKey).HasColumnName("Time_KEY");

                entity.Property(e => e.UnitOfMeasureKey).HasColumnName("Unit_of_Measure_KEY");
            });

            modelBuilder.Entity<FactSubscriptionAggMonthly>(entity =>
            {
                entity.HasKey(e => e.SubscriptionAggMonthlyKey)
                    .HasName("PK_Fact_Subscription_AGG_Monthly");

                entity.ToTable("Fact_Subscription_AGG_Monthly");

                entity.HasIndex(e => e.SubscriptionAggMonthlyAccountKey)
                    .HasName("IX_Account_KEY");

                entity.HasIndex(e => e.SubscriptionAggMonthlyDeviceKey)
                    .HasName("IX_Device_KEY");

                entity.HasIndex(e => e.SubscriptionAggMonthlySsk)
                    .HasName("idx_subscription_ssk");

                entity.HasIndex(e => e.SubscriptionAggMonthlySubscriptionTypeKey)
                    .HasName("IX_Subscription_Type_KEY");

                entity.HasIndex(e => e.SubscriptionAggMonthlyTeamKey)
                    .HasName("IX_Team_KEY");

                entity.HasIndex(e => e.SubscriptionAggMonthlyTimeKey)
                    .HasName("IX_TIme_KEY");

                entity.HasIndex(e => e.SubscriptionAggMonthlyUnitOfMeasureKey)
                    .HasName("IX_UOM_KEY");

                entity.HasIndex(e => e.SubscriptionAggMonthlyValidFlag)
                    .HasName("IX_Valid");

                entity.Property(e => e.SubscriptionAggMonthlyKey).HasColumnName("Subscription_AGG_Monthly_KEY");

                entity.Property(e => e.SubscriptionAggMonthlyAccountKey).HasColumnName("Subscription_AGG_Monthly_Account_KEY");

                entity.Property(e => e.SubscriptionAggMonthlyCancelled).HasColumnName("Subscription_AGG_Monthly_Cancelled");

                entity.Property(e => e.SubscriptionAggMonthlyDeviceKey).HasColumnName("Subscription_AGG_Monthly_Device_KEY");

                entity.Property(e => e.SubscriptionAggMonthlyRecordAddedBy)
                    .HasColumnName("Subscription_AGG_Monthly_Record_Added_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionAggMonthlyRecordAddedDateTime)
                    .HasColumnName("Subscription_AGG_Monthly_Record_Added_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionAggMonthlyRecordUpdatedBy)
                    .HasColumnName("Subscription_AGG_Monthly_Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SubscriptionAggMonthlyRecordUpdatedDateTime)
                    .HasColumnName("Subscription_AGG_Monthly_Record_Updated_DateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscriptionAggMonthlySsk)
                    .HasColumnName("Subscription_AGG_Monthly_SSK")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SubscriptionAggMonthlySubscription)
                    .HasColumnName("Subscription_AGG_Monthly_Subscription")
                    .HasColumnType("decimal");

                entity.Property(e => e.SubscriptionAggMonthlySubscriptionTypeKey).HasColumnName("Subscription_AGG_Monthly_Subscription_Type_KEY");

                entity.Property(e => e.SubscriptionAggMonthlyTeamKey).HasColumnName("Subscription_AGG_Monthly_Team_KEY");

                entity.Property(e => e.SubscriptionAggMonthlyTimeKey).HasColumnName("Subscription_AGG_Monthly_Time_KEY");

                entity.Property(e => e.SubscriptionAggMonthlyUnitOfMeasureKey).HasColumnName("Subscription_AGG_Monthly_Unit_of_Measure_KEY");

                entity.Property(e => e.SubscriptionAggMonthlyValidFlag).HasColumnName("Subscription_AGG_Monthly_Valid_Flag");
            });

            modelBuilder.Entity<FactSurveyQuestionAnswer>(entity =>
            {
                entity.HasKey(e => new { e.ResponseStartTimeKey, e.ResponseStartHmsKey, e.ResponseEndTimeKey, e.ResponseEndHmsKey, e.AccountKey, e.TeamKey, e.ContactKey, e.SurveyResponseKey, e.SurveyAnswerKey, e.SurveyKey, e.SurveyQuestionKey, e.AnswerIdNk, e.ResponseIdNk })
                    .HasName("PK_Fact_Survey_Question_Answer");

                entity.ToTable("fact_survey_question_answer");

                entity.Property(e => e.ResponseStartTimeKey).HasColumnName("Response_Start_Time_KEY");

                entity.Property(e => e.ResponseStartHmsKey).HasColumnName("Response_Start_HMS_KEY");

                entity.Property(e => e.ResponseEndTimeKey).HasColumnName("Response_End_Time_KEY");

                entity.Property(e => e.ResponseEndHmsKey).HasColumnName("Response_End_HMS_KEY");

                entity.Property(e => e.AccountKey).HasColumnName("Account_KEY");

                entity.Property(e => e.TeamKey).HasColumnName("Team_KEY");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_Key");

                entity.Property(e => e.SurveyResponseKey).HasColumnName("Survey_Response_KEY");

                entity.Property(e => e.SurveyAnswerKey).HasColumnName("Survey_Answer_KEY");

                entity.Property(e => e.SurveyKey).HasColumnName("Survey_Key");

                entity.Property(e => e.SurveyQuestionKey).HasColumnName("Survey_Question_KEY");

                entity.Property(e => e.AnswerIdNk).HasColumnName("Answer_ID_NK");

                entity.Property(e => e.ResponseIdNk).HasColumnName("Response_ID_NK");

                entity.Property(e => e.AmContactKey).HasColumnName("AM_Contact_Key");

                entity.Property(e => e.BdcContactKey).HasColumnName("BDC_Contact_Key");

                entity.Property(e => e.ContactRoleKey).HasColumnName("Contact_Role_Key");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_Count");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("Record_Created_By_KEY");

                entity.Property(e => e.RecordCreatedHmsKey).HasColumnName("Record_Created_HMS_Key");

                entity.Property(e => e.RecordCreatedTimeKey).HasColumnName("Record_Created_Time_KEY");

                entity.Property(e => e.RecordSourceKey)
                    .IsRequired()
                    .HasColumnName("Record_source_Key")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("Record_Updated_By_KEY");

                entity.Property(e => e.RecordUpdatedHmsKey).HasColumnName("Record_Updated_HMS_Key");

                entity.Property(e => e.RecordUpdatedTimeKey).HasColumnName("Record_Updated_Time_KEY");
            });

            modelBuilder.Entity<FactTicketsCreated>(entity =>
            {
                entity.HasKey(e => new { e.TicketKey, e.CreatedTimeKey, e.CreatedTimeHmsKey, e.CreatedTimeSourceTimezoneUomKey, e.CreatedTimeKeyCst, e.CreatedTimeHmsKeyCst, e.CreatedTimeKeyUtc, e.CreatedTimeHmsKeyUtc, e.TicketCreatedByKey, e.TicketSubmittedByKey, e.AccountKey })
                    .HasName("PK_fact_tickets_created");

                entity.ToTable("fact_tickets_created");

                entity.Property(e => e.TicketKey).HasColumnName("ticket_key");

                entity.Property(e => e.CreatedTimeKey).HasColumnName("created_time_key");

                entity.Property(e => e.CreatedTimeHmsKey).HasColumnName("created_time_hms_key");

                entity.Property(e => e.CreatedTimeSourceTimezoneUomKey).HasColumnName("created_time_source_timezone_uom_key");

                entity.Property(e => e.CreatedTimeKeyCst).HasColumnName("created_time_key_cst");

                entity.Property(e => e.CreatedTimeHmsKeyCst).HasColumnName("created_time_hms_key_cst");

                entity.Property(e => e.CreatedTimeKeyUtc).HasColumnName("created_time_key_utc");

                entity.Property(e => e.CreatedTimeHmsKeyUtc).HasColumnName("created_time_hms_key_utc");

                entity.Property(e => e.TicketCreatedByKey).HasColumnName("ticket_created_by_key");

                entity.Property(e => e.TicketSubmittedByKey).HasColumnName("ticket_submitted_by_key");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.InitialQueueKey).HasColumnName("initial_queue_key");

                entity.Property(e => e.InitialTeamKey).HasColumnName("initial_team_key");

                entity.Property(e => e.RecordCreatedByHmsKey).HasColumnName("record_created_by_hms_key");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("record_created_by_key");

                entity.Property(e => e.RecordCreatedByTimeKey).HasColumnName("record_created_by_time_key");

                entity.Property(e => e.RecordUpdatedByHmsKey).HasColumnName("record_updated_by_hms_key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("record_updated_by_key");

                entity.Property(e => e.RecordUpdatedByTimeKey).HasColumnName("record_updated_by_time_key");

                entity.Property(e => e.SourceSystemKey).HasColumnName("Source_System_Key");

                entity.Property(e => e.TicketCount).HasColumnName("ticket_count");
            });

            modelBuilder.Entity<FactTicketsFirstresponse>(entity =>
            {
                entity.HasKey(e => new { e.TicketKey, e.TicketCreatedTimeKey, e.TicketCreatedHmsKey, e.SourceDateUomKey, e.SourceSystemKey, e.TicketCreatedByKey, e.TicketSubmittedByKey, e.AccountKey, e.TeamKey, e.FirstResponseByKey, e.FirstResponseTimeKey, e.FirstResponseHmsKey })
                    .HasName("PK_fact_tickets_firstresponse");

                entity.ToTable("Fact_Tickets_Firstresponse");

                entity.Property(e => e.TicketKey).HasColumnName("ticket_key");

                entity.Property(e => e.TicketCreatedTimeKey).HasColumnName("ticket_created_time_key");

                entity.Property(e => e.TicketCreatedHmsKey).HasColumnName("ticket_created_hms_key");

                entity.Property(e => e.SourceDateUomKey).HasColumnName("source_date_uom_key");

                entity.Property(e => e.SourceSystemKey).HasColumnName("Source_System_Key");

                entity.Property(e => e.TicketCreatedByKey).HasColumnName("ticket_created_by_key");

                entity.Property(e => e.TicketSubmittedByKey).HasColumnName("ticket_submitted_by_key");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.FirstResponseByKey).HasColumnName("first_response_by_key");

                entity.Property(e => e.FirstResponseTimeKey).HasColumnName("first_response_time_key");

                entity.Property(e => e.FirstResponseHmsKey).HasColumnName("first_response_hms_key");

                entity.Property(e => e.CstFirstResponseHmsKey).HasColumnName("cst_first_response_hms_key");

                entity.Property(e => e.CstFirstResponseTimeKey).HasColumnName("cst_first_response_time_key");

                entity.Property(e => e.CstTicketCreatedHmsKey).HasColumnName("cst_ticket_created_hms_key");

                entity.Property(e => e.CstTicketCreatedTimeKey).HasColumnName("cst_ticket_created_time_key");

                entity.Property(e => e.FirstResponseCommentKey)
                    .IsRequired()
                    .HasColumnName("First_Response_Comment_Key")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FirstResponseDurationUk).HasColumnName("first_response_duration_uk");

                entity.Property(e => e.FirstResponseDurationUs).HasColumnName("first_response_duration_us");

                entity.Property(e => e.RecordCreatedByHmsKey).HasColumnName("record_created_by_hms_key");

                entity.Property(e => e.RecordCreatedByKey).HasColumnName("record_created_by_key");

                entity.Property(e => e.RecordCreatedByTimeKey).HasColumnName("record_created_by_time_key");

                entity.Property(e => e.RecordUpdatedByHmsKey).HasColumnName("record_updated_by_hms_key");

                entity.Property(e => e.RecordUpdatedByKey).HasColumnName("record_updated_by_key");

                entity.Property(e => e.RecordUpdatedByTimeKey).HasColumnName("record_updated_by_time_key");

                entity.Property(e => e.UtcFirstResponseHmsKey).HasColumnName("utc_first_response_hms_key");

                entity.Property(e => e.UtcFirstResponseTimeKey).HasColumnName("utc_first_response_time_key");

                entity.Property(e => e.UtcTicketCreatedHmsKey).HasColumnName("utc_ticket_created_hms_key");

                entity.Property(e => e.UtcTicketCreatedTimeKey).HasColumnName("utc_ticket_created_time_key");
            });

            modelBuilder.Entity<FactTicketsWorked>(entity =>
            {
                entity.HasKey(e => new { e.TicketKey, e.WorkDoneAtTimeKey, e.WorkDoneAtHmsKey, e.SourceDateUomKey, e.TicketWorktypeKey, e.WorkDoneByKey, e.CurrentQueueKey, e.AccountKey, e.TeamKey, e.SourceSystemKey })
                    .HasName("PK_Fact_Tickets_Worked");

                entity.ToTable("Fact_Tickets_Worked");

                entity.Property(e => e.TicketKey).HasColumnName("ticket_key");

                entity.Property(e => e.WorkDoneAtTimeKey).HasColumnName("work_done_at_time_key");

                entity.Property(e => e.WorkDoneAtHmsKey).HasColumnName("work_done_at_hms_key");

                entity.Property(e => e.SourceDateUomKey).HasColumnName("Source_Date_UOM_key");

                entity.Property(e => e.TicketWorktypeKey).HasColumnName("ticket_worktype_key");

                entity.Property(e => e.WorkDoneByKey).HasColumnName("work_done_by_key");

                entity.Property(e => e.CurrentQueueKey).HasColumnName("current_queue_key");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.SourceSystemKey).HasColumnName("source_system_Key");

                entity.Property(e => e.Durationbilled).HasColumnName("durationbilled");

                entity.Property(e => e.Durationworked).HasColumnName("durationworked");

                entity.Property(e => e.TicketWorkedRecordCreatedByKey).HasColumnName("ticket_worked_record_created_by_key");

                entity.Property(e => e.TicketWorkedRecordCreatedHmsKey).HasColumnName("ticket_worked_record_created_hms_key");

                entity.Property(e => e.TicketWorkedRecordCreatedTimeKey).HasColumnName("ticket_worked_record_created_time_key");

                entity.Property(e => e.TicketWorkedRecordUpdatedByKey).HasColumnName("ticket_worked_record_updated_by_key");

                entity.Property(e => e.TicketWorkedRecordUpdatedHmsKey).HasColumnName("ticket_worked_record_updated_hms_key");

                entity.Property(e => e.TicketWorkedRecordUpdatedTimeKey).HasColumnName("ticket_worked_record_updated_time_key");

                entity.Property(e => e.WorkDoneAtCstHmsKey).HasColumnName("work_done_at_CST_hms_key");

                entity.Property(e => e.WorkDoneAtCstTimeKey).HasColumnName("work_done_at_CST_time_key");

                entity.Property(e => e.WorkDoneAtUtcHmsKey).HasColumnName("work_done_at_UTC_hms_key");

                entity.Property(e => e.WorkDoneAtUtcTimeKey).HasColumnName("work_done_at_UTC_time_key");
            });

            modelBuilder.Entity<GateDeviceInstance>(entity =>
            {
                entity.HasKey(e => e.GateDeviceInstanceKey)
                    .HasName("PK_gate_device_instance_key");

                entity.ToTable("gate_device_instance");

                entity.Property(e => e.GateDeviceInstanceKey).HasColumnName("gate_device_instance_key");

                entity.Property(e => e.CloudInstanceKey).HasColumnName("cloud_instance_key");

                entity.Property(e => e.CreatedDatetime)
                    .HasColumnName("created_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceKey).HasColumnName("device_key");

                entity.Property(e => e.ModifiedDatetime)
                    .HasColumnName("modified_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordType)
                    .HasColumnName("record_type")
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<IpBurnRate>(entity =>
            {
                entity.HasKey(e => e.Recid)
                    .HasName("PK_ip_burn_rate");

                entity.ToTable("ip_burn_rate");

                entity.Property(e => e.Recid).HasColumnName("recid");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("datetime");

                entity.Property(e => e.PercentOfTotalIpsUsed)
                    .HasColumnName("percent_of_total_ips_used")
                    .HasColumnType("decimal");

                entity.Property(e => e.TotalIpsAssigned).HasColumnName("total_ips_assigned");

                entity.Property(e => e.TotalIpsAssignedToDc).HasColumnName("total_ips_assigned_to_dc");

                entity.Property(e => e.TotalIpsAvaliable).HasColumnName("total_ips_avaliable");
            });

            modelBuilder.Entity<ReportAccountDeviceMbuUsageMonthly>(entity =>
            {
                entity.HasKey(e => new { e.AccountNumber, e.DeviceNumber, e.TimeMonthKey })
                    .HasName("PK_Report_Account_Device_MBU_Usage_Monthly");

                entity.ToTable("report_account_device_mbu_usage_monthly");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("Account_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.DeviceNumber).HasColumnName("Device_Number");

                entity.Property(e => e.TimeMonthKey)
                    .HasColumnName("Time_Month_Key")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.AccountBdc)
                    .HasColumnName("Account_BDC")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountHasUnmetered)
                    .IsRequired()
                    .HasColumnName("Account_Has_Unmetered")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountManager)
                    .HasColumnName("Account_Manager")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountTeamName)
                    .HasColumnName("Account_Team_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DurationInMinutes)
                    .HasColumnName("Duration_In_Minutes")
                    .HasColumnType("decimal");

                entity.Property(e => e.LocalCurrencyOverageFee)
                    .HasColumnName("Local_Currency_Overage_Fee")
                    .HasColumnType("decimal");

                entity.Property(e => e.LocalCurrencyType)
                    .IsRequired()
                    .HasColumnName("Local_Currency_Type")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.OverageFeeType)
                    .IsRequired()
                    .HasColumnName("Overage_fee_Type")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.OverageRate)
                    .HasColumnName("Overage_Rate")
                    .HasColumnType("decimal");

                entity.Property(e => e.Subscription).HasColumnType("decimal");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TotalDaysSizeGb28)
                    .HasColumnName("Total_Days_Size_GB_28")
                    .HasColumnType("decimal");

                entity.Property(e => e.TotalSizeGb)
                    .HasColumnName("Total_Size_GB")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<ReportBandwidthOverage>(entity =>
            {
                entity.ToTable("report_bandwidth_overage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.DeviceNumber).HasColumnName("Device_Number");

                entity.Property(e => e.RecordCreatedBy)
                    .HasColumnName("Record_Created_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordCreatedDate)
                    .HasColumnName("Record_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordUpdatedBy)
                    .HasColumnName("Record_Updated_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecordUpdatedDate)
                    .HasColumnName("Record_Updated_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Subscription).HasColumnType("decimal");

                entity.Property(e => e.Team).HasColumnType("varchar(80)");

                entity.Property(e => e.Usage).HasColumnType("decimal");
            });

            modelBuilder.Entity<ReportCommvaultMigration>(entity =>
            {
                entity.HasKey(e => e.ReportCommvaultMigriationId)
                    .HasName("PK_Report_Commvault_Migration");

                entity.ToTable("Report_Commvault_Migration");

                entity.Property(e => e.ReportCommvaultMigriationId).HasColumnName("Report_Commvault_Migriation_ID");

                entity.Property(e => e.ChildId).HasColumnName("Child_ID");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("Client_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CommCell)
                    .HasColumnName("Comm_Cell")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreationDate)
                    .HasColumnName("Creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("varchar(1024)");

                entity.Property(e => e.DeviceNumber)
                    .HasColumnName("Device_Number")
                    .HasColumnType("varchar(99)");

                entity.Property(e => e.DisplayName)
                    .HasColumnName("Display_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InterfaceName)
                    .HasColumnName("Interface_Name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ReportExchangeRate>(entity =>
            {
                entity.ToTable("report_exchange_rate");

                entity.Property(e => e.ReportExchangeRateId).HasColumnName("Report_Exchange_Rate_ID");

                entity.Property(e => e.ExchangeRateExchangeRateValue)
                    .HasColumnName("Exchange_Rate_Exchange_Rate_Value")
                    .HasColumnType("decimal");

                entity.Property(e => e.ExchangeRateFromCurrencyCode)
                    .IsRequired()
                    .HasColumnName("Exchange_Rate_From_Currency_Code")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.ExchangeRateFromCurrencyDescription)
                    .IsRequired()
                    .HasColumnName("Exchange_Rate_From_Currency_Description")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ExchangeRateFromCurrencySymbol)
                    .HasColumnName("Exchange_Rate_From_Currency_Symbol")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.ExchangeRateMonth).HasColumnName("Exchange_Rate_Month");

                entity.Property(e => e.ExchangeRateToCurrencyCode)
                    .IsRequired()
                    .HasColumnName("Exchange_Rate_To_Currency_Code")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.ExchangeRateToCurrencyDescription)
                    .IsRequired()
                    .HasColumnName("Exchange_Rate_To_Currency_Description")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ExchangeRateToCurrencySymbol)
                    .HasColumnName("Exchange_Rate_To_Currency_Symbol")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.ExchangeRateYear).HasColumnName("Exchange_Rate_Year");

                entity.Property(e => e.SourceSystemName)
                    .HasColumnName("Source_system_Name")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<ReportImNetwork>(entity =>
            {
                entity.HasKey(e => e.Recid)
                    .HasName("PK_Report_IM_Network");

                entity.ToTable("Report_IM_Network");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("IDX_ACCOUNT_NUMBER");

                entity.HasIndex(e => e.ContainerName)
                    .HasName("idx_container_name");

                entity.HasIndex(e => e.DatacenterName)
                    .HasName("idx_datacenter_name");

                entity.HasIndex(e => e.DeviceNumber)
                    .HasName("idx_device_number");

                entity.HasIndex(e => e.SwitchNumber)
                    .HasName("idx_switch_number");

                entity.HasIndex(e => e.TeamBusinessSegment)
                    .HasName("idx_team_business_segment");

                entity.HasIndex(e => e.TeamBusinessSubSegment)
                    .HasName("idx_team_business_sub_segment");

                entity.HasIndex(e => e.TeamName)
                    .HasName("idx_team_name");

                entity.HasIndex(e => e.Zone)
                    .HasName("idx_zone");

                entity.Property(e => e.Recid).HasColumnName("recid");

                entity.Property(e => e.AccountManager)
                    .HasColumnName("Account_Manager")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("Account_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.Cmrr)
                    .HasColumnName("CMRR")
                    .HasColumnType("decimal");

                entity.Property(e => e.ContainerName)
                    .HasColumnName("Container_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DatacenterName)
                    .HasColumnName("Datacenter_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceNumber)
                    .HasColumnName("Device_Number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_count");

                entity.Property(e => e.PrimaryContactName)
                    .HasColumnName("Primary_Contact_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PrimaryContactPhone)
                    .HasColumnName("Primary_Contact_Phone")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SwitchNumber)
                    .HasColumnName("switch_number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SwitchPortNumber)
                    .HasColumnName("switch_port_number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamName)
                    .HasColumnName("Team_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TechnicalContactName)
                    .HasColumnName("Technical_Contact_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TechnicalContactPhone)
                    .HasColumnName("Technical_Contact_Phone")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Zone).HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<ReportImPower>(entity =>
            {
                entity.HasKey(e => e.Recid)
                    .HasName("PK_Report_IM_Power");

                entity.ToTable("Report_IM_Power");

                entity.HasIndex(e => e.AccountManager)
                    .HasName("idx_account_manager");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("IDX_ACCOUNT_NUMBER");

                entity.HasIndex(e => e.Circuit)
                    .HasName("idx_circuit");

                entity.HasIndex(e => e.ContainerName)
                    .HasName("idx_container_name");

                entity.HasIndex(e => e.DeviceNumber)
                    .HasName("idx_device_number");

                entity.HasIndex(e => e.Pdu)
                    .HasName("idx_pdu");

                entity.HasIndex(e => e.Phase)
                    .HasName("idx_phase");

                entity.HasIndex(e => e.Rpp)
                    .HasName("idx_rpp");

                entity.HasIndex(e => e.SwitchNumber)
                    .HasName("idx_switch_number");

                entity.HasIndex(e => e.TeamBusinessSegment)
                    .HasName("idx_team_business_segment");

                entity.HasIndex(e => e.TeamBusinessSubSegment)
                    .HasName("idx_team_busines_sub_segment");

                entity.HasIndex(e => e.TeamName)
                    .HasName("idx_team_name");

                entity.HasIndex(e => e.Ups)
                    .HasName("idx_ups");

                entity.Property(e => e.Recid).HasColumnName("recid");

                entity.Property(e => e.AccountManager)
                    .HasColumnName("Account_Manager")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("Account_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.Circuit).HasColumnType("varchar(100)");

                entity.Property(e => e.Cmrr)
                    .HasColumnName("CMRR")
                    .HasColumnType("decimal");

                entity.Property(e => e.ContainerName)
                    .HasColumnName("Container_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DatacenterName)
                    .HasColumnName("Datacenter_name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceNumber)
                    .HasColumnName("Device_Number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MeasureCount).HasColumnName("Measure_count");

                entity.Property(e => e.Pdu)
                    .HasColumnName("PDU")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Phase).HasColumnType("varchar(100)");

                entity.Property(e => e.PrimaryContactName)
                    .HasColumnName("Primary_Contact_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PrimaryContactPhone)
                    .HasColumnName("Primary_Contact_Phone")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Rpp)
                    .HasColumnName("RPP")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SwitchNumber)
                    .HasColumnName("switch_number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SwitchPortNumber)
                    .HasColumnName("switch_port_number")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamName)
                    .HasColumnName("Team_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TechnicalContactName)
                    .HasColumnName("Technical_Contact_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TechnicalContactPhone)
                    .HasColumnName("Technical_Contact_Phone")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Ups)
                    .HasColumnName("UPS")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<ReportIncidentCreatedDetails>(entity =>
            {
                entity.HasKey(e => e.IncidentDeviceKey)
                    .HasName("PK_Report_Incident_Created_Details");

                entity.ToTable("Report_Incident_Created_Details");

                entity.HasIndex(e => e.IncidentCreatedDate)
                    .HasName("ix_Incident_Created_date");

                entity.HasIndex(e => e.IncidentReferenceNumber)
                    .HasName("ix_incident_reference_number");

                entity.Property(e => e.IncidentDeviceKey)
                    .HasColumnName("Incident_Device_Key")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountGeographicLocation)
                    .HasColumnName("Account_Geographic_Location")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("Account_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.CurrentIncidentStatusName)
                    .HasColumnName("Current_Incident_Status_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DeviceCaption)
                    .HasColumnName("Device_Caption")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.DeviceNumber).HasColumnName("Device_Number");

                entity.Property(e => e.DeviceType)
                    .HasColumnName("Device_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.EmployeeFullName)
                    .HasColumnName("Employee_Full_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmployeeTeamName)
                    .HasColumnName("Employee_Team_Name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.IncidentCreatedDate)
                    .HasColumnName("Incident_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentOpenedEmployeeContactId).HasColumnName("Incident_Opened_Employee_Contact_ID");

                entity.Property(e => e.IncidentOpenedTeam)
                    .HasColumnName("Incident_Opened_Team")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.IncidentReferenceNumber)
                    .IsRequired()
                    .HasColumnName("Incident_Reference_Number")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<ReportIncidentMessageData>(entity =>
            {
                entity.ToTable("Report_Incident_Message_Data");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("Account_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.CommentsCount).HasColumnName("comments_count");

                entity.Property(e => e.TimeMonthAbbr)
                    .HasColumnName("Time_Month_Abbr")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.TimeMonthNumber).HasColumnName("Time_Month_Number");

                entity.Property(e => e.TimeYearNumber).HasColumnName("Time_Year_Number");

                entity.Property(e => e.TitleBucket)
                    .IsRequired()
                    .HasColumnName("Title_Bucket")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ReportMktEmailList>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_Report_MKT_email_list");

                entity.ToTable("REPORT_mkt_email_list");

                entity.Property(e => e.EmailAddress)
                    .HasColumnName("emailAddress")
                    .HasMaxLength(255);

                entity.Property(e => e.LastUpdated)
                    .HasColumnName("lastUpdated")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusCode)
                    .HasColumnName("statusCode")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ReportMstgHba>(entity =>
            {
                entity.HasKey(e => e.ReportHbaId)
                    .HasName("PK_Report_HBA");

                entity.ToTable("Report_MSTG_HBA");

                entity.Property(e => e.ReportHbaId).HasColumnName("Report_HBA_ID");

                entity.Property(e => e.AccountCmrr)
                    .HasColumnName("Account_CMRR")
                    .HasColumnType("money");

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.DeviceContractReceivedDate)
                    .HasColumnName("Device_Contract_Received_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceDatacenterAbbr)
                    .HasColumnName("Device_Datacenter_Abbr")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DeviceLastModifiedDate)
                    .HasColumnName("Device_Last_Modified_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceNumber).HasColumnName("Device_Number");

                entity.Property(e => e.DeviceOfflineDate)
                    .HasColumnName("Device_Offline_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceOnlineDate)
                    .HasColumnName("Device_Online_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceStatus)
                    .HasColumnName("Device_Status")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DeviceStatusNumber).HasColumnName("Device_Status_Number");

                entity.Property(e => e.SkuDescription)
                    .HasColumnName("SKU_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SkuKey).HasColumnName("SKU_Key");

                entity.Property(e => e.SkuNumber).HasColumnName("SKU_Number");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<ReportOracleAging>(entity =>
            {
                entity.ToTable("Report_Oracle_Aging");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountManager)
                    .HasColumnName("account_manager")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("account_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("account_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BusinessUnit)
                    .HasColumnName("business_unit")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CurrentDue)
                    .HasColumnName("current_due")
                    .HasColumnType("money");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasColumnType("datetime");

                entity.Property(e => e.Due121180)
                    .HasColumnName("due_121_180")
                    .HasColumnType("money");

                entity.Property(e => e.Due130)
                    .HasColumnName("due_1_30")
                    .HasColumnType("money");

                entity.Property(e => e.Due181)
                    .HasColumnName("due_181")
                    .HasColumnType("money");

                entity.Property(e => e.Due3160)
                    .HasColumnName("due_31_60")
                    .HasColumnType("money");

                entity.Property(e => e.Due6190)
                    .HasColumnName("due_61_90")
                    .HasColumnType("money");

                entity.Property(e => e.Due91120)
                    .HasColumnName("due_91_120")
                    .HasColumnType("money");

                entity.Property(e => e.Team)
                    .HasColumnName("team")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.TimeKey).HasColumnName("time_key");

                entity.Property(e => e.TotalDue)
                    .HasColumnName("total_due")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<ReportProvisioningPipeline>(entity =>
            {
                entity.ToTable("Report_Provisioning_Pipeline");

                entity.HasIndex(e => e.DeviceDatacenterAbbr)
                    .HasName("ix_datacenter");

                entity.Property(e => e.ReportProvisioningPipelineId).HasColumnName("Report_Provisioning_Pipeline_ID");

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber).HasColumnName("Account_Number");

                entity.Property(e => e.AccountTeamName)
                    .HasColumnName("Account_Team_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CrFlag).HasColumnName("CR_Flag");

                entity.Property(e => e.DcopsBuildBusDays).HasColumnName("DCOps_Build_Bus_Days");

                entity.Property(e => e.DcopsBuildDays).HasColumnName("DCOps_Build_Days");

                entity.Property(e => e.DeviceDatacenterAbbr)
                    .HasColumnName("Device_Datacenter_Abbr")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.DeviceNumber).HasColumnName("Device_Number");

                entity.Property(e => e.DeviceOnlineDate)
                    .HasColumnName("Device_Online_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceType)
                    .HasColumnName("Device_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.DueToCustomerDate)
                    .HasColumnName("Due_To_Customer_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstCrDt)
                    .HasColumnName("First_CR_Dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstOcDt)
                    .HasColumnName("First_OC_Dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.FirstScDt)
                    .HasColumnName("First_SC_Dt")
                    .HasColumnType("datetime");

                entity.Property(e => e.OcFlag).HasColumnName("OC_Flag");

                entity.Property(e => e.RecCreatedOn)
                    .HasColumnName("Rec_Created_On")
                    .HasColumnType("datetime");

                entity.Property(e => e.ScFlag).HasColumnName("SC_Flag");

                entity.Property(e => e.SegmentConfigBuildBusDays).HasColumnName("SegmentConfig_Build_Bus_Days");

                entity.Property(e => e.SegmentConfigBuildDays).HasColumnName("SegmentConfig_Build_Days");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TotalBuildBusDays).HasColumnName("Total_Build_Bus_Days");

                entity.Property(e => e.TotalBuildDays).HasColumnName("Total_Build_Days");
            });

            modelBuilder.Entity<ReportQueueStats>(entity =>
            {
                entity.ToTable("Report_Queue_Stats");

                entity.HasIndex(e => e.AccountNumber)
                    .HasName("ix_account_number");

                entity.HasIndex(e => e.IncidentReferenceNumber)
                    .HasName("ix_incident_reference_number");

                entity.HasIndex(e => e.QueueName)
                    .HasName("ix_queue_name");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountKey).HasColumnName("account_key");

                entity.Property(e => e.AccountName)
                    .HasColumnName("account_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber).HasColumnName("account_number");

                entity.Property(e => e.ActiveTimeMi).HasColumnName("active_time_mi");

                entity.Property(e => e.IncidentCategoryName)
                    .HasColumnName("Incident_Category_Name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.IncidentKey).HasColumnName("incident_key");

                entity.Property(e => e.IncidentReferenceNumber)
                    .IsRequired()
                    .HasColumnName("incident_reference_number")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSubcategoryName)
                    .HasColumnName("Incident_Subcategory_Name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.QueueInstanceConfirmSolveDate)
                    .HasColumnName("Queue_Instance_Confirm_Solve_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceEntryDate)
                    .HasColumnName("Queue_Instance_Entry_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceEntryTimeHmsKey).HasColumnName("Queue_Instance_Entry_Time_HMS_key");

                entity.Property(e => e.QueueInstanceEntryTimeKey).HasColumnName("Queue_Instance_Entry_Time_key");

                entity.Property(e => e.QueueInstanceExitDate)
                    .HasColumnName("Queue_Instance_Exit_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceFirstAssignDate)
                    .HasColumnName("Queue_Instance_First_Assign_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceFirstAssignee)
                    .HasColumnName("Queue_Instance_First_Assignee")
                    .HasMaxLength(201);

                entity.Property(e => e.QueueInstanceFirstAssigneeKey).HasColumnName("Queue_Instance_First_Assignee_Key");

                entity.Property(e => e.QueueInstanceFirstAssigner)
                    .HasColumnName("Queue_Instance_First_Assigner")
                    .HasMaxLength(201);

                entity.Property(e => e.QueueInstanceFirstAssignerKey).HasColumnName("Queue_Instance_First_Assigner_Key");

                entity.Property(e => e.QueueInstanceFirstPrivRespDate)
                    .HasColumnName("Queue_Instance_First_Priv_Resp_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceFirstPrivResponder)
                    .HasColumnName("Queue_Instance_First_Priv_Responder")
                    .HasMaxLength(201);

                entity.Property(e => e.QueueInstanceFirstPrivResponderKey).HasColumnName("Queue_Instance_First_Priv_Responder_Key");

                entity.Property(e => e.QueueInstanceFirstPubRespDate)
                    .HasColumnName("Queue_Instance_First_Pub_Resp_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceFirstPubResponder)
                    .HasColumnName("Queue_Instance_First_Pub_Responder")
                    .HasMaxLength(201);

                entity.Property(e => e.QueueInstanceFirstPubResponderKey).HasColumnName("Queue_Instance_First_Pub_Responder_Key");

                entity.Property(e => e.QueueInstanceFirstRespDate)
                    .HasColumnName("Queue_Instance_First_Resp_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceFirstResponder)
                    .HasColumnName("Queue_Instance_First_Responder")
                    .HasMaxLength(201);

                entity.Property(e => e.QueueInstanceFirstResponderKey).HasColumnName("Queue_Instance_First_Responder_Key");

                entity.Property(e => e.QueueInstanceFirstStsChgBy)
                    .HasColumnName("Queue_Instance_First_Sts_Chg_By")
                    .HasMaxLength(201);

                entity.Property(e => e.QueueInstanceFirstStsChgByKey).HasColumnName("Queue_Instance_First_Sts_Chg_By_Key");

                entity.Property(e => e.QueueInstanceFirstStsChgDate)
                    .HasColumnName("Queue_Instance_First_Sts_Chg_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.QueueInstanceLastAssignee)
                    .HasColumnName("Queue_Instance_Last_Assignee")
                    .HasMaxLength(201);

                entity.Property(e => e.QueueInstanceLastAssigneeKey).HasColumnName("Queue_Instance_Last_Assignee_Key");

                entity.Property(e => e.QueueInstanceLastStatus)
                    .HasColumnName("Queue_Instance_Last_Status")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.QueueName)
                    .HasColumnName("queue_name")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.RecCreatedOn)
                    .HasColumnName("Rec_Created_On")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResponseTimeMi).HasColumnName("Response_Time_Mi");

                entity.Property(e => e.TcktQuecatInstance)
                    .HasColumnName("tckt_quecat_instance")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamKey).HasColumnName("team_key");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("team_name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.TimeToAssignMi).HasColumnName("Time_to_Assign_Mi");

                entity.Property(e => e.TimeToStsChgMi).HasColumnName("Time_to_Sts_Chg_Mi");
            });

            modelBuilder.Entity<ReportSoxManagedVirtDetail>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RecTimestamp, e.DeviceId, e.RecSourceSystem, e.RecTargetSystem })
                    .HasName("XPKReport_SOX_Managed_Virt_Detail");

                entity.ToTable("Report_SOX_Managed_Virt_Detail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RecTimestamp)
                    .HasColumnName("Rec_Timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeviceId)
                    .HasColumnName("Device_ID")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.RecSourceSystem)
                    .HasColumnName("Rec_Source_System")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecTargetSystem)
                    .HasColumnName("Rec_Target_System")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.AccountId)
                    .IsRequired()
                    .HasColumnName("Account_ID")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Datacenter)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.DeviceHostName)
                    .IsRequired()
                    .HasColumnName("Device_Host_Name")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.MissingIn)
                    .IsRequired()
                    .HasColumnName("Missing_In")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.RecDeviceType)
                    .IsRequired()
                    .HasColumnName("Rec_Device_Type")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.RecSrcDeviceStatus)
                    .HasColumnName("Rec_Src_Device_Status")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ReconciliationType)
                    .IsRequired()
                    .HasColumnName("Reconciliation_Type")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.ReplicationFlag)
                    .IsRequired()
                    .HasColumnName("Replication_Flag")
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<ReportSoxManagedVirtSummary>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.RecTimestamp, e.Datacenter, e.RecSourceSystem, e.RecDeviceType, e.RecTargetSystem })
                    .HasName("XPKReport_SOX_Managed_Virt_Summary");

                entity.ToTable("Report_SOX_Managed_Virt_Summary");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RecTimestamp)
                    .HasColumnName("Rec_Timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datacenter).HasColumnType("varchar(20)");

                entity.Property(e => e.RecSourceSystem)
                    .HasColumnName("Rec_Source_System")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.RecDeviceType)
                    .HasColumnName("Rec_Device_Type")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.RecTargetSystem)
                    .HasColumnName("Rec_Target_System")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.DifferenceAsPcOfSource).HasColumnName("Difference_as_pc_of_source");

                entity.Property(e => e.ReconciliationType)
                    .IsRequired()
                    .HasColumnName("Reconciliation_Type")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Result)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.SourceSystemCount).HasColumnName("Source_system_Count");

                entity.Property(e => e.TargetSystemCount).HasColumnName("Target_System_Count");
            });

            modelBuilder.Entity<RptSfdcInvoiceobjectAccountinvoicesummary>(entity =>
            {
                entity.ToTable("RPT_SFDC_invoiceobject_accountinvoicesummary");

                entity.HasIndex(e => e.SfAccountId)
                    .HasName("IDX_SF_ACCOUNT_ID");

                entity.HasIndex(e => e.Timemonthkey)
                    .HasName("IDX_TimemonthKey");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("accountNumber")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.AccountStatus)
                    .HasColumnName("accountStatus")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.AccountSubType)
                    .HasColumnName("accountSubType")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.AccountType)
                    .HasColumnName("accountType")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.Bdom).HasColumnName("bdom");

                entity.Property(e => e.BusinessUnit)
                    .HasColumnName("businessUnit")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.DataAsOf)
                    .HasColumnName("dataAsOf")
                    .HasColumnType("datetime");

                entity.Property(e => e.InvoiceAmount)
                    .HasColumnName("invoiceAmount")
                    .HasColumnType("decimal");

                entity.Property(e => e.InvoiceLocalAmount)
                    .HasColumnName("invoiceLocalAmount")
                    .HasColumnType("decimal");

                entity.Property(e => e.InvoiceLocalCurrency)
                    .HasColumnName("invoiceLocalCurrency")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.InvoiceMonth)
                    .HasColumnName("invoiceMonth")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonthOverMonthDeltaAmount)
                    .HasColumnName("monthOverMonthDeltaAmount")
                    .HasColumnType("decimal");

                entity.Property(e => e.SfAccountId)
                    .HasColumnName("SF_Account_ID")
                    .HasColumnType("varchar(18)");
            });

            modelBuilder.Entity<RptSfdcInvoiceobjectCompanyinvoicesummary>(entity =>
            {
                entity.ToTable("RPT_SFDC_invoiceobject_companyinvoicesummary");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("IDX_CompanyID");

                entity.HasIndex(e => e.Timemonthkey)
                    .HasName("IDX_Timemonthkey");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("accountNumber")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.BusinessUnit)
                    .HasColumnName("businessUnit")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.CompanyStatus)
                    .HasColumnName("companyStatus")
                    .HasMaxLength(250);

                entity.Property(e => e.DataAsOf)
                    .HasColumnName("dataAsOf")
                    .HasColumnType("datetime");

                entity.Property(e => e.DunsNumber)
                    .HasColumnName("dunsNumber")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.InvoiceAmount)
                    .HasColumnName("invoiceAmount")
                    .HasColumnType("decimal");

                entity.Property(e => e.InvoiceLocalAmount)
                    .HasColumnName("invoiceLocalAmount")
                    .HasColumnType("decimal");

                entity.Property(e => e.InvoiceLocalCurrency)
                    .HasColumnName("invoiceLocalCurrency")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.InvoiceMonth)
                    .HasColumnName("invoiceMonth")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MonthOverMonthDeltaAmount)
                    .HasColumnName("monthOverMonthDeltaAmount")
                    .HasColumnType("decimal");
            });

            modelBuilder.Entity<TempVwNpsMot>(entity =>
            {
                entity.HasKey(e => new { e.StartTimeHmsTime, e.NpsSsk })
                    .HasName("PK_Temp_vw_NPS_MOT");

                entity.ToTable("temp_vw_nps_mot");

                entity.HasIndex(e => e.IncidentReferenceNumber)
                    .HasName("IX_Incident_Reference_Number");

                entity.Property(e => e.StartTimeHmsTime)
                    .HasColumnName("Start_Time_HMS_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.NpsSsk)
                    .HasColumnName("NPS_SSK")
                    .HasColumnType("varchar(225)");

                entity.Property(e => e.AccountAllDeviceCount).HasColumnName("Account_All_Device_Count");

                entity.Property(e => e.AccountAnnualRevenue)
                    .HasColumnName("Account_Annual_Revenue")
                    .HasColumnType("decimal");

                entity.Property(e => e.AccountBackupDeviceCount).HasColumnName("Account_Backup_Device_Count");

                entity.Property(e => e.AccountBdc)
                    .HasColumnName("Account_BDC")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountBdcContactId).HasColumnName("Account_BDC_Contact_ID");

                entity.Property(e => e.AccountBillingCity)
                    .HasColumnName("Account_Billing_City")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountBillingCountry)
                    .HasColumnName("Account_Billing_Country")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountBillingPostalCode)
                    .HasColumnName("Account_Billing_Postal_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountBillingState)
                    .HasColumnName("Account_Billing_State")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountBillingStreet)
                    .HasColumnName("Account_Billing_Street")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountBusinessType)
                    .HasColumnName("Account_Business_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountCaption)
                    .HasColumnName("Account_Caption")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.AccountCreatedDate)
                    .HasColumnName("Account_Created_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountCurrencyIsoCode)
                    .HasColumnName("Account_Currency_ISO_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountCustomerType)
                    .HasColumnName("Account_Customer_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountDescription)
                    .HasColumnName("Account_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountEmerInstrExists).HasColumnName("Account_Emer_Instr_Exists");

                entity.Property(e => e.AccountFax)
                    .HasColumnName("Account_FAX")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountFirstServerOnline)
                    .HasColumnName("Account_First_Server_Online")
                    .HasColumnType("datetime");

                entity.Property(e => e.AccountGeographicLocation)
                    .HasColumnName("Account_Geographic_Location")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.AccountId).HasColumnName("Account_ID");

                entity.Property(e => e.AccountManager)
                    .HasColumnName("Account_Manager")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountManagerContactId)
                    .HasColumnName("Account_Manager_Contact_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountName)
                    .HasColumnName("Account_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountNumber)
                    .HasColumnName("Account_Number")
                    .HasMaxLength(255);

                entity.Property(e => e.AccountNumberOfEmployees).HasColumnName("Account_Number_of_Employees");

                entity.Property(e => e.AccountOtherNetworkDeviceC).HasColumnName("Account_Other_Network_Device_C");

                entity.Property(e => e.AccountOwnerId)
                    .HasColumnName("Account_Owner_ID")
                    .HasColumnType("varchar(18)");

                entity.Property(e => e.AccountOwnership)
                    .HasColumnName("Account_Ownership")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountPhone)
                    .HasColumnName("Account_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountPrimaryContact)
                    .HasColumnName("Account_Primary_Contact")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountPrimaryContactId)
                    .HasColumnName("Account_Primary_Contact_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountRating)
                    .HasColumnName("Account_Rating")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountRegion)
                    .HasColumnName("Account_Region")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountServerCount).HasColumnName("Account_Server_Count");

                entity.Property(e => e.AccountServices).HasColumnName("account services");

                entity.Property(e => e.AccountShippingCity)
                    .HasColumnName("Account_Shipping_City")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountShippingCountry)
                    .HasColumnName("Account_Shipping_Country")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountShippingPostalCode)
                    .HasColumnName("Account_Shipping_Postal_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountShippingState)
                    .HasColumnName("Account_Shipping_State")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountShippingStreet)
                    .HasColumnName("Account_Shipping_Street")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountSite)
                    .HasColumnName("Account_Site")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.AccountSlaType)
                    .HasColumnName("Account_SLA_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountSlaTypeDesc)
                    .HasColumnName("Account_SLA_Type_Desc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountSourceSystemName)
                    .HasColumnName("Account_Source_System_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.AccountStatus)
                    .HasColumnName("Account_Status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountStorageDeviceCount).HasColumnName("Account_Storage_Device_Count");

                entity.Property(e => e.AccountSubscriptionAmount)
                    .HasColumnName("Account_Subscription_Amount")
                    .HasColumnType("decimal");

                entity.Property(e => e.AccountTeamName)
                    .HasColumnName("Account_Team_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.AccountTenureDays).HasColumnName("Account_Tenure_Days");

                entity.Property(e => e.AccountTickerSymbol)
                    .HasColumnName("Account_Ticker_Symbol")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.AccountType)
                    .HasColumnName("Account_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountTypeDesc)
                    .HasColumnName("Account_Type_Desc")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.AccountUnknownDeviceCount).HasColumnName("Account_Unknown_Device_Count");

                entity.Property(e => e.AccountWebsite)
                    .HasColumnName("Account_Website")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.AlertsAndMonitoring).HasColumnName("alerts and monitoring");

                entity.Property(e => e.BreakFix).HasColumnName("break fix");

                entity.Property(e => e.ChangeToHardwareSoftwareOrNetworkConfig).HasColumnName("change to hardware, software or network config.");

                entity.Property(e => e.ChangeToHardwareSoftwareOrNetworkConfiguration).HasColumnName("change to hardware, software or network configuration");

                entity.Property(e => e.CloudAndVirtualizationServices).HasColumnName("cloud and virtualization services");

                entity.Property(e => e.ContactAccountId)
                    .HasColumnName("Contact_Account_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactAssistantName)
                    .HasColumnName("Contact_Assistant_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactAssistantPhone)
                    .HasColumnName("Contact_Assistant_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactBirthdate)
                    .HasColumnName("Contact_Birthdate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactContactTitle)
                    .HasColumnName("Contact_Contact_Title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactCoreContactId)
                    .HasColumnName("Contact_CORE_Contact_ID")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ContactCreatedById)
                    .HasColumnName("Contact_Created_By_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactCurrencyIsoCode)
                    .HasColumnName("Contact_Currency_ISO_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactCurrentRecord).HasColumnName("Contact_Current_Record");

                entity.Property(e => e.ContactDeletedDateKey).HasColumnName("Contact_Deleted_Date_Key");

                entity.Property(e => e.ContactDepartment)
                    .HasColumnName("Contact_Department")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactDescription)
                    .HasColumnName("Contact_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactDiscProfile)
                    .HasColumnName("Contact_Disc_Profile")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactDoNotCall)
                    .HasColumnName("Contact_Do_Not_Call")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactDoNotMail)
                    .HasColumnName("Contact_Do_Not_Mail")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactEffectiveEndDatetime)
                    .HasColumnName("Contact_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactEffectiveStartDatetime)
                    .HasColumnName("Contact_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactEmail)
                    .HasColumnName("Contact_Email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactEmail2)
                    .HasColumnName("Contact_Email2")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmail3)
                    .HasColumnName("Contact_Email3")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmail4)
                    .HasColumnName("Contact_Email4")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmail5)
                    .HasColumnName("Contact_Email5")
                    .HasColumnType("varchar(240)");

                entity.Property(e => e.ContactEmployeeType)
                    .HasColumnName("Contact_Employee_Type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactFax)
                    .HasColumnName("Contact_FAX")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactFirstName)
                    .HasColumnName("Contact_First_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactFullName)
                    .HasColumnName("Contact_Full_Name")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactHasOptedOutOfEmail)
                    .HasColumnName("Contact_Has_Opted_Out_Of_Email")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactHobbies)
                    .HasColumnName("Contact_Hobbies")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactHomePhone)
                    .HasColumnName("Contact_Home_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactInactive)
                    .HasColumnName("Contact_Inactive")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ContactKey).HasColumnName("Contact_Key");

                entity.Property(e => e.ContactLanguagePreference)
                    .HasColumnName("Contact_Language_Preference")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactLastActivityDate)
                    .HasColumnName("Contact_Last_Activity_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactLastCuRequestDate)
                    .HasColumnName("Contact_Last_CU_Request_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactLastCuUpdateDate)
                    .HasColumnName("Contact_Last_CU_Update_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactLastModifiedBy)
                    .HasColumnName("Contact_Last_Modified_By")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactLastName)
                    .HasColumnName("Contact_Last_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactLeadSource)
                    .HasColumnName("Contact_Lead_Source")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactLocation)
                    .HasColumnName("Contact_Location")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingCity)
                    .HasColumnName("Contact_Mailing_City")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactMailingCountry)
                    .HasColumnName("Contact_Mailing_Country")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingPostalCode)
                    .HasColumnName("Contact_Mailing_Postal_Code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingState)
                    .HasColumnName("Contact_Mailing_State")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactMailingStreet)
                    .HasColumnName("Contact_Mailing_Street")
                    .HasColumnType("varchar(800)");

                entity.Property(e => e.ContactMobilePhone)
                    .HasColumnName("Contact_Mobile_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactNk)
                    .HasColumnName("Contact_NK")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ContactOtherCity)
                    .HasColumnName("Contact_Other_City")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactOtherCountry)
                    .HasColumnName("Contact_Other_Country")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactOtherPhone)
                    .HasColumnName("Contact_Other_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactOtherPostalCode)
                    .HasColumnName("Contact_Other_Postal_Code")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.ContactOtherState)
                    .HasColumnName("Contact_Other_State")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.ContactOtherStreet)
                    .HasColumnName("Contact_Other_Street")
                    .HasColumnType("varchar(765)");

                entity.Property(e => e.ContactOwnerId)
                    .HasColumnName("Contact_Owner_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactPhone)
                    .HasColumnName("Contact_Phone")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactPhone2)
                    .HasColumnName("Contact_Phone2")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhone3)
                    .HasColumnName("Contact_Phone3")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhone4)
                    .HasColumnName("Contact_Phone4")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhone5)
                    .HasColumnName("Contact_Phone5")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactPhoneExtension).HasColumnName("Contact_Phone_Extension");

                entity.Property(e => e.ContactReportsToId)
                    .HasColumnName("Contact_Reports_To_ID")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactRoleDescription)
                    .HasColumnName("Contact_Role_Description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactRoleName)
                    .HasColumnName("Contact_Role_Name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactRoleNk)
                    .HasColumnName("Contact_Role_NK")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactSalutation)
                    .HasColumnName("Contact_Salutation")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactSecretAnswer)
                    .HasColumnName("Contact_Secret_Answer")
                    .HasColumnType("varchar(600)");

                entity.Property(e => e.ContactSecretQuestion)
                    .HasColumnName("Contact_Secret_Question")
                    .HasColumnType("varchar(600)");

                entity.Property(e => e.ContactSourceName)
                    .HasColumnName("Contact_Source_Name")
                    .HasColumnType("varchar(120)");

                entity.Property(e => e.ContactSso)
                    .HasColumnName("Contact_SSO")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactSupervisor)
                    .HasColumnName("Contact_Supervisor")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactSupervisorEmail)
                    .HasColumnName("Contact_Supervisor_Email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactSystemModStamp)
                    .HasColumnName("Contact_System_Mod_Stamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactTitle)
                    .HasColumnName("Contact_Title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContactType)
                    .HasColumnName("Contact_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ContactWorkShift)
                    .HasColumnName("Contact_Work_Shift")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmailServices).HasColumnName("email services");

                entity.Property(e => e.EquipmentMaintenance).HasColumnName("equipment maintenance");

                entity.Property(e => e.IncidentCategoryDescription)
                    .IsRequired()
                    .HasColumnName("Incident_Category_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentCategoryName)
                    .IsRequired()
                    .HasColumnName("Incident_Category_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentCreatedMethod)
                    .IsRequired()
                    .HasColumnName("Incident_Created_Method")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentCreatorName)
                    .HasColumnName("Incident_Creator_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentEffectiveEndDatetime)
                    .HasColumnName("Incident_Effective_End_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentEffectiveStartDatetime)
                    .HasColumnName("Incident_Effective_Start_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentEotr).HasColumnName("Incident_EOTR");

                entity.Property(e => e.IncidentRecordCreatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Record_Created_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentRecordCreatedDatetime)
                    .HasColumnName("Incident_Record_Created_Datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.IncidentRecordUpdatedBy)
                    .IsRequired()
                    .HasColumnName("Incident_Record_Updated_By")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.IncidentReferenceNumber)
                    .IsRequired()
                    .HasColumnName("Incident_Reference_Number")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSosFlag).HasColumnName("Incident_SOS_Flag");

                entity.Property(e => e.IncidentSubCategoryActive).HasColumnName("Incident_SubCategory_Active");

                entity.Property(e => e.IncidentSubCategoryDescription)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_Description")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.IncidentSubCategoryName)
                    .IsRequired()
                    .HasColumnName("Incident_SubCategory_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IncidentSubject)
                    .IsRequired()
                    .HasColumnName("Incident_Subject")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IncidentSubmitterName)
                    .HasColumnName("Incident_Submitter_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ManagedBackupOrStorageServices).HasColumnName("managed backup or storage services");

                entity.Property(e => e.NewGearOrNewServiceDeployment).HasColumnName("new gear or new service deployment");

                entity.Property(e => e.NewGearOrServicePurchased).HasColumnName("new gear or service purchased");

                entity.Property(e => e.Other).HasColumnName("other");

                entity.Property(e => e.StartTimeDayOfWeek)
                    .IsRequired()
                    .HasColumnName("Start_Time_Day_Of_Week")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.StartTimeFullDate)
                    .HasColumnName("Start_Time_Full_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTimeHmsStandard)
                    .HasColumnName("Start_Time_HMS_Standard")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.StartTimeMilitaryHourNumber).HasColumnName("Start_Time_Military_Hour_Number");

                entity.Property(e => e.StartTimeMinuteNumber).HasColumnName("Start_Time_Minute_Number");

                entity.Property(e => e.StartTimeMonthAbbr)
                    .IsRequired()
                    .HasColumnName("Start_Time_Month_Abbr")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.StartTimeMonthDesc)
                    .IsRequired()
                    .HasColumnName("Start_Time_Month_Desc")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.StartTimeMonthNumber).HasColumnName("Start_Time_Month_Number");

                entity.Property(e => e.StartTimeSecondNumber).HasColumnName("Start_Time_Second_Number");

                entity.Property(e => e.StartTimeStandardHourNumber).HasColumnName("Start_Time_Standard_Hour_Number");

                entity.Property(e => e.StartTimeYearNumber).HasColumnName("Start_Time_Year_Number");

                entity.Property(e => e.SurveyAllowEditCompleted).HasColumnName("Survey_Allow_Edit_Completed");

                entity.Property(e => e.SurveyAllowResumeSurvey).HasColumnName("Survey_Allow_Resume_Survey");

                entity.Property(e => e.SurveyCreatedBySs)
                    .HasColumnName("Survey_Created_by_ss")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.SurveyDescription)
                    .HasColumnName("Survey_Description")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.SurveyFeedback)
                    .HasColumnName("Survey_Feedback")
                    .HasColumnType("varchar(2000)");

                entity.Property(e => e.SurveyIsActive).HasColumnName("Survey_is_active");

                entity.Property(e => e.SurveyMaxResponsesPerUser).HasColumnName("Survey_Max_Responses_per_User");

                entity.Property(e => e.SurveyMaxTotalResponses).HasColumnName("Survey_Max_Total_Responses");

                entity.Property(e => e.SurveyName)
                    .HasColumnName("Survey_Name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.SurveyNpsAnswer).HasColumnName("Survey_NPS_Answer");

                entity.Property(e => e.SurveyNpsRatingType)
                    .HasColumnName("Survey_NPS_Rating_Type")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.SurveyQuestionPagePosition).HasColumnName("Survey_Question_Page_Position");

                entity.Property(e => e.SurveyQuestionQuestionAlias)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Alias")
                    .HasMaxLength(255);

                entity.Property(e => e.SurveyQuestionQuestionCategory)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Category")
                    .HasColumnType("varchar(63)");

                entity.Property(e => e.SurveyQuestionQuestionPosition).HasColumnName("Survey_Question_question_position");

                entity.Property(e => e.SurveyQuestionQuestionSubText)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Sub_Text")
                    .HasColumnType("varchar(4096)");

                entity.Property(e => e.SurveyQuestionQuestionText)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Text")
                    .HasColumnType("varchar(4096)");

                entity.Property(e => e.SurveyQuestionQuestionType)
                    .IsRequired()
                    .HasColumnName("Survey_Question_Question_Type")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.SurveyResponseIsComplete).HasColumnName("Survey_Response_Is_Complete");

                entity.Property(e => e.SurveyResponseLastPageNumberViewed).HasColumnName("Survey_Response_Last_Page_Number_Viewed");

                entity.Property(e => e.SurveyTitle)
                    .HasColumnName("Survey_Title")
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.SurveyTypeDescription)
                    .HasColumnName("Survey_Type_Description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyTypeName)
                    .HasColumnName("Survey_Type_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SurveyTypeSourceSystemName)
                    .HasColumnName("Survey_Type_Source_System_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamBusinessSegment)
                    .HasColumnName("Team_Business_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSegmentReportId).HasColumnName("Team_Business_Segment_Report_ID");

                entity.Property(e => e.TeamBusinessSubSegment)
                    .HasColumnName("Team_Business_Sub_Segment")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TeamBusinessSubSegmentReportId).HasColumnName("Team_Business_Sub_Segment_Report_ID");

                entity.Property(e => e.TeamDescription)
                    .HasColumnName("Team_Description")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnName("Team_Name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.TeamReportHeader)
                    .HasColumnName("Team_Report_Header")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.TeamReportHeaderId).HasColumnName("Team_Report_Header_ID");

                entity.Property(e => e.TeamRoleId).HasColumnName("Team_Role_ID");
            });
        }
    }
}