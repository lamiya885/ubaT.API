using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ubaT.Entities;

namespace ubaT.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.HasIndex(x => x.Name)
                 .IsUnique();
            builder.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.Icon)
            .HasMaxLength(128);
            builder.HasMany(x => x.Games)
            .WithOne(x => x.Language)
            .HasForeignKey(x => x.LangCode);
            builder.HasMany(x => x.Words)
            .WithOne(x => x.Language)
            .HasForeignKey(x => x.LangCode);
            builder.HasData(new Language
            {
                Code = "az",
                Name = "Azərbaycan",
                Icon = "https://www.google.com/imgres?q=azerbaijan%20flag%20icon&imgurl=https%3A%2F%2Fupload.wmA"
            });
        }
    }
}
