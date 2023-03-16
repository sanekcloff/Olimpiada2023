using Application2.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application2.Data
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
        private const string connectionString = @"";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { optionsBuilder.UseSqlServer(connectionString); }
        }

        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Contract> Contracts { get; set; }= null!;
        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<SanatoriumProgram> SanatoriumPrograms { get;set; } = null!;
        public DbSet<SanatoriumRoom> SanatoriumRooms { get; set; } = null!;
        public DbSet<SanatoriumRoomCategory> SanatoriumRoomCategories { get; set; } = null!;
    }
}
