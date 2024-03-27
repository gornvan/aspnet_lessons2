namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class Vendor : Entity<int>
    {
        public required string Name { get; set; }

        public virtual IEnumerable<VendorProvidesFabric>? Provides { get; set; }
    }
}
