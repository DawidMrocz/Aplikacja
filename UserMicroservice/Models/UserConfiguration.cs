using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using UserMicroservice.Entities;

namespace UserMicroservice.Models
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(r => r.Name).IsRequired().HasMaxLength(10);
            builder.Property(r => r.Role).HasDefaultValue("User");
        }
    }
}