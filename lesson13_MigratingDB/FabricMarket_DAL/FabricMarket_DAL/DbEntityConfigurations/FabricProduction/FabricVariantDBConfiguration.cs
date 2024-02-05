using lesson11_FabricMarket_DomainModel.Models.FabricProduction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FabricMarket_DAL.DbEntityConfigurations.FabricProduction
{
    internal class FabricVariantDBConfiguration : IEntityTypeConfiguration<FabricVariant>
    {
        public void Configure(EntityTypeBuilder<FabricVariant> builder)
        {
            builder.HasOne<FabricType>()
                .WithMany(ft => ft.Variants);
        }
    }
}
