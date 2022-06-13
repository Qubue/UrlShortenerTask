using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Entities;

namespace UrlShortener.Data
{
    public class DomainDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Url>()
                .HasKey(u => u.Id);
        }

        public DbSet<Url> Urls { get; set; }
    }
}