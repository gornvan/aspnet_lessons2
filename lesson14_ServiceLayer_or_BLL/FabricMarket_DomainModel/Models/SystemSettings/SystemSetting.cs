namespace lesson11_FabricMarket_DomainModel.Models.SystemSettings
{
    public class SystemSetting : Entity<SystemSettingEnum>
    {
        public required string Value { get; set; }
    }
}
