namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class FabricVariant : Entity<long>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required FabricType FabricType { get; set; }
        public required ColorEnum Color { get; set; }
        public required double Thickness { get; set; }
        public required double MassPerSquareMeter { get; set; }

        public virtual IEnumerable<VendorProvidesFabric>? Sources { get; set; }
        public virtual IEnumerable<ProductRequiresFabric>? DependentProducts { get; set; }
    }
}
