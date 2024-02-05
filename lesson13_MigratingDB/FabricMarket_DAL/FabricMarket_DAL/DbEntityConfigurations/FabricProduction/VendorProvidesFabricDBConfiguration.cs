using lesson11_FabricMarket_DomainModel.Models.FabricProduction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.FabricProduction
{
    internal class VendorProvidesFabricDBConfiguration : IEntityTypeConfiguration<VendorProvidesFabric>
    {
        public void Configure(EntityTypeBuilder<VendorProvidesFabric> builder)
        {
            builder.HasOne<Vendor>().WithMany(v => v.Provides);

            builder.HasOne<FabricType>().WithMany(ft => ft.Sources);
        }
    }
}
