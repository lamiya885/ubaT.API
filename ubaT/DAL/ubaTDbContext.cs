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


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ubaTDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
