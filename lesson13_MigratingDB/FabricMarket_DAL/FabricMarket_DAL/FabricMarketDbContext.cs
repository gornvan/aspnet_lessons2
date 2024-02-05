using Microsoft.EntityFrameworkCore;

namespace FabricMarket_DAL
{
    public class FabricMarketDbContext : DbContext
    {
        public FabricMarketDbContext(DbContextOptions<FabricMarketDbContext> options) : base(options)
        {

        }

        // public DbSet<Feedback> Feedbacks;
        // public DbSet<Order> Orders;
        // ...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
