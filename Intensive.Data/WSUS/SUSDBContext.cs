using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Intensive.Data.WSUS
{
    public partial class SUSDBContext : DbContext
    {
        public SUSDBContext() : base() { }

        public SUSDBContext(DbContextOptions<SUSDBContext> options) : base(options) { }

        public virtual DbSet<TbAuthorization> TbAuthorization { get; set; }
        public virtual DbSet<TbAutoDeploymentRule> TbAutoDeploymentRule { get; set; }
        public virtual DbSet<TbBundleAll> TbBundleAll { get; set; }
        public virtual DbSet<TbBundleAtLeastOne> TbBundleAtLeastOne { get; set; }
        public virtual DbSet<TbBundleDependency> TbBundleDependency { get; set; }
        public virtual DbSet<TbCategory> TbCategory { get; set; }
        public virtual DbSet<TbCategoryInAutoDeploymentRule> TbCategoryInAutoDeploymentRule { get; set; }
        public virtual DbSet<TbCategoryInSubscription> TbCategoryInSubscription { get; set; }
        public virtual DbSet<TbCategoryType> TbCategoryType { get; set; }
        public virtual DbSet<TbChangeTracking> TbChangeTracking { get; set; }
        public virtual DbSet<TbCompatiblePrinterProvider> TbCompatiblePrinterProvider { get; set; }
        public virtual DbSet<TbComputerSummaryForMicrosoftUpdates> TbComputerSummaryForMicrosoftUpdates { get; set; }
        public virtual DbSet<TbComputerTarget> TbComputerTarget { get; set; }
        public virtual DbSet<TbComputerTargetDetail> TbComputerTargetDetail { get; set; }
        public virtual DbSet<TbComputersThatNeedDetailedRollup> TbComputersThatNeedDetailedRollup { get; set; }
        public virtual DbSet<TbConfiguration> TbConfiguration { get; set; }
        public virtual DbSet<TbConfigurationA> TbConfigurationA { get; set; }
        public virtual DbSet<TbConfigurationB> TbConfigurationB { get; set; }
        public virtual DbSet<TbConfigurationC> TbConfigurationC { get; set; }
        public virtual DbSet<TbDeadDeployment> TbDeadDeployment { get; set; }
        public virtual DbSet<TbDeletedComputer> TbDeletedComputer { get; set; }
        public virtual DbSet<TbDeployment> TbDeployment { get; set; }
        public virtual DbSet<TbDownstreamServerClientActivityRollup> TbDownstreamServerClientActivityRollup { get; set; }
        public virtual DbSet<TbDownstreamServerClientSummaryRollup> TbDownstreamServerClientSummaryRollup { get; set; }
        public virtual DbSet<TbDownstreamServerRollupConfiguration> TbDownstreamServerRollupConfiguration { get; set; }
        public virtual DbSet<TbDownstreamServerSummaryRollup> TbDownstreamServerSummaryRollup { get; set; }
        public virtual DbSet<TbDownstreamServerTarget> TbDownstreamServerTarget { get; set; }
        public virtual DbSet<TbDriver> TbDriver { get; set; }
        public virtual DbSet<TbDriverClass> TbDriverClass { get; set; }
        public virtual DbSet<TbEulaAcceptance> TbEulaAcceptance { get; set; }
        public virtual DbSet<TbEulaProperty> TbEulaProperty { get; set; }
        public virtual DbSet<TbEvent> TbEvent { get; set; }
        public virtual DbSet<TbEventInstance> TbEventInstance { get; set; }
        public virtual DbSet<TbEventMessageTemplate> TbEventMessageTemplate { get; set; }
        public virtual DbSet<TbEventNamespace> TbEventNamespace { get; set; }
        public virtual DbSet<TbEventRollupCounters> TbEventRollupCounters { get; set; }
        public virtual DbSet<TbEventSource> TbEventSource { get; set; }
        public virtual DbSet<TbExpandedTargetInTargetGroup> TbExpandedTargetInTargetGroup { get; set; }
        public virtual DbSet<TbFile> TbFile { get; set; }
        public virtual DbSet<TbFileDownloadProgress> TbFileDownloadProgress { get; set; }
        public virtual DbSet<TbFileForRevision> TbFileForRevision { get; set; }
        public virtual DbSet<TbFileHash> TbFileHash { get; set; }
        public virtual DbSet<TbFileOnServer> TbFileOnServer { get; set; }
        public virtual DbSet<TbFlattenedRevisionInCategory> TbFlattenedRevisionInCategory { get; set; }
        public virtual DbSet<TbFlattenedTargetGroup> TbFlattenedTargetGroup { get; set; }
        public virtual DbSet<TbGroupAuthorization> TbGroupAuthorization { get; set; }
        public virtual DbSet<TbHandler> TbHandler { get; set; }
        public virtual DbSet<TbImplicitCategory> TbImplicitCategory { get; set; }
        public virtual DbSet<TbInstalledUpdateSufficientForPrerequisite> TbInstalledUpdateSufficientForPrerequisite { get; set; }
        public virtual DbSet<TbInventoryClass> TbInventoryClass { get; set; }
        public virtual DbSet<TbInventoryClassInstance> TbInventoryClassInstance { get; set; }
        public virtual DbSet<TbInventoryProperty> TbInventoryProperty { get; set; }
        public virtual DbSet<TbInventoryPropertyInstance> TbInventoryPropertyInstance { get; set; }
        public virtual DbSet<TbInventoryRule> TbInventoryRule { get; set; }
        public virtual DbSet<TbInventoryXml> TbInventoryXml { get; set; }
        public virtual DbSet<TbKbarticleForRevision> TbKbarticleForRevision { get; set; }
        public virtual DbSet<TbLanguage> TbLanguage { get; set; }
        public virtual DbSet<TbLanguageInSubscription> TbLanguageInSubscription { get; set; }
        public virtual DbSet<TbLocaleMap> TbLocaleMap { get; set; }
        public virtual DbSet<TbLocalizedProperty> TbLocalizedProperty { get; set; }
        public virtual DbSet<TbLocalizedPropertyForRevision> TbLocalizedPropertyForRevision { get; set; }
        public virtual DbSet<TbMoreInfoUrlforRevision> TbMoreInfoUrlforRevision { get; set; }
        public virtual DbSet<TbNotificationEvent> TbNotificationEvent { get; set; }
        public virtual DbSet<TbOsmap> TbOsmap { get; set; }
        public virtual DbSet<TbPreComputedLocalizedProperty> TbPreComputedLocalizedProperty { get; set; }
        public virtual DbSet<TbPrecomputedCategoryLocalizedProperty> TbPrecomputedCategoryLocalizedProperty { get; set; }
        public virtual DbSet<TbPrerequisite> TbPrerequisite { get; set; }
        public virtual DbSet<TbPrerequisiteDependency> TbPrerequisiteDependency { get; set; }
        public virtual DbSet<TbProgramKeys> TbProgramKeys { get; set; }
        public virtual DbSet<TbProperty> TbProperty { get; set; }
        public virtual DbSet<TbRequestedTargetGroup> TbRequestedTargetGroup { get; set; }
        public virtual DbSet<TbRequestedTargetGroupsForTarget> TbRequestedTargetGroupsForTarget { get; set; }
        public virtual DbSet<TbRevision> TbRevision { get; set; }
        public virtual DbSet<TbRevisionExtendedLanguageMask> TbRevisionExtendedLanguageMask { get; set; }
        public virtual DbSet<TbRevisionExtendedProperty> TbRevisionExtendedProperty { get; set; }
        public virtual DbSet<TbRevisionInCategory> TbRevisionInCategory { get; set; }
        public virtual DbSet<TbRevisionLanguage> TbRevisionLanguage { get; set; }
        public virtual DbSet<TbRevisionSupersedesUpdate> TbRevisionSupersedesUpdate { get; set; }
        public virtual DbSet<TbSchedule> TbSchedule { get; set; }
        public virtual DbSet<TbSchemaVersion> TbSchemaVersion { get; set; }
        public virtual DbSet<TbSchemaVersionHistory> TbSchemaVersionHistory { get; set; }
        public virtual DbSet<TbSecurityBulletinForRevision> TbSecurityBulletinForRevision { get; set; }
        public virtual DbSet<TbServerHealth> TbServerHealth { get; set; }
        public virtual DbSet<TbServerSyncResult> TbServerSyncResult { get; set; }
        public virtual DbSet<TbSingletonData> TbSingletonData { get; set; }
        public virtual DbSet<TbStateMachine> TbStateMachine { get; set; }
        public virtual DbSet<TbStateMachineEvent> TbStateMachineEvent { get; set; }
        public virtual DbSet<TbStateMachineEventTransitionLog> TbStateMachineEventTransitionLog { get; set; }
        public virtual DbSet<TbStateMachineState> TbStateMachineState { get; set; }
        public virtual DbSet<TbStateMachineTransition> TbStateMachineTransition { get; set; }
        public virtual DbSet<TbTarget> TbTarget { get; set; }
        public virtual DbSet<TbTargetGroup> TbTargetGroup { get; set; }
        public virtual DbSet<TbTargetGroupInAutoDeploymentRule> TbTargetGroupInAutoDeploymentRule { get; set; }
        public virtual DbSet<TbTargetGroupType> TbTargetGroupType { get; set; }
        public virtual DbSet<TbTargetInTargetGroup> TbTargetInTargetGroup { get; set; }
        public virtual DbSet<TbTargetType> TbTargetType { get; set; }
        public virtual DbSet<TbUpdate> TbUpdate { get; set; }
        public virtual DbSet<TbUpdateClassificationInAutoDeploymentRule> TbUpdateClassificationInAutoDeploymentRule { get; set; }
        public virtual DbSet<TbUpdateFlag> TbUpdateFlag { get; set; }
        public virtual DbSet<TbUpdateStatusPerComputer> TbUpdateStatusPerComputer { get; set; }
        public virtual DbSet<TbUpdateSummaryForAllComputers> TbUpdateSummaryForAllComputers { get; set; }
        public virtual DbSet<TbUpdateType> TbUpdateType { get; set; }
        public virtual DbSet<TbXml> TbXml { get; set; }

        // Unable to generate entity type for table 'dbo.tbEmailNotificationRecipient'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbReference'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbFrontEndServersHealth'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tbClientWithRecentNameChange'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Data Source=72.32.191.247;Initial Catalog=SUSDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAuthorization>(entity =>
            {
                entity.HasKey(e => e.PluginId)
                    .HasName("PK__tbAuthor__7C10E50129B4E359");

                entity.ToTable("tbAuthorization");

                entity.Property(e => e.PluginId)
                    .HasColumnName("PluginID")
                    .HasMaxLength(128);

                entity.Property(e => e.AssemblyName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.AuthorizationData).HasMaxLength(2048);

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Parameters).HasMaxLength(500);

                entity.Property(e => e.ServiceUrl)
                    .IsRequired()
                    .HasColumnName("ServiceURL")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbAutoDeploymentRule>(entity =>
            {
                entity.ToTable("tbAutoDeploymentRule");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActionId)
                    .HasColumnName("ActionID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Enabled).HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbBundleAll>(entity =>
            {
                entity.HasKey(e => e.BundledId)
                    .HasName("tbBundleAll_PK");

                entity.ToTable("tbBundleAll");

                entity.HasIndex(e => e.RevisionId)
                    .HasName("nc1BundleAll");

                entity.Property(e => e.BundledId).HasColumnName("BundledID");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbBundleAll)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbBundleA__Revis__2F650636");
            });

            modelBuilder.Entity<TbBundleAtLeastOne>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.BundledId })
                    .HasName("tbBundleAtLeastOne_PK");

                entity.ToTable("tbBundleAtLeastOne");

                entity.HasIndex(e => e.BundledId)
                    .HasName("nc1BundleAtLeastOne");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.BundledId).HasColumnName("BundledID");

                entity.HasOne(d => d.Bundled)
                    .WithMany(p => p.TbBundleAtLeastOne)
                    .HasForeignKey(d => d.BundledId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbBundleA__Bundl__2D7CBDC4");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbBundleAtLeastOne)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbBundleA__Revis__2E70E1FD");
            });

            modelBuilder.Entity<TbBundleDependency>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.BundledRevisionId })
                    .HasName("PK__tbBundle__40BEE6EB5FC08529");

                entity.ToTable("tbBundleDependency");

                entity.HasIndex(e => e.BundledRevisionId)
                    .HasName("nc1BundleDependency");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.BundledRevisionId).HasColumnName("BundledRevisionID");
            });

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__tbCatego__19093A2B360560F8");

                entity.ToTable("tbCategory");

                entity.HasIndex(e => e.CategoryType)
                    .HasName("nc1Category");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("CategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryIndex).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LastChange)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");

                entity.Property(e => e.ProhibitsSubcategories).HasDefaultValueSql("0");

                entity.Property(e => e.ProhibitsUpdates).HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithOne(p => p.TbCategory)
                    .HasForeignKey<TbCategory>(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbCategor__Categ__12C8C788");

                entity.HasOne(d => d.CategoryTypeNavigation)
                    .WithMany(p => p.TbCategory)
                    .HasForeignKey(d => d.CategoryType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbCategor__Categ__10E07F16");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK__tbCategor__Paren__11D4A34F");
            });

            modelBuilder.Entity<TbCategoryInAutoDeploymentRule>(entity =>
            {
                entity.HasKey(e => new { e.AutoDeploymentRuleId, e.CategoryId })
                    .HasName("PK__tbCatego__89359C8D60DA6F31");

                entity.ToTable("tbCategoryInAutoDeploymentRule");

                entity.Property(e => e.AutoDeploymentRuleId).HasColumnName("AutoDeploymentRuleID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.AutoDeploymentRule)
                    .WithMany(p => p.TbCategoryInAutoDeploymentRule)
                    .HasForeignKey(d => d.AutoDeploymentRuleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbCategor__AutoD__3F9B6DFF");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbCategoryInAutoDeploymentRule)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbCategor__Categ__408F9238");
            });

            modelBuilder.Entity<TbCategoryInSubscription>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.SubscriptionId })
                    .HasName("PK__tbCatego__D0AB886007D99C26");

                entity.ToTable("tbCategoryInSubscription");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbCategoryInSubscription)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbCategor__Categ__0B27A5C0");
            });

            modelBuilder.Entity<TbCategoryType>(entity =>
            {
                entity.HasKey(e => e.CategoryType)
                    .HasName("PK__tbCatego__0BDC1A5961129D69");

                entity.ToTable("tbCategoryType");

                entity.Property(e => e.CategoryType).HasMaxLength(256);
            });

            modelBuilder.Entity<TbChangeTracking>(entity =>
            {
                entity.HasKey(e => e.NotificationEventName)
                    .HasName("PK__tbChange__DD60B2100CBD526F");

                entity.ToTable("tbChangeTracking");

                entity.HasIndex(e => e.ChangeNumber)
                    .HasName("c0ChangeTracking");

                entity.Property(e => e.NotificationEventName).HasMaxLength(256);
            });

            modelBuilder.Entity<TbCompatiblePrinterProvider>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.CompatibleProvider })
                    .HasName("PK__tbCompat__DA62685F80591029");

                entity.ToTable("tbCompatiblePrinterProvider");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.CompatibleProvider).HasMaxLength(256);

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbCompatiblePrinterProvider)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbCompati__Revis__084B3915");
            });

            modelBuilder.Entity<TbComputerSummaryForMicrosoftUpdates>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("PK__tbComput__2B1F0FB66A94F197");

                entity.ToTable("tbComputerSummaryForMicrosoftUpdates");

                entity.Property(e => e.TargetId)
                    .HasColumnName("TargetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Downloaded).HasDefaultValueSql("0");

                entity.Property(e => e.Failed).HasDefaultValueSql("0");

                entity.Property(e => e.Installed).HasDefaultValueSql("0");

                entity.Property(e => e.InstalledPendingReboot).HasDefaultValueSql("0");

                entity.Property(e => e.LastChangeTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.NotInstalled).HasDefaultValueSql("0");

                entity.HasOne(d => d.Target)
                    .WithOne(p => p.TbComputerSummaryForMicrosoftUpdates)
                    .HasForeignKey<TbComputerSummaryForMicrosoftUpdates>(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_TargetID");
            });

            modelBuilder.Entity<TbComputerTarget>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("PK__tbComput__2B1F0FB60A049196");

                entity.ToTable("tbComputerTarget");

                entity.HasIndex(e => e.ComputerId)
                    .HasName("UQ__tbComput__A6BE3C55401BA113")
                    .IsUnique();

                entity.HasIndex(e => e.EffectiveLastDetectionTime)
                    .HasName("nc_EffectiveLastDetectionTime");

                entity.HasIndex(e => e.FullDomainName)
                    .HasName("ncComputerTarget_FullDomainName")
                    .IsUnique();

                entity.HasIndex(e => e.LastReportedStatusTime)
                    .HasName("nc4ComputerTarget");

                entity.HasIndex(e => e.ParentServerTargetId)
                    .HasName("nc5ComputerTarget");

                entity.HasIndex(e => e.Sid)
                    .HasName("nc1ComputerTarget");

                entity.Property(e => e.TargetId)
                    .HasColumnName("TargetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComputerId)
                    .IsRequired()
                    .HasColumnName("ComputerID")
                    .HasMaxLength(256);

                entity.Property(e => e.EffectiveLastDetectionTime).HasColumnType("datetime");

                entity.Property(e => e.FullDomainName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Ipaddress)
                    .HasColumnName("IPAddress")
                    .HasMaxLength(56);

                entity.Property(e => e.IsRegistered).HasDefaultValueSql("0");

                entity.Property(e => e.LastInventoryTime).HasColumnType("datetime");

                entity.Property(e => e.LastNameChangeTime).HasColumnType("datetime");

                entity.Property(e => e.LastReportedRebootTime).HasColumnType("datetime");

                entity.Property(e => e.LastReportedStatusTime).HasColumnType("datetime");

                entity.Property(e => e.LastSyncResult).HasDefaultValueSql("0");

                entity.Property(e => e.LastSyncTime).HasColumnType("datetime");

                entity.Property(e => e.ParentServerTargetId).HasColumnName("ParentServerTargetID");

                entity.Property(e => e.Sid)
                    .HasColumnName("SID")
                    .HasMaxLength(85);

                entity.HasOne(d => d.ParentServerTarget)
                    .WithMany(p => p.TbComputerTarget)
                    .HasForeignKey(d => d.ParentServerTargetId)
                    .HasConstraintName("FK__tbCompute__Paren__1A69E950");

                entity.HasOne(d => d.Target)
                    .WithOne(p => p.TbComputerTarget)
                    .HasForeignKey<TbComputerTarget>(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbCompute__Targe__1975C517");
            });

            modelBuilder.Entity<TbComputerTargetDetail>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("PK__tbComput__2B1F0FB65D79A2BA");

                entity.ToTable("tbComputerTargetDetail");

                entity.Property(e => e.TargetId)
                    .HasColumnName("TargetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BiosName).HasMaxLength(64);

                entity.Property(e => e.BiosReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.BiosVersion).HasMaxLength(64);

                entity.Property(e => e.ClientVersion).HasMaxLength(23);

                entity.Property(e => e.ComputerMake).HasMaxLength(64);

                entity.Property(e => e.ComputerModel).HasMaxLength(64);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.LastReceivedStatusRollupNumber).HasDefaultValueSql("0");

                entity.Property(e => e.LastSentStatusRollupNumber).HasDefaultValueSql("0");

                entity.Property(e => e.LastStatusRollupTime).HasColumnType("datetime");

                entity.Property(e => e.NewProductType).HasDefaultValueSql("0");

                entity.Property(e => e.OldProductType).HasDefaultValueSql("0");

                entity.Property(e => e.OsbuildNumber).HasColumnName("OSBuildNumber");

                entity.Property(e => e.Osdescription)
                    .HasColumnName("OSDescription")
                    .HasMaxLength(256);

                entity.Property(e => e.Osfamily)
                    .IsRequired()
                    .HasColumnName("OSFamily")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("N'Windows'");

                entity.Property(e => e.Oslocale)
                    .HasColumnName("OSLocale")
                    .HasMaxLength(10);

                entity.Property(e => e.OsmajorVersion).HasColumnName("OSMajorVersion");

                entity.Property(e => e.OsminorVersion).HasColumnName("OSMinorVersion");

                entity.Property(e => e.OsservicePackMajorNumber).HasColumnName("OSServicePackMajorNumber");

                entity.Property(e => e.OsservicePackMinorNumber).HasColumnName("OSServicePackMinorNumber");

                entity.Property(e => e.ProcessorArchitecture).HasMaxLength(50);

                entity.Property(e => e.SamplingValue).HasDefaultValueSql("CONVERT([int],rand(checksum(newid()))*(1000),0)");

                entity.Property(e => e.SuiteMask).HasDefaultValueSql("0");

                entity.Property(e => e.SystemMetrics).HasDefaultValueSql("0");

                entity.Property(e => e.TargetGroupMembershipChanged).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TbComputersThatNeedDetailedRollup>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("cComputersThatNeedDetailedRollup");

                entity.ToTable("tbComputersThatNeedDetailedRollup");

                entity.Property(e => e.TargetId)
                    .HasColumnName("TargetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsBeingRolledUp).HasDefaultValueSql("0");

                entity.HasOne(d => d.Target)
                    .WithOne(p => p.TbComputersThatNeedDetailedRollup)
                    .HasForeignKey<TbComputersThatNeedDetailedRollup>(d => d.TargetId)
                    .HasConstraintName("FK__tbCompute__Targe__1B5E0D89");
            });

            modelBuilder.Entity<TbConfiguration>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__tbConfig__737584F79A23D490");

                entity.ToTable("tbConfiguration");

                entity.Property(e => e.Name).HasMaxLength(128);
            });

            modelBuilder.Entity<TbConfigurationA>(entity =>
            {
                entity.HasKey(e => e.ConfigurationId)
                    .HasName("PK__tbConfig__95AA539B1728157D");

                entity.ToTable("tbConfigurationA");

                entity.Property(e => e.ConfigurationId).HasColumnName("ConfigurationID");

                entity.Property(e => e.AnonymousProxyAccess).HasDefaultValueSql("0");

                entity.Property(e => e.DssAnonymousTargeting).HasDefaultValueSql("1");

                entity.Property(e => e.DssTargetingCookieExpirationTime).HasDefaultValueSql("240");

                entity.Property(e => e.EncryptionKey)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("0x0000");

                entity.Property(e => e.HandshakeAnchor).HasMaxLength(64);

                entity.Property(e => e.HostOnMu).HasDefaultValueSql("0");

                entity.Property(e => e.IsRegistrationRequired).HasDefaultValueSql("1");

                entity.Property(e => e.LastConfigChange).HasColumnType("datetime");

                entity.Property(e => e.MaxDeltaSyncPeriod).HasDefaultValueSql("0");

                entity.Property(e => e.MaximumServerCookieExpirationTime).HasDefaultValueSql("60");

                entity.Property(e => e.ProxyName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ProxyPassword)
                    .IsRequired()
                    .HasMaxLength(728)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ProxyServerPort).HasDefaultValueSql("80");

                entity.Property(e => e.ProxyUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ReportingServiceUrl)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.ServerId).HasColumnName("ServerID");

                entity.Property(e => e.ServerPortNumber).HasDefaultValueSql("8530");

                entity.Property(e => e.ServerTargeting).HasDefaultValueSql("1");

                entity.Property(e => e.SimpleTargetingCookieExpirationTime).HasDefaultValueSql("60");

                entity.Property(e => e.SyncToMu)
                    .HasColumnName("SyncToMU")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UpstreamServerName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.UpstreamServerUseSsl)
                    .HasColumnName("UpstreamServerUseSSL")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UseProxy).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TbConfigurationB>(entity =>
            {
                entity.HasKey(e => e.ConfigurationId)
                    .HasName("PK__tbConfig__95AA539B304CF3DF");

                entity.ToTable("tbConfigurationB");

                entity.Property(e => e.ConfigurationId)
                    .HasColumnName("ConfigurationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutoPurgeClientEventAgeThreshold).HasDefaultValueSql("15");

                entity.Property(e => e.AutoPurgeDetectionPeriod).HasDefaultValueSql("12");

                entity.Property(e => e.AutoPurgeServerEventAgeThreshold).HasDefaultValueSql("90");

                entity.Property(e => e.AutoRefreshDeployments).HasDefaultValueSql("1");

                entity.Property(e => e.DispatchManagerPollingInterval).HasDefaultValueSql("5");

                entity.Property(e => e.DoReportingDataValidation).HasDefaultValueSql("0");

                entity.Property(e => e.DoReportingSummarization).HasDefaultValueSql("0");

                entity.Property(e => e.EventLogFloodProtectTime).HasDefaultValueSql("10");

                entity.Property(e => e.ImportLocalPath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LocalContentCacheLocation)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LogDestinations).HasDefaultValueSql("3");

                entity.Property(e => e.LogLevel).HasDefaultValueSql("2");

                entity.Property(e => e.LogPath)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MaxNumberOfIdsToRequestDataFromUss).HasDefaultValueSql("100");

                entity.Property(e => e.MaxSimultaneousFileDownloads).HasDefaultValueSql("10");

                entity.Property(e => e.Muurl)
                    .IsRequired()
                    .HasColumnName("MUUrl")
                    .HasMaxLength(1024);

                entity.Property(e => e.QueueFlushCount).HasDefaultValueSql("100");

                entity.Property(e => e.QueueFlushTimeInMs)
                    .HasColumnName("QueueFlushTimeInMS")
                    .HasDefaultValueSql("3000");

                entity.Property(e => e.QueueRejectCount).HasDefaultValueSql("300");

                entity.Property(e => e.RedirectorChangeNumber).HasDefaultValueSql("0");

                entity.Property(e => e.ServerSupportsAllLanguages).HasDefaultValueSql("1");

                entity.Property(e => e.SleepTimeAfterErrorInMs)
                    .HasColumnName("SleepTimeAfterErrorInMS")
                    .HasDefaultValueSql("30000");

                entity.Property(e => e.StateMachineTransitionErrorCaptureLength).HasDefaultValueSql("30");

                entity.Property(e => e.StateMachineTransitionLoggingEnabled).HasDefaultValueSql("0");

                entity.Property(e => e.StatsDotNetWebServiceUri)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("N'http://localhost'");

                entity.Property(e => e.SubscriptionFailureNumberOfRetries).HasDefaultValueSql("3");

                entity.Property(e => e.SubscriptionFailureWaitBetweenRetriesTime).HasDefaultValueSql("15");

                entity.Property(e => e.UseCookieValidation).HasDefaultValueSql("1");

                entity.HasOne(d => d.Configuration)
                    .WithOne(p => p.TbConfigurationB)
                    .HasForeignKey<TbConfigurationB>(d => d.ConfigurationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbConfigu__Confi__019E3B86");
            });

            modelBuilder.Entity<TbConfigurationC>(entity =>
            {
                entity.HasKey(e => e.ConfigurationId)
                    .HasName("PK__tbConfig__95AA539BA9E67550");

                entity.ToTable("tbConfigurationC");

                entity.Property(e => e.ConfigurationId)
                    .HasColumnName("ConfigurationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowProxyCredentialsOverNonSsl).HasDefaultValueSql("0");

                entity.Property(e => e.AutoDeployMandatory).HasDefaultValueSql("1");

                entity.Property(e => e.BitsDownloadPriorityForeground).HasDefaultValueSql("0");

                entity.Property(e => e.BitsHealthScanningInterval).HasDefaultValueSql("3600000");

                entity.Property(e => e.CollectClientInventory).HasDefaultValueSql("0");

                entity.Property(e => e.CoreXmlCompressionThreshold).HasDefaultValueSql("5120");

                entity.Property(e => e.DeploymentChangeDeferral).HasDefaultValueSql("30");

                entity.Property(e => e.DoDetailedRollup).HasDefaultValueSql("1");

                entity.Property(e => e.DoServerSyncCompression).HasDefaultValueSql("1");

                entity.Property(e => e.DownloadExpressPackages).HasDefaultValueSql("1");

                entity.Property(e => e.DownloadRegulationUrl)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("N''");

                entity.Property(e => e.HmClientsFlags).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsInstallUpdatesGreenPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsInstallUpdatesRedPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsInventoryGreenPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsInventoryRedPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsInventoryScanDiffInHours).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsSilentDays).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsSilentGreenPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsSilentRedPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsTooManyGreenPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmClientsTooManyRedPercent).HasDefaultValueSql("0");

                entity.Property(e => e.HmCoreCatalogSyncIntervalInDays).HasDefaultValueSql("0");

                entity.Property(e => e.HmCoreDiskSpaceGreenMegabytes).HasDefaultValueSql("0");

                entity.Property(e => e.HmCoreDiskSpaceRedMegabytes).HasDefaultValueSql("0");

                entity.Property(e => e.HmCoreFlags).HasDefaultValueSql("0");

                entity.Property(e => e.HmDatabaseFlags).HasDefaultValueSql("0");

                entity.Property(e => e.HmDetectIntervalInSeconds).HasDefaultValueSql("0");

                entity.Property(e => e.HmRefreshIntervalInSeconds).HasDefaultValueSql("0");

                entity.Property(e => e.HmWebServicesFlags).HasDefaultValueSql("0");

                entity.Property(e => e.LazySync).HasDefaultValueSql("1");

                entity.Property(e => e.MaxDownstreamServers).HasDefaultValueSql("1000");

                entity.Property(e => e.ProxyUserDomain)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("N''");

                entity.Property(e => e.PublishedXmlCompressionThreshold).HasDefaultValueSql("5120");

                entity.Property(e => e.ReplicaMode).HasDefaultValueSql("0");

                entity.Property(e => e.RevisionDeletionSizeThreshold).HasDefaultValueSql("1024");

                entity.Property(e => e.RevisionDeletionTimeThreshold).HasDefaultValueSql("30");

                entity.Property(e => e.RollupResetGuid).HasDefaultValueSql("newid()");

                entity.Property(e => e.WusinstallType)
                    .HasColumnName("WUSInstallType")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Configuration)
                    .WithOne(p => p.TbConfigurationC)
                    .HasForeignKey<TbConfigurationC>(d => d.ConfigurationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbConfigu__Confi__02925FBF");
            });

            modelBuilder.Entity<TbDeadDeployment>(entity =>
            {
                entity.HasKey(e => e.DeploymentId)
                    .HasName("PK__tbDeadDe__5EF8D71772A795DC");

                entity.ToTable("tbDeadDeployment");

                entity.HasIndex(e => e.GoLiveTime)
                    .HasName("nc2DeadDeployment");

                entity.HasIndex(e => e.RevisionId)
                    .HasName("nc1DeadDeployment");

                entity.HasIndex(e => e.TimeOfDeath)
                    .HasName("nc3DeadDeployment");

                entity.Property(e => e.DeploymentId)
                    .HasColumnName("DeploymentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(385);

                entity.Property(e => e.AdminNameWhoDeleted)
                    .IsRequired()
                    .HasMaxLength(385)
                    .HasDefaultValueSql("'WUS Server'");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.DeploymentTime).HasColumnType("datetime");

                entity.Property(e => e.GoLiveTime).HasColumnType("datetime");

                entity.Property(e => e.LastChangeNumber).HasDefaultValueSql("0");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.TargetGroupId).HasColumnName("TargetGroupID");

                entity.Property(e => e.TargetGroupTypeId).HasColumnName("TargetGroupTypeID");

                entity.Property(e => e.TimeOfDeath)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.UpdateId).HasColumnName("UpdateID");

                entity.Property(e => e.UpdateType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("N'Software'");
            });

            modelBuilder.Entity<TbDeletedComputer>(entity =>
            {
                entity.HasKey(e => e.ComputerId)
                    .HasName("cDeletedComputer");

                entity.ToTable("tbDeletedComputer");

                entity.Property(e => e.ComputerId)
                    .HasColumnName("ComputerID")
                    .HasMaxLength(256);

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");
            });

            modelBuilder.Entity<TbDeployment>(entity =>
            {
                entity.HasKey(e => e.DeploymentId)
                    .HasName("PK__tbDeploy__5EF8D7160A3579CA");

                entity.ToTable("tbDeployment");

                entity.HasIndex(e => e.DeploymentGuid)
                    .HasName("nc6DeploymentRevision");

                entity.HasIndex(e => e.GoLiveTime)
                    .HasName("nc5DeploymentRevision");

                entity.HasIndex(e => e.LastChangeNumber)
                    .HasName("c0DeploymentRevision");

                entity.HasIndex(e => e.TargetGroupId)
                    .HasName("nc2DeploymentRevision");

                entity.HasIndex(e => new { e.Priority, e.DeploymentTime, e.TargetGroupTypeId, e.RevisionId, e.TargetGroupId, e.ActionId })
                    .HasName("nc_RevisionID_TargetGroupID_ActionID")
                    .IsUnique();

                entity.Property(e => e.DeploymentId).HasColumnName("DeploymentID");

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(385);

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.DeploymentGuid).HasDefaultValueSql("newid()");

                entity.Property(e => e.DeploymentStatus).HasDefaultValueSql("0");

                entity.Property(e => e.DeploymentTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.DownloadPriority).HasDefaultValueSql("1");

                entity.Property(e => e.GoLiveTime).HasColumnType("datetime");

                entity.Property(e => e.IsAssigned).HasDefaultValueSql("0");

                entity.Property(e => e.IsCritical).HasDefaultValueSql("0");

                entity.Property(e => e.IsLeaf).HasDefaultValueSql("1");

                entity.Property(e => e.LastChangeNumber).HasDefaultValueSql("0");

                entity.Property(e => e.LastChangeTime).HasColumnType("datetime");

                entity.Property(e => e.Priority).HasDefaultValueSql("0");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.TargetGroupId).HasColumnName("TargetGroupID");

                entity.Property(e => e.TargetGroupTypeId).HasColumnName("TargetGroupTypeID");

                entity.Property(e => e.UpdateType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("N'Software'");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbDeployment)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbDeploym__Revis__37FA4C37");

                entity.HasOne(d => d.TargetGroup)
                    .WithMany(p => p.TbDeployment)
                    .HasForeignKey(d => d.TargetGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbDeploym__Targe__38EE7070");
            });

            modelBuilder.Entity<TbDownstreamServerClientActivityRollup>(entity =>
            {
                entity.HasKey(e => new { e.ClientSummaryId, e.UpdateId, e.RevisionNumber })
                    .HasName("PK__tbDownst__2C79B11A57995F15");

                entity.ToTable("tbDownstreamServerClientActivityRollup");

                entity.Property(e => e.ClientSummaryId).HasColumnName("ClientSummaryID");

                entity.Property(e => e.UpdateId).HasColumnName("UpdateID");

                entity.HasOne(d => d.ClientSummary)
                    .WithMany(p => p.TbDownstreamServerClientActivityRollup)
                    .HasForeignKey(d => d.ClientSummaryId)
                    .HasConstraintName("FK__tbDownstr__Clien__1E3A7A34");
            });

            modelBuilder.Entity<TbDownstreamServerClientSummaryRollup>(entity =>
            {
                entity.HasKey(e => e.ClientSummaryId)
                    .HasName("PK__tbDownst__BB6E14AECF87A393");

                entity.ToTable("tbDownstreamServerClientSummaryRollup");

                entity.Property(e => e.ClientSummaryId).HasColumnName("ClientSummaryID");

                entity.Property(e => e.NewProductType).HasDefaultValueSql("0");

                entity.Property(e => e.OldProductType).HasDefaultValueSql("0");

                entity.Property(e => e.OsbuildNumber).HasColumnName("OSBuildNumber");

                entity.Property(e => e.Oslocale)
                    .IsRequired()
                    .HasColumnName("OSLocale")
                    .HasMaxLength(10);

                entity.Property(e => e.OsmajorVersion).HasColumnName("OSMajorVersion");

                entity.Property(e => e.OsminorVersion).HasColumnName("OSMinorVersion");

                entity.Property(e => e.OsservicePackMajorNumber).HasColumnName("OSServicePackMajorNumber");

                entity.Property(e => e.OsservicePackMinorNumber).HasColumnName("OSServicePackMinorNumber");

                entity.Property(e => e.ProcessorArchitecture)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SuiteMask).HasDefaultValueSql("0");

                entity.Property(e => e.SystemMetrics).HasDefaultValueSql("0");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.TbDownstreamServerClientSummaryRollup)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__tbDownstr__Targe__2022C2A6");
            });

            modelBuilder.Entity<TbDownstreamServerRollupConfiguration>(entity =>
            {
                entity.ToTable("tbDownstreamServerRollupConfiguration");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LatestEventTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbDownstreamServerSummaryRollup>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("PK__tbDownst__2B1F0FB62F52F086");

                entity.ToTable("tbDownstreamServerSummaryRollup");

                entity.Property(e => e.TargetId)
                    .HasColumnName("TargetID")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Target)
                    .WithOne(p => p.TbDownstreamServerSummaryRollup)
                    .HasForeignKey<TbDownstreamServerSummaryRollup>(d => d.TargetId)
                    .HasConstraintName("FK__tbDownstr__Targe__1F2E9E6D");
            });

            modelBuilder.Entity<TbDownstreamServerTarget>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("PK__tbDownst__2B1F0FB663B00E22");

                entity.ToTable("tbDownstreamServerTarget");

                entity.HasIndex(e => e.AccountServerId)
                    .HasName("ncDownstreamServerTarget_AccountServerID")
                    .IsUnique();

                entity.Property(e => e.TargetId)
                    .HasColumnName("TargetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AccountServerId)
                    .IsRequired()
                    .HasColumnName("AccountServerID");

                entity.Property(e => e.IsReplica).HasDefaultValueSql("0");

                entity.Property(e => e.LastDeploymentSyncTime).HasColumnType("datetime");

                entity.Property(e => e.LastRollupTime).HasColumnType("datetime");

                entity.Property(e => e.LastSyncTime).HasColumnType("datetime");

                entity.Property(e => e.ParentServerTargetId).HasColumnName("ParentServerTargetID");

                entity.Property(e => e.RollupLastSyncTime).HasColumnType("datetime");

                entity.Property(e => e.Sid)
                    .HasColumnName("SID")
                    .HasMaxLength(85);

                entity.Property(e => e.Version).HasMaxLength(32);

                entity.HasOne(d => d.ParentServerTarget)
                    .WithMany(p => p.InverseParentServerTarget)
                    .HasForeignKey(d => d.ParentServerTargetId)
                    .HasConstraintName("FK__tbDownstr__Paren__1D4655FB");

                entity.HasOne(d => d.Target)
                    .WithOne(p => p.TbDownstreamServerTarget)
                    .HasForeignKey<TbDownstreamServerTarget>(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbDownstr__Targe__1C5231C2");
            });

            modelBuilder.Entity<TbDriver>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.HardwareId })
                    .HasName("PK__tbDriver__258B78A935FE2A50");

                entity.ToTable("tbDriver");

                entity.HasIndex(e => e.DriverVerDate)
                    .HasName("nc2Driver");

                entity.HasIndex(e => e.HardwareId)
                    .HasName("nc1Driver");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.HardwareId)
                    .HasColumnName("HardwareID")
                    .HasMaxLength(200);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.DriverVerDate).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.WhqlDriverId).HasColumnName("WhqlDriverID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TbDriver)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbDriver__ClassI__093F5D4E");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbDriver)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbDriver__Revisi__075714DC");
            });

            modelBuilder.Entity<TbDriverClass>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__tbDriver__CB1927A0E2B67419");

                entity.ToTable("tbDriverClass");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbEulaAcceptance>(entity =>
            {
                entity.HasKey(e => e.EulaId)
                    .HasName("PK__tbEulaAc__51426B64EE9DFAAA");

                entity.ToTable("tbEulaAcceptance");

                entity.Property(e => e.EulaId)
                    .HasColumnName("EulaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AcceptedDate).HasColumnType("datetime");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(385);
            });

            modelBuilder.Entity<TbEulaProperty>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.EulaFileDigest, e.LanguageId })
                    .HasName("tbEulaProperty_PK");

                entity.ToTable("tbEulaProperty");

                entity.HasIndex(e => e.EulaFileDigest)
                    .HasName("nc2EulaProperty");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("nc1EulaProperty");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.EulaFileDigest).HasColumnType("binary(20)");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.HasOne(d => d.EulaFileDigestNavigation)
                    .WithMany(p => p.TbEulaProperty)
                    .HasForeignKey(d => d.EulaFileDigest)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEulaPro__EulaF__3CBF0154");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TbEulaProperty)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEulaPro__Langu__3BCADD1B");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbEulaProperty)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEulaPro__Revis__3AD6B8E2");
            });

            modelBuilder.Entity<TbEvent>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.EventNamespaceId })
                    .HasName("PK__tbEvent__24626EC3A12BFFE7");

                entity.ToTable("tbEvent");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventNamespaceId).HasColumnName("EventNamespaceID");

                entity.Property(e => e.LogLevel).HasDefaultValueSql("1");

                entity.Property(e => e.SeverityId).HasColumnName("SeverityID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.HasOne(d => d.EventNamespace)
                    .WithMany(p => p.TbEvent)
                    .HasForeignKey(d => d.EventNamespaceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEvent__EventNa__5AF96FB1");
            });

            modelBuilder.Entity<TbEventInstance>(entity =>
            {
                entity.HasKey(e => e.EventOrdinalNumber)
                    .HasName("PK__tbEventI__94C75A076932DA48");

                entity.ToTable("tbEventInstance");

                entity.HasIndex(e => e.EventInstanceId)
                    .HasName("nc3EventInstanceConstraint")
                    .IsUnique();

                entity.HasIndex(e => e.TimeAtServer)
                    .HasName("nc4EventInstance");

                entity.HasIndex(e => new { e.EventNamespaceId, e.EventId })
                    .HasName("nc_EventNamespaceID_EventID");

                entity.HasIndex(e => new { e.UpdateId, e.RevisionNumber })
                    .HasName("nc2EventInstance");

                entity.HasIndex(e => new { e.ComputerId, e.EventNamespaceId, e.EventId })
                    .HasName("ncEventInstance_ComputerID_EventNamespaceID_EventID");

                entity.Property(e => e.AppName).HasMaxLength(256);

                entity.Property(e => e.ComputerId)
                    .HasColumnName("ComputerID")
                    .HasMaxLength(256);

                entity.Property(e => e.DeviceId)
                    .HasColumnName("DeviceID")
                    .HasColumnType("ntext");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventInstanceId).HasColumnName("EventInstanceID");

                entity.Property(e => e.EventNamespaceId).HasColumnName("EventNamespaceID");

                entity.Property(e => e.EventSourceId).HasColumnName("EventSourceID");

                entity.Property(e => e.MiscData).HasColumnType("ntext");

                entity.Property(e => e.ReplacementStrings).HasColumnType("ntext");

                entity.Property(e => e.TimeAtServer).HasColumnType("datetime");

                entity.Property(e => e.TimeAtTarget).HasColumnType("datetime");

                entity.Property(e => e.UpdateId).HasColumnName("UpdateID");

                entity.Property(e => e.Win32Hresult).HasColumnName("Win32HResult");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TbEventInstance)
                    .HasForeignKey(d => new { d.EventId, d.EventNamespaceId })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEventInstance__5ECA0095");

                entity.HasOne(d => d.EventNavigation)
                    .WithMany(p => p.TbEventInstance)
                    .HasForeignKey(d => new { d.EventSourceId, d.EventNamespaceId })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEventInstance__5DD5DC5C");
            });

            modelBuilder.Entity<TbEventMessageTemplate>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.EventNamespaceId })
                    .HasName("PK__tbEventM__24626EC3DBA38DE9");

                entity.ToTable("tbEventMessageTemplate");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventNamespaceId).HasColumnName("EventNamespaceID");

                entity.Property(e => e.MessageTemplate)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.ShortLanguage).HasMaxLength(16);

                entity.HasOne(d => d.Event)
                    .WithOne(p => p.TbEventMessageTemplate)
                    .HasForeignKey<TbEventMessageTemplate>(d => new { d.EventId, d.EventNamespaceId })
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEventMessageTe__5CE1B823");
            });

            modelBuilder.Entity<TbEventNamespace>(entity =>
            {
                entity.HasKey(e => e.EventNamespaceId)
                    .HasName("PK__tbEventN__D26A6B347131AC8C");

                entity.ToTable("tbEventNamespace");

                entity.Property(e => e.EventNamespaceId)
                    .HasColumnName("EventNamespaceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DisplayNameString)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbEventRollupCounters>(entity =>
            {
                entity.ToTable("tbEventRollupCounters");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LatestRollupTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbEventSource>(entity =>
            {
                entity.HasKey(e => new { e.EventSourceId, e.EventNamespaceId })
                    .HasName("PK__tbEventS__DF51BBD606A6BA4E");

                entity.ToTable("tbEventSource");

                entity.Property(e => e.EventSourceId).HasColumnName("EventSourceID");

                entity.Property(e => e.EventNamespaceId).HasColumnName("EventNamespaceID");

                entity.Property(e => e.DisplayNameString)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.EventNamespace)
                    .WithMany(p => p.TbEventSource)
                    .HasForeignKey(d => d.EventNamespaceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbEventSo__Event__5BED93EA");
            });

            modelBuilder.Entity<TbExpandedTargetInTargetGroup>(entity =>
            {
                entity.HasKey(e => new { e.TargetGroupId, e.TargetId })
                    .HasName("PK__tbExpand__017B08B6FCD6FED6");

                entity.ToTable("tbExpandedTargetInTargetGroup");

                entity.HasIndex(e => e.TargetId)
                    .HasName("nc1ExpandedTargetInTargetGroup");

                entity.Property(e => e.TargetGroupId).HasColumnName("TargetGroupID");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.HasOne(d => d.TargetGroup)
                    .WithMany(p => p.TbExpandedTargetInTargetGroup)
                    .HasForeignKey(d => d.TargetGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbExpande__Targe__178D7CA5");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.TbExpandedTargetInTargetGroup)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbExpande__Targe__1881A0DE");
            });

            modelBuilder.Entity<TbFile>(entity =>
            {
                entity.HasKey(e => e.FileDigest)
                    .HasName("PK__tbFile__67EC15CE2532446E");

                entity.ToTable("tbFile");

                entity.Property(e => e.FileDigest).HasColumnType("binary(20)");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.IsEncrypted).HasDefaultValueSql("0");

                entity.Property(e => e.IsEula).HasDefaultValueSql("0");

                entity.Property(e => e.IsExternalCab).HasDefaultValueSql("0");

                entity.Property(e => e.IsSecure).HasDefaultValueSql("0");

                entity.Property(e => e.Modified).HasColumnType("datetime");

                entity.Property(e => e.Muurl)
                    .HasColumnName("MUURL")
                    .HasMaxLength(1024);

                entity.Property(e => e.Ussurl)
                    .HasColumnName("USSURL")
                    .HasMaxLength(1024);
            });

            modelBuilder.Entity<TbFileDownloadProgress>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK__tbFileDo__FFEE7450303A9921");

                entity.ToTable("tbFileDownloadProgress");

                entity.HasIndex(e => e.Id)
                    .HasName("c0FileDownloadProgress");

                entity.Property(e => e.RowId)
                    .HasColumnName("RowID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TbFileForRevision>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.FileDigest })
                    .HasName("PK__tbFileFo__42CF22AD4674412E");

                entity.ToTable("tbFileForRevision");

                entity.HasIndex(e => e.FileDigest)
                    .HasName("nc1FileForRevision");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.FileDigest).HasColumnType("binary(20)");

                entity.Property(e => e.PatchingType).HasDefaultValueSql("0");

                entity.HasOne(d => d.FileDigestNavigation)
                    .WithMany(p => p.TbFileForRevision)
                    .HasForeignKey(d => d.FileDigest)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbFileFor__FileD__2C88998B");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbFileForRevision)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbFileFor__Revis__2B947552");
            });

            modelBuilder.Entity<TbFileHash>(entity =>
            {
                entity.HasKey(e => e.FileDigest)
                    .HasName("PK__tbFileHa__67EC15CE4A41DE53");

                entity.ToTable("tbFileHash");

                entity.Property(e => e.FileDigest).HasColumnType("binary(20)");

                entity.Property(e => e.AdditionalHash).IsRequired();

                entity.Property(e => e.DigestAlgorithm)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<TbFileOnServer>(entity =>
            {
                entity.HasKey(e => new { e.FileDigest, e.ConfigurationId })
                    .HasName("PK__tbFileOn__CEB6B0F68A5F74E7");

                entity.ToTable("tbFileOnServer");

                entity.HasIndex(e => e.RowId)
                    .HasName("c0FileOnServer");

                entity.Property(e => e.FileDigest).HasColumnType("binary(20)");

                entity.Property(e => e.ConfigurationId).HasColumnName("ConfigurationID");

                entity.Property(e => e.ActualState).HasDefaultValueSql("1");

                entity.Property(e => e.DesiredState).HasDefaultValueSql("1");

                entity.Property(e => e.DssrequestedDownload)
                    .HasColumnName("DSSRequestedDownload")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RowId)
                    .HasColumnName("RowID")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.TimeAddedToQueue).HasColumnType("datetime");

                entity.HasOne(d => d.FileDigestNavigation)
                    .WithMany(p => p.TbFileOnServer)
                    .HasForeignKey(d => d.FileDigest)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbFileOnS__FileD__0662F0A3");
            });

            modelBuilder.Entity<TbFlattenedRevisionInCategory>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.CategoryId })
                    .HasName("PK__tbFlatte__15217053E66BBA2B");

                entity.ToTable("tbFlattenedRevisionInCategory");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("nc1FlattenedRevisionInCategory");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbFlattenedRevisionInCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbFlatten__Categ__0E04126B");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbFlattenedRevisionInCategory)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbFlatten__Revis__0D0FEE32");
            });

            modelBuilder.Entity<TbFlattenedTargetGroup>(entity =>
            {
                entity.HasKey(e => new { e.TargetGroupId, e.ParentGroupId })
                    .HasName("cFlattenedTargetGroup");

                entity.ToTable("tbFlattenedTargetGroup");

                entity.Property(e => e.TargetGroupId).HasColumnName("TargetGroupID");

                entity.Property(e => e.ParentGroupId).HasColumnName("ParentGroupID");

                entity.HasOne(d => d.ParentGroup)
                    .WithMany(p => p.TbFlattenedTargetGroupParentGroup)
                    .HasForeignKey(d => d.ParentGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbFlatten__Paren__14B10FFA");

                entity.HasOne(d => d.TargetGroup)
                    .WithMany(p => p.TbFlattenedTargetGroupTargetGroup)
                    .HasForeignKey(d => d.TargetGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbFlatten__Targe__13BCEBC1");
            });

            modelBuilder.Entity<TbGroupAuthorization>(entity =>
            {
                entity.HasKey(e => new { e.PluginId, e.GroupId })
                    .HasName("PK__tbGroupA__CD594A31D93A0B3D");

                entity.ToTable("tbGroupAuthorization");

                entity.Property(e => e.PluginId)
                    .HasColumnName("PluginID")
                    .HasMaxLength(128);

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.HasOne(d => d.Plugin)
                    .WithMany(p => p.TbGroupAuthorization)
                    .HasForeignKey(d => d.PluginId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbGroupAu__Plugi__39E294A9");
            });

            modelBuilder.Entity<TbHandler>(entity =>
            {
                entity.HasKey(e => e.HandlerId)
                    .HasName("PK__tbHandle__9E0BC72693E6B6A2");

                entity.ToTable("tbHandler");

                entity.Property(e => e.HandlerId).HasColumnName("HandlerID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.SchemaUri)
                    .IsRequired()
                    .HasColumnName("SchemaURI")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbImplicitCategory>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.SubscriptionId })
                    .HasName("PK__tbImplic__D0AB8860885DFE64");

                entity.ToTable("tbImplicitCategory");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("N'Product'");

                entity.Property(e => e.DeltaSync).HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbImplicitCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbImplici__Categ__0A338187");
            });

            modelBuilder.Entity<TbInstalledUpdateSufficientForPrerequisite>(entity =>
            {
                entity.HasKey(e => new { e.LocalUpdateId, e.PrerequisiteId })
                    .HasName("PK__tbInstal__C3A16224C86CF272");

                entity.ToTable("tbInstalledUpdateSufficientForPrerequisite");

                entity.HasIndex(e => e.PrerequisiteId)
                    .HasName("nc1InstalledUpdateSufficientForPrerequisite");

                entity.Property(e => e.LocalUpdateId).HasColumnName("LocalUpdateID");

                entity.Property(e => e.PrerequisiteId).HasColumnName("PrerequisiteID");

                entity.HasOne(d => d.LocalUpdate)
                    .WithMany(p => p.TbInstalledUpdateSufficientForPrerequisite)
                    .HasForeignKey(d => d.LocalUpdateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbInstall__Local__314D4EA8");

                entity.HasOne(d => d.Prerequisite)
                    .WithMany(p => p.TbInstalledUpdateSufficientForPrerequisite)
                    .HasForeignKey(d => d.PrerequisiteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbInstall__Prere__324172E1");
            });

            modelBuilder.Entity<TbInventoryClass>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__tbInvent__CB1927A03ACC2B9D");

                entity.ToTable("tbInventoryClass");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__tbInvent__737584F6A368627C")
                    .IsUnique();

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbInventoryClassInstance>(entity =>
            {
                entity.HasKey(e => e.ClassInstanceId)
                    .HasName("PK__tbInvent__7B875D37C47114B6");

                entity.ToTable("tbInventoryClassInstance");

                entity.HasIndex(e => new { e.TargetId, e.ClassId, e.KeyValue })
                    .HasName("nc_TargetID_ClassID_KeyValue")
                    .IsUnique();

                entity.Property(e => e.ClassInstanceId).HasColumnName("ClassInstanceID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.KeyValue)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TbInventoryClassInstance)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbInvento__Class__222B06A9");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.TbInventoryClassInstance)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK__tbInvento__Targe__231F2AE2");
            });

            modelBuilder.Entity<TbInventoryProperty>(entity =>
            {
                entity.HasKey(e => e.PropertyId)
                    .HasName("PK__tbInvent__70C9A7558979AA70");

                entity.ToTable("tbInventoryProperty");

                entity.HasIndex(e => new { e.ClassId, e.Name })
                    .HasName("nc_ClassID_Name")
                    .IsUnique();

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TbInventoryProperty)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__tbInvento__Class__2042BE37");
            });

            modelBuilder.Entity<TbInventoryPropertyInstance>(entity =>
            {
                entity.HasKey(e => new { e.ClassInstanceId, e.PropertyId })
                    .HasName("PK__tbInvent__3C8BC742F7EC21F4");

                entity.ToTable("tbInventoryPropertyInstance");

                entity.Property(e => e.ClassInstanceId).HasColumnName("ClassInstanceID");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.HasOne(d => d.ClassInstance)
                    .WithMany(p => p.TbInventoryPropertyInstance)
                    .HasForeignKey(d => d.ClassInstanceId)
                    .HasConstraintName("FK__tbInvento__Class__24134F1B");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.TbInventoryPropertyInstance)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbInvento__Prope__25077354");
            });

            modelBuilder.Entity<TbInventoryRule>(entity =>
            {
                entity.HasKey(e => e.RuleId)
                    .HasName("PK__tbInvent__110458C2540EE134");

                entity.ToTable("tbInventoryRule");

                entity.Property(e => e.RuleId)
                    .HasColumnName("RuleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RuleXml)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TbInventoryXml>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("PK__tbInvent__2B1F0FB63517A9D2");

                entity.ToTable("tbInventoryXml");

                entity.Property(e => e.TargetId)
                    .HasColumnName("TargetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompressedXml).HasColumnType("image");

                entity.Property(e => e.IsProcessed).HasDefaultValueSql("0");

                entity.Property(e => e.RawXml).HasColumnType("ntext");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Target)
                    .WithOne(p => p.TbInventoryXml)
                    .HasForeignKey<TbInventoryXml>(d => d.TargetId)
                    .HasConstraintName("FK__tbInvento__Targe__2136E270");
            });

            modelBuilder.Entity<TbKbarticleForRevision>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.KbarticleId })
                    .HasName("PK__tbKBArti__41E15B736E022626");

                entity.ToTable("tbKBArticleForRevision");

                entity.HasIndex(e => e.KbarticleId)
                    .HasName("nc1KBArticleForRevision");

                entity.HasIndex(e => e.RevisionId)
                    .HasName("tbKBArticleForRevision_RevisionID_AK")
                    .IsUnique();

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.KbarticleId)
                    .HasColumnName("KBArticleID")
                    .HasMaxLength(15);

                entity.HasOne(d => d.Revision)
                    .WithOne(p => p.TbKbarticleForRevision)
                    .HasForeignKey<TbKbarticleForRevision>(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbKBArtic__Revis__7FB5F314");
            });

            modelBuilder.Entity<TbLanguage>(entity =>
            {
                entity.HasKey(e => e.LanguageId)
                    .HasName("PK__tbLangua__B938558B585CDEC6");

                entity.ToTable("tbLanguage");

                entity.HasIndex(e => e.ShortLanguage)
                    .HasName("nc1Language");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.Enabled).HasDefaultValueSql("0");

                entity.Property(e => e.FullTextLcid).HasColumnName("FullTextLCID");

                entity.Property(e => e.LanguageAnchor).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageIndex).ValueGeneratedOnAdd();

                entity.Property(e => e.LongLanguage)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.ShortLanguage)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.UssEnabled).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TbLanguageInSubscription>(entity =>
            {
                entity.HasKey(e => new { e.LanguageId, e.SubscriptionId })
                    .HasName("PK__tbLangua__709AE7C070A51539");

                entity.ToTable("tbLanguageInSubscription");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.Property(e => e.DeltaSync).HasDefaultValueSql("0");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TbLanguageInSubscription)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbLanguag__Langu__0C1BC9F9");
            });

            modelBuilder.Entity<TbLocaleMap>(entity =>
            {
                entity.HasKey(e => e.LocaleId)
                    .HasName("PK__tbLocale__AE84BA926A8F84B4");

                entity.ToTable("tbLocaleMap");

                entity.Property(e => e.LocaleId).ValueGeneratedNever();

                entity.Property(e => e.Lcid).HasColumnName("LCID");

                entity.Property(e => e.LocaleLongName).HasColumnType("varchar(50)");

                entity.Property(e => e.LocaleName).HasColumnType("varchar(10)");
            });

            modelBuilder.Entity<TbLocalizedProperty>(entity =>
            {
                entity.HasKey(e => e.LocalizedPropertyId)
                    .HasName("PK__tbLocali__ED9531CA366E1B0A");

                entity.ToTable("tbLocalizedProperty");

                entity.Property(e => e.LocalizedPropertyId).HasColumnName("LocalizedPropertyID");

                entity.Property(e => e.Description).HasMaxLength(1500);

                entity.Property(e => e.ReleaseNote).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TbLocalizedPropertyForRevision>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.LanguageId, e.LocalizedPropertyId })
                    .HasName("PK__tbLocali__D4CFF39823770E96");

                entity.ToTable("tbLocalizedPropertyForRevision");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.LocalizedPropertyId).HasColumnName("LocalizedPropertyID");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TbLocalizedPropertyForRevision)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbLocaliz__Langu__28B808A7");

                entity.HasOne(d => d.LocalizedProperty)
                    .WithMany(p => p.TbLocalizedPropertyForRevision)
                    .HasForeignKey(d => d.LocalizedPropertyId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbLocaliz__Local__2AA05119");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbLocalizedPropertyForRevision)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbLocaliz__Revis__29AC2CE0");
            });

            modelBuilder.Entity<TbMoreInfoUrlforRevision>(entity =>
            {
                entity.HasKey(e => e.RevisionUrlid)
                    .HasName("PK__tbMoreIn__DF49EF3C95DEBEE6");

                entity.ToTable("tbMoreInfoURLForRevision");

                entity.HasIndex(e => new { e.RevisionId, e.ShortLanguage })
                    .HasName("nc_RevisionID_ShortLanguage");

                entity.Property(e => e.RevisionUrlid).HasColumnName("RevisionURLID");

                entity.Property(e => e.MoreInfoUrl)
                    .IsRequired()
                    .HasColumnName("MoreInfoURL")
                    .HasMaxLength(2083);

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.ShortLanguage)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'all'");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbMoreInfoUrlforRevision)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbMoreInf__Revis__7DCDAAA2");
            });

            modelBuilder.Entity<TbNotificationEvent>(entity =>
            {
                entity.HasKey(e => e.NotificationEventId)
                    .HasName("PK__tbNotifi__2BA9DFBCEA0F16ED");

                entity.ToTable("tbNotificationEvent");

                entity.Property(e => e.NotificationEventId).HasColumnName("NotificationEventID");

                entity.Property(e => e.NotificationEventName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RowId).HasColumnName("RowID");
            });

            modelBuilder.Entity<TbOsmap>(entity =>
            {
                entity.HasKey(e => e.Osid)
                    .HasName("PK__tbOSMap__AEE3B0B5B24FAEF5");

                entity.ToTable("tbOSMap");

                entity.Property(e => e.Osid)
                    .HasColumnName("OSid")
                    .ValueGeneratedNever();

                entity.Property(e => e.OsbuildNumber).HasColumnName("OSBuildNumber");

                entity.Property(e => e.OslongName)
                    .HasColumnName("OSLongName")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.OsmajorVersion).HasColumnName("OSMajorVersion");

                entity.Property(e => e.OsminorVersion).HasColumnName("OSMinorVersion");

                entity.Property(e => e.OsservicePackMajorNumber).HasColumnName("OSServicePackMajorNumber");

                entity.Property(e => e.OsservicePackMinorNumber).HasColumnName("OSServicePackMinorNumber");

                entity.Property(e => e.OsshortName)
                    .HasColumnName("OSShortName")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.ProcessorArchitecture)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbPreComputedLocalizedProperty>(entity =>
            {
                entity.HasKey(e => e.PreComputedLocalizedPropertyId)
                    .HasName("PK__tbPreCom__5FF1DDB6F4BF9FF3");

                entity.ToTable("tbPreComputedLocalizedProperty");

                entity.HasIndex(e => new { e.RevisionId, e.ShortLanguage })
                    .HasName("ncPreComputedLocalizedProperty_RevisionID_ShortLanguage");

                entity.HasIndex(e => new { e.UpdateId, e.RevisionNumber })
                    .HasName("nc1PreComputedLocalizedProperty");

                entity.Property(e => e.PreComputedLocalizedPropertyId).HasColumnName("PreComputedLocalizedPropertyID");

                entity.Property(e => e.Description).HasMaxLength(1500);

                entity.Property(e => e.ReleaseNotes).HasMaxLength(1000);

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.ShortLanguage)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateId).HasColumnName("UpdateID");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbPreComputedLocalizedProperty)
                    .HasForeignKey(d => d.RevisionId)
                    .HasConstraintName("FK__tbPreComp__Revis__056ECC6A");
            });

            modelBuilder.Entity<TbPrecomputedCategoryLocalizedProperty>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ShortLanguage })
                    .HasName("PK__tbPrecom__2DD8E6FD1D646311");

                entity.ToTable("tbPrecomputedCategoryLocalizedProperty");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ShortLanguage).HasMaxLength(16);

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbPrecomputedCategoryLocalizedProperty)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbPrecomp__Categ__038683F8");

                entity.HasOne(d => d.CategoryTypeNavigation)
                    .WithMany(p => p.TbPrecomputedCategoryLocalizedProperty)
                    .HasForeignKey(d => d.CategoryType)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbPrecomp__Categ__047AA831");
            });

            modelBuilder.Entity<TbPrerequisite>(entity =>
            {
                entity.HasKey(e => e.PrerequisiteId)
                    .HasName("PK__tbPrereq__25A953F9A720EDB8");

                entity.ToTable("tbPrerequisite");

                entity.HasIndex(e => e.RevisionId)
                    .HasName("nc1Prerequisite");

                entity.Property(e => e.PrerequisiteId).HasColumnName("PrerequisiteID");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbPrerequisite)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbPrerequ__Revis__3335971A");
            });

            modelBuilder.Entity<TbPrerequisiteDependency>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.PrerequisiteRevisionId })
                    .HasName("PK__tbPrereq__4E62540BDBB68AAA");

                entity.ToTable("tbPrerequisiteDependency");

                entity.HasIndex(e => e.PrerequisiteLocalUpdateId)
                    .HasName("nc2PrerequisiteDependency");

                entity.HasIndex(e => e.PrerequisiteRevisionId)
                    .HasName("nc1PrerequisiteDependency");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.PrerequisiteRevisionId).HasColumnName("PrerequisiteRevisionID");

                entity.Property(e => e.PrerequisiteLocalUpdateId).HasColumnName("PrerequisiteLocalUpdateID");
            });

            modelBuilder.Entity<TbProgramKeys>(entity =>
            {
                entity.HasKey(e => e.ProgramKey)
                    .HasName("PK__tbProgra__998876FC3A516CF0");

                entity.ToTable("tbProgramKeys");

                entity.Property(e => e.ProgramKey).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(256);
            });

            modelBuilder.Entity<TbProperty>(entity =>
            {
                entity.HasKey(e => e.RevisionId)
                    .HasName("PK__tbProper__B4B1E3F118F1BB4A");

                entity.ToTable("tbProperty");

                entity.HasIndex(e => e.EulaId)
                    .HasName("nc2Property");

                entity.HasIndex(e => e.UpdateType)
                    .HasName("nc1Property");

                entity.Property(e => e.RevisionId)
                    .HasColumnName("RevisionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompatibleProtocolVersion).HasMaxLength(20);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DefaultPropertiesLanguageId).HasColumnName("DefaultPropertiesLanguageID");

                entity.Property(e => e.EulaExplicitlyAccepted).HasDefaultValueSql("0");

                entity.Property(e => e.EulaId).HasColumnName("EulaID");

                entity.Property(e => e.HandlerId).HasColumnName("HandlerID");

                entity.Property(e => e.MsrcSeverity)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasDefaultValueSql("N'Unspecified'");

                entity.Property(e => e.ReceivedFromCreatorService).HasColumnType("datetime");

                entity.Property(e => e.UpdateType)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasDefaultValueSql("N'Software'");

                entity.HasOne(d => d.Revision)
                    .WithOne(p => p.TbProperty)
                    .HasForeignKey<TbProperty>(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbPropert__Revis__26CFC035");
            });

            modelBuilder.Entity<TbRequestedTargetGroup>(entity =>
            {
                entity.HasKey(e => e.RequestedTargetGroupId)
                    .HasName("PK__tbReques__4AC8E77D6049B615");

                entity.ToTable("tbRequestedTargetGroup");

                entity.HasIndex(e => e.Name)
                    .HasName("AK_Name")
                    .IsUnique();

                entity.Property(e => e.RequestedTargetGroupId).HasColumnName("RequestedTargetGroupID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbRequestedTargetGroupsForTarget>(entity =>
            {
                entity.HasKey(e => new { e.TargetId, e.RequestedTargetGroupId })
                    .HasName("PK__tbReques__EFB381C112800A3B");

                entity.ToTable("tbRequestedTargetGroupsForTarget");

                entity.HasIndex(e => e.RequestedTargetGroupId)
                    .HasName("nc1RequestedTargetGroupNamesForTarget");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.RequestedTargetGroupId).HasColumnName("RequestedTargetGroupID");

                entity.HasOne(d => d.RequestedTargetGroup)
                    .WithMany(p => p.TbRequestedTargetGroupsForTarget)
                    .HasForeignKey(d => d.RequestedTargetGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbRequest__Reque__220B0B18");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.TbRequestedTargetGroupsForTarget)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK__tbRequest__Targe__2116E6DF");
            });

            modelBuilder.Entity<TbRevision>(entity =>
            {
                entity.HasKey(e => e.RevisionId)
                    .HasName("PK__tbRevisi__B4B1E3F162327600");

                entity.ToTable("tbRevision");

                entity.HasIndex(e => e.RowId)
                    .HasName("UQ__tbRevisi__FFEE745025BCA787")
                    .IsUnique();

                entity.HasIndex(e => new { e.IsLatestRevision, e.LocalUpdateId, e.RevisionNumber })
                    .HasName("ncRevision_LocalUpdateID_RevisionNumber__IsLatestRevision");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.IsBeta).HasDefaultValueSql("0");

                entity.Property(e => e.IsCritical).HasDefaultValueSql("0");

                entity.Property(e => e.IsLatestRevision).HasDefaultValueSql("1");

                entity.Property(e => e.IsLeaf).HasDefaultValueSql("1");

                entity.Property(e => e.IsMandatory).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageMask).HasDefaultValueSql("0");

                entity.Property(e => e.LastIsLeafChange).HasColumnType("datetime");

                entity.Property(e => e.LocalUpdateId).HasColumnName("LocalUpdateID");

                entity.Property(e => e.Origin).HasDefaultValueSql("0");

                entity.Property(e => e.RowId)
                    .HasColumnName("RowID")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.State).HasDefaultValueSql("1");

                entity.Property(e => e.TimeToGoLiveOnCatalog).HasColumnType("datetime");

                entity.HasOne(d => d.LocalUpdate)
                    .WithMany(p => p.TbRevision)
                    .HasForeignKey(d => d.LocalUpdateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("PK_constraint_for_table_tbRevision");
            });

            modelBuilder.Entity<TbRevisionExtendedLanguageMask>(entity =>
            {
                entity.HasKey(e => e.RevisionId)
                    .HasName("PK__tbRevisi__B4B1E3F1E74F7476");

                entity.ToTable("tbRevisionExtendedLanguageMask");

                entity.Property(e => e.RevisionId)
                    .HasColumnName("RevisionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LanguageMask2).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageMask3).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageMask4).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageMask5).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageMask6).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageMask7).HasDefaultValueSql("0");

                entity.Property(e => e.LanguageMask8).HasDefaultValueSql("0");

                entity.HasOne(d => d.Revision)
                    .WithOne(p => p.TbRevisionExtendedLanguageMask)
                    .HasForeignKey<TbRevisionExtendedLanguageMask>(d => d.RevisionId)
                    .HasConstraintName("FK__tbRevisio__Revis__25DB9BFC");
            });

            modelBuilder.Entity<TbRevisionExtendedProperty>(entity =>
            {
                entity.HasKey(e => e.RevisionId)
                    .HasName("PK__tbRevisi__B4B1E3F0B01768FF");

                entity.ToTable("tbRevisionExtendedProperty");

                entity.Property(e => e.RevisionId)
                    .HasColumnName("RevisionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ExtendedApplicabilityXml).HasColumnType("ntext");

                entity.Property(e => e.HandlerSpecificDataXml).HasColumnType("ntext");

                entity.Property(e => e.IsInstallableXml).HasColumnType("ntext");

                entity.Property(e => e.IsInstalledXml).HasColumnType("ntext");

                entity.Property(e => e.PrerequisitesXml).HasColumnType("ntext");

                entity.HasOne(d => d.Revision)
                    .WithOne(p => p.TbRevisionExtendedProperty)
                    .HasForeignKey<TbRevisionExtendedProperty>(d => d.RevisionId)
                    .HasConstraintName("FK__tbRevisio__Revis__27C3E46E");
            });

            modelBuilder.Entity<TbRevisionInCategory>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.CategoryId })
                    .HasName("PK__tbRevisi__152170539BEA72D5");

                entity.ToTable("tbRevisionInCategory");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("nc1RevisionInCategory");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Expanded).HasDefaultValueSql("0");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbRevisionInCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbRevisio__Categ__0FEC5ADD");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbRevisionInCategory)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbRevisio__Revis__0EF836A4");
            });

            modelBuilder.Entity<TbRevisionLanguage>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.LanguageId })
                    .HasName("PK__tbRevisi__1F2266A9F014EE9E");

                entity.ToTable("tbRevisionLanguage");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("nc1RevisionLanguage");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.LanguageId).HasColumnName("LanguageID");

                entity.Property(e => e.Expanded).HasDefaultValueSql("0");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TbRevisionLanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbRevisio__Langu__23F3538A");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbRevisionLanguage)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbRevisio__Revis__24E777C3");
            });

            modelBuilder.Entity<TbRevisionSupersedesUpdate>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.SupersededUpdateId })
                    .HasName("PK__tbRevisi__433325835AFF1F14");

                entity.ToTable("tbRevisionSupersedesUpdate");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.SupersededUpdateId).HasColumnName("SupersededUpdateID");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbRevisionSupersedesUpdate)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbRevisio__Revis__30592A6F");
            });

            modelBuilder.Entity<TbSchedule>(entity =>
            {
                entity.HasKey(e => new { e.ScheduleTarget, e.ScheduleId })
                    .HasName("PK__tbSchedu__0AFEF4FF20DB5090");

                entity.ToTable("tbSchedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.LastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(385);

                entity.Property(e => e.LastModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.LastRunTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CONVERT([datetime],'1753-01-01',(120))");

                entity.Property(e => e.ScheduledRunTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbSchemaVersion>(entity =>
            {
                entity.ToTable("tbSchemaVersion");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BuildNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ComponentName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SchemaVersion).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TbSchemaVersionHistory>(entity =>
            {
                entity.ToTable("tbSchemaVersionHistory");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArchivedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.BuildNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ComponentName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SchemaVersion).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TbSecurityBulletinForRevision>(entity =>
            {
                entity.HasKey(e => new { e.RevisionId, e.SecurityBulletinId })
                    .HasName("PK__tbSecuri__2A32F464DCE3A47A");

                entity.ToTable("tbSecurityBulletinForRevision");

                entity.HasIndex(e => e.RevisionId)
                    .HasName("tbSecurityBulletinForRevision_RevisionID_AK")
                    .IsUnique();

                entity.HasIndex(e => e.SecurityBulletinId)
                    .HasName("nc1SecurityBulletinForRevision");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.SecurityBulletinId)
                    .HasColumnName("SecurityBulletinID")
                    .HasMaxLength(15);

                entity.HasOne(d => d.Revision)
                    .WithOne(p => p.TbSecurityBulletinForRevision)
                    .HasForeignKey<TbSecurityBulletinForRevision>(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbSecurit__Revis__7EC1CEDB");
            });

            modelBuilder.Entity<TbServerHealth>(entity =>
            {
                entity.HasKey(e => e.ComponentName)
                    .HasName("PK__tbServer__DB06D1C03E38B71C");

                entity.ToTable("tbServerHealth");

                entity.Property(e => e.ComponentName).HasMaxLength(256);

                entity.Property(e => e.HeartBeat).HasColumnType("datetime");

                entity.Property(e => e.IsRunning).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<TbServerSyncResult>(entity =>
            {
                entity.HasKey(e => e.CategoryList)
                    .HasName("PK__tbServer__54173E1BD42EF791");

                entity.ToTable("tbServerSyncResult");

                entity.HasIndex(e => e.UpdateClassificationList)
                    .HasName("nc2tbServerSyncResult");

                entity.HasIndex(e => new { e.LanguageList, e.UpdateClassificationList })
                    .HasName("nc1ServerSyncResult");

                entity.Property(e => e.CategoryList).HasColumnType("varchar(200)");

                entity.Property(e => e.LanguageList)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.ResultXml).HasColumnType("varchar(7000)");

                entity.Property(e => e.UpdateClassificationList)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<TbSingletonData>(entity =>
            {
                entity.ToTable("tbSingletonData");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastAutoPurgeDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastTimeReportToMu)
                    .HasColumnName("LastTimeReportToMU")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CONVERT([datetime],'2000-01-01',(120))");

                entity.Property(e => e.OfflineSyncExclusionListXml).HasColumnType("ntext");

                entity.Property(e => e.ResetStateMachineNeeded).HasDefaultValueSql("0");

                entity.Property(e => e.UssHostOnMu).HasDefaultValueSql("1");
            });

            modelBuilder.Entity<TbStateMachine>(entity =>
            {
                entity.HasKey(e => e.StateMachineName)
                    .HasName("PK__tbStateM__C1BCE4707F0A5F4E");

                entity.ToTable("tbStateMachine");

                entity.HasIndex(e => e.StateMachineId)
                    .HasName("nc1StateMachine");

                entity.Property(e => e.StateMachineName).HasMaxLength(256);

                entity.Property(e => e.SelectProc)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.StateMachineId)
                    .HasColumnName("StateMachineID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdateProc)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TbStateMachineEvent>(entity =>
            {
                entity.HasKey(e => new { e.StateMachineId, e.EventId })
                    .HasName("PK__tbStateM__6450F59E7BB38580");

                entity.ToTable("tbStateMachineEvent");

                entity.HasIndex(e => e.EventName)
                    .HasName("nc1StateMachineEvent");

                entity.HasIndex(e => new { e.StateMachineId, e.EventName })
                    .HasName("eventNameUniqueForStateMachineID")
                    .IsUnique();

                entity.Property(e => e.StateMachineId).HasColumnName("StateMachineID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbStateMachineEventTransitionLog>(entity =>
            {
                entity.HasKey(e => e.EntryId)
                    .HasName("PK__tbStateM__F57BD2D7B75A8FA8");

                entity.ToTable("tbStateMachineEventTransitionLog");

                entity.Property(e => e.EntryId).HasColumnName("EntryID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.NewStateId).HasColumnName("NewStateID");

                entity.Property(e => e.OldStateId).HasColumnName("OldStateID");

                entity.Property(e => e.RowId).HasColumnName("RowID");

                entity.Property(e => e.StateMachineId).HasColumnName("StateMachineID");
            });

            modelBuilder.Entity<TbStateMachineState>(entity =>
            {
                entity.HasKey(e => new { e.StateMachineId, e.StateId })
                    .HasName("PK__tbStateM__CFFF1AAC75B1994B");

                entity.ToTable("tbStateMachineState");

                entity.HasIndex(e => e.StateName)
                    .HasName("nc1StateMachineState");

                entity.HasIndex(e => new { e.StateMachineId, e.StateName })
                    .HasName("stateNameUniqueForStateMachineID")
                    .IsUnique();

                entity.Property(e => e.StateMachineId).HasColumnName("StateMachineID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbStateMachineTransition>(entity =>
            {
                entity.HasKey(e => new { e.StateMachineId, e.StateId, e.EventId })
                    .HasName("PK__tbStateM__BE865E64C3BF1093");

                entity.ToTable("tbStateMachineTransition");

                entity.Property(e => e.StateMachineId).HasColumnName("StateMachineID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.NewStateId).HasColumnName("NewStateID");

                entity.Property(e => e.StoredProcedure).HasMaxLength(256);
            });

            modelBuilder.Entity<TbTarget>(entity =>
            {
                entity.HasKey(e => e.TargetId)
                    .HasName("PK__tbTarget__2B1F0FB64C365BC8");

                entity.ToTable("tbTarget");

                entity.HasIndex(e => e.TargetTypeId)
                    .HasName("nc1Target");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.IsNewClient).HasDefaultValueSql("0");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.TargetTypeId).HasColumnName("TargetTypeID");

                entity.HasOne(d => d.TargetType)
                    .WithMany(p => p.TbTarget)
                    .HasForeignKey(d => d.TargetTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbTarget__Target__22FF2F51");
            });

            modelBuilder.Entity<TbTargetGroup>(entity =>
            {
                entity.HasKey(e => e.TargetGroupId)
                    .HasName("PK__tbTarget__73CAF84DCBD9F246");

                entity.ToTable("tbTargetGroup");

                entity.Property(e => e.TargetGroupId)
                    .HasColumnName("TargetGroupID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.GroupPriority).HasDefaultValueSql("1");

                entity.Property(e => e.IsBuiltin).HasDefaultValueSql("0");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ParentGroupId)
                    .HasColumnName("ParentGroupID")
                    .HasDefaultValueSql("'A0A08746-4DBE-4a37-9ADF-9E7652C0B421'");

                entity.Property(e => e.TargetGroupTypeId).HasColumnName("TargetGroupTypeID");

                entity.HasOne(d => d.ParentGroup)
                    .WithMany(p => p.InverseParentGroup)
                    .HasForeignKey(d => d.ParentGroupId)
                    .HasConstraintName("FK__tbTargetG__Paren__370627FE");

                entity.HasOne(d => d.TargetGroupType)
                    .WithMany(p => p.TbTargetGroup)
                    .HasForeignKey(d => d.TargetGroupTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbTargetG__Targe__361203C5");
            });

            modelBuilder.Entity<TbTargetGroupInAutoDeploymentRule>(entity =>
            {
                entity.HasKey(e => new { e.AutoDeploymentRuleId, e.TargetGroupId })
                    .HasName("PK__tbTarget__EF99A0AB178309E3");

                entity.ToTable("tbTargetGroupInAutoDeploymentRule");

                entity.Property(e => e.AutoDeploymentRuleId).HasColumnName("AutoDeploymentRuleID");

                entity.Property(e => e.TargetGroupId).HasColumnName("TargetGroupID");

                entity.HasOne(d => d.AutoDeploymentRule)
                    .WithMany(p => p.TbTargetGroupInAutoDeploymentRule)
                    .HasForeignKey(d => d.AutoDeploymentRuleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbTargetG__AutoD__4183B671");

                entity.HasOne(d => d.TargetGroup)
                    .WithMany(p => p.TbTargetGroupInAutoDeploymentRule)
                    .HasForeignKey(d => d.TargetGroupId)
                    .HasConstraintName("FK__tbTargetG__Targe__4277DAAA");
            });

            modelBuilder.Entity<TbTargetGroupType>(entity =>
            {
                entity.HasKey(e => e.TargetGroupTypeId)
                    .HasName("PK__tbTarget__59800DAA04519888");

                entity.ToTable("tbTargetGroupType");

                entity.Property(e => e.TargetGroupTypeId).HasColumnName("TargetGroupTypeID");

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbTargetInTargetGroup>(entity =>
            {
                entity.HasKey(e => new { e.TargetGroupId, e.TargetId })
                    .HasName("PK__tbTarget__017B08B691B57131");

                entity.ToTable("tbTargetInTargetGroup");

                entity.HasIndex(e => e.TargetId)
                    .HasName("nc1TargetInTargetGroup");

                entity.Property(e => e.TargetGroupId).HasColumnName("TargetGroupID");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.HasOne(d => d.TargetGroup)
                    .WithMany(p => p.TbTargetInTargetGroup)
                    .HasForeignKey(d => d.TargetGroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbTargetI__Targe__15A53433");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.TbTargetInTargetGroup)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbTargetI__Targe__1699586C");
            });

            modelBuilder.Entity<TbTargetType>(entity =>
            {
                entity.HasKey(e => e.TargetTypeId)
                    .HasName("PK__tbTarget__B3CB14E195BD7C98");

                entity.ToTable("tbTargetType");

                entity.Property(e => e.TargetTypeId).HasColumnName("TargetTypeID");

                entity.Property(e => e.Description).HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbUpdate>(entity =>
            {
                entity.HasKey(e => e.LocalUpdateId)
                    .HasName("PK__tbUpdate__41FBF71B76CCEB62");

                entity.ToTable("tbUpdate");

                entity.HasIndex(e => e.UpdateId)
                    .HasName("UQ__tbUpdate__7A0CF3241635AA21")
                    .IsUnique();

                entity.HasIndex(e => new { e.IsLocallyPublished, e.IsHidden, e.IsClientSelfUpdate, e.IsPublic })
                    .HasName("nc1UpdateBooleanProperties");

                entity.Property(e => e.LocalUpdateId).HasColumnName("LocalUpdateID");

                entity.Property(e => e.DetectoidType).HasMaxLength(80);

                entity.Property(e => e.ImportedTime).HasColumnType("datetime");

                entity.Property(e => e.IsClientSelfUpdate).HasDefaultValueSql("1");

                entity.Property(e => e.IsHidden).HasDefaultValueSql("0");

                entity.Property(e => e.IsLocallyPublished).HasDefaultValueSql("0");

                entity.Property(e => e.IsPublic).HasDefaultValueSql("1");

                entity.Property(e => e.LastUndeclinedTime).HasColumnType("datetime");

                entity.Property(e => e.LegacyName).HasMaxLength(255);

                entity.Property(e => e.PublisherId)
                    .HasColumnName("PublisherID")
                    .HasDefaultValueSql("newid()");

                entity.Property(e => e.UpdateId).HasColumnName("UpdateID");

                entity.Property(e => e.UpdateTypeId).HasColumnName("UpdateTypeID");

                entity.HasOne(d => d.UpdateType)
                    .WithMany(p => p.TbUpdate)
                    .HasForeignKey(d => d.UpdateTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbUpdate__Update__351DDF8C");
            });

            modelBuilder.Entity<TbUpdateClassificationInAutoDeploymentRule>(entity =>
            {
                entity.HasKey(e => new { e.AutoDeploymentRuleId, e.UpdateClassificationId })
                    .HasName("PK__tbUpdate__EF57E38A517755D0");

                entity.ToTable("tbUpdateClassificationInAutoDeploymentRule");

                entity.Property(e => e.AutoDeploymentRuleId).HasColumnName("AutoDeploymentRuleID");

                entity.Property(e => e.UpdateClassificationId).HasColumnName("UpdateClassificationID");

                entity.HasOne(d => d.AutoDeploymentRule)
                    .WithMany(p => p.TbUpdateClassificationInAutoDeploymentRule)
                    .HasForeignKey(d => d.AutoDeploymentRuleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbUpdateC__AutoD__3DB3258D");

                entity.HasOne(d => d.UpdateClassification)
                    .WithMany(p => p.TbUpdateClassificationInAutoDeploymentRule)
                    .HasForeignKey(d => d.UpdateClassificationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbUpdateC__Updat__3EA749C6");
            });

            modelBuilder.Entity<TbUpdateFlag>(entity =>
            {
                entity.HasKey(e => e.LocalUpdateId)
                    .HasName("PK__tbUpdate__41FBF71B138AF7F3");

                entity.ToTable("tbUpdateFlag");

                entity.Property(e => e.LocalUpdateId)
                    .HasColumnName("LocalUpdateID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TbUpdateStatusPerComputer>(entity =>
            {
                entity.HasKey(e => new { e.TargetId, e.LocalUpdateId })
                    .HasName("cUpdateStatusPerComputer");

                entity.ToTable("tbUpdateStatusPerComputer");

                entity.HasIndex(e => e.SummarizationState)
                    .HasName("nc3UpdateStatusPerComputer");

                entity.HasIndex(e => new { e.SummarizationState, e.LastChangeTime, e.LocalUpdateId })
                    .HasName("nc2UpdateStatusPerComputer");

                entity.Property(e => e.TargetId).HasColumnName("TargetID");

                entity.Property(e => e.LocalUpdateId).HasColumnName("LocalUpdateID");

                entity.Property(e => e.LastChangeTime).HasColumnType("datetime");

                entity.Property(e => e.LastChangeTimeOnServer).HasColumnType("datetime");

                entity.Property(e => e.LastRefreshTime).HasColumnType("datetime");

                entity.HasOne(d => d.LocalUpdate)
                    .WithMany(p => p.TbUpdateStatusPerComputer)
                    .HasForeignKey(d => d.LocalUpdateId)
                    .HasConstraintName("FK__tbUpdateS__Local__4460231C");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.TbUpdateStatusPerComputer)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK__tbUpdateS__Targe__436BFEE3");
            });

            modelBuilder.Entity<TbUpdateSummaryForAllComputers>(entity =>
            {
                entity.HasKey(e => e.LocalUpdateId)
                    .HasName("PK__tbUpdate__41FBF71B37766920");

                entity.ToTable("tbUpdateSummaryForAllComputers");

                entity.Property(e => e.LocalUpdateId)
                    .HasColumnName("LocalUpdateID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Downloaded).HasDefaultValueSql("0");

                entity.Property(e => e.Failed).HasDefaultValueSql("0");

                entity.Property(e => e.Installed).HasDefaultValueSql("0");

                entity.Property(e => e.InstalledPendingReboot).HasDefaultValueSql("0");

                entity.Property(e => e.LastChangeTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getutcdate()");

                entity.Property(e => e.NotInstalled).HasDefaultValueSql("0");

                entity.HasOne(d => d.LocalUpdate)
                    .WithOne(p => p.TbUpdateSummaryForAllComputers)
                    .HasForeignKey<TbUpdateSummaryForAllComputers>(d => d.LocalUpdateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_LocalUpdateID");
            });

            modelBuilder.Entity<TbUpdateType>(entity =>
            {
                entity.HasKey(e => e.UpdateTypeId)
                    .HasName("PK__tbUpdate__C6E9765122D5E781");

                entity.ToTable("tbUpdateType");

                entity.Property(e => e.UpdateTypeId)
                    .HasColumnName("UpdateTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TbXml>(entity =>
            {
                entity.HasKey(e => e.XmlId)
                    .HasName("PK__tbXml__D14A66A93B0CF919");

                entity.ToTable("tbXml");

                entity.HasIndex(e => e.RevisionId)
                    .HasName("nc1tbXml");

                entity.HasIndex(e => e.RootElementType)
                    .HasName("nc2tbXml");

                entity.Property(e => e.XmlId).HasColumnName("XmlID");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RevisionId).HasColumnName("RevisionID");

                entity.Property(e => e.RootElementXml)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.RootElementXmlCompressed).HasColumnType("image");

                entity.HasOne(d => d.Revision)
                    .WithMany(p => p.TbXml)
                    .HasForeignKey(d => d.RevisionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK__tbXml__RevisionI__00AA174D");
            });
        }
    }
}