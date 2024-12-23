using Microsoft.EntityFrameworkCore;
using ubaT.Entities;

namespace ubaT.DAL
{
    public class ubaTDbContext:DbContext
    {
        public ubaTDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(l =>
            {
                l.HasKey(x => x.Code);
                l.HasIndex(x=>x.Name)
                     .IsUnique();
                l.Property(x => x.Code)
                    .IsFixedLength(true)
                    .HasMaxLength(2);
                l.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(32);
                l.Property(x => x.Icon)
                .HasMaxLength(128);
                l.HasMany(x => x.Games)
                .WithOne(x => x.Language)
                .HasForeignKey(x=>x.LangCode);
                l.HasMany(x => x.Words)
                .WithOne(x=>x.Language)
                .HasForeignKey(x=>x.LangCode);
                l.HasData(new Language
                { 
                Code="az",
                Name="Azərbaycan",
                Icon= "https://www.google.com/imgres?q=azerbaijan%20flag%20icon&imgurl=https%3A%2F%2Fupload.wmA"
                });


            });
            modelBuilder.Entity<Word>(w =>
            {
                w.HasKey(x => x.Id);
                w.Property(x=>x.Text)
                    .IsRequired()
                    .HasMaxLength(32);
                w.Property(x=>x.LangCode)
                    .IsRequired()
                    .HasMaxLength(2);
                w.HasOne(x => x.Language)
                    .WithMany(x => x.Words)
                    .HasForeignKey(x=>x.LangCode);
                w.HasMany(x => x.BannedWords)
                     .WithOne(x => x.Word)
                     .HasForeignKey(x=>x.WordId);


            });
            modelBuilder.Entity<Game>(g=>
            {
                g.HasKey(x => x.Id);
                g.Property(x => x.BannedWordCount)
                      .IsRequired();
                g.Property(x=>x.FailCount)
                      .IsRequired();
                g.Property(x=>x.SkipCount)
                     .IsRequired();
                g.Property(x => x.Time)
                    .HasDefaultValue(3000);
                g.Property(x => x.Score)
                    .HasDefaultValue(0);
                g.Property(x => x.SuccessAnswer)
                    .HasDefaultValue(0);
                g.Property(x=>x.WrongAnswer)
                    .HasDefaultValue(0);
                g.HasOne(x => x.Language)
                        .WithMany(x => x.Games)
                        .HasForeignKey(x=>x.LangCode);
            });
            modelBuilder.Entity<BannedWord>(bw =>
            {
                bw.HasKey(x => x.Id);
                bw.Property(x => x.Text)
                       .IsRequired()
                       .HasMaxLength(32);
                bw.HasOne(x => x.Word)
                      .WithMany(x => x.BannedWords)
                      .HasForeignKey(x=>x.WordId);

            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
