using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RecuroApi.Core.Entities;

namespace RecuroApi.Core.DBContext;

public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<EligibleEmployee> EligibleEmployees { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<EmployeeBonuse> EmployeeBonuses { get; set; }

    public DbSet<ManagerApproval> ManagerApprovals { get; set; }

    public DbSet<ProductDetail> ProductDetails { get; set; }

    public DbSet<Sale> Sales { get; set; }

    public DbSet<SalesDetail> SalesDetails { get; set; }

    public DbSet<TopEmployeeOfYear> TopEmployeeOfYears { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EligibleEmployee>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EmployeeId }).HasName("PK__Eligible__D31064AAA3AAD80C");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.BonusAmount).HasColumnType("money");
            entity.Property(e => e.DepartmentSales).HasColumnType("money");
            entity.Property(e => e.EmployeeSales).HasColumnType("money");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF17A2A26BA");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
        });

        modelBuilder.Entity<EmployeeBonuse>(entity =>
        {
            entity.HasKey(e => e.BonusId).HasName("PK__Employee__8E554708C490B1D6");

            entity.Property(e => e.BonusId).HasColumnName("BonusID");
            entity.Property(e => e.BonusAmount).HasColumnType("money");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeBonuses)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployeeB__Emplo__403A8C7D");
        });

        modelBuilder.Entity<ManagerApproval>(entity =>
        {
            entity.HasKey(e => e.ApprovalId).HasName("PK__ManagerA__328477D43A1E3FA2");

            entity.Property(e => e.ApprovalId).HasColumnName("ApprovalID");
            entity.Property(e => e.ApprovalStatus).HasMaxLength(20);
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

            entity.HasOne(d => d.Manager).WithMany(p => p.ManagerApprovals)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ManagerAp__Manag__3C69FB99");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__ProductD__B40CC6ED8DAC155F");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(100);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales__1EE3C41F4D4EC4CF");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.SaleAmount).HasColumnType("money");
            entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

            entity.HasOne(d => d.SalesPerson).WithMany(p => p.Sales)
                .HasForeignKey(d => d.SalesPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sales__SalesPers__398D8EEE");
        });

        modelBuilder.Entity<SalesDetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__SalesDet__135C314D44E77813");

            entity.Property(e => e.DetailId).HasColumnName("DetailID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.SalesId).HasColumnName("SalesID");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales");
        });

        modelBuilder.Entity<TopEmployeeOfYear>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EmployeeId }).HasName("PK__TopEmplo__D31064AA19C2F747");

            entity.ToTable("TopEmployeeOfYear");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeSales).HasColumnType("money");
        });

        base.OnModelCreating(modelBuilder);
    }

}
