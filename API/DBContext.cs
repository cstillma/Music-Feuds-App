using API;
using Microsoft.EntityFrameworkCore; // Importing Entity Framework Core for database operations

namespace API
{
    // Defining the DbContext class for the application with inheritance from DbContext
    public class MyDbContext : DbContext
    {
        // Constructor that accepts DbContextOptions and passes them to the base DbContext class
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for each entity type you want to include in the model
        public DbSet<Song> Songs { get; set; } // Represents the collection of Song entities in the context
        public DbSet<User> Users { get; set; } // Represents the collection of User entities in the context
        public DbSet<Feud> Feuds { get; set; } // Represents the collection of Feud entities in the context

        // Override the OnModelCreating method to configure the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity models here
            modelBuilder.Entity<Song>().HasKey(s => s.Id); // Configure the primary key for the Song entity
            modelBuilder.Entity<User>().HasKey(u => u.Id); // Configure the primary key for the User entity
            modelBuilder.Entity<Feud>().HasKey(f => f.Id); // Configure the primary key for the Feud entity
        }
    }
}
