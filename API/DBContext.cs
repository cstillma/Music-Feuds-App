using API;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // Define your entity DbSet properties here
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feud> Feuds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity models here
            modelBuilder.Entity<Song>().HasKey(s => s.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Feud>().HasKey(f => f.Id);
        }
    }
}
