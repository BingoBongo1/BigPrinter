using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BigPrinter.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabinet> Cabinets { get; set; } = null!;
        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<ClaimType> ClaimTypes { get; set; } = null!;
        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=SERVERPC;database=TestDb;user=sa;password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cabinet1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cabinet");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("Claim");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idcabinet).HasColumnName("IDCabinet");

                entity.Property(e => e.IdclaimDevices).HasColumnName("IDClaimDevices");

                entity.Property(e => e.IdclaimType).HasColumnName("IDClaimType");

                entity.Property(e => e.NameOfMatherial)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcabinetNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.Idcabinet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Claim_Cabinets");

                entity.HasOne(d => d.IdclaimDevicesNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.IdclaimDevices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Claim_Devices");

                entity.HasOne(d => d.IdclaimTypeNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.IdclaimType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Claim_ClaimType");
            });

            modelBuilder.Entity<ClaimType>(entity =>
            {
                entity.ToTable("ClaimType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdtypeName).HasColumnName("IDTypeName");

                entity.Property(e => e.ModelDevice)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NameDevice)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtypeNameNavigation)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.IdtypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Devices_Type");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
