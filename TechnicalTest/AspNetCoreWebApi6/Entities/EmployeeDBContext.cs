using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Principal;

namespace AspNetCoreWebApi6.Entities
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>()
              .HasIndex(employee => employee.Code)
            .IsUnique();

            builder.Seed();
        }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; } = null!;
    }
}
