using Microsoft.EntityFrameworkCore;
using RaportsMicroservice.Entities;

namespace RaportMicroservice.Models
{
    public class RaportDbContext : DbContext
    {
        public DbSet<Raport> Raports { get; set; }
        public DbSet<UserRaport> UserRaports { get; set; }
        public DbSet<UserRaportRecord> UserRaportRecords { get; set; }

        public RaportDbContext(DbContextOptions<RaportDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(RaportConfiguration).Assembly);
            new RaportDbInitializer(modelBuilder).Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableDetailedErrors();
        }
    }
}