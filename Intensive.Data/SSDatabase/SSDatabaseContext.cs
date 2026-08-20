using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Intensive.Data.SSDatabase
{
    public partial class SSDatabaseContext : DbContext
    {
        public SSDatabaseContext()
        {
        }

        public SSDatabaseContext(DbContextOptions<SSDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdmigrations> TbAdmigrations { get; set; }
        public virtual DbSet<TbAricJob> TbAricJob { get; set; }
        public virtual DbSet<TbAricProcess> TbAricProcess { get; set; }
        public virtual DbSet<TbAricProcessArgument> TbAricProcessArgument { get; set; }
        public virtual DbSet<TbAuditTrail> TbAuditTrail { get; set; }
        public virtual DbSet<TbConfig> TbConfig { get; set; }
        public virtual DbSet<TbEncryptedConfig> TbEncryptedConfig { get; set; }
        public virtual DbSet<TbManagedSystems> TbManagedSystems { get; set; }
        public virtual DbSet<TbMetricKeys> TbMetricKeys { get; set; }
        public virtual DbSet<TbMetrics> TbMetrics { get; set; }
        public virtual DbSet<TbPatchingAccounts> TbPatchingAccounts { get; set; }
        public virtual DbSet<TbPatchingClientConfigAdvanced> TbPatchingClientConfigAdvanced { get; set; }
        public virtual DbSet<TbPatchingClientConfigBasic> TbPatchingClientConfigBasic { get; set; }
        public virtual DbSet<TbPatchingClients> TbPatchingClients { get; set; }
        public virtual DbSet<TbPatchingTicketHistory> TbPatchingTicketHistory { get; set; }
        public virtual DbSet<TbServerTags> TbServerTags { get; set; }
        public virtual DbSet<TbServers> TbServers { get; set; }
        public virtual DbSet<TbTags> TbTags { get; set; }
        public virtual DbSet<TbUserRole> TbUserRole { get; set; }
        public virtual DbSet<VwPatchingClient> VwPatchingClient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SSDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAdmigrations>(entity =>
            {
                entity.ToTable("tbADMigrations");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MigrationType)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Objects)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SourceDomain)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sso)
                    .IsRequired()
                    .HasColumnName("SSO")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Submitted).HasColumnType("datetime");

                entity.Property(e => e.TargetOu)
                    .IsRequired()
                    .HasColumnName("TargetOU")
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAricJob>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("tbAricJob");

                entity.Property(e => e.EventId)
                    .HasColumnName("EventID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Completed).HasColumnType("datetime");

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.ProcessName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnedData).HasColumnType("text");

                entity.Property(e => e.Started).HasColumnType("datetime");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Submitted).HasColumnType("datetime");

                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAricProcess>(entity =>
            {
                entity.HasKey(e => e.ProcessName);

                entity.ToTable("tbAricProcess");

                entity.Property(e => e.ProcessName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.SystemId).HasColumnName("SystemID");
            });

            modelBuilder.Entity<TbAricProcessArgument>(entity =>
            {
                entity.ToTable("tbAricProcessArgument");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAuditTrail>(entity =>
            {
                entity.ToTable("tbAuditTrail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Detail).IsUnicode(false);

                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigKey);

                entity.ToTable("tbConfig");

                entity.Property(e => e.ConfigKey)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigJson)
                    .IsRequired()
                    .HasColumnName("ConfigJSON")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbEncryptedConfig>(entity =>
            {
                entity.HasKey(e => e.ConfigKey);

                entity.ToTable("tbEncryptedConfig");

                entity.Property(e => e.ConfigKey)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigJson)
                    .IsRequired()
                    .HasColumnName("ConfigJSON")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbManagedSystems>(entity =>
            {
                entity.HasKey(e => e.SystemId)
                    .HasName("PK_ManagedSystems");

                entity.ToTable("tbManagedSystems");

                entity.Property(e => e.SystemId).HasColumnName("SystemID");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Manager)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerSso)
                    .IsRequired()
                    .HasColumnName("ManagerSSO")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryOwner)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PrimaryOwnerSso)
                    .IsRequired()
                    .HasColumnName("PrimaryOwnerSSO")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryOwner)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SecondaryOwnerSso)
                    .HasColumnName("SecondaryOwnerSSO")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbMetricKeys>(entity =>
            {
                entity.ToTable("tbMetricKeys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.MetricKey)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SystemId).HasColumnName("SystemID");
            });

            modelBuilder.Entity<TbMetrics>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbMetrics");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MetricDate).HasColumnType("date");

                entity.Property(e => e.MetricKey)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPatchingAccounts>(entity =>
            {
                entity.HasKey(e => e.Number);

                entity.ToTable("tbPatchingAccounts");

                entity.Property(e => e.Number).ValueGeneratedNever();

                entity.Property(e => e.LastRefresh).HasColumnType("datetime");

                entity.Property(e => e.OptInOutDate).HasColumnType("datetime");

                entity.Property(e => e.OptInOutTicket)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbPatchingClientConfigAdvanced>(entity =>
            {
                entity.HasKey(e => e.DeviceNumber)
                    .HasName("PK_PatchingClientConfigAdvanced");

                entity.ToTable("tbPatchingClientConfigAdvanced");

                entity.Property(e => e.DeviceNumber).ValueGeneratedNever();

                entity.Property(e => e.ArictimeTableId).HasColumnName("ARICTimeTableID");
            });

            modelBuilder.Entity<TbPatchingClientConfigBasic>(entity =>
            {
                entity.HasKey(e => e.DeviceNumber)
                    .HasName("PK_PatchingClientConfigBasic");

                entity.ToTable("tbPatchingClientConfigBasic");

                entity.Property(e => e.DeviceNumber).ValueGeneratedNever();
            });

            modelBuilder.Entity<TbPatchingClients>(entity =>
            {
                entity.HasKey(e => e.DeviceNumber)
                    .HasName("PK_PatchingClients");

                entity.ToTable("tbPatchingClients");

                entity.Property(e => e.DeviceNumber).ValueGeneratedNever();

                entity.Property(e => e.Auoptions).HasColumnName("AUOptions");

                entity.Property(e => e.LastPatchDate).HasColumnType("datetime");

                entity.Property(e => e.LastRefresh).HasColumnType("datetime");

                entity.Property(e => e.UseWuserver).HasColumnName("UseWUServer");

                entity.Property(e => e.Wsusid).HasColumnName("WSUSID");

                entity.Property(e => e.Wuserver)
                    .IsRequired()
                    .HasColumnName("WUServer")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPatchingTicketHistory>(entity =>
            {
                entity.ToTable("tbPatchingTicketHistory");

                entity.Property(e => e.CoreTicket)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RunId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TicketType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbServerTags>(entity =>
            {
                entity.ToTable("tbServerTags");

                entity.HasIndex(e => e.DeviceNumber)
                    .HasName("idxServerTags_DeviceNumber");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TagId).HasColumnName("TagID");
            });

            modelBuilder.Entity<TbServers>(entity =>
            {
                entity.HasKey(e => e.DeviceNumber)
                    .HasName("PK_Servers");

                entity.ToTable("tbServers");

                entity.Property(e => e.DeviceNumber).ValueGeneratedNever();

                entity.Property(e => e.AntiVirusId).HasColumnName("AntiVirusID");

                entity.Property(e => e.DataCenter)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastRefresh).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.NimBusrobotId)
                    .HasColumnName("NimBUSRobotID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("OS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScomagentId).HasColumnName("SCOMAgentID");

                entity.Property(e => e.Tags).IsUnicode(false);

                entity.Property(e => e.Wsusid).HasColumnName("WSUSID");
            });

            modelBuilder.Entity<TbTags>(entity =>
            {
                entity.ToTable("tbTags");

                entity.HasIndex(e => e.Account)
                    .HasName("idxTags_Account");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbUserRole>(entity =>
            {
                entity.ToTable("tbUserRole");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Member)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwPatchingClient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPatchingClient");

                entity.Property(e => e.Auoptions).HasColumnName("AUOptions");

                entity.Property(e => e.DataCenter)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastPatchDate).HasColumnType("datetime");

                entity.Property(e => e.LastRefresh).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Os)
                    .IsRequired()
                    .HasColumnName("OS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UseWuserver).HasColumnName("UseWUServer");

                entity.Property(e => e.Wsusid).HasColumnName("WSUSID");

                entity.Property(e => e.Wuserver)
                    .IsRequired()
                    .HasColumnName("WUServer")
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
