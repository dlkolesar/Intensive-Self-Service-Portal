using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Intensive.Data.ADMT
{
    public partial class ADMTContext : DbContext
    {
        public ADMTContext()
        {
        }

        public ADMTContext(DbContextOptions<ADMTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Computers> Computers { get; set; }
        public virtual DbSet<DistributedTasks> DistributedTasks { get; set; }
        public virtual DbSet<Domains> Domains { get; set; }
        public virtual DbSet<GlobalTasks> GlobalTasks { get; set; }
        public virtual DbSet<LocalTasks> LocalTasks { get; set; }
        public virtual DbSet<LockedObjects> LockedObjects { get; set; }
        public virtual DbSet<MigratedObjects> MigratedObjects { get; set; }
        public virtual DbSet<MigratedObjectsView> MigratedObjectsView { get; set; }
        public virtual DbSet<NameConflicts> NameConflicts { get; set; }
        public virtual DbSet<NameConflictsDomains> NameConflictsDomains { get; set; }
        public virtual DbSet<NameConflictsNames> NameConflictsNames { get; set; }
        public virtual DbSet<Objects> Objects { get; set; }
        public virtual DbSet<PasswordAgeComputers> PasswordAgeComputers { get; set; }
        public virtual DbSet<PasswordAgeDomains> PasswordAgeDomains { get; set; }
        public virtual DbSet<RefAccounts> RefAccounts { get; set; }
        public virtual DbSet<RefComputers> RefComputers { get; set; }
        public virtual DbSet<RefDomains> RefDomains { get; set; }
        public virtual DbSet<RefTypes> RefTypes { get; set; }
        public virtual DbSet<References> References { get; set; }
        public virtual DbSet<Servers> Servers { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<TaskProperties> TaskProperties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADMT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computers>(entity =>
            {
                entity.HasKey(e => e.ComputerId);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Computers")
                    .IsUnique();

                entity.Property(e => e.DnsName).HasMaxLength(256);

                entity.Property(e => e.FlatName).HasMaxLength(32);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<DistributedTasks>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.ComputerId });

                entity.Property(e => e.Job).HasColumnType("image");

                entity.Property(e => e.LogFile).HasColumnType("image");

                entity.Property(e => e.StatusText)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.HasOne(d => d.Computer)
                    .WithMany(p => p.DistributedTasks)
                    .HasForeignKey(d => d.ComputerId)
                    .HasConstraintName("FK_DistributedTasks_Computers");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.DistributedTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_DistributedTasks_LocalTasks");
            });

            modelBuilder.Entity<Domains>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.Property(e => e.DomainId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DnsName).HasMaxLength(256);

                entity.Property(e => e.FlatName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.Guid)
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<GlobalTasks>(entity =>
            {
                entity.HasKey(e => e.GlobalTaskId);

                entity.Property(e => e.GlobalTaskId).ValueGeneratedNever();

                entity.Property(e => e.TaskTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<LocalTasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.AccountFile).HasColumnType("image");

                entity.Property(e => e.AdmtComputer)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("(host_name())");

                entity.Property(e => e.AdmtUser)
                    .HasMaxLength(256)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.LogFile).HasColumnType("image");

                entity.HasOne(d => d.GlobalTask)
                    .WithMany(p => p.LocalTasks)
                    .HasForeignKey(d => d.GlobalTaskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocalTasks_GlobalTasks");
            });

            modelBuilder.Entity<LockedObjects>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DistinguishedName)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.LockTime).HasColumnType("datetime");

                entity.Property(e => e.SamName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<MigratedObjects>(entity =>
            {
                entity.HasKey(e => new { e.SourceObjectId, e.TargetObjectId });

                entity.HasIndex(e => e.MigrationTime)
                    .HasName("IX_MigratedObjects_Time");

                entity.Property(e => e.MigrationTime).HasColumnType("datetime");

                entity.Property(e => e.PasswordCopyTime).HasColumnType("datetime");

                entity.HasOne(d => d.GlobalTask)
                    .WithMany(p => p.MigratedObjects)
                    .HasForeignKey(d => d.GlobalTaskId)
                    .HasConstraintName("FK_MigratedObjects_GlobalTasks");

                entity.HasOne(d => d.SourceObject)
                    .WithMany(p => p.MigratedObjectsSourceObject)
                    .HasForeignKey(d => d.SourceObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MigratedObjects_Objects");

                entity.HasOne(d => d.TargetObject)
                    .WithMany(p => p.MigratedObjectsTargetObject)
                    .HasForeignKey(d => d.TargetObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MigratedObjects_Objects1");
            });

            modelBuilder.Entity<MigratedObjectsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MigratedObjectsView");

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.SourceAdsPath)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.SourceDomain).HasMaxLength(256);

                entity.Property(e => e.SourceDomainDns).HasMaxLength(256);

                entity.Property(e => e.SourceDomainFlat)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.SourceDomainSid)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.SourceSamName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TargetAdsPath)
                    .IsRequired()
                    .HasMaxLength(2048);

                entity.Property(e => e.TargetDomain).HasMaxLength(256);

                entity.Property(e => e.TargetDomainDns).HasMaxLength(256);

                entity.Property(e => e.TargetDomainFlat)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.Property(e => e.TargetSamName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<NameConflicts>(entity =>
            {
                entity.HasKey(e => new { e.SourceDomainId, e.TargetDomainId });

                entity.HasOne(d => d.SourceDomain)
                    .WithMany(p => p.NameConflictsSourceDomain)
                    .HasForeignKey(d => d.SourceDomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NameConflicts_NameConflictsDomains_Source");

                entity.HasOne(d => d.TargetDomain)
                    .WithMany(p => p.NameConflictsTargetDomain)
                    .HasForeignKey(d => d.TargetDomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NameConflicts_NameConflictsDomains_Target");
            });

            modelBuilder.Entity<NameConflictsDomains>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_NameConflictsDomains")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<NameConflictsNames>(entity =>
            {
                entity.HasKey(e => new { e.DomainId, e.Sam });

                entity.Property(e => e.Sam).HasMaxLength(256);

                entity.Property(e => e.Canonical).HasMaxLength(256);

                entity.Property(e => e.Rdn).HasMaxLength(64);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.NameConflictsNames)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NameConflictsNames_NameConflictsDomains");
            });

            modelBuilder.Entity<Objects>(entity =>
            {
                entity.HasKey(e => e.ObjectId);

                entity.HasIndex(e => e.Guid);

                entity.HasIndex(e => e.Type);

                entity.HasIndex(e => new { e.AdsPathTruncated, e.DomainId })
                    .HasName("IX_ADsPathTruncated_DomainId_Objects");

                entity.HasIndex(e => new { e.DomainId, e.Rid })
                    .HasName("IX_Objects_Domain_Rid")
                    .IsUnique();

                entity.HasIndex(e => new { e.SamName, e.DomainId });

                entity.Property(e => e.ObjectId).ValueGeneratedNever();

                entity.Property(e => e.AdsPath)
                    .IsRequired()
                    .HasColumnName("ADsPath")
                    .HasMaxLength(2048);

                entity.Property(e => e.AdsPathTruncated)
                    .HasColumnName("ADsPathTruncated")
                    .HasMaxLength(400)
                    .HasComputedColumnSql("(CONVERT([nvarchar](400),[ADsPath]))");

                entity.Property(e => e.Guid)
                    .HasMaxLength(32)
                    .IsFixedLength();

                entity.Property(e => e.SamName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Usn).HasColumnName("USN");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.Objects)
                    .HasForeignKey(d => d.DomainId)
                    .HasConstraintName("FK_Objects_Domains");
            });

            modelBuilder.Entity<PasswordAgeComputers>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.PasswordAgeComputers)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PasswordAgeComputers_PasswordAgeDomains");
            });

            modelBuilder.Entity<PasswordAgeDomains>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RefAccounts>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_RefAccounts")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.RefAccounts)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RefAccounts_RefDomains");
            });

            modelBuilder.Entity<RefComputers>(entity =>
            {
                entity.HasKey(e => e.ComputerId);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_RefComputers")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RefDomains>(entity =>
            {
                entity.HasKey(e => e.DomainId);

                entity.HasIndex(e => e.Name)
                    .HasName("IX_RefDomains")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RefTypes>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<References>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.ComputerId, e.TypeId });

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_References_RefAccounts");

                entity.HasOne(d => d.Computer)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.ComputerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_References_RefComputers");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.References)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_References_RefTypes");
            });

            modelBuilder.Entity<Servers>(entity =>
            {
                entity.HasKey(e => e.DomainName);

                entity.Property(e => e.DomainName).HasMaxLength(256);

                entity.Property(e => e.SourceServerName).HasMaxLength(256);

                entity.Property(e => e.TargetServerName).HasMaxLength(256);
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => new { e.ComputerId, e.Name });

                entity.HasIndex(e => e.Account);

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Computer)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ComputerId)
                    .HasConstraintName("FK_Services_Computers");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.SettingName);

                entity.Property(e => e.SettingName).HasMaxLength(256);

                entity.Property(e => e.SettingValue).HasColumnType("sql_variant");
            });

            modelBuilder.Entity<TaskProperties>(entity =>
            {
                entity.HasKey(e => new { e.TaskId, e.PropertyName });

                entity.Property(e => e.PropertyName).HasMaxLength(256);

                entity.Property(e => e.PropertyValue).HasColumnType("sql_variant");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TaskProperties)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_TaskProperties_LocalTasks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
