using CatsGrpcMicroservice.Entities;
using Microsoft.EntityFrameworkCore;


namespace CatsGrpcMicroservice.Models
{
    public class CatsDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<CatRecord> CatRecords { get; set; }
        public DbSet<CatRecordHours> CatRecordHourss { get; set; }

        public CatsDbContext(DbContextOptions<CatsDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //new CatsDbInitializer(modelBuilder).Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableDetailedErrors();
        }
    }
}