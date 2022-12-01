using CatsApiMicroservice.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatsApiMicroservice.Models
{
    public class UserCatsDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatRecord> CatRecords { get; set; }
        public DbSet<CatRecordHours> CatRecordHourss { get; set; }

        public UserCatsDbContext(DbContextOptions<UserCatsDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new CatDbInitializer(modelBuilder).Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableDetailedErrors();
        }
    }
}