using lesson11_FabricMarket_DomainModel.Models.ECommerce;

namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class ProductRequiresFabric
    {
        public required FabricVariant FabricVariant { get; set; }
        public required Product Product { get; set; }
        public required decimal AreaOfFabric { get; set; }
    }
}
