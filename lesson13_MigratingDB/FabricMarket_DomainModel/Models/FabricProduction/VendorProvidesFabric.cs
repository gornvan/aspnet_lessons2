namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class VendorProvidesFabric : IEntityWithoutOwnId
    {
        public required Vendor Vendor { get; set; }
        public required FabricVariant FabricVariant { get; set; }
        public required decimal PricePerSquareMeter { get; set; }
    }
}
