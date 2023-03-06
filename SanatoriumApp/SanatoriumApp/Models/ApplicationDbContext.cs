using Microsoft.EntityFrameworkCore;
using SanatoriumApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanatoriumApp.Models
{
    internal class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        private const string connectionString = @"Server=localhost\SQLEXPRESS; Database=OLIMP_XX; Trusted_Connection=true;";
        //private const string connectionString = @"Server=DESKTOP-I8L1GP6; Database=OLIMP_XX; Trusted_Connection=true;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Client> Clients { get; set; } = null!;
        //public DbSet<CostPerDay> CostsPerDays { get; set; } = null!;
        //public DbSet<SanatoriumProgram> SanatoriumPrograms { get; set; } = null!;
        //public DbSet<SanatoriumRoom> SanatoriumRooms { get; set;} = null!;
        //public DbSet<SanatoriumRoomCategory> SanatoriumRoomCategories { get; set; } = null!;
        //public DbSet<Treaty> Treaties { get; set; } = null!;
        public DbSet<User> Users { get;set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(c => c.Client)
                .WithOne(u => u.User)
                .HasForeignKey<User>
                (u => u.ClientId);

            modelBuilder.Entity<Role>()
                .HasMany(u=>u.Users)
                .WithOne(r=>r.Role)
                .HasForeignKey(r => r.RoleId);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}
