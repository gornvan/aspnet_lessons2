namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class FabricType : Entity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }

        public virtual IEnumerable<FabricVariant>? Variants { get; set; }
    }
}
