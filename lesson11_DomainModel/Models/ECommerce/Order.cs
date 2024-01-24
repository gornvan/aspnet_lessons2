using lesson11_FabricMarket_DomainModel.Models.Identity;

namespace lesson11_FabricMarket_DomainModel.Models.ECommerce
{
    public class Order
    {
        public required User User {get; set;}
        public required DateTime Date {get; set;}
        public required OrderStatus Status { get; set; }
    }
}
