using Microsoft.EntityFrameworkCore;
using UserMicroservice.Entities;

namespace UserMicroservice.Models
{
    public class UserDbInitializer
    {
        private readonly ModelBuilder modelBuilder;
        public UserDbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Dawid",
                    PasswordHash = "zxcasdqwe",
                    Email = "dawid@tlen.pl",
                    CCtr = "RS8531",
                    ActTyp = "L8531",
                    Role = "Admin",
                    Photo = "zdjecie"
                },
                new User
                {
                    UserId = 2,
                    Name = "Agata",
                    PasswordHash = "zxcasdqwe",
                    Email = "agata@tlen.pl",
                    CCtr = "RS8531",
                    ActTyp = "L8531",
                    Role = "Manager",
                    Photo = "zdjecie"
                },
                new User
                {
                    UserId = 3,
                    Name = "Bartek",
                    PasswordHash = "zxcasdqwe",
                    Email = "bartek@tlen.pl",
                    CCtr = "RS8531",
                    ActTyp = "L8531",
                    Role = "User",
                    Photo = "zdjecie"
                }
            );
        }
    }
}