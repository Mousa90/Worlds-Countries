global using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WorldsCountriesAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=MOUSA-KALOUTI\\SS17;Database=WorldsCountriesDB;Trusted_Connection=true;TrustServerCertificate=true;"); ;
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //To stop tracking in EF Core.
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
