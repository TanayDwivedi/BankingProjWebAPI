using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class BANKINGContext : DbContext
    {
        public BANKINGContext()
        {
        }

        public BANKINGContext(DbContextOptions<BANKINGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDetail> AccountDetails { get; set; }
        public virtual DbSet<BeneficiaryDetail> BeneficiaryDetails { get; set; }
        public virtual DbSet<GrossAnnualIncome> GrossAnnualIncomes { get; set; }
        public virtual DbSet<LocationCityState> LocationCityStates { get; set; }
        public virtual DbSet<LocationPinCodeCity> LocationPinCodeCities { get; set; }
        public virtual DbSet<NetBankingUserDetail> NetBankingUserDetails { get; set; }
        public virtual DbSet<OccupationType> OccupationTypes { get; set; }
        public virtual DbSet<SourceOfIncome> SourceOfIncomes { get; set; }
        public virtual DbSet<UserOpenAccount> UserOpenAccounts { get; set; }
        public virtual DbSet<UserTransaction> UserTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BANKING;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountDetail>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("pk_AccountNumber");

                entity.Property(e => e.AadharCardNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AadharCardNumberNavigation)
                    .WithMany(p => p.AccountDetails)
                    .HasForeignKey(d => d.AadharCardNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AadharNumber");
            });

            modelBuilder.Entity<BeneficiaryDetail>(entity =>
            {
                entity.HasKey(e => new { e.BeneficiaryAccNo, e.UserAccountNo })
                    .HasName("pk_BeneficiaryDetails");

                entity.Property(e => e.BeneficiaryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.BeneficiaryAccNoNavigation)
                    .WithMany(p => p.BeneficiaryDetailBeneficiaryAccNoNavigations)
                    .HasForeignKey(d => d.BeneficiaryAccNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_BeneficiaryAccNo");

                entity.HasOne(d => d.UserAccountNoNavigation)
                    .WithMany(p => p.BeneficiaryDetailUserAccountNoNavigations)
                    .HasForeignKey(d => d.UserAccountNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UserAccountNo");
            });

            modelBuilder.Entity<GrossAnnualIncome>(entity =>
            {
                entity.HasKey(e => e.AnnualIncome)
                    .HasName("pk_AnnualIncome");

                entity.ToTable("GrossAnnualIncome");

                entity.Property(e => e.AnnualIncome)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationCityState>(entity =>
            {
                entity.HasKey(e => e.City)
                    .HasName("pk_City");

                entity.ToTable("LocationCityState");

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CityState)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("City_State");
            });

            modelBuilder.Entity<LocationPinCodeCity>(entity =>
            {
                entity.HasKey(e => e.Pincode)
                    .HasName("pk_Pincode");

                entity.ToTable("LocationPinCodeCity");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.LocationPinCodeCities)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("fk_City");
            });

            modelBuilder.Entity<NetBankingUserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_userId");

                entity.Property(e => e.TransactionPass)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.NetBankingUserDetails)
                    .HasForeignKey(d => d.AccountNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccountNumber");
            });

            modelBuilder.Entity<OccupationType>(entity =>
            {
                entity.HasKey(e => e.Otype)
                    .HasName("pk_Otype");

                entity.ToTable("OccupationType");

                entity.Property(e => e.Otype)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SourceOfIncome>(entity =>
            {
                entity.HasKey(e => e.SourceType)
                    .HasName("pk_SourceType");

                entity.ToTable("SourceOfIncome");

                entity.Property(e => e.SourceType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserOpenAccount>(entity =>
            {
                entity.HasKey(e => e.AadharCardNumber)
                    .HasName("pk_AadharCardNumber");

                entity.ToTable("UserOpenAccount");

                entity.Property(e => e.AadharCardNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.FathersName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAnnualIncome)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OccupationType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialAddrLine1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialAddrLine2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialLandmark)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialPincode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SourceOfIncome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.GrossAnnualIncomeNavigation)
                    .WithMany(p => p.UserOpenAccounts)
                    .HasForeignKey(d => d.GrossAnnualIncome)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_GrossAnnualIncome");

                entity.HasOne(d => d.OccupationTypeNavigation)
                    .WithMany(p => p.UserOpenAccounts)
                    .HasForeignKey(d => d.OccupationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OccupationType");

                entity.HasOne(d => d.ResidentialPincodeNavigation)
                    .WithMany(p => p.UserOpenAccounts)
                    .HasForeignKey(d => d.ResidentialPincode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rpincode");

                entity.HasOne(d => d.SourceOfIncomeNavigation)
                    .WithMany(p => p.UserOpenAccounts)
                    .HasForeignKey(d => d.SourceOfIncome)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SourceOfIncome");
            });

            modelBuilder.Entity<UserTransaction>(entity =>
            {
                entity.HasKey(e => new { e.TransactionId, e.AccountNumber })
                    .HasName("pk_UserTransaction");

                entity.ToTable("UserTransaction");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TransactionID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.UserTransactions)
                    .HasForeignKey(d => d.AccountNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TransactionAccNo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
