using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Entities;

namespace TestApp.Models
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        private const string connectionString = @"Server=localhost\SQLEXPRESS; Database=TestAppDataBase; Trusted_Connection=true; TrustServerCertificate=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasOne(u => u.User)
                .WithOne(up => up.UserProfile)
                .HasForeignKey<UserProfile>
                (u => u.UserId);
        }
    }
}
