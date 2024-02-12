namespace lesson11_FabricMarket_DomainModel.Models.SystemSettings
{
    public class SystemSetting : Entity<SystemSettingEnum>
    {
        public required SystemSettingEnum SettingId { get; set; }
        public required string Value { get; set; }
    }
}
