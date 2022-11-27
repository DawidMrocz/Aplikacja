using InboxMicroservice.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace InboxMicroservice.Models
{
    public class InboxDbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public InboxDbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Inbox>().HasData(
                new Inbox
                {
                    Id = 1,
                    UserId = 1,
                    Name = "bartszap",
                    Photo = "PHtoto",
                },
                new Inbox
                {
                    Id = 2,
                    UserId = 2,
                    Name = "bartszap",
                    Photo = "PHtoto",
                },
                new Inbox
                {
                    Id = 3,
                    UserId = 3,
                    Name = "bartszap",
                    Photo = "PHtoto",
                }
            );
            modelBuilder.Entity<InboxItem>().HasData(
                new InboxItem
                {
                    Id = 1,
                    JobDescription = "Create drawing",
                    JobId=1,
                    System = "Catia",
                    Link = "linkt o Job",
                    Engineer = "Agata",
                    Ecm = 4561976,
                    Hours = 0,
                    Gpdm = 1,
                    ProjectNumber = "LASDl",
                    Client = "TOYOTA",
                    SapText = "sap text",
                    Status = "2D/3D",
                    Components = 0,
                    DrawingsComponents = 0,
                    DrawingsAssembly = 0,
                    InboxId=1
                },
                new InboxItem
                {
                    Id = 2,
                    JobDescription = "Create drawing",
                    JobId = 2,
                    Type = "2D",
                    System = "Catia",
                    Link = "linkt o Job",
                    Engineer = "Agata",
                    Ecm = 4561976,
                    Hours = 0,
                    Gpdm = 1,
                    ProjectNumber = "LASDl",
                    Client = "TOYOTA",
                    SapText = "sap text",
                    Status = "2D/3D",
                    Components = 0,
                    DrawingsComponents = 0,
                    DrawingsAssembly = 0,
                    InboxId = 2
                },
                new InboxItem
                {
                    Id = 3,
                    JobDescription = "Create drawing",
                    JobId = 3,
                    Type = "2D",
                    System = "Catia",
                    Link = "linkt o Job",
                    Engineer = "Agata",
                    Ecm = 4561976,
                    Hours = 0,
                    Gpdm = 1,
                    ProjectNumber = "LASDl",
                    Client = "TOYOTA",
                    SapText = "sap text",
                    Status = "2D/3D",
                    Components = 0,
                    DrawingsComponents = 0,
                    DrawingsAssembly = 0,
                    InboxId = 1
                }
            );
        }
    }
}
