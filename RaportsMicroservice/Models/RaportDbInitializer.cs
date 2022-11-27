using Microsoft.EntityFrameworkCore;
using RaportsMicroservice.Entities;

namespace RaportMicroservice.Models
{
    public class RaportDbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public RaportDbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Raport>().HasData(
                new Raport
                {
                    RaportId = 1,
                    TotalHours = 0
                },
                new Raport
                {
                    RaportId = 2,
                    TotalHours = 0
                },
                new Raport
                {
                    RaportId = 3,
                    TotalHours = 0
                }
            );
        }
    }
}