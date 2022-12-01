using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JobMicroservice.Entities
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.Property(r => r.JobDescription).IsRequired().HasMaxLength(30);
            builder.Property(r => r.System).IsRequired();
            builder.Property(r => r.Client).IsRequired();
            builder.Property(r => r.ProjectName).IsRequired();
            builder.Property(r => r.ProjectNumber).IsRequired();
            builder.Property(r => r.Gpdm).IsRequired();
            builder.Property(r => r.Engineer).IsRequired();
            builder.Property(r => r.Link).IsRequired();
            builder.Property(r => r.Ecm).IsRequired();
            //builder.Property(r => r.Received).HasDefaultValueSql("getdate()");
        }
    }
}
