using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VICMAPI.Models
{
    public partial class VICMS_81258Context : DbContext
    {
        public VICMS_81258Context()
        {
        }

        public VICMS_81258Context(DbContextOptions<VICMS_81258Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<InsuranceCompanyDetails> InsuranceCompanyDetails { get; set; }
        public virtual DbSet<Policies> Policies { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }

        // Unable to generate entity type for table 'dbo.Login'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=10.3.117.39;Database=VICMS_81258;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasKey(e => e.ClaimId);

                entity.HasIndex(e => e.BankAccountNo)
                    .HasName("UQ__Claims__0177E2CD9BDB3C5E")
                    .IsUnique();

                entity.HasIndex(e => e.IfscCode)
                    .HasName("UQ__Claims__00EF9F3F1DE5DCBB")
                    .IsUnique();

                entity.Property(e => e.ClaimId).HasColumnName("Claim_Id");

                entity.Property(e => e.BankAccountNo)
                    .IsRequired()
                    .HasColumnName("Bank_Account_No")
                    .HasMaxLength(50);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasColumnName("Bank_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasColumnName("Branch_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ClaimAmount).HasColumnName("Claim_Amount");

                entity.Property(e => e.ClaimReason)
                    .IsRequired()
                    .HasColumnName("Claim_Reason")
                    .HasMaxLength(50);

                entity.Property(e => e.ClaimStatus)
                    .IsRequired()
                    .HasColumnName("Claim_Status")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.IfscCode)
                    .IsRequired()
                    .HasColumnName("IFSC_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.LicenceNo)
                    .IsRequired()
                    .HasColumnName("Licence_No")
                    .HasMaxLength(50);

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.SupportedDocuments)
                    .IsRequired()
                    .HasColumnName("Supported_Documents")
                   .HasMaxLength(50);

                entity.Property(e => e.VehicleCondition)
                    .IsRequired()
                    .HasColumnName("Vehicle_Condition")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Claims__Customer__628FA481");

                entity.HasOne(d => d.Policy)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__Claims__Policy_I__6383C8BA");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.HasIndex(e => e.CustomerContact)
                    .HasName("UQ__Customer__BB5D17846E74F157")
                    .IsUnique();

                entity.HasIndex(e => e.CustomerName)
                    .HasName("UQ__Customer__305BADDF73E5FCC4")
                    .IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasColumnName("Customer_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerAge).HasColumnName("Customer_Age");

                entity.Property(e => e.CustomerContact)
                    .IsRequired()
                    .HasColumnName("Customer_Contact")
                    .HasMaxLength(10);

                entity.Property(e => e.CustomerCountry)
                    .IsRequired()
                    .HasColumnName("Customer_Country")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasColumnName("Customer_Email")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("Customer_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerPassword)
                    .IsRequired()
                    .HasColumnName("Customer_Password")
                    .HasMaxLength(50);

                entity.Property(e => e.CustomerState)
                    .IsRequired()
                    .HasColumnName("Customer_State")
                    .HasMaxLength(50);

                entity.Property(e => e.LicenceNo)
                    .IsRequired()
                    .HasColumnName("Licence_No")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InsuranceCompanyDetails>(entity =>
            {
                entity.HasKey(e => e.ComapanyIdentificationNo);

                entity.ToTable("Insurance_Company_Details");

                entity.HasIndex(e => e.CompanyContact)
                    .HasName("UQ__Insuranc__0713D0CCC668CB09")
                    .IsUnique();

                entity.Property(e => e.ComapanyIdentificationNo).HasColumnName("Comapany_Identification_No");

                entity.Property(e => e.CompanyAddress)
                    .IsRequired()
                    .HasColumnName("Company_Address")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyContact)
                    .IsRequired()
                    .HasColumnName("Company_Contact")
                    .HasMaxLength(10);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("Company_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Policies>(entity =>
            {
                entity.HasKey(e => e.PolicyId);

                entity.Property(e => e.PolicyId).HasColumnName("Policy_Id");

                entity.Property(e => e.ComapanyIdentificationNo).HasColumnName("Comapany_Identification_No");

                entity.Property(e => e.InsurenceAmount).HasColumnName("Insurence_Amount");

                entity.Property(e => e.PolicyExpiryDate)
                    .HasColumnName("Policy_ExpiryDate")
                    .HasColumnType("date");

                entity.Property(e => e.PolicyStartDate)
                    .HasColumnName("Policy_StartDate")
                    .HasColumnType("date");

                entity.Property(e => e.PolicyType)
                    .IsRequired()
                    .HasColumnName("Policy_Type")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.Property(e => e.VehicleType)
                    .IsRequired()
                    .HasColumnName("Vehicle_Type")
                    .HasMaxLength(50);

                entity.HasOne(d => d.ComapanyIdentificationNoNavigation)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.ComapanyIdentificationNo)
                    .HasConstraintName("FK__Policies__Comapa__5812160E");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Policies)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK__Policies__Vehicl__571DF1D5");
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_Id");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_Id");

                entity.Property(e => e.VehicleModel)
                    .IsRequired()
                    .HasColumnName("Vehicle_Model")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleName)
                    .IsRequired()
                    .HasColumnName("Vehicle_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.VehicleNo).HasColumnName("Vehicle_No");

                entity.Property(e => e.VehiclePrice).HasColumnName("Vehicle_Price");

                entity.Property(e => e.VehiclePurchasedDate)
                    .HasColumnName("Vehicle_Purchased_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Vehicles__Custom__5441852A");
            });
        }
    }
}
