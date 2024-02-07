namespace lesson11_FabricMarket_DomainModel.Models.SystemSettings
{
    public class SystemSettings
    {
        public required SystemSettingId SettingId { get; set; }
        public required string Value { get; set; }
    }
}
