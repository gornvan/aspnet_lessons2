namespace lesson11_FabricMarket_DomainModel.Models.ECommerce
{
    public class OrderReceiptCode : Entity<long>
    {
        public required Order Order { get ; set; }
        public required string Code { get; set; }
    }
}
