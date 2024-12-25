using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ubaT.Entities;

namespace ubaT.Configurations
{
    public class GameContiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BannedWordCount)
                  .IsRequired();
            builder.Property(x => x.FailCount)
                  .IsRequired();
            builder.Property(x => x.SkipCount)
                 .IsRequired();
            builder.Property(x => x.Time)
                .HasDefaultValue(3000);
            builder.Property(x => x.Score)
                .HasDefaultValue(0);
            builder.Property(x => x.SuccessAnswer)
                .HasDefaultValue(0);
            builder.Property(x => x.WrongAnswer)
                .HasDefaultValue(0);
            builder.HasOne(x => x.Language)
                    .WithMany(x => x.Games)
                    .HasForeignKey(x => x.LangCode);
        }
    }
}
