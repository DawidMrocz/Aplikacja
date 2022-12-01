using CatsGrpcMicroservice.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatsGrpcMicroservice.Models
{
    public class CatsDbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public CatsDbInitializer(ModelBuilder modelBuilder)
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
                    ActTyp = "sdfsdf",
                    CCtr = "sdfsdf"
    },
                new Employee
                {
                    EmployeeId = 2,
                    Name = "Dawid2",
                    UserId = 2,
                    ActTyp = "sdfsdf",
                    CCtr = "sdfsdf"
                }
            );
        }
    }
}