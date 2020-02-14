using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayCompute.Entity;

namespace PayCompute.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { set; get; }
        public DbSet<PayRoll> PayRolls { set; get; }
        public DbSet<Relative> Relatives { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<PositionJob> PositionJobs { set; get; }
        public DbSet<Location> Locations { set; get; }
        public DbSet<LocationEmployee> LocationEmployees { set; get; }
        public DbSet<TaxYear> TaxYears { set; get; }
        public DbSet<TimekeepingEMP> TimekeepingEMPs { set; get; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<LocationEmployee>()
        //        .HasKey(c => new { c.EmployeeId, c.LocationId });
        //}
    }
}
