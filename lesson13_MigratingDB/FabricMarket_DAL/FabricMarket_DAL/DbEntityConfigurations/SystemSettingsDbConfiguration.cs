using lesson11_FabricMarket_DomainModel.Models.SystemSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations
{
    internal class SystemSettingsDbConfiguration : IEntityTypeConfiguration<SystemSettings>
    {
        public void Configure(EntityTypeBuilder<SystemSettings> builder)
        {
            builder.HasKey(ss => ss.SettingId);
        }
    }
}
