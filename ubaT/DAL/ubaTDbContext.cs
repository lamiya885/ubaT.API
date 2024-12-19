using Microsoft.EntityFrameworkCore;
using ubaT.Entities;

namespace ubaT.DAL
{
    public class ubaTDbContext:DbContext
    {
        public ubaTDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Languages> Languages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Languages>(b =>
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
                b.HasData(new Languages
                { 
                Code="az",
                Name="Azərbaycan",
                Icon= "https://www.google.com/imgres?q=azerbaijan%20flag%20icon&imgurl=https%3A%2F%2Fupload.wikimedia.org%2Fwikipedia%2Fcommons%2Fthumb%2Fd%2Fdd%2FFlag_of_Azerbaijan.svg%2F2560px-Flag_of_Azerbaijan.svg.png&imgrefurl=https%3A%2F%2Fcommons.wikimedia.org%2Fwiki%2FFile%3AFlag_of_Azerbaijan.svg&docid=dZHPPz4KwbBEFM&tbnid=pIwSa7wZoqWpWM&vet=12ahUKEwi80rqCjLSKAxVXywIHHY27JkYQM3oECB0QAA..i&w=2560&h=1280&hcb=2&ved=2ahUKEwi80rqCjLSKAxVXywIHHY27JkYQM3oECB0QAA"
                });


            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
