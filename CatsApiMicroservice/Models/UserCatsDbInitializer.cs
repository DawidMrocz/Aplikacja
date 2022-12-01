using CatsApiMicroservice.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatsApiMicroservice.Models
{
    public class CatDbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public CatDbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    Name = "Dawid",
                    UserId=1,
    },
                new Employee
                {
                    EmployeeId = 2,
                    Name = "Dawid",
                    UserId = 2,
                },
                new Employee
                {
                    EmployeeId = 3,
                    Name = "Dawid",
                    UserId = 3,
                }
            );
        }
    }
}