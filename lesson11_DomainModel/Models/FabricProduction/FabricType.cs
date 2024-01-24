namespace lesson11_FabricMarket_DomainModel.Models.FabricProduction
{
    public class FabricType : Entity<long>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
