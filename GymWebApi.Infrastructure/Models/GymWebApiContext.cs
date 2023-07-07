using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GymWebApi.Infrastructure.Models;

public partial class GymWebApiContext : DbContext
{
    public GymWebApiContext()
    {
    }

    public GymWebApiContext(DbContextOptions<GymWebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<ActivityCreation> ActivityCreations { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<CardDetail> CardDetails { get; set; }

    public virtual DbSet<Club> Clubs { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<TrainerSpecialInformation> TrainerSpecialInformations { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    public virtual DbSet<UserPrivateInformation> UserPrivateInformations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0VH2JPM;Initial Catalog=GymWebApp;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK_ActivityId");

            entity.ToTable(tb => tb.HasTrigger("ActivityCreationTrigger"));

            entity.Property(e => e.ActivityId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.ActivityDate).HasColumnType("date");
            entity.Property(e => e.ActivityEndTime)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ActivityName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ActivityStartTime)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ClubId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId)
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.HasOne(d => d.Club).WithMany(p => p.Activities)
                .HasForeignKey(d => d.ClubId)
                .HasConstraintName("FK_Activities_ClubId");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Activities)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK_Activities_TrainerId");
        });

        modelBuilder.Entity<ActivityCreation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ActivityCreation");

            entity.Property(e => e.ActivityCreationDate).HasColumnType("date");
            entity.Property(e => e.ActivityDeletionDate).HasColumnType("date");
            entity.Property(e => e.ActivityId)
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.HasOne(d => d.Activity).WithMany()
                .HasForeignKey(d => d.ActivityId)
                .HasConstraintName("FK_ActivityCreation_ActivityId");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<CardDetail>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK_CardId");

            entity.Property(e => e.CardId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.CardCvc).HasColumnName("CardCVC");
            entity.Property(e => e.CardExpDate)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Club>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK_ClubId");

            entity.Property(e => e.ClubId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.ClubLocation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClubName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ClubWorkingHours)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK_MembershipId");

            entity.Property(e => e.MembershipId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.MembershipType)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK_TrainerId");

            entity.Property(e => e.TrainerId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.TrainerFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrainerLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrainerPicture).HasColumnType("text");
            entity.Property(e => e.TrainerSpecialization)
                .HasMaxLength(70)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TrainerSpecialInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TrainerSpecialInformation");

            entity.Property(e => e.TrainerEmail)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.TrainerPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Trainer).WithMany()
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK_TrainerId");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_TransactionId");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.TransactionDescription).HasColumnType("text");
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TransactionLog");

            entity.Property(e => e.CardId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.TransactionId)
                .HasMaxLength(36)
                .IsUnicode(false);

            entity.HasOne(d => d.Card).WithMany()
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("FK_TransactionLog_CardId");

            entity.HasOne(d => d.Transaction).WithMany()
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_TransactionLog_TransactionId");
        });

        modelBuilder.Entity<UserPrivateInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserPrivateInformation");

            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.CardId)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Pin)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PIN");
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.Card).WithMany()
                .HasForeignKey(d => d.CardId)
                .HasConstraintName("FK_UserPrivateInformation_CardId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
