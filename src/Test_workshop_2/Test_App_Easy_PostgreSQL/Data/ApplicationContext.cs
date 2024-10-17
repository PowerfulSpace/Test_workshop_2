using Microsoft.EntityFrameworkCore;
using Test_App_Easy_PostgreSQL.Models;

namespace Test_App_Easy_PostgreSQL.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost;Database=Test_App_Easy_PostgreSQL_DB;Username=postgres;Password=easypassword;"; // Укажите правильные значения
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses);
        }
    }
}
