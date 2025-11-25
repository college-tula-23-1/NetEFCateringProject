using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFReferencesProject
{
    public class ProjectContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=WS-TC-1-3-00;Initial Catalog=hr_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Company)
                        .WithMany(c => c.Employees)
                        .HasForeignKey(e => e.CompanyId)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Position)
                        .WithMany(p => p.Employees);


            modelBuilder.Entity<EmployeeProfile>()
                        .HasOne(ep => ep.Employee)
                        .WithOne(e => e.EmployeeProfile)
                        .HasForeignKey<EmployeeProfile>(ep => ep.EmployeeId)
                        .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Employee>()
            //            .HasOne(e => e.EmployeeProfile)
            //            .WithOne(ep => ep.Employee)
            //            .HasForeignKey<EmployeeProfile>(ep => ep.Id);

            //modelBuilder.Entity<EmployeeProfile>().ToTable("Employees");
            //modelBuilder.Entity<Employee>().ToTable("Employees");

            //modelBuilder.Entity<Employee>()
            //            .HasMany(e => e.Projects)
            //            .WithMany(p => p.Employees)
            //            .UsingEntity(ep => ep.ToTable("EmployeesProjects"));

            modelBuilder.Entity<Employee>()
                        .HasMany(e => e.Projects)
                        .WithMany(p => p.Employees)
                        .UsingEntity<EmployeeProject>(
                        t => t.HasOne(ep => ep.Project)
                              .WithMany(p => p.ProjectEmployees)
                              .HasForeignKey(ep => ep.ProjectId),
                        t => t.HasOne(ep => ep.Employee)
                              .WithMany(e => e.EmployeeProjects)
                              .HasForeignKey(ep => ep.EmployeeId),
                        t =>
                        {
                            t.Property(ep => ep.StartDate)
                             .HasDefaultValueSql("GETDATE()");
                            t.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });
                            t.ToTable("EmployeesProjects");
                        });

        }
    }
}
