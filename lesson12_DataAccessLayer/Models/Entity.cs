namespace lesson11_FabricMarket_DomainModel.Models
{
    public class Entity<TIdentifier>
    {
        public TIdentifier? Id { get; set; }
    }
}
