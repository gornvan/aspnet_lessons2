using Microsoft.EntityFrameworkCore;

namespace FabricMarket_DAL
{
    public class FabricMarketDbContext : DbContext
    {
        public FabricMarketDbContext(DbContextOptions<FabricMarketDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        // public DbSet<Feedback> Feedbacks;
        // public DbSet<Order> Orders;
        // ... - use ApplyConfigurationsFromAssembly instead and create configs for entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
