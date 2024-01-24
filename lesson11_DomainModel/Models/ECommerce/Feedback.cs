namespace lesson11_FabricMarket_DomainModel.Models.ECommerce
{
    public class Feedback : Entity<long>
    {
        public required Order Order { get; set; }
        public required Product Product { get; set; }
        public required int Rating { get; set; }
        public required string Message { get; set; }
        public required string PicturePath { get; set; }
        public required string ManagerComment { get; set; }
    }
}
