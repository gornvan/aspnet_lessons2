using lesson11_FabricMarket_DomainModel.Models.ECommerce;
using Microsoft.EntityFrameworkCore;

namespace FabricMarket_DAL
{
    public class FabricMarketDbContext : DbContext
    {

        // public DbSet<Feedback> Feedbacks;
        // public DbSet<Order> Orders;
        // ...

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
