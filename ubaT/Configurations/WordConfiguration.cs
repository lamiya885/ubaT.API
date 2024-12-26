using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using ubaT.Entities;

namespace ubaT.Configrations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.LangCode)
                .IsRequired()
                .HasMaxLength(2);
            builder.HasOne(x => x.Language)
                .WithMany(x => x.Words)
                .HasForeignKey(x => x.LangCode);
            builder.HasMany(x => x.BannedWords)
                 .WithOne(x => x.Word)
                 .HasForeignKey(x => x.WordId);

            builder.Property(x => x.Text)
                    .IsRequired()
                    .HasMaxLength(32);

            builder.HasOne(x => x.Language)
                .WithMany(x => x.Words)
                .HasForeignKey(x => x.LangCode);

            builder.HasMany(x => x.BannedWords)
                    .WithOne(x => x.Word)
                    .HasForeignKey(x => x.WordId);
        }


    }

}

