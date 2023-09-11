using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi6.Entities
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 502030, Name = "Mehedi Hasan", Code = "EMP320", Salary = 50000, SuperVisorId = 502036 },
                new Employee { Id = 502031, Name = "Ashikur Rahman", Code = "EMP321", Salary = 45000, SuperVisorId = 502036 },
                new Employee { Id = 502032, Name = "Rakibul Islam", Code = "EMP322", Salary = 52000, SuperVisorId = 502030 },
                new Employee { Id = 502033, Name = "Hasan Abdullah", Code = "EMP323", Salary = 46000, SuperVisorId = 502031 },
                new Employee { Id = 502034, Name = "Akib Khan", Code = "EMP324", Salary = 66000, SuperVisorId = 502032 },
                new Employee { Id = 502035, Name = "Rasel Shikder", Code = "EMP325", Salary = 53500, SuperVisorId = 502033 },
                new Employee { Id = 502036, Name = "Selim Reja", Code = "EMP326", Salary = 59000, SuperVisorId = 502035 }
            );

        }
    }
}
