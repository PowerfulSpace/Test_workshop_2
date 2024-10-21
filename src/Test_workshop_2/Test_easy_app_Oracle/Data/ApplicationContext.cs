﻿using Microsoft.EntityFrameworkCore;
using Test_easy_app_Oracle.Models;

namespace Test_easy_app_Oracle.Data
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
            string connectionString = "User Id=SYSTEM;Password=easypassword;Data Source=localhost:1521/XE"; // Укажите правильные значения
            optionsBuilder.UseOracle(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses);
        }
    }
}
