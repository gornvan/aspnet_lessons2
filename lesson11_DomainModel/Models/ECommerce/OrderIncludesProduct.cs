namespace lesson11_FabricMarket_DomainModel.Models.ECommerce
{
    public class OrderIncludesProduct
    {
        public required Order Order { get; set; }
        public required Product Product { get; set; }
        public required decimal CostAtOrderingTime { get; set; }
    }
}
