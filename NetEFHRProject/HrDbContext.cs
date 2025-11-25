using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetEFHRProject;

public partial class HrDbContext : DbContext
{
    public HrDbContext()
    {
    }

    public HrDbContext(DbContextOptions<HrDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeProfile> EmployeeProfiles { get; set; }

    public virtual DbSet<EmployeesProject> EmployeesProjects { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=WS-TC-1-3-00;Initial Catalog=hr_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasIndex(e => e.CountryId, "IX_Companies_CountryId");

            entity.HasOne(d => d.Country).WithMany(p => p.Companies).HasForeignKey(d => d.CountryId);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasIndex(e => e.CapitalId, "IX_Countries_CapitalId");

            entity.HasOne(d => d.Capital).WithMany(p => p.Countries).HasForeignKey(d => d.CapitalId);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasIndex(e => e.CompanyId, "IX_Employees_CompanyId");

            entity.HasIndex(e => e.PositionId, "IX_Employees_PositionId");

            entity.HasOne(d => d.Company).WithMany(p => p.Employees).HasForeignKey(d => d.CompanyId);

            entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasForeignKey(d => d.PositionId);
        });

        modelBuilder.Entity<EmployeeProfile>(entity =>
        {
            entity.ToTable("EmployeeProfile");

            entity.HasIndex(e => e.EmployeeId, "IX_EmployeeProfile_EmployeeId").IsUnique();

            entity.HasOne(d => d.Employee).WithOne(p => p.EmployeeProfile).HasForeignKey<EmployeeProfile>(d => d.EmployeeId);
        });

        modelBuilder.Entity<EmployeesProject>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.ProjectId });

            entity.HasIndex(e => e.ProjectId, "IX_EmployeesProjects_ProjectId");

            entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeesProjects).HasForeignKey(d => d.EmployeeId);

            entity.HasOne(d => d.Project).WithMany(p => p.EmployeesProjects).HasForeignKey(d => d.ProjectId);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
