using FabricMarket_BLL.Contracts.SystemSettings;
using FabricMarket_DAL;
using lesson11_FabricMarket_DomainModel.Models.SystemSettings;
using Microsoft.EntityFrameworkCore;

namespace FabricMarket_BLL.Services.SystemSettings
{
    public class SystemSettingsService : ISystemSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemSettingsService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<string?> ReadSetting(SystemSettingEnum settingId)
        {
            var settingEntity = await _unitOfWork.GetRepository<SystemSetting>()
                .AsReadOnlyQueryable()
                .FirstOrDefaultAsync(s => s.Id == settingId);

            return settingEntity?.Value;
        }

        public async Task WriteSetting(SystemSettingEnum id, string value)
        {
            var setting = new SystemSetting { SettingId = id, Value = value };

            var repo = _unitOfWork.GetRepository<SystemSetting>();

            repo.Update(setting);

            var updatedCount = await _unitOfWork.SaveChangesAsync();
            if (updatedCount == 1)
            {
                return;
            }
            
            repo.Create(setting);
            var createdCount = await _unitOfWork.SaveChangesAsync();
            if (createdCount != 1)
            {
                throw new SettingsUpdateException(
                    $@"Expected to update 1 setting, but updated {updatedCount}"
                );
            }
        }
    }
}
