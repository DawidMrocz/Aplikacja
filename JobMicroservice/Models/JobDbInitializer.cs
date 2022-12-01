using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using JobMicroservice.Entities;

namespace JobMicroservice.Models
{
    public class JobDbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public JobDbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<Job>().HasData(
                new Job()
                {
                    JobId = 1,
                    JobDescription="Create drawing",
                    Type="2D",
                    System="Catia",
                    Link="linkt o task",
                    Engineer="Agata",
                    Ecm=4561976,
                    Gpdm=1,
                    ProjectNumber="LASDl",
                    Client="TOYOTA",
                    ProjectName="sap text",
                    Status="2D",
                    Received="15.22.2022",
                    
                },
                new Job()
                {
                    JobId = 2,
                    JobDescription = "Create drawing",
                    Type = "2D",
                    System = "Catia",
                    Link = "linkt o task",
                    Engineer = "Agata",
                    Ecm = 4561976,
                    Gpdm = 1,
                    ProjectNumber = "LASDl",
                    Client = "TOYOTA",
                    ProjectName = "sap text",
                    Status = "2D",
                    Received="20.11.2022",
                    DueDate="25.11.2022"
                },
                new Job()
                {
                    JobId = 3,
                    JobDescription = "Create drawing",
                    Type = "2D",
                    System = "Catia",
                    Link = "linkt o task",
                    Engineer = "Agata",
                    Ecm = 4561976,
                    Gpdm = 1,
                    ProjectNumber = "LASDl",
                    Client = "TOYOTA",
                    ProjectName = "sap text",
                    Status = "2D",
                    Received = "20.11.2022",
                }
            );
        }
    }
}
