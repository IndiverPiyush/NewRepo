using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MedicineSearchWebApp.Models
{
    public partial class MedicineSearchContext : DbContext
    {
        public MedicineSearchContext()
        {
        }

        public MedicineSearchContext(DbContextOptions<MedicineSearchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Medecine> Medecines { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=10.3.117.14; Database=MedicineSearch_IP; Integrated Security=True");


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminUser);

                entity.ToTable("ADMIN");

                entity.Property(e => e.AdminUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_USER");

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_NAME");

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_PASSWORD");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_USER");

                entity.ToTable("CUSTOMER");

                entity.HasIndex(e => e.UserMobile, "IX_USER")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.AllergicTo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ALLERGIC_TO")
                    .HasDefaultValueSql("('NONE')");

                entity.Property(e => e.UserArea)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_AREA");

                entity.Property(e => e.UserCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_CITY");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_EMAIL");

                entity.Property(e => e.UserMobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_MOBILE");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_NAME");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USER_PASSWORD");

                entity.Property(e => e.UserWalletbal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("USER_WALLETBAL");
            });

            modelBuilder.Entity<Medecine>(entity =>
            {
                entity.HasKey(e => e.MedicineId);

                entity.ToTable("MEDECINE");

                entity.Property(e => e.MedicineId).HasColumnName("MEDICINE_ID");

                entity.Property(e => e.MedicineCategory)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_CATEGORY");

                entity.Property(e => e.MedicineDosage).HasColumnName("MEDICINE_DOSAGE");

                entity.Property(e => e.MedicineEdate)
                    .HasColumnType("date")
                    .HasColumnName("MEDICINE_EDATE");

                entity.Property(e => e.MedicineMdate)
                    .HasColumnType("date")
                    .HasColumnName("MEDICINE_MDATE");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEDICINE_NAME");

                entity.Property(e => e.MedicinePrice)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("MEDICINE_PRICE");

                entity.Property(e => e.MedicineStock)
                    .HasColumnName("MEDICINE_STOCK")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.ProviderId).HasColumnName("PROVIDER_ID");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Medecines)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDECINE_VENDOR");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("VENDOR");

                entity.HasIndex(e => e.VendorMobile, "IX_VENDOR")
                    .IsUnique();

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorArea)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_AREA");

                entity.Property(e => e.VendorCity)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_CITY");

                entity.Property(e => e.VendorMobile)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_MOBILE");

                entity.Property(e => e.VendorOrgName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_ORG_NAME");

                entity.Property(e => e.VendorPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_PASSWORD");

                entity.Property(e => e.VendorSpeciality)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VENDOR_SPECIALITY");

                entity.Property(e => e.VendorWallet)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("VENDOR_WALLET");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
