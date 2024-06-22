using FileApload_FluentValidation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FileApload_FluentValidation.Helpers.EntityConfiguration
{
    public class InformationConfiguration : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.Property(m => m.Title).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Image).IsRequired();
        }
    }
}
