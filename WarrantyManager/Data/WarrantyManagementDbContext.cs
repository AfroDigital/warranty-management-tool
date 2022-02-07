using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WarrantyManager.Models;

#nullable disable

namespace WarrantyManager.Data
{
    public partial class WarrantyManagementDbContext : DbContext
    {
        public WarrantyManagementDbContext()
        {
        }

        public WarrantyManagementDbContext(DbContextOptions<WarrantyManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<Warranty> CustomerWarranties { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseSqlServer("Server=localhost;Database=WarrantyManagementDb;User Id=sa;Password=Ak@nji_1028;");
            }
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(NEWSEQUENTIALID())");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            bldr.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(NEWSEQUENTIALID())");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });


            bldr.Entity<Warranty>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.SerialNumber })
                    .HasName("PK__Customer_Product");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");


            });

            bldr.Entity<Distributor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("(NEWSEQUENTIALID())");
                entity.HasMany(e => e.Customers);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

          


            OnModelCreatingPartial(bldr);

        }

        partial void OnModelCreatingPartial(ModelBuilder bldr);
    }
}
