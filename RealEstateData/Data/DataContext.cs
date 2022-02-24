using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Model;

namespace RealEstateAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //for the real estate properties
        public DbSet<RealEstate> RealEstates { get; set; }
        //for the agents of the properties
        public DbSet<EstateAgent> EstateAgents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("server=(localdb)\\Local_New;database=RealEstateDB;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
