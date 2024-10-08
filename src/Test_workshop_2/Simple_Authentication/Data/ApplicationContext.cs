using Microsoft.EntityFrameworkCore;
using Simple_Authentication.Models;

namespace Simple_Authentication.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            // При первом запуске создадим базу данных
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-F9SMEKT;Database=Test_Simple_Authentication_DB;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
