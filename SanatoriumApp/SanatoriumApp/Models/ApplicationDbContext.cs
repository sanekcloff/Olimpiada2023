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

        protected ApplicationDbContext()
        {
        }

        private const string connectionString = @"Server=localhost\SQLEXPRESS; Database=OLIMP_XX; Trusted_Connection=true;";

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
        public DbSet<SanatoriumRoom> SanatoriumRooms { get; set;} = null!;
        public DbSet<SanatoriumRoomCategory> SanatoriumRoomCategories { get; set; } = null!;
        public DbSet<Treaty> Treaties { get; set; } = null!;
    }
}
