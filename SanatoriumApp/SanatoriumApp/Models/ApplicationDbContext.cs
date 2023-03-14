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
            //Database.EnsureDeleted();
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
        public DbSet<CostPerDay> CostsPerDays { get; set; } = null!;
        public DbSet<SanatoriumProgram> SanatoriumPrograms { get; set; } = null!;
        public DbSet<SanatoriumRoom> SanatoriumRooms { get; set; } = null!;
        public DbSet<SanatoriumRoomCategory> SanatoriumRoomCategories { get; set; } = null!;
        public DbSet<Treaty> Treaties { get; set; } = null!;
        public DbSet<User> Users { get;set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(u => u.Users)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<SanatoriumRoomCategory>()
                .HasMany(sr => sr.SanatoriumRooms)
                .WithOne(sc => sc.SanatoriumRoomCategory)
                .HasForeignKey(sr => sr.SanatoriumRoomCategoryId);

            modelBuilder.Entity<SanatoriumProgram>()
                .HasMany(cpd => cpd.CostPerDays)
                .WithOne(sp => sp.SanatoriumProgram)
                .HasForeignKey(cpd => cpd.SanatoriumProgramId);

            modelBuilder.Entity<SanatoriumRoom>()
                .HasMany(cpd => cpd.CostPerDays)
                .WithOne(sr => sr.SanatoriumRoom)
                .HasForeignKey(cpd => cpd.SanatoriumRoomId);

            modelBuilder.Entity<CostPerDay>()
                .HasMany(t => t.Treaties)
                .WithOne(cpd => cpd.CostPerDay)
                .HasForeignKey(t => t.CostPerDayId);

            modelBuilder.Entity<Client>()
                .HasMany(t => t.Treaties)
                .WithOne(c => c.Client)
                .HasForeignKey(t => t.ClientId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
