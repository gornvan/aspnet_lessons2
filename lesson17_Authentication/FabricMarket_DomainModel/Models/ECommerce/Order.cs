using lesson11_FabricMarket_DomainModel.Models.Identity;

namespace lesson11_FabricMarket_DomainModel.Models.ECommerce
{
    public class Order : Entity<long>
    {
        public required User User {get; set;}
        public required DateTime Date {get; set;}
        public required OrderStatusEnum Status { get; set; }
    }
}
