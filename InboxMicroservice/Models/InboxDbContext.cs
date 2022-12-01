using InboxMicroservice.Entities;
using Microsoft.EntityFrameworkCore;

namespace InboxMicroservice.Models
{
    public class InboxDbContext : DbContext
    {
        public DbSet<Inbox> Inboxs { get; set; }
        public DbSet<InboxItem> InboxItems { get; set; }

        public InboxDbContext(DbContextOptions<InboxDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InboxConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InboxItemConfiguration).Assembly);
           // new InboxDbInitializer(modelBuilder).Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableDetailedErrors();
        }
    }
}
