using System;
using System.Collections.Generic;
using DEApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DEApp.Data;

public partial class DeappContext : DbContext
{
    public DeappContext()
    {
    }

    public DeappContext(DbContextOptions<DeappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<ProfileSetting> ProfileSettings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DevConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("PK__Applican__39AE9148DCA54378");

            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.Applicant1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Applicant");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.HouseNo).HasMaxLength(50);
            entity.Property(e => e.Landmark).HasMaxLength(100);
            entity.Property(e => e.MaritalStatus).HasMaxLength(50);
            entity.Property(e => e.OccupationType).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Applicant__Vendo__3B75D760");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD437BD68E4C2");

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.ApplicantDate).HasColumnType("datetime");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoanDescription).HasMaxLength(255);
            entity.Property(e => e.LoanType).HasMaxLength(100);
            entity.Property(e => e.MaxLoanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MonthlyPayment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Loans)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK__Loans__Applicant__3E52440B");
        });

        modelBuilder.Entity<ProfileSetting>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__ProfileS__1788CC4C5E214654");

            entity.ToTable("ProfileSetting");

            entity.HasIndex(e => e.Username, "UQ__ProfileS__536C85E4A3DAE6C1").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasMaxLength(15);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.ProfileSettings)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProfileSe__RoleI__4D94879B");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A91DE69CB");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B616043D374B4").IsUnique();

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C52717147");

            entity.ToTable("User");

            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__FC8618D3294AD913");

            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Make)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
