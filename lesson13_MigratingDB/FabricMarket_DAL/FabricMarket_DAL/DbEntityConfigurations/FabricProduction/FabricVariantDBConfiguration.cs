using lesson11_FabricMarket_DomainModel.Models.FabricProduction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.FabricProduction
{
    internal class FabricVariantDBConfiguration : IEntityTypeConfiguration<FabricVariant>
    {
        public void Configure(EntityTypeBuilder<FabricVariant> builder)
        {
            builder.HasOne(fv => fv.FabricType)
                .WithMany(ft => ft.Variants);
        }
    }
}
