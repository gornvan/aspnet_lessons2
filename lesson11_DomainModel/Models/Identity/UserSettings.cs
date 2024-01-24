namespace lesson11_FabricMarket_DomainModel.Models.Identity
{
    public class UserSettings
    {
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public required bool DarkThemeEnabled { get; set; }
    }
}
