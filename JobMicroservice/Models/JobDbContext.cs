using JobMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using JobMicroservice.Entities;

namespace JobMicroservice.Models
{
    public class JobDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public JobDbContext(DbContextOptions<JobDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobConfiguration).Assembly);
            new JobDbInitializer(modelBuilder).Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableDetailedErrors();
        }
    }
}
