using FileApload_FluentValidation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileApload_FluentValidation.Helpers.EntityConfiguration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.Property(m => m.FullName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Field).IsRequired();
            builder.Property(m => m.Email).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Phone).IsRequired();
            builder.Property(m => m.Address).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Image).IsRequired();
        }
    }
}
