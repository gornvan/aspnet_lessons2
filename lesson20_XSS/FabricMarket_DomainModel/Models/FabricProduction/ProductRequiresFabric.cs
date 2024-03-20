using lesson11_FabricMarket_DomainModel.Models.ECommerce;

namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class ProductRequiresFabric : IEntityWithoutOwnId
    {
        public required long ProductId { get; set; }
        public required int FabricVariantId { get; set; }
        public required decimal AreaOfFabric { get; set; }

        public required FabricVariant FabricVariant { get; set; }
        public required Product Product { get; set; }
    }
}
