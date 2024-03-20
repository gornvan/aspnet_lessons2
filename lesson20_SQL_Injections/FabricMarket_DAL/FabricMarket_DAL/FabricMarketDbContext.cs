using lesson11_FabricMarket_DomainModel.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FabricMarket_DAL
{
    public class FabricMarketDbContext : IdentityDbContext<User>
    {
        public FabricMarketDbContext(DbContextOptions<FabricMarketDbContext> options) : base(options)
        {

        }

        // public DbSet<Feedback> Feedbacks;
        // public DbSet<Order> Orders;
        // ... - use ApplyConfigurationsFromAssembly instead and create configs for entities

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
