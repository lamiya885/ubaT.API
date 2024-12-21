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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(b =>
            {
                b.HasKey(x => x.Code);
                b.HasIndex(x=>x.Name)
                .IsUnique();
                b.Property(x => x.Code)
                .IsFixedLength(true)
                .HasMaxLength(2);
                b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
                b.Property(x => x.Icon)
                .HasMaxLength(128);
                b.HasData(new Language
                { 
                Code="az",
                Name="Azərbaycan",
                Icon= "https://www.google.com/imgres?q=azerbaijan%20flag%20icon&imgurl=https%3A%2F%2Fupload.wmA"
                });


            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
