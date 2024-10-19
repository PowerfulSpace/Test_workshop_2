using Microsoft.EntityFrameworkCore;
using Test_app_SQLiete.Models;

namespace Test_app_SQLiete.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // Конструктор, который принимает DbContextOptions
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }
    }
}
