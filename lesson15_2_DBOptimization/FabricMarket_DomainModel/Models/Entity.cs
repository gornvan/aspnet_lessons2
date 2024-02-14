namespace lesson11_FabricMarket_DomainModel.Models
{
    public class Entity<TIdentifier> : IEntity
    {
        public TIdentifier? Id { get; set; }
    }
}
