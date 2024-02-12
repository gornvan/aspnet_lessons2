using lesson11_FabricMarket_DomainModel.Models.SystemSettings;

namespace FabricMarket_BLL.Contracts.SystemSettings
{
    public interface ISystemSettingsService : IService
    {
        public Task<string?> ReadSetting(SystemSettingEnum settingId);

        public Task WriteSetting(SystemSettingEnum id, string value);
    }
}
