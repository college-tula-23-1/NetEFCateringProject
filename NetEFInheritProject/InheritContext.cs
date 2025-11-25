using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetEFInheritProject
{
    public class InheritContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=WS-TC-1-3-00;Initial Catalog=hr_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>()
                        //.UseTphMappingStrategy();
                        //.UseTptMappingStrategy();
                        .UseTpcMappingStrategy();
        }
    }
}
