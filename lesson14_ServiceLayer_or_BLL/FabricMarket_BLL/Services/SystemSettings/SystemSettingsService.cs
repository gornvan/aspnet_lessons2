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

        public async Task WriteSetting(SystemSetting settingToWrite)
        {
            var repo = _unitOfWork.GetRepository<SystemSetting>();

            await repo.InsertOrUpdate(
                s => s.Id == settingToWrite.Id,
                settingToWrite
            );

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
