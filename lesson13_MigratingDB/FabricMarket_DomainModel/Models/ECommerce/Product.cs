using lesson11_FabricMarket_DomainModel.Models.FabricProduction;

namespace lesson11_FabricMarket_DomainModel.Models.ECommerce
{
    public class Product : Entity<long>
    {
        public required string Name {get; set;}
        public required string Description {get; set;}
        public required string PicturePath { get; set; }

        public IEnumerable<ProductRequiresFabric>? RequiredFabrics { get; set; }
    }
}
